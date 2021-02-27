using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
   public interface ICarService
   {
       IDataResult<List<Car>> GetAll();
       IDataResult<List<Car>> GetCarsByColorId(int id); 
       IDataResult<List<Car>> GetCarsByBrandId(int id); 
       IDataResult<Car> GetById(int id);
       IResult Add(Car car);
       IDataResult<List<CarDetailsDto>> GetCarDetails();
   }
}
