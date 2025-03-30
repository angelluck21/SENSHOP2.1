using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;

namespace SENSHOP2._1.PDF
{
    public class footer : IEventHandler
    {
        private readonly Document _document;

        public footer(Document document)
        {
            _document = document;
        }
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfPage page = docEvent.GetPage();
            PdfCanvas canvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), docEvent.GetDocument());

            
            Rectangle pageSize = page.GetPageSize();

            
            Canvas footerCanvas = new Canvas(canvas, pageSize);
            footerCanvas.SetFontSize(10);

            Paragraph footerParagraph = new Paragraph()
            .Add("Desarrollamos Software ADSO\n")
            .Add("Página " + docEvent.GetDocument().GetPageNumber(page));

           
            footerCanvas
                .ShowTextAligned(
                    footerParagraph,
                    pageSize.GetWidth() / 2,
                    pageSize.GetBottom() + 20, 
                    iText.Layout.Properties.TextAlignment.CENTER
                );

            footerCanvas.Close();


        }


    }
}
