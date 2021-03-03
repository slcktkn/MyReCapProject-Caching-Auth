using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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

        public IDataResult<List<CustomerDetailsDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.GetCustomerDetails(),Messages.ListedDetails);
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.StartsWith("K"))
            {
                return new ErrorResult(Messages.InvalidName);
            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.ValidName);

            ;
        }
    }
}
