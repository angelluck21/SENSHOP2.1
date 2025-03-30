
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using SENSHOP2._1.Models;
using SENSHOP2._1.PDF;
using static SENSHOP2._1.Repositorio.RepositorioFactura;
using static SENSHOP2._1.Repositorio.RepositorioPDF2;

namespace SENSHOP2._1.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositorioFactura _repositorioFactura;

        public FacturaController(IConfiguration configuration, IRepositorioFactura Repofac)
        {
            _configuration = configuration;
            _repositorioFactura = Repofac;
        }

        public IActionResult Facturar(ProductoViewModel producto)
        {
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new footer(document));

            // Añadir encabezado de la factura
            document.Add(new Paragraph("FACTURA")
                .SetFontSize(24)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            // Añadir detalles del vendedor
            document.Add(new Paragraph("Nombre del Vendedor: Tu Empresa")
                .SetFontSize(12)
                .SetTextAlignment(TextAlignment.LEFT));
            document.Add(new Paragraph("Dirección: Calle Falsa 123")
                .SetFontSize(12)
                .SetTextAlignment(TextAlignment.LEFT));
            document.Add(new Paragraph("Teléfono: +123 456 7890")
                .SetFontSize(12)
                .SetTextAlignment(TextAlignment.LEFT));
            document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"))
                .SetFontSize(12)
                .SetTextAlignment(TextAlignment.RIGHT));

            // Espacio entre secciones
            document.Add(new Paragraph("\n\n"));

            // Añadir detalles de productos
            var facs = _repositorioFactura.GenerarFactura(new ProductoViewModel());

            foreach (var p in facs)
            {
                document.Add(new Paragraph($"Código del producto: {p.code}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT));
               ;
                document.Add(new Paragraph($"Precio: {p.p_venta}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT));
                document.Add(new Paragraph($"Descripción del producto: {p.descripsionE}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT));
                document.Add(new Paragraph($"Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT));
                document.Add(new Paragraph("\n"));
            }

            document.Close();

            byte[] pdfBytes = stream.ToArray();
            Response.Headers.Add("Content-Disposition", "inline; filename=Factura.pdf");
            return File(pdfBytes, "application/pdf");
        }
    }


}
