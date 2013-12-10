using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace Ex2.FacebookApp.UserControls
{
    public partial class UserViewControl : UserControl
    {
        private User m_User;

        public User User
        {
            get
            {
                return m_User;
            }

            set
            {
                if (m_User != value)
                {
                    m_User = value;
                    updateView();
                }
            }
        }

        public UserViewControl()
        {
            InitializeComponent();
        }

        private void m_FBLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (User != null && !string.IsNullOrEmpty(User.Id))
            {
                Process.Start(string.Format("https://www.facebook.com/{0}", User.Id));
            }
            else
            {
                MessageBox.Show("User info is not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateView()
        {
            Utils.UpdateControlText(m_UsernameLabel, m_User != null ? m_User.Name : null);
            Utils.UpdateControlText(m_OtherInfo, m_User != null && m_User.Location != null ? m_User.Location.Name : null);
            Utils.UpdateImage(m_Userpic, m_User != null ? m_User.ImageLarge : null);
        }
    }
}
