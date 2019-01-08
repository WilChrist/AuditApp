using modelFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace modelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using ( var auditContext = new AuditContext())
            {
                Thread.Sleep(0);
                foreach (var audit in auditContext.Audits)
                {
                    auditContext.Entry(audit).Reference(a => a.Auditer).Load();
                    Console.WriteLine(audit.Auditer.Email+" "+audit.Auditer.Password);
                }
            }
            Console.ReadLine();
        }
    }
}
