// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task CopyAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            // Generate unique analyzer IDs (deterministic for playback)
            string defaultSourceId = $"test_analyzer_source_{Recording.Random.NewGuid().ToString("N")}";
            string defaultTargetId = $"test_analyzer_target_{Recording.Random.NewGuid().ToString("N")}";
            string sourceAnalyzerId = Recording.GetVariable("copySourceAnalyzerId", defaultSourceId) ?? defaultSourceId;
            string targetAnalyzerId = Recording.GetVariable("copyTargetAnalyzerId", defaultTargetId) ?? defaultTargetId;

            // Step 1: Create the source analyzer
            var sourceConfig = new ContentAnalyzerConfig
            {
                EnableFormula = false,
                EnableLayout = true,
                EnableOcr = true,
                EstimateFieldSourceAndConfidence = true,
                ReturnDetails = true
            };

            var sourceFieldSchema = new ContentFieldSchema(
                new Dictionary<string, ContentFieldDefinition>
                {
                    ["company_name"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Extract,
                        Description = "Name of the company"
                    },
                    ["total_amount"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.Number,
                        Method = GenerationMethod.Extract,
                        Description = "Total amount on the document"
                    }
                })
            {
                Name = "company_schema",
                Description = "Schema for extracting company information"
            };

            var sourceAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Source analyzer for copying",
                Config = sourceConfig,
                FieldSchema = sourceFieldSchema
            };
            sourceAnalyzer.Models.Add("completion", "gpt-4.1");
            sourceAnalyzer.Tags.Add("modelType", "in_development");

            var createOperation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                sourceAnalyzerId,
                sourceAnalyzer);
            var sourceResult = createOperation.Value;
            Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' created successfully!");

            // Get the source analyzer to see its description and tags before copying
            var sourceResponse = await client.GetAnalyzerAsync(sourceAnalyzerId);
            ContentAnalyzer sourceAnalyzerInfo = sourceResponse.Value;
            Console.WriteLine($"Source analyzer description: {sourceAnalyzerInfo.Description}");
            Console.WriteLine($"Source analyzer tags: {string.Join(", ", sourceAnalyzerInfo.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

            try
            {
                // Step 2: Copy the source analyzer to target
                // Note: This copies within the same resource. For cross-resource copying, use GrantCopyAuth sample.
                #region Snippet:ContentUnderstandingCopyAnalyzer
#if SNIPPET
                await client.CopyAnalyzerAsync(
                    WaitUntil.Completed,
                    targetAnalyzerId,
                    sourceAnalyzerId);
#else
                await client.CopyAnalyzerAsync(
                    WaitUntil.Completed,
                    targetAnalyzerId,
                    sourceAnalyzerId);
#endif
                #endregion

                // Step 3: Update the target analyzer with a production tag
                // Step 4: Get the target analyzer again to verify the update
                #region Snippet:ContentUnderstandingUpdateAndVerifyAnalyzer
#if SNIPPET
                // Get the target analyzer first to get its BaseAnalyzerId
                var targetResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                ContentAnalyzer targetAnalyzer = targetResponse.Value;

                // Update the target analyzer with a production tag
                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = targetAnalyzer.BaseAnalyzerId
                };
                updatedAnalyzer.Tags["modelType"] = "model_in_production";

                await client.UpdateAnalyzerAsync(targetAnalyzerId, updatedAnalyzer);

                // Get the target analyzer again to verify the update
                var updatedResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                ContentAnalyzer updatedTargetAnalyzer = updatedResponse.Value;
                Console.WriteLine($"Updated target analyzer description: {updatedTargetAnalyzer.Description}");
                Console.WriteLine($"Updated target analyzer tag: {updatedTargetAnalyzer.Tags["modelType"]}");
#else
                // Get the target analyzer first to get its BaseAnalyzerId
                var targetResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                ContentAnalyzer targetAnalyzer = targetResponse.Value;

                // Update the target analyzer with a production tag
                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = targetAnalyzer.BaseAnalyzerId
                };
                updatedAnalyzer.Tags["modelType"] = "model_in_production";

                await client.UpdateAnalyzerAsync(targetAnalyzerId, updatedAnalyzer);

                // Get the target analyzer again to verify the update
                var updatedResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                ContentAnalyzer updatedTargetAnalyzer = updatedResponse.Value;
                Console.WriteLine($"Updated target analyzer description: {updatedTargetAnalyzer.Description}");
                Console.WriteLine($"Updated target analyzer tag: {updatedTargetAnalyzer.Tags["modelType"]}");
#endif
                #endregion
            }
            finally
            {
                // Clean up: delete both analyzers
                #region Snippet:ContentUnderstandingDeleteAnalyzer
#if SNIPPET
                try
                {
                    await client.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }

                try
                {
                    await client.DeleteAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }
#else
                try
                {
                    await client.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }

                try
                {
                    await client.DeleteAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully.");
                }
                catch
                {
                    // Ignore cleanup errors
                }
#endif
                #endregion
            }
        }
    }
}
