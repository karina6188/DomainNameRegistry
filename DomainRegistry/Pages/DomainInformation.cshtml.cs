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
        private readonly IDomain _domain;

        public DomainInformationModel(IDomain domain)
        {
            _domain = domain;
        }

        public Domain Domain { get; set; }

        public async Task OnGetAsync(int id)
        {
            Domain = await _domain.GetDomainByDomainIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _domain.DeleteDomain(id);
            return Redirect("/");
        }
    }
}