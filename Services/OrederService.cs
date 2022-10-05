using System;
using EF_Core.Models.Dto;
using EF_Core.Entites;
using EF_Core.Repositories;
using EF_Core.Context;

namespace EF_Core.Services
{
    public class OrederService
    {
        private readonly OrderRepo _orderRepo;
        public OrederService(OrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public void CreateOrder(Order order)
        {
            var response = _orderRepo.Create(order);
            if(response)
            {
                Console.WriteLine("Order successfully created...");
            }
            else
            {
                Console.WriteLine("Order not created...");
            }
        }
        public void CreateFoodOrder(FoodOrder foodOrder)
        {
            var response = _orderRepo.Insert(foodOrder);
            if(response)
            {
                Console.WriteLine("FoodOrder successfully inserted");
            }
        }

    }
}