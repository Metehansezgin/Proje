using Microsoft.EntityFrameworkCore;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.DataAccess.Concrete.EntityFramework
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=METEHANPC\SQLEXPRESS;Initial Catalog=RehberProjesi;Integrated Security=True");
        }
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }

    }
}
