using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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

            if (DateTime.Now.Hour==2)
            {
                return new ErrorDataResult<List<Car>>();
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.LoadedList);
        }

        [CacheRemoveAspect("ICarService.Get")]
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
        [CacheAspect()]
        [PerformanceAspect(5)]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.ValidName);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
          return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(),Messages.LoadedList);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice<2500)
            {
                throw new Exception("");
            }

            Add(car);
            return null;
        }
    }
}
