// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests.Samples
{
    /// <summary>
    /// Test class for Azure Content Understanding Analyze Binary Raw JSON sample.
    /// This class validates the functionality demonstrated in azure_pdf_analysis.cs
    /// for analyzing documents and accessing raw JSON responses using protocol methods.
    /// IMPORTANT: This tests the protocol method approach for accessing raw JSON.
    /// For production use, prefer the object model approach tested in AnalyzeBinaryTest.
    /// </summary>
    public class AnalyzeBinaryRawJsonTest : ContentUnderstandingTestBase
    {
        public AnalyzeBinaryRawJsonTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        /// <summary>
        /// Test Summary:
        /// - Create ContentUnderstandingClient using CreateClient()
        /// - Read sample PDF file from disk
        /// - Analyze PDF using protocol method to get raw JSON response
        /// - Parse and validate the raw JSON structure
        /// - Save raw JSON to file
        /// - Verify key JSON elements exist
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzeBinaryWithRawJsonResponse()
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

            // Step 2: Analyze document using protocol method
            TestContext.WriteLine("\nStep 2: Analyzing document with protocol method...");
            TestContext.WriteLine("  Analyzer: prebuilt-documentSearch");
            TestContext.WriteLine("  Using protocol method to access raw JSON response");

            BinaryData responseData;
            try
            {
                // Use the protocol method to get raw response
                var operation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    "prebuilt-documentSearch",
                    "application/pdf",
                    RequestContent.Create(BinaryData.FromBytes(pdfBytes)));

                responseData = operation.Value;
                Assert.IsNotNull(responseData, "Response data should not be null");
                TestContext.WriteLine("  ✓ Analysis completed successfully");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  Failed to analyze document: {ex.Message}");
                throw;
            }

            // Step 3: Parse and validate the raw JSON
            TestContext.WriteLine("\nStep 3: Processing raw JSON response...");

            using var jsonDocument = JsonDocument.Parse(responseData);
            Assert.IsNotNull(jsonDocument, "JSON document should not be null");
            Assert.IsNotNull(jsonDocument.RootElement, "JSON root element should not be null");

            // Pretty-print the JSON
            string prettyJson = JsonSerializer.Serialize(
                jsonDocument.RootElement,
                new JsonSerializerOptions { WriteIndented = true });

            Assert.IsTrue(prettyJson.Length > 0, "Pretty JSON should not be empty");
            TestContext.WriteLine($"  ✓ Raw JSON parsed successfully ({prettyJson.Length:N0} characters)");

            // Step 4: Save to file
            TestContext.WriteLine("\nStep 4: Saving raw JSON to file...");
            string outputDir = Path.Combine(testFileDir, "TestOutput");
            Directory.CreateDirectory(outputDir);

            string testIdentifier = TestHelpers.GenerateAnalyzerId(Recording, "RawJson");
            string outputFileName = $"analyze_result_{testIdentifier}.json";
            string outputPath = Path.Combine(outputDir, outputFileName);

            File.WriteAllText(outputPath, prettyJson);

            Assert.IsTrue(File.Exists(outputPath), $"Output file should exist at {outputPath}");
            TestContext.WriteLine($"  ✓ Raw JSON saved to: {outputPath}");

            // Step 5: Validate key JSON structure
            TestContext.WriteLine("\nStep 5: Validating JSON structure...");

            // Verify root structure
            Assert.IsTrue(jsonDocument.RootElement.TryGetProperty("result", out var resultElement),
                "JSON should have 'result' property");
            TestContext.WriteLine("  ✓ Found 'result' property");

            // Verify analyzer ID
            if (resultElement.TryGetProperty("analyzerId", out var analyzerIdElement))
            {
                string analyzerId = analyzerIdElement.GetString();
                Assert.IsNotNull(analyzerId, "Analyzer ID should not be null");
                TestContext.WriteLine($"  ✓ Analyzer ID: {analyzerId}");
            }

            // Verify contents array
            Assert.IsTrue(resultElement.TryGetProperty("contents", out var contentsElement),
                "Result should have 'contents' property");
            Assert.AreEqual(JsonValueKind.Array, contentsElement.ValueKind,
                "Contents should be an array");
            Assert.IsTrue(contentsElement.GetArrayLength() > 0,
                "Contents array should not be empty");
            TestContext.WriteLine($"  ✓ Contents count: {contentsElement.GetArrayLength()}");

            // Verify first content element
            var firstContent = contentsElement[0];

            if (firstContent.TryGetProperty("kind", out var kindElement))
            {
                string kind = kindElement.GetString();
                TestContext.WriteLine($"  ✓ Content kind: {kind}");
            }

            if (firstContent.TryGetProperty("mimeType", out var mimeTypeElement))
            {
                string mimeType = mimeTypeElement.GetString();
                Assert.AreEqual("application/pdf", mimeType, "MIME type should be application/pdf");
                TestContext.WriteLine($"  ✓ MIME type: {mimeType}");
            }

            TestContext.WriteLine("\n=============================================================");
            TestContext.WriteLine("✓ Raw JSON analysis completed successfully");
            TestContext.WriteLine("=============================================================");
        }

        /// <summary>
        /// Test Summary:
        /// - Use protocol method to get raw response
        /// - Verify response is valid BinaryData
        /// - Verify can be parsed as JSON
        /// </summary>
        [RecordedTest]
        public async Task TestProtocolMethodReturnsValidBinaryData()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing protocol method returns valid BinaryData...");

            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath));
            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                RequestContent.Create(BinaryData.FromBytes(pdfBytes)));

            var responseData = operation.Value;

            // Verify BinaryData properties
            Assert.IsNotNull(responseData, "BinaryData should not be null");
            Assert.IsTrue(responseData.ToMemory().Length > 0, "BinaryData should have content");
            TestContext.WriteLine($"  ✓ BinaryData size: {responseData.ToMemory().Length} bytes");

            // Verify can be parsed as JSON
            Assert.DoesNotThrow(() => JsonDocument.Parse(responseData),
                "BinaryData should be valid JSON");
            TestContext.WriteLine("  ✓ BinaryData is valid JSON");

            // Verify can be converted to string
            string jsonString = responseData.ToString();
            Assert.IsTrue(jsonString.Length > 0, "JSON string should not be empty");
            TestContext.WriteLine($"  ✓ JSON string length: {jsonString.Length} characters");

            TestContext.WriteLine("\n✓ BinaryData validation completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Parse raw JSON response
        /// - Validate all expected top-level properties exist
        /// - Verify property types are correct
        /// </summary>
        [RecordedTest]
        public async Task TestRawJsonStructureValidation()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing raw JSON structure validation...");

            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath));
            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                RequestContent.Create(BinaryData.FromBytes(pdfBytes)));

            var responseData = operation.Value;

            using var jsonDocument = JsonDocument.Parse(responseData);
            var root = jsonDocument.RootElement;

            TestContext.WriteLine("\nValidating JSON structure:");

            // Validate top-level structure
            Assert.IsTrue(root.TryGetProperty("result", out var result),
                "Should have 'result' property");
            TestContext.WriteLine("  ✓ Has 'result' property");

            // Validate result properties
            Assert.IsTrue(result.TryGetProperty("analyzerId", out var analyzerId),
                "Result should have 'analyzerId'");
            Assert.AreEqual(JsonValueKind.String, analyzerId.ValueKind);
            TestContext.WriteLine($"  ✓ Has 'analyzerId': {analyzerId.GetString()}");

            Assert.IsTrue(result.TryGetProperty("contents", out var contents),
                "Result should have 'contents'");
            Assert.AreEqual(JsonValueKind.Array, contents.ValueKind);
            TestContext.WriteLine($"  ✓ Has 'contents' array with {contents.GetArrayLength()} items");

            // Validate content structure
            if (contents.GetArrayLength() > 0)
            {
                var firstContent = contents[0];
                TestContext.WriteLine("\n  Validating first content element:");

                if (firstContent.TryGetProperty("kind", out var kind))
                {
                    Assert.AreEqual(JsonValueKind.String, kind.ValueKind);
                    TestContext.WriteLine($"    ✓ Has 'kind': {kind.GetString()}");
                }

                if (firstContent.TryGetProperty("mimeType", out var mimeType))
                {
                    Assert.AreEqual(JsonValueKind.String, mimeType.ValueKind);
                    TestContext.WriteLine($"    ✓ Has 'mimeType': {mimeType.GetString()}");
                }

                if (firstContent.TryGetProperty("markdown", out var markdown))
                {
                    Assert.AreEqual(JsonValueKind.String, markdown.ValueKind);
                    TestContext.WriteLine($"    ✓ Has 'markdown' ({markdown.GetString().Length} chars)");
                }
            }

            TestContext.WriteLine("\n✓ JSON structure validation completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Use protocol method to analyze
        /// - Parse JSON and extract markdown content
        /// - Verify markdown is not empty
        /// </summary>
        [RecordedTest]
        public async Task TestExtractMarkdownFromRawJson()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing markdown extraction from raw JSON...");

            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath));
            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                RequestContent.Create(BinaryData.FromBytes(pdfBytes)));

            var responseData = operation.Value;

            using var jsonDocument = JsonDocument.Parse(responseData);
            var result = jsonDocument.RootElement.GetProperty("result");
            var contents = result.GetProperty("contents");

            Assert.IsTrue(contents.GetArrayLength() > 0, "Should have at least one content");

            var firstContent = contents[0];

            if (firstContent.TryGetProperty("markdown", out var markdownElement))
            {
                string markdown = markdownElement.GetString();

                Assert.IsNotNull(markdown, "Markdown should not be null");
                Assert.IsTrue(markdown.Length > 0, "Markdown should not be empty");

                TestContext.WriteLine($"  ✓ Extracted markdown ({markdown.Length} characters)");
                TestContext.WriteLine($"\n  First 200 characters:");
                TestContext.WriteLine($"  {markdown.Substring(0, Math.Min(200, markdown.Length))}...");
            }
            else
            {
                Assert.Fail("First content should have markdown property");
            }

            TestContext.WriteLine("\n✓ Markdown extraction completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Analyze document with protocol method
        /// - Serialize JSON with different options (compact vs indented)
        /// - Verify both formats are valid
        /// </summary>
        [RecordedTest]
        public async Task TestJsonSerializationOptions()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing JSON serialization options...");

            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath));
            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                RequestContent.Create(BinaryData.FromBytes(pdfBytes)));

            var responseData = operation.Value;

            using var jsonDocument = JsonDocument.Parse(responseData);

            // Test compact JSON
            TestContext.WriteLine("\nTesting compact JSON serialization...");
            string compactJson = JsonSerializer.Serialize(
                jsonDocument.RootElement,
                new JsonSerializerOptions { WriteIndented = false });

            Assert.IsTrue(compactJson.Length > 0);
            Assert.DoesNotThrow(() => JsonDocument.Parse(compactJson));
            TestContext.WriteLine($"  ✓ Compact JSON: {compactJson.Length} characters");

            // Test indented JSON
            TestContext.WriteLine("\nTesting indented JSON serialization...");
            string indentedJson = JsonSerializer.Serialize(
                jsonDocument.RootElement,
                new JsonSerializerOptions { WriteIndented = true });

            Assert.IsTrue(indentedJson.Length > 0);
            Assert.IsTrue(indentedJson.Length > compactJson.Length,
                "Indented JSON should be longer than compact");
            Assert.DoesNotThrow(() => JsonDocument.Parse(indentedJson));
            TestContext.WriteLine($"  ✓ Indented JSON: {indentedJson.Length} characters");

            TestContext.WriteLine($"\n  Size difference: {indentedJson.Length - compactJson.Length} characters");
            TestContext.WriteLine("✓ JSON serialization options validated");
        }

        /// <summary>
        /// Test Summary:
        /// - Parse raw JSON response
        /// - Count total number of properties at all levels
        /// - Verify JSON depth and complexity
        /// </summary>
        [RecordedTest]
        public async Task TestRawJsonComplexityAnalysis()
        {
            var client = CreateClient();

            TestContext.WriteLine("Analyzing raw JSON complexity...");

            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath));
            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                RequestContent.Create(BinaryData.FromBytes(pdfBytes)));

            var responseData = operation.Value;

            using var jsonDocument = JsonDocument.Parse(responseData);
            var root = jsonDocument.RootElement;

            TestContext.WriteLine("\nJSON Complexity Analysis:");

            // Analyze structure
            int propertyCount = CountProperties(root);
            TestContext.WriteLine($"  Total properties: {propertyCount}");

            int maxDepth = GetMaxDepth(root);
            TestContext.WriteLine($"  Maximum depth: {maxDepth}");

            string jsonString = responseData.ToString();
            TestContext.WriteLine($"  Total size: {jsonString.Length:N0} characters");

            Assert.IsTrue(propertyCount > 0, "Should have properties");
            Assert.IsTrue(maxDepth > 0, "Should have depth");

            TestContext.WriteLine("\n✓ Complexity analysis completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Use protocol method with invalid analyzer
        /// - Verify error response is still valid JSON
        /// </summary>
        [RecordedTest]
        public async Task TestProtocolMethodErrorResponse()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing protocol method error response...");

            string testFileDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pdfPath = Path.Combine(testFileDir, "Samples\\SampleFiles", "sample_invoice.pdf");

            Assert.IsTrue(File.Exists(pdfPath));
            byte[] pdfBytes = File.ReadAllBytes(pdfPath);

            string invalidAnalyzer = "invalid_analyzer_" + Guid.NewGuid().ToString("N");

            try
            {
                var operation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    invalidAnalyzer,
                    "application/pdf",
                    RequestContent.Create(BinaryData.FromBytes(pdfBytes)));

                await operation.WaitForCompletionAsync();

                Assert.Fail("Should have thrown exception for invalid analyzer");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                TestContext.WriteLine($"  Status: {ex.Status}");
                TestContext.WriteLine($"  Error Code: {ex.ErrorCode}");

                Assert.AreEqual(404, ex.Status, "Should return 404 for invalid analyzer");
            }

            TestContext.WriteLine("\n✓ Error response validation completed");
        }

        /// <summary>
        /// Helper method to count all properties in a JSON element recursively
        /// </summary>
        private int CountProperties(JsonElement element)
        {
            int count = 0;

            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (var property in element.EnumerateObject())
                    {
                        count++; // Count the property itself
                        count += CountProperties(property.Value); // Count nested properties
                    }
                    break;

                case JsonValueKind.Array:
                    foreach (var item in element.EnumerateArray())
                    {
                        count += CountProperties(item);
                    }
                    break;
            }

            return count;
        }

        /// <summary>
        /// Helper method to get maximum depth of JSON structure
        /// </summary>
        private int GetMaxDepth(JsonElement element, int currentDepth = 0)
        {
            int maxDepth = currentDepth;

            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (var property in element.EnumerateObject())
                    {
                        int depth = GetMaxDepth(property.Value, currentDepth + 1);
                        maxDepth = Math.Max(maxDepth, depth);
                    }
                    break;

                case JsonValueKind.Array:
                    foreach (var item in element.EnumerateArray())
                    {
                        int depth = GetMaxDepth(item, currentDepth + 1);
                        maxDepth = Math.Max(maxDepth, depth);
                    }
                    break;
            }

            return maxDepth;
        }
    }
}
