using System;
using System.Collections.Generic;
using System.Text;
using Doodle.Dal.Interfaces;
using Doodle.SqlEntities.Entities;

namespace Doodle.Dal.Implementations
{
    public class CurrentStatusValueRepository : GenericRepository<CurrentStatusValue>, ICurrentStatusValueRepository
    {

        public CurrentStatusValueRepository(DoodleContext context) : base(context)
        {

        }

    }
}
