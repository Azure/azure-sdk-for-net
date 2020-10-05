// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Samples
{
    public partial class FormRecognizerSamples : SamplesBase<FormRecognizerTestEnvironment>
    {
        [Test]
        public async Task RecognizeContentFromFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            string invoiceFilePath = FormRecognizerTestEnvironment.CreatePath("Invoice_1.pdf");

            using (FileStream stream = new FileStream(invoiceFilePath, FileMode.Open))
            {
                FormPageCollection formPages = await client.StartRecognizeContentAsync(stream).WaitForCompletionAsync();
                foreach (FormPage page in formPages)
                {
                    Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

                    for (int i = 0; i < page.Lines.Count; i++)
                    {
                        FormLine line = page.Lines[i];
                        Console.WriteLine($"    Line {i} has {line.Words.Count} word{(line.Words.Count > 1 ? "s" : "")}, and text: '{line.Text}'.");

                        Console.WriteLine("        Its bounding box is:");
                        Console.WriteLine($"        Upper left => X: {line.BoundingBox[0].X}, Y= {line.BoundingBox[0].Y}");
                        Console.WriteLine($"        Upper right => X: {line.BoundingBox[1].X}, Y= {line.BoundingBox[1].Y}");
                        Console.WriteLine($"        Lower right => X: {line.BoundingBox[2].X}, Y= {line.BoundingBox[2].Y}");
                        Console.WriteLine($"        Lower left => X: {line.BoundingBox[3].X}, Y= {line.BoundingBox[3].Y}");
                    }

                    for (int i = 0; i < page.Tables.Count; i++)
                    {
                        FormTable table = page.Tables[i];
                        Console.WriteLine($"Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");
                        foreach (FormTableCell cell in table.Cells)
                        {
                            Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) contains text: '{cell.Text}'.");
                        }
                    }
                }
            }
        }
    }
}
