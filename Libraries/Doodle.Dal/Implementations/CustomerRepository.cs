using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Doodle.Dal.Interfaces;
using Doodle.Dal.UnitOfWork;
using Doodle.Infrastructure.SharedModels;
using Doodle.SqlEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doodle.Dal.Implementations
{
    public class CustomerRepository : GenericRepository<Contactdetails>, ICustomerRepository
    {
        

        public CustomerRepository(DoodleContext context) : base(context)
        {

        }


        public void UpdateLeadTable(Contactdetails entity)
        {
            _context.Set<Contactdetails>().Attach(entity);
            _context.Entry(entity).Property(x => x.LeadId).IsModified = true;
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> SaveCustomers(Contactdetails input)
        {

           await _context.Contactdetails.AddAsync(input);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }
    }
}
