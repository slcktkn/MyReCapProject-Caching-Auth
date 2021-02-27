using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.LoadedList);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),Messages.GetCarsById);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new ErrorDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.GetBrandsById);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id),Messages.GetCarsById);

        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice<0 ||car.CarName.Length<3)
            {
                return new ErrorResult(Messages.InvalidName);
            }
            _carDal.Add(car);

            return new SuccessResult(Messages.ValidName);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
          return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),Messages.LoadedList);
        }
    }
}
