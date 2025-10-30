// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// Tests for STAC Item Tiler operations using TilerClient.
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
            var tilerClient = client.GetTilerClient();
            string tileMatrixSetId = "WebMercatorQuad";

            TestContext.WriteLine($"Input - tile_matrix_set_id: {tileMatrixSetId}");

            // Act
            Response<TileMatrixSet> response = await tilerClient.GetTileMatrixDefinitionsAsync(tileMatrixSetId);

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
            var tilerClient = client.GetTilerClient();

            TestContext.WriteLine("Testing ListTileMatrices to get all available tile matrix set IDs");

            // Act
            Response<IReadOnlyList<string>> response = await tilerClient.GetTileMatricesAsync();

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
        public async Task Test06_03_ListAvailableAssets()
        {
            // Arrange
            var client = GetTestClient();
            var tilerClient = client.GetTilerClient();
            string collectionId = TestEnvironment.CollectionId;
            string itemId = TestEnvironment.ItemId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");
            TestContext.WriteLine($"Input - item_id: {itemId}");

            // Act - use protocol method to see raw request/response
            TestContext.WriteLine("\n=== Making Request ===");
            TestContext.WriteLine($"GET /stac/collections/{collectionId}/items/{itemId}/tilejson/assets");

            Response<IReadOnlyDictionary<string, TilerInfo>> response = await tilerClient.GetItemAssetDetailsAsync(collectionId, itemId);

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
            IReadOnlyDictionary<string, TilerInfo> assets = response.Value;

            TestContext.WriteLine($"\n=== Parsed Assets ===");
            TestContext.WriteLine($"Number of assets: {assets.Count}");

            // All items should be asset names (dictionary keys)
            var assetNames = assets.Keys.ToList();

            TestContext.WriteLine($"Available assets: {string.Join(", ", assetNames.Take(10))}");
            if (assetNames.Count > 10)
            {
                TestContext.WriteLine($"... and {assetNames.Count - 10} more");
            }

            // Log detailed info about first asset to help debug
            if (assets.Count > 0)
            {
                var firstAsset = assets.First();
                TestContext.WriteLine($"\n=== First Asset Details ===");
                TestContext.WriteLine($"Asset Name: {firstAsset.Key}");
                TestContext.WriteLine($"TilerInfo: {firstAsset.Value}");
            }
        }
    }
}
