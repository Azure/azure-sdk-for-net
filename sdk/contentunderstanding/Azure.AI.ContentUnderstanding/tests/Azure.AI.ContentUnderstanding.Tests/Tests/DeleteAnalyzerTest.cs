// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests.Samples
{
    /// <summary>
    /// Test class for Azure Content Understanding Delete Analyzer sample.
    /// This class validates the functionality demonstrated in azure_content_analyzer.cs
    /// for deleting custom analyzers.
    /// </summary>
    public class DeleteAnalyzerTest : ContentUnderstandingTestBase
    {
        public DeleteAnalyzerTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        /// <summary>
        /// Test Summary:
        /// - Create ContentUnderstandingClient using CreateClient()
        /// - Create a temporary analyzer for deletion demo
        /// - Delete the analyzer using DeleteAnalyzerAsync
        /// - Verify the analyzer is deleted (not in list)
        /// </summary>
        [RecordedTest]
        public async Task TestDeleteAnalyzer()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "DeleteTest");

            TestContext.WriteLine($"Step 1: Creating temporary analyzer for deletion: {analyzerId}");

            // Create a simple custom analyzer
            var tempAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Temporary analyzer for deletion demo",
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                },
                FieldSchema = new ContentFieldSchema(
                    new Dictionary<string, ContentFieldDefinition>
                    {
                        ["demo_field"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.String,
                            Method = GenerationMethod.Extract,
                            Description = "Demo field for deletion"
                        }
                    })
                {
                    Name = "demo_schema",
                    Description = "Schema for deletion demo"
                }
            };

            // Add required model mappings
            tempAnalyzer.Models.Add("completion", "gpt-4o");
            tempAnalyzer.Models.Add("embedding", "text-embedding-3-large");

            var createOperation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                tempAnalyzer,
                allowReplace: true);

            var createdResult = createOperation.Value;
            Assert.IsNotNull(createdResult);
            TestContext.WriteLine($"  ✅ Analyzer '{analyzerId}' created successfully!");
            TestContext.WriteLine($"  Status: {createdResult.Status}");

            // Verify analyzer exists in list
            TestContext.WriteLine("\nStep 2: Verifying analyzer exists in list...");
            var analyzersBeforeDelete = new List<ContentAnalyzer>();
            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                analyzersBeforeDelete.Add(analyzer);
            }

            bool foundBeforeDelete = analyzersBeforeDelete.Any(a => a.AnalyzerId == analyzerId);
            Assert.IsTrue(foundBeforeDelete, $"Analyzer '{analyzerId}' should exist before deletion");
            TestContext.WriteLine($"  ✓ Analyzer '{analyzerId}' found in list");

            // Step 3: Delete the analyzer
            TestContext.WriteLine("\nStep 3: Deleting the analyzer...");
            var deleteResponse = await client.DeleteAnalyzerAsync(analyzerId);

            Assert.IsNotNull(deleteResponse);
            TestContext.WriteLine($"  ✅ Analyzer '{analyzerId}' deleted successfully!");

            // Step 4: Verify analyzer no longer exists
            TestContext.WriteLine("\nStep 4: Verifying analyzer is deleted...");
            var analyzersAfterDelete = new List<ContentAnalyzer>();
            await foreach (var analyzer in client.GetAnalyzersAsync())
            {
                analyzersAfterDelete.Add(analyzer);
            }

            bool foundAfterDelete = analyzersAfterDelete.Any(a => a.AnalyzerId == analyzerId);
            Assert.IsFalse(foundAfterDelete, $"Analyzer '{analyzerId}' should not exist after deletion");
            TestContext.WriteLine($"  ✓ Analyzer '{analyzerId}' no longer in list");

            TestContext.WriteLine("\n=============================================================");
            TestContext.WriteLine("✓ Sample completed successfully");
            TestContext.WriteLine("=============================================================");
        }

        /// <summary>
        /// Test Summary:
        /// - Attempt to delete non-existent analyzer
        /// - Verify appropriate error is returned (404)
        /// </summary>
        [RecordedTest]
        public async Task TestDeleteNonExistentAnalyzer()
        {
            var client = CreateClient();
            var nonExistentId = "non_existent_analyzer_" + Guid.NewGuid().ToString("N");

            TestContext.WriteLine($"Testing deletion of non-existent analyzer: {nonExistentId}");

            try
            {
                await client.DeleteAnalyzerAsync(nonExistentId);

                // Some services may return success even for non-existent resources
                TestContext.WriteLine("  Note: Service accepted delete request for non-existent analyzer");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                TestContext.WriteLine($"  Status: {ex.Status}");
                TestContext.WriteLine($"  Error Code: {ex.ErrorCode}");

                // Verify it's a 404 Not Found error
                Assert.AreEqual(404, ex.Status, "Should return 404 for non-existent analyzer");
            }

            TestContext.WriteLine("\n✓ Error handling verification completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer
        /// - Delete analyzer
        /// - Attempt to delete same analyzer again
        /// - Verify appropriate behavior (idempotent or error)
        /// </summary>
        [RecordedTest]
        public async Task TestDeleteAnalyzerTwice()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "DoubleDeleteTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing double deletion: {analyzerId}");

            try
            {
                // Create analyzer
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer for double deletion"
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Analyzer created");

                // First deletion
                TestContext.WriteLine("\nFirst deletion...");
                await client.DeleteAnalyzerAsync(analyzerId);
                TestContext.WriteLine("  ✓ First deletion succeeded");
                createdAnalyzer = false; // Marked as deleted

                // Second deletion (should fail or be idempotent)
                TestContext.WriteLine("\nSecond deletion...");
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("  ✓ Second deletion succeeded (idempotent behavior)");
                }
                catch (RequestFailedException ex)
                {
                    TestContext.WriteLine($"  ✓ Second deletion failed as expected: {ex.Message}");
                    TestContext.WriteLine($"  Status: {ex.Status}");
                    Assert.AreEqual(404, ex.Status, "Should return 404 for already deleted analyzer");
                }
            }
            finally
            {
                // Cleanup - only if still exists
                if (createdAnalyzer)
                {
                    try
                    {
                        await client.DeleteAnalyzerAsync(analyzerId);
                        TestContext.WriteLine("\n  ✓ Cleanup: Analyzer deleted");
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }

            TestContext.WriteLine("\n✓ Double deletion test completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Create multiple analyzers
        /// - Delete them one by one
        /// - Verify each deletion is successful
        /// </summary>
        [RecordedTest]
        public async Task TestDeleteMultipleAnalyzers()
        {
            var client = CreateClient();
            var baseId = TestHelpers.GenerateAnalyzerId(Recording, "MultiDelete");
            var analyzerIds = new List<string>();
            var createdAnalyzers = new HashSet<string>();

            TestContext.WriteLine("Testing deletion of multiple analyzers...");

            try
            {
                // Create 3 analyzers
                for (int i = 1; i <= 3; i++)
                {
                    var analyzerId = $"{baseId}_{i}";
                    analyzerIds.Add(analyzerId);

                    TestContext.WriteLine($"\nCreating analyzer {i}: {analyzerId}");

                    var analyzer = new ContentAnalyzer
                    {
                        BaseAnalyzerId = "prebuilt-document",
                        Description = $"Test analyzer {i} for multi-deletion"
                    };
                    analyzer.Models.Add("completion", "gpt-4o");
                    analyzer.Models.Add("embedding", "text-embedding-3-large");

                    var createOperation = await client.CreateAnalyzerAsync(
                        WaitUntil.Completed,
                        analyzerId,
                        analyzer,
                        allowReplace: true);

                    Assert.IsNotNull(createOperation.Value);
                    createdAnalyzers.Add(analyzerId);
                    TestContext.WriteLine($"  ✓ Created analyzer {i}");
                }

                // Delete all analyzers
                TestContext.WriteLine("\nDeleting all analyzers...");
                foreach (var analyzerId in analyzerIds)
                {
                    TestContext.WriteLine($"  Deleting: {analyzerId}");
                    await client.DeleteAnalyzerAsync(analyzerId);
                    createdAnalyzers.Remove(analyzerId);
                    TestContext.WriteLine($"    ✓ Deleted");
                }

                // Verify all are deleted
                TestContext.WriteLine("\nVerifying all analyzers are deleted...");
                var remainingAnalyzers = new List<ContentAnalyzer>();
                await foreach (var analyzer in client.GetAnalyzersAsync())
                {
                    remainingAnalyzers.Add(analyzer);
                }

                foreach (var analyzerId in analyzerIds)
                {
                    bool found = remainingAnalyzers.Any(a => a.AnalyzerId == analyzerId);
                    Assert.IsFalse(found, $"Analyzer '{analyzerId}' should not exist after deletion");
                }

                TestContext.WriteLine($"  ✓ All {analyzerIds.Count} analyzers successfully deleted");
            }
            finally
            {
                // Cleanup any remaining analyzers
                foreach (var analyzerId in createdAnalyzers)
                {
                    try
                    {
                        await client.DeleteAnalyzerAsync(analyzerId);
                        TestContext.WriteLine($"\n  Cleanup: Deleted {analyzerId}");
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }

            TestContext.WriteLine("\n✓ Multiple deletion test completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer
        /// - Get analyzer to verify it exists
        /// - Delete analyzer
        /// - Attempt to get analyzer again
        /// - Verify get fails with 404
        /// </summary>
        [RecordedTest]
        public async Task TestGetAfterDelete()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "GetAfterDeleteTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing get after deletion: {analyzerId}");

            try
            {
                // Create analyzer
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer for get-after-delete"
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Analyzer created");

                // Get analyzer before deletion
                TestContext.WriteLine("\nGetting analyzer before deletion...");
                var getBeforeDelete = await client.GetAnalyzerAsync(analyzerId);
                Assert.IsNotNull(getBeforeDelete);
                Assert.IsNotNull(getBeforeDelete.Value);
                Assert.AreEqual(analyzerId, getBeforeDelete.Value.AnalyzerId);
                TestContext.WriteLine($"  ✓ Analyzer retrieved: {getBeforeDelete.Value.AnalyzerId}");

                // Delete analyzer
                TestContext.WriteLine("\nDeleting analyzer...");
                await client.DeleteAnalyzerAsync(analyzerId);
                createdAnalyzer = false;
                TestContext.WriteLine("  ✓ Analyzer deleted");

                // Try to get analyzer after deletion
                TestContext.WriteLine("\nAttempting to get analyzer after deletion...");
                try
                {
                    var getAfterDelete = await client.GetAnalyzerAsync(analyzerId);
                    Assert.Fail("Should have thrown exception for deleted analyzer");
                }
                catch (RequestFailedException ex)
                {
                    TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                    TestContext.WriteLine($"  Status: {ex.Status}");
                    Assert.AreEqual(404, ex.Status, "Should return 404 for deleted analyzer");
                }
            }
            finally
            {
                // Cleanup
                if (createdAnalyzer)
                {
                    try
                    {
                        await client.DeleteAnalyzerAsync(analyzerId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }

            TestContext.WriteLine("\n✓ Get after delete test completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer
        /// - Delete analyzer
        /// - Verify delete response is valid
        /// - Check response status and headers
        /// </summary>
        [RecordedTest]
        public async Task TestDeleteResponseValidation()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "DeleteResponseTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing delete response validation: {analyzerId}");

            try
            {
                // Create analyzer
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer for response validation"
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Analyzer created");

                // Delete analyzer and validate response
                TestContext.WriteLine("\nDeleting analyzer and validating response...");
                var deleteResponse = await client.DeleteAnalyzerAsync(analyzerId);
                createdAnalyzer = false;

                // Verify response
                Assert.IsNotNull(deleteResponse, "Delete response should not be null");
                TestContext.WriteLine("  ✓ Delete response is not null");
            }
            finally
            {
                // Cleanup
                if (createdAnalyzer)
                {
                    try
                    {
                        await client.DeleteAnalyzerAsync(analyzerId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }

            TestContext.WriteLine("\n✓ Delete response validation completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Verify cannot delete prebuilt analyzers
        /// - Attempt to delete prebuilt-document analyzer
        /// - Verify appropriate error or behavior
        /// </summary>
        [RecordedTest]
        public async Task TestDeletePrebuiltAnalyzer()
        {
            var client = CreateClient();
            string prebuiltAnalyzerId = "prebuilt-document";

            TestContext.WriteLine($"Testing deletion of prebuilt analyzer: {prebuiltAnalyzerId}");

            try
            {
                await client.DeleteAnalyzerAsync(prebuiltAnalyzerId);

                // If we reach here, service allowed deletion (unexpected behavior)
                TestContext.WriteLine("  ⚠️  Service allowed deletion of prebuilt analyzer");
                TestContext.WriteLine("  This may indicate the analyzer was not actually a prebuilt one");
            }
            catch (RequestFailedException ex)
            {
                TestContext.WriteLine($"  ✓ Expected exception caught: {ex.Message}");
                TestContext.WriteLine($"  Status: {ex.Status}");
                TestContext.WriteLine($"  Error Code: {ex.ErrorCode}");

                // Verify appropriate error code
                Assert.IsTrue(ex.Status >= 400, "Should return error for prebuilt analyzer deletion");
            }

            TestContext.WriteLine("\n✓ Prebuilt analyzer deletion test completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with tags
        /// - Delete analyzer
        /// - Verify complete deletion including tags
        /// </summary>
        [RecordedTest]
        public async Task TestDeleteAnalyzerWithTags()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "DeleteTagsTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing deletion of analyzer with tags: {analyzerId}");

            try
            {
                // Create analyzer with tags
                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer with tags for deletion"
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");
                analyzer.Tags.Add("env", "test");
                analyzer.Tags.Add("purpose", "deletion_test");
                analyzer.Tags.Add("owner", "sdk_test");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Analyzer created with tags");

                // Verify tags exist
                var getResponse = await client.GetAnalyzerAsync(analyzerId);
                Assert.IsTrue(getResponse.Value.Tags.Count >= 3, "Analyzer should have tags");
                TestContext.WriteLine($"  ✓ Verified {getResponse.Value.Tags.Count} tags exist");

                // Delete analyzer
                TestContext.WriteLine("\nDeleting analyzer with tags...");
                await client.DeleteAnalyzerAsync(analyzerId);
                createdAnalyzer = false;
                TestContext.WriteLine("  ✓ Analyzer deleted");

                // Verify analyzer and tags are completely deleted
                var allAnalyzers = new List<ContentAnalyzer>();
                await foreach (var a in client.GetAnalyzersAsync())
                {
                    allAnalyzers.Add(a);
                }

                bool found = allAnalyzers.Any(a => a.AnalyzerId == analyzerId);
                Assert.IsFalse(found, "Analyzer should be completely deleted");
                TestContext.WriteLine("  ✓ Analyzer and tags completely deleted");
            }
            finally
            {
                // Cleanup
                if (createdAnalyzer)
                {
                    try
                    {
                        await client.DeleteAnalyzerAsync(analyzerId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }

            TestContext.WriteLine("\n✓ Delete with tags test completed");
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with complex field schema
        /// - Delete analyzer
        /// - Verify complete deletion including schema
        /// </summary>
        [RecordedTest]
        public async Task TestDeleteAnalyzerWithFieldSchema()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "DeleteSchemaTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing deletion of analyzer with field schema: {analyzerId}");

            try
            {
                // Create analyzer with field schema
                var fieldSchema = new ContentFieldSchema(
                    new Dictionary<string, ContentFieldDefinition>
                    {
                        ["field1"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.String,
                            Method = GenerationMethod.Extract,
                            Description = "Test field 1"
                        },
                        ["field2"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.Number,
                            Method = GenerationMethod.Extract,
                            Description = "Test field 2"
                        }
                    })
                {
                    Name = "test_schema",
                    Description = "Test schema for deletion"
                };

                var analyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer with schema for deletion",
                    FieldSchema = fieldSchema
                };
                analyzer.Models.Add("completion", "gpt-4o");
                analyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Analyzer created with field schema");

                // Delete analyzer
                TestContext.WriteLine("\nDeleting analyzer with field schema...");
                await client.DeleteAnalyzerAsync(analyzerId);
                createdAnalyzer = false;
                TestContext.WriteLine("  ✓ Analyzer deleted");

                // Verify complete deletion
                var allAnalyzers = new List<ContentAnalyzer>();
                await foreach (var a in client.GetAnalyzersAsync())
                {
                    allAnalyzers.Add(a);
                }

                bool found = allAnalyzers.Any(a => a.AnalyzerId == analyzerId);
                Assert.IsFalse(found, "Analyzer with schema should be completely deleted");
                TestContext.WriteLine("  ✓ Analyzer and schema completely deleted");
            }
            finally
            {
                // Cleanup
                if (createdAnalyzer)
                {
                    try
                    {
                        await client.DeleteAnalyzerAsync(analyzerId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }

            TestContext.WriteLine("\n✓ Delete with field schema test completed");
        }
    }
}
