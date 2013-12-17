namespace Ex2.FacebookApp.Model.Translator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class TranslatorFactory
    {
        public static ITranslator Create(eTranslatorType i_Type, eTranslationLang i_TargetLanguageCode)
        {
            switch (i_Type)
            {
                case eTranslatorType.Dummy:
                    return new DummyTranslator();
                case eTranslatorType.Bing:
                    return new CachingTranslator(new BingTranslator(i_TargetLanguageCode.ToString()));
                case eTranslatorType.Base64:
                    return new Base64Translator();
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
