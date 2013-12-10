namespace Ex2.FacebookApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_NewsFeedRepeater = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.m_PostItemTemplate = new Ex2.FacebookApp.UserControls.PostItemControl();
            this.postMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_BookmarkItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.opeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_RefreshNewsFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_AutoRefreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_TranslationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.m_TranslatorsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_LanguagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_PostsTabControl = new System.Windows.Forms.TabControl();
            this.m_NewsFeedTabPage = new System.Windows.Forms.TabPage();
            this.m_FavoritesTabPage = new System.Windows.Forms.TabPage();
            this.m_FavoritesRepeater = new Microsoft.VisualBasic.PowerPacks.DataRepeater();
            this.m_FavoritePostTemplate = new Ex2.FacebookApp.UserControls.PostItemControl();
            this.favoritePostMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromFavoritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_NewsFeedRepeater.ItemTemplate.SuspendLayout();
            this.m_NewsFeedRepeater.SuspendLayout();
            this.postMenuStrip.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.m_PostsTabControl.SuspendLayout();
            this.m_NewsFeedTabPage.SuspendLayout();
            this.m_FavoritesTabPage.SuspendLayout();
            this.m_FavoritesRepeater.ItemTemplate.SuspendLayout();
            this.m_FavoritesRepeater.SuspendLayout();
            this.favoritePostMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_NewsFeedRepeater
            // 
            this.m_NewsFeedRepeater.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // m_NewsFeedRepeater.ItemTemplate
            // 
            this.m_NewsFeedRepeater.ItemTemplate.Controls.Add(this.m_PostItemTemplate);
            this.m_NewsFeedRepeater.ItemTemplate.Size = new System.Drawing.Size(816, 163);
            this.m_NewsFeedRepeater.Location = new System.Drawing.Point(3, 3);
            this.m_NewsFeedRepeater.Name = "m_NewsFeedRepeater";
            this.m_NewsFeedRepeater.Size = new System.Drawing.Size(824, 356);
            this.m_NewsFeedRepeater.TabIndex = 3;
            // 
            // m_PostItemTemplate
            // 
            this.m_PostItemTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_PostItemTemplate.ContextMenuStrip = this.postMenuStrip;
            this.m_PostItemTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PostItemTemplate.FavoritesManager = null;
            this.m_PostItemTemplate.IsFavorite = false;
            this.m_PostItemTemplate.Location = new System.Drawing.Point(0, 0);
            this.m_PostItemTemplate.Name = "m_PostItemTemplate";
            this.m_PostItemTemplate.Post = null;
            this.m_PostItemTemplate.Size = new System.Drawing.Size(801, 162);
            this.m_PostItemTemplate.TabIndex = 0;
            this.m_PostItemTemplate.TranslatorHost = null;
            // 
            // postMenuStrip
            // 
            this.postMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_BookmarkItToolStripMenuItem});
            this.postMenuStrip.Name = "contextMenuStrip1";
            this.postMenuStrip.Size = new System.Drawing.Size(142, 26);
            // 
            // m_BookmarkItToolStripMenuItem
            // 
            this.m_BookmarkItToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_BookmarkItToolStripMenuItem.Image")));
            this.m_BookmarkItToolStripMenuItem.Name = "m_BookmarkItToolStripMenuItem";
            this.m_BookmarkItToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.m_BookmarkItToolStripMenuItem.Text = "Bookmark it!";
            this.m_BookmarkItToolStripMenuItem.Click += new System.EventHandler(this.m_BookmarkItToolStripMenuItem_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opeToolStripMenuItem,
            this.m_TranslationMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(838, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "File";
            // 
            // opeToolStripMenuItem
            // 
            this.opeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_RefreshNewsFeedToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.m_ExitToolStripMenuItem});
            this.opeToolStripMenuItem.Name = "opeToolStripMenuItem";
            this.opeToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opeToolStripMenuItem.Text = "Actions";
            // 
            // m_RefreshNewsFeedToolStripMenuItem
            // 
            this.m_RefreshNewsFeedToolStripMenuItem.Name = "m_RefreshNewsFeedToolStripMenuItem";
            this.m_RefreshNewsFeedToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_RefreshNewsFeedToolStripMenuItem.Text = "Refresh News Feed";
            this.m_RefreshNewsFeedToolStripMenuItem.Click += new System.EventHandler(this.m_RefreshNewsFeedToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_AutoRefreshMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // m_AutoRefreshMenuItem
            // 
            this.m_AutoRefreshMenuItem.Name = "m_AutoRefreshMenuItem";
            this.m_AutoRefreshMenuItem.Size = new System.Drawing.Size(195, 22);
            this.m_AutoRefreshMenuItem.Text = "Auto refresh news feed";
            this.m_AutoRefreshMenuItem.Click += new System.EventHandler(this.m_AutoRefreshMenuItem_Click);
            // 
            // m_ExitToolStripMenuItem
            // 
            this.m_ExitToolStripMenuItem.Name = "m_ExitToolStripMenuItem";
            this.m_ExitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_ExitToolStripMenuItem.Text = "Exit";
            this.m_ExitToolStripMenuItem.Click += new System.EventHandler(this.m_ExitToolStripMenuItem_Click);
            // 
            // m_TranslationMenu
            // 
            this.m_TranslationMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_TranslatorsMenuItem,
            this.m_LanguagesMenuItem});
            this.m_TranslationMenu.Name = "m_TranslationMenu";
            this.m_TranslationMenu.Size = new System.Drawing.Size(78, 20);
            this.m_TranslationMenu.Text = "Translation";
            // 
            // m_TranslatorsMenuItem
            // 
            this.m_TranslatorsMenuItem.Name = "m_TranslatorsMenuItem";
            this.m_TranslatorsMenuItem.Size = new System.Drawing.Size(160, 22);
            this.m_TranslatorsMenuItem.Text = "Translator";
            // 
            // m_LanguagesMenuItem
            // 
            this.m_LanguagesMenuItem.Name = "m_LanguagesMenuItem";
            this.m_LanguagesMenuItem.Size = new System.Drawing.Size(160, 22);
            this.m_LanguagesMenuItem.Text = "Target language";
            // 
            // m_PostsTabControl
            // 
            this.m_PostsTabControl.Controls.Add(this.m_NewsFeedTabPage);
            this.m_PostsTabControl.Controls.Add(this.m_FavoritesTabPage);
            this.m_PostsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PostsTabControl.Location = new System.Drawing.Point(0, 24);
            this.m_PostsTabControl.Name = "m_PostsTabControl";
            this.m_PostsTabControl.SelectedIndex = 0;
            this.m_PostsTabControl.Size = new System.Drawing.Size(838, 388);
            this.m_PostsTabControl.TabIndex = 4;
            // 
            // m_NewsFeedTabPage
            // 
            this.m_NewsFeedTabPage.Controls.Add(this.m_NewsFeedRepeater);
            this.m_NewsFeedTabPage.Location = new System.Drawing.Point(4, 22);
            this.m_NewsFeedTabPage.Name = "m_NewsFeedTabPage";
            this.m_NewsFeedTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.m_NewsFeedTabPage.Size = new System.Drawing.Size(830, 362);
            this.m_NewsFeedTabPage.TabIndex = 0;
            this.m_NewsFeedTabPage.Text = "News Feed";
            this.m_NewsFeedTabPage.UseVisualStyleBackColor = true;
            // 
            // m_FavoritesTabPage
            // 
            this.m_FavoritesTabPage.Controls.Add(this.m_FavoritesRepeater);
            this.m_FavoritesTabPage.Location = new System.Drawing.Point(4, 22);
            this.m_FavoritesTabPage.Name = "m_FavoritesTabPage";
            this.m_FavoritesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.m_FavoritesTabPage.Size = new System.Drawing.Size(830, 362);
            this.m_FavoritesTabPage.TabIndex = 1;
            this.m_FavoritesTabPage.Text = "Favorites";
            this.m_FavoritesTabPage.UseVisualStyleBackColor = true;
            // 
            // m_FavoritesRepeater
            // 
            this.m_FavoritesRepeater.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // m_FavoritesRepeater.ItemTemplate
            // 
            this.m_FavoritesRepeater.ItemTemplate.Controls.Add(this.m_FavoritePostTemplate);
            this.m_FavoritesRepeater.ItemTemplate.Size = new System.Drawing.Size(816, 163);
            this.m_FavoritesRepeater.Location = new System.Drawing.Point(3, 3);
            this.m_FavoritesRepeater.Name = "m_FavoritesRepeater";
            this.m_FavoritesRepeater.Size = new System.Drawing.Size(824, 356);
            this.m_FavoritesRepeater.TabIndex = 0;
            this.m_FavoritesRepeater.Text = "dataRepeater1";
            // 
            // m_FavoritePostTemplate
            // 
            this.m_FavoritePostTemplate.BackColor = System.Drawing.Color.Honeydew;
            this.m_FavoritePostTemplate.ContextMenuStrip = this.favoritePostMenuStrip;
            this.m_FavoritePostTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_FavoritePostTemplate.FavoritesManager = null;
            this.m_FavoritePostTemplate.IsFavorite = false;
            this.m_FavoritePostTemplate.Location = new System.Drawing.Point(0, 0);
            this.m_FavoritePostTemplate.Name = "m_FavoritePostTemplate";
            this.m_FavoritePostTemplate.Post = null;
            this.m_FavoritePostTemplate.Size = new System.Drawing.Size(801, 162);
            this.m_FavoritePostTemplate.TabIndex = 0;
            this.m_FavoritePostTemplate.TranslatorHost = null;
            // 
            // favoritePostMenuStrip
            // 
            this.favoritePostMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromFavoritesToolStripMenuItem});
            this.favoritePostMenuStrip.Name = "favoritePostMenuStrip";
            this.favoritePostMenuStrip.Size = new System.Drawing.Size(195, 26);
            // 
            // removeFromFavoritesToolStripMenuItem
            // 
            this.removeFromFavoritesToolStripMenuItem.Image = global::Ex2.FacebookApp.Properties.Resources.Delete;
            this.removeFromFavoritesToolStripMenuItem.Name = "removeFromFavoritesToolStripMenuItem";
            this.removeFromFavoritesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.removeFromFavoritesToolStripMenuItem.Text = "Remove from favorites";
            this.removeFromFavoritesToolStripMenuItem.Click += new System.EventHandler(this.removeFromFavoritesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 412);
            this.Controls.Add(this.m_PostsTabControl);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Cool facebook app";
            this.Load += new System.EventHandler(this.MainWin_Load);
            this.m_NewsFeedRepeater.ItemTemplate.ResumeLayout(false);
            this.m_NewsFeedRepeater.ResumeLayout(false);
            this.postMenuStrip.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.m_PostsTabControl.ResumeLayout(false);
            this.m_NewsFeedTabPage.ResumeLayout(false);
            this.m_FavoritesTabPage.ResumeLayout(false);
            this.m_FavoritesRepeater.ItemTemplate.ResumeLayout(false);
            this.m_FavoritesRepeater.ResumeLayout(false);
            this.favoritePostMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem opeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_TranslationMenu;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater m_NewsFeedRepeater;
        private UserControls.PostItemControl m_PostItemTemplate;
        private System.Windows.Forms.ContextMenuStrip postMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem m_BookmarkItToolStripMenuItem;
        private System.Windows.Forms.TabControl m_PostsTabControl;
        private System.Windows.Forms.TabPage m_NewsFeedTabPage;
        private System.Windows.Forms.TabPage m_FavoritesTabPage;
        private Microsoft.VisualBasic.PowerPacks.DataRepeater m_FavoritesRepeater;
        private UserControls.PostItemControl m_FavoritePostTemplate;
        private System.Windows.Forms.ContextMenuStrip favoritePostMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeFromFavoritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_TranslatorsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_RefreshNewsFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_LanguagesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_AutoRefreshMenuItem;
    }
}