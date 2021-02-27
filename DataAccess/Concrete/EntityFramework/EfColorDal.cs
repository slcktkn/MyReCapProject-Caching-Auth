using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:EfEntityRepositoryBase<Color,CarRentalContext>,IColorDal
    {
        public List<ColorDetailsDto> GetColorDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from cl in context.Colors
                    join c in context.Cars on cl.ColorId equals c.ColorId
                    join br in context.Brands on c.BrandId equals br.BrandId
                    select new ColorDetailsDto
                    {
                        CarName = c.CarName,
                        ColorName = cl.ColorName,
                        DailyPrice = c.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
