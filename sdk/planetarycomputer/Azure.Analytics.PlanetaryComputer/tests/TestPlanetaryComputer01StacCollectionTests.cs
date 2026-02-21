// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Additional tests for STAC Collection operations.
    /// Based on Python test: test_planetary_computer_01_stac_collection.py
    /// Complements existing StacClientTests.cs with collection listing and metadata operations.
    /// </summary>
    [AsyncOnly]
    public class TestPlanetaryComputer01StacCollectionTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer01StacCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Test listing all STAC collections.
        /// Python equivalent: test_01_list_collections
        /// C# method: GetCollections(sign=null, durationInMinutes=null)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Collections")]
        public async Task Test01_01_ListCollections()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            TestContext.WriteLine("Testing GetCollections (list all STAC collections)");

            // Act
            Response<StacCatalogCollections> response = await stacClient.GetCollectionsAsync();

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollections");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacCatalogCollections collections = response.Value;
            Assert.IsNotNull(collections, "Collections should not be null");
            Assert.IsNotNull(collections.Collections, "Collections array should not be null");

            // Verify collections array exists
            int collectionCount = collections.Collections.Count;
            TestContext.WriteLine($"Number of collections: {collectionCount}");

            // Verify we have at least one collection
            Assert.Greater(collectionCount, 0, "Should have at least one collection");

            // Verify first collection has required STAC properties
            if (collectionCount > 0)
            {
                StacCollectionResource firstCollection = collections.Collections[0];

                Assert.IsNotNull(firstCollection.Id, "Collection should have 'id' property");
                string collectionId = firstCollection.Id;
                ValidateNotNullOrEmpty(collectionId, "collection.id");

                TestContext.WriteLine($"First collection ID: {collectionId}");

                // Verify other STAC collection properties
                Assert.IsNotNull(firstCollection.Type, "Collection should have 'type' property");
                Assert.IsNotNull(firstCollection.Links, "Collection should have 'links' property");
                Assert.IsNotNull(firstCollection.StacVersion, "Collection should have 'stac_version' property");

                if (firstCollection.Title != null)
                {
                    string title = firstCollection.Title;
                    TestContext.WriteLine($"First collection title: {title}");
                }
            }

            TestContext.WriteLine($"Successfully listed {collectionCount} collections");
        }

        /// <summary>
        /// Test getting a specific STAC collection by ID.
        /// Python equivalent: test_03_get_collection
        /// C# method: GetCollection(collectionId, sign=null, durationInMinutes=null)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("GetCollection")]
        public async Task Test01_03_GetCollection()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollection for collection: {collectionId}");

            // Act
            Response<StacCollectionResource> response = await stacClient.GetCollectionAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollection");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacCollectionResource collection = response.Value;
            Assert.IsNotNull(collection, "Collection should not be null");

            // Verify collection ID matches
            Assert.IsNotNull(collection.Id, "Response should contain 'id' property");
            string returnedId = collection.Id;
            Assert.AreEqual(collectionId, returnedId, "Returned collection ID should match requested ID");

            // Verify STAC collection required properties
            Assert.IsNotNull(collection.Type, "Collection should have 'type' property");
            Assert.AreEqual("Collection", collection.Type, "Type should be 'Collection'");

            Assert.IsNotNull(collection.StacVersion, "Collection should have 'stac_version' property");
            ValidateNotNullOrEmpty(collection.StacVersion, "stac_version");
            TestContext.WriteLine($"STAC version: {collection.StacVersion}");

            Assert.IsNotNull(collection.Links, "Collection should have 'links' property");
            Assert.Greater(collection.Links.Count, 0, "Links should have at least one item");

            Assert.IsNotNull(collection.Extent, "Collection should have 'extent' property");
            Assert.IsNotNull(collection.License, "Collection should have 'license' property");

            // Log additional properties
            if (collection.Title != null)
            {
                TestContext.WriteLine($"Collection title: {collection.Title}");
            }

            if (collection.Description != null)
            {
                string description = collection.Description;
                if (description.Length > 100)
                {
                    description = description.Substring(0, 100) + "...";
                }
                TestContext.WriteLine($"Collection description: {description}");
            }

            TestContext.WriteLine($"Successfully retrieved collection: {returnedId}");
        }

        /// <summary>
        /// Test getting STAC conformance classes.
        /// Python equivalent: test_02_get_conformance_class
        /// C# method: GetConformanceClass()
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Conformance")]
        public async Task Test01_02_GetConformanceClass()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            TestContext.WriteLine("Testing GetConformanceClass");

            // Act
            Response<StacConformanceClasses> response = await stacClient.GetConformanceClassAsync();

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetConformanceClass");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacConformanceClasses conformance = response.Value;
            Assert.IsNotNull(conformance, "Conformance should not be null");
            Assert.IsNotNull(conformance.ConformsTo, "ConformsTo should not be null");

            int conformanceCount = conformance.ConformsTo.Count;
            TestContext.WriteLine($"Number of conformance classes: {conformanceCount}");
            Assert.Greater(conformanceCount, 0, "Should have at least one conformance class");

            // Log first few conformance URIs
            for (int i = 0; i < System.Math.Min(5, conformanceCount); i++)
            {
                TestContext.WriteLine($"Conformance class {i + 1}: {conformance.ConformsTo[i]}");
            }

            TestContext.WriteLine("Successfully retrieved conformance classes");
        }

        /// <summary>
        /// Test getting partition type for a collection.
        /// Python equivalent: test_04_get_partition_type
        /// C# method: GetPartitionType(collectionId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Partition")]
        public async Task Test01_04_GetPartitionType()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetPartitionType for collection: {collectionId}");

            // Act
            Response<PartitionType> response = await stacClient.GetPartitionTypeAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetPartitionType");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            PartitionType partitionType = response.Value;
            Assert.IsNotNull(partitionType, "PartitionType should not be null");
            Assert.IsNotNull(partitionType.Scheme, "Partition scheme should not be null");

            TestContext.WriteLine($"Partition scheme: {partitionType.Scheme}");

            // Verify scheme is a valid value
            string scheme = partitionType.Scheme.ToString();
            Assert.IsNotNull(scheme, "Scheme should have a value");

            TestContext.WriteLine($"Successfully retrieved partition type: {scheme}");
        }

        /// <summary>
        /// Test listing render options for a collection.
        /// Python equivalent: test_05_list_render_options
        /// C# method: GetRenderOptions(collectionId) -> list_render_options
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("RenderOptions")]
        public async Task Test01_05_ListRenderOptions()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetRenderOptions (list) for collection: {collectionId}");

            // Act
            Response<IReadOnlyList<RenderConfiguration>> response = await stacClient.GetRenderOptionsAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetRenderOptions");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            IReadOnlyList<RenderConfiguration> renderOptions = response.Value;
            Assert.IsNotNull(renderOptions, "RenderOptions should not be null");

            int optionCount = renderOptions.Count;
            TestContext.WriteLine($"Number of render options: {optionCount}");

            if (optionCount > 0)
            {
                RenderConfiguration firstOption = renderOptions[0];
                Assert.IsNotNull(firstOption.Id, "Render option should have ID");
                TestContext.WriteLine($"First render option ID: {firstOption.Id}");

                if (firstOption.Name != null)
                {
                    TestContext.WriteLine($"First render option name: {firstOption.Name}");
                }
            }

            TestContext.WriteLine($"Successfully listed {optionCount} render options");
        }

        /// <summary>
        /// Test getting tile settings for a collection.
        /// Python equivalent: test_06_get_tile_settings
        /// C# method: GetTileSettings(collectionId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("TileSettings")]
        public async Task Test01_06_GetTileSettings()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetTileSettings for collection: {collectionId}");

            // Act
            Response<TileSettings> response = await stacClient.GetTileSettingsAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetTileSettings");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            TileSettings tileSettings = response.Value;
            Assert.IsNotNull(tileSettings, "TileSettings should not be null");

            // Log available properties
            TestContext.WriteLine($"Max items per tile: {tileSettings.MaxItemsPerTile}");
            TestContext.WriteLine($"Min zoom: {tileSettings.MinZoom}");

            if (tileSettings.DefaultLocation != null)
            {
                TestContext.WriteLine($"Default location: {tileSettings.DefaultLocation}");
            }

            TestContext.WriteLine("Successfully retrieved tile settings");
        }

        /// <summary>
        /// Test listing mosaics for a collection.
        /// Python equivalent: test_07_list_mosaics
        /// C# method: GetMosaics(collectionId) -> list_mosaics
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Mosaics")]
        public async Task Test01_07_ListMosaics()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetMosaics (list) for collection: {collectionId}");

            // Act
            Response<IReadOnlyList<StacMosaic>> response = await stacClient.GetMosaicsAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetMosaics");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            IReadOnlyList<StacMosaic> mosaics = response.Value;
            Assert.IsNotNull(mosaics, "Mosaics should not be null");

            int mosaicCount = mosaics.Count;
            TestContext.WriteLine($"Number of mosaics: {mosaicCount}");

            if (mosaicCount > 0)
            {
                StacMosaic firstMosaic = mosaics[0];
                Assert.IsNotNull(firstMosaic.Id, "Mosaic should have ID");
                TestContext.WriteLine($"First mosaic ID: {firstMosaic.Id}");

                if (firstMosaic.Name != null)
                {
                    TestContext.WriteLine($"First mosaic name: {firstMosaic.Name}");
                }
            }

            TestContext.WriteLine($"Successfully listed {mosaicCount} mosaics");
        }

        /// <summary>
        /// Test getting queryables for a collection.
        /// Python equivalent: test_08_get_collection_queryables
        /// C# method: GetCollectionQueryables(collectionId)
        /// Returns raw JSON for queryables
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Queryables")]
        public async Task Test01_08_GetCollectionQueryables()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionQueryables for collection: {collectionId}");

            // Act - Using protocol method for raw JSON response
            Response response = await stacClient.GetCollectionQueryablesAsync(collectionId, new RequestContext());

            // Assert
            ValidateResponse(response, "GetCollectionQueryables");
            Assert.AreEqual(200, response.Status, "Expected successful response");

            // Parse JSON response
            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;

            Assert.IsTrue(root.TryGetProperty("properties", out JsonElement properties), "Response should have 'properties' key");

            int propertyCount = 0;
            foreach (JsonProperty prop in properties.EnumerateObject())
            {
                propertyCount++;
            }

            TestContext.WriteLine($"Number of queryables: {propertyCount}");

            if (propertyCount > 0)
            {
                JsonProperty firstProperty = properties.EnumerateObject().First();
                TestContext.WriteLine($"First queryable: {firstProperty.Name}");
            }

            TestContext.WriteLine($"Successfully retrieved {propertyCount} queryables");
        }

        /// <summary>
        /// Test listing all queryables (global).
        /// Python equivalent: test_09_list_queryables
        /// C# method: GetQueryables() -> list_queryables
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Queryables")]
        public async Task Test01_09_ListQueryables()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            TestContext.WriteLine("Testing GetQueryables (global queryables)");

            // Act - Using protocol method for raw JSON response
            Response response = await stacClient.GetQueryablesAsync(new RequestContext());

            // Assert
            ValidateResponse(response, "GetQueryables");
            Assert.AreEqual(200, response.Status, "Expected successful response");

            // Parse JSON response
            using JsonDocument doc = JsonDocument.Parse(response.Content);
            JsonElement root = doc.RootElement;

            Assert.IsTrue(root.TryGetProperty("properties", out JsonElement properties), "Response should have 'properties' key");

            int propertyCount = 0;
            foreach (JsonProperty prop in properties.EnumerateObject())
            {
                propertyCount++;
            }

            TestContext.WriteLine($"Number of global queryables: {propertyCount}");

            TestContext.WriteLine($"Successfully retrieved {propertyCount} global queryables");
        }

        /// <summary>
        /// Test getting collection configuration.
        /// Python equivalent: test_10_get_collection_configuration
        /// C# method: GetCollectionConfiguration(collectionId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Configuration")]
        public async Task Test01_10_GetCollectionConfiguration()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionConfiguration for collection: {collectionId}");

            // Act
            Response<UserCollectionSettings> response = await stacClient.GetCollectionConfigurationAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollectionConfiguration");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            UserCollectionSettings config = response.Value;
            Assert.IsNotNull(config, "Configuration should not be null");

            TestContext.WriteLine("Successfully retrieved collection configuration");
        }

        /// <summary>
        /// Test getting collection thumbnail.
        /// Python equivalent: test_11_get_collection_thumbnail
        /// C# method: GetCollectionThumbnail(collectionId)
        /// Returns streaming binary data
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Thumbnail")]
        public async Task Test01_11_GetCollectionThumbnail()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionThumbnail for collection: {collectionId}");

            // First check if collection has thumbnail asset
            Response<StacCollectionResource> collectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = collectionResponse.Value;

            if (collection.Assets == null || !collection.Assets.ContainsKey("thumbnail"))
            {
                TestContext.WriteLine("Collection does not have a thumbnail asset, skipping test");
                Assert.Pass("Collection does not have thumbnail");
                return;
            }

            // Act - Get thumbnail as streaming response
            Response response = await stacClient.GetCollectionThumbnailAsync(collectionId, new RequestContext());

            // Assert
            ValidateResponse(response, "GetCollectionThumbnail");
            Assert.AreEqual(200, response.Status, "Expected successful response");

            // Read the streaming content
            System.IO.Stream contentStream = response.ContentStream;
            Assert.IsNotNull(contentStream, "Content stream should not be null");

            // Read into byte array
            using var memoryStream = new System.IO.MemoryStream();
            await contentStream.CopyToAsync(memoryStream);
            byte[] thumbnailBytes = memoryStream.ToArray();

            TestContext.WriteLine($"Thumbnail size: {thumbnailBytes.Length} bytes");
            Assert.Greater(thumbnailBytes.Length, 0, "Thumbnail bytes should not be empty");
            Assert.Greater(thumbnailBytes.Length, 100, "Thumbnail should be substantial");

            // Check for common image format magic bytes
            bool isPng = thumbnailBytes.Length >= 8 &&
                        thumbnailBytes[0] == 0x89 && thumbnailBytes[1] == 0x50 &&
                        thumbnailBytes[2] == 0x4E && thumbnailBytes[3] == 0x47;

            bool isJpeg = thumbnailBytes.Length >= 3 &&
                         thumbnailBytes[0] == 0xFF && thumbnailBytes[1] == 0xD8 &&
                         thumbnailBytes[2] == 0xFF;

            Assert.IsTrue(isPng || isJpeg, "Thumbnail should be either PNG or JPEG format");

            if (isPng)
            {
                TestContext.WriteLine("Thumbnail format: PNG");
            }
            else if (isJpeg)
            {
                TestContext.WriteLine("Thumbnail format: JPEG");
            }

            TestContext.WriteLine("Successfully retrieved collection thumbnail");
        }

        /// <summary>
        /// Test creating a render option for a collection.
        /// Python equivalent: test_12_create_render_option
        /// C# method: CreateRenderOption(collectionId, body)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("RenderOptions")]
        [Category("Mutation")]
        public async Task Test01_12_CreateRenderOption()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing CreateRenderOption for collection: {collectionId}");

            // Check if render option already exists and delete it
            try
            {
                await stacClient.DeleteRenderOptionAsync(collectionId, "test-natural-color");
                TestContext.WriteLine("Deleted existing test render option");
            }
            catch
            {
                // Ignore if it doesn't exist
            }

            // Create render option
            var renderOption = new RenderConfiguration("test-natural-color", "Test Natural color")
            {
                Type = RenderOptionType.RasterTile,
                Options = "assets=image&asset_bidx=image|1,2,3",
                MinZoom = 6
            };

            // Act
            Response<RenderConfiguration> response = await stacClient.CreateRenderOptionAsync(collectionId, renderOption);

            // Assert
            ValidateResponse(response.GetRawResponse(), "CreateRenderOption");
            Assert.AreEqual(201, response.GetRawResponse().Status, "Expected 201 Created response");

            RenderConfiguration createdOption = response.Value;
            Assert.IsNotNull(createdOption, "Created render option should not be null");
            Assert.AreEqual("test-natural-color", createdOption.Id, "ID should match");
            Assert.AreEqual("Test Natural color", createdOption.Name, "Name should match");

            TestContext.WriteLine($"Successfully created render option: {createdOption.Id}");
        }

        /// <summary>
        /// Test getting a specific render option.
        /// Python equivalent: test_13_get_render_option
        /// C# method: GetRenderOption(collectionId, renderOptionId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("RenderOptions")]
        public async Task Test01_13_GetRenderOption()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetRenderOption for collection: {collectionId}");

            // Act
            Response<RenderConfiguration> response = await stacClient.GetRenderOptionAsync(collectionId, "test-natural-color");

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetRenderOption");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            RenderConfiguration renderOption = response.Value;
            Assert.IsNotNull(renderOption, "Render option should not be null");
            Assert.AreEqual("test-natural-color", renderOption.Id, "ID should match");
            Assert.IsNotNull(renderOption.Name, "Name should not be null");

            TestContext.WriteLine($"Successfully retrieved render option: {renderOption.Id}");
        }

        /// <summary>
        /// Test replacing a render option.
        /// Python equivalent: test_14_replace_render_option
        /// C# method: ReplaceRenderOption(collectionId, renderOptionId, body)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("RenderOptions")]
        [Category("Mutation")]
        public async Task Test01_14_ReplaceRenderOption()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing ReplaceRenderOption for collection: {collectionId}");

            // Create updated render option
            var renderOption = new RenderConfiguration("test-natural-color", "Test Natural color updated")
            {
                Description = "RGB from visual assets - updated",
                Type = RenderOptionType.RasterTile,
                Options = "assets=image&asset_bidx=image|1,2,3",
                MinZoom = 6
            };

            // Act
            Response<RenderConfiguration> response = await stacClient.ReplaceRenderOptionAsync(collectionId, "test-natural-color", renderOption);

            // Assert
            ValidateResponse(response.GetRawResponse(), "ReplaceRenderOption");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            RenderConfiguration updatedOption = response.Value;
            Assert.IsNotNull(updatedOption, "Updated render option should not be null");
            Assert.AreEqual("test-natural-color", updatedOption.Id, "ID should match");
            Assert.AreEqual("RGB from visual assets - updated", updatedOption.Description, "Description should be updated");

            TestContext.WriteLine($"Successfully replaced render option: {updatedOption.Id}");
        }

        /// <summary>
        /// Test deleting a render option.
        /// Python equivalent: test_14a_delete_render_option
        /// C# method: DeleteRenderOption(collectionId, renderOptionId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("RenderOptions")]
        [Category("Mutation")]
        public async Task Test01_14a_DeleteRenderOption()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing DeleteRenderOption for collection: {collectionId}");

            // Create a render option to be deleted
            var renderOption = new RenderConfiguration("test-render-opt-delete", "Test Render Option To Be Deleted")
            {
                Type = RenderOptionType.RasterTile,
                Options = "assets=image&asset_bidx=image|1,2,3",
                MinZoom = 6
            };

            TestContext.WriteLine("Creating render option for deletion");
            await stacClient.CreateRenderOptionAsync(collectionId, renderOption);

            // Verify it exists
            Response<RenderConfiguration> getResponse = await stacClient.GetRenderOptionAsync(collectionId, "test-render-opt-delete");
            Assert.IsNotNull(getResponse.Value, "Render option should exist before deletion");

            // Act - Delete it
            Response deleteResponse = await stacClient.DeleteRenderOptionAsync(collectionId, "test-render-opt-delete");

            // Assert
            ValidateResponse(deleteResponse, "DeleteRenderOption");
            Assert.That(deleteResponse.Status, Is.EqualTo(200).Or.EqualTo(204), "Expected 200 OK or 204 No Content response");

            TestContext.WriteLine("Render option deleted successfully");

            // Verify deletion - should throw or return 404
            try
            {
                await stacClient.GetRenderOptionAsync(collectionId, "test-render-opt-delete");
                Assert.Fail("Getting deleted render option should have failed");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status, "Should return 404 for deleted resource");
                TestContext.WriteLine("Verified render option was deleted");
            }
        }

        /// <summary>
        /// Test adding a mosaic to a collection.
        /// Python equivalent: test_15_add_mosaic
        /// C# method: AddMosaic(collectionId, body)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Mosaics")]
        [Category("Mutation")]
        public async Task Test01_15_AddMosaic()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing AddMosaic for collection: {collectionId}");

            // Check if mosaic already exists and delete it
            try
            {
                await stacClient.DeleteMosaicAsync(collectionId, "test-mosaic-1");
                TestContext.WriteLine("Deleted existing test mosaic");
            }
            catch
            {
                // Ignore if it doesn't exist
            }

            // Create mosaic
            var mosaic = new StacMosaic(
                id: "test-mosaic-1",
                name: "Test Most recent available",
                cql: new List<IDictionary<string, BinaryData>>()
            );

            // Act
            Response<StacMosaic> response = await stacClient.AddMosaicAsync(collectionId, mosaic);

            // Assert
            ValidateResponse(response.GetRawResponse(), "AddMosaic");
            Assert.IsTrue(response.GetRawResponse().Status == 201 || response.GetRawResponse().Status == 200,
                "Expected 201 Created or 200 OK response");

            StacMosaic createdMosaic = response.Value;
            Assert.IsNotNull(createdMosaic, "Created mosaic should not be null");
            Assert.AreEqual("test-mosaic-1", createdMosaic.Id, "ID should match");

            TestContext.WriteLine($"Successfully added mosaic: {createdMosaic.Id}");
        }

        /// <summary>
        /// Test getting a specific mosaic.
        /// Python equivalent: test_16_get_mosaic
        /// C# method: GetMosaic(collectionId, mosaicId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Mosaics")]
        public async Task Test01_16_GetMosaic()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetMosaic for collection: {collectionId}");

            // Act
            Response<StacMosaic> response = await stacClient.GetMosaicAsync(collectionId, "test-mosaic-1");

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetMosaic");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacMosaic mosaic = response.Value;
            Assert.IsNotNull(mosaic, "Mosaic should not be null");
            Assert.AreEqual("test-mosaic-1", mosaic.Id, "ID should match");

            TestContext.WriteLine($"Successfully retrieved mosaic: {mosaic.Id}");
        }

        /// <summary>
        /// Test replacing a mosaic.
        /// Python equivalent: test_17_replace_mosaic
        /// C# method: ReplaceMosaic(collectionId, mosaicId, body)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Mosaics")]
        [Category("Mutation")]
        public async Task Test01_17_ReplaceMosaic()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing ReplaceMosaic for collection: {collectionId}");

            // Create updated mosaic (name max 30 chars)
            var mosaic = new StacMosaic(
                id: "test-mosaic-1",
                name: "Test Mosaic Updated",
                cql: new List<IDictionary<string, BinaryData>>()
            );

            // Act
            Response<StacMosaic> response = await stacClient.ReplaceMosaicAsync(collectionId, "test-mosaic-1", mosaic);

            // Assert
            ValidateResponse(response.GetRawResponse(), "ReplaceMosaic");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacMosaic updatedMosaic = response.Value;
            Assert.IsNotNull(updatedMosaic, "Updated mosaic should not be null");
            Assert.AreEqual("test-mosaic-1", updatedMosaic.Id, "ID should match");
            Assert.AreEqual("Test Mosaic Updated", updatedMosaic.Name, "Name should be updated");

            TestContext.WriteLine($"Successfully replaced mosaic: {updatedMosaic.Id}");
        }

        /// <summary>
        /// Test deleting a mosaic.
        /// Python equivalent: test_17a_delete_mosaic
        /// C# method: DeleteMosaic(collectionId, mosaicId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Mosaics")]
        [Category("Mutation")]
        public async Task Test01_17a_DeleteMosaic()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing DeleteMosaic for collection: {collectionId}");

            // Create a mosaic to be deleted
            var mosaic = new StacMosaic(
                id: "test-mosaic-delete",
                name: "Test Mosaic To Be Deleted",
                cql: new List<IDictionary<string, BinaryData>>()
            );

            TestContext.WriteLine("Creating mosaic for deletion");
            await stacClient.AddMosaicAsync(collectionId, mosaic);

            // Verify it exists
            Response<StacMosaic> getResponse = await stacClient.GetMosaicAsync(collectionId, "test-mosaic-delete");
            Assert.IsNotNull(getResponse.Value, "Mosaic should exist before deletion");

            // Act - Delete it
            Response deleteResponse = await stacClient.DeleteMosaicAsync(collectionId, "test-mosaic-delete");

            // Assert
            ValidateResponse(deleteResponse, "DeleteMosaic");
            Assert.That(deleteResponse.Status, Is.EqualTo(200).Or.EqualTo(204), "Expected 200 OK or 204 No Content response");

            TestContext.WriteLine("Mosaic deleted successfully");

            // Verify deletion
            try
            {
                await stacClient.GetMosaicAsync(collectionId, "test-mosaic-delete");
                Assert.Fail("Getting deleted mosaic should have failed");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status, "Should return 404 for deleted resource");
                TestContext.WriteLine("Verified mosaic was deleted");
            }
        }
    }
}
