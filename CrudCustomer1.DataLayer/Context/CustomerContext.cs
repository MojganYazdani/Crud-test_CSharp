using CrudCustomer1.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace CrudCustomer1.DataLayer.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        } 
        public DbSet<Customer> Customers { get; set; }


    }
}
