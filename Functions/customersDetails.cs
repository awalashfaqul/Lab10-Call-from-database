using System;
using Lab_10___Call_the_database.Models;

namespace Lab_10___Call_the_database.Functions;

public class customersDetails
{
    public static void customerDetails(NorthwindContext context)
    {
        Console.WriteLine("\t\tEnter the customer's ID for details about:");
        var customerId = Console.ReadLine();

        var customerDetails = context.Customers
            .Where(c => c.CustomerId == customerId)
            .Select(c => new
            {
                c.CompanyName,
                c.ContactName,
                c.ContactTitle,
                c.Address,
                c.City,
                c.Region,
                c.PostalCode,
                c.Country,
                c.Phone,
                Orders = c.Orders.Select(o => new { o.OrderId, o.OrderDate, o.ShippedDate }).ToList()
            })
            .FirstOrDefault();

        if (customerDetails == null)
        {
            Console.WriteLine("Invalid Customer  ID. No such customer exists.");
            return;
        }

        Console.WriteLine($"Company: {customerDetails.CompanyName}");
        Console.WriteLine($"Contact: {customerDetails.ContactName}, {customerDetails.ContactTitle}");
        Console.WriteLine($"Address: {customerDetails.Address}");
        Console.WriteLine($"City: {customerDetails.City}, {customerDetails.Region}, {customerDetails.PostalCode}");
        Console.WriteLine($"Country: {customerDetails.Country}");
        Console.WriteLine($"Phone: {customerDetails.Phone}");
        Console.WriteLine("Orders:");

        foreach (var order in customerDetails.Orders)
        {
            Console.WriteLine($"  Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Shipped Date: {(order.ShippedDate.HasValue ? order.ShippedDate.ToString() : "Not shipped yet")}");
        }
    }
}

