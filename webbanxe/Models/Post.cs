using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webbanxe.Models
{
    [Table ("Post")]
    public class Post
    {
        [Key]
        public long PostID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Contents { get; set; }

        [ValidateNever]
        public string? Images { get; set; }

        [ValidateNever]
        public string? Link { get; set; }

        [ValidateNever]
        public string? Author { get; set;}
       
        [ValidateNever]
        public DateTime CreatedDate { get; set; }

        [ValidateNever]
        public bool IsActive { get; set; }

        [ValidateNever]
        public int PostOrder {  get; set; }
        [ValidateNever]
        public int Category {  get; set; }
        [ValidateNever]
        public int Status { get; set; }

        [NotMapped]
        [ValidateNever]
        public IFormFile ImageFile { get; set; }

        [ValidateNever]
        public int MenuID { get; set; }

        [ValidateNever]
        
        public virtual Menu menu { get; set; }

    }
}
