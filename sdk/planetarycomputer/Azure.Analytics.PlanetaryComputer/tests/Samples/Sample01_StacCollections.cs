// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests.Samples
{
    /// <summary>
    /// Samples demonstrating how to work with STAC collections using the Planetary Computer SDK.
    /// </summary>
    public partial class Sample01_StacCollections : PlanetaryComputerTestBase
    {
        public Sample01_StacCollections(bool isAsync) : base(isAsync) { }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListCollections()
        {
            #region Snippet:Sample01_ListCollections
            // Create a Planetary Computer client
#if SNIPPET
            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");
            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());
#else
            var client = GetTestClient();
#endif
            StacClient stacClient = client.GetStacClient();

            // List all available STAC collections
            Response<StacCatalogCollections> response = await stacClient.GetCollectionsAsync();
            StacCatalogCollections collections = response.Value;

            Console.WriteLine($"Found {collections.Collections.Count} collections:");
            foreach (StacCollectionResource collection in collections.Collections)
            {
                Console.WriteLine($"  - {collection.Id}: {collection.Title}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetCollection()
        {
            #region Snippet:Sample01_GetCollection
            // Create a Planetary Computer client
#if SNIPPET
            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");
            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());
#else
            var client = GetTestClient();
#endif
            StacClient stacClient = client.GetStacClient();

            // Get a specific collection by ID
            string collectionId = "naip";
            Response<StacCollectionResource> response = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = response.Value;

            Console.WriteLine($"Collection: {collection.Id}");
            Console.WriteLine($"Title: {collection.Title}");
            Console.WriteLine($"Description: {collection.Description}");
            Console.WriteLine($"License: {collection.License}");
            Console.WriteLine($"STAC Version: {collection.StacVersion}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetConformanceClasses()
        {
            #region Snippet:Sample01_GetConformanceClasses
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // Get STAC conformance classes
            Response<StacConformanceClasses> response = await stacClient.GetConformanceClassAsync();
            StacConformanceClasses conformance = response.Value;

            Console.WriteLine("STAC Conformance Classes:");
            foreach (Uri conformsTo in conformance.ConformsTo)
            {
                Console.WriteLine($"  - {conformsTo}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetPartitionType()
        {
            #region Snippet:Sample01_GetPartitionType
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // Get partition type for a collection
            string collectionId = "naip";
            Response<PartitionType> response = await stacClient.GetPartitionTypeAsync(collectionId);
            PartitionType partitionType = response.Value;

            Console.WriteLine($"Partition scheme: {partitionType.Scheme}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListRenderOptions()
        {
            #region Snippet:Sample01_ListRenderOptions
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // List render options for a collection
            string collectionId = "naip";
            Response<IReadOnlyList<RenderConfiguration>> response = await stacClient.GetRenderOptionsAsync(collectionId);
            IReadOnlyList<RenderConfiguration> renderOptions = response.Value;

            Console.WriteLine($"Render options for {collectionId}:");
            foreach (RenderConfiguration option in renderOptions)
            {
                Console.WriteLine($"  - {option.Id}: {option.Name}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetTileSettings()
        {
            #region Snippet:Sample01_GetTileSettings
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // Get tile settings for a collection
            string collectionId = "naip";
            Response<TileSettings> response = await stacClient.GetTileSettingsAsync(collectionId);
            TileSettings tileSettings = response.Value;

            Console.WriteLine($"Max items per tile: {tileSettings.MaxItemsPerTile}");
            Console.WriteLine($"Min zoom: {tileSettings.MinZoom}");
            if (tileSettings.DefaultLocation != null)
            {
                Console.WriteLine($"Default location: {tileSettings.DefaultLocation}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListMosaics()
        {
            #region Snippet:Sample01_ListMosaics
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // List mosaics for a collection
            string collectionId = "naip";
            Response<IReadOnlyList<StacMosaic>> response = await stacClient.GetMosaicsAsync(collectionId);
            IReadOnlyList<StacMosaic> mosaics = response.Value;

            Console.WriteLine($"Mosaics for {collectionId}:");
            foreach (StacMosaic mosaic in mosaics)
            {
                Console.WriteLine($"  - {mosaic.Id}: {mosaic.Name}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetCollectionQueryables()
        {
            #region Snippet:Sample01_GetCollectionQueryables
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // Get queryables for a collection
            string collectionId = "naip";
            Response response = await stacClient.GetCollectionQueryablesAsync(collectionId, new RequestContext());

            // Parse the JSON response
            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;
            JsonElement properties = root.GetProperty("properties");

            Console.WriteLine($"Queryables for {collectionId}:");
            foreach (JsonProperty property in properties.EnumerateObject())
            {
                Console.WriteLine($"  - {property.Name}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListGlobalQueryables()
        {
            #region Snippet:Sample01_ListGlobalQueryables
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // Get global queryables
            Response response = await stacClient.GetQueryablesAsync(new RequestContext());

            // Parse the JSON response
            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;
            JsonElement properties = root.GetProperty("properties");

            Console.WriteLine("Global queryables:");
            foreach (JsonProperty property in properties.EnumerateObject())
            {
                Console.WriteLine($"  - {property.Name}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetCollectionConfiguration()
        {
            #region Snippet:Sample01_GetCollectionConfiguration
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // Get collection configuration
            string collectionId = "naip";
            Response<UserCollectionSettings> response = await stacClient.GetCollectionConfigurationAsync(collectionId);
            UserCollectionSettings config = response.Value;

            Console.WriteLine($"Configuration for {collectionId} retrieved successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetCollectionThumbnail()
        {
            #region Snippet:Sample01_GetCollectionThumbnail
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // Get collection thumbnail
            string collectionId = "naip";
            Response response = await stacClient.GetCollectionThumbnailAsync(collectionId, new RequestContext());

            // Read the thumbnail data
            System.IO.Stream contentStream = response.ContentStream;
            using var memoryStream = new System.IO.MemoryStream();
            await contentStream.CopyToAsync(memoryStream);
            byte[] thumbnailBytes = memoryStream.ToArray();

            Console.WriteLine($"Thumbnail downloaded: {thumbnailBytes.Length} bytes");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ManageRenderOptions()
        {
            #region Snippet:Sample01_ManageRenderOptions
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = "naip";

            // Create a new render option
            var renderOption = new RenderConfiguration("custom-render", "Custom Natural Color")
            {
                Type = RenderOptionType.RasterTile,
                Options = "assets=image&asset_bidx=image|1,2,3",
                MinZoom = 6,
                Description = "Custom RGB rendering"
            };

            Response<RenderConfiguration> createResponse = await stacClient.CreateRenderOptionAsync(collectionId, renderOption);
            Console.WriteLine($"Created render option: {createResponse.Value.Id}");

            // Get the render option
            Response<RenderConfiguration> getResponse = await stacClient.GetRenderOptionAsync(collectionId, "custom-render");
            Console.WriteLine($"Retrieved render option: {getResponse.Value.Name}");

            // Update the render option
            renderOption.Description = "Updated custom RGB rendering";
            Response<RenderConfiguration> updateResponse = await stacClient.ReplaceRenderOptionAsync(
                collectionId, "custom-render", renderOption);
            Console.WriteLine($"Updated render option: {updateResponse.Value.Description}");

            // Delete the render option
            await stacClient.DeleteRenderOptionAsync(collectionId, "custom-render");
            Console.WriteLine("Deleted render option");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ManageMosaics()
        {
            #region Snippet:Sample01_ManageMosaics
            // Create a Planetary Computer client
            var client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = "naip";

            // Add a new mosaic
            var mosaic = new StacMosaic(
                id: "custom-mosaic",
                name: "Custom Mosaic",
                cql: new List<IDictionary<string, BinaryData>>()
            );

            Response<StacMosaic> addResponse = await stacClient.AddMosaicAsync(collectionId, mosaic);
            Console.WriteLine($"Added mosaic: {addResponse.Value.Id}");

            // Get the mosaic
            Response<StacMosaic> getResponse = await stacClient.GetMosaicAsync(collectionId, "custom-mosaic");
            Console.WriteLine($"Retrieved mosaic: {getResponse.Value.Name}");

            // Update the mosaic
            mosaic.Name = "Updated Custom Mosaic";
            Response<StacMosaic> updateResponse = await stacClient.ReplaceMosaicAsync(
                collectionId, "custom-mosaic", mosaic);
            Console.WriteLine($"Updated mosaic: {updateResponse.Value.Name}");

            // Delete the mosaic
            await stacClient.DeleteMosaicAsync(collectionId, "custom-mosaic");
            Console.WriteLine("Deleted mosaic");
            #endregion
        }
    }
}
