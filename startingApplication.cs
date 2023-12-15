using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Lab_10___Call_the_database.Models;
using Lab_10___Call_the_database.Functions;

namespace Lab_10___Call_the_database;

public class startingApplication
{
	public static void startProgram()
	{
        char userInput;
        using (var context = new NorthwindContext())
        {
            while (true)
            {
                Console.WriteLine("\t\tWelcome to the NorthWind Database!!");
                mainMenu:
                Console.WriteLine("\t\t\n\t\tPlease choose your option below: ");
                Console.WriteLine("\t\t1. Customer's List");
                Console.WriteLine("\t\t2. Customer's Details");
                Console.WriteLine("\t\t3. Add a new customer");
                Console.WriteLine("\t\t4. Exit");
                Console.Write("\n\t\tEnter your choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        customersList.customerList(context);
                        break;
                    case "2":
                        customersDetails.customerDetails(context);
                        break;
                    case "3":
                        addaCustomer.AddCustomer(context);
                        break;
                    case "4":
                        Console.WriteLine("\t\tThis will end you session and will EXIT you from the the system.");
                        Console.Write("\t\t\n\t\tDo you want to exit now? (y/n): ");
                        userInput = Console.ReadKey().KeyChar;

                        switch (Char.ToLower(userInput))
                        {
                            case 'y':
                                Console.WriteLine("\t\t\n\t\tExiting program. Thank you!");
                                Environment.Exit(0); // 0 indicates a successful exit
                                break;
                            case 'n':
                                goto mainMenu;
                            //break;
                            default:
                                Console.WriteLine("t\t\n\t\tInvalid input. Try again.");
                                break;

                        }
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }
    }
}

