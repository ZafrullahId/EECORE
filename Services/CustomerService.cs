using System;
using EF_Core.Models.Dto;
using EF_Core.Entites;
using EF_Core.Repositories;

namespace EF_Core.Services
{
    public class CustomerService
    {
        private readonly CustomerRepo _customerRepo;
        public CustomerService(CustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public void Register(CreateCustomerDto createCustomerDto)
        {
            var customer = new Customer()
            {
                 NextOfKin = createCustomerDto.NextOfKin,
                 DateOfBirth = createCustomerDto.DathOfBirth,
                 Wallet = 0.00m,
                 Gender = createCustomerDto.Gender,
                 CreatedAt = DateTime.Now,
                 User = new User()
                 {
                    FirstName = createCustomerDto.User.FirstName,
                    LastName = createCustomerDto.User.LastName,
                    Email = createCustomerDto.User.Email,
                    PhoneNumber = createCustomerDto.User.PhoneNumber,
                    Password = createCustomerDto.User.Password,
                    CreatedAt = DateTime.Now, 
                    Address = new Address()
                    {
                        CreatedAt = DateTime.Now,
                        City = createCustomerDto.User.City,
                        Country = createCustomerDto.User.Country,
                        Street = createCustomerDto.User.Street,
                        NumberLine = createCustomerDto.User.NumberLine,
                        PostalCode = createCustomerDto.User.PostalCode,
                        State = createCustomerDto.User.State
                    }
                 }
            };
            var response = _customerRepo.Create(customer);
            if(response)
            {
                Console.WriteLine("Customer created successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void UpdateWallet(string email,UpdateCustomerDto updateCustomerDto)
        {
            var customer = _customerRepo.GetByEmail(email);
            customer.Wallet += updateCustomerDto.Wallet;
            var response = _customerRepo.Update(customer);
            if(response)
            {
                Console.WriteLine("Customer Wallet Successfully updated...");
                Console.WriteLine($"Your wallet Balance is #{customer.Wallet}");
            }
            else
            {
                Console.WriteLine("Customer Wallet update failed...");
            }
        }
         public void WalletUdate(string email,UpdateCustomerDto updateCustomerDto)
        {
            var customer = _customerRepo.GetByEmail(email);
            customer.Wallet = updateCustomerDto.Wallet;
            var response = _customerRepo.Update(customer);
            if(response)
            {
                Console.WriteLine("Customer Wallet Successfully updated...");
                Console.WriteLine($"Your wallet Balance is #{customer.Wallet}");
            }
            else
            {
                Console.WriteLine("Customer Wallet update failed...");
            }
        }
        public void Edit(string email,UpdateCustomerDto updatedCustomerDto)
        {
            var customer = _customerRepo.GetByEmail(email);
            if(customer == null)
            {
                Console.WriteLine("Customer is null");
            }
            customer.NextOfKin = updatedCustomerDto.NextOfKin;
            customer.DateOfBirth = updatedCustomerDto.DathOfBirth;
            customer.Gender =updatedCustomerDto.Gender;
            customer.User.FirstName = updatedCustomerDto.User.FirstName;
            customer.User.LastName = updatedCustomerDto.User.LastName;
            customer.User.PhoneNumber = updatedCustomerDto.User.PhoneNumber;
            customer.User.Address.Street = updatedCustomerDto.User.City;
            customer.User.Address.PostalCode = updatedCustomerDto.User.PostalCode;
            customer.User.Address.City = updatedCustomerDto.User.City;
            customer.User.Address.State = updatedCustomerDto.User.State;
            customer.User.Address.Country = updatedCustomerDto.User.Country;
            customer.UpdatedAt = DateTime.Now;
            var response = _customerRepo.Update(customer);
            if(response)
            {
                Console.WriteLine("Customer Successfully updated...");
            }
            else
            {
                Console.WriteLine("Customer update failed...");
            }
        }
         public GetCustomerDto Find(string email,string password)
        {
            var customer = _customerRepo.GetByEmail(email);
            if(customer != null && customer.User.Password == password)
            {
                 return new GetCustomerDto()
            {
                NextOfKin = customer.NextOfKin,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                Wallet = customer.Wallet,
                User = new GetUserDto()
                {
                    Name = $"{customer.User.LastName} {customer.User.FirstName}",
                    Email = customer.User.Email,
                    PhoneNumber = customer.User.PhoneNumber,
                    City = customer.User.Address.City,
                    Country = customer.User.Address.Country,
                    State = customer.User.Address.State,
                    NumberLine = customer.User.Address.NumberLine,
                    PostalCode = customer.User.Address.PostalCode,
                    Street = customer.User.Address.Street
                }
            };
            }
            return null;
        }
        public List<GetCustomerDto> GetAll()
        {
            var customer = _customerRepo.List();
            return customer.Select(customer => new GetCustomerDto()
            {
                NextOfKin = customer.NextOfKin,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                User = new GetUserDto()
                {
                    Name = $"{customer.User.LastName} {customer.User.FirstName}",
                    Email = customer.User.Email,
                    PhoneNumber = customer.User.PhoneNumber,
                    City = customer.User.Address.City,
                    Country = customer.User.Address.Country,
                    State = customer.User.Address.State,
                    NumberLine = customer.User.Address.NumberLine,
                    PostalCode = customer.User.Address.PostalCode,
                    Street = customer.User.Address.Street
                }
            }).ToList();
        }
         public void Delete(string email)
        {
            var customer = _customerRepo.GetByEmail(email);
            if (customer == null)
            {
                Console.WriteLine($"Not User found with email {email}");
                return;
            }
            var response = _customerRepo.Delete(customer.User.Email);
            if (response)
            {
                Console.WriteLine("User Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }
        public GetCustomerDto CheckWallet(string email)
        {
            var customer = _customerRepo.GetByEmail(email);
            
           return new GetCustomerDto()
            {
                Wallet = customer.Wallet
            };
        }
         public void FundWallet(GetCustomerDto getCustomerDto)
        {
            Console.WriteLine("Enter amount");
            decimal amount = decimal.Parse(Console.ReadLine());
             var updateCustomerDto = new UpdateCustomerDto()
             {
                Wallet = amount,
             };
             UpdateWallet(getCustomerDto.User.Email, updateCustomerDto);
        }
        public Customer VeiwProfile(string email)
        {
           var customer =  _customerRepo.GetByEmail(email);
           return customer;
        }
        
    }
}
