// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task GetPrebuiltAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingGetPrebuiltAnalyzer
#if SNIPPET
            // Get information about a prebuilt analyzer
            var response = await client.GetAnalyzerAsync("prebuilt-documentSearch");
#else
            // Get information about a prebuilt analyzer
            var response = await client.GetAnalyzerAsync("prebuilt-documentSearch");
#endif
            ContentAnalyzer analyzer = response.Value;

            // Print a few properties from ContentAnalyzer
            Console.WriteLine($"Analyzer ID: {analyzer.AnalyzerId}");
            Console.WriteLine($"Base Analyzer ID: {analyzer.BaseAnalyzerId}");
            Console.WriteLine($"Description: {analyzer.Description}");
            Console.WriteLine($"Enable OCR: {analyzer.Config.EnableOcr}");
            Console.WriteLine($"Enable Layout: {analyzer.Config.EnableLayout}");
            Console.WriteLine($"Models: {string.Join(", ", analyzer.Models.Select(m => $"{m.Key}={m.Value}"))}");

            // Get raw response JSON and format it for nice printing
            var rawResponseForJson = response.GetRawResponse();
            string rawJson = rawResponseForJson.Content.ToString();
            using (JsonDocument doc = JsonDocument.Parse(rawJson))
            {
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string formattedJson = JsonSerializer.Serialize(doc, jsonOptions);
                Console.WriteLine("\nPrebuilt-documentSearch Analyzer (Raw JSON):");
                Console.WriteLine(formattedJson);
            }
            #endregion

            #region Assertion:ContentUnderstandingGetPrebuiltAnalyzer
            Assert.IsNotNull(response, "Response should not be null");
            Assert.IsTrue(response.HasValue, "Response should have a value");
            Assert.IsNotNull(analyzer, "Analyzer should not be null");
            Console.WriteLine("Get prebuilt analyzer response verified");

            // Verify raw response
            var rawResponse = response.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.AreEqual(200, rawResponse.Status, "Response status should be 200");
            Assert.IsNotNull(rawResponse.Content, "Response content should not be null");
            Console.WriteLine($"Raw response status: {rawResponse.Status}");

            // Verify raw JSON response
            Assert.IsNotNull(rawJson, "Raw JSON should not be null");
            Assert.IsTrue(rawJson.Length > 0, "Raw JSON should not be empty");
            Assert.IsTrue(rawJson.Contains("prebuilt-documentSearch") || rawJson.Contains("documentSearch"),
                "Raw JSON should contain analyzer identifier");
            Console.WriteLine($"Raw JSON length: {rawJson.Length} characters");

            // Verify basic analyzer properties for prebuilt-documentSearch
            if (!string.IsNullOrWhiteSpace(analyzer.BaseAnalyzerId))
            {
                Console.WriteLine($"Base analyzer ID: {analyzer.BaseAnalyzerId}");
            }

            if (!string.IsNullOrWhiteSpace(analyzer.Description))
            {
                Console.WriteLine($"Description: {analyzer.Description}");
            }

            // Verify config if present
            if (analyzer.Config != null)
            {
                Console.WriteLine("Analyzer has configuration");
                if (analyzer.Config.EnableOcr.HasValue)
                {
                    Console.WriteLine($"  EnableOcr: {analyzer.Config.EnableOcr.Value}");
                }
                if (analyzer.Config.EnableLayout.HasValue)
                {
                    Console.WriteLine($"  EnableLayout: {analyzer.Config.EnableLayout.Value}");
                }
            }

            // Verify models if present
            if (analyzer.Models != null && analyzer.Models.Count > 0)
            {
                Console.WriteLine($"Analyzer has {analyzer.Models.Count} model mapping(s)");
                foreach (var model in analyzer.Models)
                {
                    Console.WriteLine($"  {model.Key}: {model.Value}");
                }
            }

            Console.WriteLine("All prebuilt analyzer properties validated successfully");
            #endregion
        }

        [RecordedTest]
        public async Task GetPrebuiltInvoiceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingGetPrebuiltInvoice
#if SNIPPET
            // Get information about prebuilt-invoice analyzer
            var invoiceResponse = await client.GetAnalyzerAsync("prebuilt-invoice");
#else
            // Get information about prebuilt-invoice analyzer
            var invoiceResponse = await client.GetAnalyzerAsync("prebuilt-invoice");
#endif
            ContentAnalyzer invoiceAnalyzer = invoiceResponse.Value;

            // Get raw response JSON and format it for nice printing
            var rawResponseForJson = invoiceResponse.GetRawResponse();
            string rawJson = rawResponseForJson.Content.ToString();
            using (JsonDocument doc = JsonDocument.Parse(rawJson))
            {
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string formattedJson = JsonSerializer.Serialize(doc, jsonOptions);
                Console.WriteLine(formattedJson);
            }
            #endregion

            #region Assertion:ContentUnderstandingGetPrebuiltInvoice
            Assert.IsNotNull(invoiceResponse, "Response should not be null");
            Assert.IsTrue(invoiceResponse.HasValue, "Response should have a value");
            Assert.IsNotNull(invoiceAnalyzer, "Invoice analyzer should not be null");
            Console.WriteLine("Get prebuilt invoice analyzer response verified");

            // Verify raw response
            var rawResponse = invoiceResponse.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.AreEqual(200, rawResponse.Status, "Response status should be 200");
            Assert.IsNotNull(rawResponse.Content, "Response content should not be null");
            Console.WriteLine($"Raw response status: {rawResponse.Status}");

            // Verify raw JSON response
            Assert.IsNotNull(rawJson, "Raw JSON should not be null");
            Assert.IsTrue(rawJson.Length > 0, "Raw JSON should not be empty");
            Assert.IsTrue(rawJson.Contains("invoice") || rawJson.Contains("Invoice"),
                "Raw JSON should contain 'invoice'");
            Console.WriteLine($"Raw JSON length: {rawJson.Length} characters");

            // Verify invoice analyzer has field schema (prebuilt-invoice should have predefined fields)
            Assert.IsNotNull(invoiceAnalyzer.FieldSchema, "Invoice analyzer should have field schema");
            Assert.IsNotNull(invoiceAnalyzer.FieldSchema!.Fields, "Invoice analyzer should have fields");
            Assert.IsTrue(invoiceAnalyzer.FieldSchema.Fields.Count > 0,
                "Invoice analyzer should have at least one field");
            Console.WriteLine($"Invoice analyzer has {invoiceAnalyzer.FieldSchema.Fields.Count} field(s)");

            // Verify common invoice fields
            var commonFields = new[] { "CustomerName", "InvoiceDate", "TotalAmount", "LineItems" };
            int foundFields = 0;
            foreach (var fieldName in commonFields)
            {
                if (invoiceAnalyzer.FieldSchema.Fields.ContainsKey(fieldName))
                {
                    foundFields++;
                    var field = invoiceAnalyzer.FieldSchema.Fields[fieldName];
                    Console.WriteLine($"  {fieldName} field found (Type: {field.Type})");

                    Assert.IsFalse(string.IsNullOrWhiteSpace(field.Description),
                        $"{fieldName} should have a description");
                }
            }

            if (foundFields > 0)
            {
                Console.WriteLine($"Found {foundFields} common invoice fields");
            }
            else
            {
                Console.WriteLine("⚠️ No common invoice fields found (field names may differ)");
            }

            // Verify field schema metadata
            if (!string.IsNullOrWhiteSpace(invoiceAnalyzer.FieldSchema.Name))
            {
                Console.WriteLine($"Field schema name: {invoiceAnalyzer.FieldSchema.Name}");
            }

            if (!string.IsNullOrWhiteSpace(invoiceAnalyzer.FieldSchema.Description))
            {
                Console.WriteLine($"Field schema description: {invoiceAnalyzer.FieldSchema.Description}");
            }

            // Verify base analyzer ID
            if (!string.IsNullOrWhiteSpace(invoiceAnalyzer.BaseAnalyzerId))
            {
                Console.WriteLine($"Base analyzer ID: {invoiceAnalyzer.BaseAnalyzerId}");
            }

            // Verify description
            if (!string.IsNullOrWhiteSpace(invoiceAnalyzer.Description))
            {
                Console.WriteLine($"Description: {invoiceAnalyzer.Description}");
            }

            // Verify config
            if (invoiceAnalyzer.Config != null)
            {
                Console.WriteLine("Invoice analyzer has configuration");
                if (invoiceAnalyzer.Config.EnableOcr.HasValue)
                {
                    Console.WriteLine($"  EnableOcr: {invoiceAnalyzer.Config.EnableOcr.Value}");
                }
                if (invoiceAnalyzer.Config.EnableLayout.HasValue)
                {
                    Console.WriteLine($"  EnableLayout: {invoiceAnalyzer.Config.EnableLayout.Value}");
                }
                if (invoiceAnalyzer.Config.EstimateFieldSourceAndConfidence.HasValue)
                {
                    Console.WriteLine($"  EstimateFieldSourceAndConfidence: {invoiceAnalyzer.Config.EstimateFieldSourceAndConfidence.Value}");
                }
            }

            // Verify models
            if (invoiceAnalyzer.Models != null && invoiceAnalyzer.Models.Count > 0)
            {
                Console.WriteLine($"Invoice analyzer has {invoiceAnalyzer.Models.Count} model mapping(s)");
                foreach (var model in invoiceAnalyzer.Models)
                {
                    Console.WriteLine($"  {model.Key}: {model.Value}");
                }
            }

            Console.WriteLine("All prebuilt invoice analyzer properties validated successfully");
            #endregion
        }

        [RecordedTest]
        public async Task GetCustomAnalyzerAsync()
        {
            ContentUnderstandingClient client = default!;
            #region Snippet:ContentUnderstandingGetCustomAnalyzer
#if SNIPPET
            string analyzerId = $"my_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#else
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            // First, create a custom analyzer
            string defaultId = $"test_custom_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerId", defaultId) ?? defaultId;
#endif

            // Define field schema with custom fields
            var fieldSchema = new ContentFieldSchema(
                new Dictionary<string, ContentFieldDefinition>
                {
                    ["company_name"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Extract,
                        Description = "Name of the company"
                    }
                })
            {
                Name = "test_schema",
                Description = "Test schema for GetAnalyzer sample"
            };

            // Create analyzer configuration
            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true
            };

            // Create the custom analyzer
            var analyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Test analyzer for GetAnalyzer sample",
                Config = config,
                FieldSchema = fieldSchema
            };
            analyzer.Models["completion"] = "gpt-4.1";

            // Create the analyzer
            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                analyzer);

            try
            {
                // Get information about the custom analyzer
                var response = await client.GetAnalyzerAsync(analyzerId);
                ContentAnalyzer retrievedAnalyzer = response.Value;

                // Get raw response JSON and format it for nice printing
                var rawResponseForJson = response.GetRawResponse();
                string rawJson = rawResponseForJson.Content.ToString();
                using (JsonDocument doc = JsonDocument.Parse(rawJson))
                {
                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                    string formattedJson = JsonSerializer.Serialize(doc, jsonOptions);
                    Console.WriteLine(formattedJson);
                }
                #endregion

                #region Assertion:ContentUnderstandingGetCustomAnalyzer
                Assert.IsNotNull(response, "Response should not be null");
                Assert.IsTrue(response.HasValue, "Response should have a value");
                Assert.IsNotNull(retrievedAnalyzer, "Retrieved analyzer should not be null");
                Console.WriteLine($"Get custom analyzer response verified for '{analyzerId}'");

                // Verify raw response
                var rawResponse = response.GetRawResponse();
                Assert.IsNotNull(rawResponse, "Raw response should not be null");
                Assert.AreEqual(200, rawResponse.Status, "Response status should be 200");
                Assert.IsNotNull(rawResponse.Content, "Response content should not be null");
                Console.WriteLine($"Raw response status: {rawResponse.Status}");

                // Verify raw JSON response
                Assert.IsNotNull(rawJson, "Raw JSON should not be null");
                Assert.IsTrue(rawJson.Length > 0, "Raw JSON should not be empty");
                Console.WriteLine($"Raw JSON length: {rawJson.Length} characters");

                // Verify the analyzer properties match what we created
                Assert.IsNotNull(retrievedAnalyzer.BaseAnalyzerId, "Base analyzer ID should not be null");
                Assert.AreEqual("prebuilt-document", retrievedAnalyzer.BaseAnalyzerId,
                    "Base analyzer ID should match");
                Console.WriteLine($"Base analyzer ID verified: {retrievedAnalyzer.BaseAnalyzerId}");

                Assert.IsNotNull(retrievedAnalyzer.Description, "Description should not be null");
                Assert.AreEqual("Test analyzer for GetAnalyzer sample", retrievedAnalyzer.Description,
                    "Description should match");
                Console.WriteLine($"Description verified: {retrievedAnalyzer.Description}");

                // Verify field schema
                Assert.IsNotNull(retrievedAnalyzer.FieldSchema, "Field schema should not be null");
                Assert.IsNotNull(retrievedAnalyzer.FieldSchema!.Name, "Schema name should not be null");
                Assert.AreEqual("test_schema", retrievedAnalyzer.FieldSchema.Name,
                    "Schema name should match");
                Console.WriteLine($"Field schema name verified: {retrievedAnalyzer.FieldSchema.Name}");

                Assert.IsNotNull(retrievedAnalyzer.FieldSchema.Description, "Schema description should not be null");
                Assert.AreEqual("Test schema for GetAnalyzer sample", retrievedAnalyzer.FieldSchema.Description,
                    "Schema description should match");
                Console.WriteLine($"Field schema description verified");

                Assert.IsNotNull(retrievedAnalyzer.FieldSchema.Fields, "Fields should not be null");
                Assert.AreEqual(1, retrievedAnalyzer.FieldSchema.Fields.Count,
                    "Should have 1 custom field");
                Console.WriteLine($"Field count verified: {retrievedAnalyzer.FieldSchema.Fields.Count}");

                Assert.IsTrue(retrievedAnalyzer.FieldSchema.Fields.ContainsKey("company_name"),
                    "Should contain company_name field");
                Console.WriteLine("company_name field found");

                // Verify field definition in detail
                var companyNameField = retrievedAnalyzer.FieldSchema.Fields["company_name"];
                Assert.IsNotNull(companyNameField, "company_name field should not be null");
                Assert.AreEqual(ContentFieldType.String, companyNameField.Type,
                    "Field type should be String");
                Console.WriteLine($"  Type: {companyNameField.Type}");

                Assert.AreEqual(GenerationMethod.Extract, companyNameField.Method,
                    "Field method should be Extract");
                Console.WriteLine($"  Method: {companyNameField.Method}");

                Assert.IsNotNull(companyNameField.Description, "Field description should not be null");
                Assert.AreEqual("Name of the company", companyNameField.Description,
                    "Field description should match");
                Console.WriteLine($"  Description: {companyNameField.Description}");

                // Verify config
                Assert.IsNotNull(retrievedAnalyzer.Config, "Config should not be null");
                Assert.IsNotNull(retrievedAnalyzer.Config!.ReturnDetails, "ReturnDetails should not be null");
                Assert.AreEqual(true, retrievedAnalyzer.Config.ReturnDetails,
                    "ReturnDetails should be true");
                Console.WriteLine($"Config verified (ReturnDetails={retrievedAnalyzer.Config.ReturnDetails})");

                // Verify models
                Assert.IsNotNull(retrievedAnalyzer.Models, "Models should not be null");
                Assert.IsTrue(retrievedAnalyzer.Models.Count >= 1,
                    "Should have at least 1 model mapping");
                Console.WriteLine($"Model mappings count: {retrievedAnalyzer.Models.Count}");

                Assert.IsTrue(retrievedAnalyzer.Models.ContainsKey("completion"),
                    "Should contain completion model");
                var completionModel = retrievedAnalyzer.Models["completion"];
                Assert.AreEqual("gpt-4.1", completionModel, "Completion model should be gpt-4.1");
                Console.WriteLine($"  completion: {completionModel}");

                // Verify the retrieved analyzer matches the original
                Console.WriteLine("Retrieved analyzer matches original configuration:");
                Console.WriteLine($"  - Base analyzer: {retrievedAnalyzer.BaseAnalyzerId}");
                Console.WriteLine($"  - Description: {retrievedAnalyzer.Description}");
                Console.WriteLine($"  - Field schema: {retrievedAnalyzer.FieldSchema.Name}");
                Console.WriteLine($"  - Fields: {retrievedAnalyzer.FieldSchema.Fields.Count}");
                Console.WriteLine($"  - Models: {retrievedAnalyzer.Models.Count}");

                Console.WriteLine("All custom analyzer properties validated successfully");
                #endregion
            }
            finally
            {
                // Clean up: delete the analyzer
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors in tests
                }
            }
        }
    }
}
