using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestProject.Domain.Core.Customers;

namespace TestProject.Domain.Contracts.Customers;

public interface ICustomerRepository 
{
    void Add(Customer entity);
    void Delete(Customer customer);
    IQueryable<Customer> List();
    Customer Find(string firstname, string lastname, DateTime birthDate);
    void Update(Customer newCustomer, Customer oldCustomer);
}

