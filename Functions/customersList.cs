using System;
using Lab_10___Call_the_database.Models;

namespace Lab_10___Call_the_database.Functions;

	public class customersList
	{
        public static void customerList(NorthwindContext context)
        {
            Console.WriteLine("Sort by company name in (A)scending or (D)escending order?");
            var sortOrder = Console.ReadLine();

            var customersQuery = context.Customers
                .Select(c => new
                {
                    c.CustomerId,
                    c.CompanyName,
                    c.Country,
                    c.Region,
                    c.Phone,
                    OrderCount = c.Orders.Count
                });

            var customers = sortOrder.ToUpper() == "A"
                ? customersQuery.OrderBy(c => c.CompanyName).ToList()
                : customersQuery.OrderByDescending(c => c.CompanyName).ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer's ID: {customer.CustomerId} " + $"Company: {customer.CompanyName} " + $"Country: {customer.Country} " +
                                  $"Region: {customer.Region} " + $"Phone: {customer.Phone} " +
                                  $"Orders: {customer.OrderCount}");
            }
        }
}

