using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurboAzController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public TurboAzController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            HttpClient client= new HttpClient();
            client.BaseAddress = new Uri("https://turbo.az");
           var response= await client.GetStringAsync("/");

            return response;

        }
        [HttpGet("{name}")]
        public async Task Get(string name )
        {
            string contentRootPath = _environment.ContentRootPath;
            string filePath = Path.Combine(contentRootPath, "Documents",name+ ".docx");

         
            // Create a document by supplying the filepath. 
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();

                // Create an empty table.
                Table table = new Table();

                // Create a TableProperties object and specify its border information.
                TableProperties tblProp = new TableProperties(
                    new TableBorders(
                        new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                        new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                        new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                        new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                        new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 },
                        new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Dashed), Size = 24 }
                    )
                );
                // Append the TableProperties object to the empty table.
                table.AppendChild<TableProperties>(tblProp);

                // Create a row.
                TableRow tr = new TableRow();

                // Create a cell.
                TableCell tc1 = new TableCell();

                // Specify the width property of the table cell.
                tc1.Append(new TableCellProperties(new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));

                // Specify the table cell content.
                tc1.Append(new Paragraph(new Run(new Text("Hello, World!"))));

                // Append the table cell to the table row.
                tr.Append(tc1);


                // Create a second table cell by copying the OuterXml value of the first table cell.
                TableCell tc2 = new TableCell(tc1.OuterXml);

                // Append the table cell to the table row.
                tr.Append(tc2);

                // Append the table row to the table.
                table.Append(tr);
                mainPart.Document.Body=new Body());
                // Append the table to the document.
                mainPart.Document.Body.Append(table);

                // Save changes to the MainDocumentPart.
                mainPart.Document.Save();

              
            }
        }
    }
}
