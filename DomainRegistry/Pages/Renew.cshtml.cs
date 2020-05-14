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
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly IDomain _domain;

        /// <summary>
        /// A constructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="domain"></param>
        public RenewModel(IDomain domain)
        {
            _domain = domain;
        }

        public Domain Domain { get; set; }

        [BindProperty]
        public UpdateInput Input { get; set; }

        /// <summary>
        /// Get the domain object from the database using the domain's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnGetAsync(int id)
        {
            Domain = await _domain.GetDomainByDomainIdAsync(id);
        }

        /// <summary>
        /// Get the domain object from the database using the domaint's ID
        /// Then edit the information based on the data from the form
        /// Save the updated domain object into the database
        /// Redirect the user back to the domain's information page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// A class to define the UpdateInput
        /// </summary>
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