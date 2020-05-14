using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using DomainRegistry.Models;
using DomainRegistry.Data;
using DomainRegistry.Models.Interface;

namespace DomainRegistry.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly IDomain _domain;

        /// <summary>
        /// A contructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="domaincontext"></param>
        public IndexModel(IDomain domaincontext)
        {
            _domain = domaincontext;
        }

        [BindProperty]
        public RegisterInput Input { get; set; }

        public void OnGet()
        {

        }

        /// <summary>
        /// Get the data from the form and use the information to createe a Domain object
        /// Create a new data row using the Domain object and save it into the database
        /// If the data is saved successfully, redirect the page to Domain Information
        /// Otherwise stay at the same page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var domain = new Domain
            {
                DomainName = Input.DomainName,
                Period = Input.Period,
                Provider = Input.Provider,
                ContactID = Input.ContactID
            };

            await _domain.CreateDomainAsync(domain);
            var result = _domain.GetDomainByDomainIdAsync(domain.ID);
            if (result != null)
            {
                return Redirect($"/DomainInformation/{domain.ID}");
            }
            else
            {
                return Redirect("/");
            }
        }

        /// <summary>
        /// A class to define the RegisterInput
        /// </summary>
        public class RegisterInput
        {
            [StringLength(30, MinimumLength = 10)]
            [Required]
            [Display(Name = "Domain Name:")]
            public string DomainName { get; set; }

            [Range(1, 5)]
            [Required]
            [Display(Name = "Period of Registration(years):")]
            public int Period { get; set; }

            [Required]
            [Display(Name = "Verification Provider:")]
            public string Provider { get; set; }

            [Required]
            [Display(Name = "Contact ID:")]
            public string ContactID { get; set; }
        }
    }
}