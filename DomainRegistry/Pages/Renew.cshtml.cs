using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainRegistry.Models;
using DomainRegistry.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DomainRegistry.Pages
{
    public class RenewModel : PageModel
    {
        private readonly IDomain _domain;

        public RenewModel(IDomain domain)
        {
            _domain = domain;
        }

        public Domain Domain { get; set; }

        [BindProperty]
        public UpdateInput Input { get; set; }

        public async Task OnGetAsync(int id)
        {
            Domain = await _domain.GetDomainByDomainIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Domain domain = await _domain.GetDomainByDomainIdAsync(id);

            domain.DomainName = Request.Form["DomainName"];
            domain.Period = Convert.ToInt32(Request.Form["Period"]);
            
            try
            {
                await _domain.UpdateDomain(domain);
            }
            catch (Exception)
            {
                throw;
            }
            return Redirect($"/DomainInformation/{domain.ID}");
        }

        public class UpdateInput
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