namespace Ex2.FacebookApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Serialization;
    
    [XmlInclude(typeof(FavoriteItem))]
    public class SimpleStorableItem : IStorableItem
    {
        public string Data { get; set; }

        public string Id { get; set; }
    }
}
