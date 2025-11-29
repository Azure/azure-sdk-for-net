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
            Console.WriteLine($"Found {analyzers.Count} analyzer(s)");

            // Verify counts
            Assert.IsTrue(prebuiltCount >= 0, "Prebuilt count should be >= 0");
            Assert.IsTrue(customCount >= 0, "Custom count should be >= 0");
            Assert.AreEqual(analyzers.Count, prebuiltCount + customCount,
                "Total count should equal prebuilt + custom count");
            Console.WriteLine($"Count breakdown: {prebuiltCount} prebuilt, {customCount} custom");

            // Verify prebuilt analyzers exist (there should always be some prebuilt analyzers)
            Assert.IsTrue(prebuiltCount > 0, "Should have at least one prebuilt analyzer");
            Console.WriteLine($"Prebuilt analyzers present: {prebuiltCount}");

            // Verify each analyzer has required properties
            int validAnalyzers = 0;
            int analyzersWithDescription = 0;

            foreach (var analyzer in analyzers)
            {
                Assert.IsNotNull(analyzer, "Analyzer should not be null");
                Assert.IsNotNull(analyzer.AnalyzerId, "Analyzer ID should not be null");
                Assert.IsFalse(string.IsNullOrWhiteSpace(analyzer.AnalyzerId),
                    $"Analyzer ID should not be empty or whitespace");

                validAnalyzers++;

                // Track optional properties
                if (!string.IsNullOrWhiteSpace(analyzer.Description))
                {
                    analyzersWithDescription++;
                }

                // Verify analyzer ID format (should not contain spaces or special characters)
                Assert.IsFalse(analyzer.AnalyzerId.Contains(" "),
                    $"Analyzer ID should not contain spaces: {analyzer.AnalyzerId}");
            }

            Assert.AreEqual(analyzers.Count, validAnalyzers, "All analyzers should have valid IDs");
            Console.WriteLine($"All {validAnalyzers} analyzers have valid IDs");
            Console.WriteLine($"  Analyzers with description: {analyzersWithDescription}");

            // Verify common prebuilt analyzers exist
            var analyzerIds = new List<string>();
            foreach (var analyzer in analyzers)
            {
                if (analyzer.AnalyzerId != null)
                {
                    analyzerIds.Add(analyzer.AnalyzerId);
                }
            }
            var commonPrebuiltAnalyzers = new[]
            {
                "prebuilt-document",
                "prebuilt-documentSearch",
                "prebuilt-invoice"
            };

            int foundCommonAnalyzers = 0;
            foreach (var prebuiltId in commonPrebuiltAnalyzers)
            {
                if (analyzerIds.Contains(prebuiltId))
                {
                    foundCommonAnalyzers++;
                    Console.WriteLine($"  Found common analyzer: {prebuiltId}");
                }
                else
                {
                    Console.WriteLine($"  ⚠️ Common analyzer not found: {prebuiltId}");
                }

                Assert.IsTrue(analyzerIds.Contains(prebuiltId),
                    $"Should contain common prebuilt analyzer: {prebuiltId}");
            }

            Assert.AreEqual(commonPrebuiltAnalyzers.Length, foundCommonAnalyzers,
                "All common prebuilt analyzers should be present");
            Console.WriteLine($"All {foundCommonAnalyzers} common prebuilt analyzers verified");

            // Verify prebuilt analyzer naming convention
            var prebuiltAnalyzers = analyzers.Where(a => a.AnalyzerId?.StartsWith("prebuilt-") == true).ToList();
            Assert.AreEqual(prebuiltCount, prebuiltAnalyzers.Count,
                "Prebuilt count should match filtered list");

            foreach (var prebuilt in prebuiltAnalyzers)
            {
                Assert.IsTrue(prebuilt.AnalyzerId!.StartsWith("prebuilt-"),
                    $"Prebuilt analyzer ID should start with 'prebuilt-': {prebuilt.AnalyzerId}");

                // Verify prebuilt analyzer ID format (should be lowercase with hyphens)
                Assert.IsFalse(prebuilt.AnalyzerId.Contains(" "),
                    $"Prebuilt analyzer ID should not contain spaces: {prebuilt.AnalyzerId}");
                Assert.IsFalse(prebuilt.AnalyzerId.Contains("_"),
                    $"Prebuilt analyzer ID should use hyphens, not underscores: {prebuilt.AnalyzerId}");
            }
            Console.WriteLine($"All {prebuiltAnalyzers.Count} prebuilt analyzers follow naming convention");

            // Verify custom analyzers (if any)
            var customAnalyzers = analyzers.Where(a => a.AnalyzerId?.StartsWith("prebuilt-") != true).ToList();
            Assert.AreEqual(customCount, customAnalyzers.Count,
                "Custom count should match filtered list");

            if (customAnalyzers.Count > 0)
            {
                Console.WriteLine($"Found {customAnalyzers.Count} custom analyzer(s):");
                foreach (var custom in customAnalyzers.Take(5)) // Show first 5 custom analyzers
                {
                    Console.WriteLine($"  - {custom.AnalyzerId}");
                    if (!string.IsNullOrWhiteSpace(custom.Description))
                    {
                        Console.WriteLine($"    Description: {custom.Description}");
                    }
                }
                if (customAnalyzers.Count > 5)
                {
                    Console.WriteLine($"  ...  and {customAnalyzers.Count - 5} more");
                }
            }
            else
            {
                Console.WriteLine("No custom analyzers found");
            }

            // Verify no duplicate analyzer IDs
            var duplicateIds = analyzerIds
                .GroupBy(id => id)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            Assert.AreEqual(0, duplicateIds.Count,
                $"Should not have duplicate analyzer IDs: {string.Join(", ", duplicateIds)}");
            Assert.AreEqual(analyzers.Count, analyzerIds.Count,
                "Number of unique analyzer IDs should match total count");
            Console.WriteLine($"All analyzer IDs are unique");

            // Summary statistics
            Console.WriteLine($"\nVerification completed successfully:");
            Console.WriteLine($"  Total analyzers: {analyzers.Count}");
            Console.WriteLine($"  Prebuilt: {prebuiltCount} ({(double)prebuiltCount / analyzers.Count * 100:F1}%)");
            Console.WriteLine($"  Custom: {customCount} ({(double)customCount / analyzers.Count * 100:F1}%)");
            Console.WriteLine($"  With description: {analyzersWithDescription} ({(double)analyzersWithDescription / analyzers.Count * 100:F1}%)");
            Console.WriteLine($"  Common prebuilt analyzers: {foundCommonAnalyzers}/{commonPrebuiltAnalyzers.Length}");
            #endregion
        }
    }
}