using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Doodle.Dal.Implementations;
using Doodle.Dal.Interfaces;
using Doodle.SqlEntities.Entities;

namespace Doodle.Dal.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DoodleContext _context;

        public UnitOfWork(DoodleContext context)
        {
            _context = context;
            Customer = new CustomerRepository(_context);
            commLogs = new CommunicationLogsRepository(_context);
            csv = new CurrentStatusValueRepository(_context);
            Lead = new LeadRepository(_context);
            LeadTable = new LeadTableRepository(_context);
        }

        public ICustomerRepository Customer { get; private set; }
        public ICommunicationLogsRepository commLogs { get; private set;}

        public ICurrentStatusValueRepository csv { get; private set; }

        public ILeadRepository Lead { get; private set; }
        public ILeadTableRepository LeadTable { get;  private set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
