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
        public async Task ListAnalyzersAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingListAnalyzers
#if SNIPPET
            // List all analyzers
            var analyzers = new List<ContentAnalyzer>();
            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                analyzers.Add(analyzer);
            }

            Console.WriteLine($"Found {analyzers.Count} analyzer(s)");

            // Display summary
            var prebuiltCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") == true);
            var customCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") != true);
            Console.WriteLine($"  Prebuilt analyzers: {prebuiltCount}");
            Console.WriteLine($"  Custom analyzers: {customCount}");

            // Display details for each analyzer
            foreach (var analyzer in analyzers)
            {
                Console.WriteLine($"  ID: {analyzer.AnalyzerId}");
                Console.WriteLine($"  Description: {analyzer.Description ?? "(none)"}");
                Console.WriteLine($"  Status: {analyzer.Status}");

                if (analyzer.AnalyzerId?.StartsWith("prebuilt-") == true)
                {
                    Console.WriteLine("  Type: Prebuilt analyzer");
                }
                else
                {
                    Console.WriteLine("  Type: Custom analyzer");
                }
            }
#else
            // List all analyzers
            var analyzers = new List<ContentAnalyzer>();
            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                analyzers.Add(analyzer);
            }

            Console.WriteLine($"Found {analyzers.Count} analyzer(s)");

            // Display summary
            var prebuiltCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") == true);
            var customCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") != true);
            Console.WriteLine($"  Prebuilt analyzers: {prebuiltCount}");
            Console.WriteLine($"  Custom analyzers: {customCount}");

            // Display details for each analyzer (limit to first 10 for test output)
            foreach (var analyzer in analyzers.Take(10))
            {
                Console.WriteLine($"  ID: {analyzer.AnalyzerId}");
                Console.WriteLine($"  Description: {analyzer.Description ?? "(none)"}");
                Console.WriteLine($"  Status: {analyzer.Status}");

                if (analyzer.AnalyzerId?.StartsWith("prebuilt-") == true)
                {
                    Console.WriteLine("  Type: Prebuilt analyzer");
                }
                else
                {
                    Console.WriteLine("  Type: Custom analyzer");
                }
            }
#endif
            #endregion
        }
    }
}
