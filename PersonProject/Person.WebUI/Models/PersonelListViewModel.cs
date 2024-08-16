using Person.Core.Utilities.Results.Abstract;
using Person.Entities.Concrete;

namespace Person.WebUI.Models
{
    public class PersonelListViewModel
    {
        public IDataResult<List<Personel>> Personels { get; set; }

    }
}
