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
    /// Tests for STAC Item Tiler operations using DataClient.
    /// Tests are mapped from Python tests in test_planetary_computer_06_stac_item_tiler.py.
    /// </summary>
    [Category("Tiler")]
    [AsyncOnly]
    public class TestPlanetaryComputer06StacItemTilerTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer06StacItemTilerTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Tests getting tile matrix definitions for a specific tile matrix set (WebMercatorQuad).
        /// Maps to Python test: test_01_get_tile_matrix_definitions
        /// </summary>
        [Test]
        [Category("TileMatrices")]
        [Category("TileMatrixDefinitions")]
        public async Task Test06_01_GetTileMatrixDefinitions()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string tileMatrixSetId = "WebMercatorQuad";

            TestContext.WriteLine($"Input - tile_matrix_set_id: {tileMatrixSetId}");

            // Act
            Response<TileMatrixSet> response = await dataClient.GetTileMatrixDefinitionsAsync(tileMatrixSetId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetTileMatrixDefinitions");

            TileMatrixSet tileMatrixSet = response.Value;
            Assert.IsNotNull(tileMatrixSet, "TileMatrixSet should not be null");
            Assert.IsNotNull(tileMatrixSet.Id, "TileMatrixSet ID should not be null");
            Assert.IsNotNull(tileMatrixSet.TileMatrices, "TileMatrices should not be null");

            TestContext.WriteLine($"TileMatrixSet ID: {tileMatrixSet.Id}");

            // Note: In playback mode, ID may be "Sanitized" due to test proxy sanitization
            if (Mode == RecordedTestMode.Live)
            {
                Assert.That(tileMatrixSet.Id, Is.EqualTo(tileMatrixSetId), $"ID should match requested tile matrix set");
            }

            // Verify tileMatrices array
            Assert.That(tileMatrixSet.TileMatrices.Count, Is.GreaterThan(0), "Should have at least one tile matrix");

            TestContext.WriteLine($"Number of tile matrices: {tileMatrixSet.TileMatrices.Count}");

            // Validate first tile matrix structure
            var firstMatrix = tileMatrixSet.TileMatrices[0];
            Assert.IsNotNull(firstMatrix, "First tile matrix should not be null");

            // Verify required tile matrix properties
            Assert.IsNotNull(firstMatrix.Id, "Tile matrix should have 'id'");
            ValidateNotNullOrEmpty(firstMatrix.Id, "Tile matrix id");

            Assert.IsNotNull(firstMatrix.ScaleDenominator, "Tile matrix should have 'scaleDenominator'");

            int tileWidth = firstMatrix.TileWidth;
            int tileHeight = firstMatrix.TileHeight;

            // Verify standard tile dimensions
            Assert.That(tileWidth, Is.EqualTo(256), "Standard tile width should be 256");
            Assert.That(tileHeight, Is.EqualTo(256), "Standard tile height should be 256");

            TestContext.WriteLine($"First matrix ID: {firstMatrix.Id}");
            TestContext.WriteLine($"Tile dimensions: {tileWidth}x{tileHeight}");
            TestContext.WriteLine($"Scale denominator: {firstMatrix.ScaleDenominator}");        }

        /// <summary>
        /// Tests listing all available tile matrix set IDs.
        /// Maps to Python test: test_02_list_tile_matrices
        /// </summary>
        [Test]
        [Category("TileMatrices")]
        public async Task Test06_02_ListTileMatrices()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();

            TestContext.WriteLine("Testing ListTileMatrices to get all available tile matrix set IDs");

            // Act
            Response<IReadOnlyList<string>> response = await dataClient.GetTileMatricesAsync();

            // Assert
            Assert.That(response, Is.Not.Null, "Response should not be null");
            Assert.That(response.Value, Is.Not.Null, "Response value should not be null");
            IReadOnlyList<string> tileMatrixIds = response.Value;

            TestContext.WriteLine($"Number of tile matrices: {tileMatrixIds.Count}");

            // Check for expected tile matrix sets
            Assert.That(tileMatrixIds, Does.Contain("WebMercatorQuad"), "Should include WebMercatorQuad");
            Assert.That(tileMatrixIds, Does.Contain("WorldCRS84Quad"), "Should include WorldCRS84Quad");

            TestContext.WriteLine($"Found tile matrices: {string.Join(", ", tileMatrixIds)}");
        }

        /// <summary>
        /// Tests listing available assets for a STAC item.
        /// Maps to Python test: test_03_list_available_assets
        /// </summary>
        [Test]
        [Category("Assets")]
        public async Task Test06_03_GetItemAssetDetails()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act
            Response<IReadOnlyList<string>> response = await dataClient.GetAvailableAssetsAsync(
                collectionId: collectionId,
                itemId: itemId
            );

            // Assert
            ValidateResponse(response, "GetAvailableAssets");

            IReadOnlyList<string> assets = response.Value;
            Assert.IsNotNull(assets, "Assets list should not be null");
            Assert.Greater(assets.Count, 0, "Should have at least one asset");

            TestContext.WriteLine($"Number of assets: {assets.Count}");
            TestContext.WriteLine($"Available assets: {string.Join(", ", assets.Take(10))}");

            // All items should be asset names (strings)
            foreach (var asset in assets)
            {
                Assert.IsNotNull(asset, "Asset name should not be null");
                Assert.IsNotEmpty(asset, "Asset name should not be empty");
            }
        }

        /// <summary>
        /// Tests getting bounds (bounding box) for a STAC item.
        /// Maps to Python test: test_04_get_bounds
        /// </summary>
        [Test]
        [Category("Bounds")]
        public async Task Test06_04_GetBounds()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act
            Response<StacItemBounds> response = await dataClient.GetBoundsAsync(
                collectionId: collectionId,
                itemId: itemId
            );

            // Assert
            ValidateResponse(response, "GetBounds");

            StacItemBounds boundsResult = response.Value;
            Assert.IsNotNull(boundsResult, "Bounds result should not be null");
            Assert.IsNotNull(boundsResult.Bounds, "Bounds array should not be null");
            Assert.AreEqual(4, boundsResult.Bounds.Count, "Bounds should have 4 coordinates [minx, miny, maxx, maxy]");

            var bounds = boundsResult.Bounds;
            float minx = bounds[0];
            float miny = bounds[1];
            float maxx = bounds[2];
            float maxy = bounds[3];

            TestContext.WriteLine($"Bounds: [{minx}, {miny}, {maxx}, {maxy}]");

            // Validate bounds logic
            Assert.Less(minx, maxx, "minx should be less than maxx");
            Assert.Less(miny, maxy, "miny should be less than maxy");
        }

        /// <summary>
        /// Tests getting a preview image of a STAC item.
        /// Maps to Python test: test_05_get_preview
        /// </summary>
        [Test]
        [Category("Preview")]
        public async Task Test06_05_GetPreview()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");
            TestContext.WriteLine("Input - dimensions: 512x512");

            // Act
            Response<BinaryData> response = await dataClient.GetPreviewAsync(
                collectionId: collectionId,
                itemId: itemId,
                format: TilerImageFormat.Png,
                width: 512,
                height: 512,
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3"
            );

            // Assert
            ValidateResponse(response, "GetPreview");

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
        /// Tests getting info/metadata for a STAC item as GeoJSON.
        /// Maps to Python test: test_06_get_info_geo_json
        /// </summary>
        [Test]
        [Category("Info")]
        public async Task Test06_06_GetInfoGeoJson()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act
            Response<TilerInfoGeoJsonFeature> response = await dataClient.GetInfoGeoJsonAsync(
                collectionId: collectionId,
                itemId: itemId,
                assets: new[] { "image" }
            );

            // Assert
            ValidateResponse(response, "GetInfoGeoJson");

            TilerInfoGeoJsonFeature data = response.Value;
            Assert.IsNotNull(data, "Response data should not be null");

            TestContext.WriteLine("Info GeoJSON retrieved successfully");
        }

        /// <summary>
        /// Tests listing statistics for a STAC item's assets.
        /// Maps to Python test: test_07_list_statistics
        /// </summary>
        [Test]
        [Category("Statistics")]
        public async Task Test06_07_ListStatistics()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act
            Response<TilerStacItemStatistics> response = await dataClient.GetStatisticsAsync(
                collectionId: collectionId,
                itemId: itemId,
                assets: new[] { "image" }
            );

            // Assert
            ValidateResponse(response, "GetStatistics");

            TilerStacItemStatistics statistics = response.Value;
            Assert.IsNotNull(statistics, "Statistics should not be null");

            TestContext.WriteLine("Statistics retrieved successfully");
        }

        /// <summary>
        /// Tests getting WMTS capabilities XML for a STAC item.
        /// Maps to Python test: test_08_get_wmts_capabilities
        /// </summary>
        [Test]
        [Category("WMTS")]
        public async Task Test06_08_GetWmtsCapabilities()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act
            Response<BinaryData> response = await dataClient.GetWmtsCapabilitiesAsync(
                collectionId: collectionId,
                itemId: itemId,
                tileMatrixSetId: "WebMercatorQuad",
                tileFormat: TilerImageFormat.Png,
                tileScale: 1,
                minZoom: 7,
                maxZoom: 14,
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3"
            );

            // Assert
            ValidateResponse(response, "GetWmtsCapabilities");

            BinaryData xmlData = response.Value;
            byte[] xmlBytes = xmlData.ToArray();
            string xmlString = System.Text.Encoding.UTF8.GetString(xmlBytes);

            TestContext.WriteLine($"XML size: {xmlBytes.Length} bytes");
            TestContext.WriteLine($"XML first 200 chars: {xmlString.Substring(0, System.Math.Min(200, xmlString.Length))}");

            // Validate XML structure
            Assert.Greater(xmlBytes.Length, 0, "XML bytes should not be empty");
            Assert.That(xmlString, Does.Contain("Capabilities"), "Response should contain Capabilities element");
            Assert.That(xmlString.ToLower(), Does.Contain("wmts"), "Response should reference WMTS");
            Assert.That(xmlString, Does.Contain("TileMatrix"), "Response should contain TileMatrix information");

            TestContext.WriteLine("WMTS capabilities XML validated successfully");
        }

        /// <summary>
        /// Tests getting asset statistics for a STAC item.
        /// Maps to Python test: test_09_get_asset_statistics
        /// </summary>
        [Test]
        [Category("Statistics")]
        public async Task Test06_09_GetAssetStatistics()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act
            Response<IReadOnlyDictionary<string, BinaryData>> response = await dataClient.GetAssetStatisticsAsync(
                collectionId: collectionId,
                itemId: itemId,
                assets: new[] { "image" }
            );

            // Assert
            ValidateResponse(response, "GetAssetStatistics");

            IReadOnlyDictionary<string, BinaryData> assetStatistics = response.Value;
            Assert.IsNotNull(assetStatistics, "Asset statistics should not be null");
            Assert.Greater(assetStatistics.Count, 0, "Should have statistics for at least one asset");

            TestContext.WriteLine($"Number of assets with statistics: {assetStatistics.Count}");

            // Verify structure: each asset should contain band statistics
            foreach (var assetEntry in assetStatistics)
            {
                string assetName = assetEntry.Key;
                BinaryData statisticsData = assetEntry.Value;

                TestContext.WriteLine($"\nAsset: {assetName}");
                Assert.IsNotNull(statisticsData, $"Statistics data for asset '{assetName}' should not be null");

                // Parse the statistics to verify structure
                using JsonDocument doc = JsonDocument.Parse(statisticsData);
                JsonElement root = doc.RootElement;

                TestContext.WriteLine($"  Statistics structure: {root.ValueKind}");

                if (root.ValueKind == JsonValueKind.Object)
                {
                    // Should contain band names (e.g., "b1", "b2", etc.)
                    int bandCount = 0;
                    foreach (var bandProperty in root.EnumerateObject())
                    {
                        bandCount++;
                        string bandName = bandProperty.Name;
                        JsonElement bandStats = bandProperty.Value;

                        TestContext.WriteLine($"  Band: {bandName}");

                        // Verify band statistics have expected properties
                        if (bandStats.TryGetProperty("min", out _))
                        {
                            TestContext.WriteLine($"    Has 'min' property");
                        }
                        if (bandStats.TryGetProperty("max", out _))
                        {
                            TestContext.WriteLine($"    Has 'max' property");
                        }
                        if (bandStats.TryGetProperty("mean", out _))
                        {
                            TestContext.WriteLine($"    Has 'mean' property");
                        }
                    }

                    Assert.Greater(bandCount, 0, $"Asset '{assetName}' should have at least one band with statistics");
                }
            }

            TestContext.WriteLine("\nAsset statistics retrieved and validated successfully");
        }

        /// <summary>
        /// Tests cropping an image by GeoJSON geometry.
        /// Maps to Python test: test_10_crop_geo_json
        /// </summary>
        [Test]
        [Category("Crop")]
        public async Task Test06_10_CropGeoJson()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            // Create GeoJSON Feature with Polygon geometry
            var coordinates = new List<IList<IList<float>>>
            {
                new List<IList<float>>
                {
                    new List<float> { -84.3906f, 33.6714f },  // bottom-left
                    new List<float> { -84.3814f, 33.6714f },  // bottom-right
                    new List<float> { -84.3814f, 33.6806f },  // top-right
                    new List<float> { -84.3906f, 33.6806f },  // top-left
                    new List<float> { -84.3906f, 33.6714f }   // close the ring
                }
            };
            var geometry = new PolygonGeometry(coordinates);
            var feature = new GeoJsonFeature(geometry, FeatureType.Feature);

            // API requires properties field to be present (even if empty)
            feature.Properties.Add("description", BinaryData.FromString("\"Test crop area\""));

            TestContext.WriteLine("Geometry defined for cropping");

            // Act
            Response<BinaryData> response = await dataClient.CropGeoJsonAsync(
                collectionId: collectionId,
                itemId: itemId,
                format: "png",
                body: feature,
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3"
            );

            // Assert
            ValidateResponse(response, "CropGeoJson");

            BinaryData imageData = response.Value;
            byte[] imageBytes = imageData.ToArray();

            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            Assert.Greater(imageBytes.Length, 0, "Image bytes should not be empty");

            for (int i = 0; i < pngMagic.Length; i++)
            {
                Assert.AreEqual(pngMagic[i], imageBytes[i], $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("PNG format verified successfully");
        }

        /// <summary>
        /// Tests cropping an image by GeoJSON with custom dimensions.
        /// Maps to Python test: test_11_crop_geo_json_with_dimensions
        /// </summary>
        [Test]
        [Category("Crop")]
        public async Task Test06_11_CropGeoJsonWithDimensions()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            // Create GeoJSON Feature with Polygon geometry
            var coordinates = new List<IList<IList<float>>>
            {
                new List<IList<float>>
                {
                    new List<float> { -84.3906f, 33.6714f },
                    new List<float> { -84.3814f, 33.6714f },
                    new List<float> { -84.3814f, 33.6806f },
                    new List<float> { -84.3906f, 33.6806f },
                    new List<float> { -84.3906f, 33.6714f }
                }
            };
            var geometry = new PolygonGeometry(coordinates);
            var feature = new GeoJsonFeature(geometry, FeatureType.Feature);

            // API requires properties field to be present (even if empty)
            feature.Properties.Add("description", BinaryData.FromString("\"Test crop area with dimensions\""));

            TestContext.WriteLine("Input - dimensions: 256x256");

            // Act
            Response<BinaryData> response = await dataClient.CropGeoJsonWithDimensionsAsync(
                collectionId: collectionId,
                itemId: itemId,
                width: 256,
                height: 256,
                format: "png",
                body: feature,
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3"
            );

            // Assert
            ValidateResponse(response, "CropGeoJsonWithDimensions");

            BinaryData imageData = response.Value;
            byte[] imageBytes = imageData.ToArray();

            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            Assert.Greater(imageBytes.Length, 0, "Image bytes should not be empty");

            for (int i = 0; i < pngMagic.Length; i++)
            {
                Assert.AreEqual(pngMagic[i], imageBytes[i], $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("PNG format verified successfully");
        }

        /// <summary>
        /// Tests getting statistics for a GeoJSON area.
        /// Maps to Python test: test_12_get_geo_json_statistics
        /// </summary>
        [Test]
        [Category("Statistics")]
        public async Task Test06_12_GetGeoJsonStatistics()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            // Create GeoJSON Feature with Polygon geometry
            var coordinates = new List<IList<IList<float>>>
            {
                new List<IList<float>>
                {
                    new List<float> { -84.3906f, 33.6714f },
                    new List<float> { -84.3814f, 33.6714f },
                    new List<float> { -84.3814f, 33.6806f },
                    new List<float> { -84.3906f, 33.6806f },
                    new List<float> { -84.3906f, 33.6714f }
                }
            };
            var geometry = new PolygonGeometry(coordinates);
            var feature = new GeoJsonFeature(geometry, FeatureType.Feature);

            // API requires properties field to be present (even if empty)
            feature.Properties.Add("description", BinaryData.FromString("\"Test statistics area\""));

            TestContext.WriteLine("Geometry defined for statistics");

            // Act
            Response<StacItemStatisticsGeoJson> response = await dataClient.GetGeoJsonStatisticsAsync(
                collectionId: collectionId,
                itemId: itemId,
                body: feature,
                assets: new[] { "image" }
            );

            // Assert
            ValidateResponse(response, "GetGeoJsonStatistics");

            StacItemStatisticsGeoJson data = response.Value;
            Assert.IsNotNull(data, "Response data should not be null");

            TestContext.WriteLine("GeoJSON statistics retrieved successfully");
        }

        /// <summary>
        /// Tests getting a part of an image by bounding box.
        /// Maps to Python test: test_13_get_part
        /// </summary>
        [Test]
        [Category("Part")]
        public async Task Test06_13_GetPart()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            float minx = -84.3930f;
            float miny = 33.6798f;
            float maxx = -84.3670f;
            float maxy = 33.7058f;

            TestContext.WriteLine($"Input - bounds: [{minx}, {miny}, {maxx}, {maxy}]");

            // Act
            Response<BinaryData> response = await dataClient.GetPartAsync(
                collectionId: collectionId,
                itemId: itemId,
                minx: minx,
                miny: miny,
                maxx: maxx,
                maxy: maxy,
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3",
                format: "png"
            );

            // Assert
            ValidateResponse(response, "GetPart");

            BinaryData imageData = response.Value;
            byte[] imageBytes = imageData.ToArray();

            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            Assert.Greater(imageBytes.Length, 0, "Image bytes should not be empty");

            for (int i = 0; i < pngMagic.Length; i++)
            {
                Assert.AreEqual(pngMagic[i], imageBytes[i], $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("PNG format verified successfully");
        }

        /// <summary>
        /// Tests getting a part of an image with custom dimensions.
        /// Maps to Python test: test_14_get_part_with_dimensions
        /// </summary>
        [Test]
        [Category("Part")]
        public async Task Test06_14_GetPartWithDimensions()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            float minx = -84.3930f;
            float miny = 33.6798f;
            float maxx = -84.3670f;
            float maxy = 33.7058f;

            TestContext.WriteLine($"Input - bounds: [{minx}, {miny}, {maxx}, {maxy}]");
            TestContext.WriteLine("Input - dimensions: 256x256");

            // Act
            Response<BinaryData> response = await dataClient.GetPartWithDimensionsAsync(
                collectionId: collectionId,
                itemId: itemId,
                minx: minx,
                miny: miny,
                maxx: maxx,
                maxy: maxy,
                width: 256,
                height: 256,
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3",
                format: "png"
            );

            // Assert
            ValidateResponse(response, "GetPartWithDimensions");

            BinaryData imageData = response.Value;
            byte[] imageBytes = imageData.ToArray();

            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            Assert.Greater(imageBytes.Length, 0, "Image bytes should not be empty");

            for (int i = 0; i < pngMagic.Length; i++)
            {
                Assert.AreEqual(pngMagic[i], imageBytes[i], $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("PNG format verified successfully");
        }

        /// <summary>
        /// Tests getting data for a specific point.
        /// Maps to Python test: test_15_get_point
        /// </summary>
        [Test]
        [Category("Point")]
        public async Task Test06_15_GetPoint()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            float longitude = -84.3860f;
            float latitude = 33.6760f;

            TestContext.WriteLine($"Input - point: longitude={longitude}, latitude={latitude}");

            // Act
            Response<TilerCoreModelsResponsesPoint> response = await dataClient.GetPointAsync(
                collectionId: collectionId,
                itemId: itemId,
                longitude: longitude,
                latitude: latitude,
                assets: new[] { "image" }
            );

            // Assert
            ValidateResponse(response, "GetPoint");

            TilerCoreModelsResponsesPoint data = response.Value;
            Assert.IsNotNull(data, "Response data should not be null");

            TestContext.WriteLine("Point data retrieved successfully");
        }

        /// <summary>
        /// Tests getting a preview with specific format (JPEG).
        /// Maps to Python test: test_16_get_preview_with_format
        /// </summary>
        [Test]
        [Category("Preview")]
        public async Task Test06_16_GetPreviewWithFormat()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");
            TestContext.WriteLine("Input - format: JPEG");

            // Act
            Response<BinaryData> response = await dataClient.GetPreviewWithFormatAsync(
                collectionId: collectionId,
                itemId: itemId,
                format: "jpeg",
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3"
            );

            // Assert
            ValidateResponse(response, "GetPreviewWithFormat");

            BinaryData imageData = response.Value;
            byte[] imageBytes = imageData.ToArray();

            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");
            TestContext.WriteLine($"First 16 bytes (hex): {BitConverter.ToString(imageBytes.Take(16).ToArray()).Replace("-", "")}");

            // Verify JPEG magic bytes
            byte[] jpegMagic = new byte[] { 0xFF, 0xD8, 0xFF };
            Assert.Greater(imageBytes.Length, 0, "Image bytes should not be empty");

            for (int i = 0; i < jpegMagic.Length; i++)
            {
                Assert.AreEqual(jpegMagic[i], imageBytes[i], $"JPEG magic byte {i} mismatch");
            }

            TestContext.WriteLine("JPEG magic bytes verified successfully");
        }

        /// <summary>
        /// Tests getting TileJSON metadata.
        /// Maps to Python test: test_17_get_tile_json
        /// </summary>
        [Test]
        [Category("TileJson")]
        public async Task Test06_17_GetTileJson()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act
            Response<TileJsonMetadata> response = await dataClient.GetTileJsonAsync(
                collectionId: collectionId,
                itemId: itemId,
                tileMatrixSetId: "WebMercatorQuad",
                tileFormat: TilerImageFormat.Png,
                tileScale: 1,
                minZoom: 7,
                maxZoom: 14,
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3"
            );

            // Assert
            ValidateResponse(response, "GetTileJson");

            TileJsonMetadata tileJson = response.Value;
            Assert.IsNotNull(tileJson, "TileJSON should not be null");
            Assert.IsNotNull(tileJson.TileJson, "TileJSON version should not be null");
            Assert.IsNotNull(tileJson.Tiles, "Tiles array should not be null");
            Assert.Greater(tileJson.Tiles.Count, 0, "Should have at least one tile URL pattern");

            TestContext.WriteLine($"TileJSON version: {tileJson.TileJson}");
            TestContext.WriteLine($"Number of tile URL patterns: {tileJson.Tiles.Count}");
        }

        /// <summary>
        /// Tests getting a specific tile.
        /// Maps to Python test: test_18_get_tile
        /// </summary>
        [Test]
        [Category("Tile")]
        public async Task Test06_18_GetTile()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");
            TestContext.WriteLine("Input - tile coordinates: z=14, x=4349, y=6564");

            // Act
            Response<BinaryData> response = await dataClient.GetTileAsync(
                collectionId: collectionId,
                itemId: itemId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 14,
                x: 4349,
                y: 6564,
                scale: 1,
                format: "png",
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3"
            );

            // Assert
            ValidateResponse(response, "GetTile");

            BinaryData imageData = response.Value;
            byte[] imageBytes = imageData.ToArray();

            TestContext.WriteLine($"Tile size: {imageBytes.Length} bytes");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            Assert.Greater(imageBytes.Length, 0, "Image bytes should not be empty");

            for (int i = 0; i < pngMagic.Length; i++)
            {
                Assert.AreEqual(pngMagic[i], imageBytes[i], $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("PNG format verified successfully");
        }

        /// <summary>
        /// Tests listing available assets for a STAC item (legacy test from original file).
        /// Maps to Python test: test_03_list_available_assets
        /// Note: This test is the same as Test06_03.
        /// Keeping it for backwards compatibility.
        /// </summary>
        [Test]
        [Category("Assets")]
        public async Task Test06_19_ListAvailableAssets()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act
            TestContext.WriteLine("\n=== Making Request ===");
            TestContext.WriteLine($"GET /data/collections/{collectionId}/items/{itemId}/assets");

            Response<IReadOnlyList<string>> response = await dataClient.GetAvailableAssetsAsync(collectionId, itemId);

            // Log raw response
            TestContext.WriteLine("\n=== Raw Response ===");
            TestContext.WriteLine($"Status: {response.GetRawResponse().Status} {response.GetRawResponse().ReasonPhrase}");
            TestContext.WriteLine($"Content-Type: {response.GetRawResponse().Headers.ContentType}");
            TestContext.WriteLine("\n=== Response Body ===");
            string responseBody = response.GetRawResponse().Content.ToString();
            TestContext.WriteLine(responseBody);

            // Assert
            Assert.That(response, Is.Not.Null, "Response should not be null");
            Assert.That(response.Value, Is.Not.Null, "Response value should not be null");
            IReadOnlyList<string> assets = response.Value;

            TestContext.WriteLine($"\n=== Parsed Assets ===");
            TestContext.WriteLine($"Number of assets: {assets.Count}");

            // All items should be asset names (strings)
            TestContext.WriteLine($"Available assets: {string.Join(", ", assets.Take(10))}");
            if (assets.Count > 10)
            {
                TestContext.WriteLine($"... and {assets.Count - 10} more");
            }

            // Validate asset names
            foreach (var asset in assets)
            {
                Assert.IsNotNull(asset, "Asset name should not be null");
                Assert.IsNotEmpty(asset, "Asset name should not be empty");
            }
        }
    }
}
