using System.ComponentModel.DataAnnotations;

namespace PhotoSharingVl.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        public int PhotoID { get; set; }
        public string UserName { get; set; }
        [Required]
        [StringLength(250)]
        public string Subject { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        // clé étrangère
        public virtual Photo Photo { get; set; }
    }
}