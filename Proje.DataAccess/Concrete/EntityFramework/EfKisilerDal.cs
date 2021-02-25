using Proje.Core.DataAccess.EntityFramework;
using Proje.DataAccess.Abstract;
using Proje.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.DataAccess.Concrete.EntityFramework
{
   public class EfKisilerDal:EfEntityRepositoryBase<Kisiler,Context>,IKisilerDal
   {
   }
}
