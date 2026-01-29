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
using NUnit.Framework;

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
            // You can replace this URL with your own publicly accessible document URL.
            Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf");

            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uriSource } });

            AnalyzeResult result = operation.Value;
            MediaContent content = result.Contents!.First();
            Console.WriteLine("Markdown:");
            Console.WriteLine(content.Markdown);

            // Cast MediaContent to DocumentContent to access document-specific properties
            // DocumentContent derives from MediaContent and provides additional properties
            // to access full information about document, including Pages, Tables and many others
            DocumentContent documentContent = (DocumentContent)content;
            Console.WriteLine($"Pages: {documentContent.StartPageNumber} - {documentContent.EndPageNumber}");

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
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeUrlAsync
            Assert.IsNotNull(uriSource, "URI source should not be null");
            Assert.IsTrue(uriSource.IsAbsoluteUri, "URI should be absolute");
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");
            Console.WriteLine("Analysis operation properties verified");
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result contents should not be null");
            Console.WriteLine($"Analysis result contains {result.Contents?.Count ??  0} content(s)");
            #endregion

            // A PDF file has only one content element even if it contains multiple pages
            Console.WriteLine(content.Markdown);
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "PDF file should have exactly one content element");
            Assert.IsNotNull(content, "Content should not be null");
            Assert.IsInstanceOf<MediaContent>(content, "Content should be of type MediaContent");
            if (content is MediaContent mediaContent)
            {
                Assert.IsNotNull(mediaContent.Markdown, "Markdown content should not be null");
                Assert.IsTrue(mediaContent.Markdown.Length > 0, "Markdown content should not be empty");
                Assert.IsFalse(string.IsNullOrWhiteSpace(mediaContent.Markdown),
                    "Markdown content should not be just whitespace");
                Console.WriteLine($"Markdown content extracted successfully ({mediaContent.Markdown.Length} characters)");
            }

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

            foreach (var page in docContent.Pages)
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
            Assert.IsTrue(docContent.Tables.Count > 0, "Tables collection should not be empty");
            Console.WriteLine($"Tables collection verified: {docContent.Tables.Count} tables");

            int tableCounter = 1;
            foreach (var table in docContent.Tables)
            {
                Assert.IsNotNull(table, $"Table {tableCounter} should not be null");
                Assert.IsTrue(table.RowCount > 0, $"Table {tableCounter} should have at least 1 row, but had {table.RowCount}");
                Assert.IsTrue(table.ColumnCount > 0, $"Table {tableCounter} should have at least 1 column, but had {table.ColumnCount}");

                // Validate table cells if available
                if (table.Cells != null)
                {
                    Assert.IsTrue(table.Cells.Count > 0, $"Table {tableCounter} cells collection should not be empty when not null");

                    foreach (var cell in table.Cells)
                    {
                        Assert.IsNotNull(cell, "Table cell should not be null");
                        Assert.IsTrue(cell.RowIndex >= 0 && cell.RowIndex < table.RowCount,
                            $"Cell row index {cell.RowIndex} should be within table row count {table.RowCount}");
                        Assert.IsTrue(cell.ColumnIndex >= 0 && cell.ColumnIndex < table.ColumnCount,
                            $"Cell column index {cell.ColumnIndex} should be within table column count {table.ColumnCount}");
                    }
                }

                Console.WriteLine($"  Table {tableCounter}: {table.RowCount} rows x {table.ColumnCount} columns" +
                    (table.Cells != null ? $" ({table.Cells.Count} cells)" : ""));
                tableCounter++;
            }

            Console.WriteLine("All document properties validated successfully");
        }

        [RecordedTest]
        public async Task AnalyzeVideoUrlAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeVideoUrlAsync
            Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/videos/sdk_samples/FlightSimulator.mp4");
            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-videoSearch",
                inputs: new[] { new AnalyzeInput { Url = uriSource } });

            AnalyzeResult result = operation.Value;

            // prebuilt-videoSearch can detect video segments, so we should iterate through all segments
            int segmentIndex = 1;
            foreach (MediaContent media in result.Contents!)
            {
                // Cast MediaContent to AudioVisualContent to access audio/visual-specific properties
                // AudioVisualContent derives from MediaContent and provides additional properties
                // to access full information about audio/video, including timing, transcript phrases, and many others
                AudioVisualContent videoContent = (AudioVisualContent)media;
                Console.WriteLine($"--- Segment {segmentIndex} ---");
                Console.WriteLine("Markdown:");
                Console.WriteLine(videoContent.Markdown);

                string summary = videoContent.Fields["Summary"].Value?.ToString() ?? string.Empty;
                Console.WriteLine($"Summary: {summary}");

                Console.WriteLine($"Start: {videoContent.StartTimeMs} ms, End: {videoContent.EndTimeMs} ms");
                Console.WriteLine($"Frame size: {videoContent.Width} x {videoContent.Height}");

                Console.WriteLine("---------------------");
                segmentIndex++;
            }
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeVideoUrlAsync
            Assert.IsNotNull(operation);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Contents);
            Assert.IsTrue(result.Contents.Count > 0);
            Assert.IsTrue(result.Contents.All(c => c is AudioVisualContent), "Video analysis should return audio/visual content.");
            Assert.IsTrue(result.Contents.All(c => !string.IsNullOrWhiteSpace(c.Fields["Summary"].Value?.ToString())),
                "All video segments should include a Summary field.");
            #endregion
        }

        [RecordedTest]
        public async Task AnalyzeAudioUrlAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeAudioUrlAsync
            Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/audio/callCenterRecording.mp3");
            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-audioSearch",
                inputs: new[] { new AnalyzeInput { Url = uriSource } });

            AnalyzeResult result = operation.Value;

            // Cast MediaContent to AudioVisualContent to access audio/visual-specific properties
            // AudioVisualContent derives from MediaContent and provides additional properties
            // to access full information about audio/video, including timing, transcript phrases, and many others
            AudioVisualContent audioContent = (AudioVisualContent)result.Contents!.First();
            Console.WriteLine("Markdown:");
            Console.WriteLine(audioContent.Markdown);

            string summary = audioContent.Fields["Summary"].Value?.ToString() ?? string.Empty;
            Console.WriteLine($"Summary: {summary}");

            // Example: Access an additional field in AudioVisualContent (transcript phrases)
            if (audioContent.TranscriptPhrases != null && audioContent.TranscriptPhrases.Count > 0)
            {
                Console.WriteLine("Transcript (first two phrases):");
                foreach (TranscriptPhrase phrase in audioContent.TranscriptPhrases.Take(2))
                {
                    Console.WriteLine($"  [{phrase.Speaker}] {phrase.StartTimeMs} ms: {phrase.Text}");
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeAudioUrlAsync
            Assert.IsNotNull(operation);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Contents);
            Assert.IsTrue(result.Contents.Count > 0);
            Assert.IsInstanceOf<AudioVisualContent>(audioContent);
            Assert.IsTrue(result.Contents.All(c => c is AudioVisualContent), "Audio analysis should return audio/visual content.");
            Assert.IsTrue(result.Contents.All(c => !string.IsNullOrWhiteSpace(c.Fields["Summary"].Value?.ToString())),
                "Audio analysis should include a Summary field.");
            #endregion
        }

        [RecordedTest]
        public async Task AnalyzeImageUrlAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeImageUrlAsync
            Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/image/pieChart.jpg");
            Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-imageSearch",
                inputs: new[] { new AnalyzeInput { Url = uriSource } });

            AnalyzeResult result = operation.Value;

            MediaContent content = result.Contents!.First();
            Console.WriteLine("Markdown:");
            Console.WriteLine(content.Markdown);

            string summary = content.Fields["Summary"].Value?.ToString() ?? string.Empty;
            Console.WriteLine($"Summary: {summary}");
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeImageUrlAsync
            Assert.IsNotNull(operation);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Contents);
            Assert.IsTrue(result.Contents.Count > 0);
            Assert.IsTrue(result.Contents.All(c => !string.IsNullOrWhiteSpace(c.Fields["Summary"].Value?.ToString())),
                "Image analysis should include a Summary field.");
            #endregion
        }
    }
}
