using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Models.Enum;

namespace EF_Core.Entites
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Wallet { get; set; }
        public Gender Gender { get; set; }
        public List<Order> Order { get; set; }
        // public List<Food> Foods { get; set; }
    }
}