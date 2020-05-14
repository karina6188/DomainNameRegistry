using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainRegistry.Models.Interfaces
{
    public interface IDomain
    {
        Task SaveDomainAsync(Domain domain);

        Task GetDomainByNameAsync(string domainName);

        Task UpdateDomain(Domain domain);
    }
}
