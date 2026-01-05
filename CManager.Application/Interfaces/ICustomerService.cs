using System;
using CManager.Domain.Models;

namespace CManager.Application.Interfaces;

public interface ICustomerService
{
    void Create(Customer customer);
    List<Customer> GetAll();
    Customer? GetByEmail(string email);
    bool DeleteByEmail(string email);
}
