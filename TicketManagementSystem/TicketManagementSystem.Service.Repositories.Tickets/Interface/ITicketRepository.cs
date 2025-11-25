using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.DomainTier.Models;

namespace TicketManagementSystem.Service.Repositories.Tickets.Interface
{
    public interface ITicketRepository
    {
        int CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        Ticket GetTicket(int id);
    }
}
