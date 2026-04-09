using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationReport.Clases;

namespace WebApplicationReport.view
{
    public partial class VisitaReporteForm : System.Web.UI.Page


    {
        public Persona persona = new Persona();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var data = new List<Persona>
                {
                    new Persona {Id = 1, Name = "John Doe", Age = 29  },
                    new Persona {Id = 2, Name = "Jane Smith", Age = 34  },
                    new Persona {Id = 3, Name = "Samuel Green", Age = 41  }

                };

                gvPersonas.DataSource = data;
                gvPersonas.DataBind();


            }

        }

        protected  void btnPDF_Click(object sender, EventArgs e)
        {

            var data = new List<Persona>
                {
                    new Persona {Id = 1, Name = "John Doe", Age = 29  },
                    new Persona {Id = 2, Name = "Jane Smith", Age = 34  },
                    new Persona {Id = 3, Name = "Samuel Green", Age = 41  }

                };

            //RUTA TEMPORAL PARA GUARDAR EL PDF
                        string filePath = Server.MapPath("~/Reportes/GeneratedReporte.pdf");


            // Crear el archivo PDF
            using (var writer = new iText.Kernel.Pdf.PdfWriter(filePath))
            {
                using (var pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                {
                    var document = new iText.Layout.Document(pdf);

                    document.Add(new iText.Layout.Element.Paragraph("Reporte de Personas"));

                    foreach (var person in data)
                    {
                        document.Add(new iText.Layout.Element.Paragraph($"ID: {person.Id}"));
                        document.Add(new iText.Layout.Element.Paragraph($"Nombre: {person.Name}"));
                        document.Add(new iText.Layout.Element.Paragraph($"Edad: {person.Age}"));
                        document.Add(new iText.Layout.Element.Paragraph("---------------------------"));
                    }

                    document.Close();
                }
            }

            // Descargar el archivo PDF
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.pdf");
            Response.TransmitFile(filePath);
            Response.End();
        }








    }
}