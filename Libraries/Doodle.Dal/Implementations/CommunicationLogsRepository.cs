using System;
using System.Collections.Generic;
using System.Text;
using Doodle.Dal.Interfaces;
using Doodle.SqlEntities.Entities;

namespace Doodle.Dal.Implementations
{
    public class CommunicationLogsRepository : GenericRepository<CommunicationLogs>, ICommunicationLogsRepository
    {

        public CommunicationLogsRepository(DoodleContext context) : base(context)
        {

        }
    }
}
