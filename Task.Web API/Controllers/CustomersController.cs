using Microsoft.AspNetCore.Mvc;
using Task.Application.Services;
using Task.Core.DTO;
using Task.Core.Interfaces;
using Task.Core.Model;
using Task.Infrastructure.Repositories;

namespace Task.Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> AddCustomer(CustomerDTO customerDTO)
        {
            var addedCustomer = await _customerService.AddCustomerAsync(customerDTO);
            return CreatedAtAction(nameof(GetCustomerById), new { id = addedCustomer.Id }, addedCustomer);
        }
    }

 }
