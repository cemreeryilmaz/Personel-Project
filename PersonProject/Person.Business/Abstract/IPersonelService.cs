using Person.Core.Utilities.Results.Abstract;
using Person.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Business.Abstract
{
    public interface IPersonelService
    {
        IDataResult<List<Personel>> GetAll();
        IDataResult<Personel> GetById(int personelId);
        IResult Add(Personel personel);
        IResult Update(Personel personel);
        IResult Delete(Personel personel);
    }
}
