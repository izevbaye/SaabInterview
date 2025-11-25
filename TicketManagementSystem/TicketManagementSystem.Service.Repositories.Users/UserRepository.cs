using Microsoft.Data.SqlClient;
using System;
using System.Configuration;  // Add this using directive

using TicketManagementSystem.DomainTier.Accounts;
using TicketManagementSystem.DomainTier.Models;
using TicketManagementSystem.Service.Repositories.Users.Interfaces;

namespace TicketManagementSystem.Service.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private SqlConnection connection;
        
        public UserRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["database"].ConnectionString; 
            connection = new SqlConnection(connectionString);
        }
        
        public async Task<User> GetUser(string username)
        {
            // Assume this method does not need to change and is connected to a database with users populated.
            try
            {
                string sql = "SELECT TOP 1 FROM Users u WHERE u.Username == @p1";
                connection.Open();

                var command = new SqlCommand(sql, connection)
                {
                    CommandType = System.Data.CommandType.Text,
                };

                command.Parameters.Add("@p1", System.Data.SqlDbType.NVarChar).Value = username;

                return (User)command.ExecuteScalar();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public async Task<User> GetAccountManager()
        {
            // Assume this method does not need to change.
            return await GetUser("Sarah");
        }

        public void Dispose()
        {
            // Assume this method does not need to change.
            connection.Dispose();
        }
    }
}
