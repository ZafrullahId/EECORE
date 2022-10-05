using EF_Core.Context;
using EF_Core.Entites;
using EF_Core.Models.Dto;
using EF_Core.Models.Enum;
using EF_Core.Repositories;
using EF_Core.Services;

namespace Ef_Core.Menus
{
    public class StaffMenu
    {
        private readonly StaffRepo _staffRepo;
        private readonly StaffService _staffServices;
        private readonly CustomerMenu customerMenu;
        private readonly FoodMenu foodMenu;
        private readonly FoodService _foodServise;
         private readonly FoodRepo _foodRepo;
        public StaffMenu(AppDbContext dbContext)
        {
            _staffRepo = new StaffRepo(dbContext);
            _staffServices = new StaffService(_staffRepo);
            foodMenu = new FoodMenu(dbContext);
            _foodRepo = new FoodRepo(dbContext);
            _foodServise = new FoodService(_foodRepo);
        }
        public void AddStaff()
        {
            Console.WriteLine("Enter Staff First Name");
            string first_name = Console.ReadLine();
            Console.WriteLine("Enter Staff Last Name");
            string last_name = Console.ReadLine();
            Console.WriteLine("Enter Staff E-mail Address");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Staff Phone number");
            string phone_number = Console.ReadLine();
            Console.WriteLine("Enter Staff Password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Enter Staff Gender: ");
            var gender = CustomerMenu.GetGender();
            Console.WriteLine("Enter Staff Role: ");
            var role = GetRole();
            Console.WriteLine("Enter Staff Number Line");
            var numberLine = Console.ReadLine();
            Console.WriteLine("Enter Staff Street: ");
            var street = Console.ReadLine();
            Console.WriteLine("Enter Staff State: ");
            var state = Console.ReadLine();
            Console.WriteLine("Enter Staff City: ");
            var city = Console.ReadLine();
            Console.WriteLine("Enter Staff Country: ");
            var country = Console.ReadLine();
            Console.WriteLine("Enter Staff Postal Code: ");
            var posatal_code = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date of Birth");
            var dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Next of kin Name");
            var nextOfKin = Console.ReadLine();
            var createStaffDto = new CreateStaffDto()
            {
                User = new CreateUserDto()
                {
                    FirstName = first_name,
                    LastName = last_name,
                    Email = email,
                    PhoneNumber = phone_number,
                    Password = password,
                    NumberLine = numberLine,
                    Street = street,
                    State =state,
                    City = city,
                    Country = country,
                    PostalCode = posatal_code,
                },
                NextOfKin = nextOfKin,
                DathOfBirth = dob,
                Role = role,
                Gender = gender,
            };
            _staffServices.Register(createStaffDto);
            AddStaffSubMenu();
        }
        public Role GetRole()
        {
            Console.WriteLine("Enter 1 For Admin \n2 For Cook \n3 For Cleaner \n4 For Transporter");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Input");
            }
           if (option == 1)
           {
            return Role.Admin;
           }
           else if (option == 2)
           {
            return Role.Cook;
           }
           else if (option == 3)
           {
            return Role.Cleaner;
           }
           else
           {
            return Role.Transporter;
           }
        }
        public void Login()
        {
            Console.WriteLine("Enter Your E-mail");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string password = Console.ReadLine();
            var staff = _staffRepo.GetByEmail(email);
             if(staff == null)
            {
                Console.WriteLine("Account not found");
                Login();
            }
            else if(staff != null && staff.User.Email == email && staff.User.Password == password && staff.Role == Role.Admin)
            {
                Console.WriteLine("Log-In successfully... (ADMIN)");
                Console.Beep();
                AdminSubMenu();
            }
             else if(staff != null && staff.User.Email == email && staff.User.Password == password && staff.Role == Role.Cook)
            {
                Console.WriteLine("Log-In successfully... (COOK)");
                Console.Beep();
            }
            else
            {
                Console.WriteLine("Acount not found");
                Login();
            }
        }
        public void AdminSubMenu()
        {
            Console.WriteLine("Enter 1 To Add new Staff");
            Console.WriteLine("Enter 2 To Check all Staff Details");
            Console.WriteLine("Enter 3 To Add new Food");
            Console.WriteLine("Enter 4 To Update Food");
            Console.WriteLine("Enter 5 To Remove Food from List");
            Console.WriteLine("Enter 6 To Get Food Details");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Option");
            }
            HandleAdminSubMenu(option);
        }
        public void HandleAdminSubMenu(int option)
        {
            switch (option)
            {
                case 1:
                 AddStaff();
                     break;
                case 2:
                    _staffServices.PrintAllStaffs();
                    Case2();
                      break;
                case 3:
                  foodMenu.AddFood();
                  Case2();
                    break;
                case 4:
                   foodMenu.UpdateFood();
                   Case2();
                    break;
                case 5:
                  foodMenu.DeleteFood();
                  Case2();
                   break;
                case 6:
                    _foodServise.GetAllFood();
                    Case2();
                    break;
                default:
                    AdminSubMenu();
                    break;

            } 
        }
         public void AddStaffSubMenu()
         {
            System.Console.WriteLine("Do you like to add another Staff");
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
                   AddStaff();
                break;
                case 2:
                    Case2();
                    break;
            }
         }
        public void Case2()
        {
            Console.WriteLine("Enter 0 Back To Previous Menu");
            Console.WriteLine("Enter 1 Quit");
            int option;
             while (!int.TryParse(Console.ReadLine(),out option))
            {
                System.Console.WriteLine("Invalid Option");
            }
            switch (option)
            {
                case 0:
                  AdminSubMenu();
                     break;
                case 1:
                     break;
                default:
                  Case2();
                    break;
            }
        }
    }
}