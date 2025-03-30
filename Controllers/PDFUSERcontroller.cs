
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using SENSHOP2._1.Models;
using SENSHOP2._1.PDF;
using static SENSHOP2._1.Repositorio.RepositorioUserpdf;

namespace SENSHOP2._1.Controllers
{   
    public class PDFUSERcontroller : Controller
    {
        
        
            private readonly IConfiguration _configuration;
            private readonly IRepositorioUserpdf _RepositorioUserpdf;

            public PDFUSERcontroller(IConfiguration configuration, IRepositorioUserpdf RepositorioUserpdf)
            {
                _configuration = configuration;
                 _RepositorioUserpdf = RepositorioUserpdf;
            }

            public IActionResult Listadousers(RegViewModel user)
            {
                MemoryStream stream = new MemoryStream();
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new footer(document));

                document.Add(new Paragraph("Listdos de personas registradas")
                    .SetFontSize(18)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER));

                Table table = new Table(5, true);
                table.AddHeaderCell("fecha");
                table.AddHeaderCell("Cedula");
                table.AddHeaderCell("Nombre");
                table.AddHeaderCell("Apellido");
                table.AddHeaderCell("Correo");


                RegViewModel model = new RegViewModel();
                var pdf3 = _RepositorioUserpdf.HacerPDF3(model);
                foreach (var p in pdf3)
                {
                    table.AddCell(p.fecha);
                    table.AddCell(p.n_identficacion);
                    table.AddCell(p.name);
                    table.AddCell(p.apellido);
                    table.AddCell(p.correo);


                }

                document.Add(table);
                document.Close();

                byte[] pdfBytes = stream.ToArray();
                Response.Headers.Add("Content-Disposition", "inline; filename=Listado de productos.pdf");
                return File(pdfBytes, "application/pdf");
            }
        }
    
}
