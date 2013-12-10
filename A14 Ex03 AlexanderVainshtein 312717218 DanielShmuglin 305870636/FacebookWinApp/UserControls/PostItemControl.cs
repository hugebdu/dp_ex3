using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using Ex2.FacebookApp.Model;
using Ex2.FacebookApp.Model.Translator;

namespace Ex2.FacebookApp.UserControls
{
    public partial class PostItemControl : UserControl
    {
        private LinkViewForm m_LinkViewForm;

        private UserForm m_UserForm;

        public ITranslatorHost TranslatorHost { get; set; }

        private bool m_PostIsTranslated;

        private Post m_Post;

        public Post Post
        {
            get
            {
                return m_Post;
            }

            set
            {
                if (m_Post != value)
                {
                    m_Post = value;
                    m_PostIsTranslated = false;
                    updateView();
                }
            }
        }

        private FavoritesManager m_FavoritesManager;

        public FavoritesManager FavoritesManager
        {
            get
            {
                return m_FavoritesManager;
            }

            set
            {
                if (value != m_FavoritesManager)
                {
                    const bool v_Subscribe = true;
                    registerFavoriteManagerEvents(!v_Subscribe);
                    m_FavoritesManager = value;
                    registerFavoriteManagerEvents(v_Subscribe);
                }
            }
        }

        public bool IsFavorite
        {
            get
            {
                return FavoritesManager != null ? FavoritesManager.GetFavoritePosts().Any(post => post.Id == m_Post.Id) : false;
            }

            set
            {
                if (FavoritesManager == null)
                {
                    return;
                }

                if (value)
                {
                    FavoritesManager.MarkFavorite(m_Post);
                }
                else
                {
                    FavoritesManager.UnmarkFavorite(m_Post);
                }

                updateIsFavoriteView();
            }
        }

        public PostItemControl()
        {
            InitializeComponent();
        }

        private void updateView()
        {
            long likesCount = 0;
            if (m_Post != null)
            {
                if ((m_Post as PostedItem).LikedBy != null)
                {
                    likesCount = (m_Post as PostedItem).LikedBy.Count;
                }
                else
                {
                    likesCount = m_Post.LikesCount;
                }
            }

            Utils.UpdateControlText(m_Name, m_Post == null || m_Post.From == null ? string.Empty : m_Post.From.Name);
            Utils.UpdateControlText(m_LikesCountLabel, likesCount.ToString());
            Utils.UpdateImage(m_UserPicture, m_Post == null || m_Post.From == null ? null : m_Post.From.ImageNormal);
            Utils.UpdateControlText(m_CreationDateLabel, m_Post == null || !m_Post.CreatedTime.HasValue ? null : m_Post.CreatedTime.Value.ToString());
            updatePostBody();
            updateIsFavoriteView();
        }

        private void updatePostBody()
        {
            var rftBodyHelper = new RtfHelper();
            string header = null;

            if (m_Post != null)
            {
                var postType = m_Post.Type.HasValue ? m_Post.Type.Value : FacebookWrapper.ObjectModel.Post.eType.status;
                switch (postType)
                {
                    case Post.eType.checkin:
                        header = "has checked in:";
                        break;
                    case Post.eType.link:
                        header = "has posted a link:";
                        break;
                    case Post.eType.photo:
                        header = "has posted a photo:";
                        break;
                    case Post.eType.status:
                        break;
                    case Post.eType.swf:
                        header = "has posted a clip:";
                        break;
                    case Post.eType.video:
                        header = "has posted a video:";
                        break;
                    default:
                        break;
                }

                rftBodyHelper.AppendLine(header);
                rftBodyHelper.AppendLine(m_Post.Message);
                rftBodyHelper.AppendBoldText(m_Post.Name);
                rftBodyHelper.AppendNewLine();
                rftBodyHelper.AppendLine(m_Post.Link);
            }

            Utils.UpdateRtfText(m_PostBody, rftBodyHelper.RtfText);
        }

        private void m_TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_PostIsTranslated || TranslatorHost == null || TranslatorHost.ActiveTranslator == null)
            {
                return;
            }

            if (m_TabControl.SelectedTab == m_TranslatedTab)
            {
                TranslatorHost.ActiveTranslator.AsyncTranslate(m_PostBody.Text, (result) => Utils.UpdateControlText(m_TranslatedPostBody, result.TranslatedOrOriginText));
                m_PostIsTranslated = true;
            }
        }

        private void m_PostBody_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            ensureBrowserExists();
            m_LinkViewForm.Url = e.LinkText;
            m_LinkViewForm.Show();
        }

        private void m_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_Post != null)
            {
                ensureUserFromExists();
                m_UserForm.User = m_Post.From;
                m_UserForm.Show(this);
            }
        }

        private void ensureBrowserExists()
        {
            if (m_LinkViewForm != null)
            {
                return;
            }

            m_LinkViewForm = new LinkViewForm();
            m_LinkViewForm.FormClosed += (sender, e) => m_LinkViewForm = null;
        }

        private void ensureUserFromExists()
        {
            if (m_UserForm != null)
            {
                return;
            }

            m_UserForm = new UserForm();
            m_UserForm.FormClosed += (sender, e) => m_UserForm = null;
        }

        private void m_ViewPostLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_Post != null)
            {
                string postUrl = null;
                if (m_Post.Type.HasValue && m_Post.Type.Value == FacebookWrapper.ObjectModel.Post.eType.photo)
                {
                    postUrl = m_Post.Link;
                }

                postUrl = postUrl ?? string.Format("http://www.facebook.com/{0}", m_Post.Id);
                Process.Start(postUrl);
            }
        }

        private void m_FavoriteBox_Click(object sender, EventArgs e)
        {
            if (FavoritesManager != null)
            {
                IsFavorite = !IsFavorite;
            }
        }

        private void updateIsFavoriteView()
        {
            m_FavoriteBox.Image = IsFavorite ? Properties.Resources.star : m_FavoriteBox.Image = Properties.Resources.empty_star;
        }

        private void registerFavoriteManagerEvents(bool i_Subscribe)
        {
            if (m_FavoritesManager == null)
            {
                return;
            }

            if (i_Subscribe)
            {
                m_FavoritesManager.FavoriteAdded += m_FavoritesManager_FavoriteAdded;
                m_FavoritesManager.FavoriteRemoved += m_FavoritesManager_FavoriteRemoved;
            }
            else
            {
                m_FavoritesManager.FavoriteAdded -= m_FavoritesManager_FavoriteAdded;
                m_FavoritesManager.FavoriteRemoved -= m_FavoritesManager_FavoriteRemoved;
            }
        }

        void m_FavoritesManager_FavoriteRemoved(object i_Sender, Post i_Post)
        {
            if (i_Post.Id == Post.Id)
            {
                updateIsFavoriteView();
            }
        }

        void m_FavoritesManager_FavoriteAdded(object i_Sender, Post i_Post)
        {
            if (i_Post.Id == Post.Id)
            {
                updateIsFavoriteView();
            }
        }
    }
}