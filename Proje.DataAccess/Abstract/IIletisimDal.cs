using Proje.Core.DataAccess;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.DataAccess.Abstract
{
  public  interface IIletisimDal:IEntityRepository<Iletisim>
    {
        public int Rapor_Telefon_Kayit_Sayisi(string veri);

        public int rapor(Expression<Func<Iletisim, bool>> where, Expression<Func<Iletisim, int>> select);

        public List<result> Konum_Liste();
    }
}
