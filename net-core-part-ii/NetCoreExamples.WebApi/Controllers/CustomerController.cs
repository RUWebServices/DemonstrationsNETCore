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
    /// <summary>
    /// Used to manipulate and get information about customers
    /// </summary>
    [Analytics]
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>A list of customers</returns>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [HttpGet]
        [Route("")]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        /// <summary>
        /// Gets a customer by id
        /// </summary>
        /// <param name="id">Id which is associated with a customer within the system</param>
        /// <returns>A single customer (if it was found)</returns>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        /// <summary>
        /// Creates a new customer within the system
        /// </summary>
        /// <param name="customer">This is the customer input model</param>
        /// <returns>A status code of 201 and a set Location header.</returns>
        [ProducesResponseType(201)]
        [ProducesResponseType(412)]
        [HttpPost]
        [Route("")]
        public IActionResult CreateNewCustomer([FromBody] CustomerInputModel customer)
        {
            if (!ModelState.IsValid) { throw new ModelFormatException("Customer was not properly formatted."); }

            return Ok();
        }
    }
}