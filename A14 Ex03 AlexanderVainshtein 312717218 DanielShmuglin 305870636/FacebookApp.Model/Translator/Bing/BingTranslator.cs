namespace Ex2.FacebookApp.Model.Translator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using Ex2.FacebookApp.Model.MicrosoftTranslator;
    using Ex2.FacebookApp.Model.Properties;
    
    public class BingTranslator : ITranslator, IDisposable
    {
        private readonly AdmAuthentication r_Authentication;
        private string m_TargetLanguageCode;

        public LanguageServiceClient LanguageService { get; private set; }

        public BingTranslator(string i_TargetLanguageCode)
        {
            m_TargetLanguageCode = i_TargetLanguageCode;
            r_Authentication = new AdmAuthentication(Settings.Default.BingTranslateClientID, Settings.Default.BingTranslateSecretKey);
            LanguageService = new LanguageServiceClient();
        }

        public void AsyncTranslate(string i_Text, OnCompleted i_Callback)
        {
            ThreadPool.QueueUserWorkItem(doTranslate, new Tuple<string, OnCompleted>(i_Text, i_Callback));
        }

        private void doTranslate(object i_State)
        {
            string text = (i_State as Tuple<string, OnCompleted>).Item1;
            OnCompleted callback = (i_State as Tuple<string, OnCompleted>).Item2;

            var languageCode = detectLanguage(text);
            ITranslationResult result;
            if (languageCode != m_TargetLanguageCode)
            {
                var translated = invokeWithAuthentication(() => LanguageService.Translate(string.Empty, text, languageCode, m_TargetLanguageCode));
                result = new TranslationResult(text, languageCode, true, translated);
            }
            else
            {
                result = new TranslationResult(text, languageCode);
            }

            callback(result);
        }

        class TranslationResult : ITranslationResult
        {
            private string m_OriginText;
            private bool m_IsTranslated;
            private string m_TranslatedText;
            private string m_SourceLanguageCode;

            public TranslationResult(string i_OriginText, string i_SourceLanguageCode, bool i_IsTranslated = false, string i_TranslatedText = null)
            {
                m_OriginText = i_OriginText;
                m_IsTranslated = i_IsTranslated;
                m_TranslatedText = i_TranslatedText;
                m_SourceLanguageCode = i_SourceLanguageCode;
            }

            public string OriginText
            {
                get 
                {
                    return m_OriginText;
                }
            }

            public bool IsTranslated
            {
                get 
                {
                    return m_IsTranslated;
                }
            }

            public string TranslatedText
            {
                get 
                {
                    return m_TranslatedText;
                }
            }

            public string TranslatedOrOriginText
            {
                get 
                {
                    return IsTranslated ? TranslatedText : OriginText;
                }
            }

            public string SourceLanguageCode
            {
                get 
                {
                    return m_SourceLanguageCode;
                }
            }
        }

        private string detectLanguage(string i_Text)
        {
            return invokeWithAuthentication(() => LanguageService.Detect(string.Empty, i_Text));
        }

        private T invokeWithAuthentication<T>(Func<T> i_Action)
        {
            using (var scope = new OperationContextScope(LanguageService.InnerChannel))
            {
                var property = new HttpRequestMessageProperty();
                property.Method = "POST";
                property.Headers.Add("Authorization", "Bearer " + r_Authentication.GetAccessToken().access_token);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = property;
                return i_Action();
            }
        }

        public void Dispose()
        {
            (LanguageService as IDisposable).Dispose();
        }
    }
}
