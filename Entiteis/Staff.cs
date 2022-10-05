using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Models.Enum;

namespace EF_Core.Entites
{
    public class Staff : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
    }
}