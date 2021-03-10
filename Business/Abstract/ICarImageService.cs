using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file,CarImage carImage);
        IResult Update(IFormFile file,CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int carId);
    }
}
