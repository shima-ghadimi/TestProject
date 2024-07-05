using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Contracts.Customers;
using TestProject.Domain.Core.Customers;
using TestProject.InfraStracture.DataLayer.Common;


namespace TestProject.InfraStracture.DataLayer.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbInMemoryContext db;
        public CustomerRepository()
        {
            db = new DbInMemoryContext();

            if (!db.Customers.Any())
            {
                var customers = new List<Customer>
                {
                 new(){FirstName="Shima",LastName="Ghadimi",DateOfBirth=new(1993,09,25),Email="www.Shimaghadimi72@gmail.com",PhoneNumber="09194938042",BankAccountNumber="12345678"},
                  new(){FirstName="Sara",LastName="Baghery",DateOfBirth=new(2000,10,01),Email="www.Sara78@gmail.com",PhoneNumber="09121234554",BankAccountNumber="87654321"},
                };
                db.Customers.AddRange(customers);
                db.SaveChanges();
            }
            


        }

        public void Add(Customer entity)
        {       
                db.Add(entity);
                db.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            db.Remove(customer);
            db.SaveChanges();
        }


        public Customer Find(string firstname, string lastname, DateTime birthDate)
        {
            return db.Customers.FirstOrDefault(c => c.FirstName == firstname &&
                                          c.LastName == lastname &&
                                          c.DateOfBirth == birthDate);
        }
        public IQueryable<Customer> List()
        {
            return db.Customers.AsQueryable();
        }

        public void Update(Customer newCustomer, Customer oldCustomer)
        {

            oldCustomer.FirstName = newCustomer.FirstName;
            oldCustomer.LastName = newCustomer.LastName;
            oldCustomer.Email = newCustomer.Email;
            oldCustomer.PhoneNumber = newCustomer.PhoneNumber;
            oldCustomer.BankAccountNumber = newCustomer.BankAccountNumber;
            db.Customers.Update(oldCustomer);
            db.SaveChanges();

        }
    }
}
