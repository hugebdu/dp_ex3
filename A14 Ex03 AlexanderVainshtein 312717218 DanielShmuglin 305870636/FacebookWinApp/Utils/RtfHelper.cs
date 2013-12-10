namespace Ex2.FacebookApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RtfHelper
    {
        private const string k_DeafultFont = "Times New Roman";

        private const uint k_DeafultSize = 23;

        public string Font { get; set; }

        public uint Size { get; set; }

        public bool UTF { get; set; }

        private StringBuilder m_RtfText;

        public string RtfText
        {
            get
            {
                return string.Concat(getRtfHeader(), m_RtfText.ToString(), getRtfFooter());
            }
        }

        public RtfHelper()
        {
            UTF = true;
            Font = k_DeafultFont;
            Size = k_DeafultSize;
            Reset();
        }

        public void Reset()
        {
            m_RtfText = new StringBuilder();
        }

        public void Append(string i_Text)
        {
            if (string.IsNullOrEmpty(i_Text))
            {
                return;
            }

            m_RtfText.Append(UTF ? getRtfUnicodeEscapedString(i_Text) : i_Text);
        }

        public void AppendLine(string i_Text)
        {
            if (string.IsNullOrEmpty(i_Text))
            {
                return;
            }

            Append(i_Text);
            AppendNewLine();
        }

        public void AppendBoldText(string i_Text)
        {
            m_RtfText.Append(@"\b ");
            Append(i_Text);
            m_RtfText.Append(@"\b0 ");
        }

        public void AppendNewLine()
        {
            m_RtfText.Append(@"\par ");
        }

        private string getRtfUnicodeEscapedString(string i_String)
        {
            var sb = new StringBuilder();
            foreach (var oneChar in i_String)
            {
                if (oneChar <= 0x7f)
                {
                    sb.Append(oneChar);
                }
                else
                {
                    sb.Append(@"\u" + Convert.ToUInt32(oneChar) + "?");
                }
            }

            return sb.ToString();
        }

        private string getRtfHeader()
        {
            var font = string.IsNullOrEmpty(Font) ? k_DeafultFont : Font;
            var size = (Size <= 0) ? k_DeafultSize : Size;

            var header = new StringBuilder();
            header.Append(@"{\rtf{\fonttbl {\f0 ");
            header.Append(font);
            header.Append(@";}}\f0\fs");
            header.Append(size);
            header.Append(@" ");

            return header.ToString();
        }

        private string getRtfFooter()
        {
            return @" }";
        }
    }
}