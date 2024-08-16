using FluentValidation;
using Person.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Business.Validator.FluentValidation
{
    public class PersonelValidator : AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Personel Adı Boş Geçilemez.");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Personel Adı En Az 2 Karakterden Oluşmalıdır.");
            RuleFor(p => p.SurName).NotEmpty().WithMessage("Personel Soyadı Boş Geçilemez.");
            RuleFor(p => p.SurName).MinimumLength(2).WithMessage("Personel Soyadı En Az 2 Karakterden Oluşmalıdır.");

        }
    }
}
