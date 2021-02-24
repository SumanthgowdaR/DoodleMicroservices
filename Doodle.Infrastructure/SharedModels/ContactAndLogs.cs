using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle.Infrastructure.SharedModels
{
    public class ContactAndLogs
    {
        public int LeadId { get; set; }
        public int? ContactDetail { get; set; }
        public string CommunicationMode { get; set; }
        public int? LeadSource { get; set; }
        public int? CurrentStatus { get; set; }
        public int LogId { get; set; }
        public int Loan { get; set; }
        public string CommunicationDate { get; set; }
        public int? Status { get; set; }
    }
}
