using System.Collections.Generic;
using System.Linq;
using TicketManagementSystem.DomainTier.Models;
using TicketManagementSystem.Service.Repositories.Tickets.Interface;

namespace TicketManagementSystem.Service.Repositories.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        private static readonly List<Ticket> Tickets = new List<Ticket>();

        public int CreateTicket(Ticket ticket)
        {
            var currentHighestTicket = Tickets.Any() ? Tickets.Max(i => i.Id) : 0;
            var id = currentHighestTicket + 1;
            ticket.Id = id;

            Tickets.Add(ticket);

            return id;
        }

        public void UpdateTicket(Ticket ticket)
        {
            var outdatedTicket = Tickets.FirstOrDefault(t => t.Id == ticket.Id);

            if (outdatedTicket != null)
            {
                Tickets.Remove(outdatedTicket);
                Tickets.Add(ticket);
            }
        }

        public Ticket GetTicket(int id)
        {
            return Tickets.FirstOrDefault(a => a.Id == id);
        }
    }
}
