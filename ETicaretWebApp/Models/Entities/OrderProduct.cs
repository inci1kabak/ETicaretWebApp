using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretWebApp.Models.Entities
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}