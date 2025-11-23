// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
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
        public async Task DeleteAnalyzerAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingCreateSimpleAnalyzer
            // First create a simple analyzer to delete
#if SNIPPET
            // Generate a unique analyzer ID
            string analyzerId = $"my_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
#else
            // Generate a unique analyzer ID and record it for playback
            string defaultId = $"test_analyzer_{Recording.Random.NewGuid().ToString("N")}";
            string analyzerId = Recording.GetVariable("deleteAnalyzerId", defaultId) ?? defaultId;
#endif

            // Create a simple analyzer
            var analyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Simple analyzer for deletion example",
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                }
            };
            analyzer.Models.Add("completion", "gpt-4.1");

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                analyzer,
                allowReplace: true);

            Console.WriteLine($"Analyzer '{analyzerId}' created successfully.");
            #endregion

            #region Snippet:ContentUnderstandingDeleteAnalyzer
#if SNIPPET
            // Delete an analyzer
            await client.DeleteAnalyzerAsync(analyzerId);
            Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
#else
            // Delete an analyzer
            await client.DeleteAnalyzerAsync(analyzerId);
            Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully.");
#endif
            #endregion
        }
    }
}
