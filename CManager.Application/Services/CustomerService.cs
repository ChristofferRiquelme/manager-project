using System;
using CManager.Application.Interfaces;
using CManager.Domain.Models;

namespace CManager.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly List<Customer> _customers;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
        _customers = _repository.GetAll();
    }

    public void Create(Customer customer)
    {
        customer.Id = Guid.NewGuid();
        _customers.Add(customer);
        _repository.Save(_customers);
    }

    public List<Customer> GetAll() => _customers;

    public Customer? GetByEmail(string email)
        => _customers.FirstOrDefault(x => x.Email == email);

    public bool DeleteByEmail(string email)
    {
        var customer = GetByEmail(email);
        if (customer == null)
            return false;

        _customers.Remove(customer);
        _repository.Save(_customers);
        return true;
    }
}
