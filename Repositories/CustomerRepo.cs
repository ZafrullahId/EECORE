using EF_Core.Context;
using EF_Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Repositories
{
    public class CustomerRepo
    {
        private readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool Create(Customer customer)
        {
            if(customer == null)
            {
                Console.WriteLine("Customer cannot be null");
                return false;
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Customer updatedCustomer)
        {
           _context.Customers.Update(updatedCustomer);
                _context.SaveChanges();
                return true;
        }
        public Customer GetById(int customerId)
        {
            return _context.Customers
            .Include(c => c.User)
            . SingleOrDefault(x => x.Id == customerId);
        }
        public Customer GetByEmail(string email)
        {
            return _context.Customers
            .Include(c => c.User.Address).Include(c => c.User)
            .SingleOrDefault(x => x.User.Email == email);
        }
        public bool Delete(string email)
        {
             var customer = _context.Users
               .Include(c => c.Address)
               .FirstOrDefault(x => x.Email == email);
            if (customer == null)
            {
                Console.WriteLine("Customer is Null");
                return false;
            }
            _context.Users.Remove(customer);
            _context.SaveChanges();
            return true;
        }
        public List<Customer> List()
        {
            return _context.Customers
                .Include(c => c.User)
                .ToList();
        }
    //     public List<Customer> DetailList()
    //    {
    //      return _context.Customers
    //      .Include(c => c.Foods)
    //      .Include(x => x.User).ToList();
    //    }
    }
}