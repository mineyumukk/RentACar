using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(Rental))]
        public IResult Add(Rental rental)
        {
            //var result = CheckReturnDate(rental.CarId);
            //if (!result.Success)
            //{
            //    return new ErrorResult(result.Message);

            //}
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetCarRentalDetails(r => r.CarId == carId && r.ReturnDate == null);

            if (result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId==id));
        }

        public IDataResult<List<CarRentalDetailDto>> GetRentalDetailDto()
        {
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<CarRentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarRentalDetailDto>>(_rentalDal.GetCarRentalDetails());
        }

        [ValidationAspect(typeof(Rental))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        [ValidationAspect(typeof(Rental))]
        public IResult UpdateReturnDate(Rental rental)
        {
            var result = _rentalDal.GetAll(r=>r.RentalId==rental.RentalId);
            var updateRental = result.LastOrDefault();
            if (updateRental.ReturnDate != null)
            {
                return new ErrorResult();
            }

            updateRental.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(updateRental);
            return new SuccessResult(Messages.RentalUpdatedReturnDate);
        }
    }
}
