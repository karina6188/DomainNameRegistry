using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainRegistry.Models.Interface
{
    public interface IDomain
    {
        Task CreateDomainAsync(Domain domain);

        Task<Domain> GetDomainByDomainIdAsync(int domainId);

        Task UpdateDomain(Domain domain);

        Task DeleteDomain(int domainId);
    }
}
