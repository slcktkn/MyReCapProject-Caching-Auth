using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IRentalService
   {
       IDataResult<List<Rental>> GetAll();
       IResult Add(Rental rental);
       IDataResult<Rental> GetRentalCarById(int carId);
   }
}
