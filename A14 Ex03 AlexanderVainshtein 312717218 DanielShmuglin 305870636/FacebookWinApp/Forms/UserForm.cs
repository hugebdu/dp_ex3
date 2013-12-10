using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace Ex2.FacebookApp
{
    public partial class UserForm : Form
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
                    m_UserViewControl.User = m_User;
                }
            }
        }

        public UserForm()
        {
            InitializeComponent();
        }
    }
}
