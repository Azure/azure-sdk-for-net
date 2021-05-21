﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task RecognizeContentFromUri()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            FormRecognizerClient client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerSampleRecognizeContentFromUri
#if SNIPPET
            Uri formUri = <formUri>;
#else
            Uri formUri = FormRecognizerTestEnvironment.CreateUri("Invoice_1.pdf");
#endif

            Response<FormPageCollection> response = await client.StartRecognizeContentFromUriAsync(formUri).WaitForCompletionAsync();
            FormPageCollection formPages = response.Value;

            foreach (FormPage page in formPages)
            {
                Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

                for (int i = 0; i < page.Lines.Count; i++)
                {
                    FormLine line = page.Lines[i];
                    Console.WriteLine($"  Line {i} has {line.Words.Count} {(line.Words.Count == 1 ? "word" : "words")}, and text: '{line.Text}'.");

                    if (line.Appearance != null)
                    {
                        // Check the style and style confidence to see if text is handwritten.
                        // Note that value '0.8' is used as an example.
                        if (line.Appearance.Style.Name == TextStyleName.Handwriting && line.Appearance.Style.Confidence > 0.8)
                        {
                            Console.WriteLine("The text is handwritten");
                        }
                    }

                    Console.WriteLine("    Its bounding box is:");
                    Console.WriteLine($"    Upper left => X: {line.BoundingBox[0].X}, Y= {line.BoundingBox[0].Y}");
                    Console.WriteLine($"    Upper right => X: {line.BoundingBox[1].X}, Y= {line.BoundingBox[1].Y}");
                    Console.WriteLine($"    Lower right => X: {line.BoundingBox[2].X}, Y= {line.BoundingBox[2].Y}");
                    Console.WriteLine($"    Lower left => X: {line.BoundingBox[3].X}, Y= {line.BoundingBox[3].Y}");
                }

                for (int i = 0; i < page.Tables.Count; i++)
                {
                    FormTable table = page.Tables[i];
                    Console.WriteLine($"  Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");
                    foreach (FormTableCell cell in table.Cells)
                    {
                        Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) contains text: '{cell.Text}'.");
                    }
                }

                for (int i = 0; i < page.SelectionMarks.Count; i++)
                {
                    FormSelectionMark selectionMark = page.SelectionMarks[i];
                    Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
                    Console.WriteLine("    Its bounding box is:");
                    Console.WriteLine($"      Upper left => X: {selectionMark.BoundingBox[0].X}, Y= {selectionMark.BoundingBox[0].Y}");
                    Console.WriteLine($"      Upper right => X: {selectionMark.BoundingBox[1].X}, Y= {selectionMark.BoundingBox[1].Y}");
                    Console.WriteLine($"      Lower right => X: {selectionMark.BoundingBox[2].X}, Y= {selectionMark.BoundingBox[2].Y}");
                    Console.WriteLine($"      Lower left => X: {selectionMark.BoundingBox[3].X}, Y= {selectionMark.BoundingBox[3].Y}");
                }
            }

            #endregion
        }
    }
}
