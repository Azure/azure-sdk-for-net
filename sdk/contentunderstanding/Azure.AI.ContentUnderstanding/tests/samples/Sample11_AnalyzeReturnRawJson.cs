// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
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

            // Use convenience method to analyze the document
            var operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                BinaryData.FromBytes(fileBytes));

            // Get the raw JSON response
            var rawResponse = operation.GetRawResponse();
            string rawJson = rawResponse.Content.ToString();
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeReturnRawJson
            Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
            Assert.IsTrue(fileBytes.Length > 0, "File should not be empty");
            Console.WriteLine($"File loaded: {filePath} ({fileBytes.Length} bytes)");

            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.IsTrue(rawResponse.Status >= 200 && rawResponse.Status < 300,
                $"Response status should be successful, but was {rawResponse.Status}");
            Console.WriteLine($"Analysis operation completed with status: {rawResponse.Status}");

            Assert.IsNotNull(rawJson, "Raw JSON should not be null");
            Assert.IsTrue(rawJson.Length > 0, "Raw JSON should not be empty");
            Console.WriteLine($"Raw JSON length: {rawJson.Length:N0} characters");

            // Verify response is valid JSON format
            try
            {
                using var testDoc = JsonDocument.Parse(rawJson);
                Assert.IsNotNull(testDoc, "Response should be valid JSON");
                Assert.IsNotNull(testDoc.RootElement, "JSON should have root element");
                Console.WriteLine("Response is valid JSON format");
            }
            catch (JsonException ex)
            {
                Assert.Fail($"Response data is not valid JSON: {ex.Message}");
            }

            Console.WriteLine("Raw JSON analysis operation completed successfully");
            #endregion

            #region Snippet:ContentUnderstandingParseRawJson
            // Pretty-print the raw JSON response
            using var jsonDoc = JsonDocument.Parse(rawJson);
            string prettyJson = JsonSerializer.Serialize(jsonDoc.RootElement, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(prettyJson);
            #endregion

            #region Assertion:ContentUnderstandingParseRawJson
            Assert.IsNotNull(prettyJson, "Pretty JSON string should not be null");
            Assert.IsTrue(prettyJson.Length > 0, "Pretty JSON should not be empty");
            Assert.IsTrue(prettyJson.Length >= rawJson.Length,
                "Pretty JSON should be same size or larger than original (due to indentation)");
            Console.WriteLine($"Pretty JSON generated: {prettyJson.Length:N0} characters");

            // Verify JSON is properly indented
            Assert.IsTrue(prettyJson.Contains("\n") || prettyJson.Contains("\r"),
                "Pretty JSON should contain line breaks");
            Assert.IsTrue(prettyJson.Contains("  ") || prettyJson.Contains("\t"),
                "Pretty JSON should contain indentation");
            Console.WriteLine("JSON is properly formatted with indentation");

            // Verify pretty JSON can be parsed back
            try
            {
                using var prettyDoc = JsonDocument.Parse(prettyJson);
                Assert.IsNotNull(prettyDoc, "Pretty JSON should be valid JSON");
                Assert.IsNotNull(prettyDoc.RootElement, "Pretty JSON should have root element");
                Console.WriteLine("Pretty JSON is valid and can be parsed");
            }
            catch (JsonException ex)
            {
                Assert.Fail($"Pretty JSON is not valid: {ex.Message}");
            }

            Console.WriteLine("Raw JSON pretty-printing completed successfully");
            #endregion

                        // Extract key information from raw JSON
            using var jsonDocExtraction = JsonDocument.Parse(rawJson);
            var resultElement = jsonDocExtraction.RootElement.GetProperty("result");

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

            #region Assertion:ContentUnderstandingExtractFromRawJson
            Console.WriteLine("\nJSON Structure Extraction Verification:");

            // Verify JSON root structure
            using var jsonDocForExtraction = JsonDocument.Parse(rawJson);
            Assert.IsNotNull(jsonDocForExtraction.RootElement, "JSON root element should not be null");
            Assert.AreEqual(JsonValueKind.Object, jsonDocForExtraction.RootElement.ValueKind,
                "JSON root should be an object");
            Console.WriteLine("JSON root element is an object");

            // Verify 'result' property exists
            Assert.IsTrue(jsonDocForExtraction.RootElement.TryGetProperty("result", out var resultElementVerify),
                "JSON should have 'result' property");
            Assert.AreEqual(JsonValueKind.Object, resultElementVerify.ValueKind,
                "Result should be an object");
            Console.WriteLine("'result' property found and is an object");

            // Count and display all root properties
            var rootPropertyCount = 0;
            var rootPropertyNames = new System.Collections.Generic.List<string>();
            foreach (var property in jsonDocForExtraction.RootElement.EnumerateObject())
            {
                rootPropertyCount++;
                rootPropertyNames.Add(property.Name);
            }
            Console.WriteLine($"Root level properties: {rootPropertyCount}");
            Console.WriteLine($"  Property names: {string.Join(", ", rootPropertyNames)}");

            // ========== Verify Analyzer ID ==========
            Console.WriteLine("\n?? Analyzer ID Verification:");
            if (resultElementVerify.TryGetProperty("analyzerId", out var analyzerIdElementVerify))
            {
                var analyzerId = analyzerIdElementVerify.GetString();
                Assert.IsNotNull(analyzerId, "Analyzer ID should not be null");
                Assert.IsFalse(string.IsNullOrWhiteSpace(analyzerId),
                    "Analyzer ID should not be empty");
                Assert.AreEqual("prebuilt-documentSearch", analyzerId,
                    "Analyzer ID should match the one used in the request");
                Console.WriteLine($"Analyzer ID verified: '{analyzerId}'");
            }
            else
            {
                Assert.Fail("JSON result should contain 'analyzerId' property");
            }

            // ========== Verify Contents Array ==========
            Console.WriteLine("\nContents Array Verification:");
            if (resultElementVerify.TryGetProperty("contents", out var contentsElementVerify))
            {
                Assert.AreEqual(JsonValueKind.Array, contentsElementVerify.ValueKind,
                    "Contents should be an array");
                Console.WriteLine("'contents' property is an array");

                int contentsCount = contentsElementVerify.GetArrayLength();
                Assert.IsTrue(contentsCount > 0, "Contents array should have at least one element");
                Assert.AreEqual(1, contentsCount, "PDF file should have exactly one content element");
                Console.WriteLine($"Contents count: {contentsCount}");

                // Verify first content element
                var firstContentVerify = contentsElementVerify[0];
                Assert.AreEqual(JsonValueKind.Object, firstContentVerify.ValueKind,
                    "Content element should be an object");
                Console.WriteLine("First content element is an object");

                // Count and display content properties
                var contentPropertyCount = 0;
                var contentPropertyNames = new System.Collections.Generic.List<string>();
                foreach (var property in firstContentVerify.EnumerateObject())
                {
                    contentPropertyCount++;
                    contentPropertyNames.Add(property.Name);
                }
                Console.WriteLine($"Content properties: {contentPropertyCount}");
                Console.WriteLine($"  Property names: {string.Join(", ", contentPropertyNames)}");

                // ========== Verify Kind Property ==========
                Console.WriteLine("\nContent Kind Verification:");
                if (firstContentVerify.TryGetProperty("kind", out var kindElementVerify))
                {
                    var kind = kindElementVerify.GetString();
                    Assert.IsNotNull(kind, "Content kind should not be null");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(kind),
                        "Content kind should not be empty");

                    // Verify kind is a valid value (document or media)
                    if (kind != null)
                    {
                        var kindLower = kind.ToLowerInvariant();
                        Assert.IsTrue(kindLower == "document" || kindLower == "media",
                            $"Content kind should be 'document' or 'media', but was '{kind}'");
                    }
                }
                else
                {
                    Assert.Fail("Content element should contain 'kind' property");
                }

                // ========== Verify MIME Type Property ==========
                Console.WriteLine("\n?? MIME Type Verification:");
                if (firstContentVerify.TryGetProperty("mimeType", out var mimeTypeElementVerify))
                {
                    var mimeType = mimeTypeElementVerify.GetString();
                    Assert.IsNotNull(mimeType, "MIME type should not be null");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mimeType),
                        "MIME type should not be empty");
                    if (mimeType != null)
                    {
                        Assert.IsTrue(mimeType.IndexOf('/') >= 0,
                            $"MIME type should be in format 'type/subtype', but was '{mimeType}'");
                        Assert.AreEqual("application/pdf", mimeType,
                            "MIME type should be 'application/pdf' for PDF files");
                    }
                }
                else
                {
                    Assert.Fail("Content element should contain 'mimeType' property");
                }

                // ========== Verify Additional Common Properties ==========
                Console.WriteLine("\nAdditional Properties Verification:");

                // Check for markdown property
                if (firstContentVerify.TryGetProperty("markdown", out var markdownElement))
                {
                    if (markdownElement.ValueKind == JsonValueKind.String)
                    {
                        var markdown = markdownElement.GetString();
                        Assert.IsNotNull(markdown, "Markdown property should not be null");
                    }
                }
                else
                {
                    Console.WriteLine("No 'markdown' property found");
                }

                // Check for startPageNumber property
                if (firstContentVerify.TryGetProperty("startPageNumber", out var startPageElement))
                {
                    if (startPageElement.ValueKind == JsonValueKind.Number)
                    {
                        var startPage = startPageElement.GetInt32();
                        Assert.IsTrue(startPage >= 1, $"Start page should be >= 1, but was {startPage}");
                        Console.WriteLine($"Start page number: {startPage}");
                    }
                }

                // Check for endPageNumber property
                if (firstContentVerify.TryGetProperty("endPageNumber", out var endPageElement))
                {
                    if (endPageElement.ValueKind == JsonValueKind.Number)
                    {
                        var endPage = endPageElement.GetInt32();
                        Assert.IsTrue(endPage >= 1, $"End page should be >= 1, but was {endPage}");
                        Console.WriteLine($"End page number: {endPage}");

                        // If both start and end page exist, verify relationship
                        if (firstContentVerify.TryGetProperty("startPageNumber", out var startPageCheck) &&
                            startPageCheck.ValueKind == JsonValueKind.Number)
                        {
                            var startPage = startPageCheck.GetInt32();
                            Assert.IsTrue(endPage >= startPage,
                                $"End page ({endPage}) should be >= start page ({startPage})");
                            var totalPages = endPage - startPage + 1;
                            Console.WriteLine($"Total pages: {totalPages}");
                        }
                    }
                }

                // Check for pages array
                if (firstContentVerify.TryGetProperty("pages", out var pagesElement))
                {
                    if (pagesElement.ValueKind == JsonValueKind.Array)
                    {
                        var pageCount = pagesElement.GetArrayLength();
                        Console.WriteLine($"Pages array found: {pageCount} page(s)");
                    }
                }

                // Check for tables array
                if (firstContentVerify.TryGetProperty("tables", out var tablesElement))
                {
                    if (tablesElement.ValueKind == JsonValueKind.Array)
                    {
                        var tableCount = tablesElement.GetArrayLength();
                        Console.WriteLine($"Tables array found: {tableCount} table(s)");
                    }
                }
            }
            else
            {
                Assert.Fail("JSON result should contain 'contents' property");
            }

            // ========== Verify Additional Result Properties ==========
            Console.WriteLine("\nAdditional Result Properties:");

            // Check for warnings
            if (resultElementVerify.TryGetProperty("warnings", out var warningsElement))
            {
                if (warningsElement.ValueKind == JsonValueKind.Array)
                {
                    var warningCount = warningsElement.GetArrayLength();
                    if (warningCount > 0)
                    {
                        Console.WriteLine($"?? Warnings found: {warningCount}");
                        for (int i = 0; i < Math.Min(warningCount, 5); i++)
                        {
                            var warning = warningsElement[i];
                            if (warning.TryGetProperty("message", out var messageElement))
                            {
                                Console.WriteLine($"  {i + 1}. {messageElement.GetString()}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No warnings");
                    }
                }
            }

            // Check for apiVersion
            if (resultElementVerify.TryGetProperty("apiVersion", out var apiVersionElement))
            {
                if (apiVersionElement.ValueKind == JsonValueKind.String)
                {
                    var apiVersion = apiVersionElement.GetString();
                    Console.WriteLine($"API version: {apiVersion}");
                }
            }

            // ========== Summary ==========
            Console.WriteLine("\nRaw JSON extraction and validation completed successfully:");
            Console.WriteLine($"  JSON root properties: {rootPropertyCount}");
            Console.WriteLine($"  Analyzer ID: verified");
            Console.WriteLine($"  Contents count: verified");
            Console.WriteLine($"  Content kind: verified");
            Console.WriteLine($"  MIME type: verified");
            Console.WriteLine($"  All required properties: present and valid");
            #endregion
        }
    }
}
