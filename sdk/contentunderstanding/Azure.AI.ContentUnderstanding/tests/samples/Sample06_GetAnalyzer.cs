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

            // Display full analyzer JSON
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            string analyzerJson = JsonSerializer.Serialize(analyzer, jsonOptions);
            Console.WriteLine("Prebuilt-documentSearch Analyzer:");
            Console.WriteLine(analyzerJson);
            #endregion

            #region Assertion:ContentUnderstandingGetPrebuiltAnalyzer
            Assert.IsNotNull(response, "Response should not be null");
            Assert.IsNotNull(analyzer, "Analyzer should not be null");
            Assert.IsNotNull(analyzerJson, "Analyzer JSON should not be null");
            Assert.IsTrue(analyzerJson.Length > 0, "Analyzer JSON should not be empty");

            // Verify raw response
            var rawResponse = response.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.AreEqual(200, rawResponse.Status, "Response status should be 200");
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

            // Display full analyzer JSON
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            string invoiceAnalyzerJson = JsonSerializer.Serialize(invoiceAnalyzer, jsonOptions);
            Console.WriteLine("Prebuilt-invoice Analyzer:");
            Console.WriteLine(invoiceAnalyzerJson);
            #endregion

            #region Assertion:ContentUnderstandingGetPrebuiltInvoice
            Assert.IsNotNull(invoiceResponse, "Response should not be null");
            Assert.IsNotNull(invoiceAnalyzer, "Invoice analyzer should not be null");
            Assert.IsNotNull(invoiceAnalyzerJson, "Invoice analyzer JSON should not be null");
            Assert.IsTrue(invoiceAnalyzerJson.Length > 0, "Invoice analyzer JSON should not be empty");

            // Verify invoice analyzer has field schema (prebuilt-invoice should have predefined fields)
            Assert.IsNotNull(invoiceAnalyzer.FieldSchema, "Invoice analyzer should have field schema");
            Assert.IsNotNull(invoiceAnalyzer.FieldSchema!.Fields, "Invoice analyzer should have fields");
            Assert.IsTrue(invoiceAnalyzer.FieldSchema.Fields.Count > 0,
                "Invoice analyzer should have at least one field");

            // Verify raw response
            var rawResponse = invoiceResponse.GetRawResponse();
            Assert.IsNotNull(rawResponse, "Raw response should not be null");
            Assert.AreEqual(200, rawResponse.Status, "Response status should be 200");
            #endregion
        }

        [RecordedTest]
        public async Task GetCustomAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            // First, create a custom analyzer
            string defaultId = $"test_custom_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("analyzerId", defaultId) ?? defaultId;

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

            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true
            };

            var analyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Test analyzer for GetAnalyzer sample",
                Config = config,
                FieldSchema = fieldSchema
            };
            analyzer.Models.Add("completion", "gpt-4.1");

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                analyzer);

            try
            {
                #region Snippet:ContentUnderstandingGetCustomAnalyzer
#if SNIPPET
                // First, create a custom analyzer (see Sample 04 for details)
                string analyzerId = $"my_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

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

                var config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                };

                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer for GetAnalyzer sample",
                    Config = config,
                    FieldSchema = fieldSchema
                };
                analyzer.Models.Add("completion", "gpt-4.1");

                // Create the analyzer
                await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer);
#else
                // Analyzer already created above
#endif

                // Get information about the custom analyzer
                var response = await client.GetAnalyzerAsync(analyzerId);
                ContentAnalyzer retrievedAnalyzer = response.Value;

                // Display full analyzer JSON
                var jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                };
                string analyzerJson = JsonSerializer.Serialize(retrievedAnalyzer, jsonOptions);
                Console.WriteLine("Custom Analyzer:");
                Console.WriteLine(analyzerJson);
                #endregion

                #region Assertion:ContentUnderstandingGetCustomAnalyzer
                Assert.IsNotNull(response, "Response should not be null");
                Assert.IsNotNull(retrievedAnalyzer, "Retrieved analyzer should not be null");
                Assert.IsNotNull(analyzerJson, "Analyzer JSON should not be null");
                Assert.IsTrue(analyzerJson.Length > 0, "Analyzer JSON should not be empty");

                // Verify the analyzer properties match what we created
                Assert.AreEqual("prebuilt-document", retrievedAnalyzer.BaseAnalyzerId,
                    "Base analyzer ID should match");
                Assert.AreEqual("Test analyzer for GetAnalyzer sample", retrievedAnalyzer.Description,
                    "Description should match");

                // Verify field schema
                Assert.IsNotNull(retrievedAnalyzer.FieldSchema, "Field schema should not be null");
                Assert.AreEqual("test_schema", retrievedAnalyzer.FieldSchema!.Name,
                    "Schema name should match");
                Assert.IsNotNull(retrievedAnalyzer.FieldSchema.Fields, "Fields should not be null");
                Assert.AreEqual(1, retrievedAnalyzer.FieldSchema.Fields.Count,
                    "Should have 1 custom field");
                Assert.IsTrue(retrievedAnalyzer.FieldSchema.Fields.ContainsKey("company_name"),
                    "Should contain company_name field");

                // Verify field definition
                var companyNameField = retrievedAnalyzer.FieldSchema.Fields["company_name"];
                Assert.AreEqual(ContentFieldType.String, companyNameField.Type,
                    "Field type should be String");
                Assert.AreEqual(GenerationMethod.Extract, companyNameField.Method,
                    "Field method should be Extract");
                Assert.AreEqual("Name of the company", companyNameField.Description,
                    "Field description should match");

                // Verify config
                Assert.IsNotNull(retrievedAnalyzer.Config, "Config should not be null");
                Assert.AreEqual(true, retrievedAnalyzer.Config!.ReturnDetails,
                    "ReturnDetails should be true");

                // Verify models
                Assert.IsNotNull(retrievedAnalyzer.Models, "Models should not be null");
                Assert.IsTrue(retrievedAnalyzer.Models.Count >= 1,
                    "Should have at least 1 model mapping");
                Assert.IsTrue(retrievedAnalyzer.Models.ContainsKey("completion"),
                    "Should contain completion model");

                // Verify raw response
                var rawResponse = response.GetRawResponse();
                Assert.IsNotNull(rawResponse, "Raw response should not be null");
                Assert.AreEqual(200, rawResponse.Status, "Response status should be 200");
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