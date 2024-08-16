using Person.Core.DataAccess.EntityFramework.Abstract;
using Person.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.DataAccess.Abstract
{
    public interface IPersonelDal : IEntityRepository<Personel>
    {

    }
}
