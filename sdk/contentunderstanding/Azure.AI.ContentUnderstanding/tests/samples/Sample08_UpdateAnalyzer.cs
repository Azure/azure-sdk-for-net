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
