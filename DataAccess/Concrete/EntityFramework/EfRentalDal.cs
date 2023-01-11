using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cus in context.Customers on r.CustomerId equals cus.CustomerId
                             join usr in context.UserOperations on cus.UserOperationId equals usr.UserOperationId
                             join col in context.Colors on c.ColorId equals col.ColorId

                             select new CarRentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CustomerName = usr.FirstName,
                                 CustomerCompanyName = cus.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };


                return result.ToList();

            }
        }
    }
}
