using Microsoft.EntityFrameworkCore;
using Proje.Core.DataAccess.EntityFramework;
using Proje.DataAccess.Abstract;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Proje.DataAccess.Concrete.EntityFramework
{
   public class EfIletisimDal : EfEntityRepositoryBase<Iletisim, Context>,IIletisimDal
   {
       

        public int rapor(Expression<Func<Iletisim, bool>> where, Expression<Func<Iletisim,int>> select)
        {
            using (var context = new Context())
            {
                return context.Set<Iletisim>().Where(where).Select(select).Distinct().ToList().Count;
            }
        }

        public int Rapor_Telefon_Kayit_Sayisi(string veri)
        {
            using (var context = new Context())
            {                
                 return  context.Set<Iletisim>().Where(x=>x.Konum == veri).Select(x=>x.Telefon).Distinct().ToList().Count;                                            
            }
        }

        public List<result> Konum_Liste()
        {
            using (var context = new Context())
            {
                List<result> result = new List<result>();
                
                var list = context.Iletisim
                                  .GroupBy(p => p.Konum)
                                  .Select(g => new
                                  {
                                      Konum = g.Key,
                                      Count = g.Count()
                                  }).OrderByDescending(g=>g.Count)
                                  .ToList();
               
                foreach (var item in list)
                {
                    result.Add(new result
                    {
                        Konum=item.Konum,
                        sayi=item.Count,
                        kisi_sayi= rapor(x => x.Konum == item.Konum, y => y.KID),
                        telefon_sayi= Rapor_Telefon_Kayit_Sayisi(item.Konum)
                    });
                }

                return result;
            }
        }

    }
}
