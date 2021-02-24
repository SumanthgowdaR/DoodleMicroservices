using System;
using System.Collections.Generic;

namespace Doodle.SqlEntities.Entities
{
    public partial class LeadsourceTable
    {
        public LeadsourceTable()
        {
            LeadTable = new HashSet<LeadTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LeadTable> LeadTable { get; set; }
    }
}
