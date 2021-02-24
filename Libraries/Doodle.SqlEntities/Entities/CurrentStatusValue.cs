using System;
using System.Collections.Generic;

namespace Doodle.SqlEntities.Entities
{
    public partial class CurrentStatusValue
    {
        public CurrentStatusValue()
        {
            CommunicationLogs = new HashSet<CommunicationLogs>();
            LeadTable = new HashSet<LeadTable>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CommunicationLogs> CommunicationLogs { get; set; }
        public virtual ICollection<LeadTable> LeadTable { get; set; }
    }
}
