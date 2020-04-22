// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
using Azure.AI.FormRecognizer.Tests;
using Azure.Core.Testing;
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
                Response<IReadOnlyList<FormPage>> formPages = await client.StartRecognizeContent(stream).WaitForCompletionAsync();
                foreach (FormPage page in formPages.Value)
                {
                    Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

                    for (int i = 0; i < page.Lines.Count; i++)
                    {
                        FormLine line = page.Lines[i];
                        Console.WriteLine($"    Line {i} has {line.Words.Count} word{(line.Words.Count > 1 ? "s" : "")}, and text: '{line.Text}'.");
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
