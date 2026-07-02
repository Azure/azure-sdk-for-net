// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    [Category("STAC")]
    [Category("Collections")]
    [Category("Lifecycle")]
    public class TestPlanetaryComputer08CollectionLifecycleTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer08CollectionLifecycleTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Returns a unique collection ID per async/sync mode to avoid conflicts
        /// when both modes run in the same test session.
        /// </summary>
        private string LifecycleCollectionId => TestEnvironment.LifecycleCollectionId;

        // Tests 01-03 are marked [AsyncOnly] because they share a single collection on the live endpoint.
        // Running both async and sync modes would cause the second mode's delete to fail with 404
        // (the collection was already deleted by the first mode). This matches how Python and Java
        // handle lifecycle tests — they only run once per test method.

        [Test]
        [AsyncOnly]
        [Category("CreateCollection")]
        public async Task Test08_01_BeginCreateCollection()
        {
            var client = GetTestClient();
            var stacClient = client.GetStacClient();
            string collectionId = LifecycleCollectionId;

            // Check if collection exists and delete it first (matches Python pattern)
            try
            {
                await stacClient.GetCollectionAsync(collectionId);
                TestContext.WriteLine($"Collection '{collectionId}' already exists, deleting first...");
                await stacClient.DeleteCollectionAsync(WaitUntil.Started, collectionId, null);
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
                TestContext.WriteLine($"Deleted existing collection '{collectionId}'");
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                TestContext.WriteLine($"Collection '{collectionId}' does not exist, proceeding with creation");
            }
            catch (RequestFailedException ex) when (ex.Status == 409)
            {
                // Collection is being deleted from a previous run - wait for it to finish
                TestContext.WriteLine($"Collection '{collectionId}' is being deleted, waiting...");
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(TimeSpan.FromSeconds(60));
                }
            }

            var spatialExtent = new StacExtensionSpatialExtent();
            spatialExtent.BoundingBox.Add(new List<float> { -180.0f, -90.0f, 180.0f, 90.0f });

            var temporalExtent = new StacCollectionTemporalExtent(new[] { new List<string> { "2018-01-01T00:00:00Z", "2018-12-31T23:59:59Z" } });
            var extent = new StacExtensionExtent(spatialExtent, temporalExtent);

            var collection = new StacCollectionResource(
                id: collectionId,
                description: "Test collection",
                links: new List<StacLink>(),
                license: "CC-BY-4.0",
                extent: extent)
            {
                StacVersion = "1.0.0",
                Title = "Test Collection",
                Type = "Collection"
            };

            // Use WaitUntil.Started to avoid LRO final-state GET mismatch during playback.
            // The LRO mechanism adds a final GET /stac/collections/{id} check in playback mode
            // that wasn't recorded during the live run (where polling completed the operation).
            await stacClient.CreateCollectionAsync(WaitUntil.Started, collection);

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }

        [Test]
        [AsyncOnly]
        [Category("ReplaceCollection")]
        public async Task Test08_02_ReplaceCollection()
        {
            var client = GetTestClient();
            var stacClient = client.GetStacClient();
            string collectionId = LifecycleCollectionId;

            Response<StacCollectionResource> getCollectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource originalCollection = getCollectionResponse.Value;

            originalCollection.Description = "Test collection - UPDATED";

            Response<StacCollectionResource> updateResponse = await stacClient.ReplaceCollectionAsync(collectionId, originalCollection);
            ValidateResponse(updateResponse, "ReplaceCollection");
        }

        [Test]
        [AsyncOnly]
        [Category("DeleteCollection")]
        public async Task Test08_03_BeginDeleteCollection()
        {
            var client = GetTestClient();
            var stacClient = client.GetStacClient();
            string collectionId = LifecycleCollectionId;

            // Use WaitUntil.Started to avoid LRO final-state GET mismatch during playback.
            // The LRO mechanism adds a final GET /stac/collections/{id} check in playback mode
            // that wasn't recorded during the live run (where polling completed the operation).
            await stacClient.DeleteCollectionAsync(WaitUntil.Started, collectionId, null);

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(TimeSpan.FromSeconds(30));
            }
        }

        /// <summary>
        /// Tests creating a collection asset.
        /// Maps to Python test: test_04_create_collection_asset
        /// </summary>
        [Test]
        [Category("CollectionAsset")]
        public async Task Test08_04_CreateCollectionAsset()
        {
            // Arrange
            var client = GetTestClient();
            var stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;
            string assetId = "test-asset";

            TestContext.WriteLine($"Collection ID: {collectionId}");
            TestContext.WriteLine($"Asset ID: {assetId}");

            // Delete the asset if it already exists
            try
            {
                TestContext.WriteLine($"Checking if asset '{assetId}' already exists and deleting if found...");
                await stacClient.DeleteCollectionAssetAsync(collectionId, assetId);
                TestContext.WriteLine($"Deleted existing '{assetId}'");
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                TestContext.WriteLine($"Asset '{assetId}' does not exist, proceeding with creation");
            }

            // Create asset data
            var assetData = new Dictionary<string, object>
            {
                ["key"] = assetId,
                ["href"] = "https://example.com/test-asset.txt",
                ["type"] = "text/plain",
                ["roles"] = new[] { "metadata" },
                ["title"] = "Test Asset"
            };

            // Create file content
            byte[] fileContent = System.Text.Encoding.UTF8.GetBytes("Test asset content");
            using var fileStream = new System.IO.MemoryStream(fileContent);

            // Prepare multipart form data
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new StringContent(JsonSerializer.Serialize(assetData)), "data");
            multipartContent.Add(new StreamContent(fileStream), "file", "test-asset.txt");

            TestContext.WriteLine($"Calling: CreateCollectionAssetAsync('{collectionId}', {{...}})");

            // Serialize multipart content to stream
            var contentStream = new MemoryStream();
            await multipartContent.CopyToAsync(contentStream);
            contentStream.Position = 0;

            // Act
            Response response = await stacClient.CreateCollectionAssetAsync(
                collectionId,
                RequestContent.Create(contentStream),
                multipartContent.Headers.ContentType?.ToString(),
                null);

            // Assert
            ValidateResponse(response);

            TestContext.WriteLine($"Asset '{assetId}' created successfully with status: {response.Status}");
        }

        /// <summary>
        /// Tests replacing a collection asset.
        /// Maps to Python test: test_05_replace_collection_asset
        /// </summary>
        [Test]
        [Category("CollectionAsset")]
        public async Task Test08_05_ReplaceCollectionAsset()
        {
            // Arrange
            var client = GetTestClient();
            var stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;
            string assetId = "test-asset";

            TestContext.WriteLine($"Collection ID: {collectionId}");
            TestContext.WriteLine($"Asset ID: {assetId}");

            // Update asset data
            var assetData = new Dictionary<string, object>
            {
                ["key"] = assetId,
                ["href"] = "https://example.com/test-asset-updated.txt",
                ["type"] = "text/plain",
                ["roles"] = new[] { "metadata" },
                ["title"] = "Test Asset - Updated"
            };

            // Create updated file content
            byte[] fileContent = System.Text.Encoding.UTF8.GetBytes("Test asset content - updated");
            using var fileStream = new System.IO.MemoryStream(fileContent);

            // Prepare multipart form data
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new StringContent(JsonSerializer.Serialize(assetData)), "data");
            multipartContent.Add(new StreamContent(fileStream), "file", "test-asset.txt");

            TestContext.WriteLine($"Calling: ReplaceCollectionAssetAsync('{collectionId}', '{assetId}', {{...}})");

            // Serialize multipart content to stream
            var contentStream = new MemoryStream();
            await multipartContent.CopyToAsync(contentStream);
            contentStream.Position = 0;

            // Act
            Response response = await stacClient.ReplaceCollectionAssetAsync(
                collectionId,
                assetId,
                RequestContent.Create(contentStream),
                multipartContent.Headers.ContentType?.ToString(),
                null);

            // Assert
            ValidateResponse(response);

            TestContext.WriteLine($"Asset '{assetId}' replaced successfully with status: {response.Status}");
        }

        /// <summary>
        /// Tests deleting a collection asset.
        /// Maps to Python test: test_06_delete_collection_asset
        /// </summary>
        [Test]
        [Category("CollectionAsset")]
        public async Task Test08_06_DeleteCollectionAsset()
        {
            // Arrange
            var client = GetTestClient();
            var stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;
            string assetIdToDelete = "test-asset-to-be-deleted";

            TestContext.WriteLine($"Collection ID: {collectionId}");
            TestContext.WriteLine($"Asset ID: {assetIdToDelete}");

            // First create the asset to be deleted
            TestContext.WriteLine($"Creating asset for deletion: {assetIdToDelete}");

            var assetData = new Dictionary<string, object>
            {
                ["key"] = assetIdToDelete,
                ["href"] = "https://example.com/test-asset-to-delete.txt",
                ["type"] = "text/plain",
                ["roles"] = new[] { "metadata" },
                ["title"] = "Test Asset To Be Deleted"
            };

            byte[] fileContent = System.Text.Encoding.UTF8.GetBytes("Test asset content for deletion");
            using var createFileStream = new System.IO.MemoryStream(fileContent);

            var createMultipartContent = new MultipartFormDataContent();
            createMultipartContent.Add(new StringContent(JsonSerializer.Serialize(assetData)), "data");
            createMultipartContent.Add(new StreamContent(createFileStream), "file", "test-asset-to-delete.txt");

            // Serialize multipart content to stream
            var createContentStream = new MemoryStream();
            await createMultipartContent.CopyToAsync(createContentStream);
            createContentStream.Position = 0;

            Response createResponse = await stacClient.CreateCollectionAssetAsync(
                collectionId,
                RequestContent.Create(createContentStream),
                createMultipartContent.Headers.ContentType?.ToString(),
                null);
            ValidateResponse(createResponse);
            TestContext.WriteLine("Asset created successfully");

            // Now delete it
            TestContext.WriteLine($"Calling: DeleteCollectionAssetAsync('{collectionId}', '{assetIdToDelete}')");

            // Act
            Response<StacCollectionResource> deleteResponse = await stacClient.DeleteCollectionAssetAsync(collectionId, assetIdToDelete);

            // Assert
            ValidateResponse(deleteResponse);

            TestContext.WriteLine($"Asset '{assetIdToDelete}' deleted successfully with status: {deleteResponse.GetRawResponse().Status}");

            // Verify deletion by checking collection assets
            Response<StacCollectionResource> collectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = collectionResponse.Value;

            if (collection.Assets != null && collection.Assets.Count > 0)
            {
                Assert.That(collection.Assets.ContainsKey(assetIdToDelete), Is.False,
                    "Asset should have been deleted from collection");
            }

            TestContext.WriteLine("Asset deletion verified");
        }
    }
}
