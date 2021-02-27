using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,CarRentalContext>,ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from c in context.Cars
                    join cl in context.Colors on c.ColorId equals cl.ColorId
                    join br in context.Brands on cl.ColorId equals br.BrandId
                    select new CarDetailsDto
                    {
                        BrandName = br.BrandName,
                        DailyPrice = c.DailyPrice,
                        CarName = c.CarName,
                        ColorName = cl.ColorName

                    };
                return result.ToList();
            }
        }
    }
}

