using api.DTOs;
using api.Models;
using api.Services;
using api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CustomerController : ControllerBase
  {
    private readonly CustomerService _service;

    public CustomerController(CustomerService service)
    {
      _service = service;
    }

    [HttpGet(Name = "GetCustomers")]
    public async Task<IEnumerable<Customer>> Get()
    {
      return await _service.GetAllAsync();
    }

    [HttpGet("{id}", Name = "GetCustomer")]
    public async Task<ActionResult<Customer>> GetById(Guid id)
    {
      var customer = await _service.GetByIdAsync(id);

      return customer;
    }

    [HttpPost(Name = "AddCustomer")]
    [Authorize]
    public async Task<IActionResult> Create(CustomerDTO customerDTO)
    {
      var newCustomer = await _service.CreateAsync(customerDTO);
      if (newCustomer.Name.Equals("name_error_409_validations"))
      {
        return ErrorUtilities.UniqueName("Customer");
      }

      if (newCustomer.Email.Equals("email_error_409_validations"))
      {
        return ErrorUtilities.EmailName("Email");
      }

      return CreatedAtAction(nameof(GetById), new { id = newCustomer.CustomerID }, customerDTO);
    }

    [HttpPut("{id}", Name = "EditCustomer")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, CustomerDTO customerDTO)
    {
      var customerToUpdate = await _service.GetByIdAsync(id);

      if (customerToUpdate is not null)
      {
        await _service.UpdateAsync(id, customerDTO);
        return NoContent();
      }
      else
      {
        return new NotFoundObjectResult(new { message = $"The {customerDTO} with ID = {id} doesn't exist." });
      }
    }
  }
}
