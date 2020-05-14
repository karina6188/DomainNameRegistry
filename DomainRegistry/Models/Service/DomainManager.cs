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
        /// <summary>
        /// Establishes a private connection to a database via dependency injection
        /// </summary>
        private readonly DomainDbContext _context;

        public DomainManager(DomainDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves a new domain data from the form into the connected database
        /// </summary>
        public async Task CreateDomainAsync(Domain domain)
        {
            await _context.Domain.AddAsync(domain);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get the domain by the ID from the connected database
        /// </summary>
        public async Task<Domain> GetDomainByDomainIdAsync(int domainID) => await _context.Domain.FirstOrDefaultAsync(x => x.ID == domainID);

        /// <summary>
        /// Delete the domain by using the domain's ID in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteDomain(int id)
        {
            Domain domain = await GetDomainByDomainIdAsync(id);
            _context.Domain.RemoveRange(domain);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update the domain with new data and save it in the database
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task UpdateDomain(Domain domain)
        {
            _context.Domain.Update(domain);
            await _context.SaveChangesAsync();
        }
    }
}
