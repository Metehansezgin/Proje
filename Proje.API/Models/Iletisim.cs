using Proje.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;

namespace Proje.API.Models
{
    public class Iletisim
    {
        [Key]
        public String IID { get; set; }
        public String Telefon { get; set; }
        public String Email { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }

  
}
