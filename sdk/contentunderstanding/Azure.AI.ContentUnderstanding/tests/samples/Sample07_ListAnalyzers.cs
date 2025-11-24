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

            #region Assertion:ContentUnderstandingListAnalyzers
            Assert.IsNotNull(analyzers, "Analyzers list should not be null");
            Assert.IsTrue(analyzers.Count > 0, "Should have at least one analyzer");

            // Verify prebuilt analyzers exist (there should always be some prebuilt analyzers)
            Assert.IsTrue(prebuiltCount > 0, "Should have at least one prebuilt analyzer");
            Assert.AreEqual(analyzers.Count, prebuiltCount + customCount,
                "Total count should equal prebuilt + custom count");

            // Verify each analyzer has required properties
            foreach (var analyzer in analyzers)
            {
                Assert.IsNotNull(analyzer, "Analyzer should not be null");
                Assert.IsNotNull(analyzer.AnalyzerId, "Analyzer ID should not be null");
                Assert.IsFalse(string.IsNullOrWhiteSpace(analyzer.AnalyzerId),
                    "Analyzer ID should not be empty or whitespace");

                // Status may be null for some analyzers, but if present should be valid
                // Description is optional, so no assertion needed
            }

            // Verify common prebuilt analyzers exist
            var analyzerIds = analyzers.Select(a => a.AnalyzerId).ToList();
            var commonPrebuiltAnalyzers = new[]
            {
                "prebuilt-document",
                "prebuilt-documentSearch",
                "prebuilt-invoice"
            };

            foreach (var prebuiltId in commonPrebuiltAnalyzers)
            {
                Assert.IsTrue(analyzerIds.Contains(prebuiltId),
                    $"Should contain common prebuilt analyzer: {prebuiltId}");
            }

            // Verify prebuilt analyzer naming convention
            var prebuiltAnalyzers = analyzers.Where(a => a.AnalyzerId?.StartsWith("prebuilt-") == true).ToList();
            foreach (var prebuilt in prebuiltAnalyzers)
            {
                Assert.IsTrue(prebuilt.AnalyzerId!.StartsWith("prebuilt-"),
                    $"Prebuilt analyzer ID should start with 'prebuilt-': {prebuilt.AnalyzerId}");
            }

            Console.WriteLine($"\n✓ Verification completed:");
            Console.WriteLine($"  Total analyzers: {analyzers.Count}");
            Console.WriteLine($"  Prebuilt: {prebuiltCount}, Custom: {customCount}");
            #endregion
        }
    }
}