using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(rental => rental.RentDate).NotEmpty();
            RuleFor(rental => rental.ReturnDate).NotEmpty();
            RuleFor(rental => rental.ReturnDate).Must(NotNow);
        }

        private bool NotNow(DateTime? arg)
        {
            if (arg==DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
