using ETicaretWebApp.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretWebApp.Models.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderProduct> Orders { get; set; }
    }
}