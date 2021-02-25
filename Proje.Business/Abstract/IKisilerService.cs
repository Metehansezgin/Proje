using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Business.Abstract
{
    interface IKisilerService
    {
        Kisiler Get(int id);
        List<Kisiler> GetList(Expression<Func<Kisiler, bool>> filter = null);
        bool Add(Kisiler entity);
        bool Update(Kisiler entity);
        bool Delete(Kisiler entity);
    }
}
