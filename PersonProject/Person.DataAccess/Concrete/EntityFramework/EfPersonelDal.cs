using Person.Core.DataAccess.EntityFramework.Concrete;
using Person.DataAccess.Abstract;
using Person.DataAccess.Concrete.EntityFramework.Context;
using Person.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.DataAccess.Concrete.EntityFramework
{
    public class EfPersonelDal : EfEntityRepositoryBase<Personel,PersonelContext>,IPersonelDal
    {

    }
}
