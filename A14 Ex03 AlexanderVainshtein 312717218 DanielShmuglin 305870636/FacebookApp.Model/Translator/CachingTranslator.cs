namespace Ex2.FacebookApp.Model.Translator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;

    public class CachingTranslator : ITranslator
    {
        private readonly ConcurrentDictionary<string, ITranslationResult> r_TranslationCache = new ConcurrentDictionary<string, ITranslationResult>();
        private HashAlgorithm r_Algorithm;
        private ITranslator m_InnerTranslator;

        public CachingTranslator(ITranslator i_BaseTranslator)
        {
            m_InnerTranslator = i_BaseTranslator;
            r_Algorithm = createHashAlgorithm();
        }

        public void AsyncTranslate(string i_Text, OnCompleted i_Callback)
        {
            var key = getKey(i_Text);
            if (r_TranslationCache.ContainsKey(key))
            {
                i_Callback(r_TranslationCache[key]);
            }

            m_InnerTranslator.AsyncTranslate(
                i_Text,
                (result) =>
                {
                    if (!r_TranslationCache.ContainsKey(key))
                    {
                        r_TranslationCache.TryAdd(key, result);
                    }

                    i_Callback(r_TranslationCache[key]);
                });
        }

        private string getKey(string i_Text)
        {
            var hash = r_Algorithm.ComputeHash(Encoding.UTF8.GetBytes(i_Text));
            var stringBuilder = new StringBuilder();
            foreach (var oneByte in hash)
            {
                stringBuilder.Append(oneByte.ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        private HashAlgorithm createHashAlgorithm()
        {
            return MD5.Create();
        }
    }
}
