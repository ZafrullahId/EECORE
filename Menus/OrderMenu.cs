using EF_Core.Context;
using EF_Core.Entites;
using EF_Core.Models.Dto;
using EF_Core.Models.Enum;
using EF_Core.Repositories;
using EF_Core.Services;

namespace Ef_Core.Menus
{
    public class OrderMenu
    {
        private readonly FoodService _foodService;
        private readonly FoodRepo _foodRepo;
         private readonly CustomerService _customerService;
        private readonly CustomerRepo _repositories;
        private readonly OrederService _orderService;
        private readonly OrderRepo _orderRepo;
        public OrderMenu(AppDbContext DbContext)
        {
            _foodRepo = new FoodRepo(DbContext);
            _foodService = new FoodService(_foodRepo);
             _repositories = new CustomerRepo(DbContext);
            _customerService = new CustomerService(_repositories);
            _orderRepo = new OrderRepo(DbContext);
            _orderService = new OrederService(_orderRepo);
        }
        decimal TotalAmount = 0.00m;
        int choosedId;
        public List<Food> foods = new List<Food>();    
        public void Order(GetCustomerDto getCustomerDto)
        {
            _foodService.GetAllFood();
            Console.WriteLine("Please choose by number");
             
            while (!int.TryParse(Console.ReadLine(), out choosedId))
            {
                Console.WriteLine("Enter a valid option");
            }
            var food = _foodRepo.GetById(choosedId);
            if (food == null)
            {
                Console.WriteLine("Food not on List");
                Order(getCustomerDto);
            }
            if(food.AvailableTime > DateTime.Now || food.Status == Status.NotAvailable)
            {
                Console.WriteLine("Food not Available at the Moment");
                Order(getCustomerDto);
            }
            if(food.NumberOfPlates == 0)
            {
                 Console.WriteLine("Food not Available at the Moment");
                Order(getCustomerDto);
            }
            Console.WriteLine("Enter Quantity (Number Of Plates)");
            int quantity;
             while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            Console.WriteLine("Do you Like to Order Another Food");
            Console.WriteLine("Enter 1 For YES");
            Console.WriteLine("Enter 2 For NO");
            TotalAmount += food.Price * quantity;
            food.NumberOfPlates -= quantity;        
            int option;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input. Try again");
            }
            switch(option)
            {
                case 1:
                 foods.Add(food);
                  Order(getCustomerDto);
                    break;
                case 2:
                   foods.Add(food);
                   Console.WriteLine($"Total amount is #{TotalAmount}");
                   Quest(getCustomerDto);
                   var food1 = new Food()
                 {
                    NumberOfPlates = food.NumberOfPlates,
                 };
                 _foodService.updateNumberOfPlates(food1,choosedId);
                break;
            }
                
        }
        public void Quest(GetCustomerDto getCustomerDto)
        {      
            Console.WriteLine("Enter 1 To Proceed");
            Console.WriteLine("Enter 2 To View cart");
            Console.WriteLine("Enter 3 To Cancel Order");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Option");
            }
           switch(option)
            {
                case 1:
                Payment(getCustomerDto);
                    break;
                case 2:
                ViewCart(getCustomerDto);
                    break;
                    case 3:
                break;
                default:
                   break;
            }
        }
        public void Payment(GetCustomerDto getCustomerDto)
        {
            if(getCustomerDto.Wallet < TotalAmount)
            {
                  Console.WriteLine("Insuficient funds. \nEnter 1 to fund wallet.\nEnter 0 to Cancel order");
                  int option;
                  while(!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input. Try again");
                }
                 switch(option)
               {
                case 1:
                  _customerService.FundWallet(getCustomerDto);
                   var customer = _customerService.CheckWallet(getCustomerDto.User.Email);
                   getCustomerDto.Wallet = customer.Wallet;
                 Quest(getCustomerDto);
                    break;
                case 0:
                 TotalAmount = 0.00m;
                    break;
                default:
                Payment(getCustomerDto);
                   break;
               }
            }
            else
            {
                 var customer = _customerService.CheckWallet(getCustomerDto.User.Email);
                 customer.Wallet -= TotalAmount;
                 var updateCustomerDto = new UpdateCustomerDto()
                 {
                    Wallet = customer.Wallet
                 };
                 _customerService.WalletUdate(getCustomerDto.User.Email,updateCustomerDto);
                 Console.WriteLine($"Thank you for Your Patronage Your wallet balance is #{customer.Wallet}");
                 TotalAmount = 0.00m;
                 var customer1 = _repositories.GetByEmail(getCustomerDto.User.Email);
                 var order = new Order()
                 {
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CustomerId = customer1.Id
                 };
                 _orderService.CreateOrder(order);
                 var foodOrder = new FoodOrder()
                 {
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    FoodId = choosedId,
                    OrderId = order.Id,
                 };
                 _orderService.CreateFoodOrder(foodOrder);
            }         
        }
         public void ViewCart(GetCustomerDto getCustomerDto)
        {
            foreach (var food in foods)
            {
                Console.WriteLine($"ID: {food.Id} \t TYPE: {food.Type} \t PRICE: {food.Price}");
            }
            Quest(getCustomerDto);
        }
        
    }
}