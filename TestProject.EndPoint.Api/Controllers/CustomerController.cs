using Microsoft.AspNetCore.Mvc;
using TestProject.Domain.Contracts.Customers;
using TestProject.Domain.Core.Customers;

namespace TestProject.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IEnumerable<Customer> Get() => service.List();


        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                service.Add(customer);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        public IActionResult Delete(string firstname, string lastname, DateTime birthDate)
        {
            try
            {
                if (service.Delete( firstname,  lastname,  birthDate))
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            try
            {
                service.Update(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
