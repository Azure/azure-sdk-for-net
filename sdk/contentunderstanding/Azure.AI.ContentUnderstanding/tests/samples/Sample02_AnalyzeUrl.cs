// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task AnalyzeUrlAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeUrlAsync
#if SNIPPET
            Uri uriSource = new Uri("<uriSource>");
#else
            Uri uriSource = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
#endif
            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uriSource } });

            AnalyzeResult result = operation.Value;
            #endregion

            #region Snippet:ContentUnderstandingExtractMarkdown
            // A PDF file has only one content element even if it contains multiple pages
            MediaContent? content = null;
            if (result.Contents == null || result.Contents.Count == 0)
            {
                Console.WriteLine("(No content returned from analysis)");
            }
            else
            {
                content = result.Contents.First();
                if (!string.IsNullOrEmpty(content.Markdown))
                {
                    Console.WriteLine(content.Markdown);
                }
                else
                {
                    Console.WriteLine("(No markdown content available)");
                }
            }
            #endregion

            #region Snippet:ContentUnderstandingAccessDocumentProperties
            // Check if this is document content to access document-specific properties
            if (content is DocumentContent documentContent)
            {
                Console.WriteLine($"Document type: {documentContent.MimeType ?? "(unknown)"}");
                Console.WriteLine($"Start page: {documentContent.StartPageNumber}");
                Console.WriteLine($"End page: {documentContent.EndPageNumber}");
                Console.WriteLine($"Total pages: {documentContent.EndPageNumber - documentContent.StartPageNumber + 1}");

                // Check for pages
                if (documentContent.Pages != null && documentContent.Pages.Count > 0)
                {
                    Console.WriteLine($"Number of pages: {documentContent.Pages.Count}");
                    foreach (var page in documentContent.Pages)
                    {
                        var unit = documentContent.Unit?.ToString() ?? "units";
                        Console.WriteLine($"  Page {page.PageNumber}: {page.Width} x {page.Height} {unit}");
                    }
                }

                // Check for tables
                if (documentContent.Tables != null && documentContent.Tables.Count > 0)
                {
                    Console.WriteLine($"Number of tables: {documentContent.Tables.Count}");
                    int tableCounter = 1;
                    foreach (var table in documentContent.Tables)
                    {
                        Console.WriteLine($"  Table {tableCounter}: {table.RowCount} rows x {table.ColumnCount} columns");
                        tableCounter++;
                    }
                }
            }
            #endregion
        }
    }
}
