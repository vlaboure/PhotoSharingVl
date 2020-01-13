using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingVl.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string ImageMimeType { get; set; }
        [DisplayName("Picture")]
        public byte[] PhotoFile { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCreation { get; set; }
        public String UserName { get; set; }

        //Clé étrangère
        public virtual ICollection<Comment> Comments{get;set;}
     
    }
}