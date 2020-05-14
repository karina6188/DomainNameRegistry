using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainRegistry.Models;
using DomainRegistry.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainRegistry.Pages
{
    public class DomainInformationModel : PageModel
    {
        /// <summary>
        /// Dependency injection to establish a private connection to a database table by injecting an interface
        /// </summary>
        private readonly IDomain _domain;

        /// <summary>
        /// A constructor to set propety to the corresponding interface instance
        /// </summary>
        /// <param name="domain"></param>
        public DomainInformationModel(IDomain domain)
        {
            _domain = domain;
        }

        public Domain Domain { get; set; }

        /// <summary>
        /// Get the domain object from the database using the domaint's ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task OnGetAsync(int id)
        {
            Domain = await _domain.GetDomainByDomainIdAsync(id);
        }

        /// <summary>
        /// Delete the domain object in the database using the domain's ID
        /// Redirect the user back to the Registration page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _domain.DeleteDomain(id);
            return Redirect("/");
        }
    }
}