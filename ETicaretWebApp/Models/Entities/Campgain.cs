using ETicaretWebApp.Models.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretWebApp.Models.Entities
{
        public class Campgain:BaseEntity
        {
            [MaxLength(50)]
            public string CampgainName { get; set; }
            [Required]
            public DateTime StartDate { get; set; }
            [Required]
            public DateTime EndDate { get; set; }
        }
}