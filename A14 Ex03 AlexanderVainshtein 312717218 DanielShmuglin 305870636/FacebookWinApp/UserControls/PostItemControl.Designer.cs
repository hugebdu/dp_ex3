namespace Ex2.FacebookApp.UserControls
{
    partial class PostItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_Name = new System.Windows.Forms.LinkLabel();
            this.m_BodyPannel = new System.Windows.Forms.Panel();
            this.m_TabControl = new System.Windows.Forms.TabControl();
            this.m_OriginalTab = new System.Windows.Forms.TabPage();
            this.m_PostBody = new System.Windows.Forms.RichTextBox();
            this.m_TranslatedTab = new System.Windows.Forms.TabPage();
            this.m_TranslatedPostBody = new System.Windows.Forms.RichTextBox();
            this.m_LikesLabel = new System.Windows.Forms.Label();
            this.m_LeftPanel = new System.Windows.Forms.Panel();
            this.m_LikesCountLabel = new System.Windows.Forms.Label();
            this.m_ViewPostLink = new System.Windows.Forms.LinkLabel();
            this.m_CreationDateLabel = new System.Windows.Forms.Label();
            this.m_FavoriteBox = new System.Windows.Forms.PictureBox();
            this.m_UserPicture = new System.Windows.Forms.PictureBox();
            this.m_BodyPannel.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_OriginalTab.SuspendLayout();
            this.m_TranslatedTab.SuspendLayout();
            this.m_LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_FavoriteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_UserPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // m_Name
            // 
            this.m_Name.AutoSize = true;
            this.m_Name.Location = new System.Drawing.Point(3, 83);
            this.m_Name.Name = "m_Name";
            this.m_Name.Size = new System.Drawing.Size(35, 13);
            this.m_Name.TabIndex = 2;
            this.m_Name.TabStop = true;
            this.m_Name.Text = "[User]";
            this.m_Name.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_Name_LinkClicked);
            // 
            // m_BodyPannel
            // 
            this.m_BodyPannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BodyPannel.Controls.Add(this.m_TabControl);
            this.m_BodyPannel.Location = new System.Drawing.Point(127, 0);
            this.m_BodyPannel.Name = "m_BodyPannel";
            this.m_BodyPannel.Size = new System.Drawing.Size(674, 164);
            this.m_BodyPannel.TabIndex = 3;
            // 
            // m_TabControl
            // 
            this.m_TabControl.Controls.Add(this.m_OriginalTab);
            this.m_TabControl.Controls.Add(this.m_TranslatedTab);
            this.m_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TabControl.Location = new System.Drawing.Point(0, 0);
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.Size = new System.Drawing.Size(674, 164);
            this.m_TabControl.TabIndex = 5;
            this.m_TabControl.SelectedIndexChanged += new System.EventHandler(this.m_TabControl_SelectedIndexChanged);
            // 
            // m_OriginalTab
            // 
            this.m_OriginalTab.Controls.Add(this.m_PostBody);
            this.m_OriginalTab.Location = new System.Drawing.Point(4, 22);
            this.m_OriginalTab.Name = "m_OriginalTab";
            this.m_OriginalTab.Padding = new System.Windows.Forms.Padding(3);
            this.m_OriginalTab.Size = new System.Drawing.Size(666, 138);
            this.m_OriginalTab.TabIndex = 0;
            this.m_OriginalTab.Text = "Original";
            this.m_OriginalTab.UseVisualStyleBackColor = true;
            // 
            // m_PostBody
            // 
            this.m_PostBody.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_PostBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PostBody.Location = new System.Drawing.Point(3, 3);
            this.m_PostBody.Name = "m_PostBody";
            this.m_PostBody.ReadOnly = true;
            this.m_PostBody.Size = new System.Drawing.Size(660, 132);
            this.m_PostBody.TabIndex = 0;
            this.m_PostBody.Text = "";
            this.m_PostBody.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.m_PostBody_LinkClicked);
            // 
            // m_TranslatedTab
            // 
            this.m_TranslatedTab.Controls.Add(this.m_TranslatedPostBody);
            this.m_TranslatedTab.Location = new System.Drawing.Point(4, 22);
            this.m_TranslatedTab.Name = "m_TranslatedTab";
            this.m_TranslatedTab.Padding = new System.Windows.Forms.Padding(3);
            this.m_TranslatedTab.Size = new System.Drawing.Size(666, 138);
            this.m_TranslatedTab.TabIndex = 1;
            this.m_TranslatedTab.Tag = "TranslationTarget";
            this.m_TranslatedTab.Text = "Translated";
            this.m_TranslatedTab.UseVisualStyleBackColor = true;
            // 
            // m_TranslatedPostBody
            // 
            this.m_TranslatedPostBody.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_TranslatedPostBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TranslatedPostBody.Location = new System.Drawing.Point(3, 3);
            this.m_TranslatedPostBody.Name = "m_TranslatedPostBody";
            this.m_TranslatedPostBody.ReadOnly = true;
            this.m_TranslatedPostBody.Size = new System.Drawing.Size(660, 132);
            this.m_TranslatedPostBody.TabIndex = 1;
            this.m_TranslatedPostBody.Text = "";
            this.m_TranslatedPostBody.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.m_PostBody_LinkClicked);
            // 
            // m_LikesLabel
            // 
            this.m_LikesLabel.AutoSize = true;
            this.m_LikesLabel.Location = new System.Drawing.Point(4, 121);
            this.m_LikesLabel.Name = "m_LikesLabel";
            this.m_LikesLabel.Size = new System.Drawing.Size(35, 13);
            this.m_LikesLabel.TabIndex = 5;
            this.m_LikesLabel.Text = "Likes:";
            // 
            // m_LeftPanel
            // 
            this.m_LeftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_LeftPanel.Controls.Add(this.m_CreationDateLabel);
            this.m_LeftPanel.Controls.Add(this.m_FavoriteBox);
            this.m_LeftPanel.Controls.Add(this.m_LikesCountLabel);
            this.m_LeftPanel.Controls.Add(this.m_ViewPostLink);
            this.m_LeftPanel.Controls.Add(this.m_UserPicture);
            this.m_LeftPanel.Controls.Add(this.m_LikesLabel);
            this.m_LeftPanel.Controls.Add(this.m_Name);
            this.m_LeftPanel.Location = new System.Drawing.Point(3, 3);
            this.m_LeftPanel.Name = "m_LeftPanel";
            this.m_LeftPanel.Size = new System.Drawing.Size(118, 160);
            this.m_LeftPanel.TabIndex = 6;
            // 
            // m_LikesCountLabel
            // 
            this.m_LikesCountLabel.AutoSize = true;
            this.m_LikesCountLabel.Location = new System.Drawing.Point(37, 121);
            this.m_LikesCountLabel.Name = "m_LikesCountLabel";
            this.m_LikesCountLabel.Size = new System.Drawing.Size(13, 13);
            this.m_LikesCountLabel.TabIndex = 7;
            this.m_LikesCountLabel.Text = "0";
            // 
            // m_ViewPostLink
            // 
            this.m_ViewPostLink.AutoSize = true;
            this.m_ViewPostLink.Location = new System.Drawing.Point(3, 102);
            this.m_ViewPostLink.Name = "m_ViewPostLink";
            this.m_ViewPostLink.Size = new System.Drawing.Size(80, 13);
            this.m_ViewPostLink.TabIndex = 6;
            this.m_ViewPostLink.TabStop = true;
            this.m_ViewPostLink.Text = "View post in FB";
            this.m_ViewPostLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_ViewPostLink_LinkClicked);
            // 
            // m_CreationDateLabel
            // 
            this.m_CreationDateLabel.AutoSize = true;
            this.m_CreationDateLabel.Location = new System.Drawing.Point(-1, 141);
            this.m_CreationDateLabel.Name = "m_CreationDateLabel";
            this.m_CreationDateLabel.Size = new System.Drawing.Size(78, 13);
            this.m_CreationDateLabel.TabIndex = 9;
            this.m_CreationDateLabel.Text = "[Creation Date]";
            // 
            // m_FavoriteBox
            // 
            this.m_FavoriteBox.Image = global::Ex2.FacebookApp.Properties.Resources.empty_star;
            this.m_FavoriteBox.InitialImage = global::Ex2.FacebookApp.Properties.Resources.empty_star;
            this.m_FavoriteBox.Location = new System.Drawing.Point(86, 114);
            this.m_FavoriteBox.Name = "m_FavoriteBox";
            this.m_FavoriteBox.Size = new System.Drawing.Size(25, 23);
            this.m_FavoriteBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_FavoriteBox.TabIndex = 8;
            this.m_FavoriteBox.TabStop = false;
            this.m_FavoriteBox.Click += new System.EventHandler(this.m_FavoriteBox_Click);
            // 
            // m_UserPicture
            // 
            this.m_UserPicture.Location = new System.Drawing.Point(9, 3);
            this.m_UserPicture.Name = "m_UserPicture";
            this.m_UserPicture.Size = new System.Drawing.Size(98, 73);
            this.m_UserPicture.TabIndex = 0;
            this.m_UserPicture.TabStop = false;
            // 
            // PostItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_LeftPanel);
            this.Controls.Add(this.m_BodyPannel);
            this.DoubleBuffered = true;
            this.Name = "PostItemControl";
            this.Size = new System.Drawing.Size(804, 167);
            this.m_BodyPannel.ResumeLayout(false);
            this.m_TabControl.ResumeLayout(false);
            this.m_OriginalTab.ResumeLayout(false);
            this.m_TranslatedTab.ResumeLayout(false);
            this.m_LeftPanel.ResumeLayout(false);
            this.m_LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_FavoriteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_UserPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_UserPicture;
        private System.Windows.Forms.Panel m_BodyPannel;
        private System.Windows.Forms.RichTextBox m_PostBody;
        private System.Windows.Forms.LinkLabel m_Name;
        private System.Windows.Forms.TabControl m_TabControl;
        private System.Windows.Forms.TabPage m_OriginalTab;
        private System.Windows.Forms.TabPage m_TranslatedTab;
        private System.Windows.Forms.RichTextBox m_TranslatedPostBody;
        private System.Windows.Forms.Label m_LikesLabel;
        private System.Windows.Forms.Panel m_LeftPanel;
        private System.Windows.Forms.LinkLabel m_ViewPostLink;
        private System.Windows.Forms.Label m_LikesCountLabel;
        private System.Windows.Forms.PictureBox m_FavoriteBox;
        private System.Windows.Forms.Label m_CreationDateLabel;
    }
}
