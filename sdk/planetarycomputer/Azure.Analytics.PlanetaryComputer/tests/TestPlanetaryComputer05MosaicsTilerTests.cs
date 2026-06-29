// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for Mosaics Tiler operations using DataClient.
    /// Tests are mapped from Python tests in test_planetary_computer_05_mosaics_tiler.py.
    /// </summary>
    [Category("Tiler")]
    [Category("Mosaics")]
    public class TestPlanetaryComputer05MosaicsTilerTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer05MosaicsTilerTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Creates a CQL2-JSON filter for temporal range matching the Python implementation.
        /// </summary>
        private static Dictionary<string, BinaryData> CreateTemporalFilter(string collectionId)
        {
            return new Dictionary<string, BinaryData>
            {
                ["op"] = BinaryData.FromString("\"and\""),
                ["args"] = BinaryData.FromObjectAsJson(new object[]
                {
                    new Dictionary<string, object>
                    {
                        ["op"] = "=",
                        ["args"] = new object[]
                        {
                            new Dictionary<string, string> { ["property"] = "collection" },
                            collectionId
                        }
                    },
                    new Dictionary<string, object>
                    {
                        ["op"] = ">=",
                        ["args"] = new object[]
                        {
                            new Dictionary<string, string> { ["property"] = "datetime" },
                            "2021-01-01T00:00:00Z"
                        }
                    },
                    new Dictionary<string, object>
                    {
                        ["op"] = "<=",
                        ["args"] = new object[]
                        {
                            new Dictionary<string, string> { ["property"] = "datetime" },
                            "2022-12-31T23:59:59Z"
                        }
                    }
                })
            };
        }

        /// <summary>
        /// Tests registering a mosaics search with STAC search parameters.
        /// Maps to Python test: test_01_register_mosaics_search
        /// </summary>
        [Test]
        [Category("RegisterSearch")]
        public async Task Test05_01_RegisterMosaicsSearch()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");

            // Create CQL2-JSON filter (matching Python implementation)
            var filter = CreateTemporalFilter(collectionId);

            var sortBy = new[]
            {
                new StacSortExtension("datetime", StacSearchSortingDirection.Desc)
            };

            TestContext.WriteLine($"Filter Language: CQL2-JSON");

            // Act
            Response<TilerMosaicSearchRegistrationResult> response = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json,
                sortBy: sortBy
            );

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);

            TilerMosaicSearchRegistrationResult result = response.Value;
            ValidateNotNullOrEmpty(result.SearchId, "Search ID");

            TestContext.WriteLine($"Search ID: {result.SearchId}");

            // Search ID should be a non-empty string (typically a hash)
            Assert.That(result.SearchId.Length, Is.GreaterThan(0), "Search ID should not be empty");

            // In live mode, verify search ID format (typically alphanumeric hash)
            if (Mode == RecordedTestMode.Live)
            {
                Assert.That(result.SearchId, Does.Match(@"^[a-zA-Z0-9]+$"),
                    "Search ID should be alphanumeric (hash format)");
            }
        }

        /// <summary>
        /// Tests getting mosaics search info after registration.
        /// Maps to Python test: test_02_get_mosaics_search_info
        /// </summary>
        [Test]
        [Category("SearchInfo")]
        public async Task Test05_02_GetSearchInfo()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            // Create CQL2-JSON filter (matching Python implementation)
            var filter = CreateTemporalFilter(collectionId);

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json
            );

            ValidateResponse(registerResponse);
            string searchId = registerResponse.Value.SearchId;

            TestContext.WriteLine($"Registered Search ID: {searchId}");

            // Act - Get search info for the registered search
            Response<TilerStacSearchRegistration> response = await dataClient.GetSearchInfoAsync(searchId);

            // Assert
            ValidateResponse(response, "GetMosaicsSearchInfo");

            TilerStacSearchRegistration searchInfo = response.Value;
            Assert.That(searchInfo, Is.Not.Null, "Search info should not be null");

            TestContext.WriteLine($"Search registration retrieved successfully");
            TestContext.WriteLine($"Search info retrieved for search ID: {searchId}");
        }

        /// <summary>
        /// Tests getting mosaics tile JSON metadata.
        /// Maps to Python test: test_03_get_mosaics_tile_json
        /// </summary>
        [Test]
        [Category("TileJson")]
        public async Task Test05_03_GetSearchTileJson()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            // Register search first with CQL2-JSON filter (matching Python implementation)
            var filter = CreateTemporalFilter(collectionId);

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get tile JSON metadata
            Response<TileJsonMetadata> response = await dataClient.GetSearchTileJsonAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                assets: new[] { "image" },
                assetBandIndices: new[] { "image|1,2,3" },
                tileScale: 1,
                minZoom: 9,
                tileFormat: TilerImageFormat.Png,
                collectionId: collectionId
            );

            // Assert
            ValidateResponse(response, "GetMosaicsTileJson");

            TileJsonMetadata tileJson = response.Value;
            Assert.That(tileJson, Is.Not.Null, "TileJSON should not be null");
            Assert.That(tileJson.TileJson, Is.Not.Null, "TileJSON version should not be null");
            Assert.That(tileJson.Tiles, Is.Not.Null, "Tiles array should not be null");
            Assert.That(tileJson.Tiles.Count, Is.GreaterThan(0), "Should have at least one tile URL pattern");

            TestContext.WriteLine($"TileJSON version: {tileJson.TileJson}");
            TestContext.WriteLine($"Number of tile URL patterns: {tileJson.Tiles.Count}");
            if (tileJson.Tiles.Count > 0)
            {
                TestContext.WriteLine($"First tile URL pattern: {tileJson.Tiles[0]}");
            }
        }

        /// <summary>
        /// Tests getting a specific mosaic tile as PNG image.
        /// Maps to Python test: test_04_get_mosaics_tile
        /// </summary>
        [Test]
        [Category("MosaicTile")]
        public async Task Test05_04_GetSearchTile()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine("Using tile coordinates: z=13, x=2174, y=3282");

            // Register search first with CQL2-JSON filter (matching Python implementation)
            var filter = CreateTemporalFilter(collectionId);

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get tile image
            Response<BinaryData> response = await dataClient.GetSearchTileAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 13,
                x: 2174,
                y: 3282,
                scale: 1,
                format: "png",
                assets: new[] { "image" },
                assetBandIndices: new[] { "image|1,2,3" },
                collection: collectionId
            );

            // Assert
            ValidateResponse(response, "GetMosaicsTile");

            BinaryData imageData = response.Value;
            byte[] imageBytes = imageData.ToArray();

            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");
            TestContext.WriteLine($"First 16 bytes (hex): {BitConverter.ToString(imageBytes.Take(16).ToArray()).Replace("-", "")}");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            Assert.That(imageBytes.Length, Is.GreaterThan(0), "Image bytes should not be empty");
            Assert.That(imageBytes.Length, Is.GreaterThan(100), $"Image should be substantial, got only {imageBytes.Length} bytes");

            for (int i = 0; i < pngMagic.Length; i++)
            {
                Assert.That(imageBytes[i], Is.EqualTo(pngMagic[i]), $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("PNG magic bytes verified successfully");
        }

        /// <summary>
        /// Tests getting WMTS capabilities XML for mosaics.
        /// Maps to Python test: test_05_get_mosaics_wmts_capabilities
        /// </summary>
        [Test]
        [Category("WmtsCapabilities")]
        public async Task Test05_05_GetSearchWmtsCapabilities()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            // Register search first with CQL2-JSON filter (matching Python implementation)
            var filter = CreateTemporalFilter(collectionId);

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get WMTS capabilities
            Response<BinaryData> response = await dataClient.GetSearchWmtsCapabilitiesAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                tileFormat: TilerImageFormat.Png,
                tileScale: 1,
                minZoom: 7,
                maxZoom: 13,
                assets: new[] { "image" },
                assetBandIndices: new[] { "image|1,2,3" }
            );

            // Assert
            ValidateResponse(response, "GetMosaicsWmtsCapabilities");

            BinaryData xmlData = response.Value;
            byte[] xmlBytes = xmlData.ToArray();
            string xmlString = Encoding.UTF8.GetString(xmlBytes);

            TestContext.WriteLine($"XML size: {xmlBytes.Length} bytes");
            TestContext.WriteLine($"XML first 200 chars: {xmlString.Substring(0, Math.Min(200, xmlString.Length))}");

            // Validate XML structure
            Assert.That(xmlBytes.Length, Is.GreaterThan(0), "XML bytes should not be empty");
            Assert.That(xmlString, Does.Contain("Capabilities"), "Response should contain Capabilities element");
            Assert.That(xmlString.ToLower(), Does.Contain("wmts"), "Response should reference WMTS");
            Assert.That(xmlString, Does.Contain("TileMatrix"), "Response should contain TileMatrix information");

            TestContext.WriteLine("WMTS capabilities XML validated successfully");
        }

        /// <summary>
        /// Tests getting mosaic assets for a specific point.
        /// Maps to Python test: test_06_get_mosaics_assets_for_point
        /// </summary>
        [Test]
        [Category("Assets")]
        public async Task Test05_06_GetSearchPointWithAssets()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            float longitude = -84.43202751899601f;
            float latitude = 33.639647639722273f;

            TestContext.WriteLine($"Input - point: longitude={longitude}, latitude={latitude}");

            // Register search first with CQL2-JSON filter (matching Python implementation)
            var filter = CreateTemporalFilter(collectionId);

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get assets for point
            Response<IReadOnlyList<StacItemPointAsset>> response = await dataClient.GetSearchPointWithAssetsAsync(
                searchId: searchId,
                longitude: longitude,
                latitude: latitude,
                coordinateReferenceSystem: "EPSG:4326",
                itemsLimit: 100,
                exitWhenFull: true,
                scanLimit: 100,
                skipCovered: true,
                timeLimit: 30
            );

            // Assert
            ValidateResponse(response, "GetMosaicsAssetsForPoint");

            IReadOnlyList<StacItemPointAsset> assets = response.Value;
            Assert.That(assets, Is.Not.Null, "Assets list should not be null");

            TestContext.WriteLine($"Number of assets: {assets.Count}");

            // If we have assets, validate structure
            if (assets.Count > 0)
            {
                StacItemPointAsset firstAsset = assets[0];
                Assert.That(firstAsset, Is.Not.Null, "First asset should not be null");
                Assert.That(firstAsset.Id, Is.Not.Null, "Asset ID should not be null");
                Assert.That(firstAsset.Id, Is.Not.Empty, "Asset ID should not be empty");

                TestContext.WriteLine($"First asset ID: {firstAsset.Id}");
            }
            else
            {
                TestContext.WriteLine("No assets returned for this point");
            }
        }

        /// <summary>
        /// Tests getting mosaic assets for a specific tile.
        /// Maps to Python test: test_07_get_mosaics_assets_for_tile
        /// </summary>
        [Test]
        [Category("AssetsForTile")]
        public async Task Test05_07_GetSearchAssetsForTile()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine("Using tile coordinates: z=13, x=2174, y=3282");

            // Register search first with CQL2-JSON filter (matching Python implementation)
            var filter = CreateTemporalFilter(collectionId);

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get assets for tile
            Response<IReadOnlyList<TilerAssetGeoJson>> response = await dataClient.GetSearchAssetsForTileAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 13,
                x: 2174,
                y: 3282,
                collectionId: collectionId
            );

            // Assert
            ValidateResponse(response, "GetMosaicsAssetsForTile");

            IReadOnlyList<TilerAssetGeoJson> assets = response.Value;
            Assert.That(assets, Is.Not.Null, "Assets list should not be null");

            TestContext.WriteLine($"Number of assets: {assets.Count}");
            TestContext.WriteLine("Assets for tile retrieved successfully");
        }
    }
}
