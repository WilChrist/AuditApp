using System;
using System.Collections.Generic;
using SelectPdf;
using System.IO;
using System.Reflection;
using modelFirst;
using modelFirst.Model;
using System.Linq;

namespace HandlingPdf.pdf
{
    public class PdfGenerator
    {
        public PdfGenerator()
        {
            this.Renderer = new HtmlToPdf();
            this.auditContext = new AuditContext();
        }

        private String p = "HandlingPdf.pdf.";
        public String CompanyName { get; set; } = "EXCELLENCIAL";
        public String Auditedcompany { get; set; } = "DEFAULT_COMPANY";
        public String CompanyLogoUrl { get; set; } = "logo.png";
        public String AuditedcompanyLogoUrl { get; set; } = "logo.png";
        public String EmployeeName { get; set; } = "DEFAULT_EMPLOYEE";
        public String ConductorEmployeeName { get; set; } = "DEFAULT_CONDUCTOR_EMPLOYEE";
        public String OuthPutPath { get; set; }= @"c:\";
        public String DataAsString { get; set; }

        private String CoverPageTemplate;
        private String ContentPagesTemplate;
        private PdfDocument CoverPage;
        private PdfDocument ContentPages;
        
        private HtmlToPdf Renderer;
        private AuditContext auditContext;

        private void setContentPagesTemplate()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(p+"contentPagesTemplate.html");
            StreamReader reader = new StreamReader(stream);
            this.ContentPagesTemplate = reader.ReadToEnd();

        }

        private void setCoverPageTemplate()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(p+"cover.html");
            StreamReader reader = new StreamReader(stream);
            this.CoverPageTemplate = reader.ReadToEnd();
            this.CoverPageTemplate = this.CoverPageTemplate.Replace("[[FONT]]", this.imageReader(p + "Lora-Regular.ttf"));
            this.CoverPageTemplate = this.CoverPageTemplate.Replace("[[BG_IMAGE]]", this.imageReader(p + "background.png"));
            this.CoverPageTemplate = this.CoverPageTemplate.Replace("[[EMPLOYEE]]", this.EmployeeName);
            this.CoverPageTemplate = this.CoverPageTemplate.Replace("[[AUDITED_COMPANY]]", this.Auditedcompany);
            this.CoverPageTemplate = this.CoverPageTemplate.Replace("[[LOGO1]]", this.imageReader(p + "ESLogo.png"));
            this.CoverPageTemplate = this.CoverPageTemplate.Replace("[[LOGO2]]", this.imageReader(p + "logo.png"));
            //Console.Write(this.CoverPageTemplate);
        }

        public void generateCoverPage()
        {

            this.Renderer.Options.PdfPageSize = PdfPageSize.A4;
            this.Renderer.Options.MarginTop = 0;
            this.Renderer.Options.MarginRight = 0;
            this.Renderer.Options.MarginBottom = 0;
            this.Renderer.Options.MarginLeft = 0;
            this.Renderer.Options.JpegCompressionLevel = 0;
            this.Renderer.Options.DrawBackground = true;
            this.Renderer.Options.AutoFitWidth = HtmlToPdfPageFitMode.NoAdjustment;
            this.setCoverPageTemplate();

            /*
             replace logo and other stuff in template
             */

            this.CoverPage = this.Renderer.ConvertHtmlString(this.CoverPageTemplate);
        }

        public void generateContentPagesWithStringData()
        {
            
            this.Renderer.Options.PdfPageSize = PdfPageSize.A4;
            this.Renderer.Options.MarginTop = 10;
            this.Renderer.Options.MarginRight = 10;
            this.Renderer.Options.MarginBottom = 10;
            this.Renderer.Options.MarginLeft = 15;
            this.Renderer.Options.JpegCompressionLevel = 0;
            this.Renderer.Options.DrawBackground = true;
            this.Renderer.Options.AutoFitWidth = HtmlToPdfPageFitMode.AutoFit;
            this.setContentPagesTemplate();
            this.ContentPagesTemplate = this.ContentPagesTemplate.Replace("[[CONTENT]]", this.DataAsString);
            this.ContentPages = this.Renderer.ConvertHtmlString(this.ContentPagesTemplate);

        }


        public void generateReport(int id)
        {
            this.generateStringData(id);
            this.generateCoverPage();
            this.generateContentPagesWithStringData();
            this.CoverPage.Append(this.ContentPages);
            this.CoverPage.Save(this.OuthPutPath);

        }


        private String imageReader(String name)
        {
           Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
           MemoryStream m = new MemoryStream();
            stream.CopyTo(m);
            return Convert.ToBase64String(m.ToArray());
        }

        private void generateStringData(int id)
        {
            List<Category> listCat = this.auditContext.Categories.ToList();

            this.DataAsString = "<h1>Questions Répondu</h1><table><tr><td>Categorie</td><td>Nombre de questions</td><td>Nb Répondues</td><td>Nb Oui</td><td>Nb Non</td><td>Nb NAN</td></tr>";
            foreach (Category cat in listCat)
            {
               
                int totalquestion = this.auditContext.Questions.Where(q => q.Category.Id == cat.Id).Count();
                int answered = this.auditContext.Answers.Where(a => a.Audit.Id == id && a.Question.Category.Id == cat.Id).Count();
                int answeredYes = this.auditContext.Answers.Where(a => a.Audit.Id == id && a.Question.Category.Id == cat.Id && a.Reply == true).Count();
                int answeredNo = this.auditContext.Answers.Where(a => a.Audit.Id == id && a.Question.Category.Id == cat.Id && a.Reply == false).Count();
                this.DataAsString += "<tr><td>" + cat.Name + "</td><td>" + totalquestion + "</td><td>" + answered + "</td><td>" + answeredYes + "</td><td>" + answeredNo + "</td><td>" + (totalquestion - answeredYes - answeredNo) + "</td></tr>";
            }
            this.DataAsString += "</table>";

            foreach(Category cat in listCat)
            {
                List<Answer> answeredNo = this.auditContext.Answers.Include("Question").Where(a => a.Audit.Id == id && a.Question.Category.Id == cat.Id && a.Reply == false).ToList();

                if (answeredNo.Count > 0)
                {
                    this.DataAsString += "<h1>Recommandations Pour la "+cat.Name+"</h1>";
                    this.DataAsString += "<table><tr><td>Question</td><td>Réponse</td><td>Recommandattion</td></tr>";
                
                    foreach(Answer answer in answeredNo)
                    {
                    
                        this.DataAsString += "<tr><td>"+answer.Question.Intitled+"</td><td>Non</td><td>"+answer.RecommandationToApply+"</td></tr>";
                    }

                    this.DataAsString += "</table>";
                }
                
            }

        }

    }
}
