using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 namespace EF_Core.Entites
 {
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }    
        public Customer Customer { get; set; }
        public List<Food> Food { get; set; }
    }
 }