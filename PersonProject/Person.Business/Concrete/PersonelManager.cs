using Person.Business.Abstract;
using Person.Core.Utilities.Business;
using Person.Core.Utilities.Results.Abstract;
using Person.Core.Utilities.Results.Concrete;
using Person.DataAccess.Abstract;
using Person.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }
        
        public IResult Add(Personel personel)
        {
            IResult result = BusinessRules.Run(CheckIfPersonelNameExists(personel.Name));
            if (result != null)
            {
                return result;
            }

            _personelDal.Add(personel);
            return new SuccessResult("Personel Eklendi.");
        }

        public IResult Delete(Personel personel)
        {
            _personelDal.Delete(personel);
            return new SuccessResult("Personel Silindi.");
        }

        public IDataResult<List<Personel>> GetAll()
        {
            return new SuccessDataResult<List<Personel>>(_personelDal.GetAll(), "Personeller Listelendi.");
        }

        public IDataResult<Personel> GetById(int personelId)
        {
            return new SuccessDataResult<Personel>(_personelDal.Get(p => p.Id == personelId));
        }

        public IResult Update(Personel personel)
        {
            _personelDal.Update(personel);
            return new SuccessResult("Personel Güncellendi.");
        }

        // Örnek olsun diye aynı isimde personel kaydetmemek için kullanıldı.
        private IResult CheckIfPersonelNameExists(string personelName)
        {
            var result = _personelDal.GetAll(p => p.Name == personelName).Any();
            if (result)
            {
                return new ErrorResult("Bu isimde zaten başka bir personel mevcuttur.");
            }
            return new SuccessResult();
        }
    }
}
