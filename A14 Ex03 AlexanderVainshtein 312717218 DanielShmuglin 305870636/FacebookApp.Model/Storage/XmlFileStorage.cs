namespace Ex2.FacebookApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    public class XmlFileStorage : IDataStorage
    {
        private Dictionary<string, SimpleStorableItem> m_Items;

        public string FileName { get; private set; }

        public XmlFileStorage(string i_FileName)
        {
            if (string.IsNullOrEmpty(i_FileName))
            {
                throw new ArgumentException("Invalid (empty) file name");
            }

            FileName = i_FileName;
            load();
        }

        public void PutItem(IStorableItem i_Item)
        {
            if (i_Item is SimpleStorableItem)
            {
                PutItem(i_Item as SimpleStorableItem);
            }
            else
            {
                throw new ArgumentException("Only simple storable item can be saved to this storage");
            }
        }

        public void PutItem(SimpleStorableItem i_Item)
        {
            if (m_Items.ContainsKey(i_Item.Id))
            {
                m_Items[i_Item.Id] = i_Item;
            }
            else
            {
                m_Items.Add(i_Item.Id, i_Item);
            }

            saveAsync();
        }

        public IStorableItem GetItem(string i_Id)
        {
            return m_Items.ContainsKey(i_Id) ? m_Items[i_Id] : null;
        }

        public IEnumerable<IStorableItem> GetItems()
        {
            return m_Items.Values;
        }

        public bool DeleteItem(string i_Id)
        {
            var deleted = false;

            if (m_Items.ContainsKey(i_Id))
            {
                m_Items.Remove(i_Id);
                deleted = true;
                saveAsync();
            }

            return deleted;
        }

        private void saveAsync()
        {
            new Task(save).Start();
        }

        private void load()
        {
            m_Items = new Dictionary<string, SimpleStorableItem>();

            if (File.Exists(FileName))
            {
                using (var reader = new StreamReader(FileName))
                {
                    try
                    {
                        var serializer = new XmlSerializer(typeof(List<SimpleStorableItem>));
                        var values = serializer.Deserialize(reader) as List<SimpleStorableItem>;

                        foreach (var value in values)
                        {
                            m_Items.Add(value.Id, value);
                        }
                    }
                    catch (XmlException)
                    { 
                        // Log exception
                    }
                }
            }
        }

        private void save()
        {
            if (!File.Exists(FileName))
            {
                var folder = Path.GetDirectoryName(FileName);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }

            using (var writer = new StreamWriter(FileName))
            {
                var serializer = new XmlSerializer(typeof(List<SimpleStorableItem>));
                serializer.Serialize(writer, m_Items.Select(pair => pair.Value).ToList());
            }
        }
    }
}
