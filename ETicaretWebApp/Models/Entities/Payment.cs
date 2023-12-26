using ETicaretWebApp.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretWebApp.Models.Entities
{
    public class Payment:BaseEntity
    {
        [Required]
        public string PaymentName { get; set; }
    }
}