// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.DocumentAnalysis.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Samples
{
    public partial class DocumentAnalysisSamples
    {
        [RecordedTest]
        public async Task AnalyzePrebuiltDocumentFromFileAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            DocumentAnalysisClient client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:FormRecognizerAnalyzePrebuiltDocumentFromFileAsync
#if SNIPPET
            string filePath = "<filePath>";
#else
            string filePath = DocumentAnalysisTestEnvironment.CreatePath("Form_1.jpg");
#endif
            using var stream = new FileStream(filePath, FileMode.Open);

            AnalyzeDocumentOperation operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-document", stream);
            AnalyzeResult result = operation.Value;

            Console.WriteLine("Detected key-value pairs:");

            foreach (DocumentKeyValuePair kvp in result.KeyValuePairs)
            {
                if (kvp.Value == null)
                {
                    Console.WriteLine($"  Found key with no value: '{kvp.Key.Content}'");
                }
                else
                {
                    Console.WriteLine($"  Found key-value pair: '{kvp.Key.Content}' and '{kvp.Value.Content}'");
                }
            }

            foreach (DocumentPage page in result.Pages)
            {
                Console.WriteLine($"Document Page {page.PageNumber} has {page.Lines.Count} line(s), {page.Words.Count} word(s),");
                Console.WriteLine($"and {page.SelectionMarks.Count} selection mark(s).");

                for (int i = 0; i < page.Lines.Count; i++)
                {
                    DocumentLine line = page.Lines[i];
                    Console.WriteLine($"  Line {i} has content: '{line.Content}'.");

                    Console.WriteLine($"    Its bounding polygon (points ordered clockwise):");

                    for (int j = 0; j < line.BoundingPolygon.Count; j++)
                    {
                        Console.WriteLine($"      Point {j} => X: {line.BoundingPolygon[j].X}, Y: {line.BoundingPolygon[j].Y}");
                    }
                }

                for (int i = 0; i < page.SelectionMarks.Count; i++)
                {
                    DocumentSelectionMark selectionMark = page.SelectionMarks[i];

                    Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
                    Console.WriteLine($"    Its bounding polygon (points ordered clockwise):");

                    for (int j = 0; j < selectionMark.BoundingPolygon.Count; j++)
                    {
                        Console.WriteLine($"      Point {j} => X: {selectionMark.BoundingPolygon[j].X}, Y: {selectionMark.BoundingPolygon[j].Y}");
                    }
                }
            }

            foreach (DocumentStyle style in result.Styles)
            {
                // Check the style and style confidence to see if text is handwritten.
                // Note that value '0.8' is used as an example.

                bool isHandwritten = style.IsHandwritten.HasValue && style.IsHandwritten == true;

                if (isHandwritten && style.Confidence > 0.8)
                {
                    Console.WriteLine($"Handwritten content found:");

                    foreach (DocumentSpan span in style.Spans)
                    {
                        Console.WriteLine($"  Content: {result.Content.Substring(span.Index, span.Length)}");
                    }
                }
            }

            Console.WriteLine("The following tables were extracted:");

            for (int i = 0; i < result.Tables.Count; i++)
            {
                DocumentTable table = result.Tables[i];
                Console.WriteLine($"  Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

                foreach (DocumentTableCell cell in table.Cells)
                {
                    Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) has kind '{cell.Kind}' and content: '{cell.Content}'.");
                }
            }

            #endregion
        }
    }
}
