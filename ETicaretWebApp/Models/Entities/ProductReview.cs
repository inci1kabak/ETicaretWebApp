using ETicaretWebApp.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretWebApp.Models.Entities
{
    public class ProductReview:BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public string Description { get; set; }
        [Required]
        public int Point { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Product Product { get; set; }
    }
}