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
using NUnit.Framework;

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

            #region Assertion:ContentUnderstandingCreateSourceAnalyzer
            Assert.IsNotNull(createOperation, "Create source analyzer operation should not be null");
            Assert.IsNotNull(createOperation.GetRawResponse(), "Create source analyzer operation should have a raw response");
            TestContext.WriteLine("✅ Create source analyzer operation properties verified");
            Assert.IsNotNull(sourceResult, "Source analyzer result should not be null");
            Assert.AreEqual("prebuilt-document", sourceResult.BaseAnalyzerId, "Base analyzer ID should match");
            Assert.AreEqual("Source analyzer for copying", sourceResult.Description, "Description should match");
            Assert.IsNotNull(sourceResult.Config, "Config should not be null");
            Assert.IsNotNull(sourceResult.FieldSchema, "Field schema should not be null");
            Assert.AreEqual(2, sourceResult.FieldSchema!.Fields.Count, "Should have 2 fields");
            Assert.IsTrue(sourceResult.Tags.ContainsKey("modelType"), "Should contain modelType tag");
            Assert.AreEqual("in_development", sourceResult.Tags["modelType"], "modelType tag should match");
            Console.WriteLine($"✓ Verified source analyzer '{sourceAnalyzerId}' created successfully");
            #endregion

            // Get the source analyzer to see its description and tags before copying
            var sourceResponse = await client.GetAnalyzerAsync(sourceAnalyzerId);
            ContentAnalyzer sourceAnalyzerInfo = sourceResponse.Value;
            Console.WriteLine($"Source analyzer description: {sourceAnalyzerInfo.Description}");
            Console.WriteLine($"Source analyzer tags: {string.Join(", ", sourceAnalyzerInfo.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

            #region Assertion:ContentUnderstandingGetSourceAnalyzer
            Assert.IsNotNull(sourceResponse, "Source analyzer response should not be null");
            Assert.IsNotNull(sourceAnalyzerInfo, "Source analyzer info should not be null");
            Assert.AreEqual("Source analyzer for copying", sourceAnalyzerInfo.Description,
                "Source description should match");
            Assert.IsTrue(sourceAnalyzerInfo.Tags.ContainsKey("modelType"),
                "Source should contain modelType tag");
            Assert.AreEqual("in_development", sourceAnalyzerInfo.Tags["modelType"],
                "Source modelType tag should be 'in_development'");
            #endregion

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

                #region Assertion:ContentUnderstandingCopyAnalyzer
                // Verify the target analyzer was created by copying
                var copiedResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
                Assert.IsNotNull(copiedResponse, "Copied analyzer response should not be null");

                ContentAnalyzer copiedAnalyzer = copiedResponse.Value;
                Assert.IsNotNull(copiedAnalyzer, "Copied analyzer should not be null");

                // Verify the copied analyzer has the same properties as the source
                Assert.AreEqual(sourceAnalyzerInfo.BaseAnalyzerId, copiedAnalyzer.BaseAnalyzerId,
                    "Copied analyzer should have same base analyzer ID");
                Assert.AreEqual(sourceAnalyzerInfo.Description, copiedAnalyzer.Description,
                    "Copied analyzer should have same description");

                // Verify field schema was copied
                Assert.IsNotNull(copiedAnalyzer.FieldSchema, "Copied analyzer should have field schema");
                Assert.AreEqual(sourceAnalyzerInfo.FieldSchema!.Fields.Count, copiedAnalyzer.FieldSchema!.Fields.Count,
                    "Copied analyzer should have same number of fields");
                Assert.IsTrue(copiedAnalyzer.FieldSchema.Fields.ContainsKey("company_name"),
                    "Copied analyzer should contain company_name field");
                Assert.IsTrue(copiedAnalyzer.FieldSchema.Fields.ContainsKey("total_amount"),
                    "Copied analyzer should contain total_amount field");

                // Verify tags were copied
                Assert.IsTrue(copiedAnalyzer.Tags.ContainsKey("modelType"),
                    "Copied analyzer should contain modelType tag");
                Assert.AreEqual("in_development", copiedAnalyzer.Tags["modelType"],
                    "Copied analyzer should have same tag value");

                Console.WriteLine($"✓ Verified analyzer copied from '{sourceAnalyzerId}' to '{targetAnalyzerId}'");
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

                #region Assertion:ContentUnderstandingUpdateAndVerifyAnalyzer
                Assert.IsNotNull(targetResponse, "Target analyzer response should not be null");
                Assert.IsNotNull(targetAnalyzer, "Target analyzer should not be null");

                Assert.IsNotNull(updatedResponse, "Updated analyzer response should not be null");
                Assert.IsNotNull(updatedTargetAnalyzer, "Updated target analyzer should not be null");

                // Verify description is preserved from copy (not changed by tag-only update)
                Assert.AreEqual("Source analyzer for copying", updatedTargetAnalyzer.Description,
                    "Description should be preserved from source");

                // Verify tag was updated
                Assert.IsTrue(updatedTargetAnalyzer.Tags.ContainsKey("modelType"),
                    "Updated analyzer should contain modelType tag");
                Assert.AreEqual("model_in_production", updatedTargetAnalyzer.Tags["modelType"],
                    "Tag should be updated to 'model_in_production'");

                // Verify field schema is still intact after update
                Assert.IsNotNull(updatedTargetAnalyzer.FieldSchema,
                    "Field schema should still exist after update");
                Assert.AreEqual(2, updatedTargetAnalyzer.FieldSchema!.Fields.Count,
                    "Should still have 2 fields after update");

                // Verify base analyzer ID is preserved
                Assert.AreEqual(sourceAnalyzerInfo.BaseAnalyzerId, updatedTargetAnalyzer.BaseAnalyzerId,
                    "Base analyzer ID should be preserved");

                Console.WriteLine($"✓ Verified target analyzer updated successfully");
                Console.WriteLine($"  Description: {updatedTargetAnalyzer.Description}");
                Console.WriteLine($"  Tag modelType: in_development → model_in_production");
                #endregion
            }
            finally
            {
                // Clean up: delete both analyzers
                #region Snippet:ContentUnderstandingDeleteCopiedAnalyzers
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
