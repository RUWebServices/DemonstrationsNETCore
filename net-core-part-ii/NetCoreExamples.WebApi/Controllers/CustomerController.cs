using Microsoft.AspNetCore.Mvc;
using NetCoreExamples.Models.InputModels;
using NetCoreExamples.Services;
using NetCoreExamples.Services.Implementations;
using NetCoreExamples.Services.Interfaces;
using NetCoreExamples.WebApi.Attributes;

namespace NetCoreExamples.WebApi.Controllers
{
    [Analytics]
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null) { return NotFound($"Customer with id {id} was not found."); }
            return Ok(customer);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewCustomer([FromBody] CustomerInputModel customer)
        {
            if (!ModelState.IsValid) { return StatusCode(412, customer); }

            return Ok();
        }
    }
}