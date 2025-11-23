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
