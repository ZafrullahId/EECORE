using EF_Core.Context;
using EF_Core.Entites;
using EF_Core.Models.Dto;
using EF_Core.Models.Enum;
using EF_Core.Repositories;
using EF_Core.Services;
using Ef_Core.Menus;

namespace Menu
{
    public class MainMenu
    {
        private readonly CustomerMenu customerMenu;
        private readonly StaffMenu staffMenu;
        public MainMenu(AppDbContext dbContext)
        {
            customerMenu = new CustomerMenu(dbContext);
            staffMenu = new StaffMenu(dbContext);
        }
        public void PrintMainMenu()
        {
            WelcomePage();
            Console.WriteLine("Enter 1 To Sign-In as Customer");
            Console.WriteLine("Enter 2 To Sign-In as Staff");
            Console.WriteLine("Enter 0 To Quit");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Option");
            }
            
            HandleMainMenu(option);
        }
        public void HandleMainMenu(int option)
        {
            switch (option)
            {
                case 1:
                  PrintCustomerMenu();
                    break;
                case 2:
                  PrintStaffenu();
                    break;
                case 0:
                break;
                default:
                  PrintMainMenu();
                    break;
            }
        }
        public void PrintCustomerMenu()
        {
            Console.WriteLine("Enter 1 To Create an Account");
            Console.WriteLine("Enter 2 To Log-In");
            Console.WriteLine("Enter 3 To Quit");
            Console.WriteLine("Enter 0 To MainMenu");
             int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Option");
            }
            HandleCustomerMenu(option);
        }
        public void HandleCustomerMenu(int option)
        {
            switch(option)
            {
                case 1:
                  customerMenu.Register();
                    break;
                case 2:
                  customerMenu.Login();
                    break;
                case 3:
                    break;
                case 0:
                    PrintMainMenu();
                      break;
            }
        }
         public void PrintStaffenu()
        {
            Console.WriteLine("Enter 1 To Log-In");
            Console.WriteLine("Enter 2 To Quit");
            Console.WriteLine("Enter 0 To MainMenu");
            int option;
            while(!int.TryParse(Console.ReadLine(),out option))
            {
                Console.WriteLine("Invalid Option");
            }
            HandleStaffenu(option);
        }
         public void HandleStaffenu(int option)
        {
            switch(option)
            {
                case 1:
                  staffMenu.Login();
                    break;
                case 2:
                    break;
                case 0:
                     PrintMainMenu();
                   break;
            }
        }
         public static void WelcomePage()
        {
          Console.WriteLine("==================================================");
          Console.WriteLine("## WELCOME #######################################");
          Console.WriteLine("====== TO ========================================");
          Console.WriteLine("########## CLH ###################################");
          Console.WriteLine("<<<<<<<<<<<< FOOD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
          Console.WriteLine("################## ODERING #######################");
          Console.WriteLine("======================== CONSOLE =================");
          Console.WriteLine("############################## APP ###############");
          Console.WriteLine("==================================================");
          
        }
    }
}