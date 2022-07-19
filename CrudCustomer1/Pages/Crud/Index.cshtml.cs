using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrudCustomer1.CoreLayer.DTOs.Customers;
using CrudCustomer1.CoreLayer.Services.Customers;
using CrudCustomer1.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
namespace CrudCustomer1.Pages.Crud
{
    [BindProperties]
    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        
        private readonly ICustomerService _customerService;

        #region Properties  
        [Display(Name = "First Name ")]
        [Required(ErrorMessage = " Enter {0} ")]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = " Enter {0} ")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = " Enter {0} ")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = " Enter {0} ")]
        public string Email { get; set; }

        [DataType(DataType.CreditCard)]
        [Display(Name = "Bank Account Number")]
        public string BankAccountNumber { get; set; } 

        #endregion
        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [ViewData]
        public string[] customersField { get; set; } = new string[] {
            "Firs tname",  "Last name", "Date Of Birth" , "Phone Number","Email","Bank Account Number"  };
        [ViewData]
        public List<CustomerDto> Result { get; set; } = new List<CustomerDto>(); 
        public void OnGet(string title)
        {
            Result = _customerService.ReadCustomer(); 
        }

        public IActionResult OnPostCreate()
        { 
            return RedirectToPage("Create");
        }
        public IActionResult OnPostDetail(int id)
        { 
            return RedirectToPage("Detail", new { C_Id = id });
        }
        public IActionResult OnPostEdit(int id)
        { 
            return RedirectToPage("Edit", new { C_Id = id });
        }
        public IActionResult OnPostDelete(int id)
        { 
            return RedirectToPage("Delete", new { C_Id = id });
        }

    }
}
