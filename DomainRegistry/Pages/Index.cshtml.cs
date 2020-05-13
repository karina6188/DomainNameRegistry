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
        public void OnGet()
        {

        }
    }
}