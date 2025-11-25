using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.DomainTier.Accounts;
using TicketManagementSystem.DomainTier.eNums;
using TicketManagementSystem.DomainTier.Models;

namespace TicketManagementSystem.Service.Interfaces
{
    public interface ITicketService
    {
        Task<int> CreateTicket(User user, Ticket ticket, Priority priority);
        Task AssignTicketAsync(User user);
    }
}
