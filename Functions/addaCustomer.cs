using System;
using Lab_10___Call_the_database.Models;

namespace Lab_10___Call_the_database.Functions;

public class addaCustomer
{
    public static void AddCustomer(NorthwindContext context)
    {
        var customer = new Customer
        {
            CustomerId = GenerateRandomCustomerID(),
            CompanyName = PromptForInput("Enter company name: ", false),
            ContactName = PromptForInput("Enter contact name: ", true),
            ContactTitle = PromptForInput("Enter contact title: ", true),
            Address = PromptForInput("Enter address: ", true),
            City = PromptForInput("Enter city: ", true),
            Region = PromptForInput("Enter region: ", true),
            PostalCode = PromptForInput("Enter postal code: ", true),
            Country = PromptForInput("Enter country: ", true),
            Phone = PromptForInput("Enter phone number: ", true),
        };

        context.Customers.Add(customer);
        context.SaveChanges();
        Console.WriteLine($"New customer added with ID: {customer.CustomerId}");
    }

    static string GenerateRandomCustomerID()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 5)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    static string PromptForInput(string prompt, bool allowNull)
    {
        string input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
            if (allowNull)
            {
                return string.IsNullOrWhiteSpace(input) ? null : input;
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
}

