using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace identity_jwt.Models
{
    public class AppUser : IdentityUser
    {
        /// ApplicationUser inherits the class IdentityUser to add fields FirstName & LastName to User's Identity table in DB
        [MaxLength(200)]
        public string? FirstName { get; set; }

        [MaxLength(200)]
        public string? LastName { get; set; }
    }
}
