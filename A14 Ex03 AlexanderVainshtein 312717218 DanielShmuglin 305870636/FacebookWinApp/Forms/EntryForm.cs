using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;

namespace Ex2.FacebookApp
{
    public partial class EntryForm : Form
    {
        public EntryForm()
        {
            InitializeComponent();
        }

        private static LoginResult login()
        {
            return FacebookService.Login(
                AppInfo.AppID,
                AppInfo.FriendsAboutMe,
                AppInfo.PublishStream,
                AppInfo.ReadStrem,
                AppInfo.UserAboutMe,
                AppInfo.UserEvents,
                AppInfo.UserStatus);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Visible = false;
                var loginResult = login();
                if (loginResult.LoggedInUser != null)
                {
                    var mainForm = new MainForm(loginResult);
                    mainForm.ShowDialog();
                    this.Close();
                }
                else if (!string.IsNullOrEmpty(loginResult.ErrorMessage))
                {
                    MessageBox.Show(loginResult.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooooops! Error occured! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    this.Visible = true;
                }
            }
        }
    }
}