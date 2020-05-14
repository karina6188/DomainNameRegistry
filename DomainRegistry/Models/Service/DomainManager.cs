using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainRegistry.Data;
using DomainRegistry.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace DomainRegistry.Models.Service
{
    public class DomainManager : IDomain
    {
        private readonly DomainDbContext _context;

        public DomainManager(DomainDbContext context)
        {
            _context = context;
        }

        public async Task CreateDomainAsync(Domain domain)
        {
            await _context.Domain.AddAsync(domain);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain> GetDomainByDomainIdAsync(int domainID) => await _context.Domain.FirstOrDefaultAsync(x => x.ID == domainID);

        public async Task DeleteDomain(int id)
        {
            Domain domain = await GetDomainByDomainIdAsync(id);
            _context.Domain.RemoveRange(domain);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDomain(Domain domain)
        {
            _context.Domain.Update(domain);
            await _context.SaveChangesAsync();
        }
    }
}
