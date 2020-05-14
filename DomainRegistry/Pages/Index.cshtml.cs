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

namespace DomainRegistry.Pages
{
    public class IndexModel : PageModel
    {
        public IConfiguration Configuration { get; set; }

        [BindProperty]
        public RegisterInput Input { get; set; }

        private DomainDbContext _context;

        public IndexModel(DomainDbContext context)
        {
            _context = context;
        }

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

            var result = await _context.
            
        }

        public class RegisterInput
        {
            [StringLength(30, MinimumLength = 10)]
            [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$", ErrorMessage = "The field Domain Name: can only contain characters and numbers")]
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