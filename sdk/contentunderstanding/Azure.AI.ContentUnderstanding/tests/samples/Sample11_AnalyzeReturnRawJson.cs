// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Text.Json;
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
        public async Task AnalyzeReturnRawJsonAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeReturnRawJson
#if SNIPPET
            string filePath = "<filePath>";
#else
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
#endif
            byte[] fileBytes = File.ReadAllBytes(filePath);

            // Use protocol method to get raw JSON response
            // Note: For production use, prefer the object model approach (AnalyzeBinaryAsync with BinaryData)
            // which returns AnalyzeResult objects that are easier to work with
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                RequestContent.Create(BinaryData.FromBytes(fileBytes)));

            BinaryData responseData = operation.Value;
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeReturnRawJson
            Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            TestContext.WriteLine("✅ Analysis operation properties verified");
            Assert.IsNotNull(responseData, "Response data should not be null");
            Assert.IsTrue(responseData.ToMemory().Length > 0, "Response data should not be empty");
            #endregion

            #region Snippet:ContentUnderstandingParseRawJson
            // Parse the raw JSON response
            using var jsonDocument = JsonDocument.Parse(responseData);

            // Pretty-print the JSON
            string prettyJson = JsonSerializer.Serialize(
                jsonDocument.RootElement,
                new JsonSerializerOptions { WriteIndented = true });

            // Create output directory if it doesn't exist
            string outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
            Directory.CreateDirectory(outputDir);

            // Save to file
            string outputFileName = $"analyze_result_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
            string outputPath = Path.Combine(outputDir, outputFileName);
            File.WriteAllText(outputPath, prettyJson);

            Console.WriteLine($"Raw JSON response saved to: {outputPath}");
            Console.WriteLine($"File size: {prettyJson.Length:N0} characters");
            #endregion

            #region Assertion:ContentUnderstandingParseRawJson
            Assert.IsNotNull(jsonDocument, "JSON document should not be null");
            Assert.IsNotNull(prettyJson, "Pretty JSON string should not be null");
            Assert.IsTrue(prettyJson.Length > 0, "Pretty JSON should not be empty");

            // Verify output directory was created
            Assert.IsTrue(Directory.Exists(outputDir), $"Output directory should exist at {outputDir}");

            // Verify output file was created
            Assert.IsTrue(File.Exists(outputPath), $"Output file should exist at {outputPath}");

            // Verify file content
            var fileContent = File.ReadAllText(outputPath);
            Assert.IsNotNull(fileContent, "File content should not be null");
            Assert.IsTrue(fileContent.Length > 0, "File content should not be empty");
            Assert.AreEqual(prettyJson, fileContent, "File content should match pretty JSON");

            Console.WriteLine($"✓ Verified JSON file created at: {outputPath}");
            Console.WriteLine($"✓ File size: {fileContent.Length:N0} characters");
            #endregion

            #region Snippet:ContentUnderstandingExtractFromRawJson
            // Extract key information from raw JSON
            var resultElement = jsonDocument.RootElement.GetProperty("result");

            if (resultElement.TryGetProperty("analyzerId", out var analyzerIdElement))
            {
                Console.WriteLine($"Analyzer ID: {analyzerIdElement.GetString()}");
            }

            if (resultElement.TryGetProperty("contents", out var contentsElement) &&
                contentsElement.ValueKind == JsonValueKind.Array)
            {
                Console.WriteLine($"Contents count: {contentsElement.GetArrayLength()}");

                if (contentsElement.GetArrayLength() > 0)
                {
                    var firstContent = contentsElement[0];
                    if (firstContent.TryGetProperty("kind", out var kindElement))
                    {
                        Console.WriteLine($"Content kind: {kindElement.GetString()}");
                    }
                    if (firstContent.TryGetProperty("mimeType", out var mimeTypeElement))
                    {
                        Console.WriteLine($"MIME type: {mimeTypeElement.GetString()}");
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractFromRawJson
            // Verify JSON structure
            Assert.IsTrue(jsonDocument.RootElement.TryGetProperty("result", out var resultElementVerify),
                "JSON should have 'result' property");
            Assert.AreEqual(JsonValueKind.Object, resultElementVerify.ValueKind,
                "Result should be an object");

            // Verify analyzer ID
            if (resultElementVerify.TryGetProperty("analyzerId", out var analyzerIdElementVerify))
            {
                var analyzerId = analyzerIdElementVerify.GetString();
                Assert.IsNotNull(analyzerId, "Analyzer ID should not be null");
                Assert.IsFalse(string.IsNullOrWhiteSpace(analyzerId),
                    "Analyzer ID should not be empty");
                Assert.AreEqual("prebuilt-documentSearch", analyzerId,
                    "Analyzer ID should match the one used in the request");
            }
            else
            {
                Assert.Fail("JSON result should contain 'analyzerId' property");
            }

            // Verify contents array
            if (resultElementVerify.TryGetProperty("contents", out var contentsElementVerify))
            {
                Assert.AreEqual(JsonValueKind.Array, contentsElementVerify.ValueKind,
                    "Contents should be an array");

                int contentsCount = contentsElementVerify.GetArrayLength();
                Assert.IsTrue(contentsCount > 0, "Contents array should have at least one element");

                Console.WriteLine($"✓ Verified contents count: {contentsCount}");

                // Verify first content element
                var firstContentVerify = contentsElementVerify[0];
                Assert.AreEqual(JsonValueKind.Object, firstContentVerify.ValueKind,
                    "Content element should be an object");

                // Verify kind property
                if (firstContentVerify.TryGetProperty("kind", out var kindElementVerify))
                {
                    var kind = kindElementVerify.GetString();
                    Assert.IsNotNull(kind, "Content kind should not be null");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(kind),
                        "Content kind should not be empty");
                    Console.WriteLine($"✓ Verified content kind: {kind}");
                }

                // Verify mimeType property
                if (firstContentVerify.TryGetProperty("mimeType", out var mimeTypeElementVerify))
                {
                    var mimeType = mimeTypeElementVerify.GetString();
                    Assert.IsNotNull(mimeType, "MIME type should not be null");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mimeType), "MIME type should not be empty");
                    Assert.IsTrue(mimeType?.Contains("/") ?? false,
                        "MIME type should be in format 'type/subtype'");
                    Console.WriteLine($"✓ Verified MIME type: {mimeType}");
                }
            }
            else
            {
                Assert.Fail("JSON result should contain 'contents' property");
            }

            Console.WriteLine("\n✓ Raw JSON extraction and validation completed successfully");
            #endregion
        }
    }
}
