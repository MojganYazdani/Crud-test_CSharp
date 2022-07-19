﻿using System;
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

    public class DeleteModel : PageModel
    {
        [ViewData]
        public int C_id { get; set; } 

        [ViewData]
        public CustomerDto foundedCustomer { get; set; }

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
        public void OnGet(int C_Id)
        { 
            C_id = C_Id; 
            foundedCustomer= _customerService.FindACustomer(C_Id);
        }

        private readonly ICustomerService _customerService;
   
        public DeleteModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        public IActionResult OnPostDelete(int id)
        { 

            _customerService.DeleteCustomer(id);

            return RedirectToPage("Index");
        }


    }

}