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
    [AsyncOnly]
    public class TestPlanetaryComputer05MosaicsTilerTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer05MosaicsTilerTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Tests registering a mosaics search with STAC search parameters.
        /// Maps to Python test: test_01_register_mosaics_search
        /// </summary>
        [Test]
        [Ignore("Missing session recording - needs to be recorded")]
        [Category("RegisterSearch")]
        public async Task Test05_01_RegisterMosaicsSearch()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");

            // Create search parameters - filter to 2021-2022 date range with CQL2-Text
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            var sortBy = new[]
            {
                new StacSortExtension("datetime", StacSearchSortingDirection.Desc)
            };

            TestContext.WriteLine($"Filter: {filter}");
            TestContext.WriteLine($"Filter Language: cql2-text");

            // Act - Use convenience method instead of JSON serialization
            Response<TilerMosaicSearchRegistrationResult> response = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text,
                sortBy: sortBy
            );

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);

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
        [Ignore("Missing session recording - needs to be recorded")]
        [Category("SearchInfo")]
        public async Task Test05_02_GetMosaicsSearchInfo()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            // First, register a search to get a search ID with CQL2-Text
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text
            );

            ValidateResponse(registerResponse);
            string searchId = registerResponse.Value.SearchId;

            TestContext.WriteLine($"Registered Search ID: {searchId}");

            // Act - Get search info for the registered search
            Response<TilerStacSearchRegistration> response = await dataClient.GetMosaicsSearchInfoAsync(searchId);

            // Assert
            ValidateResponse(response, "GetMosaicsSearchInfo");

            TilerStacSearchRegistration searchInfo = response.Value;
            Assert.IsNotNull(searchInfo, "Search info should not be null");

            TestContext.WriteLine($"Search registration retrieved successfully");
            TestContext.WriteLine($"Search info retrieved for search ID: {searchId}");
        }

        /// <summary>
        /// Tests getting mosaics tile JSON metadata.
        /// Maps to Python test: test_03_get_mosaics_tile_json
        /// </summary>
        [Test]
        [Ignore("Missing session recording - needs to be recorded")]
        [Category("TileJson")]
        public async Task Test05_03_GetMosaicsTileJson()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            // Register search first
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get tile JSON metadata
            Response<TileJsonMetadata> response = await dataClient.GetMosaicsTileJsonAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3",
                tileScale: 1,
                minZoom: 9,
                tileFormat: TilerImageFormat.Png,
                collection: collectionId
            );

            // Assert
            ValidateResponse(response, "GetMosaicsTileJson");

            TileJsonMetadata tileJson = response.Value;
            Assert.IsNotNull(tileJson, "TileJSON should not be null");
            Assert.IsNotNull(tileJson.TileJson, "TileJSON version should not be null");
            Assert.IsNotNull(tileJson.Tiles, "Tiles array should not be null");
            Assert.Greater(tileJson.Tiles.Count, 0, "Should have at least one tile URL pattern");

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
        [Ignore("Missing session recording - needs to be recorded")]
        [Category("Tile")]
        public async Task Test05_04_GetMosaicsTile()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine("Input - tile coordinates: z=13, x=2174, y=3282");

            // Register search first
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get tile image
            Response<BinaryData> response = await dataClient.GetMosaicsTileAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 13,
                x: 2174,
                y: 3282,
                scale: 1,
                format: "png",
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3",
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
            Assert.Greater(imageBytes.Length, 0, "Image bytes should not be empty");
            Assert.Greater(imageBytes.Length, 100, $"Image should be substantial, got only {imageBytes.Length} bytes");

            for (int i = 0; i < pngMagic.Length; i++)
            {
                Assert.AreEqual(pngMagic[i], imageBytes[i], $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("PNG magic bytes verified successfully");
        }

        /// <summary>
        /// Tests getting WMTS capabilities XML for mosaics.
        /// Maps to Python test: test_05_get_mosaics_wmts_capabilities
        /// </summary>
        [Test]
        [Ignore("Missing session recording - needs to be recorded")]
        [Category("WMTS")]
        public async Task Test05_05_GetMosaicsWmtsCapabilities()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            // Register search first
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get WMTS capabilities
            Response<BinaryData> response = await dataClient.GetMosaicsWmtsCapabilitiesAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                tileFormat: TilerImageFormat.Png,
                tileScale: 1,
                minZoom: 7,
                maxZoom: 13,
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3"
            );

            // Assert
            ValidateResponse(response, "GetMosaicsWmtsCapabilities");

            BinaryData xmlData = response.Value;
            byte[] xmlBytes = xmlData.ToArray();
            string xmlString = Encoding.UTF8.GetString(xmlBytes);

            TestContext.WriteLine($"XML size: {xmlBytes.Length} bytes");
            TestContext.WriteLine($"XML first 200 chars: {xmlString.Substring(0, Math.Min(200, xmlString.Length))}");

            // Validate XML structure
            Assert.Greater(xmlBytes.Length, 0, "XML bytes should not be empty");
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
        [Ignore("Missing session recording - needs to be recorded")]
        [Category("Assets")]
        public async Task Test05_06_GetMosaicsAssetsForPoint()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            float longitude = -84.43202751899601f;
            float latitude = 33.639647639722273f;

            TestContext.WriteLine($"Input - point: longitude={longitude}, latitude={latitude}");

            // Register search first
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get assets for point
            Response<IReadOnlyList<StacItemPointAsset>> response = await dataClient.GetMosaicsAssetsForPointAsync(
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
            Assert.IsNotNull(assets, "Assets list should not be null");

            TestContext.WriteLine($"Number of assets: {assets.Count}");

            // If we have assets, validate structure
            if (assets.Count > 0)
            {
                StacItemPointAsset firstAsset = assets[0];
                Assert.IsNotNull(firstAsset, "First asset should not be null");
                Assert.IsNotNull(firstAsset.Id, "Asset ID should not be null");
                Assert.IsNotEmpty(firstAsset.Id, "Asset ID should not be empty");

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
        [Ignore("Missing session recording - needs to be recorded")]
        [Category("Assets")]
        public async Task Test05_07_GetMosaicsAssetsForTile()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine("Input - tile coordinates: z=13, x=2174, y=3282");

            // Register search first
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text
            );

            string searchId = registerResponse.Value.SearchId;
            TestContext.WriteLine($"Using search ID: {searchId}");

            // Act - Get assets for tile
            Response<IReadOnlyList<BinaryData>> response = await dataClient.GetMosaicsAssetsForTileAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 13,
                x: 2174,
                y: 3282,
                collectionId: collectionId
            );

            // Assert
            ValidateResponse(response, "GetMosaicsAssetsForTile");

            IReadOnlyList<BinaryData> assets = response.Value;
            Assert.IsNotNull(assets, "Assets list should not be null");

            TestContext.WriteLine($"Number of assets: {assets.Count}");
            TestContext.WriteLine("Assets for tile retrieved successfully");
        }

        /// <summary>
        /// Tests creating a static image from a mosaic search.
        /// Maps to Python test: test_08_create_static_image
        /// </summary>
        [Test]
        [Category("StaticImage")]
        public async Task Test05_08_CreateStaticImage()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            // Define geometry for the static image - coordinates as [[[lon, lat], ...]]
            var coordinates = new List<IList<IList<float>>>
            {
                new List<IList<float>>
                {
                    new List<float> { -84.45378097481053f, 33.6567321707079f },
                    new List<float> { -84.39805886744838f, 33.6567321707079f },
                    new List<float> { -84.39805886744838f, 33.61945681366625f },
                    new List<float> { -84.45378097481053f, 33.61945681366625f },
                    new List<float> { -84.45378097481053f, 33.6567321707079f }
                }
            };
            var geometry = new PolygonGeometry(coordinates);

            TestContext.WriteLine($"Geometry defined with coordinates");

            // Create CQL2-JSON filter (as dictionary)
            var cqlFilter = new Dictionary<string, BinaryData>
            {
                ["op"] = BinaryData.FromString("\"and\""),
                ["args"] = BinaryData.FromString($@"[
                    {{""op"": ""="", ""args"": [{{""property"": ""collection""}}, ""{collectionId}""]}},
                    {{
                        ""op"": ""anyinteracts"",
                        ""args"": [
                            {{""property"": ""datetime""}},
                            {{""interval"": [""2023-01-01T00:00:00Z"", ""2023-12-31T00:00:00Z""]}}
                        ]
                    }}
                ]")
            };

            // Create image request - all required parameters in constructor
            var imageRequest = new ImageParameters(
                cql: cqlFilter,
                renderParameters: $"assets=image&asset_bidx=image|1,2,3&collection={collectionId}",
                columns: 1080,
                rows: 1080
            );

            imageRequest.Zoom = 13;
            imageRequest.Geometry = geometry;
            imageRequest.ImageSize = "1080x1080";
            imageRequest.ShowBranding = false;

            TestContext.WriteLine($"Image request: columns={imageRequest.Columns}, rows={imageRequest.Rows}, zoom={imageRequest.Zoom}");

            // Act - Create static image
            Response<ImageResponse> response = await dataClient.CreateStaticImageAsync(
                collectionId: collectionId,
                body: imageRequest
            );

            // Assert
            ValidateResponse(response, "CreateStaticImage");

            ImageResponse imageResponse = response.Value;
            Assert.IsNotNull(imageResponse, "Image response should not be null");
            Assert.IsNotNull(imageResponse.Url, "Image URL should not be null");

            TestContext.WriteLine($"Static image created successfully");
            TestContext.WriteLine($"Image URL: {imageResponse.Url}");
        }

        /// <summary>
        /// Tests retrieving a static image by ID.
        /// Maps to Python test: test_09_get_static_image
        /// </summary>
        [Test]
        [Category("StaticImage")]
        public async Task Test05_09_GetStaticImage()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            // First create a static image to get an ID
            var coordinates = new List<IList<IList<float>>>
            {
                new List<IList<float>>
                {
                    new List<float> { -84.45378097481053f, 33.6567321707079f },
                    new List<float> { -84.39805886744838f, 33.6567321707079f },
                    new List<float> { -84.39805886744838f, 33.61945681366625f },
                    new List<float> { -84.45378097481053f, 33.61945681366625f },
                    new List<float> { -84.45378097481053f, 33.6567321707079f }
                }
            };
            var geometry = new PolygonGeometry(coordinates);

            var cqlFilter = new Dictionary<string, BinaryData>
            {
                ["op"] = BinaryData.FromString("\"and\""),
                ["args"] = BinaryData.FromString($@"[
                    {{""op"": ""="", ""args"": [{{""property"": ""collection""}}, ""{collectionId}""]}},
                    {{
                        ""op"": ""anyinteracts"",
                        ""args"": [
                            {{""property"": ""datetime""}},
                            {{""interval"": [""2023-01-01T00:00:00Z"", ""2023-12-31T00:00:00Z""]}}
                        ]
                    }}
                ]")
            };

            var imageRequest = new ImageParameters(
                cql: cqlFilter,
                renderParameters: $"assets=image&asset_bidx=image|1,2,3&collection={collectionId}",
                columns: 1080,
                rows: 1080
            );
            imageRequest.Zoom = 13;
            imageRequest.Geometry = geometry;
            imageRequest.ImageSize = "1080x1080";
            imageRequest.ShowBranding = false;

            Response<ImageResponse> createResponse = await dataClient.CreateStaticImageAsync(
                collectionId: collectionId,
                body: imageRequest
            );

            Uri url = createResponse.Value.Url;

            // Extract image ID from URL - split by '?' to remove query params, then get last path segment
            string imageId = url.ToString().Split('?')[0].Split('/').Last();

            TestContext.WriteLine($"Created image with ID: {imageId}");
            TestContext.WriteLine($"Image URL: {url}");

            Assert.IsNotNull(imageId, "Image ID should not be null");
            Assert.IsNotEmpty(imageId, "Image ID should not be empty");

            // Act - Get the static image
            Response<BinaryData> response = await dataClient.GetStaticImageAsync(
                collectionId: collectionId,
                id: imageId
            );

            // Assert
            ValidateResponse(response, "GetStaticImage");

            BinaryData imageData = response.Value;
            byte[] imageBytes = imageData.ToArray();

            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");
            TestContext.WriteLine($"First 16 bytes (hex): {BitConverter.ToString(imageBytes.Take(16).ToArray()).Replace("-", "")}");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            Assert.Greater(imageBytes.Length, 0, "Image bytes should not be empty");

            for (int i = 0; i < Math.Min(pngMagic.Length, imageBytes.Length); i++)
            {
                Assert.AreEqual(pngMagic[i], imageBytes[i], $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("PNG magic bytes verified successfully");
        }
    }
}
