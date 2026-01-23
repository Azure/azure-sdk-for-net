// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task AnalyzeBinaryAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeBinaryAsync
#if SNIPPET
            // Replace with the path to your local document file.
            string filePath = "<localDocumentFilePath>";
#else
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
#endif
            byte[] fileBytes = File.ReadAllBytes(filePath);
            BinaryData binaryData = BinaryData.FromBytes(fileBytes);

            Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                binaryData);

            AnalyzeResult result = operation.Value;
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeBinaryAsync
            Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
            Assert.IsTrue(fileBytes.Length > 0, "File should not be empty");
            Assert.IsNotNull(binaryData, "Binary data should not be null");
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");
            Console.WriteLine("Analysis operation properties verified");
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result contents should not be null");
            Console.WriteLine($"Analysis result contains {result.Contents?.Count ??  0} content(s)");
            #endregion

            #region Snippet:ContentUnderstandingExtractMarkdown
            // A PDF file has only one content element even if it contains multiple pages
            MediaContent content = result.Contents!.First();
            Console.WriteLine(content.Markdown);
            #endregion

            #region Assertion:ContentUnderstandingExtractMarkdown
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "PDF file should have exactly one content element");
            Assert.IsNotNull(content, "Content should not be null");
            Assert.IsInstanceOf<MediaContent>(content, "Content should be of type MediaContent");
            Assert.IsNotNull(content.Markdown, "Markdown content should not be null");
            Assert.IsTrue(content.Markdown.Length > 0, "Markdown content should not be empty");
            Assert.IsFalse(string.IsNullOrWhiteSpace(content.Markdown),
                "Markdown content should not be just whitespace");
            Console.WriteLine($"Markdown content extracted successfully ({content.Markdown.Length} characters)");
            #endregion

            #region Snippet:ContentUnderstandingAccessDocumentProperties
            // Check if this is document content to access document-specific properties
            if (content is DocumentContent documentContent)
            {
                Console.WriteLine($"Document type: {documentContent.MimeType ?? "(unknown)"}");
                Console.WriteLine($"Start page: {documentContent.StartPageNumber}");
                Console.WriteLine($"End page: {documentContent.EndPageNumber}");

                // Check for pages
                if (documentContent.Pages != null && documentContent.Pages.Count > 0)
                {
                    Console.WriteLine($"Number of pages: {documentContent.Pages.Count}");
                    foreach (DocumentPage page in documentContent.Pages)
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
                    foreach (DocumentTable table in documentContent.Tables)
                    {
                        Console.WriteLine($"  Table {tableCounter}: {table.RowCount} rows x {table.ColumnCount} columns");
                        tableCounter++;
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingAccessDocumentProperties
            Assert.IsNotNull(content, "Content should not be null for document properties validation");
            Assert.IsInstanceOf<DocumentContent>(content, "Content should be of type DocumentContent");
            DocumentContent docContent = (DocumentContent)content;

            // Validate MIME type
            Assert.IsNotNull(docContent.MimeType, "MIME type should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(docContent.MimeType), "MIME type should not be empty");
            Assert.AreEqual("application/pdf", docContent.MimeType, "MIME type should be application/pdf");
            Console.WriteLine($"MIME type verified: {docContent.MimeType}");

            // Validate page numbers
            Assert.IsTrue(docContent.StartPageNumber >= 1, "Start page should be >= 1");
            Assert.IsTrue(docContent.EndPageNumber >= docContent.StartPageNumber,
                "End page should be >= start page");
            int totalPages = docContent.EndPageNumber - docContent.StartPageNumber + 1;
            Assert.IsTrue(totalPages > 0, "Total pages should be positive");
            Console.WriteLine($"Page range verified: {docContent.StartPageNumber} to {docContent.EndPageNumber} ({totalPages} pages)");

            // Validate pages collection
            Assert.IsNotNull(docContent.Pages, "Pages collection should not be null");
            Assert.IsTrue(docContent.Pages.Count > 0, "Pages collection should not be empty");
            Assert.AreEqual(totalPages, docContent.Pages.Count,
                "Pages collection count should match calculated total pages");
            Console.WriteLine($"Pages collection verified: {docContent.Pages.Count} pages");

            // Track page numbers to ensure they're sequential and unique
            var pageNumbers = new System.Collections.Generic.HashSet<int>();

            foreach (DocumentPage page in docContent.Pages)
            {
                Assert.IsNotNull(page, "Page object should not be null");
                Assert.IsTrue(page.PageNumber >= 1, "Page number should be >= 1");
                Assert.IsTrue(page.PageNumber >= docContent.StartPageNumber &&
                            page.PageNumber <= docContent.EndPageNumber,
                    $"Page number {page.PageNumber} should be within document range [{docContent.StartPageNumber}, {docContent.EndPageNumber}]");
                Assert.IsTrue(page.Width > 0, $"Page {page.PageNumber} width should be > 0, but was {page.Width}");
                Assert.IsTrue(page.Height > 0, $"Page {page.PageNumber} height should be > 0, but was {page.Height}");

                // Ensure page numbers are unique
                Assert.IsTrue(pageNumbers.Add(page.PageNumber),
                    $"Page number {page.PageNumber} appears multiple times");

                Console.WriteLine($"  Page {page.PageNumber}: {page.Width} x {page.Height} {docContent.Unit?.ToString() ?? "units"}");
            }

            // Validate tables collection
            Assert.IsNotNull(docContent.Tables, "Tables collection should not be null");
            Console.WriteLine($"Tables collection verified: {docContent.Tables.Count} tables");

            int tableIndex = 1;
            foreach (DocumentTable table in docContent.Tables)
            {
                Assert.IsNotNull(table, $"Table {tableIndex} should not be null");
                Assert.IsTrue(table.RowCount > 0, $"Table {tableIndex} should have at least 1 row, but had {table.RowCount}");
                Assert.IsTrue(table.ColumnCount > 0, $"Table {tableIndex} should have at least 1 column, but had {table.ColumnCount}");

                // Validate table cells if available
                if (table.Cells != null)
                {
                    Assert.IsTrue(table.Cells.Count > 0, $"Table {tableIndex} cells collection should not be empty when not null");

                    foreach (var cell in table.Cells)
                    {
                        Assert.IsNotNull(cell, "Table cell should not be null");
                        Assert.IsTrue(cell.RowIndex >= 0 && cell.RowIndex < table.RowCount,
                            $"Cell row index {cell.RowIndex} should be within table row count {table.RowCount}");
                        Assert.IsTrue(cell.ColumnIndex >= 0 && cell.ColumnIndex < table.ColumnCount,
                            $"Cell column index {cell.ColumnIndex} should be within table column count {table.ColumnCount}");
                        Assert.IsTrue(cell.RowSpan >= 1, $"Cell row span should be >= 1, but was {cell.RowSpan}");
                        Assert.IsTrue(cell.ColumnSpan >= 1, $"Cell column span should be >= 1, but was {cell.ColumnSpan}");
                    }
                }

                Console.WriteLine($"  Table {tableIndex}: {table.RowCount} rows x {table.ColumnCount} columns" +
                    (table.Cells != null ? $" ({table.Cells.Count} cells)" : ""));
                tableIndex++;
            }

            Console.WriteLine("All document properties validated successfully");
            #endregion
        }
    }
}
