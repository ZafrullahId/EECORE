using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Models.Enum;

namespace EF_Core.Entites
{
    public class Food : BaseEntity
    {
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int NumberOfPlates { get; set; }
        public Status Status { get; set; }
        public DateTime AvailableTime { get;set; }
        public List<Order> Orders { get;set; }
        // public List<Customer> customers { get; set; }
    }
}