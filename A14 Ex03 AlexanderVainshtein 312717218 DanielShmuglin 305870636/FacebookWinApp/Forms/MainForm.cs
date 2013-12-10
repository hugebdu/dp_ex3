using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.VisualBasic.PowerPacks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Ex2.FacebookApp.UserControls;
using Ex2.FacebookApp.Model;
using Ex2.FacebookApp.Model.Translator;

namespace Ex2.FacebookApp
{
    public partial class MainForm : Form, ITranslatorHost
    {
        private const eTranslatorType k_DefaultTranslator = eTranslatorType.Dummy;
        private const eTranslationLang k_DefaultTargetLanguage = eTranslationLang.he;
        private const string k_FavoritesTabTitle = "Favorites";
        private const int k_RefreshIntervalMs = 60000;

        private class PostWrapper
        {
            public Post Post { get; set; }

            public ITranslatorHost TranslatorHost { get; set; }

            public FavoritesManager FavoritesManager { get; set; }
        }

        private FavoritesManager m_FavoritesManager;
        private readonly Timer r_FeedRefreshTimer = new Timer();
        private readonly Dictionary<string, ITranslator> r_Translators = new Dictionary<string, ITranslator>();
        private User m_User;
        private eTranslatorType m_SelectedTranslatorType = k_DefaultTranslator;
        private eTranslationLang m_SelectedTargetLanguage = k_DefaultTargetLanguage;

        public ITranslator ActiveTranslator
        {
            get
            {
                string currentKey = string.Format("{0}.{1}", m_SelectedTranslatorType, m_SelectedTargetLanguage);

                if (!r_Translators.ContainsKey(currentKey))
                {
                    r_Translators.Add(currentKey, TranslatorFactory.Create(m_SelectedTranslatorType, m_SelectedTargetLanguage));
                }

                return r_Translators[currentKey];
            }
        }

        public MainForm(LoginResult i_LoginResult)
        {
            m_User = i_LoginResult.LoggedInUser;
            InitializeComponent();
            initializeTimer();
            initializeFavoritesManager();
        }

        private void initializeFavoritesManager()
        {
            m_FavoritesManager = new FavoritesManager(m_User.Id);
            m_FavoritesManager.FavoriteAdded += m_FavoritesManager_FavoriteAdded;
            m_FavoritesManager.FavoriteRemoved += m_FavoritesManager_FavoriteRemoved;
        }

        private void initializeTimer()
        {
            r_FeedRefreshTimer.Interval = k_RefreshIntervalMs;
            r_FeedRefreshTimer.Tick += new EventHandler(m_FeedRefreshTimer_Tick);
            updateRefreshTimeState();
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            loadNewFeedAsync();
            loadFavoritesAsync();
            createTranslationMenu();
        }

        private void m_FavoritesManager_FavoriteRemoved(object i_Sender, Post i_Post)
        {
            var favoritePosts = m_FavoritesRepeater.DataSource as List<PostWrapper>;
            favoritePosts.RemoveAll(pw => pw.Post.Id == i_Post.Id);
            m_FavoritesRepeater.DataSource = new List<PostWrapper>(favoritePosts);
            updateFavoritesTabTitle(favoritePosts.Count);
        }

        private void m_FavoritesManager_FavoriteAdded(object i_Sender, Post i_Post)
        {
            loadFavoritesAsync();
        }

        void m_FeedRefreshTimer_Tick(object sender, EventArgs e)
        {
            loadNewFeedAsync();
        }

        private void loadNewFeedAsync()
        {
            new Task(loadNewsFeed).Start();
        }

        private void loadNewsFeed()
        {
            var posts = m_User.NewsFeed.Select(post => createPostWrapper(post)).ToList();
            updatePostRepeater(m_NewsFeedRepeater, m_PostItemTemplate, posts);
        }

        private void loadFavoritesAsync()
        {
            m_FavoritesManager.GetFavoritePostsAsync(
                new Action<IEnumerable<Post>>(
                    (result) =>
                    {
                        var posts = result.Select(post => createPostWrapper(post)).ToList();
                        updatePostRepeater(m_FavoritesRepeater, m_FavoritePostTemplate, posts);
                        updateFavoritesTabTitle(posts.Count);
                    }));
        }

        private PostWrapper createPostWrapper(Post i_Post)
        {
            return new PostWrapper()
                {
                    Post = i_Post,
                    TranslatorHost = this,
                    FavoritesManager = m_FavoritesManager
                };
        }

        private void updatePostRepeater(DataRepeater i_Repeater, Control template, List<PostWrapper> i_Posts)
        {
            template.DataBindings.Clear();
            template.DataBindings.Add("TranslatorHost", i_Posts, "TranslatorHost");
            template.DataBindings.Add("FavoritesManager", i_Posts, "FavoritesManager");
            template.DataBindings.Add("Post", i_Posts, "Post");

            if (i_Repeater.InvokeRequired)
            {
                i_Repeater.Invoke(new Action(() => i_Repeater.DataSource = i_Posts));
            }
            else
            {
                i_Repeater.DataSource = i_Posts;
            }
        }

        private void m_BookmarkItToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sourceControl = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as PostItemControl;
            if (sourceControl != null && sourceControl.Post != null)
            {
                m_FavoritesManager.MarkFavorite(sourceControl.Post);
                loadFavoritesAsync();
            }
        }

        private void removeFromFavoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sourceControl = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as PostItemControl;
            if (sourceControl != null && sourceControl.Post != null)
            {
                m_FavoritesManager.UnmarkFavorite(sourceControl.Post);
                loadFavoritesAsync();
            }
        }

        private void m_ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_RefreshNewsFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadNewFeedAsync();
        }

        private void updateFavoritesTabTitle(int i_FavoritesCount)
        {
            Utils.UpdateControlText(m_FavoritesTabPage, string.Format("{0}({1})", k_FavoritesTabTitle, i_FavoritesCount));
        }

        private void createTranslationMenu()
        {
            addTranslatorsToMenu();
            addLanguagesToMenu();
        }

        private void addTranslatorsToMenu()
        {
            foreach (var value in Enum.GetValues(typeof(eTranslatorType)))
            {
                var translatorType = (eTranslatorType)value;
                var menuItem = new ToolStripMenuItem(translatorType.ToString());
                menuItem.Click += translatorMenuItem_Click;
                menuItem.Checked = translatorType == k_DefaultTranslator;
                m_TranslatorsMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void translatorMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                m_SelectedTranslatorType = (eTranslatorType)Enum.Parse(typeof(eTranslatorType), menuItem.Text);
                checkSelectedItem(m_TranslatorsMenuItem, menuItem);
            }
        }

        private void addLanguagesToMenu()
        {
            foreach (var value in Enum.GetValues(typeof(eTranslationLang)))
            {
                var language = (eTranslationLang)value;
                var menuItem = new ToolStripMenuItem(language.ToString());
                menuItem.Click += languageMenuItem_Click;
                menuItem.Checked = language == k_DefaultTargetLanguage;
                m_LanguagesMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void languageMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                m_SelectedTargetLanguage = (eTranslationLang)Enum.Parse(typeof(eTranslationLang), menuItem.Text);
                checkSelectedItem(m_LanguagesMenuItem, menuItem);
            }
        }

        private void checkSelectedItem(ToolStripMenuItem i_Parent, ToolStripMenuItem i_SelectedItem)
        {
            foreach (var item in i_Parent.DropDownItems)
            {
                (item as ToolStripMenuItem).Checked = item == i_SelectedItem;
            }
        }

        private void m_AutoRefreshMenuItem_Click(object sender, EventArgs e)
        {
            m_AutoRefreshMenuItem.Checked = !m_AutoRefreshMenuItem.Checked;
            updateRefreshTimeState();
        }

        private void updateRefreshTimeState()
        {
            if (m_AutoRefreshMenuItem.Checked)
            {
                r_FeedRefreshTimer.Start();
            }
            else
            {
                r_FeedRefreshTimer.Stop();
            }
        }

    }
}