namespace Ex2.FacebookApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IDataStorage
    {
        void PutItem(IStorableItem i_Item);

        IStorableItem GetItem(string i_Id);

        IEnumerable<IStorableItem> GetItems();

        bool DeleteItem(string i_Id);
    }
}
