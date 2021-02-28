using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
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

        public IResult Add(Rental rental)
        {
            //var result = _rentalDal.GetAll(c =>
            //c.CarId == rental.CarId && c.ReturnDate > DateTime.Now || rental.ReturnDate == null).Any();
            var result = _rentalDal.GetAll(c => c.CarId == rental.CarId&&c.ReturnDate==null).Any();
            if (result)
                return new ErrorResult(Messages.ErrorReservation);
            else
                _rentalDal.Add(rental);
            return new SuccessResult(Messages.MadeReservation);
        }

        public IDataResult<Rental> GetRentalCarById(int carId)
        {
            return new ErrorDataResult<Rental>(_rentalDal.Get(c=>c.ReturnDate==null),Messages.ErrorReservation);
        }
    }
}
