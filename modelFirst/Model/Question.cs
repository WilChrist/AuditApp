using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelFirst.Model
{
    class Question
    {
        public int Id { get; set; }
        public String Intitled { get; set; }
        public String Details { get; set; }
        public int Coefficient { get; set; }
        public int Scale { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Category Category { get; set; }
        public ICollection<Audit> Audits { get; set; }
        public Answer Answer { get; set; }
    }
}
