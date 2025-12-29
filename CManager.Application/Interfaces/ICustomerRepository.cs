using System;
using CManager.Domain.Models;

namespace CManager.Application.Interfaces;

public interface ICustomerRepository
{
    void Save(List<Customer> customers);
    List<Customer> GetAll();
}
