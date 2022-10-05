using EF_Core.Models.Dto;
using EF_Core.Entites;
using EF_Core.Repositories;
using EF_Core.Models.Enum;
// using EF_Core.Models.Enum;

namespace EF_Core.Services
{
    public class FoodService
    {
        private readonly FoodRepo _foodRepo;
        public FoodService(FoodRepo foodRepo)
        {
            _foodRepo = foodRepo;
        }
        public void Add(Food food)
        {
           var response = _foodRepo.Create(food);
           if(response)
           {
             Console.WriteLine("Food added successfully...");
           }
           else
           {
             Console.WriteLine("Food not added");
           }
        }
        public void UpdateFood(Food updatedfood,int id)
        {
            var food = _foodRepo.GetById(id);
            if(food == null)
            {
                Console.WriteLine("Food not on List");
            }     
                food.Type = updatedfood.Type;
                food.Price = updatedfood.Price;
                food.NumberOfPlates = updatedfood.NumberOfPlates;
                food.Status = updatedfood.Status;
                food.UpdatedAt = updatedfood.UpdatedAt;
                food.AvailableTime = updatedfood.AvailableTime;
            var response = _foodRepo.Update(food);
            if (response)
            {
                Console.WriteLine("Food Updated successfully...");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
         public void updateNumberOfPlates(Food updatefood,int id)
        {
            var food = _foodRepo.GetById(id);
            food.NumberOfPlates = updatefood.NumberOfPlates;
            var response = _foodRepo.Update(food);
             if (response)
            {
                Console.WriteLine("Food Updated successfully...");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void DeleteFood(int foodId)
        {
            var response = _foodRepo.Delete(foodId);
            if(response)
            {
                Console.WriteLine("Food deleted successfully...");
            }
            else
            {
                Console.WriteLine("Something went wrong...");
            }
        }
        public void GetAllFood()
        {
            var foods = _foodRepo.List();
            if(foods == null)
            {
                Console.WriteLine("No Food is Available at the moment");
            }
            foreach (var food in foods)
            {
                Console.WriteLine($"ID: {food.Id} \t TYPE: {food.Type} \t PRICE PER PLATE: {food.Price} \t AVAILABLE TIME: {food.AvailableTime}");
            }
        }
        public void GetAllProcessingFood()
        {
             var foods = _foodRepo.List();
              foreach (var food in foods)
            {
                if(food.AvailableTime > DateTime.Now)
                {
                   Console.WriteLine($"ID: {food.Id} \t TYPE: {food.Type} \t PRICE PER PLATE: {food.Price} \t STATUS: {food.Status} \t AVAILABLE TIME: {food.AvailableTime}");
                }
                 else
                 {
                   continue;
                 }
            }
        }
        public void GetAllAvailableFood()
        {
             var foods = _foodRepo.List();
             foreach (var food in foods)
            {
                if( DateTime.Now > food.AvailableTime && food.Status != Status.NotAvailable)
                {
                   Console.WriteLine($"ID: {food.Id} \t TYPE: {food.Type} \t PRICE PER PLATE: {food.Price} \t AVAILABLE TIME: {food.AvailableTime}");
                }
               else
               {
                continue;
               }
            }
        }
        public void GetAllNotAvailableFood()
        {
             var foods = _foodRepo.List();
              foreach (var food in foods)
            {
                if(food.Status == Status.NotAvailable)
                {
                   Console.WriteLine($"ID: {food.Id} \t TYPE: {food.Type} \t PRICE PER PLATE: {food.Price} \t STATUS: {food.Status} \t AVAILABLE TIME: {food.AvailableTime}");
                }
                else
                {
                 continue;
                }
            }
        }
    }
}