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
            initialAnalyzer.Models.Add("completion", "gpt-4.1");
            initialAnalyzer.Tags["tag1"] = "tag1_initial_value";
            initialAnalyzer.Tags["tag2"] = "tag2_initial_value";

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

                // Update tags (empty string removes a tag)
                updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
                updatedAnalyzer.Tags["tag2"] = "";  // Remove tag2
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

                // Update tags (empty string removes a tag)
                updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
                updatedAnalyzer.Tags["tag2"] = "";  // Remove tag2
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
                // Verify initial analyzer was retrieved successfully
                Assert.IsNotNull(currentAnalyzer, "Current analyzer response should not be null");
                Assert.IsNotNull(currentAnalyzer.Value, "Current analyzer value should not be null");
                Assert.AreEqual("Initial description", currentAnalyzer.Value.Description,
                    "Initial description should match");
                Assert.IsNotNull(currentAnalyzer.Value.Tags, "Initial tags should not be null");
                Assert.IsTrue(currentAnalyzer.Value.Tags.ContainsKey("tag1"),
                    "Should contain tag1");
                Assert.IsTrue(currentAnalyzer.Value.Tags.ContainsKey("tag2"),
                    "Should contain tag2");
                Assert.AreEqual("tag1_initial_value", currentAnalyzer.Value.Tags["tag1"],
                    "tag1 initial value should match");
                Assert.AreEqual("tag2_initial_value", currentAnalyzer.Value.Tags["tag2"],
                    "tag2 initial value should match");

                // Verify the updated analyzer was retrieved successfully
                Assert.IsNotNull(updated, "Updated analyzer response should not be null");
                Assert.IsNotNull(updated.Value, "Updated analyzer value should not be null");

                // Verify description was updated
                Assert.AreEqual("Updated description", updated.Value.Description,
                    "Description should be updated");

                // Verify tags were updated correctly
                Assert.IsNotNull(updated.Value.Tags, "Updated tags should not be null");

                // tag1 should be updated
                Assert.IsTrue(updated.Value.Tags.ContainsKey("tag1"),
                    "Should still contain tag1");
                Assert.AreEqual("tag1_updated_value", updated.Value.Tags["tag1"],
                    "tag1 should have updated value");

                // tag2 should still exist but with empty string value
                // Note: Setting a tag to empty string does not remove it, it just sets the value to empty
                Assert.IsTrue(updated.Value.Tags.ContainsKey("tag2"),
                    "tag2 should still exist (empty string doesn't remove tags)");
                Assert.AreEqual("", updated.Value.Tags["tag2"],
                    "tag2 should have empty string value");

                // tag3 should be added
                Assert.IsTrue(updated.Value.Tags.ContainsKey("tag3"),
                    "Should contain new tag3");
                Assert.AreEqual("tag3_value", updated.Value.Tags["tag3"],
                    "tag3 should have correct value");

                // Verify base analyzer ID is preserved
                Assert.AreEqual("prebuilt-document", updated.Value.BaseAnalyzerId,
                    "Base analyzer ID should be preserved");

                Console.WriteLine("\n✓ Update verification completed:");
                Console.WriteLine($"  Description updated: Initial description → Updated description");
                Console.WriteLine($"  Tags before: tag1={currentAnalyzer.Value.Tags["tag1"]}, tag2={currentAnalyzer.Value.Tags["tag2"]}");
                Console.WriteLine($"  Tags after: tag1={updated.Value.Tags["tag1"]}, tag3={updated.Value.Tags["tag3"]} (tag2 removed)");
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