// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests.Samples
{
    /// <summary>
    /// Samples demonstrating how to manage collection lifecycle operations including
    /// creating, updating, and deleting collections and collection assets.
    /// </summary>
    public partial class Sample08_CollectionLifecycle : PlanetaryComputerTestBase
    {
        public Sample08_CollectionLifecycle(bool isAsync) : base(isAsync) { }
        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CreateCollection()
        {
            #region Snippet:Sample08_CreateCollection
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            StacClient stacClient = client.GetStacClient();

            // Define collection ID
            string collectionId = "my-test-collection";

            // Define spatial extent (global coverage)
            var spatialExtent = new StacExtensionSpatialExtent();
            spatialExtent.BoundingBox.Add(new List<float> { -180.0f, -90.0f, 180.0f, 90.0f });

            // Define temporal extent
            var temporalExtent = new StacCollectionTemporalExtent(
                new[] { new List<string> { "2018-01-01T00:00:00Z", "2018-12-31T23:59:59Z" } }
            );

            // Combine spatial and temporal extents
            var extent = new StacExtensionExtent(spatialExtent, temporalExtent);

            // Create collection resource
            var collection = new StacCollectionResource(
                id: collectionId,
                description: "Test collection for demonstration",
                links: new List<StacLink>(),
                license: "CC-BY-4.0",
                extent: extent)
            {
                StacVersion = "1.0.0",
                Title = "Test Collection",
                Type = "Collection"
            };

            // Start collection creation (asynchronous operation)
            Operation createOperation = await stacClient.CreateCollectionAsync(
                WaitUntil.Started,
                collection
            );

            Console.WriteLine($"Collection creation started: {collectionId}");
            Console.WriteLine("Note: Collection creation is asynchronous and may take time to complete");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task UpdateCollection()
        {
            #region Snippet:Sample08_UpdateCollection
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            StacClient stacClient = client.GetStacClient();

            string collectionId = "my-test-collection";

            // Get the existing collection
            Response<StacCollectionResource> getResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = getResponse.Value;

            // Update the description
            collection.Description = "Test collection - UPDATED";

            // Replace the collection with the updated version
            Response<StacCollectionResource> updateResponse = await stacClient.CreateOrReplaceCollectionAsync(
                collectionId,
                collection
            );

            Console.WriteLine($"Collection '{collectionId}' updated successfully");
            Console.WriteLine($"New description: {updateResponse.Value.Description}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task DeleteCollection()
        {
            #region Snippet:Sample08_DeleteCollection
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            StacClient stacClient = client.GetStacClient();

            string collectionId = "my-test-collection";

            // Start collection deletion (asynchronous operation)
            Operation deleteOperation = await stacClient.DeleteCollectionAsync(
                WaitUntil.Started,
                collectionId,
                null
            );

            Console.WriteLine($"Collection deletion started: {collectionId}");
            Console.WriteLine("Note: Collection deletion is asynchronous and may take time to complete");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CreateCollectionAsset()
        {
            #region Snippet:Sample08_CreateCollectionAsset
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            StacClient stacClient = client.GetStacClient();

            string collectionId = "naip";
            string assetId = "test-asset";

            // Create asset metadata
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
            using var fileStream = new MemoryStream(fileContent);

            // Prepare multipart form data
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new StringContent(JsonSerializer.Serialize(assetData)), "data");
            multipartContent.Add(new StreamContent(fileStream), "file", "test-asset.txt");

            // Serialize multipart content to stream
            var contentStream = new MemoryStream();
            await multipartContent.CopyToAsync(contentStream);
            contentStream.Position = 0;

            // Create the asset
            Response response = await stacClient.CreateCollectionAssetAsync(
                collectionId,
                RequestContent.Create(contentStream),
                multipartContent.Headers.ContentType?.ToString(),
                null
            );

            Console.WriteLine($"Asset '{assetId}' created successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ReplaceCollectionAsset()
        {
            #region Snippet:Sample08_ReplaceCollectionAsset
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            StacClient stacClient = client.GetStacClient();

            string collectionId = "naip";
            string assetId = "test-asset";

            // Update asset metadata
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
            using var fileStream = new MemoryStream(fileContent);

            // Prepare multipart form data
            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new StringContent(JsonSerializer.Serialize(assetData)), "data");
            multipartContent.Add(new StreamContent(fileStream), "file", "test-asset.txt");

            // Serialize multipart content to stream
            var contentStream = new MemoryStream();
            await multipartContent.CopyToAsync(contentStream);
            contentStream.Position = 0;

            // Replace the asset
            Response response = await stacClient.ReplaceCollectionAssetAsync(
                collectionId,
                assetId,
                RequestContent.Create(contentStream),
                multipartContent.Headers.ContentType?.ToString(),
                null
            );

            Console.WriteLine($"Asset '{assetId}' replaced successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task DeleteCollectionAsset()
        {
            #region Snippet:Sample08_DeleteCollectionAsset
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            StacClient stacClient = client.GetStacClient();

            string collectionId = "naip";
            string assetId = "test-asset";

            // Delete the asset
            Response<StacCollectionResource> response = await stacClient.DeleteCollectionAssetAsync(
                collectionId,
                assetId
            );

            Console.WriteLine($"Asset '{assetId}' deleted successfully");

            // Verify deletion by checking collection assets
            Response<StacCollectionResource> collectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = collectionResponse.Value;

            if (collection.Assets != null && !collection.Assets.ContainsKey(assetId))
            {
                Console.WriteLine("Asset deletion verified");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CompleteAssetManagementWorkflow()
        {
            #region Snippet:Sample08_CompleteAssetManagementWorkflow
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            StacClient stacClient = client.GetStacClient();

            string collectionId = "naip";
            string assetId = "workflow-test-asset";

            // Step 1: Create an asset
            Console.WriteLine("Step 1: Creating asset...");
            var assetData = new Dictionary<string, object>
            {
                ["key"] = assetId,
                ["href"] = "https://example.com/workflow-asset.txt",
                ["type"] = "text/plain",
                ["roles"] = new[] { "metadata" },
                ["title"] = "Workflow Test Asset"
            };

            byte[] fileContent = System.Text.Encoding.UTF8.GetBytes("Original content");
            using (var fileStream = new MemoryStream(fileContent))
            {
                var multipartContent = new MultipartFormDataContent();
                multipartContent.Add(new StringContent(JsonSerializer.Serialize(assetData)), "data");
                multipartContent.Add(new StreamContent(fileStream), "file", "workflow-asset.txt");

                var contentStream = new MemoryStream();
                await multipartContent.CopyToAsync(contentStream);
                contentStream.Position = 0;

                Response createResponse = await stacClient.CreateCollectionAssetAsync(
                    collectionId,
                    RequestContent.Create(contentStream),
                    multipartContent.Headers.ContentType?.ToString(),
                    null
                );
                Console.WriteLine("Asset created");
            }

            // Step 2: Update the asset
            Console.WriteLine("Step 2: Updating asset...");
            assetData["title"] = "Workflow Test Asset - Updated";
            byte[] updatedContent = System.Text.Encoding.UTF8.GetBytes("Updated content");

            using (var fileStream = new MemoryStream(updatedContent))
            {
                var multipartContent = new MultipartFormDataContent();
                multipartContent.Add(new StringContent(JsonSerializer.Serialize(assetData)), "data");
                multipartContent.Add(new StreamContent(fileStream), "file", "workflow-asset.txt");

                var contentStream = new MemoryStream();
                await multipartContent.CopyToAsync(contentStream);
                contentStream.Position = 0;

                Response updateResponse = await stacClient.ReplaceCollectionAssetAsync(
                    collectionId,
                    assetId,
                    RequestContent.Create(contentStream),
                    multipartContent.Headers.ContentType?.ToString(),
                    null
                );
                Console.WriteLine("Asset updated");
            }

            // Step 3: Delete the asset
            Console.WriteLine("Step 3: Deleting asset...");
            Response<StacCollectionResource> deleteResponse = await stacClient.DeleteCollectionAssetAsync(
                collectionId,
                assetId
            );
            Console.WriteLine("Asset deleted");
            Console.WriteLine("Workflow completed successfully");
            #endregion
        }
    }
}
