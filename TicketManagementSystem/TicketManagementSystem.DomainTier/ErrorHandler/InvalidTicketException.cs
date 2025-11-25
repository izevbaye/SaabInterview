using System;
namespace TicketManagementSystem.DomainTier.ErrorHandler
{
    public class InvalidTicketException : Exception
    {
        public InvalidTicketException(string message) : base(message)
        {
        }
    }
}
