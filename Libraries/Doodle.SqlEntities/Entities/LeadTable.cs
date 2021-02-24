using System;
using System.Collections.Generic;

namespace Doodle.SqlEntities.Entities
{
    public partial class LeadTable
    {
        public LeadTable()
        {
            CommunicationLogs = new HashSet<CommunicationLogs>();
        }

        public int Id { get; set; }
        public int? ContactDetail { get; set; }
        public string CommunicationMode { get; set; }
        public int? LeadSource { get; set; }
        public int? LeadAmountRequired { get; set; }
        public int? CurrentStatus { get; set; }

        public virtual Contactdetails ContactDetailNavigation { get; set; }
        public virtual CurrentStatusValue CurrentStatusNavigation { get; set; }
        public virtual LeadsourceTable LeadSourceNavigation { get; set; }
        public virtual ICollection<CommunicationLogs> CommunicationLogs { get; set; }
    }
}
