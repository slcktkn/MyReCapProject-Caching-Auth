using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal
    {
        //List<Car> _cars;

        //public InMemoryDal()
        //{
        //    _cars = new List<Car>
        //    {
        //        new Car{Id = 1,BrandId = 1,ColorId = 23,ModelYear = "2021",DailyPrice = 350,Description = "TOGG"},
        //        new Car{Id = 2,BrandId = 1,ColorId = 345,ModelYear = "2021",DailyPrice = 340,Description = "SUV"},
        //        new Car{Id = 3,BrandId = 2,ColorId = 34565,ModelYear = "2021",DailyPrice = 500,Description = "TRUCK"},
        //        new Car{Id = 4,BrandId = 2,ColorId = 23,ModelYear = "2021",DailyPrice = 750,Description = "BUS"},
        //        new Car{Id = 5,BrandId = 1,ColorId = 23,ModelYear = "2021",DailyPrice = 300,Description = "Mercedes"},
        //    };
        //}

        //public List<Car> GetById(int id)
        //{
        //    return _cars.Where(c => c.Id == id).ToList();
        //}

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(Car car)
        //{
        //    _cars.Add(car);
        //}

        //public void Update(Car car)
        //{
        //    Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
        //    carToUpdate.BrandId = car.BrandId;
        //    carToUpdate.ColorId = car.ColorId;
        //    carToUpdate.DailyPrice = car.DailyPrice;
        //    carToUpdate.Description = car.Description;
        //    carToUpdate.ModelYear = car.ModelYear;
        //}

        //public void Delete(Car car)
        //{
        //    Car carToDelete;
        //    carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
        //    _cars.Remove(carToDelete);
        //}
    }
}
