using EF_Core.Context;
using EF_Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(User user)
        {
            if (user == null)
            {
                Console.WriteLine("User is Null");
                return false;
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool Update(User updatedUser)
        {
            _context.Update(updatedUser);
            _context.SaveChanges();
            return true;
        }

        public List<User> List()
        {
            return _context.Users
                .Include(u => u.Address)
                .ToList();
        }

        public User GetById(int UserId)
        {
            return _context.Users.Include(u => u.Address).Where(a => a.Id == UserId).SingleOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.Include(u => u.Address).Where(a => a.Email == email).FirstOrDefault();
        }

        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
