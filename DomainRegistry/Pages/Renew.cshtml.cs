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
    public class RenewModel : PageModel
    {
        private readonly IDomain _domain;

        public RenewModel(IDomain domain)
        {
            _domain = domain;
        }

        public Domain Domain { get; set; }

        public async Task OnGetAsync(int id)
        {
            Domain = await _domain.GetDomainByDomainIdAsync(id);
        }
    }
}