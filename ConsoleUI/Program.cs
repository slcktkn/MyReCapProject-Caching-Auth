using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            CarDetailTest();

            RentalManager rentalManager=new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId = 24 });
            rentalManager.GetRentalCarById(3);
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var carDetail in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(carDetail.CarName + "---" + carDetail.ColorName + "---" + "---" + carDetail.BrandName +
                                  "---" + carDetail.DailyPrice);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var c in carManager.GetAll().Data)
            {
                Console.WriteLine(c.CarName);
            }
        }
    }
}
