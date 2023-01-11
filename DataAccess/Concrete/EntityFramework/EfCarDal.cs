using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join col in context.Colors on c.ColorId equals col.ColorId
                             
                             
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName= b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice=c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();

            }
        }
    }
}
