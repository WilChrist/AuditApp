using System;
using System.Collections.Generic;
using SelectPdf;
using System.IO;
using System.Reflection;

namespace HandlingPdf.pdf
{
    public class PdfGenerator
    {
        public PdfGenerator()
        {
            this.Renderer = new HtmlToPdf();
        }

        private String p = "HandlingPdf.pdf.";
        public String CompanyName { get; set; } = "EXCELLENCIAL";
        public String Auditedcompany { get; set; } = "DEFAUL_COMPANY";
        public String CompanyLogoUrl { get; set; } = "logo.png";
        public String AuditedcompanyLogoUrl { get; set; } = "logo.png";
        public String EmployeeName { get; set; } = "DEFAULT_EMPLOYEE";
        public String ConductorEmployeeName { get; set; } = "DEFAULT_CONDUCTOR_EMPLOYEE";
        public String OuthPutPath { get; set; }= @"c:\";
        public String DataAsString { get; set; }
        public List<String> DataAsList { get; set; }

        private String CoverPageTemplate;
        private String ContentPagesTemplate;
        private PdfDocument CoverPage;
        private PdfDocument ContentPages;
        
        private HtmlToPdf Renderer;


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
            this.CoverPageTemplate = this.CoverPageTemplate.Replace("[[LOGO1]]", this.imageReader(p + "logo.png"));
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

        public void generateContentPagesWithListData()
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

            String data = "une liste de données";
            /*
             do stuff with lis data to get a string before replace in template
             */
            this.ContentPagesTemplate.Replace("[[CONTENT]]", data);
            this.ContentPages = this.Renderer.ConvertHtmlString(this.ContentPagesTemplate);
        }

        public void generateReport()
        {
            this.generateCoverPage();
            this.generateContentPagesWithStringData();
            this.CoverPage.Append(this.ContentPages);
            this.CoverPage.Save(this.OuthPutPath);

        }

        public void generateReposrtWithListData()
        {
            this.generateCoverPage();
            this.generateContentPagesWithListData();
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

    }
}
