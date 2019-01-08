﻿using modelFirst.Model;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelFirst
{
    class AuditDBInitializer : SqliteDropCreateDatabaseAlways<AuditContext>
    {
        public AuditDBInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void Seed(AuditContext context)
        {
            base.Seed(context);
            int numberOfObject = 9;
            int numberOfSubObject = 8;
            Random random = new Random();

            for (int i = 1; i <= numberOfObject; i++)
            {
                #region
                Category category = new Category()
                {
                    Id = i,
                    Name = "Category " + i,
                    CreatedAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };
                context.Categories.Add(category);
                #endregion

                #region
                Auditer auditer = new Auditer()
                {
                    Id = i,
                    FirstName = "Auditer " + i,
                    LastName = "Of Excellecia Audit " + i,
                    Email = "auditer" + i + "@excellenciaudit.ma",
                    PhoneNumber = "+212 6 33 22 55 1" + i,
                    Password = BCrypt.Net.BCrypt.HashPassword("123456789"),
                    CreatedAt = DateTime.Now,
                    UpdateAt = DateTime.Now

                };
                
                context.Auditers.Add(auditer);
                #endregion

                #region
                Audit audit = new Audit()
                {
                    Id = i,
                    Name = "Audit " + i,
                    AuditedCompanyName = "Company " + i,
                    CreatedAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                };
                audit.Auditer = auditer;
                //auditer.Audits.Add(audit);
                context.Audits.Add(audit);
                #endregion


                #region
                List<Answer> answers = new List<Answer>();
                for (int j = 1; j <= numberOfSubObject; j++)
                {
                    Answer answer = new Answer()
                    {
                        Id = j,
                        Score = j,
                        Recommandation = "Recommandation " + j,
                        Comment = "Comment " + j,
                        FaillureNumber = j,
                        CreatedAt = DateTime.Now,
                        UpdateAt = DateTime.Now
                    };
                    answers.Add(answer);
                    context.Answers.Add(answer);
                }
                
                #endregion

                #region

                List<Question> questions = new List<Question>();
                for (int j = 1; j <= numberOfSubObject; j++)
                {
                    Question question = new Question()
                    {
                        Id = j,
                        Intitled = "Intitled " + j,
                        Details = "Details " + j,
                        Coefficient = random.Next(1, 5),
                        Scale = 10,
                        CreatedAt = DateTime.Now,
                        UpdateAt = DateTime.Now,
                    };
                    
                    question.Category = category;
                    question.Answer = answers.ElementAt(j-1);
                    questions.Add(question);
                }
                audit.Questions = questions;
                //category.Questions = questions;

                #endregion

            }
            context.SaveChanges();
        }
    }
}