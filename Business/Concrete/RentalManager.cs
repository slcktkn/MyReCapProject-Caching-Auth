using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.LoadedList);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfReturnDateIsNull(rental.CarId, rental.ReturnDate)
                ,CheckIfCarRentalLimitExceeds(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarAddedSuccessfully);
        }

        public IDataResult<Rental> GetRentalCarById(int carId)
        {
            return new ErrorDataResult<Rental>(_rentalDal.Get(c => c.ReturnDate == null), Messages.ErrorReservation);
        }

        private IResult CheckIfReturnDateIsNull(int id, DateTime? returnDate)
        {
            var result = _rentalDal.GetAll(c => c.CarId == id && returnDate == null).Any();
            if (result)
            {
                return new ErrorResult(Messages.ErrorReservation);
            }
            return new SuccessResult(Messages.MadeReservation);
        }

        private IResult CheckIfCarRentalLimitExceeds(int id)
        {
            var result = _rentalDal.GetAll(c => c.CarId == id).Count;
            if (result>3)
            {
                return new ErrorResult(Messages.RentalCountOfCarError);
            }
            return new SuccessResult();
        }
    }
}
