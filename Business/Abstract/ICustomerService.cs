using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetCustomersById(int userId);
        IDataResult<List<CustomerDetailsDto>> GetCustomerDetails();
        IResult Add(Customer customer);
    }
}
