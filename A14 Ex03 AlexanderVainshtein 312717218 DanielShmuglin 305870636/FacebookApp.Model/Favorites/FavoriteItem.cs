namespace Ex2.FacebookApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FacebookWrapper.ObjectModel;

    public class FavoriteItem : SimpleStorableItem
    {
        public FavoriteItem()
        {
        }

        public FavoriteItem(Post i_Post)
        {
            Id = i_Post.Id;
            Data = DateTime.Now.Ticks.ToString();
            AddingDateAsTicks = DateTime.Now.Ticks;
        }

        public long AddingDateAsTicks { get; set; }
    }
}
