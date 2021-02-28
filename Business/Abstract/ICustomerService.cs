using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetCustomersById(int userId);
        IResult Add(Customer customer);
    }
}
