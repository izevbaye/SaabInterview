using System.ComponentModel.DataAnnotations;

namespace TicketManagementSystem.DomainTier.Accounts
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
