using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Core.Customers;

namespace TestProject.Services.ApplicationService.Customers
{
    public class CustomerValidator :AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage("Email Not Valid");
            RuleFor(c => c.PhoneNumber).Matches(@"^(\\+98|0)?9\\d{9}$").WithMessage("Phone Number Not Valid");
            RuleFor(c => c.BankAccountNumber).Length(8).WithMessage("Enter 8 characters");
                
        }
    }
}
