using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Models.Enum;

namespace EF_Core.Models.Dto
{
    public class CreateStaffDto
    {
        public CreateUserDto User { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DathOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
    }
    public class UpdateStaffDto
    {
        public UpdateUserDto User { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DathOfBirth { get; set; }
        public Role Role { get;set; }
        public Gender Gender { get; set; }
    }
    public class GetStaffDto
    {
        public GetUserDto User { get; set; }
        public bool isActive { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DathOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get;set; }
    }
}