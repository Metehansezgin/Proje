using Proje.Business.Abstract;
using Proje.DataAccess.Abstract;
using Proje.DataAccess.Concrete.EntityFramework;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Proje.Business.Concrete
{
   public class KisilerManager:IKisilerService
    {
        private IKisilerDal _kisilerDal=new EfKisilerDal();

        public KisilerManager()
        {
            //IKisilerDal kisilerDal
            //_kisilerDal = kisilerDal;
        }
        public bool Add(Kisiler entity)
        {
          return  _kisilerDal.Add(entity);
        }

        public bool Delete(Kisiler entity)
        {
            return _kisilerDal.Delete(entity);
        }

        public List<Kisiler> GetList(Expression<Func<Kisiler, bool>> filter = null)
        {
            return _kisilerDal.GetList(filter);
        }
          

        public Kisiler Get(int id)
        {
            return _kisilerDal.Get(id);
        }

        public bool Update(Kisiler entity)
        {
            return _kisilerDal.Update(entity);
        }
    }
}
