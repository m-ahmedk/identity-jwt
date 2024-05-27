using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace identity_jwt.Models
{
    public class AppUser : IdentityUser
    {
        /// ApplicationUser inherits the class IdentityUser to add fields FirstName & LastName to User's Identity table in DB
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }
    }
}
