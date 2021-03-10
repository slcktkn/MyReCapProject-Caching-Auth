using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCount(carImage.CarId)
                 , CheckIfCarImageExists(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult();
            }

            carImage.ImagePath = FileHelper.Add(file);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCount(carImage.CarId)
                , CheckIfCarImageExists(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.CarId == carImage.CarId)
                .ImagePath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.LoadedList);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> Get(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.CarId==carId));
        }

        private IResult CheckIfCarImageExists(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id && c.ImagePath == null).Any();
            if (result)
            {
                return new ErrorResult(Messages.AddCarImageToList);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageCount(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.NumberOfCarImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
