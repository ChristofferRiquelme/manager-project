using System;
using CManager.Application.Interfaces;
using CManager.Domain.Models;

namespace CManager.Presentation.ConsoleApp.Controllers;

public class MenuController
{
    private ICustomerService _customerService;

    public MenuController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Skapa kund");
            Console.WriteLine("2. Visa kunder");
            Console.WriteLine("3. Visa specifik kund");
            Console.WriteLine("4. Ta bort kund");
            Console.WriteLine("0. Avsluta");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateCustomer(); break;
                case "2": ShowCustomers(); break;
                case "3": ShowCustomer(); break;
                case "4": DeleteCustomer(); break;
                case "0": return;
            }

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }

    private void CreateCustomer()
    {
        Console.Clear();
        Console.WriteLine("Skapa en ny kund");

        Console.Write("Förnamn: ");
        var fname = Console.ReadLine();

        Console.Write("Efternamn: ");
        var lname = Console.ReadLine();

        Console.Write("Email: ");
        var email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Namn och email får inte vara tomma.");
            return;
        }

        var customer = new Customer
        {
            FirstName = fname,
            LastName = lname,
            Email= email
        };

        _customerService.Create(customer);

        Console.WriteLine("Kunden skapades!");
    }
    private void ShowCustomers()
    {
        
    }
    private void ShowCustomer()
    {
        
    }
    private void DeleteCustomer()
    {
        
    }
}
