using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelFirst.Model
{
    class Answer
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public String Recommandation { get; set; }
        public String Comment { get; set; }
        public int ? FaillureNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Question Question { get; set; }
    }
}
