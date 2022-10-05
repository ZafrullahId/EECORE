using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Models.Enum;

namespace EF_Core.Models.Dto
{
    public class CreateCustomerDto
    {
        public CreateUserDto User { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DathOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
    public class UpdateCustomerDto
    {
        public UpdateUserDto User { get; set; }
        public string NextOfKin { get; set; }
        public decimal Wallet { get;set; }
        public DateTime DathOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
    public class GetCustomerDto
    {
        public GetUserDto User { get; set; }
        public decimal Wallet { get;set; }
        public string NextOfKin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}