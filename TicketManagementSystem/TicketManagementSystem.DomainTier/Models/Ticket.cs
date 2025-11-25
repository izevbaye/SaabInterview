using System;
using TicketManagementSystem.DomainTier.Accounts;
using TicketManagementSystem.DomainTier.eNums;
namespace TicketManagementSystem.DomainTier.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public string Description { get; set; }

        public User AssignedUser { get; set; }

        public User AccountManager { get; set; }

        public DateTime Created { get; set; }

        public bool IsPayingCustomer { get; set; }
    }
}
