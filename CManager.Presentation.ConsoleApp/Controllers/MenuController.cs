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

        Console.Write("Telefonnummer: ");
        var phoneNumber = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
        {
            Console.WriteLine("Namn och email får inte vara tomma.");
            return;
        }

        var customer = new Customer
        {
            FirstName = fname,
            LastName = lname,
            Email = email,
            PhoneNumber = phoneNumber 
        };

        try
        {
            _customerService.Create(customer);
            Console.WriteLine("Kunden skapades!");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private void ShowCustomers()
    {
        Console.Clear();
        Console.WriteLine("Alla kunder\n");

        var customers = _customerService.GetAll();

        if (!customers.Any())
        {
            Console.WriteLine("Inga kunder finns ännu.");
            return;
        }

        foreach (var customer in customers)
        {
            Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
            Console.WriteLine("----------------------");
        }
    }
    private void ShowCustomer()
    {
        Console.Clear();
        Console.WriteLine("Visa kund\n");

        Console.Write("Ange email: ");
        var email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Email får inte vara tom.");
            return;
        }

        var customer = _customerService.GetByEmail(email);

        if (customer == null)
        {
            Console.WriteLine("Ingen kund hittades med den angivna email adressen.");
            return;
        }

        Console.WriteLine("\nKundinformation:");
        Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
        Console.WriteLine($"Email: {customer.Email}");
        Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
    }
    private void DeleteCustomer()
    {
        Console.Clear();
        Console.WriteLine("Ta bort kund\n");

        Console.Write("Ange email: ");
        var email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("Email får inte vara tom.");
            return;
        }

        var success = _customerService.DeleteByEmail(email);

        if (!success)
        {
            Console.WriteLine("Ingen kund hittade med den angivna email adressen.");
            return;
        }

        Console.WriteLine("Kunden har tagits bort.");
    }
}
