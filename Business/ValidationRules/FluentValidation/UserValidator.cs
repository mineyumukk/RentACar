using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty().WithMessage("İsim gerekli");
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Soyadı gerekli");
            RuleFor(customer => customer.Email).EmailAddress();
            RuleFor(customer => customer.LastName).Length(2, 50);
            RuleFor(customer => customer.FirstName).Length(2, 50);
            RuleFor(customer => customer.FirstName).NotEqual(customer => customer.LastName);
            //RuleFor(customer => customer.Password).NotNull();
            //RuleFor(customer => customer.Password).NotEqual(customer => customer.LastName);
        }
    }
}
