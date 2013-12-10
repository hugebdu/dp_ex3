using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ex2.FacebookApp
{
    public partial class LinkViewForm : Form
    {
        public LinkViewForm()
        {
            InitializeComponent();
        }

        public string Url
        {
            get
            {
                return m_LinkViewer.Url;
            }

            set
            {
                m_LinkViewer.Url = value;
            }
        }
    }
}
