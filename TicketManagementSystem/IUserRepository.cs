using System;
using System.Threading.Tasks;
namespace TicketManagementSystem.Service.Repositories.Users.Interfaces
{
	public interface IUserRepository : IDisposable
    {
		 
			Task async<User> GetUser(string Username);

			Task async<User> GetAccountManager();
		 
	}
}