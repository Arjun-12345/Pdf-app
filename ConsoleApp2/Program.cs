using Spire.Pdf;
using Spire.Pdf.Texts;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace HighlightTextInPdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a PdfDocument instance
            PdfDocument pdf = new PdfDocument();
            //Load a PDF file
            pdf.LoadFromFile(@"F:\Microsoft Visual Studio\ConsoleApp2\ConsoleApp2\Data\Sample.pdf");

            //Creare a PdfTextFindOptions instance
            PdfTextFindOptions findOptions = new PdfTextFindOptions();
            //Specify the text finding parameter
            findOptions.Parameter = TextFindParameter.WholeWord;

            //Loop through the pages in the PDF file
            foreach (PdfPageBase page in pdf.Pages)
            {
                //Create a PdfTextFinder instance
                PdfTextFinder finder = new PdfTextFinder(page);
                //Set the text finding option
                finder.Options = findOptions;
                //Find a specific text
                
                var results = finder.Find("Verbal Ability");
                //Highlight all occurrences of the specific text
                foreach (PdfTextFragment text in results)
                {
                    text.HighLight(Color.Green);
                }
            }

            //Save the result file
            pdf.SaveToFile(@"F:\Microsoft Visual Studio\ConsoleApp2\ConsoleApp2\Data\HighlightText.pdf");
            
        }
    }
}