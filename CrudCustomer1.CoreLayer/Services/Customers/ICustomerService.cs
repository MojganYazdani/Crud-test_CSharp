using CrudCustomer1.CoreLayer.DTOs.Customers;
using CrudCustomer1.CoreLayer.Utilities;
using CrudCustomer1.DataLayer.Entities;

using System.Collections.Generic;
namespace CrudCustomer1.CoreLayer.Services.Customers
{
    public interface ICustomerService
    {
        OperationResult CreateCustomer(CustomerDto RegCustomerDto);
        List<CustomerDto> ReadCustomer();
        CustomerDto FindACustomer(int id);
        OperationResult EditCustomer(CustomerDto a,int id);
        void DeleteCustomer(int id);


    }
}
