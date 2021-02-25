using Proje.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proje.API.Models
{
  public  class Kisiler
    {
        [Key]
        public int UUID { get; set; }
        public String Ad { get; set; }
        public String Soyad { get; set; }
        public String Firma { get; set; }
        public List<Iletisim> lletisim { get; set; }

    }
}
