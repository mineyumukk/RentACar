using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            //Tek bir satırda yazabiliriz ama when kuralı eklediğimiz zaman patlarız.
            RuleFor(c => c.Description).NotEmpty().WithMessage("Araç açıklaması gerekli");
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            //RuleFor(c=>c.DailyPrice).GreaterThanOrEqualTo(500).When(c=>c.BrandId==1); ---- marka id'si 1 olan arabanın günlük fiyatı 500 olamlı
            RuleFor(c=>c.Description).Must(StartWithA).WithMessage("Araç açıklaması A harfi ile başlamalı"); //araba açıklamasının A ile başlamasının gerekliliğinden bahseden kural 
        }

        private bool StartWithA(string arg) //arg burada Description'u temsil eder.
        {
            return arg.StartsWith("A");
        }
    }
}
