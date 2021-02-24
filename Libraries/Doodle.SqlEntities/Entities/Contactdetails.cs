using System;
using System.Collections.Generic;

namespace Doodle.SqlEntities.Entities
{
    public partial class Contactdetails
    {
        public Contactdetails()
        {
            LeadTable = new HashSet<LeadTable>();
        }

        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int? LeadId { get; set; }

        public virtual ICollection<LeadTable> LeadTable { get; set; }
    }
}
