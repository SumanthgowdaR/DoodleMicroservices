using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Doodle.Infrastructure.SharedModels;
using Doodle.SqlEntities.Entities;

namespace Doodle.Dal.Interfaces
{
    public interface ICustomerRepository : IRepository<Contactdetails>
    {
        Task<bool> SaveCustomers(Contactdetails input);

        void UpdateLeadTable(Contactdetails entity);
    }
}
