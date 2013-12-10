namespace Ex2.FacebookApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using FacebookWrapper.ObjectModel;

    public class FavoritesManager
    {
        private const string k_AppFolderName = "CoolFbApp_" + AppInfo.AppID;

        public delegate void FavoriteChangeEventHandler(object i_Sender, Post i_Post);

        public event FavoriteChangeEventHandler FavoriteAdded;

        public event FavoriteChangeEventHandler FavoriteRemoved;

        private IDataStorage m_Storage;
        private readonly Dictionary<string, Tuple<FavoriteItem, Post>> r_FavoritePosts = new Dictionary<string, Tuple<FavoriteItem, Post>>();
        private bool m_FavoritesLoaded = false;
        private readonly object r_FavoritesLoadingContext = new object();

        public FavoritesManager(string i_UserId)
        {
            initializeStorage(i_UserId);
        }

        private void initializeStorage(string i_UserId)
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create), k_AppFolderName);
            string storageFilename = string.Format("favorites_{0}.xml", i_UserId);
            m_Storage = DataStorageFactory.CreateDataStorage(eStorageType.XmlFile, Path.Combine(folder, storageFilename));
        }

        public void MarkFavorite(Post i_Post)
        {
            ensureFavoritesLoaded(); 
            if (r_FavoritePosts.ContainsKey(i_Post.Id))
            {
                r_FavoritePosts.Remove(i_Post.Id);
            }

            r_FavoritePosts.Add(i_Post.Id, new Tuple<FavoriteItem, Post>(new FavoriteItem(i_Post), i_Post));
            m_Storage.PutItem(r_FavoritePosts[i_Post.Id].Item1);
            OnFavoriteAdded(i_Post);
        }

        public void UnmarkFavorite(Post i_Post)
        {
            ensureFavoritesLoaded();
            if (r_FavoritePosts.ContainsKey(i_Post.Id))
            {
                r_FavoritePosts.Remove(i_Post.Id);
            }

            m_Storage.DeleteItem(i_Post.Id);
            OnFavoriteRemoved(i_Post);
        }

        public void GetFavoritePostsAsync(Action<IEnumerable<Post>> i_Callback)
        {
            new Task(() =>
            {
                var posts = GetFavoritePosts();
                if (i_Callback != null)
                {
                    i_Callback(posts);
                }
            }).Start();
        }

        public IEnumerable<Post> GetFavoritePosts()
        {
            ensureFavoritesLoaded();
            var postsInfo = r_FavoritePosts.Values.ToList();
            postsInfo.Sort(postsComparisonByCreateTimeDesc);
            return postsInfo.Select(pair => pair.Item2);
        }

        private int postsComparisonByCreateTimeDesc(Tuple<FavoriteItem, Post> i_Tuple1, Tuple<FavoriteItem, Post> i_Tuple2)
        {
            var creationTime1 = i_Tuple1.Item2.CreatedTime.HasValue ? i_Tuple1.Item2.CreatedTime.Value.Ticks : 0;
            var creationTime2 = i_Tuple2.Item2.CreatedTime.HasValue ? i_Tuple2.Item2.CreatedTime.Value.Ticks : 0;

            return creationTime2.CompareTo(creationTime1);
        }

        private void OnFavoriteAdded(Post i_Post)
        {
            if (FavoriteAdded != null)
            {
                FavoriteAdded(this, i_Post);
            }
        }

        private void OnFavoriteRemoved(Post i_Post)
        {
            if (FavoriteRemoved != null)
            {
                FavoriteRemoved(this, i_Post);
            }
        }

        private void ensureFavoritesLoaded()
        {
            if (!m_FavoritesLoaded)
            {
                loadFavorites();
            }
        }

        private void loadFavorites()
        {
            lock (r_FavoritesLoadingContext)
            {
                if (m_FavoritesLoaded)
                {
                    return;
                }

                r_FavoritePosts.Clear();

                foreach (FavoriteItem favoriteItem in m_Storage.GetItems())
                {
                    if (!r_FavoritePosts.ContainsKey(favoriteItem.Id))
                    {
                        Post post = null;
                        try
                        {
                            post = FacebookWrapper.FacebookService.GetObject<Post>(favoriteItem.Id);
                        }
                        catch (Facebook.FacebookApiException)
                        {
                            // Log error
                            // Post could be deleted. 
                            // TODO: Implement remove such posts from favorites after some number of loading attempts
                        }

                        if (post != null)
                        {
                            r_FavoritePosts.Add(favoriteItem.Id, new Tuple<FavoriteItem, Post>(favoriteItem, post));
                        }
                    }
                }

                m_FavoritesLoaded = true;
            }
        }
    }
}