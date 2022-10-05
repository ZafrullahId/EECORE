using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Entites
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}