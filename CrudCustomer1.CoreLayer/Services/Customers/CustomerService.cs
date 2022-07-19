using System;
using System.Linq;
using CrudCustomer1.CoreLayer.DTOs.Customers;
using CrudCustomer1.CoreLayer.Utilities;
using CrudCustomer1.DataLayer.Context;
using CrudCustomer1.DataLayer.Entities;
using System.Collections.Generic;

namespace CrudCustomer1.CoreLayer.Services.Customers
{

    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _context;
        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public OperationResult CreateCustomer(CustomerDto RegCustomerDto)
        {
            var isUserNameExist = _context.Customers.Any(u =>
           u.Firstname == RegCustomerDto.Firstname
           && u.Lastname == RegCustomerDto.Lastname
           && u.DateOfBirth == RegCustomerDto.DateOfBirth);

            if (isUserNameExist)
                return OperationResult.Error("Duplicate username");
          
            isUserNameExist = _context.Customers.Any(u =>u.Email == RegCustomerDto.Email);
            if (isUserNameExist)
                return OperationResult.Error("Duplicate username");
         
            _context.Customers.Add(new Customer()
            {
                Firstname = RegCustomerDto.Firstname,
                Lastname = RegCustomerDto.Lastname,
                DateOfBirth = RegCustomerDto.DateOfBirth,
                PhoneNumber = RegCustomerDto.PhoneNumber,
                Email = RegCustomerDto.Email,
                BankAccountNumber = RegCustomerDto.BankAccountNumber
            });
            _context.SaveChanges();
            return OperationResult.Success();
        }
        public List<CustomerDto> ReadCustomer()
        { 
            var customerSet = _context.Set<Customer>().ToList();
            List<CustomerDto> RegCustomerDto = new List<CustomerDto>(); 

            for (int i = 0; i < customerSet.Count; i++)
            {
                RegCustomerDto.Add(new CustomerDto()
                {
                    Firstname = customerSet[i].Firstname,
                    Lastname = customerSet[i].Lastname,
                    DateOfBirth = customerSet[i].DateOfBirth,
                    PhoneNumber = customerSet[i].PhoneNumber,
                    Email = customerSet[i].Email,
                    BankAccountNumber = customerSet[i].BankAccountNumber
                });
            } 
            return RegCustomerDto;
        }
        public CustomerDto FindACustomer(int id)
        {
            var customerSet = _context.Set<Customer>().ToList();  
            CustomerDto RegCustomerDto =new CustomerDto()
                {
                    Firstname = customerSet[id].Firstname,
                    Lastname = customerSet[id].Lastname,
                    DateOfBirth = customerSet[id].DateOfBirth,
                    PhoneNumber = customerSet[id].PhoneNumber,
                    Email = customerSet[id].Email,
                    BankAccountNumber = customerSet[id].BankAccountNumber
                }; 

            // var RegCustomerDto = _context.Customers.ToList();
            return RegCustomerDto;
        }
        public OperationResult EditCustomer(CustomerDto pickedCustomer, int id)
        {
            var isUserNameExist = _context.Customers.Any(u =>
         u.Firstname == pickedCustomer.Firstname
         && u.Lastname == pickedCustomer.Lastname
         && u.DateOfBirth == pickedCustomer.DateOfBirth);

            if (isUserNameExist)
                return OperationResult.Error("Duplicate username");

            isUserNameExist = _context.Customers.Any(u => u.Email == pickedCustomer.Email);
            if (isUserNameExist)
                return OperationResult.Error("Duplicate username");


            var customerSet = _context.Set<Customer>().ToList();
            customerSet[id].Firstname =   pickedCustomer.Firstname;
            customerSet[id].Lastname =   pickedCustomer.Lastname;
            customerSet[id].DateOfBirth =   pickedCustomer.DateOfBirth;
            customerSet[id].PhoneNumber =  pickedCustomer.PhoneNumber;
            customerSet[id].Email =  pickedCustomer.Email;
            customerSet[id].BankAccountNumber =  pickedCustomer.BankAccountNumber;

            _context.SaveChanges();  
            return OperationResult.Success();
        }
        public void DeleteCustomer(int id)
        {
            var customerSet = _context.Set<Customer>().ToList();
            List<CustomerDto> RegCustomerDto = new List<CustomerDto>();  
            Customer isUserNameExist = customerSet.ElementAt(id);
            _context.Customers.Remove(isUserNameExist);
            _context.SaveChanges();

        }
    }
}
