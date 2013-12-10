namespace Ex2.FacebookApp.Model.Translator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public delegate void OnCompleted(ITranslationResult i_Result);

    public interface ITranslator
    {
        void AsyncTranslate(string i_Text, OnCompleted i_Callback);
    }
}
