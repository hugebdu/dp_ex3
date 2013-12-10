namespace Ex2.FacebookApp
{
    partial class UserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.m_UserViewControl = new Ex2.FacebookApp.UserControls.UserViewControl();
            this.SuspendLayout();
            // 
            // m_UserViewControl
            // 
            this.m_UserViewControl.Location = new System.Drawing.Point(6, 2);
            this.m_UserViewControl.Name = "m_UserViewControl";
            this.m_UserViewControl.Size = new System.Drawing.Size(212, 254);
            this.m_UserViewControl.TabIndex = 0;
            this.m_UserViewControl.User = null;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 257);
            this.Controls.Add(this.m_UserViewControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.Text = "User Information";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UserViewControl m_UserViewControl;
    }
}