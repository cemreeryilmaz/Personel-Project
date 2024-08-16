using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Person.Business.Abstract;
using Person.Entities.Concrete;
using Person.WebUI.Models;

namespace Person.WebUI.Controllers
{
    public class PersonelController : Controller
    {
        IValidator<Personel> _personelValidator;
        IPersonelService _personelService;

        public PersonelController(IPersonelService personelService, IValidator<Personel> validator)
        {
            _personelService = personelService;
            _personelValidator = validator;
        }

        public IActionResult Index()
        {
            var model = new PersonelListViewModel()
            {
                Personels = _personelService.GetAll()
            };

            return View(model);
        }


        public IActionResult Add()
        {
            var model = new PersonelViewModel()
            {
                Personel = new Personel()
            };

            return View(model);
        }

       
        [HttpPost]
        public async Task<IActionResult> Add(PersonelViewModel model)
        {
            var entity = new Personel()
            {
                Name = model.Personel.Name,
                SurName = model.Personel.SurName,
                Gender = model.Personel.Gender,
                Debit = model.Personel.Debit,
                Graduation = model.Personel.Graduation,
                StartDate = model.Personel.StartDate,
                EndDate = model.Personel.EndDate
            };

            var validateResult = _personelValidator.Validate(entity);

            if (validateResult.IsValid)
            {
                _personelService.Add(entity);

                return RedirectToAction("Index");
            }

            foreach (var item in validateResult.Errors)
            {
                TempData["mesaj"] = item.ErrorMessage;
            }

            return View();

        }

        public ActionResult Update(int personelId)
        {
            var model = new PersonelViewModel()
            {
                Personel = _personelService.GetById(personelId).Data
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Personel personel)
        {
            var entity = _personelService.GetById(personel.Id);

            entity.Data.Name = personel.Name;
            entity.Data.SurName = personel.SurName;
            entity.Data.Debit = personel.Debit;
            entity.Data.Gender = personel.Gender;
            entity.Data.Graduation = personel.Graduation;

            _personelService.Update(personel);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int personelId)
        {
            var entity = _personelService.GetById(personelId);

            if (entity != null)
                _personelService.Delete(entity.Data);
            
            return RedirectToAction("Index");
        }

    }
}