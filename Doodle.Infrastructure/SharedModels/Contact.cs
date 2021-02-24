using System;
using System.Collections.Generic;
using System.Text;

namespace Doodle.Infrastructure.SharedModels
{
    public class Contact
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
}
