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
    public class CreateModel : PageModel
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

        public CreateModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var result = _customerService.CreateCustomer(new CustomerDto()
            {
                Firstname = Firstname,
                Lastname = Lastname,
                DateOfBirth = DateOfBirth,
                PhoneNumber = PhoneNumber,
                Email = Email,
                BankAccountNumber = BankAccountNumber

            });
            if (result.Status == OperationResultStatus.Error)
            {
                ModelState.AddModelError("Customer", result.Message);
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
