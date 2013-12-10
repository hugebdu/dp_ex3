namespace Ex2.FacebookApp
{
    partial class LinkViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkViewForm));
            this.m_LinkViewer = new Ex2.FacebookApp.UserControls.LinkViewer();
            this.SuspendLayout();
            // 
            // m_LinkViewer
            // 
            this.m_LinkViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_LinkViewer.Location = new System.Drawing.Point(0, 0);
            this.m_LinkViewer.Name = "m_LinkViewer";
            this.m_LinkViewer.Size = new System.Drawing.Size(976, 625);
            this.m_LinkViewer.TabIndex = 0;
            this.m_LinkViewer.Url = "about:blank";
            // 
            // LinkViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 625);
            this.Controls.Add(this.m_LinkViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LinkViewForm";
            this.Text = "Link view";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.LinkViewer m_LinkViewer;
    }
}