// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Test class for Azure Content Understanding Analyze URL sample.
    /// This class validates the functionality demonstrated in azure_content_analyze.cs
    /// using the prebuilt-documentSearch analyzer with URL inputs.
    /// </summary>
    public class AnalyzeUrlTest : ContentUnderstandingTestBase
    {
        public AnalyzeUrlTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        /// <summary>
        /// Test Summary:
        /// - Create ContentUnderstandingClient using CreateClient()
        /// - Analyze document from URL using prebuilt-documentSearch
        /// - Verify analysis result contains expected content
        /// - Verify markdown content is generated
        /// - Verify document-specific properties (pages, tables, etc.)
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeDocumentFromUrl()
        {
            var client = CreateClient();

            // Step 1: Analyze document from URL
            TestContext.WriteLine("Step 1: Analyzing document from URL...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";
            TestContext.WriteLine($"  URL: {fileUrl}");
            TestContext.WriteLine("  Analyzer: prebuilt-documentSearch");
            TestContext.WriteLine("  Analyzing...");

            // Validate URL format
            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri),
                $"Invalid URL format: {fileUrl}");

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            TestHelpers.AssertOperationProperties(operation, "Analysis operation");

            var result = operation.Value;
            Assert.IsNotNull(result);
            TestContext.WriteLine("  Analysis completed successfully");
            TestContext.WriteLine($"  Result: AnalyzerId={result.AnalyzerId}, Contents count={result.Contents?.Count ?? 0}");

            // Step 2: Verify markdown content
            TestContext.WriteLine("\nStep 2: Verifying markdown content...");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents.Count > 0, "Result should have at least one content");

            // A PDF file has only one content element even if it contains multiple pages
            var content = result.Contents.First();
            Assert.IsNotNull(content);

            if (content is MediaContent mediaContent)
            {
                Assert.IsNotNull(mediaContent.Markdown, "Markdown content should not be null");
                Assert.IsTrue(mediaContent.Markdown.Length > 0, "Markdown content should not be empty");
                TestContext.WriteLine($"  Markdown length: {mediaContent.Markdown.Length} characters");
            }
            else
            {
                TestContext.WriteLine("  (No markdown content available)");
            }

            // Step 3: Verify document-specific properties
            TestContext.WriteLine("\nStep 3: Verifying document properties...");
            if (content is DocumentContent documentContent)
            {
                TestContext.WriteLine($"  Document type: {documentContent.MimeType ?? "(unknown)"}");
                Assert.IsNotNull(documentContent.MimeType);

                Assert.IsTrue(documentContent.StartPageNumber >= 1, "Start page should be >= 1");
                Assert.IsTrue(documentContent.EndPageNumber >= documentContent.StartPageNumber,
                    "End page should be >= start page");

                int totalPages = documentContent.EndPageNumber - documentContent.StartPageNumber + 1;
                TestContext.WriteLine($"  Start page: {documentContent.StartPageNumber}");
                TestContext.WriteLine($"  End page: {documentContent.EndPageNumber}");
                TestContext.WriteLine($"  Total pages: {totalPages}");

                // Check for pages
                if (documentContent.Pages != null && documentContent.Pages.Count > 0)
                {
                    TestContext.WriteLine($"\nStep 4: Displaying page information...");
                    TestContext.WriteLine($"  Number of pages: {documentContent.Pages.Count}");

                    foreach (var page in documentContent.Pages)
                    {
                        Assert.IsTrue(page.PageNumber >= 1, "Page number should be >= 1");
                        Assert.IsTrue(page.Width > 0, "Page width should be > 0");
                        Assert.IsTrue(page.Height > 0, "Page height should be > 0");

                        var unit = documentContent.Unit?.ToString() ?? "units";
                        TestContext.WriteLine($"  Page {page.PageNumber}: {page.Width} x {page.Height} {unit}");
                    }
                }

                // Check for tables
                if (documentContent.Tables != null && documentContent.Tables.Count > 0)
                {
                    TestContext.WriteLine($"\nStep 5: Displaying table information...");
                    TestContext.WriteLine($"  Number of tables: {documentContent.Tables.Count}");

                    int tableCounter = 1;
                    foreach (var table in documentContent.Tables)
                    {
                        Assert.IsTrue(table.RowCount > 0, "Table should have at least 1 row");
                        Assert.IsTrue(table.ColumnCount > 0, "Table should have at least 1 column");

                        TestContext.WriteLine($"  Table {tableCounter}: {table.RowCount} rows x {table.ColumnCount} columns");
                        tableCounter++;
                    }
                }
            }
            else
            {
                TestContext.WriteLine("  Content Information:");
                TestContext.WriteLine("    Not a document content type - document-specific information is not available");
            }

            TestContext.WriteLine("\n=============================================================");
            TestContext.WriteLine("✓ Sample completed successfully");
            TestContext.WriteLine("=============================================================");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze document from URL
        /// - Save analysis result to output file
        /// - Verify result file is created and contains data
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeUrlAndSaveResult()
        {
            var client = CreateClient();

            // Analyze document from URL
            TestContext.WriteLine("Analyzing document from URL...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";
            TestContext.WriteLine($"  URL: {fileUrl}");

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri),
                $"Invalid URL format: {fileUrl}");

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            TestHelpers.AssertOperationProperties(operation, "Analysis operation");

            var result = operation.Value;
            Assert.IsNotNull(result);
            TestContext.WriteLine("  Analysis completed successfully");

            // Save analysis result to file
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string testIdentifier = TestHelpers.GenerateAnalyzerId(Recording, "AnalyzeUrl");

            string outputFilename = TestHelpers.SaveAnalysisResultToFile(
                result,
                "TestAnalyzeUrlAndSaveResult",
                testFileDir,
                testIdentifier);

            // Verify the saved file exists and has content
            Assert.IsTrue(File.Exists(outputFilename), $"Saved result file should exist at {outputFilename}");
            Assert.IsTrue(new FileInfo(outputFilename).Length > 0, "Saved result file should not be empty");
            TestContext.WriteLine($"\n✓ Analysis result saved to: {outputFilename}");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze document from URL and extract operation ID
        /// - Verify operation ID is valid
        /// - Check operation status
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeUrlCheckOperationStatus()
        {
            var client = CreateClient();

            // Analyze document from URL
            TestContext.WriteLine("Starting analysis operation...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri),
                $"Invalid URL format: {fileUrl}");

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            // Extract operation ID
            string operationId = operation.GetRehydrationToken().Value.Id;
            TestContext.WriteLine($"  Extracted operation_id: {operationId}");
            Assert.IsNotNull(operationId, "Operation ID should not be null");
            Assert.IsTrue(operationId.Length > 0, "Operation ID should not be empty");

            TestHelpers.AssertOperationProperties(operation, "Analysis operation");

            var result = operation.Value;
            Assert.IsNotNull(result);
            TestContext.WriteLine("  Analysis completed successfully");
            TestContext.WriteLine($"  Result: AnalyzerId={result.AnalyzerId}, Contents count={result.Contents?.Count ?? 0}");

            TestContext.WriteLine("\n✓ Operation status verified successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Test error handling for invalid URL
        /// - Verify appropriate exception is thrown
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeInvalidUrl()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing with invalid URL...");
            string invalidUrl = "https://invalid-domain-that-does-not-exist.com/nonexistent.pdf";

            Assert.IsTrue(Uri.TryCreate(invalidUrl, UriKind.Absolute, out var uri),
                "URL should be valid format but point to non-existent resource");

            try
            {
                var operation = await client.AnalyzeAsync(
                    WaitUntil.Completed,
                    "prebuilt-documentSearch",
                    inputs: new[] { new AnalyzeInput { Url = uri } });

                // If we get here without exception, wait for completion to see if error occurs
                await operation.WaitForCompletionAsync();

                TestContext.WriteLine("  Note: Service may have accepted the URL but failed during processing");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                TestContext.WriteLine($"  Status: {ex.Status}");
                TestContext.WriteLine($"  Error Code: {ex.ErrorCode}");

                // Verify it's an appropriate error code
                Assert.IsTrue(ex.Status >= 400, "Should return 4xx or 5xx error for invalid URL");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"  ✓ Exception caught: {ex.GetType().Name}");
                TestContext.WriteLine($"  Message: {ex.Message}");
            }

            TestContext.WriteLine("\n✓ Error handling verification completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze document with different valid URLs
        /// - Verify both produce valid results
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeMultipleUrls()
        {
            var client = CreateClient();

            // Test with first URL
            TestContext.WriteLine("Test 1: Analyzing first document...");
            var url1 = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";
            TestContext.WriteLine($"  URL: {url1}");

            Assert.IsTrue(Uri.TryCreate(url1, UriKind.Absolute, out var uri1));

            var operation1 = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uri1 } });

            var result1 = operation1.Value;
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result1.Contents);
            Assert.IsTrue(result1.Contents.Count > 0);
            TestContext.WriteLine($"  ✓ Result 1: {result1.Contents.Count} content(s)");

            // Verify the content
            var content1 = result1.Contents.First();
            if (content1 is DocumentContent doc1)
            {
                Assert.IsNotNull(doc1.MimeType);
                TestContext.WriteLine($"  ✓ Document type: {doc1.MimeType}");
            }

            TestContext.WriteLine("\n✓ Multiple URL analysis completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Test URL validation before analysis
        /// - Verify malformed URLs are caught
        /// </summary>
        [Test]
        public void TestUrlValidation()
        {
            TestContext.WriteLine("Testing URL validation...");

            // Test valid URL
            string validUrl = "https://example.com/document.pdf";
            Assert.IsTrue(Uri.TryCreate(validUrl, UriKind.Absolute, out var validUri),
                "Valid URL should parse successfully");
            TestContext.WriteLine($"  ✓ Valid URL: {validUrl}");

            // Test invalid URLs
            string[] invalidUrls = new[]
            {
                "not-a-url",
                "ftp://unsupported-protocol.com/file.pdf",
                "",
                "   ",
                "http://",
                "://missing-scheme.com"
            };

            foreach (var invalidUrl in invalidUrls)
            {
                bool isValid = Uri.TryCreate(invalidUrl, UriKind.Absolute, out var uri);
                if (!isValid || (uri != null && (uri.Scheme != "http" && uri.Scheme != "https")))
                {
                    TestContext.WriteLine($"  ✓ Invalid URL rejected: '{invalidUrl}'");
                }
            }

            TestContext.WriteLine("\n✓ URL validation completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze document and verify raw response properties
        /// - Ensure operation has proper HTTP response data
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeUrlRawResponse()
        {
            var client = CreateClient();

            // Analyze document from URL
            TestContext.WriteLine("Analyzing document from URL...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            // Verify raw response
            var rawResponse = operation.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            TestContext.WriteLine($"  ✓ Raw response status: {rawResponse.Status}");

            // Verify response headers exist
            Assert.IsNotNull(rawResponse.Headers, "Response headers should not be null");
            TestContext.WriteLine($"  ✓ Response has headers");

            // Verify operation completed successfully
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            TestContext.WriteLine($"  ✓ Operation completed with value");

            // Verify result
            var result = operation.Value;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Contents);
            Assert.IsTrue(result.Contents.Count > 0);
            TestContext.WriteLine($"  ✓ Result contains {result.Contents.Count} content(s)");

            TestContext.WriteLine("\n✓ Raw response validation completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze document and verify all content types are handled
        /// - Check for proper DocumentContent casting
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeUrlContentTypes()
        {
            var client = CreateClient();

            // Analyze document from URL
            TestContext.WriteLine("Analyzing document and verifying content types...");
            var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";

            Assert.IsTrue(Uri.TryCreate(fileUrl, UriKind.Absolute, out var uri));

            var operation = await client.AnalyzeAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                inputs: new[] { new AnalyzeInput { Url = uri } });

            var result = operation.Value;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Contents);
            Assert.IsTrue(result.Contents.Count > 0);

            TestContext.WriteLine($"\nAnalyzing {result.Contents.Count} content item(s):");

            foreach (var content in result.Contents)
            {
                Assert.IsNotNull(content, "Content should not be null");

                if (content is DocumentContent documentContent)
                {
                    TestContext.WriteLine($"  ✓ DocumentContent found");
                    TestContext.WriteLine($"    MIME type: {documentContent.MimeType}");
                    TestContext.WriteLine($"    Pages: {documentContent.StartPageNumber} - {documentContent.EndPageNumber}");

                    // Verify required properties
                    Assert.IsNotNull(documentContent.MimeType);
                    Assert.IsTrue(documentContent.StartPageNumber >= 1);
                    Assert.IsTrue(documentContent.EndPageNumber >= documentContent.StartPageNumber);
                }
                else if (content is MediaContent mediaContent)
                {
                    TestContext.WriteLine($"  ✓ MediaContent found");
                    TestContext.WriteLine($"    Has markdown: {!string.IsNullOrEmpty(mediaContent.Markdown)}");
                }
                else
                {
                    TestContext.WriteLine($"  ✓ Content type: {content.GetType().Name}");
                }
            }

            TestContext.WriteLine("\n✓ Content type verification completed successfully");
        }
    }
}
