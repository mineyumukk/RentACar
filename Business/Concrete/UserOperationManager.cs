using Business.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationManager : IUserOperationService
    {
        IUserOperationDal _userOperationDal;
        public UserOperationManager(IUserOperationDal userOperationDal)
        {
            _userOperationDal = userOperationDal;
        }

        [ValidationAspect(typeof(UserOperation))]
        public IResult Add(UserOperation userOperation)
        {
            _userOperationDal.Add(userOperation);
            return new SuccessResult();
        }

        public IResult Delete(UserOperation userOperation)
        {
            _userOperationDal.Delete(userOperation);
            return new SuccessResult();
        }

        public IDataResult<UserOperation> GetByMail(string email)
        {
            return new SuccessDataResult<UserOperation>(_userOperationDal.Get(u=>u.Email==email));
        }

        [ValidationAspect(typeof(UserOperation))]
        public IResult Update(UserOperation userOperation)
        {
            _userOperationDal.Update(userOperation);
            return new SuccessResult();
        }
    }
}
