using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelFirst.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public String RecommandationToApply { get; set; }
        public String Comment { get; set; }
        public int ? FaillureNumber { get; set; }
        public bool ? Reply { get; set; }
        public String RiskIncurred { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual Question Question { get; set; }
    }
}
