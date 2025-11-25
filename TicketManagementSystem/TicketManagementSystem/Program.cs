using EmailService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TicketManagementSystem.DomainTier.Accounts;
using TicketManagementSystem.DomainTier.eNums;
using TicketManagementSystem.DomainTier.ErrorHandler;
using TicketManagementSystem.DomainTier.Models;
using TicketManagementSystem.Service.Repositories.Tickets;
using TicketManagementSystem.Service.Repositories.Tickets.Interface;


// Add these using statements if needed for the interfaces
using TicketManagementSystem.Service.Repositories.Users;
using TicketManagementSystem.Service.Repositories.Users.Interfaces;
 

namespace TicketManagementSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
          .ConfigureLogging(builder =>
          {
              builder.AddConsole();
              // configure other providers if needed
          })
          .Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            try
            {
                RunApplication(logger);
            }
            catch (UnknownUserException ex)
            {
                logger.LogError(ex, "Unknown user error occurred");
                // optionally rethrow or handle
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Unhandled exception");
                throw;
            }
            Console.WriteLine("Ticket Service Test Harness");
           

            Console.WriteLine("Please Enter Your FIRST NAME......  and press enter");
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine() ?? "";  // ReadLine returns a string

            // Ask for last name
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine() ?? "";

            // Ask for Id — since Id is int, parse the string
            Console.Write("Enter Id (number): ");
            string idInput = Console.ReadLine() ?? "";

            Console.Write("Enter Username: ");
            string username = Console.ReadLine() ?? "";
            int id;
            if (!int.TryParse(idInput, out id))
            {
                Console.WriteLine("Invalid number for Id. Setting Id = 0.");
                id = 0;
            }
            User user = new User
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Username = username
            };

 
            IUserRepository userRepository = new UserRepository();  
            IEmailService emailService = new EmailServiceProxy();
            ITicketRepository ticketRepository = new TicketRepository();

            var service = new TicketService(userRepository, emailService, ticketRepository);

            var ticket = new Ticket
            {
                Title = "System Crash",
                AssignedUser = user,
                Description = "The system crashed when user performed a search",
                Created = DateTime.UtcNow,
                IsPayingCustomer = true
            };

            var ticketId = await service.CreateTicket(user, ticket, Priority.Medium);

            Console.WriteLine($"Created ticket with ID: {ticketId}");
            service.AssignTicketAsync(user);

            Console.WriteLine("Done");
        }

        private static void RunApplication(ILogger logger)
        {
            // Example – throw the custom exception
            throw new UnknownUserException("User with ID 123 not found");
        }
    }
}
