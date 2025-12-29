using System;
using System.Text.Json;
using CManager.Application.Interfaces;
using CManager.Domain.Models;

namespace CManager.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private const string FilePath = "customers.json";

    public List<Customer> GetAll()
    {
        if (!File.Exists(FilePath))
        return new List<Customer>();

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Customer>>(json) ?? new();
    }

    public void Save(List<Customer> customers)
    {
        var json = JsonSerializer.Serialize(customers, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FilePath, json);
    }
}
