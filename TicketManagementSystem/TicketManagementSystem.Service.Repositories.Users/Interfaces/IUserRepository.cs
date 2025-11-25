using System;
using System.Threading.Tasks;
using TicketManagementSystem.DomainTier.Accounts;
using TicketManagementSystem.DomainTier.Models;
namespace TicketManagementSystem.Service.Repositories.Users.Interfaces
{
	public interface IUserRepository : IDisposable
    {
		 
			Task<User> GetUser(string Username);

			Task<User> GetAccountManager();
		 
	}
}