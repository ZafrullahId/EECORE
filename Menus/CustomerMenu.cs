using EF_Core.Context;
using EF_Core.Entites;
using EF_Core.Models.Dto;
using EF_Core.Models.Enum;
using EF_Core.Repositories;
using EF_Core.Services;

namespace Ef_Core.Menus
{
    public class CustomerMenu
    {
        private readonly CustomerService _customerService;
        private readonly CustomerRepo _repositories;
        private readonly FoodRepo _foodRepo;
        private readonly FoodService _foodService;
        private readonly OrderMenu _orderMenu;
        public CustomerMenu(AppDbContext context)
        {
            _repositories = new CustomerRepo(context);
            _customerService = new CustomerService(_repositories);
            _foodRepo = new FoodRepo(context);
            _foodService = new FoodService(_foodRepo);
            _orderMenu = new OrderMenu(context);
        }
         public void Register()
        {
            Console.WriteLine("Register User Here: ");
            Console.WriteLine("Enter Your First Name: ");
            var first_name = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name: ");
            var last_name = Console.ReadLine();
            Console.WriteLine("Enter Your Email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number: ");
            var phone_number = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            var password = Console.ReadLine();
            var gender = GetGender();
            Console.WriteLine("Enter Your Number Line");
            var numberLine = Console.ReadLine();
            Console.WriteLine("Enter Your Street: ");
            var street = Console.ReadLine();
            Console.WriteLine("Enter Your State: ");
            var state = Console.ReadLine();
            Console.WriteLine("Enter Your City: ");
            var city = Console.ReadLine();
            Console.WriteLine("Enter Your Country: ");
            var country = Console.ReadLine();
            Console.WriteLine("Enter Your Postal Code: ");
            var posatal_code = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date of Birth");
            var dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Next of kin Name");
            var nextOfKin = Console.ReadLine();
            var customerDto = new CreateCustomerDto()
            {
                User = new CreateUserDto
                {
                    FirstName = first_name,
                    LastName = last_name,
                    Email = email,
                    PhoneNumber = phone_number,
                    Password = password,
                    NumberLine = numberLine,
                    Street = street,
                    State = street,
                    City = city,
                    Country = country,
                    PostalCode = posatal_code
                },
                DathOfBirth = dob,
                Gender = gender,
                NextOfKin = nextOfKin,
            };
            _customerService.Register(customerDto);
            Login();
        }
        
         public static Gender GetGender()
        {
            Console.WriteLine("Enter 1 For Male \nEnter 2 For Female \nEnter 3 For Others");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Input");
            }
            if (option == 1)
            {
                return Gender.Male;
            }
            else if(option == 2)
            {
                return Gender.Female;
            }
            else 
            {
                return Gender.Others;
            }       
        }
        public void Login()
        {
            Console.WriteLine("Enter Your E-mail");
            string email =  Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            string password = Console.ReadLine();
            var customer = _customerService.Find(email,password);
            if(customer == null)
            {
                Console.WriteLine("Account not found");
                Login();
            }
            else if(customer != null && customer.User.Email == email)
            {
                Console.WriteLine("Log-In successfully...");
                Console.Beep();
                CustomerSubMenu(customer);
            }
        }
        public void CustomerSubMenu(GetCustomerDto getCustomerDto)
        {
            Console.WriteLine("Enter 1 To Check All Available Foods");
            Console.WriteLine("Enter 2 To Check Processing Foods");
            Console.WriteLine("Enter 3 To Check All Not Available Foods");
            Console.WriteLine("Enter 4 To Check Wallet");
            Console.WriteLine("Enter 5 To Fund Wallet");
            Console.WriteLine("Enter 6 To Start Order");
            Console.WriteLine("Enter 7 To Update Profile");
            Console.WriteLine("Enter 8 To Delete Account");
            Console.WriteLine("Enter 9 To View Profile");
            int option;
             while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Option");
            }
             switch(option)
            {
                case 1:
                  _foodService.GetAllAvailableFood();
                  Case2(getCustomerDto);
                    break;
                case 2:
                  _foodService.GetAllProcessingFood();
                   Case2(getCustomerDto);
                    break;
                case 3:
                  _foodService.GetAllNotAvailableFood();
                   Case2(getCustomerDto);
                    break;
                case 4:
                 WalletBalance(getCustomerDto);
                  Case2(getCustomerDto);
                    break;
                case 5:
                    _customerService.FundWallet(getCustomerDto);
                     Case2(getCustomerDto);
                    break;
                case 6:
                _orderMenu.Order(getCustomerDto);
                 Case2(getCustomerDto);
                    break;
                case 7:
                    break;
                case 8:
                   DeleteAcct(getCustomerDto);
                    break; 
                case 9:
                    Profile(getCustomerDto);
                    Case2(getCustomerDto);
                    break;
                default:
                    CustomerSubMenu(getCustomerDto);
                    break;
            }
        }        
        public void DeleteAcct(GetCustomerDto getCustomerDto)
        {
            Console.WriteLine("Are you Sure you want to delete your Account");
            Console.WriteLine("Enter 1 For Yes\nEnter 2 For No");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Option");
            }
            switch(option)
            {
                case 1:
                  _customerService.Delete(getCustomerDto.User.Email);
                  break;
                case 2:
                  break;
                default:
                  DeleteAcct(getCustomerDto);
                   break;
            }
        }
        public void WalletBalance(GetCustomerDto getCustomerDto)
        {
            var wallet = _customerService.CheckWallet(getCustomerDto.User.Email);
            Console.WriteLine($"Your Wallet Balance is #{getCustomerDto.Wallet}");
        }
        public void Case2(GetCustomerDto getCustomerDto)
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
                  CustomerSubMenu(getCustomerDto);
                     break;
                case 1:
                     break;
                default:
                  Case2(getCustomerDto);
                    break;
            }
        }
        public void Profile(GetCustomerDto getCustomerDto)
        {
            var customer = _customerService.VeiwProfile(getCustomerDto.User.Email);
            Console.WriteLine($"THIS IS YOUR PROFILE NAME: {customer.User.FirstName} {customer.User.LastName}");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"FIRSTNAME: {customer.User.FirstName}");
            Console.WriteLine($"LASTNAME: {customer.User.LastName}");
            Console.WriteLine($"EMAIL: {customer.User.Email}");
            Console.WriteLine($"WALLET: {customer.Wallet}");
            Console.WriteLine($"PHONENUMBER: {customer.User.PhoneNumber}");
            Console.WriteLine($"COUNTRY: {customer.User.Address.Country}");
            Console.WriteLine($"STATE: {customer.User.Address.State}");
            Console.WriteLine($"CITY: {customer.User.Address.City}");
            Console.WriteLine($"NUMBERLINE: {customer.User.Address.NumberLine}");
            Console.WriteLine($"POSTALCODE: {customer.User.Address.PostalCode}");
            Console.WriteLine("----------------------------------------------------------");
        }
         public void UpdateProfile(GetCustomerDto getCustomerDto)
        {
            var customer = _customerService.VeiwProfile(getCustomerDto.User.Email);
            Console.WriteLine($"THIS IS YOUR PROFILE NAME: {customer.User.FirstName} {customer.User.LastName}");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"1. FIRSTNAME: {customer.User.FirstName}");
            Console.WriteLine($"2. LASTNAME: {customer.User.LastName}");
            Console.WriteLine($"3. PHONENUMBER: {customer.User.PhoneNumber}");
            Console.WriteLine($"4. COUNTRY: {customer.User.Address.Country}");
            Console.WriteLine($"5. STATE: {customer.User.Address.State}");
            Console.WriteLine($"6. CITY: {customer.User.Address.City}");
            Console.WriteLine($"7. NUMBERLINE: {customer.User.Address.NumberLine}");
            Console.WriteLine($"8. POSTALCODE: {customer.User.Address.PostalCode}");
            Console.WriteLine("----------------------------------------------------------");
            int option;
            while (!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Option");
            }
            HandleUpdateProfile(option);
        }
        public void HandleUpdateProfile(int option)
        {
            switch (option)
            {
                case 1:
                break;
                case 2:
                break;
                case 3:
                break;
                case 4:
                break;
                case 5:
                break;
                default:
                break;
            }
        }
    }
}