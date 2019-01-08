using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelFirst.Model
{
    class Audit
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String AuditedCompanyName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Auditer Auditer { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
