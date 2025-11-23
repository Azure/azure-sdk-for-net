// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    public class ListAnalyzersTest : ContentUnderstandingTestBase
    {
        public ListAnalyzersTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        /// <summary>
        /// Test Summary:
        /// - Create ContentUnderstandingClient using CreateClient()
        /// - List all available analyzers
        /// - Verify list response contains analyzers
        /// - Verify each analyzer has required properties
        /// </summary>
        [RecordedTest]
        public async Task TestListAllAnalyzers()
        {
            var client = CreateClient();

            TestContext.WriteLine("Step 1: Listing all available analyzers...");
            var analyzers = new List<ContentAnalyzer>();

            try
            {
                await foreach (var analyzer in client.GetAnalyzersAsync())
                {
                    analyzers.Add(analyzer);
                }

                TestContext.WriteLine($"  Found {analyzers.Count} analyzer(s)");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  Failed to list analyzers: {ex.Message}");
                TestContext.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Verify we get at least one analyzer in the list
            Assert.IsTrue(analyzers.Count > 0, "Should have at least one analyzer in the list");
            TestContext.WriteLine($"\n✓ Successfully retrieved {analyzers.Count} analyzer(s)");

            // Verify each analyzer has required properties
            TestContext.WriteLine("\nStep 2: Verifying analyzer properties...");
            foreach (var analyzer in analyzers)
            {
                Assert.IsNotNull(analyzer.AnalyzerId, "Each analyzer should have analyzer_id");
                Assert.IsNotNull(analyzer.Status, "Each analyzer should have status");
                Assert.IsNotNull(analyzer.CreatedAt, "Each analyzer should have created_at");

                TestContext.WriteLine($"  ✓ Analyzer: {analyzer.AnalyzerId} - Status: {analyzer.Status}");
            }

            TestContext.WriteLine("\n✓ All analyzers have required properties");
        }

        /// <summary>
        /// Test Summary:
        /// - List all analyzers
        /// - Count prebuilt vs custom analyzers
        /// - Verify prebuilt analyzers exist
        /// - Verify analyzer ID patterns
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzerCategorization()
        {
            var client = CreateClient();

            TestContext.WriteLine("Listing and categorizing analyzers...");
            var analyzers = new List<ContentAnalyzer>();

            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                analyzers.Add(analyzer);
            }

            Assert.IsTrue(analyzers.Count > 0, "Should have at least one analyzer");

            // Categorize analyzers
            var prebuiltAnalyzers = analyzers.Where(a => a.AnalyzerId?.StartsWith("prebuilt-") == true).ToList();
            var customAnalyzers = analyzers.Where(a => a.AnalyzerId?.StartsWith("prebuilt-") != true).ToList();

            TestContext.WriteLine($"\nSummary:");
            TestContext.WriteLine($"  Total analyzers: {analyzers.Count}");
            TestContext.WriteLine($"  Prebuilt analyzers: {prebuiltAnalyzers.Count}");
            TestContext.WriteLine($"  Custom analyzers: {customAnalyzers.Count}");

            // Verify prebuilt analyzers exist
            Assert.IsTrue(prebuiltAnalyzers.Count > 0, "Should have at least one prebuilt analyzer");
            TestContext.WriteLine($"\n✓ Found {prebuiltAnalyzers.Count} prebuilt analyzer(s)");

            // List prebuilt analyzers
            TestContext.WriteLine("\nPrebuilt analyzers:");
            foreach (var analyzer in prebuiltAnalyzers)
            {
                TestContext.WriteLine($"  - {analyzer.AnalyzerId}: {analyzer.Description ?? "(no description)"}");
                Assert.IsTrue(analyzer.AnalyzerId.StartsWith("prebuilt-"),
                    $"Prebuilt analyzer ID should start with 'prebuilt-': {analyzer.AnalyzerId}");
            }

            // List custom analyzers if any
            if (customAnalyzers.Count > 0)
            {
                TestContext.WriteLine("\nCustom analyzers:");
                foreach (var analyzer in customAnalyzers)
                {
                    TestContext.WriteLine($"  - {analyzer.AnalyzerId}: {analyzer.Description ?? "(no description)"}");
                }
            }

            TestContext.WriteLine("\n✓ Analyzer categorization completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Verify specific prebuilt analyzers exist
        /// - Check prebuilt-document or prebuilt-documentSearch analyzer
        /// - Verify analyzer status is ready
        /// </summary>
        [RecordedTest]
        public async Task TestPrebuiltAnalyzersExist()
        {
            var client = CreateClient();

            TestContext.WriteLine("Checking for expected prebuilt analyzers...");
            var analyzers = new List<ContentAnalyzer>();

            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                analyzers.Add(analyzer);
            }

            // Check for prebuilt-document or prebuilt-documentSearch
            var documentAnalyzer = analyzers.FirstOrDefault(a =>
                a.AnalyzerId == "prebuilt-document" ||
                a.AnalyzerId == "prebuilt-documentSearch");

            Assert.IsNotNull(documentAnalyzer,
                "Should find prebuilt-document or prebuilt-documentSearch analyzer");

            TestContext.WriteLine($"  ✓ Found document analyzer: {documentAnalyzer.AnalyzerId}");
            TestContext.WriteLine($"    Description: {documentAnalyzer.Description}");
            TestContext.WriteLine($"    Status: {documentAnalyzer.Status}");
            TestContext.WriteLine($"    Created at: {documentAnalyzer.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");

            // Verify status is ready
            Assert.AreEqual("ready", documentAnalyzer.Status.ToString().ToLowerInvariant(),
                "Prebuilt analyzer should be in ready status");

            TestContext.WriteLine("\n✓ Prebuilt analyzer verification completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - List analyzers and verify detailed properties
        /// - Check CreatedAt and LastModifiedAt timestamps
        /// - Verify analyzer configuration if available
        /// </summary>
        [RecordedTest]
        public async Task TestAnalyzerDetailedProperties()
        {
            var client = CreateClient();

            TestContext.WriteLine("Retrieving detailed analyzer properties...");
            var analyzers = new List<ContentAnalyzer>();

            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                analyzers.Add(analyzer);
            }

            Assert.IsTrue(analyzers.Count > 0, "Should have at least one analyzer");

            TestContext.WriteLine($"\nAnalyzing {analyzers.Count} analyzer(s) in detail:\n");
            TestContext.WriteLine("=============================================================");

            for (int i = 0; i < analyzers.Count; i++)
            {
                var analyzer = analyzers[i];

                TestContext.WriteLine($"\nAnalyzer {i + 1}:");
                TestContext.WriteLine($"  ID: {analyzer.AnalyzerId}");
                TestContext.WriteLine($"  Description: {analyzer.Description ?? "(none)"}");
                TestContext.WriteLine($"  Status: {analyzer.Status}");

                // Verify timestamps
                Assert.IsNotNull(analyzer.CreatedAt, "CreatedAt should not be null");
                TestContext.WriteLine($"  Created at: {analyzer.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");

                Assert.IsNotNull(analyzer.LastModifiedAt, "LastModifiedAt should not be null");
                TestContext.WriteLine($"  Last modified: {analyzer.LastModifiedAt:yyyy-MM-dd HH:mm:ss} UTC");

                // Verify LastModifiedAt is >= CreatedAt
                Assert.IsTrue(analyzer.LastModifiedAt >= analyzer.CreatedAt,
                    "LastModifiedAt should be greater than or equal to CreatedAt");

                // Check analyzer type
                if (analyzer.AnalyzerId?.StartsWith("prebuilt-") == true)
                {
                    TestContext.WriteLine("  Type: Prebuilt analyzer");
                }
                else
                {
                    TestContext.WriteLine("  Type: Custom analyzer");
                }

                // Check tags if available
                if (analyzer.Tags != null && analyzer.Tags.Count > 0)
                {
                    TestContext.WriteLine($"  Tags: {string.Join(", ", analyzer.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
                }
                else
                {
                    TestContext.WriteLine("  Tags: (none)");
                }

                // Check configuration if available
                if (analyzer.Config != null)
                {
                    TestContext.WriteLine("  Config: Available");
                }
            }

            TestContext.WriteLine("\n=============================================================");
            TestContext.WriteLine("✓ Detailed property verification completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Get a specific prebuilt analyzer
        /// - Verify detailed properties
        /// - Compare with list results
        /// </summary>
        [RecordedTest]
        public async Task TestGetSpecificPrebuiltAnalyzer()
        {
            var client = CreateClient();

            // First, list all analyzers to find a prebuilt one
            TestContext.WriteLine("Step 1: Finding a prebuilt analyzer...");
            ContentAnalyzer prebuiltAnalyzer = null;

            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                if (analyzer.AnalyzerId?.StartsWith("prebuilt-") == true)
                {
                    prebuiltAnalyzer = analyzer;
                    break;
                }
            }

            Assert.IsNotNull(prebuiltAnalyzer, "Should find at least one prebuilt analyzer");
            TestContext.WriteLine($"  Found: {prebuiltAnalyzer.AnalyzerId}");

            // Get the specific analyzer
            TestContext.WriteLine($"\nStep 2: Getting analyzer details for {prebuiltAnalyzer.AnalyzerId}...");
            var response = await client.GetAnalyzerAsync(prebuiltAnalyzer.AnalyzerId);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);

            var specificAnalyzer = response.Value;
            TestContext.WriteLine($"  ✓ Successfully retrieved analyzer: {specificAnalyzer.AnalyzerId}");

            // Verify properties match
            TestContext.WriteLine("\nStep 3: Verifying properties...");
            Assert.AreEqual(prebuiltAnalyzer.AnalyzerId, specificAnalyzer.AnalyzerId);
            Assert.AreEqual(prebuiltAnalyzer.Status, specificAnalyzer.Status);
            Assert.IsNotNull(specificAnalyzer.Description);
            Assert.IsTrue(specificAnalyzer.Description.Length > 0);
            Assert.IsNotNull(specificAnalyzer.CreatedAt);
            Assert.IsNotNull(specificAnalyzer.Config);

            TestContext.WriteLine($"  ID: {specificAnalyzer.AnalyzerId}");
            TestContext.WriteLine($"  Description: {specificAnalyzer.Description}");
            TestContext.WriteLine($"  Status: {specificAnalyzer.Status}");
            TestContext.WriteLine($"  Created at: {specificAnalyzer.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");

            TestContext.WriteLine("\n✓ Analyzer details verification completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Test error handling for invalid analyzer ID
        /// - Verify appropriate exception is thrown
        /// </summary>
        [RecordedTest]
        public async Task TestGetNonExistentAnalyzer()
        {
            var client = CreateClient();

            string nonExistentAnalyzerId = "non-existent-analyzer-" + Guid.NewGuid().ToString();
            TestContext.WriteLine($"Attempting to get non-existent analyzer: {nonExistentAnalyzerId}");

            try
            {
                var response = await client.GetAnalyzerAsync(nonExistentAnalyzerId);
                Assert.Fail("Should have thrown RequestFailedException for non-existent analyzer");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                TestContext.WriteLine($"  Status: {ex.Status}");
                TestContext.WriteLine($"  Error Code: {ex.ErrorCode}");

                // Verify it's a 404 Not Found
                Assert.AreEqual(404, ex.Status, "Should return 404 for non-existent analyzer");
            }

            TestContext.WriteLine("\n✓ Error handling verification completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - List analyzers multiple times
        /// - Verify consistency of results
        /// - Check that analyzer count remains stable
        /// </summary>
        [RecordedTest]
        public async Task TestListAnalyzersConsistency()
        {
            var client = CreateClient();

            TestContext.WriteLine("Step 1: First listing of analyzers...");
            var firstList = new List<ContentAnalyzer>();
            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                firstList.Add(analyzer);
            }
            TestContext.WriteLine($"  Found {firstList.Count} analyzer(s)");

            TestContext.WriteLine("\nStep 2: Second listing of analyzers...");
            var secondList = new List<ContentAnalyzer>();
            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                secondList.Add(analyzer);
            }
            TestContext.WriteLine($"  Found {secondList.Count} analyzer(s)");

            // Verify counts match
            Assert.AreEqual(firstList.Count, secondList.Count,
                "Analyzer count should be consistent between listings");

            // Verify same analyzer IDs exist in both lists
            var firstIds = firstList.Select(a => a.AnalyzerId).OrderBy(id => id).ToList();
            var secondIds = secondList.Select(a => a.AnalyzerId).OrderBy(id => id).ToList();

            CollectionAssert.AreEqual(firstIds, secondIds,
                "Analyzer IDs should be consistent between listings");

            TestContext.WriteLine($"\n✓ Both listings returned {firstList.Count} analyzer(s) with consistent IDs");
            TestContext.WriteLine("✓ Consistency verification completed successfully");
        }

        /// <summary>
        /// Test Summary:
        /// - Test pagination behavior (if applicable)
        /// - Verify all analyzers are returned
        /// </summary>
        [RecordedTest]
        public async Task TestListAnalyzersPagination()
        {
            var client = CreateClient();

            TestContext.WriteLine("Testing analyzer listing with pagination...");
            var allAnalyzers = new List<ContentAnalyzer>();
            int pageCount = 0;
            int itemsPerPage = 0;

            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                allAnalyzers.Add(analyzer);
                itemsPerPage++;

                // Track "pages" (in practice, we just count items)
                if (itemsPerPage == 10) // Assume 10 items per page for tracking
                {
                    pageCount++;
                    TestContext.WriteLine($"  Retrieved page {pageCount} with {itemsPerPage} items");
                    itemsPerPage = 0;
                }
            }

            if (itemsPerPage > 0)
            {
                pageCount++;
                TestContext.WriteLine($"  Retrieved final page {pageCount} with {itemsPerPage} items");
            }

            TestContext.WriteLine($"\n✓ Total: {allAnalyzers.Count} analyzer(s) across {pageCount} page(s)");
            Assert.IsTrue(allAnalyzers.Count > 0, "Should retrieve at least one analyzer");

            // Verify no duplicates
            var distinctIds = allAnalyzers.Select(a => a.AnalyzerId).Distinct().ToList();
            Assert.AreEqual(allAnalyzers.Count, distinctIds.Count,
                "Should not have duplicate analyzer IDs");

            TestContext.WriteLine("✓ Pagination test completed successfully");
        }
    }
}
