using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(col=>col.ColorName).NotEmpty().WithMessage("Aracın rengi boş bırakılamaz");
            RuleFor(col=>col.ColorName).Length(2,50);

        }
    }
}
