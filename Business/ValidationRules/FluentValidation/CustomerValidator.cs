using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.CompanyName).NotEmpty();
            RuleFor(customer => customer.CustomerName).NotEmpty();
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.LastName).NotEmpty();
            RuleFor(customer => customer.Email).EmailAddress();
            RuleFor(customer => customer.CustomerName).Length(2,50);
            RuleFor(customer => customer.LastName).Length(2,50);
            RuleFor(customer => customer.FirstName).Length(2, 50);
            RuleFor(customer => customer.FirstName).NotEqual(customer => customer.LastName);
            RuleFor(customer => customer.Password).NotNull();
            RuleFor(customer => customer.Password).NotEqual(customer=>customer.LastName);
        }
    }
}
