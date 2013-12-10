namespace Ex2.FacebookApp.Model.Translator
{
    public interface ITranslatorHost
    {
        ITranslator ActiveTranslator { get; }
    }
}
