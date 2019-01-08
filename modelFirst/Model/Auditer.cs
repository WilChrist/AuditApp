using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelFirst.Model
{
    class Auditer
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public ICollection<Audit> Audits { get; set; }
    }
}
