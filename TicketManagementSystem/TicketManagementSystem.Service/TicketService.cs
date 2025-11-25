using EmailService;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IO;
using System.Text.Json;
using TicketManagementSystem.DomainTier.Accounts;
using TicketManagementSystem.DomainTier.eNums;
using TicketManagementSystem.DomainTier.ErrorHandler;
using TicketManagementSystem.DomainTier.Models;
using TicketManagementSystem.Service.Repositories.Tickets;
using TicketManagementSystem.Service.Repositories.Tickets.Interface;
using TicketManagementSystem.Service.Repositories.Users;
using TicketManagementSystem.Service.Repositories.Users.Interfaces;

namespace TicketManagementSystem.Service.Repositories.Tickets
{
    public class TicketService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
           private readonly ITicketRepository _ticketRepository;
          

        public TicketService(IUserRepository userRepository, IEmailService emailService, ITicketRepository ticketRepository)
        {
            _userRepository = userRepository;
            _emailService = emailService;
               _ticketRepository = ticketRepository;
       
        }

        public TicketService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<int>  CreateTicket(User user, Ticket ticket, Priority p)
        {
            if (string.IsNullOrWhiteSpace(ticket.Title) || string.IsNullOrWhiteSpace(ticket.Description))
            {
                throw new InvalidTicketException("Title or description were null or empty");
            }

            if (ticket.AssignedUser != null)
            {
                User assignedUser = ticket.AssignedUser;
                var fullUser = await _userRepository.GetUser(assignedUser.Username /* or ID */);
                if (fullUser == null)
                    throw new UnknownUserException($"Assigned user {assignedUser.Username} not found");

                ticket.AssignedUser = fullUser;

            }

           bool priorityRaised = false;
            if (ticket.Created < DateTime.UtcNow - TimeSpan.FromHours(1))
            {
                if (p == Priority.Low) { p = Priority.Medium; priorityRaised = true; }
                else if (p == Priority.Medium) { p = Priority.High; priorityRaised = true; }
            }

            if ((ticket.Title.Contains("Crash") || ticket.Title.Contains("Important") || ticket.Title.Contains("Failure")) && !priorityRaised)
            {
                if (p == Priority.Low) p = Priority.Medium;
                else if (p == Priority.Medium) p = Priority.High;
            }

            if (p == Priority.High)
            {
                 _emailService.SendEmailToAdministrator(ticket.Title, ticket.AssignedUser.ToString());
            }

            double price = 0;/// default price. I dont know why its hardcoded here
            User accountManager = null;
            if (ticket.IsPayingCustomer)
            {
                accountManager = await _userRepository.GetAccountManager();
                price = (p == Priority.High) ? 100 : 50;
            }

            int id =  _ticketRepository.CreateTicket(ticket);
            return id;
        }
         
         public async Task AssignTicketAsync(User user) 
        {
           // User user = null;
            using (var ur = new UserRepository())
            {
                if (user.Username != null)
                {
                    user = await ur.GetUser(user.Username);
                }
            }

            if (user == null)
            {
                throw new UnknownUserException("User not found");
            }

            var ticket = _ticketRepository.GetTicket(user.Id);

            if (ticket == null)
            {
                throw new ApplicationException("No ticket found for id " + user.Id);
            }

            ticket.AssignedUser = user;

            _ticketRepository.UpdateTicket(ticket);
        }

        private void WriteTicketToFile(Ticket ticket)
        {
            var ticketJson = JsonSerializer.Serialize(ticket);
            File.WriteAllText(Path.Combine(Path.GetTempPath(), $"ticket_{ticket.Id}.json"), ticketJson);
        }
    }
}
