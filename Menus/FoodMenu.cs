using EF_Core.Context;
using EF_Core.Entites;
using EF_Core.Models.Dto;
using EF_Core.Models.Enum;
using EF_Core.Repositories;
using EF_Core.Services;

namespace Ef_Core.Menus
{
    public class FoodMenu
    {
         private readonly CustomerService _customerService;
         private readonly CustomerRepo _customerRepositories;
         private readonly StaffService _staffServices;
         private readonly StaffRepo _staffRepo;
         private readonly FoodService _foodServise;
         private readonly FoodRepo _foodRepo;
         public FoodMenu(AppDbContext DbContext)
         {
            _customerRepositories = new CustomerRepo(DbContext);
            _customerService = new CustomerService(_customerRepositories);
            _staffRepo = new StaffRepo(DbContext);
            _staffServices = new StaffService(_staffRepo);
            _foodRepo = new FoodRepo(DbContext);
            _foodServise = new FoodService(_foodRepo);
         }
         public void AddFood()
         {
            Console.WriteLine("Enter Food Type");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Price");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number Of Available Plates");
            int availablePlates = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Available Time Of Food (YYYY-MM-DD hh:mm:ss)");
            DateTime availableTime;
            while(!DateTime.TryParse(Console.ReadLine(),out availableTime))
            {
                Console.WriteLine("Invalid DateTime");
            }
            Console.WriteLine("Enter Food Status");
            var status = GetStatus();
            var food = new Food()
            {
              Type = type,
              Price = price,
              NumberOfPlates = availablePlates,
              Status = status,
              AvailableTime = availableTime,
              CreatedAt = DateTime.Now,
              UpdatedAt = DateTime.Now,
            };
            _foodServise.Add(food);
            AddFoodSubMenu();
         }
         public void DeleteFood()
         {
            _foodServise.GetAllFood();
            Console.WriteLine("Enter Food ID to be Deleted");
             int option;
             while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Input");
            }
            _foodServise.DeleteFood(option);
         }
         public Status GetStatus()
         {
            Console.WriteLine("Enter 1 For Available");
            Console.WriteLine("Enter 2 For Processing");
            Console.WriteLine("Enter 3 For Not Available");
             int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Input");
            }
            if (option == 1)
            {
                return Status.Available;
            }
            else if(option == 2)
            {
                return Status.Processing;
            }
            else 
            {
                return Status.NotAvailable;
            }       
         }
         public void UpdateFood()
         {
             _foodServise.GetAllFood();
            Console.WriteLine("Enter Food ID To be Updated");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Food Type");
            string updatedtype = Console.ReadLine();
            Console.WriteLine("Enter Price");
            decimal updatedprice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number Of Available Plates");
            int updatedavailablePlates = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Available Time Of Food (YYYY-MM-DD-hh-mm-ss)");
            DateTime availableTime;
            while(!DateTime.TryParse(Console.ReadLine(),out availableTime))
            {
                Console.WriteLine("Invalid DateTime");
            }
            Console.WriteLine("Enter Food Status");
            var updatedstatus = GetStatus();
            var updatedFood = new Food()
            {
                Type = updatedtype,
                Price = updatedprice,
                NumberOfPlates = updatedavailablePlates,
                Status = updatedstatus,
                AvailableTime = availableTime,
                UpdatedAt = DateTime.Now,
            };
            _foodServise.UpdateFood(updatedFood,id);
            UpdateFoodSubMenu();
         }
         public void UpdateFoodSubMenu()
         {
            System.Console.WriteLine("Do you like to update another food");
            System.Console.WriteLine("Enter 1 For YES");
            System.Console.WriteLine("Enter 2 For NO");
            int opt;
            while (!int.TryParse(Console.ReadLine(),out opt))
            {
                System.Console.WriteLine("Invalid Option");
            }
            switch(opt)
            {
                case 1:
                   UpdateFood();
                break;
                case 2:
                    break;
            }
         }
          public void AddFoodSubMenu()
         {
            System.Console.WriteLine("Do you like to add another food");
            System.Console.WriteLine("Enter 1 For YES");
            System.Console.WriteLine("Enter 2 For NO");
            int opt;
            while (!int.TryParse(Console.ReadLine(),out opt))
            {
                System.Console.WriteLine("Invalid Option");
            }
            switch(opt)
            {
                case 1:
                   AddFood();
                break;
                case 2:
                    break;
            }
         }
    }
}