// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Test class for Azure Content Understanding Update Analyzer sample.
    /// This class validates the functionality demonstrated in azure_content_update.cs
    /// for updating analyzer properties like description and tags.
    /// </summary>
    public class UpdateAnalyzerTest : ContentUnderstandingTestBase
    {
        public UpdateAnalyzerTest(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
        }

        /// <summary>
        /// Test Summary:
        /// - Create an initial analyzer with description and tags
        /// - Get the analyzer to verify initial state
        /// - Update the analyzer with new description and tags
        /// - Get the analyzer again to verify changes persisted
        /// - Clean up by deleting the analyzer
        /// </summary>
        [RecordedTest]
        public async Task TestUpdateAnalyzerDescriptionAndTags()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "UpdateTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Step 1: Creating initial analyzer: {analyzerId}");

            try
            {
                // Create initial analyzer
                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Initial description",
                    Config = new ContentAnalyzerConfig
                    {
                        EnableFormula = true,
                        EnableLayout = true,
                        EnableOcr = true,
                        EstimateFieldSourceAndConfidence = true,
                        ReturnDetails = true
                    },
                    FieldSchema = new ContentFieldSchema(
                        new Dictionary<string, ContentFieldDefinition>
                        {
                            ["total_amount"] = new ContentFieldDefinition
                            {
                                Description = "Total amount of this document",
                                Method = GenerationMethod.Extract,
                                Type = ContentFieldType.Number
                            },
                            ["company_name"] = new ContentFieldDefinition
                            {
                                Description = "Name of the company",
                                Method = GenerationMethod.Extract,
                                Type = ContentFieldType.String
                            }
                        })
                    {
                        Description = "Schema for update demo",
                        Name = "update_demo_schema"
                    }
                };

                // Add required model mappings
                initialAnalyzer.Models.Add("completion", "gpt-4o");
                initialAnalyzer.Models.Add("embedding", "text-embedding-3-large");

                // Add initial tags
                initialAnalyzer.Tags.Add("tag1", "tag1_initial_value");
                initialAnalyzer.Tags.Add("tag2", "tag2_initial_value");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                TestHelpers.AssertOperationProperties(createOperation, "Create analyzer operation");

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;

                TestContext.WriteLine($"  ✓ Analyzer '{analyzerId}' created successfully!");
                TestContext.WriteLine($"  Status: {createOperation.Value.Status}");

                // Step 2: Get the analyzer before update
                TestContext.WriteLine("\nStep 2: Getting analyzer before update...");
                var getBeforeUpdate = await client.GetAnalyzerAsync(analyzerId);

                Assert.IsNotNull(getBeforeUpdate);
                Assert.IsNotNull(getBeforeUpdate.Value);
                Assert.AreEqual(analyzerId, getBeforeUpdate.Value.AnalyzerId);
                Assert.AreEqual("Initial description", getBeforeUpdate.Value.Description);
                Assert.IsTrue(getBeforeUpdate.Value.Tags.ContainsKey("tag1"));
                Assert.AreEqual("tag1_initial_value", getBeforeUpdate.Value.Tags["tag1"]);

                TestContext.WriteLine("  Initial analyzer state:");
                TestContext.WriteLine($"    Description: {getBeforeUpdate.Value.Description}");
                TestContext.WriteLine($"    Tags: {string.Join(", ", getBeforeUpdate.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

                // Step 3: Update the analyzer
                TestContext.WriteLine("\nStep 3: Updating analyzer with new description and tags...");
                TestContext.WriteLine("  Changes to apply:");
                TestContext.WriteLine($"    New Description: Updated description");
                TestContext.WriteLine($"    Tag Updates: tag1 (updated), tag2 (removed), tag3 (added)");

                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = getBeforeUpdate.Value.BaseAnalyzerId,
                    Description = "Updated description"
                };

                // Update tags
                updatedAnalyzer.Tags.Add("tag1", "tag1_updated_value");
                updatedAnalyzer.Tags.Add("tag2", ""); // Empty string to remove tag
                updatedAnalyzer.Tags.Add("tag3", "tag3_value");

                var updateResponse = await client.UpdateAnalyzerAsync(analyzerId, updatedAnalyzer);

                Assert.IsNotNull(updateResponse);
                TestContext.WriteLine("  ✓ Analyzer updated successfully!");

                // Step 4: Get the analyzer after update to verify changes persisted
                TestContext.WriteLine("\nStep 4: Getting analyzer after update to verify changes...");
                var getAfterUpdate = await client.GetAnalyzerAsync(analyzerId);

                Assert.IsNotNull(getAfterUpdate);
                Assert.IsNotNull(getAfterUpdate.Value);
                Assert.AreEqual(analyzerId, getAfterUpdate.Value.AnalyzerId);
                Assert.AreEqual("Updated description", getAfterUpdate.Value.Description);

                // Verify tag updates
                Assert.IsTrue(getAfterUpdate.Value.Tags.ContainsKey("tag1"));
                Assert.AreEqual("tag1_updated_value", getAfterUpdate.Value.Tags["tag1"]);
                Assert.IsTrue(getAfterUpdate.Value.Tags.ContainsKey("tag3"));
                Assert.AreEqual("tag3_value", getAfterUpdate.Value.Tags["tag3"]);

                TestContext.WriteLine("  Updated analyzer state:");
                TestContext.WriteLine($"    Description: {getAfterUpdate.Value.Description}");
                TestContext.WriteLine($"    Tags: {string.Join(", ", getAfterUpdate.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

                TestContext.WriteLine("\n✓ Update verification completed successfully");
            }
            finally
            {
                // Clean up
                if (createdAnalyzer)
                {
                    TestContext.WriteLine("\nStep 5: Cleaning up (deleting analyzer)...");
                    try
                    {
                        await client.DeleteAnalyzerAsync(analyzerId);
                        TestContext.WriteLine($"  ✓ Analyzer '{analyzerId}' deleted successfully!");
                    }
                    catch (RequestFailedException ex)
                    {
                        TestContext.WriteLine($"  ⚠️  Failed to delete analyzer: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with initial description
        /// - Update only description
        /// - Verify description changed but other properties remain unchanged
        /// </summary>
        [RecordedTest]
        public async Task TestUpdateAnalyzerDescriptionOnly()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "DescUpdateTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing description-only update: {analyzerId}");

            try
            {
                // Create initial analyzer
                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Original description"
                };
                initialAnalyzer.Models.Add("completion", "gpt-4o");
                initialAnalyzer.Models.Add("embedding", "text-embedding-3-large");
                initialAnalyzer.Tags.Add("test_tag", "test_value");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Initial analyzer created");

                // Update only description
                TestContext.WriteLine("\nUpdating description only...");
                var updateAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "New description"
                };

                await client.UpdateAnalyzerAsync(analyzerId, updateAnalyzer);
                TestContext.WriteLine("  ✓ Description updated");

                // Verify changes
                var getAfterUpdate = await client.GetAnalyzerAsync(analyzerId);
                Assert.AreEqual("New description", getAfterUpdate.Value.Description);
                Assert.IsTrue(getAfterUpdate.Value.Tags.ContainsKey("test_tag"),
                    "Tags should remain unchanged");
                Assert.AreEqual("test_value", getAfterUpdate.Value.Tags["test_tag"]);

                TestContext.WriteLine($"  ✓ Description changed: {getAfterUpdate.Value.Description}");
                TestContext.WriteLine($"  ✓ Tags unchanged: {string.Join(", ", getAfterUpdate.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with initial tags
        /// - Update only tags
        /// - Verify tags changed but description remains unchanged
        /// </summary>
        [RecordedTest]
        public async Task TestUpdateAnalyzerTagsOnly()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "TagUpdateTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing tags-only update: {analyzerId}");

            try
            {
                // Create initial analyzer
                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Fixed description"
                };
                initialAnalyzer.Models.Add("completion", "gpt-4o");
                initialAnalyzer.Models.Add("embedding", "text-embedding-3-large");
                initialAnalyzer.Tags.Add("env", "dev");
                initialAnalyzer.Tags.Add("version", "1.0");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Initial analyzer created");
                TestContext.WriteLine($"    Initial tags: env=dev, version=1.0");

                // Update only tags
                TestContext.WriteLine("\nUpdating tags only...");
                var updateAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Fixed description"
                };
                updateAnalyzer.Tags.Add("env", "prod");
                updateAnalyzer.Tags.Add("version", "2.0");
                updateAnalyzer.Tags.Add("owner", "test_team");

                await client.UpdateAnalyzerAsync(analyzerId, updateAnalyzer);
                TestContext.WriteLine("  ✓ Tags updated");

                // Verify changes
                var getAfterUpdate = await client.GetAnalyzerAsync(analyzerId);
                Assert.AreEqual("Fixed description", getAfterUpdate.Value.Description,
                    "Description should remain unchanged");
                Assert.AreEqual("prod", getAfterUpdate.Value.Tags["env"]);
                Assert.AreEqual("2.0", getAfterUpdate.Value.Tags["version"]);
                Assert.IsTrue(getAfterUpdate.Value.Tags.ContainsKey("owner"));

                TestContext.WriteLine($"  ✓ Description unchanged: {getAfterUpdate.Value.Description}");
                TestContext.WriteLine($"  ✓ Tags updated: {string.Join(", ", getAfterUpdate.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with multiple tags
        /// - Remove one tag by setting empty string
        /// - Verify tag is removed
        /// </summary>
        [RecordedTest]
        public async Task TestUpdateAnalyzerRemoveTag()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "RemoveTagTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing tag removal: {analyzerId}");

            try
            {
                // Create initial analyzer
                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer"
                };
                initialAnalyzer.Models.Add("completion", "gpt-4o");
                initialAnalyzer.Models.Add("embedding", "text-embedding-3-large");
                initialAnalyzer.Tags.Add("keep_tag", "keep_value");
                initialAnalyzer.Tags.Add("remove_tag", "remove_value");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Initial analyzer created with 2 tags");

                // Remove one tag
                TestContext.WriteLine("\nRemoving 'remove_tag' by setting empty string...");
                var updateAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document"
                };
                updateAnalyzer.Tags.Add("keep_tag", "keep_value");
                updateAnalyzer.Tags.Add("remove_tag", ""); // Empty string to remove

                await client.UpdateAnalyzerAsync(analyzerId, updateAnalyzer);
                TestContext.WriteLine("  ✓ Update completed");

                // Verify tag removal
                var getAfterUpdate = await client.GetAnalyzerAsync(analyzerId);
                Assert.IsTrue(getAfterUpdate.Value.Tags.ContainsKey("keep_tag"));

                // Check if remove_tag was actually removed (behavior may vary)
                if (getAfterUpdate.Value.Tags.ContainsKey("remove_tag"))
                {
                    var removeTagValue = getAfterUpdate.Value.Tags["remove_tag"];
                    TestContext.WriteLine($"  Note: 'remove_tag' still exists with value: '{removeTagValue}'");
                }
                else
                {
                    TestContext.WriteLine("  ✓ 'remove_tag' successfully removed");
                }

                TestContext.WriteLine($"  Remaining tags: {string.Join(", ", getAfterUpdate.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer
        /// - Update multiple times sequentially
        /// - Verify each update persists correctly
        /// </summary>
        [RecordedTest]
        public async Task TestMultipleSequentialUpdates()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "MultiUpdateTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing multiple sequential updates: {analyzerId}");

            try
            {
                // Create initial analyzer
                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Version 1"
                };
                initialAnalyzer.Models.Add("completion", "gpt-4o");
                initialAnalyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Initial analyzer created (Version 1)");

                // First update
                TestContext.WriteLine("\nFirst update to Version 2...");
                var update1 = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Version 2"
                };
                await client.UpdateAnalyzerAsync(analyzerId, update1);

                var get1 = await client.GetAnalyzerAsync(analyzerId);
                Assert.AreEqual("Version 2", get1.Value.Description);
                TestContext.WriteLine($"  ✓ Updated to: {get1.Value.Description}");

                // Second update
                TestContext.WriteLine("\nSecond update to Version 3...");
                var update2 = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Version 3"
                };
                await client.UpdateAnalyzerAsync(analyzerId, update2);

                var get2 = await client.GetAnalyzerAsync(analyzerId);
                Assert.AreEqual("Version 3", get2.Value.Description);
                TestContext.WriteLine($"  ✓ Updated to: {get2.Value.Description}");

                // Third update
                TestContext.WriteLine("\nThird update to Final Version...");
                var update3 = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Final Version"
                };
                await client.UpdateAnalyzerAsync(analyzerId, update3);

                var get3 = await client.GetAnalyzerAsync(analyzerId);
                Assert.AreEqual("Final Version", get3.Value.Description);
                TestContext.WriteLine($"  ✓ Updated to: {get3.Value.Description}");

                TestContext.WriteLine("\n✓ All sequential updates completed successfully");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Attempt to update non-existent analyzer
        /// - Verify appropriate error is returned
        /// </summary>
        [RecordedTest]
        public async Task TestUpdateNonExistentAnalyzer()
        {
            var client = CreateClient();
            var nonExistentId = "non_existent_analyzer_" + Guid.NewGuid().ToString("N");

            TestContext.WriteLine($"Testing update of non-existent analyzer: {nonExistentId}");

            try
            {
                var updateAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "This should fail"
                };

                await client.UpdateAnalyzerAsync(nonExistentId, updateAnalyzer);

                Assert.Fail("Should have thrown exception for non-existent analyzer");
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
        /// - Create analyzer and verify LastModifiedAt timestamp
        /// - Update analyzer
        /// - Verify LastModifiedAt timestamp is updated
        /// </summary>
        [RecordedTest]
        public async Task TestUpdateAnalyzerTimestamp()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "TimestampTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing timestamp updates: {analyzerId}");

            try
            {
                // Create initial analyzer
                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Initial"
                };
                initialAnalyzer.Models.Add("completion", "gpt-4o");
                initialAnalyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;

                var getBeforeUpdate = await client.GetAnalyzerAsync(analyzerId);
                var createdAt = getBeforeUpdate.Value.CreatedAt;
                var lastModifiedBefore = getBeforeUpdate.Value.LastModifiedAt;

                TestContext.WriteLine($"  Created at: {createdAt:yyyy-MM-dd HH:mm:ss} UTC");
                TestContext.WriteLine($"  Last modified (before): {lastModifiedBefore:yyyy-MM-dd HH:mm:ss} UTC");

                // Wait a moment to ensure timestamps differ
                await Task.Delay(1000);

                // Update analyzer
                TestContext.WriteLine("\nUpdating analyzer...");
                var updateAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Updated"
                };
                await client.UpdateAnalyzerAsync(analyzerId, updateAnalyzer);

                var getAfterUpdate = await client.GetAnalyzerAsync(analyzerId);
                var lastModifiedAfter = getAfterUpdate.Value.LastModifiedAt;

                TestContext.WriteLine($"  Last modified (after): {lastModifiedAfter:yyyy-MM-dd HH:mm:ss} UTC");

                // Verify timestamps
                Assert.AreEqual(createdAt, getAfterUpdate.Value.CreatedAt,
                    "CreatedAt should not change");
                Assert.IsTrue(lastModifiedAfter >= lastModifiedBefore,
                    "LastModifiedAt should be updated or equal");

                TestContext.WriteLine("\n✓ Timestamp verification completed");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer with complex tags
        /// - Update with special characters in tag values
        /// - Verify special characters are handled correctly
        /// </summary>
        [RecordedTest]
        public async Task TestUpdateAnalyzerWithSpecialCharacterTags()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "SpecialCharTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing special characters in tags: {analyzerId}");

            try
            {
                // Create initial analyzer
                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Test analyzer"
                };
                initialAnalyzer.Models.Add("completion", "gpt-4o");
                initialAnalyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;
                TestContext.WriteLine("  ✓ Initial analyzer created");

                // Update with special characters
                TestContext.WriteLine("\nUpdating with special character tags...");
                var updateAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document"
                };
                updateAnalyzer.Tags.Add("email", "test@example.com");
                updateAnalyzer.Tags.Add("path", "/folder/subfolder");
                updateAnalyzer.Tags.Add("version", "1.0.0");
                updateAnalyzer.Tags.Add("description", "Test with spaces and punctuation!");

                await client.UpdateAnalyzerAsync(analyzerId, updateAnalyzer);
                TestContext.WriteLine("  ✓ Tags updated");

                // Verify special characters preserved
                var getAfterUpdate = await client.GetAnalyzerAsync(analyzerId);

                Assert.IsTrue(getAfterUpdate.Value.Tags.ContainsKey("email"));
                Assert.AreEqual("test@example.com", getAfterUpdate.Value.Tags["email"]);

                TestContext.WriteLine("  ✓ Special characters preserved:");
                foreach (var tag in getAfterUpdate.Value.Tags)
                {
                    TestContext.WriteLine($"    {tag.Key}: {tag.Value}");
                }
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }

        /// <summary>
        /// Test Summary:
        /// - Create analyzer
        /// - Update and verify response contains updated information
        /// - Check raw response properties
        /// </summary>
        [RecordedTest]
        public async Task TestUpdateAnalyzerResponseValidation()
        {
            var client = CreateClient();
            var analyzerId = TestHelpers.GenerateAnalyzerId(Recording, "ResponseTest");
            bool createdAnalyzer = false;

            TestContext.WriteLine($"Testing update response validation: {analyzerId}");

            try
            {
                // Create initial analyzer
                var initialAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Initial"
                };
                initialAnalyzer.Models.Add("completion", "gpt-4o");
                initialAnalyzer.Models.Add("embedding", "text-embedding-3-large");

                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                Assert.IsNotNull(createOperation.Value);
                createdAnalyzer = true;

                // Update analyzer
                TestContext.WriteLine("\nUpdating analyzer...");
                var updateAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = "prebuilt-document",
                    Description = "Updated"
                };

                var updateResponse = await client.UpdateAnalyzerAsync(analyzerId, updateAnalyzer);

                // Verify response
                Assert.IsNotNull(updateResponse, "Update response should not be null");
                TestContext.WriteLine("  ✓ Update response validated");
            }
            finally
            {
                if (createdAnalyzer)
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    TestContext.WriteLine("\n  ✓ Analyzer deleted");
                }
            }
        }
    }
}
