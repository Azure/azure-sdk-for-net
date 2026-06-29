// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for Collection-scoped Tiler operations using DataClient.
    /// Tests are mapped from Python tests in test_planetary_computer_08_collection_tiler.py.
    /// These endpoints were added in the GA (2026-04-15) API version.
    /// </summary>
    [Category("Tiler")]
    [Category("CollectionTiler")]
    public class TestPlanetaryComputer09CollectionTilerTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer09CollectionTilerTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Tests getting collection tiler info.
        /// Maps to Python test: test_01_get_collection_info
        /// </summary>
        [Test]
        [Category("CollectionInfo")]
        public async Task Test09_01_GetCollectionInfo()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionInfo for collection: {collectionId}");

            // Act - use protocol method to avoid deserialization bug in generated MosaicMetadata model
            Response response = await dataClient.GetCollectionInfoAsync(collectionId, new RequestContext());

            // Assert
            ValidateResponse(response, "GetCollectionInfo");
            Assert.That(response.Content, Is.Not.Null, "Response content should not be null");
            Assert.That(response.Content.ToString().Length, Is.GreaterThan(0), "Response should have content");

            TestContext.WriteLine("GetCollectionInfo succeeded");
        }

        /// <summary>
        /// Tests getting collection point data at a specific location.
        /// Maps to Python test: test_02_get_collection_point
        /// </summary>
        [Test]
        [Category("CollectionPoint")]
        public async Task Test09_02_GetCollectionPoint()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            float longitude = -84.3860f;
            float latitude = 33.6760f;

            TestContext.WriteLine($"Testing GetCollectionPoint for collection: {collectionId}");
            TestContext.WriteLine($"Coordinates: ({longitude}, {latitude})");

            // Act - use protocol method to avoid deserialization bug in generated TilerCoreModelsResponsesPoint model
            // assets or expression is required for point queries
            Response response = await dataClient.GetCollectionPointAsync(
                collectionId: collectionId,
                longitude: longitude,
                latitude: latitude,
                scanLimit: null,
                itemsLimit: null,
                timeLimit: null,
                exitWhenFull: null,
                skipCovered: null,
                ids: null,
                bbox: null,
                query: null,
                sortby: null,
                datetime: null,
                subdatasetName: null,
                subdatasetBands: null,
                crs: null,
                sel: null,
                selMethod: null,
                bidx: null,
                assets: new[] { "image" },
                expression: null,
                assetBandIndices: null,
                assetAsBand: null,
                noData: null,
                unscale: null,
                reproject: null,
                coordinateReferenceSystem: null,
                resampling: null,
                context: new RequestContext()
            );

            // Assert
            ValidateResponse(response, "GetCollectionPoint");
            Assert.That(response.Content, Is.Not.Null, "Response content should not be null");
            Assert.That(response.Content.ToString().Length, Is.GreaterThan(0), "Response should have content");

            TestContext.WriteLine("GetCollectionPoint succeeded");
        }

        /// <summary>
        /// Tests getting collection point assets at a specific location.
        /// Maps to Python test: test_03_get_collection_point_assets
        /// </summary>
        [Test]
        [Category("CollectionPointAssets")]
        public async Task Test09_03_GetCollectionPointAssets()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            float longitude = -84.3860f;
            float latitude = 33.6760f;

            TestContext.WriteLine($"Testing GetCollectionPointAssets for collection: {collectionId}");
            TestContext.WriteLine($"Coordinates: ({longitude}, {latitude})");

            // Act
            Response<IReadOnlyList<StacItemPointAsset>> response = await dataClient.GetCollectionPointAssetsAsync(
                collectionId: collectionId,
                longitude: longitude,
                latitude: latitude
            );

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollectionPointAssets");
            Assert.That(response.Value, Is.Not.Null, "Response value should not be null");

            TestContext.WriteLine($"Found {response.Value.Count} point assets");
        }

        /// <summary>
        /// Tests getting a collection tile.
        /// Maps to Python test: test_04_get_collection_tile
        /// </summary>
        [Test]
        [Category("CollectionTile")]
        public async Task Test09_04_GetCollectionTileByScaleAndFormat()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionTileByScaleAndFormat for collection: {collectionId}");

            // Act
            Response<BinaryData> response = await dataClient.GetCollectionTileByScaleAndFormatAsync(
                collectionId: collectionId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 14,
                x: 4349,
                y: 6564,
                scale: 1,
                format: "png",
                assets: new[] { "image" },
                assetBandIndices: new[] { "image|1,2,3" }
            );

            // Assert
            ValidateResponse(response, "GetCollectionTileByScaleAndFormat");

            byte[] imageBytes = response.Value.ToArray();
            TestContext.WriteLine($"Tile size: {imageBytes.Length} bytes");

            Assert.That(imageBytes.Length, Is.GreaterThanOrEqualTo(8), "Tile bytes should be at least 8 bytes to contain a PNG header");

            // Verify PNG magic bytes
            byte[] pngMagic = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            for (int i = 0; i < pngMagic.Length; i++)
            {
                Assert.That(imageBytes[i], Is.EqualTo(pngMagic[i]), $"PNG magic byte {i} mismatch");
            }

            TestContext.WriteLine("GetCollectionTileByScaleAndFormat succeeded - valid PNG");
        }

        /// <summary>
        /// Tests getting collection TileJSON metadata.
        /// Maps to Python test: test_05_get_collection_tile_json
        /// </summary>
        [Test]
        [Category("CollectionTileJson")]
        public async Task Test09_05_GetCollectionTileJson()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionTileJson for collection: {collectionId}");

            // Act
            Response<TileJsonMetadata> response = await dataClient.GetCollectionTileJsonAsync(
                collectionId: collectionId,
                assets: new[] { "image" },
                assetBandIndices: new[] { "image|1,2,3" }
            );

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollectionTileJson");
            Assert.That(response.Value, Is.Not.Null, "TileJSON response should not be null");

            TestContext.WriteLine("GetCollectionTileJson succeeded");
        }

        /// <summary>
        /// Tests getting a bbox crop from a collection.
        /// Maps to Python test: test_06_get_collection_bbox_crop
        /// </summary>
        [Test]
        [Category("CollectionBboxCrop")]
        public async Task Test09_06_GetCollectionBboxCrop()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            float minx = -84.3900f;
            float miny = 33.6800f;
            float maxx = -84.3850f;
            float maxy = 33.6850f;

            TestContext.WriteLine($"Testing GetCollectionBboxCrop for collection: {collectionId}");
            TestContext.WriteLine($"Bbox: [{minx}, {miny}, {maxx}, {maxy}]");

            // Act
            Response<BinaryData> response = await dataClient.GetCollectionBboxCropAsync(
                collectionId: collectionId,
                minx: minx,
                miny: miny,
                maxx: maxx,
                maxy: maxy,
                format: "png",
                assets: new[] { "image" },
                assetBandIndices: new[] { "image|1,2,3" }
            );

            // Assert
            ValidateResponse(response, "GetCollectionBboxCrop");

            byte[] imageBytes = response.Value.ToArray();
            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");

            Assert.That(imageBytes.Length, Is.GreaterThan(0), "Image bytes should not be empty");

            TestContext.WriteLine("GetCollectionBboxCrop succeeded");
        }

        /// <summary>
        /// Tests getting WMTS capabilities for a collection.
        /// Maps to Python test: test_07_get_collection_wmts_capabilities
        /// </summary>
        [Test]
        [Category("CollectionWmts")]
        public async Task Test09_07_GetCollectionWmtsCapabilities()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionWmtsCapabilities for collection: {collectionId}");

            // Act
            Response<BinaryData> response = await dataClient.GetCollectionWmtsCapabilitiesAsync(
                collectionId: collectionId,
                assets: new[] { "image" }
            );

            // Assert
            ValidateResponse(response, "GetCollectionWmtsCapabilities");

            byte[] xmlBytes = response.Value.ToArray();
            string xmlString = Encoding.UTF8.GetString(xmlBytes);

            TestContext.WriteLine($"WMTS XML size: {xmlBytes.Length} bytes");

            Assert.That(xmlBytes.Length, Is.GreaterThan(0), "XML bytes should not be empty");
            Assert.That(xmlString, Does.Contain("Capabilities"), "Response should contain Capabilities element");

            TestContext.WriteLine("GetCollectionWmtsCapabilities succeeded");
        }

        /// <summary>
        /// Tests cropping a collection by GeoJSON feature.
        /// Maps to Python test: test_08_crop_collection_feature
        /// </summary>
        [Test]
        [Category("CollectionCrop")]
        public async Task Test09_08_CropCollectionFeature()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing CropCollectionFeature for collection: {collectionId}");

            // Build GeoJSON Feature as raw JSON to ensure "properties": {} is included
            // (the generated GeoJsonFeature model skips empty properties during serialization)
            string geoJsonBody = @"{
                ""type"": ""Feature"",
                ""geometry"": {
                    ""type"": ""Polygon"",
                    ""coordinates"": [[[-84.3930, 33.6798], [-84.3670, 33.6798], [-84.3670, 33.7058], [-84.3930, 33.7058], [-84.3930, 33.6798]]]
                },
                ""properties"": {}
            }";

            // Act - use protocol method with raw JSON body
            Response response = await dataClient.CropCollectionFeatureAsync(
                collectionId: collectionId,
                content: RequestContent.Create(BinaryData.FromString(geoJsonBody)),
                bidx: null,
                assets: new[] { "image" },
                expression: null,
                assetBandIndices: new[] { "image|1,2,3" },
                assetAsBand: null,
                noData: null,
                unscale: null,
                reproject: null,
                scanLimit: null,
                itemsLimit: null,
                timeLimit: null,
                exitWhenFull: null,
                skipCovered: null,
                ids: null,
                bbox: null,
                query: null,
                sortby: null,
                datetime: null,
                subdatasetName: null,
                subdatasetBands: null,
                crs: null,
                sel: null,
                selMethod: null,
                algorithm: null,
                algorithmParams: null,
                coordinateReferenceSystem: null,
                maxSize: null,
                height: null,
                width: null,
                colorFormula: null,
                collection: null,
                resampling: null,
                pixelSelection: null,
                rescale: null,
                colorMapName: null,
                colorMap: null,
                returnMask: null,
                destinationCrs: null,
                format: null,
                context: new RequestContext()
            );

            // Assert
            ValidateResponse(response, "CropCollectionFeature");

            byte[] imageBytes = response.Content.ToArray();
            TestContext.WriteLine($"Image size: {imageBytes.Length} bytes");

            Assert.That(imageBytes.Length, Is.GreaterThan(0), "Image bytes should not be empty");

            TestContext.WriteLine("CropCollectionFeature succeeded");
        }

        /// <summary>
        /// Tests listing tilesets for a collection.
        /// Maps to Python test: test_09_get_collection_tilesets
        /// </summary>
        [Test]
        [Category("CollectionTilesets")]
        public async Task Test09_09_GetCollectionTilesets()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionTilesets for collection: {collectionId}");

            // Act
            Response<TileSetList> response = await dataClient.GetCollectionTilesetsAsync(
                collectionId: collectionId
            );

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollectionTilesets");
            Assert.That(response.Value, Is.Not.Null, "TileSetList response should not be null");

            TestContext.WriteLine("GetCollectionTilesets succeeded");
        }

        /// <summary>
        /// Tests getting collection assets for a specific tile.
        /// Maps to Python test: test_10_get_collection_assets_for_tile
        /// </summary>
        [Test]
        [Category("CollectionAssetsForTile")]
        public async Task Test09_10_GetCollectionAssetsForTile()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionAssetsForTile for collection: {collectionId}");

            // Act
            Response<IReadOnlyList<TilerAssetGeoJson>> response = await dataClient.GetCollectionAssetsForTileAsync(
                collectionId: collectionId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 13,
                x: 2174,
                y: 3282
            );

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollectionAssetsForTile");
            Assert.That(response.Value, Is.Not.Null, "Response value should not be null");

            TestContext.WriteLine($"Found {response.Value.Count} assets for tile");
            TestContext.WriteLine("GetCollectionAssetsForTile succeeded");
        }

        /// <summary>
        /// Tests getting collection tileset metadata.
        /// Maps to Python test: test_11_get_collection_tileset_metadata
        /// </summary>
        [Test]
        [Category("CollectionTilesetMetadata")]
        public async Task Test09_11_GetCollectionTilesetMetadata()
        {
            // Arrange
            var client = GetTestClient();
            var dataClient = client.GetDataClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionTilesetMetadata for collection: {collectionId}");

            // Act
            Response<TileSetMetadata> response = await dataClient.GetCollectionTilesetMetadataAsync(
                collectionId: collectionId,
                tileMatrixSetId: "WebMercatorQuad"
            );

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollectionTilesetMetadata");
            Assert.That(response.Value, Is.Not.Null, "TileSetMetadata response should not be null");

            TestContext.WriteLine("GetCollectionTilesetMetadata succeeded");
        }
    }
}
