using EF_Core.Context;
using Menu;

namespace Ef_Core
{
    public class Program
    {
        public static void Main(string [] args)
        {
           AppDbContext dbContext = new AppDbContext();

           MainMenu mainMenu = new MainMenu(dbContext);

           mainMenu.PrintMainMenu();
        }
    }
}