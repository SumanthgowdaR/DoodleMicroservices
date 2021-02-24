using System;
using System.Collections.Generic;
using System.Text;
using Doodle.Dal.Interfaces;
using Doodle.Infrastructure.SharedModels;
using Doodle.SqlEntities.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Doodle.Dal.Implementations
{
    public class LeadTableRepository : GenericRepository<LeadTable>, ILeadTableRepository
    {
        public LeadTableRepository(DoodleContext context) : base(context)
        {

        }

        public async void UpdateLeadTable(LeadTable entity)
        {
            _context.Set<LeadTable>().Attach(entity);
            _context.Entry(entity).Property(x => x.CurrentStatus).IsModified = true;
            _context.Entry(entity).State = EntityState.Modified;
        }
        public async Task<dynamic> GetCustomerAllDetails(ContactAndLogs input)
        {
            var res = (from cd in _context.Contactdetails
                       join ld in _context.LeadTable on cd.Id equals ld.ContactDetail
                       join l in _context.Leads on ld.Id equals l.Id
                       join csv in _context.CurrentStatusValue on ld.CurrentStatus equals csv.Id
                       join ls in _context.LeadsourceTable on ld.LeadSource equals ls.Id
                       where ld.Id == input.LeadId && cd.Id == input.ContactDetail
                       select new 
                       {
                           UserName = cd.ContactName,
                           userMail = cd.Email,
                           UserMobile = cd.ContactNumber,
                           LeadName = l.Name,
                           CommunicationMode = ld.CommunicationMode,
                           LeadSource = ls.Name,
                           Loan = ld.LeadAmountRequired,
                           CurrentStatus = csv.Name


                       }).SingleOrDefault();

                      return res;
        }
    }
}
