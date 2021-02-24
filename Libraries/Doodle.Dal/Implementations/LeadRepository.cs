using System;
using System.Collections.Generic;
using System.Text;
using Doodle.Dal.Interfaces;
using Doodle.SqlEntities.Entities;

namespace Doodle.Dal.Implementations
{
    public class LeadRepository : GenericRepository<LeadsourceTable>, ILeadRepository
    {
        public LeadRepository(DoodleContext context) : base(context)
        {

        }
    }
}
