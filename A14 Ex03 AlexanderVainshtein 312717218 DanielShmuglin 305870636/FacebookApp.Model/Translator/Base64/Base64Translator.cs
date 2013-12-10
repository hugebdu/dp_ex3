namespace Ex2.FacebookApp.Model.Translator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class Base64Translator : ITranslator
    {
        public void AsyncTranslate(string i_Text, OnCompleted i_Callback)
        {
            ThreadPool.QueueUserWorkItem(doTranslate, new Tuple<string, OnCompleted>(i_Text, i_Callback));
        }

        private void doTranslate(object i_State)
        {
            string text = (i_State as Tuple<string, OnCompleted>).Item1;
            OnCompleted callback = (i_State as Tuple<string, OnCompleted>).Item2;
            callback(new DummyTranslationResult(text));
        }

        private class DummyTranslationResult : ITranslationResult
        {
            private string m_Text;

            public DummyTranslationResult(string i_Text)
            {
                this.m_Text = i_Text;
            }

            public string OriginText
            {
                get
                {
                    return m_Text;
                }
            }

            public bool IsTranslated
            {
                get
                {
                    return true;
                }
            }

            public string TranslatedText
            {
                get
                {
                    return toBase64String(m_Text);
                }
            }

            public string TranslatedOrOriginText
            {
                get
                {
                    return TranslatedText;
                }
            }

            public string SourceLanguageCode
            {
                get
                {
                    return "he";
                }
            }

            private string toBase64String(string i_Text)
            {
                return Convert.ToBase64String(Encoding.Unicode.GetBytes(i_Text));
            }
        }
    }
}