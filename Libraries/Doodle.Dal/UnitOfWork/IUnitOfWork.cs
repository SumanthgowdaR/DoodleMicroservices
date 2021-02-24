using System;
using System.Collections.Generic;
using System.Text;
using Doodle.Dal.Interfaces;
using System.Threading.Tasks;

namespace Doodle.Dal.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        ICommunicationLogsRepository commLogs { get; }

        ICurrentStatusValueRepository csv { get; }

        ILeadRepository Lead { get; }
        ILeadTableRepository LeadTable { get; }

        Task<int> CommitAsync();
    }
}
