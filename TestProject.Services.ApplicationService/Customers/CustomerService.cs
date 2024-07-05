using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Contracts.Customers;
using TestProject.Domain.Core.Customers;

namespace TestProject.Services.ApplicationService.Customers
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository repository { get; set; }
        public CustomerService(ICustomerRepository _repository)
        {
            repository= _repository;
        }
        public void Add(Customer customer)
        {
            if (repository.Find(customer.FirstName, customer.LastName, customer.DateOfBirth) is not null)
                throw new Exception("Customer is Exist");

            if (ValidateCustomer(customer))
                repository.Add(customer);    
            
        }

        public bool Delete(string firstname,string lastname,DateTime birthDate)
        {
            var entity = repository.Find(firstname,lastname,birthDate);
            if (entity != null)
            {
                repository.Delete(entity);
                return true;
            }
            else
                return false;
        }

     

        public IEnumerable<Customer> List()
        {
            return repository.List();
        }

        public void Update(Customer customer)
        {
            var oldCustomer=repository.Find(customer.FirstName,customer.LastName,customer.DateOfBirth);
            if (oldCustomer is null)
            {
                throw new Exception("Customer Not Exist");
            }
            if (ValidateCustomer(customer))
                 repository.Update(customer,oldCustomer);
        }
        private bool ValidateCustomer(Customer customer)
        {
            CustomerValidator validator = new();
            var res=validator.Validate(customer);
                       
            if(!res.IsValid)
                throw new Exception(string.Join('-', res.Errors.Select(x => x.ErrorMessage))); 
            return true;
          
            
        }
    }
}
