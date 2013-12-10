﻿namespace Ex2.FacebookApp.Model.Translator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;

    public class CachedTranslator : ITranslator
    {
        private readonly Dictionary<string, ITranslationResult> r_TranslationCache = new Dictionary<string, ITranslationResult>();
        private readonly object r_CacheUpdateContext = new object();
        private ITranslator m_InnerTranslator;

        public CachedTranslator(ITranslator i_BaseTranslator)
        {
            m_InnerTranslator = i_BaseTranslator;
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
                        lock (r_CacheUpdateContext)
                        {
                            if (!r_TranslationCache.ContainsKey(key))
                            {
                                r_TranslationCache.Add(key, result);
                            }
                        }
                    }

                    i_Callback(r_TranslationCache[key]);
                });
        }

        private string getKey(string i_Text)
        {
            var algorithm = getHashAlgorithm();
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(i_Text));
            var stringBuilder = new StringBuilder();
            foreach (var oneByte in hash)
            {
                stringBuilder.Append(oneByte.ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        private HashAlgorithm getHashAlgorithm()
        {
            return MD5.Create();
        }
    }
}