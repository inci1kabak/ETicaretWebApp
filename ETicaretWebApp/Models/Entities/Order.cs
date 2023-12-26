using ETicaretWebApp.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretWebApp.Models.Entities
{
    public class Order:BaseEntity
    {
        [Required]
        public string OrderedById { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        [Required]
        [MaxLength(11)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public virtual ICollection<OrderProduct> Products { get; set; }
        public virtual ApplicationUser OrderedBy { get; set; }

    }
}