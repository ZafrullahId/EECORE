using EF_Core.Context;
using EF_Core.Entites;
using EF_Core.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Repositories
{
    public class FoodRepo
    {
        public readonly AppDbContext _context;
        public FoodRepo(AppDbContext context)
        {
            _context = context;
        }
         public bool Create(Food food)
        {
            if(food == null)
            {
                Console.WriteLine("Food cannot be null");
                return false;
            }
            _context.Foods.Add(food);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Food updatedFood)
        {
           _context.Foods. Update(updatedFood);
                _context.SaveChanges();
                return true;
        }
        public Food GetById(int id)
        {
            return _context.Foods
            . SingleOrDefault(x => x.Id == id);
        }
        public Food GetByPrice(decimal price)
        {
            return _context.Foods
            .SingleOrDefault(x => x.Price >= price);
        }
        public bool Delete(int foodId)
        {
            var food = _context.Foods
               .FirstOrDefault(x => x.Id == foodId);
            if (food == null)
            {
                Console.WriteLine("Customer is Null");
                return false;
            }
            _context.Foods.Remove(food);
            _context.SaveChanges();
            return true;
        }
        public List<Food> List()
        {
            return _context.Foods
                .ToList();
        }
       
    }
}