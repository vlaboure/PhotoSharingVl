using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoSharingVl.Models;

namespace PhotoSharingTests.Doubles
{
    class FakePhotoSharingContext : IPhotoSharingContext
    {

        /// <summary>
        /// simulation d'un DbContext pour les tests
        /// 
        /// </summary>
        //This object is a keyed collection we use to mock an 
        //entity framework context in memory
        SetMap _map = new SetMap();

        public IQueryable<Photo> Photos
        {
            get { return _map.Get<Photo>().AsQueryable(); }
            set { _map.Use<Photo>(value); }
        }

        public IQueryable<Comment> Comments
        {
            get { return _map.Get<Comment>().AsQueryable(); }
            set { _map.Use<Comment>(value); }
        }

        public bool ChangesSaved { get; set; }

        public int SaveChanges()
        {
            ChangesSaved = true;
            return 0;
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public Photo FindPhotoById(int ID)
        {
          //  Photo item= (from p in this.Photos
            //        where p.Id == ID
            //        select p).First();

            return Photos.First(p => p.Id == ID);
        }

        public Comment FindCommentById(int ID)
        {
            //Comment item = (from c in this.Comments
            //              where c.Id == ID
            //              select c).First();

            return Comments.First(p => p.Id == ID);

        }


        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }

        class SetMap : KeyedCollection<Type, object>
        {

            public HashSet<T> Use<T>(IEnumerable<T> sourceData)
            {
                var set = new HashSet<T>(sourceData);
                if (Contains(typeof(T)))
                {
                    Remove(typeof(T));
                }
                Add(set);
                return set;
            }

            public HashSet<T> Get<T>()
            {
                return (HashSet<T>) this[typeof(T)];
            }

            protected override Type GetKeyForItem(object item)
            {
                return item.GetType().GetGenericArguments().Single();
            }
        }
    }
}
