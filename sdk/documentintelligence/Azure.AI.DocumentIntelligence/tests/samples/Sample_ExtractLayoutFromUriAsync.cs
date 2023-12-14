// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.DocumentIntelligence.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Samples
{
    public partial class DocumentIntelligenceSamples
    {
        [RecordedTest]
        public async Task ExtractLayoutFromUriAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceExtractLayoutFromUriAsync
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = uriSource
            };

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content);
            AnalyzeResult result = operation.Value;

            foreach (DocumentPage page in result.Pages)
            {
                Console.WriteLine($"Document Page {page.PageNumber} has {page.Lines.Count} line(s), {page.Words.Count} word(s)," +
                    $" and {page.SelectionMarks.Count} selection mark(s).");

                for (int i = 0; i < page.Lines.Count; i++)
                {
                    DocumentLine line = page.Lines[i];

                    Console.WriteLine($"  Line {i}:");
                    Console.WriteLine($"    Content: '{line.Content}'");

                    Console.Write("    Bounding polygon, with points ordered clockwise:");
                    for (int j = 0; j < line.Polygon.Count; j += 2)
                    {
                        Console.Write($" ({line.Polygon[j]}, {line.Polygon[j + 1]})");
                    }

                    Console.WriteLine();
                }

                for (int i = 0; i < page.SelectionMarks.Count; i++)
                {
                    DocumentSelectionMark selectionMark = page.SelectionMarks[i];

                    Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
                    Console.WriteLine($"    State: {selectionMark.State}");

                    Console.Write("    Bounding polygon, with points ordered clockwise:");
                    for (int j = 0; j < selectionMark.Polygon.Count; j++)
                    {
                        Console.Write($" ({selectionMark.Polygon[j]}, {selectionMark.Polygon[j + 1]})");
                    }

                    Console.WriteLine();
                }
            }

            for (int i = 0; i < result.Paragraphs.Count; i++)
            {
                DocumentParagraph paragraph = result.Paragraphs[i];

                Console.WriteLine($"Paragraph {i}:");
                Console.WriteLine($"  Content: {paragraph.Content}");

                if (paragraph.Role != null)
                {
                    Console.WriteLine($"  Role: {paragraph.Role}");
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
                        var handwrittenContent = result.Content.Substring(span.Offset, span.Length);
                        Console.WriteLine($"  {handwrittenContent}");
                    }
                }
            }

            for (int i = 0; i < result.Tables.Count; i++)
            {
                DocumentTable table = result.Tables[i];

                Console.WriteLine($"Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

                foreach (DocumentTableCell cell in table.Cells)
                {
                    Console.WriteLine($"  Cell ({cell.RowIndex}, {cell.ColumnIndex}) is a '{cell.Kind}' with content: {cell.Content}");
                }
            }

            #endregion
        }
    }
}
