// -----------------------------------------------------------------------
// <copyright file="Utils.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex2.FacebookApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Drawing;

    public static class Utils
    {
        public static void UpdateControlText(Control i_Control, string i_Text)
        {
            if (i_Control.InvokeRequired)
            {
                i_Control.Invoke(new Action<Control, string>(UpdateControlText), i_Control, i_Text);
            }
            else
            {
                i_Control.Text = i_Text;
            }
        }

        public static void UpdateRtfText(RichTextBox i_RichTextBox, string i_Text)
        {
            if (i_RichTextBox.InvokeRequired)
            {
                i_RichTextBox.Invoke(new Action<RichTextBox, string>(UpdateRtfText), i_RichTextBox, i_Text);
            }
            else
            {
                i_RichTextBox.Rtf = i_Text;
            }
        }

        public static void UpdateImage(PictureBox i_PictoreBox, Image i_Image)
        {
            if (i_PictoreBox.InvokeRequired)
            {
                i_PictoreBox.Invoke(new Action<PictureBox, Image>(UpdateImage), i_PictoreBox, i_Image);
            }
            else
            {
                i_PictoreBox.Image = i_Image;
            }
        }
    }
}
