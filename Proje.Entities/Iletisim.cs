using Proje.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;

namespace Proje.Entities
{
    public class Iletisim:IEntity
    {
        [Key]
        public int IID { get; set; }
        public int KID { get; set; }
        public String Telefon { get; set; }
        public String Email { get; set; }
        public String Konum { get; set; }
       

    }

  
}
