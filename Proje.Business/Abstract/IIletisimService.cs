using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Business.Abstract
{
    interface IIletisimService
    {
        Iletisim Get(int id);
        List<Iletisim> GetList(Expression<Func<Iletisim, bool>> filter = null);
        bool Add(Iletisim entity);
        bool Update(Iletisim entity);
        bool Delete(Iletisim entity);
    }
}
