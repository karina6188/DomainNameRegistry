using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainRegistry.Models
{
    public class Domain
    {
        public int ID { get; set; }
        [Required]
        public string DomainName { get; set; }
        [Required]
        public int Period { get; set; }
        [Required]
        public string Provider { get; set; }
        [Required]
        public string ContactID { get; set; }
    }
}
