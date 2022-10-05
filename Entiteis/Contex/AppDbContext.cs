using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace EF_Core.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server = localhost;user = root;database = EfCoreConsoleApp;port = 3306;password = zafuolobeyo1@");
        }
        public DbSet<Customer>Customers {get;set;}
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FoodOrder> foodOrder { get;set; }
        
    }
}