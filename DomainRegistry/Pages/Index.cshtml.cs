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
        private readonly IDomain _domain;

        public IndexModel(IDomain domaincontext)
        {
            _domain = domaincontext;
        }

        [BindProperty]
        public RegisterInput Input { get; set; }

        public void OnGet()
        {

        }

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