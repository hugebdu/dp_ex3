namespace Ex2.FacebookApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IStorableItem
    {
        string Data { get; set; }

        string Id { get; set; }
    }
}
