using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;
       }

       public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.LoadedList);
        }

        public IDataResult<List<Customer>> GetCustomersById(int userId)
        {
            return new ErrorDataResult<List<Customer>>(_customerDal.GetAll(c=>c.UserId==userId));
        }

        public IResult Add(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
