using System;
namespace TicketManagementSystem.DomainTier.ErrorHandler
{
    public class UnknownUserException : Exception
    {
        public UnknownUserException(string message) : base(message)
        {
        }
    }
}
