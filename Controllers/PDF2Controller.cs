
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using SENSHOP2._1.Models;
using SENSHOP2._1.PDF;
using static SENSHOP2._1.Repositorio.PDFRepositorio1;
using static SENSHOP2._1.Repositorio.RepositorioPDF2;

namespace SENSHOP2._1.Controllers
{
    public class PDF2Controller : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositorioPDF_2 _repositorioPDF2;
        private readonly IRepositorioPDF1 _repositorioPDF1;

        public PDF2Controller(IConfiguration configuration, IRepositorioPDF_2 repositorioPDF2, IRepositorioPDF1 repositorioPDF1)
        {
            _configuration = configuration;
            _repositorioPDF2 = repositorioPDF2;
            _repositorioPDF1 = repositorioPDF1; 
        }

        public IActionResult ListadoProductosPdf2(ProductoViewModel producto)
        {
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new footer(document));

            document.Add(new Paragraph("Productos Registrados")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(5, true);
            table.AddHeaderCell("Codigo");
            table.AddHeaderCell("Nombre del producto");
            table.AddHeaderCell("Precio en venta");
            table.AddHeaderCell("Descripcion del producto");
            table.AddHeaderCell("Unidades");
        

            ProductoViewModel model = new ProductoViewModel();
            var pdf2 = _repositorioPDF2.HacerPDF2(model);
            foreach (var p in pdf2)
            {
                table.AddCell(p.code);
                table.AddCell(p.name);
                table.AddCell(p.p_venta);
                table.AddCell(p.descripsionE);
                table.AddCell(p.Uni);
                
            
            }

            document.Add(table);
            document.Close();

            byte[] pdfBytes = stream.ToArray();
            Response.Headers.Add("Content-Disposition", "inline; filename=Productos Registrados.pdf");
            return File(pdfBytes, "application/pdf");
        }
        
       


        public IActionResult proveedoreslist(ProveedoresViewModel proveer)
        {
            MemoryStream stream = new MemoryStream();
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new footer(document));

            document.Add(new Paragraph("Listados de Proveedores")
                .SetFontSize(18)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER));

            Table table = new Table(5, true);
            table.AddHeaderCell("Cedula");
            table.AddHeaderCell("Nombres");
            table.AddHeaderCell("Apellidos");
            table.AddHeaderCell("Numero de telefeno");
            table.AddHeaderCell("Empresa");


            ProveedoresViewModel model = new ProveedoresViewModel();
            var pdf2 = _repositorioPDF1.proveedorespdf(model);
            foreach (var p in pdf2)
            {

                table.AddCell(p.Nombre);
                table.AddCell(p.Apellido);
                table.AddCell(p.NTelefono);
                table.AddCell(p.empresa);


            }

            document.Add(table);
            document.Close();

            byte[] pdfBytes = stream.ToArray();
            Response.Headers.Add("Content-Disposition", "inline; filename=Listado de productos.pdf");
            return File(pdfBytes, "application/pdf");
        }
    }
}
