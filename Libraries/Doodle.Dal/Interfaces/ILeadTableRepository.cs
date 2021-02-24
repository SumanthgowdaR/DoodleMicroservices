using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Doodle.Infrastructure.SharedModels;
using Doodle.SqlEntities.Entities;

namespace Doodle.Dal.Interfaces
{
    public interface ILeadTableRepository : IRepository<LeadTable>
    {
        Task<dynamic> GetCustomerAllDetails(ContactAndLogs input);
        void UpdateLeadTable(LeadTable entity);
    }
}
