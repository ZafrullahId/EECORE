using System;
using EF_Core.Models.Dto;
using EF_Core.Entites;
using EF_Core.Repositories;
using EF_Core.Models.Enum;

namespace EF_Core.Services
{
    public class StaffService
    {
        private readonly StaffRepo _staffRepo;
        public StaffService(StaffRepo staffRepo)
        {
            _staffRepo = staffRepo;
        }
        public void Register(CreateStaffDto createStaffDto)
        {
            var staff = new Staff()
            {
                NextOfKin = createStaffDto.NextOfKin,
                DateOfBirth = createStaffDto.DathOfBirth,
                Gender = createStaffDto.Gender,
                Role = createStaffDto.Role,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                User = new User()
                {
                    FirstName = createStaffDto.User.FirstName,
                    LastName = createStaffDto.User.LastName,
                    Email = createStaffDto.User.Email,
                    PhoneNumber = createStaffDto.User.PhoneNumber,
                    Password = createStaffDto.User.Password,
                    Address = new Address()
                    {
                        CreatedAt = DateTime.Now,
                        PostalCode = createStaffDto.User.PostalCode,
                        NumberLine = createStaffDto.User.NumberLine,
                        Street = createStaffDto.User.Street,
                        City  = createStaffDto.User.City,
                        State = createStaffDto.User.State,
                        Country = createStaffDto.User.Country,
                    }
                }
            };
            var response = _staffRepo.Create(staff);
            if(response)
            {
                Console.WriteLine("Staff Added Successfully...");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }
        public void Edit(UpdateStaffDto updateStaffDto,int id)
        {
            var staff = _staffRepo.GetById(id);
            if(staff == null)
            {
                Console.WriteLine("Staff is Null");
            }
            updateStaffDto.NextOfKin = staff.NextOfKin;
            updateStaffDto.DathOfBirth = staff.DateOfBirth;
            updateStaffDto.Gender = staff.Gender;
            updateStaffDto.Role = staff.Role;
            updateStaffDto.User.FirstName = staff.User.FirstName;
            updateStaffDto.User.LastName = staff.User.LastName;
            updateStaffDto.User.PhoneNumber = staff.User.PhoneNumber;
            updateStaffDto.User.PostalCode = staff.User.Address.PostalCode;
            updateStaffDto.User.NumberLine = staff.User.Address.NumberLine;
            updateStaffDto.User.Street = staff.User.Address.Street;
            updateStaffDto.User.State = staff.User.Address.State;
            updateStaffDto.User.City = staff.User.Address.City;
            updateStaffDto.User.Country = staff.User.Address.Country;
            var response = _staffRepo.Update(staff);
             if(response)
            {
                Console.WriteLine("Customer Successfully updated...");
            }
            else
            {
                Console.WriteLine("Customer update failed...");
            }
        }
        public GetStaffDto FindByRole(Role role)
        {
            var staff = _staffRepo.GetByRole(role);
            return new GetStaffDto()
            {
                NextOfKin = staff.NextOfKin,
                DathOfBirth = staff.DateOfBirth,
                Gender = staff.Gender,
                User = new GetUserDto()
                {
                    Name = $"{staff.User.FirstName} {staff.User.LastName}",             
                    Email = staff.User.Email,
                    PhoneNumber = staff.User.PhoneNumber,
                    City = staff.User.Address.City,
                    Country = staff.User.Address.Country,
                    State = staff.User.Address.State,
                    NumberLine = staff.User.Address.NumberLine,
                    PostalCode = staff.User.Address.PostalCode,
                    Street = staff.User.Address.Street
                }
            };
        }
        public List<GetStaffDto> GetAll()
        {
             var staff = _staffRepo.List();
            return staff.Select(staff => new GetStaffDto()
            {
                NextOfKin = staff.NextOfKin,
                DathOfBirth = staff.DateOfBirth,
                Gender = staff.Gender,
                Role = staff.Role,
                User = new GetUserDto()
                {
                    Name = $"{staff.User.LastName} {staff.User.FirstName}",
                    Email = staff.User.Email,
                    PhoneNumber = staff.User.PhoneNumber,
                    City = staff.User.Address.City,
                    Country = staff.User.Address.Country,
                    State = staff.User.Address.State,
                    NumberLine = staff.User.Address.NumberLine,
                    PostalCode = staff.User.Address.PostalCode,
                    Street = staff.User.Address.Street
                }
            }).ToList();
        }
        public void PrintAllStaffs()
        {
            var staffDtos = GetAll();
            if (staffDtos == null)
            {
                Console.WriteLine("No Staff On This List");
            }
            foreach (var staff in staffDtos)
            {
                Console.WriteLine($"NAME: {staff.User.Name} \t PHONENUMBER: {staff.User.PhoneNumber} \t ROLE: {staff.Role} \t STATE: {staff.User.State} \t CITY: {staff.User.City} \t  POSTALCODE: {staff.User.PostalCode} \t STREET: {staff.User.Street}");
            }
        }
    }
}