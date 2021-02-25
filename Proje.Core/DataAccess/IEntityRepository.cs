using Proje.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Core.DataAccess
{
   public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        T Get(int id);
        List<T> GetList(Expression<Func<T, bool>> filter=null);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
