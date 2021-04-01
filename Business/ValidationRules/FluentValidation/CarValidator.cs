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
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("Tutar boş olamaz");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Sıfırdan büyük olmalı");
        }
        
    }
}
