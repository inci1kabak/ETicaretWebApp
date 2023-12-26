using ETicaretWebApp.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretWebApp.Models.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}