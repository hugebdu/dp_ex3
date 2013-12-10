namespace Ex2.FacebookApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class DataStorageFactory
    {
        public static IDataStorage CreateDataStorage(eStorageType i_Type, params object[] i_CreationParams)
        {
            switch (i_Type)
            {
                case eStorageType.XmlFile:
                    if (i_CreationParams.Length < 1)
                    {
                        throw new ArgumentException("XmlFile storage requires file name as a parameter");
                    }

                    return new XmlFileStorage(i_CreationParams[0] as string);
                default:
                    throw new ArgumentException("Unsupported storage type");
            }
        }
    }

    public enum eStorageType
    { 
        XmlFile
    }
}
