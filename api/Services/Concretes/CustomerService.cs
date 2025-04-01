using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Repositories;

namespace api.Services
{
  public class CustomerService : ICustomerService
  {
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
      return await _customerRepository.GetAllAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
      return await _customerRepository.GetByIdAsync(id);
    }

    public async Task<Customer> CreateAsync(CustomerDTO newCustomerDTO)
    {
      if (await IsCustomerNameUnique(newCustomerDTO.Name))
      {
        var customer = new Customer();
        customer.Name = "name_error_409_validations";
        return customer;
      }

      if (await IsEmailUnique(newCustomerDTO.Email))
      {
        var customer = new Customer();
        customer.Email = "email_error_409_validations";
        return customer;
      }

      var newCustomer = new Customer();
      newCustomer.CustomerID = Guid.NewGuid();
      newCustomer.Email = newCustomerDTO.Email;
      newCustomer.Name = newCustomerDTO.Name;
      newCustomer.Password = newCustomerDTO.Password;
      newCustomer.RegionID = newCustomerDTO.RegionID;
      newCustomer.Nit = newCustomerDTO.Nit;
      if (newCustomerDTO.IsAvailable)
      {
        newCustomer.IsAvailable = "true";
      }
      else
      {
        newCustomer.IsAvailable = "false";
      }

      await _customerRepository.AddAsync(newCustomer);

      return newCustomer;
    }

    public async Task UpdateAsync(Guid id, CustomerDTO customerDTO)
    {
      var existingCustomer = await GetByIdAsync(id);

      if (existingCustomer is not null)
      {
        existingCustomer.Email = customerDTO.Name;
        existingCustomer.Name = customerDTO.Name;
        existingCustomer.Password = customerDTO.Password;
        existingCustomer.RegionID = customerDTO.RegionID;
        existingCustomer.Nit = customerDTO.Nit;
        if (customerDTO.IsAvailable)
        {
          existingCustomer.IsAvailable = "true";
        }
        else
        {
          existingCustomer.IsAvailable = "false";
        }

        await _customerRepository.UpdateAsync(existingCustomer);
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      var customerToDelete = await GetByIdAsync(id);

      if (customerToDelete is not null)
      {
        await _customerRepository.DeleteAsync(customerToDelete.CustomerID);
      }
    }

    public async Task<bool> IsCustomerNameUnique(string customerName)
    {
      return await _customerRepository.IsCustomerNameUnique(customerName);
    }

    public async Task<bool> IsEmailUnique(string customerEmail)
    {
      return await _customerRepository.IsEmailUnique(customerEmail);
    }
  }
}
