using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(1000).When(c => c.BrandId == 8);//BrandId'si 8 olanların fiyatı 1000 den büyük olsun.

            //Olmayan bişey için;
            //RuleFor(c => c.CarName).Must(StartWithA).WithMessage("Araçlar A harfi ile başlamalıdır");
        }

        //private bool StartWithA(string arg)//arg=CarName
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
