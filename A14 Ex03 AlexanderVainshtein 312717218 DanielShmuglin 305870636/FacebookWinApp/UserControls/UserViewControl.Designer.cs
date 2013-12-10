namespace Ex2.FacebookApp.UserControls
{
    partial class UserViewControl
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
            this.m_UsernameLabel = new System.Windows.Forms.Label();
            this.m_FBLink = new System.Windows.Forms.LinkLabel();
            this.m_OtherInfo = new System.Windows.Forms.Label();
            this.m_UserGroupBox = new System.Windows.Forms.GroupBox();
            this.m_Userpic = new System.Windows.Forms.PictureBox();
            this.m_UserGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_Userpic)).BeginInit();
            this.SuspendLayout();
            // 
            // m_UsernameLabel
            // 
            this.m_UsernameLabel.AutoSize = true;
            this.m_UsernameLabel.Location = new System.Drawing.Point(6, 166);
            this.m_UsernameLabel.Name = "m_UsernameLabel";
            this.m_UsernameLabel.Size = new System.Drawing.Size(39, 13);
            this.m_UsernameLabel.TabIndex = 1;
            this.m_UsernameLabel.Text = "[name]";
            // 
            // m_FBLink
            // 
            this.m_FBLink.AutoSize = true;
            this.m_FBLink.Location = new System.Drawing.Point(6, 217);
            this.m_FBLink.Name = "m_FBLink";
            this.m_FBLink.Size = new System.Drawing.Size(90, 13);
            this.m_FBLink.TabIndex = 2;
            this.m_FBLink.TabStop = true;
            this.m_FBLink.Text = "Open user\'s page";
            this.m_FBLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_FBLink_LinkClicked);
            // 
            // m_OtherInfo
            // 
            this.m_OtherInfo.AutoSize = true;
            this.m_OtherInfo.Location = new System.Drawing.Point(6, 192);
            this.m_OtherInfo.Name = "m_OtherInfo";
            this.m_OtherInfo.Size = new System.Drawing.Size(30, 13);
            this.m_OtherInfo.TabIndex = 3;
            this.m_OtherInfo.Text = "[info]";
            // 
            // m_UserGroupBox
            // 
            this.m_UserGroupBox.Controls.Add(this.m_Userpic);
            this.m_UserGroupBox.Controls.Add(this.m_OtherInfo);
            this.m_UserGroupBox.Controls.Add(this.m_UsernameLabel);
            this.m_UserGroupBox.Controls.Add(this.m_FBLink);
            this.m_UserGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_UserGroupBox.Location = new System.Drawing.Point(0, 0);
            this.m_UserGroupBox.Name = "m_UserGroupBox";
            this.m_UserGroupBox.Size = new System.Drawing.Size(212, 254);
            this.m_UserGroupBox.TabIndex = 4;
            this.m_UserGroupBox.TabStop = false;
            this.m_UserGroupBox.Text = "User";
            // 
            // m_Userpic
            // 
            this.m_Userpic.Location = new System.Drawing.Point(6, 19);
            this.m_Userpic.Name = "m_Userpic";
            this.m_Userpic.Size = new System.Drawing.Size(192, 133);
            this.m_Userpic.TabIndex = 0;
            this.m_Userpic.TabStop = false;
            // 
            // UserViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_UserGroupBox);
            this.Name = "UserViewControl";
            this.Size = new System.Drawing.Size(212, 254);
            this.m_UserGroupBox.ResumeLayout(false);
            this.m_UserGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_Userpic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_Userpic;
        private System.Windows.Forms.Label m_UsernameLabel;
        private System.Windows.Forms.LinkLabel m_FBLink;
        private System.Windows.Forms.Label m_OtherInfo;
        private System.Windows.Forms.GroupBox m_UserGroupBox;
    }
}
