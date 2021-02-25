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
   public  class IletisimManager : IIletisimService
    {
        private IIletisimDal _iletisimDal = new EfIletisimDal();
        public bool Add(Iletisim entity)
        {
           return _iletisimDal.Add(entity);
           
        }
       
        public bool Delete(Iletisim entity)
        {
            return _iletisimDal.Delete(entity);
        }

        public Iletisim Get(int id)
        {
           return _iletisimDal.Get(id);
        }

        public List<Iletisim> GetList(Expression<Func<Iletisim, bool>> filter = null)
        {
            return _iletisimDal.GetList(filter);
        }

        public bool Update(Iletisim entity)
        {
            return _iletisimDal.Update(entity);
        }
        
        public int Rapor_Kisi_Kayit_Sayisi(string veri)
        {
                        
            return _iletisimDal.rapor(x=>x.Konum == veri, y=>y.KID);
        } 
        public int Rapor_Telefon_Kayit_Sayisi(string veri)
        {
                        
            return _iletisimDal.Rapor_Telefon_Kayit_Sayisi(veri);
        }
           public List<result> Konum_Liste()
        {
                        
            return _iletisimDal.Konum_Liste();
        }



    }
}
