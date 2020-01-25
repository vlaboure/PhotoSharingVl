using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PhotoSharingVl.Models
{    
    public class PhotoSharingContext:DbContext, IPhotoSharingContext
    {
        ////DbContext pour communiquer avec Entity
        ///******************************************VERSION DE BASE SANS INTERFACE
        //public PhotoSharingContext() : base()
        //{
        //    this.Database.CommandTimeout = 180;
        //}

        //public DbSet<Photo> Photos { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        ///********************************************************************************\\\\

        public PhotoSharingContext() : base()
        {
            this.Database.CommandTimeout = 180;
        }

        //dbset pour requettes
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public T Add<T>(T entity) where T : class
        {
            return Set<T>().Add(entity);
        }

        public T Delete<T>(T entity) where T : class
        {
            return Set<T>().Remove(entity);
        }

        public Comment FindCommentById(int ID)
        {
            return Set<Comment>().Find(ID);
        }

        public Photo FindPhotoById(int ID)
        {
            return Set<Photo>().Find(ID);
        }

        IQueryable<Photo> IPhotoSharingContext.Photos
        {
            get { return Photos; }
        }

        IQueryable<Comment> IPhotoSharingContext.Comments
        {
            get { return Comments; }
        }

        //T IPhotoSharingContext.Add<T>(T entity)
        //{
        //    //return Set---> Set est une méthode de DbContext
        //    return Set<T>().Add(entity);

        //}

        //T IPhotoSharingContext.Delete<T>(T entity)
        //{
        //    return Set<T>().Remove(entity);
        //}

        //Comment IPhotoSharingContext.FindCommentById(int ID)
        //{
        //    return Set<Comment>().Find(ID);
        //}

        //Photo IPhotoSharingContext.FindPhotoById(int ID)
        //{
        //    return Set<Photo>().Find(ID);
        //}

        //int IPhotoSharingContext.SaveChanges()
        //{
        //    return SaveChanges();
        //}
    }
}