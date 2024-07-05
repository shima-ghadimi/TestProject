using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Core.Customers;

namespace TestProject.Domain.Contracts.Customers
{
    public interface ICustomerService
    {
        void Add(Customer entity);
        bool Delete(string firstname, string lastname, DateTime birthDate);
        IEnumerable<Customer> List();
      
        void Update(Customer entity);
    }
}
