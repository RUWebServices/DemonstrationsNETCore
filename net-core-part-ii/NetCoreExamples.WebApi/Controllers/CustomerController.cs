using Microsoft.AspNetCore.Mvc;
using NetCoreExamples.Models.Dtos;
using NetCoreExamples.Models.Exceptions;
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
            return Ok(customer);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateNewCustomer([FromBody] CustomerInputModel customer)
        {
            if (!ModelState.IsValid) { throw new ModelFormatException("Customer was not properly formatted."); }

            return Ok();
        }
    }
}