using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace DomainRegistry.Pages
{
    public class IndexModel : PageModel
    {
        public IConfiguration Configuration { get; set; }

        [BindProperty]
        public RegisterInput Input { get; set; }

        public void OnGet()
        {

        }

        public class RegisterInput
        {
            [StringLength(30, MinimumLength = 10)]
            [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$")]
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