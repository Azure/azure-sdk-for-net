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
        public async Task AnalyzePrebuiltDocumentFromUriAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:DocumentIntelligenceAnalyzePrebuiltDocumentFromUriAsync
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = DocumentIntelligenceTestEnvironment.CreateUri("Form_1.jpg");
#endif

            var content = new AnalyzeDocumentContent()
            {
                UrlSource = uriSource
            };

            Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-document", content);
            AnalyzeResult result = operation.Value;

            Console.WriteLine("Detected key-value pairs:");
            foreach (DocumentKeyValuePair kvp in result.KeyValuePairs)
            {
                if (kvp.Value == null)
                {
                    Console.WriteLine($"  Found key '{kvp.Key.Content}' with no value");
                }
                else
                {
                    Console.WriteLine($"  Found key '{kvp.Key.Content}' with value '{kvp.Value.Content}'");
                }
            }

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

            Console.WriteLine("Detected tables:");
            for (int i = 0; i < result.Tables.Count; i++)
            {
                DocumentTable table = result.Tables[i];

                Console.WriteLine($"  Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

                foreach (DocumentTableCell cell in table.Cells)
                {
                    Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) is a '{cell.Kind}' with content: '{cell.Content}'");
                }
            }
            #endregion
        }
    }
}
