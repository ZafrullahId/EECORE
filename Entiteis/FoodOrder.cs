using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Models.Enum;

namespace EF_Core.Entites
{
    public class FoodOrder : BaseEntity
    {
        public int FoodId { get;set; }
        public int OrderId { get;set; }
        public Food Food { get;set; }
        public Order order { get;set; }
    }
}