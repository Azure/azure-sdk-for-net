// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for STAC Collection lifecycle operations (create, update, delete).
    /// Tests are mapped from Python tests in test_planetary_computer_08_collection_lifecycle.py.
    /// Note: These tests modify collections and should be run carefully.
    /// </summary>
    [Category("STAC")]
    [Category("Collections")]
    [Category("Lifecycle")]
    [Category("LRO")]
    public class TestPlanetaryComputer08CollectionLifecycleTests : PlanetaryComputerTestBase
    {
        private const string TestCollectionId = "test-collection-lifecycle";

        public TestPlanetaryComputer08CollectionLifecycleTests(bool isAsync) : base(isAsync)
        {
        }

        public TestPlanetaryComputer08CollectionLifecycleTests() : base(true)
        {
        }

        /// <summary>
        /// Tests creating a new STAC collection using Long-Running Operation (LRO).
        /// Maps to Python test: test_01_begin_create_collection
        /// </summary>
        [RecordedTest]
        [Category("CreateCollection")]
        public async Task Test08_01_BeginCreateCollection()
        {
            // Arrange
            var client = GetTestClient();
            var stacClient = client.GetStacClient();

            TestContext.WriteLine($"Test collection ID: {TestCollectionId}");

            // Check if collection exists and delete it first
            try
            {
                Response getResponse = await stacClient.GetCollectionAsync(TestCollectionId, null, null, null);

                if (getResponse.Status == 200)
                {
                    TestContext.WriteLine($"Collection '{TestCollectionId}' already exists, deleting first...");

                    Operation deleteOperation = await stacClient.DeleteCollectionAsync(WaitUntil.Completed, TestCollectionId, null);

                    await deleteOperation.WaitForCompletionResponseAsync();
                    TestContext.WriteLine($"Deleted existing collection '{TestCollectionId}'");

                    // Wait for deletion to complete in live mode
                    if (Mode == RecordedTestMode.Live)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(30));
                    }
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                TestContext.WriteLine($"Collection '{TestCollectionId}' does not exist, proceeding with creation");
            }

            // Create collection using StacCollectionResource (matching portal/Python structure)
            var spatialExtent = new StacExtensionSpatialExtent();
            spatialExtent.BoundingBox.Add(new List<float> { -180.0f, -90.0f, 180.0f, 90.0f });

            IList<DateTimeOffset> temporalInterval = new List<DateTimeOffset>
            {
                DateTimeOffset.Parse("2018-01-01T00:00:00Z"),
                DateTimeOffset.Parse("2018-12-31T23:59:59Z")
            };

            var temporalExtent = new StacCollectionTemporalExtent(new[] { temporalInterval });

            var extent = new StacExtensionExtent(spatialExtent, temporalExtent);

            var collection = new StacCollectionResource(
                id: TestCollectionId,
                description: "An example collection",
                links: new List<StacLink>(),
                license: "CC-BY-4.0",
                extent: extent
            )
            {
                StacVersion = "1.0.0",
                Title = "Example Collection",
                Type = "Collection",
                ShortDescription = "An example collection"
            };

            TestContext.WriteLine("Calling: CreateCollectionAsync(WaitUntil.Completed, ...)");

            // Act - Create collection with LRO
            Operation createOperation = await stacClient.CreateCollectionAsync(WaitUntil.Completed, collection);

            // Wait for completion
            Response createResult = await createOperation.WaitForCompletionResponseAsync();

            // Assert
            ValidateResponse(createResult);

            TestContext.WriteLine($"Collection creation operation completed with status: {createResult.Status}");

            // Wait for collection to be fully available in live mode
            if (Mode == RecordedTestMode.Live)
            {
                await Task.Delay(TimeSpan.FromSeconds(15));
            }

            // Verify creation by retrieving the collection
            Response verifyResponse = await stacClient.GetCollectionAsync(TestCollectionId, null, null, null);

            ValidateResponse(verifyResponse);

            using JsonDocument doc = JsonDocument.Parse(verifyResponse.Content);
            JsonElement root = doc.RootElement;

            // Verify collection properties
            Assert.That(root.TryGetProperty("id", out JsonElement idElement), Is.True);
            Assert.That(idElement.GetString(), Is.EqualTo(TestCollectionId), "Collection ID should match");

            Assert.That(root.TryGetProperty("title", out JsonElement titleElement), Is.True);
            Assert.That(titleElement.GetString(), Is.EqualTo("Test Collection Lifecycle"), "Title should match");

            Assert.That(root.TryGetProperty("type", out JsonElement typeElement), Is.True);
            Assert.That(typeElement.GetString(), Is.EqualTo("Collection"), "Type should be Collection");

            TestContext.WriteLine($"Collection '{TestCollectionId}' created successfully");
        }

        /// <summary>
        /// Tests updating a collection using create or replace operation.
        /// Maps to Python test: test_02_create_or_replace_collection
        /// </summary>
        [RecordedTest]
        [Category("UpdateCollection")]
        public async Task Test08_02_CreateOrReplaceCollection()
        {
            // Arrange
            var client = GetTestClient();
            var stacClient = client.GetStacClient();

            TestContext.WriteLine($"Test collection ID: {TestCollectionId}");

            // Get existing collection
            Response getResponse = await stacClient.GetCollectionAsync(TestCollectionId, null, null, null);

            ValidateResponse(getResponse);

            // Parse the response - use implicit conversion from Response
            Response<StacCollectionResource> getCollectionResponse = await stacClient.GetCollectionAsync(TestCollectionId);
            StacCollectionResource originalCollection = getCollectionResponse.Value;

            // Update the description
            originalCollection.Description = "Test collection for lifecycle operations - UPDATED";

            TestContext.WriteLine("Calling: CreateOrReplaceCollectionAsync(...)");

            // Act - Update collection using convenience method
            Response<StacCollectionResource> updateResponse = await stacClient.CreateOrReplaceCollectionAsync(TestCollectionId, originalCollection);

            // Assert
            Assert.IsNotNull(updateResponse);
            Assert.IsNotNull(updateResponse.Value);

            TestContext.WriteLine($"Collection update completed with status: {updateResponse.GetRawResponse().Status}");

            // Wait for update to propagate in live mode
            if (Mode == RecordedTestMode.Live)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
            }

            // Verify update by retrieving the collection
            Response verifyResponse = await stacClient.GetCollectionAsync(TestCollectionId, null, null, null);

            ValidateResponse(verifyResponse);

            using JsonDocument verifyDoc = JsonDocument.Parse(verifyResponse.Content);
            JsonElement root = verifyDoc.RootElement;

            // Verify updated description
            Assert.That(root.TryGetProperty("description", out JsonElement descElement), Is.True);
            Assert.That(descElement.GetString(), Is.EqualTo("Test collection for lifecycle operations - UPDATED"),
                "Description should be updated");

            TestContext.WriteLine($"Collection '{TestCollectionId}' updated successfully");
        }

        /// <summary>
        /// Tests deleting a STAC collection using Long-Running Operation (LRO).
        /// Maps to Python test: test_03_begin_delete_collection
        /// </summary>
        [RecordedTest]
        [Category("DeleteCollection")]
        public async Task Test08_03_BeginDeleteCollection()
        {
            // Arrange
            var client = GetTestClient();
            var stacClient = client.GetStacClient();

            TestContext.WriteLine($"Test collection ID: {TestCollectionId}");

            // Verify collection exists before deletion
            Response getResponse = await stacClient.GetCollectionAsync(TestCollectionId, null, null, null);

            ValidateResponse(getResponse);
            TestContext.WriteLine($"Collection '{TestCollectionId}' exists, proceeding with deletion");

            // Act - Delete collection with LRO
            TestContext.WriteLine("Calling: DeleteCollectionAsync(WaitUntil.Completed, ...)");

            Operation deleteOperation = await stacClient.DeleteCollectionAsync(WaitUntil.Completed, TestCollectionId, null);

            // Wait for completion
            Response deleteResult = await deleteOperation.WaitForCompletionResponseAsync();

            // Assert
            TestContext.WriteLine($"Collection deletion operation completed with status: {deleteResult.Status}");

            // Wait for deletion to propagate in live mode
            if (Mode == RecordedTestMode.Live)
            {
                await Task.Delay(TimeSpan.FromSeconds(15));
            }

            // Verify deletion - collection should not be found
            try
            {
                Response verifyResponse = await stacClient.GetCollectionAsync(TestCollectionId, null, null, null);

                // If we get here in live mode, the collection still exists (shouldn't happen)
                if (Mode == RecordedTestMode.Live)
                {
                    Assert.Fail($"Collection '{TestCollectionId}' should have been deleted but still exists");
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                // Expected - collection was deleted
                TestContext.WriteLine($"Collection '{TestCollectionId}' successfully deleted (404 Not Found)");
            }
        }
    }
}
