using modelFirst.Model;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelFirst
{
    class AuditContext : DbContext
    {
        public AuditContext() : base("AuditAppDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Answer>()
                .HasRequired(a => a.Question)
                .WithOptional(q => q.Answer);

            modelBuilder.Entity<Audit>()
                .HasMany(a=>a.Questions)
                .WithMany(q=>q.Audits);

            modelBuilder.Entity<Auditer>()
                .HasMany(a => a.Audits)
                .WithRequired(adt => adt.Auditer);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Questions)
                .WithRequired(q => q.Category);

            var sqliteConnectionInitializer = new AuditDBInitializer(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Auditer> Auditers { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        
    }
}
