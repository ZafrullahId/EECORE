using EF_Core.Context;
using EF_Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Repositories
{
    public class OrderRepo
    {
        private readonly AppDbContext _context;

        public OrderRepo(AppDbContext context)
        {
             _context = context;
        }
        public bool Create(Order order)
        {
            if(order == null)
            {
                Console.WriteLine("Oredr is null");
                return false;
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
            return true;
        }
        public bool Insert(FoodOrder foodOrder)
        {
            _context.foodOrder.Add(foodOrder);
            _context.SaveChanges();
            return true;
        }
    }
}