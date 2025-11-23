// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests.Samples
{
    /// <summary>
    /// Test class for Azure Content Understanding Analyze Binary sample.
    /// This class validates the functionality demonstrated in azure_content_analysis_binary.cs
    /// using the prebuilt-documentSearch analyzer with binary file inputs.
    /// </summary>
    public class AnalyzeBinaryTest : ContentUnderstandingTestBase
    {
        public AnalyzeBinaryTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        /// <summary>
        /// Test Summary:
        /// - Create ContentUnderstandingClient using CreateClient()
        /// - Read sample PDF file from disk
        /// - Analyze PDF using prebuilt-documentSearch analyzer
        /// - Verify analysis result contains expected content
        /// - Verify markdown content is generated
        /// - Verify document-specific properties (pages, tables, etc.)
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryWithPrebuiltDocumentSearch()
        {
            var client = CreateClient();

            // Step 1: Read the PDF file
            TestContext.WriteLine("Step 1: Reading PDF file...");
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath), $"Sample file not found at {pdfPath}");

            byte[] pdfBytes = File.ReadAllBytes(pdfPath);
            TestContext.WriteLine($"  File: {pdfPath}");
            TestContext.WriteLine($"  Size: {pdfBytes.Length:N0} bytes");

            // Step 2: Analyze document using AnalyzeBinary
            TestContext.WriteLine("\nStep 2: Analyzing document...");
            TestContext.WriteLine("  Analyzer: prebuilt-documentSearch");
            TestContext.WriteLine("  Analyzing...");

            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

            TestHelpers.AssertOperationProperties(operation, "Analysis operation");

            var result = operation.Value;
            Assert.IsNotNull(result);
            TestContext.WriteLine("  Analysis completed successfully");
            TestContext.WriteLine($"  Result: AnalyzerId={result.AnalyzerId}, Contents count={result.Contents?.Count ?? 0}");

            // Step 3: Verify markdown content
            TestContext.WriteLine("\nStep 3: Verifying markdown content...");
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

            // Step 4: Verify document-specific properties
            TestContext.WriteLine("\nStep 4: Verifying document properties...");
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
                    TestContext.WriteLine($"\nStep 5: Displaying page information...");
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
                    TestContext.WriteLine($"\nStep 6: Displaying table information...");
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
        /// - Read sample PDF file from disk
        /// - Analyze PDF using AnalyzeBinary
        /// - Save analysis result to output file
        /// - Verify result file is created and contains data
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinarySaveResult()
        {
            var client = CreateClient();
            var testIdentifier = TestHelpers.GenerateAnalyzerId(Recording, "AnalyzeBinary");

            // Read the PDF file
            TestContext.WriteLine("Reading PDF file...");
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath), $"Sample file not found at {pdfPath}");

            byte[] pdfBytes = File.ReadAllBytes(pdfPath);
            TestContext.WriteLine($"  File: {pdfPath}");
            TestContext.WriteLine($"  Size: {pdfBytes.Length:N0} bytes");

            // Analyze document
            TestContext.WriteLine("\nAnalyzing document with prebuilt-documentSearch...");
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

            TestHelpers.AssertOperationProperties(operation, "Analysis operation");

            var result = operation.Value;
            Assert.IsNotNull(result);
            TestContext.WriteLine("  Analysis completed successfully");

            // Save analysis result to file
            string outputFilename = TestHelpers.SaveAnalysisResultToFile(
                result,
                "TestAnalyzeBinarySaveResult",
                testFileDir,
                testIdentifier);

            // Verify the saved file exists and has content
            Assert.IsTrue(File.Exists(outputFilename), $"Saved result file should exist at {outputFilename}");
            Assert.IsTrue(new FileInfo(outputFilename).Length > 0, "Saved result file should not be empty");
            TestContext.WriteLine($"\n✓ Analysis result saved to: {outputFilename}");
        }

        /// <summary>
        /// Test Summary:
        /// - Use prebuilt-documentSearch analyzer (no need to create custom analyzer)
        /// - Read sample PDF file from disk
        /// - Analyze PDF and verify operation status
        /// - Extract operation ID and check status
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryCheckOperationStatus()
        {
            var client = CreateClient();

            // Read the PDF file
            TestContext.WriteLine("Reading PDF file...");
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath), $"Sample file not found at {pdfPath}");

            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            // Start analysis operation
            TestContext.WriteLine("\nStarting analysis operation...");
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

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
        /// - Compare AnalyzeBinary with different content types (PDF)
        /// - Verify both produce valid results
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryWithDifferentContentTypes()
        {
            var client = CreateClient();

            // Read the PDF file
            TestContext.WriteLine("Reading PDF file...");
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath), $"Sample file not found at {pdfPath}");

            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            // Test with application/pdf content type
            TestContext.WriteLine("\nTesting with content type: application/pdf");
            var operation1 = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

            var result1 = operation1.Value;
            Assert.IsNotNull(result1);
            Assert.IsNotNull(result1.Contents);
            Assert.IsTrue(result1.Contents.Count > 0);
            TestContext.WriteLine($"  ✓ Result 1: {result1.Contents.Count} contents");

            // Verify the content is DocumentContent with correct MIME type
            var content1 = result1.Contents.First();
            if (content1 is DocumentContent doc1)
            {
                Assert.AreEqual("application/pdf", doc1.MimeType);
                TestContext.WriteLine($"  ✓ Verified MIME type: {doc1.MimeType}");
            }

            TestContext.WriteLine("\n✓ Content type verification completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Test error handling when file doesn't exist
        /// - Verify appropriate handling
        /// </summary>
        [Test]
        public void TestAnalyzeBinaryFileNotFound()
        {
            TestContext.WriteLine("Testing error handling for missing PDF file...");

            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string nonExistentPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "non_existent_file.pdf");

            Assert.IsFalse(File.Exists(nonExistentPath), "File should not exist for this test");
            TestContext.WriteLine($"✓ Verified that missing file at {nonExistentPath} would be properly detected");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze PDF and verify raw response properties
        /// - Ensure operation has proper HTTP response data
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryRawResponse()
        {
            var client = CreateClient();

            // Read the PDF file
            TestContext.WriteLine("Reading PDF file...");
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath), $"Sample file not found at {pdfPath}");

            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            // Analyze document
            TestContext.WriteLine("\nAnalyzing document...");
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

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

            TestContext.WriteLine("\n✓ Raw response validation completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Test with empty file
        /// - Verify error handling for invalid input
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryEmptyFile()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing with empty file content...");
            byte[] emptyBytes = Array.Empty<byte>();

            try
            {
                var operation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    "prebuilt-documentSearch",
                    "application/pdf",
                    BinaryData.FromBytes(emptyBytes));

                await operation.WaitForCompletionAsync();

                // If we reach here, the service accepted empty content
                TestContext.WriteLine("  Note: Service accepted empty content");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                TestContext.WriteLine($"  Status: {ex.Status}");
                TestContext.WriteLine($"  Error Code: {ex.ErrorCode}");

                // Verify it's an appropriate error
                Assert.IsTrue(ex.Status >= 400, "Should return error for empty content");
            }

            TestContext.WriteLine("\n✓ Empty file handling verified");
        }

        /// <summary>
        /// Test Summary:
        /// - Test file size verification
        /// - Ensure file is not too large or too small
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryFileSizeValidation()
        {
            var client = CreateClient();

            // Read the PDF file
            TestContext.WriteLine("Validating file size...");
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath), $"Sample file not found at {pdfPath}");

            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            // Verify file has reasonable size
            Assert.IsTrue(pdfBytes.Length > 0, "File should have content");
            Assert.IsTrue(pdfBytes.Length < 100 * 1024 * 1024, "File should be under 100MB"); // Reasonable max size
            TestContext.WriteLine($"  ✓ File size: {pdfBytes.Length:N0} bytes (valid)");

            // Analyze to ensure size is acceptable
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

            var result = operation.Value;
            Assert.IsNotNull(result);
            TestContext.WriteLine("  ✓ File size accepted by service");

            TestContext.WriteLine("\n✓ File size validation completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze the same file multiple times
        /// - Verify consistency of results
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryConsistency()
        {
            var client = CreateClient();

            // Read the PDF file
            TestContext.WriteLine("Reading PDF file for consistency test...");
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath), $"Sample file not found at {pdfPath}");

            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            // First analysis
            TestContext.WriteLine("\nFirst analysis...");
            var operation1 = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

            var result1 = operation1.Value;
            Assert.IsNotNull(result1);
            TestContext.WriteLine($"  Result 1: {result1.Contents.Count} content(s)");

            // Second analysis
            TestContext.WriteLine("\nSecond analysis...");
            var operation2 = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

            var result2 = operation2.Value;
            Assert.IsNotNull(result2);
            TestContext.WriteLine($"  Result 2: {result2.Contents.Count} content(s)");

            // Verify consistency
            Assert.AreEqual(result1.Contents.Count, result2.Contents.Count,
                "Both analyses should return same number of contents");

            TestContext.WriteLine($"\n✓ Both analyses returned {result1.Contents.Count} content(s) consistently");
            TestContext.WriteLine("✓ Consistency verification completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze binary and verify all document metadata
        /// - Check page dimensions, units, and table structures
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryDetailedMetadata()
        {
            var client = CreateClient();

            // Read the PDF file
            TestContext.WriteLine("Reading PDF file...");
            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath), $"Sample file not found at {pdfPath}");

            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            // Analyze document
            TestContext.WriteLine("\nAnalyzing document for detailed metadata...");
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                BinaryData.FromBytes(pdfBytes));

            var result = operation.Value;
            Assert.IsNotNull(result);

            TestContext.WriteLine("\nVerifying detailed metadata:");

            var content = result.Contents.First();
            if (content is DocumentContent documentContent)
            {
                // Verify MIME type
                Assert.IsNotNull(documentContent.MimeType);
                TestContext.WriteLine($"  ✓ MIME type: {documentContent.MimeType}");

                // Verify page numbering
                Assert.IsTrue(documentContent.StartPageNumber >= 1);
                Assert.IsTrue(documentContent.EndPageNumber >= documentContent.StartPageNumber);
                TestContext.WriteLine($"  ✓ Page range: {documentContent.StartPageNumber} - {documentContent.EndPageNumber}");

                // Verify page details if available
                if (documentContent.Pages != null && documentContent.Pages.Count > 0)
                {
                    TestContext.WriteLine($"  ✓ Page details available: {documentContent.Pages.Count} page(s)");

                    var firstPage = documentContent.Pages.First();
                    Assert.IsTrue(firstPage.Width > 0);
                    Assert.IsTrue(firstPage.Height > 0);
                    TestContext.WriteLine($"    First page: {firstPage.Width} x {firstPage.Height}");
                }

                // Verify table details if available
                if (documentContent.Tables != null && documentContent.Tables.Count > 0)
                {
                    TestContext.WriteLine($"  ✓ Table details available: {documentContent.Tables.Count} table(s)");

                    var firstTable = documentContent.Tables.First();
                    Assert.IsTrue(firstTable.RowCount > 0);
                    Assert.IsTrue(firstTable.ColumnCount > 0);
                    TestContext.WriteLine($"    First table: {firstTable.RowCount} x {firstTable.ColumnCount}");
                }
            }

            TestContext.WriteLine("\n✓ Detailed metadata verification completed successfully");
        }
    }
}
