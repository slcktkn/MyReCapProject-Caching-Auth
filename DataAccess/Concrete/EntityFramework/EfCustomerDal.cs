using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarRentalContext>,ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomerDetailsDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        CompanyName = c.CompanyName,
                        Email = u.EMail,
                    };

                return result.ToList();
            }
        }
    }
}
