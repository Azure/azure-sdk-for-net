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
        public async Task UpdateAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            // First create an analyzer to update
            string defaultId = $"test_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("updateAnalyzerId", defaultId) ?? defaultId;

            var initialAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Initial description",
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                }
            };
            initialAnalyzer.Models["completion"] = "gpt-4.1";
            initialAnalyzer.Tags["tag1"] = "tag1_initial_value";

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                initialAnalyzer,
                allowReplace: true);

            try
            {
                #region Snippet:ContentUnderstandingUpdateAnalyzer
#if SNIPPET
                // First, get the current analyzer to preserve base analyzer ID
                var currentAnalyzer = await client.GetAnalyzerAsync(analyzerId);

                // Display current analyzer information
                Console.WriteLine("Current analyzer information:");
                Console.WriteLine($"  Description: {currentAnalyzer.Value.Description}");
                Console.WriteLine($"  Tags: {string.Join(", ", currentAnalyzer.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

                // Create an updated analyzer with new description and tags
                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = currentAnalyzer.Value.BaseAnalyzerId,
                    Description = "Updated description"
                };

                // Update tags
                updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
                updatedAnalyzer.Tags["tag3"] = "tag3_value";  // Add tag3

                // Update the analyzer
                await client.UpdateAnalyzerAsync(analyzerId, updatedAnalyzer);

                // Verify the update
                var updated = await client.GetAnalyzerAsync(analyzerId);
                Console.WriteLine($"Description: {updated.Value.Description}");
                Console.WriteLine($"Tags: {string.Join(", ", updated.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
#else
                // First, get the current analyzer to preserve base analyzer ID
                var currentAnalyzer = await client.GetAnalyzerAsync(analyzerId);

                // Display current analyzer information
                Console.WriteLine("Current analyzer information:");
                Console.WriteLine($"  Description: {currentAnalyzer.Value.Description}");
                Console.WriteLine($"  Tags: {string.Join(", ", currentAnalyzer.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

                // Create an updated analyzer with new description and tags
                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = currentAnalyzer.Value.BaseAnalyzerId,
                    Description = "Updated description"
                };

                // Update tags
                updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
                updatedAnalyzer.Tags["tag3"] = "tag3_value";  // Add tag3

                // Update the analyzer
                await client.UpdateAnalyzerAsync(analyzerId, updatedAnalyzer);

                // Verify the update
                var updated = await client.GetAnalyzerAsync(analyzerId);
                Console.WriteLine($"Description: {updated.Value.Description}");
                Console.WriteLine($"Tags: {string.Join(", ", updated.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
#endif
                #endregion

                #region Assertion:ContentUnderstandingUpdateAnalyzer
                // ========== Verify Initial Analyzer Retrieval ==========
                Assert.IsNotNull(currentAnalyzer, "Current analyzer response should not be null");
                Assert.IsTrue(currentAnalyzer.HasValue, "Current analyzer response should have a value");
                Assert.IsNotNull(currentAnalyzer.Value, "Current analyzer value should not be null");
                Console.WriteLine("Initial analyzer retrieved successfully");

                // Verify raw response
                var currentRawResponse = currentAnalyzer.GetRawResponse();
                Assert.IsNotNull(currentRawResponse, "Current analyzer raw response should not be null");
                Assert.AreEqual(200, currentRawResponse.Status, "Response status should be 200");
                Console.WriteLine($"Get current analyzer response status: {currentRawResponse.Status}");

                // Verify initial description
                Assert.IsNotNull(currentAnalyzer.Value.Description, "Initial description should not be null");
                Assert.AreEqual("Initial description", currentAnalyzer.Value.Description,
                    "Initial description should match");
                Console.WriteLine($"Initial description verified: '{currentAnalyzer.Value.Description}'");

                // Verify initial base analyzer ID
                Assert.IsNotNull(currentAnalyzer.Value.BaseAnalyzerId, "Base analyzer ID should not be null");
                Assert.AreEqual("prebuilt-document", currentAnalyzer.Value.BaseAnalyzerId,
                    "Base analyzer ID should match");
                Console.WriteLine($"Base analyzer ID verified: {currentAnalyzer.Value.BaseAnalyzerId}");

                // Verify initial tags
                Assert.IsNotNull(currentAnalyzer.Value.Tags, "Initial tags should not be null");
                Assert.AreEqual(1, currentAnalyzer.Value.Tags.Count,
                    "Should have 1 initial tag");
                Console.WriteLine($"Initial tags count: {currentAnalyzer.Value.Tags.Count}");

                Assert.IsTrue(currentAnalyzer.Value.Tags.ContainsKey("tag1"),
                    "Should contain tag1");
                Assert.AreEqual("tag1_initial_value", currentAnalyzer.Value.Tags["tag1"],
                    "tag1 initial value should match");
                Console.WriteLine($"  tag1 = '{currentAnalyzer.Value.Tags["tag1"]}'");

                // ========== Verify Update Operation ==========
                Assert.IsNotNull(updatedAnalyzer, "Updated analyzer object should not be null");
                Assert.AreEqual(currentAnalyzer.Value.BaseAnalyzerId, updatedAnalyzer.BaseAnalyzerId,
                    "Updated analyzer should preserve base analyzer ID");
                Assert.AreEqual("Updated description", updatedAnalyzer.Description,
                    "Updated analyzer should have new description");
                Console.WriteLine("Update analyzer object created with correct properties");

                // ========== Verify Updated Analyzer Retrieval ==========
                Assert.IsNotNull(updated, "Updated analyzer response should not be null");
                Assert.IsTrue(updated.HasValue, "Updated analyzer response should have a value");
                Assert.IsNotNull(updated.Value, "Updated analyzer value should not be null");
                Console.WriteLine("Updated analyzer retrieved successfully");

                // Verify raw response
                var updatedRawResponse = updated.GetRawResponse();
                Assert.IsNotNull(updatedRawResponse, "Updated analyzer raw response should not be null");
                Assert.AreEqual(200, updatedRawResponse.Status, "Response status should be 200");
                Console.WriteLine($"Get updated analyzer response status: {updatedRawResponse.Status}");

                // ========== Verify Description Update ==========
                Assert.IsNotNull(updated.Value.Description, "Updated description should not be null");
                Assert.AreEqual("Updated description", updated.Value.Description,
                    "Description should be updated");
                Assert.AreNotEqual(currentAnalyzer.Value.Description, updated.Value.Description,
                    "Description should be different from initial value");
                Console.WriteLine($"Description updated: '{currentAnalyzer.Value.Description}' → '{updated.Value.Description}'");

                // ========== Verify Base Analyzer ID Preserved ==========
                Assert.IsNotNull(updated.Value.BaseAnalyzerId, "Base analyzer ID should not be null");
                Assert.AreEqual("prebuilt-document", updated.Value.BaseAnalyzerId,
                    "Base analyzer ID should be preserved");
                Assert.AreEqual(currentAnalyzer.Value.BaseAnalyzerId, updated.Value.BaseAnalyzerId,
                    "Base analyzer ID should remain unchanged");
                Console.WriteLine($"Base analyzer ID preserved: {updated.Value.BaseAnalyzerId}");

                // ========== Verify Tags Update ==========
                Assert.IsNotNull(updated.Value.Tags, "Updated tags should not be null");
                Console.WriteLine($"Updated tags count: {updated.Value.Tags.Count}");

                // Verify tag1 was updated
                Assert.IsTrue(updated.Value.Tags.ContainsKey("tag1"),
                    "Should still contain tag1");
                Assert.AreEqual("tag1_updated_value", updated.Value.Tags["tag1"],
                    "tag1 should have updated value");
                Assert.AreNotEqual(currentAnalyzer.Value.Tags["tag1"], updated.Value.Tags["tag1"],
                    "tag1 value should be different from initial value");
                Console.WriteLine($"  tag1 updated: '{currentAnalyzer.Value.Tags["tag1"]}' → '{updated.Value.Tags["tag1"]}'");
                // Verify tag3 was added
                Assert.IsTrue(updated.Value.Tags.ContainsKey("tag3"),
                    "Should contain new tag3");
                Assert.AreEqual("tag3_value", updated.Value.Tags["tag3"],
                    "tag3 should have correct value");
                Assert.IsFalse(currentAnalyzer.Value.Tags.ContainsKey("tag3"),
                    "tag3 should not exist in initial analyzer");
                Console.WriteLine($"  tag3 added: (new) → '{updated.Value.Tags["tag3"]}'");

                // Verify tag count (should be 2: tag1 updated, tag3 added)
                Assert.AreEqual(2, updated.Value.Tags.Count,
                    "Should have 2 tags after update (tag1 updated, tag3 added)");

                // ========== Verify Config Preservation ==========
                if (currentAnalyzer.Value.Config != null)
                {
                    if (updated.Value.Config != null)
                    {
                        // Config properties should be preserved if not explicitly updated
                        Console.WriteLine("Config exists in updated analyzer");

                        if (currentAnalyzer.Value.Config.ReturnDetails.HasValue &&
                            updated.Value.Config.ReturnDetails.HasValue)
                        {
                            Console.WriteLine($"  ReturnDetails: {updated.Value.Config.ReturnDetails.Value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Config not present in updated analyzer (may have been reset)");
                    }
                }

                // ========== Verify Models Preservation ==========
                if (currentAnalyzer.Value.Models != null && currentAnalyzer.Value.Models.Count > 0)
                {
                    if (updated.Value.Models != null)
                    {
                        Console.WriteLine($"Models exist in updated analyzer: {updated.Value.Models.Count} model(s)");

                        if (currentAnalyzer.Value.Models.ContainsKey("completion") &&
                            updated.Value.Models.ContainsKey("completion"))
                        {
                            Assert.AreEqual(currentAnalyzer.Value.Models["completion"],
                                updated.Value.Models["completion"],
                                "Completion model should be preserved");
                            Console.WriteLine($"  completion: {updated.Value.Models["completion"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Models not present in updated analyzer (may have been reset)");
                    }
                }

                // ========== Summary ==========
                Console.WriteLine("\nUpdate verification completed successfully:");
                Console.WriteLine($"  Analyzer ID: {analyzerId}");
                Console.WriteLine($"  Description: '{currentAnalyzer.Value.Description}' → '{updated.Value.Description}'");
                Console.WriteLine($"  Base Analyzer: {updated.Value.BaseAnalyzerId} (preserved)");
                Console.WriteLine($"  Tags before update: {currentAnalyzer.Value.Tags.Count} tag(s)");
                Console.WriteLine($"    - tag1: '{currentAnalyzer.Value.Tags["tag1"]}'");
                Console.WriteLine($"  Tags after update: {updated.Value.Tags.Count} tag(s)");
                Console.WriteLine($"    - tag1: '{updated.Value.Tags["tag1"]}' (updated)");
                Console.WriteLine($"    - tag3: '{updated.Value.Tags["tag3"]}' (added)");

                // ========== Verify Changes Summary ==========
                var changedProperties = new List<string>();
                if (currentAnalyzer.Value.Description != updated.Value.Description)
                    changedProperties.Add("Description");
                if (currentAnalyzer.Value.Tags.Count != updated.Value.Tags.Count ||
                    !currentAnalyzer.Value.Tags.SequenceEqual(updated.Value.Tags))
                    changedProperties.Add("Tags");

                Console.WriteLine($"  Properties changed: {string.Join(", ", changedProperties)}");
                Console.WriteLine($"  Properties preserved: BaseAnalyzerId" +
                    (updated.Value.Config != null ? ", Config" : "") +
                    (updated.Value.Models != null && updated.Value.Models.Count > 0 ? ", Models" : ""));
                #endregion
            }
            finally
            {
                // Clean up: delete the analyzer
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                }
                catch
                {
                    // Ignore cleanup errors in tests
                }
            }
        }
    }
}
