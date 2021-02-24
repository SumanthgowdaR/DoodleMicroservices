using System;
using System.Collections.Generic;

namespace Doodle.SqlEntities.Entities
{
    public partial class CommunicationLogs
    {
        public int Id { get; set; }
        public int? LeadId { get; set; }
        public string CommunicationDate { get; set; }
        public string CommunicationMode { get; set; }
        public int? Status { get; set; }

        public virtual LeadTable Lead { get; set; }
        public virtual CurrentStatusValue StatusNavigation { get; set; }
    }
}
