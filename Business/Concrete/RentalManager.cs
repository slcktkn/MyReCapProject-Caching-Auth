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

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.LoadedList);
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(c =>
            c.CarId == rental.CarId && c.ReturnDate > DateTime.Now || rental.ReturnDate == null).Any();
            //if (_rentalDal.GetAll(p => p.CarId == rental.CarId && p.ReturnDate == null) != null)  c.CarId == rental.CarId &&
            //var result = _rentalDal.GetAll(c =>  c.ReturnDate==null).Any();
            if (result)
            {
               return new ErrorResult(Messages.ErrorReservation);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.MadeReservation);
            }
            //    _rentalDal.GetAll(c => c.CarId == rental.CarId || rental.ReturnDate == null);

            //    if (rental.ReturnDate == null)
            //    {
            //        return new ErrorResult(Messages.ErrorReservation);
            //    }
            //    else
            //    {
            //        _rentalDal.Add(rental);
            //        return new SuccessResult(Messages.MadeReservation);
            //    }
        }

        public IDataResult<Rental> GetRentalCarById(int carId)
        {
            return new ErrorDataResult<Rental>(_rentalDal.Get(c=>c.ReturnDate==null),Messages.ErrorReservation);
        }
    }
}
