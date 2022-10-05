using EF_Core.Context;
using EF_Core.Entites;
using EF_Core.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Repositories
{
    public class StaffRepo
    {
        private readonly AppDbContext _context;
        public StaffRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool Create(Staff staff)
        {
            if(staff == null)
            {
                Console.WriteLine("Customer cannot be null");
                return false;
            }
            _context.Staffs.Add(staff);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Staff updatedstaff)
        {
           _context.Staffs.Update(updatedstaff);
                _context.SaveChanges();
                return true;
        }
        public Staff GetById(int staffId)
        {
            return _context.Staffs
            .Include(c => c.User)
            . SingleOrDefault(x => x.Id == staffId);
        }
        public Staff GetByEmail(string email)
        {
            return _context.Staffs
            .Include(c => c.User.Address).Include(x => x.User)
            .SingleOrDefault(x => x.User.Email == email);
        }
        public Staff GetByRole(Role role)
        {
            return _context.Staffs
            .Include(c => c.User)
            .SingleOrDefault(x => x.Role == role);
        }
        public bool Delete(int staffId)
        {
            var staff = _context.Staffs
               .FirstOrDefault(x => x.Id == staffId);
            if (staff == null)
            {
                Console.WriteLine("Staff is Null");
                return false;
            }
            _context.Staffs.Remove(staff);
            _context.SaveChanges();
            return true;
        }
        public List<Staff> List()
        {
            return _context.Staffs
                .Include(c => c.User)
                .ToList();
        }
    }
}