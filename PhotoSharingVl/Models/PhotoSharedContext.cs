using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PhotoSharingVl.Models
{
    //DbContext pour communiquer par Entity
    public class PhotoSharedContext:DbContext
    {
        public PhotoSharedContext() : base()
        {
            this.Database.CommandTimeout = 180;
        }

        //dbset pour requettes
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}