namespace Ex2.FacebookApp.Model.Translator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class TranslatorFactory
    {
        public static ITranslator Create(eTranslatorType i_Type, eTranslationLang i_TargetLanguageCode, IEnumerable<eTranslationLang> i_SkippedLanguageCodes = null)
        {
            switch (i_Type)
            {
                case eTranslatorType.Dummy:
                    return new DummyTranslator();
                case eTranslatorType.Bing:
                    return new CachedTranslator(new BingTranslator(i_TargetLanguageCode.ToString(), i_SkippedLanguageCodes == null ? null : i_SkippedLanguageCodes.Cast<string>()));
                case eTranslatorType.Base64:
                    return new CachedTranslator(new Base64Translator());
                default:
                    throw new ArgumentException("Unsupported translator type");
            }
        }
    }

    public enum eTranslatorType
    { 
        Dummy,
        Bing,
        Base64
    }

    public enum eTranslationLang
    { 
        ru,
        en,
        he
    }
}
