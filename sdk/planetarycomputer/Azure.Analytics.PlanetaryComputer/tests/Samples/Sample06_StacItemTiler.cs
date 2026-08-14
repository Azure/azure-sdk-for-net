// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests.Samples
{
    /// <summary>
    /// Samples demonstrating how to work with the STAC Item Tiler API for creating map tiles,
    /// previews, and extracting data from individual STAC items.
    /// </summary>
    public partial class Sample06_StacItemTiler : PlanetaryComputerTestBase
    {
        public Sample06_StacItemTiler(bool isAsync) : base(isAsync) { }
        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetTileMatrixDefinitions()
        {
            #region Snippet:Sample06_GetTileMatrixDefinitions
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            // Get tile matrix definitions for WebMercatorQuad
            Response<TileMatrixSet> response = await dataClient.GetTileMatrixDefinitionsAsync("WebMercatorQuad");
            TileMatrixSet tileMatrixSet = response.Value;

            Console.WriteLine($"Tile Matrix Set: {tileMatrixSet.Id}");
            Console.WriteLine($"Number of matrices: {tileMatrixSet.TileMatrices.Count}");

            // Show first matrix details
            var firstMatrix = tileMatrixSet.TileMatrices[0];
            Console.WriteLine($"First matrix ID: {firstMatrix.Id}");
            Console.WriteLine($"Tile dimensions: {firstMatrix.TileWidth}x{firstMatrix.TileHeight}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListTileMatrices()
        {
            #region Snippet:Sample06_ListTileMatrices
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            // List all available tile matrix sets
            Response<IReadOnlyList<string>> response = await dataClient.GetTileMatricesAsync();
            IReadOnlyList<string> tileMatrixIds = response.Value;

            Console.WriteLine("Available Tile Matrix Sets:");
            foreach (string id in tileMatrixIds)
            {
                Console.WriteLine($"  - {id}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemAssets()
        {
            #region Snippet:Sample06_GetItemAssets
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get available assets for a specific item
            Response<IReadOnlyList<string>> response = await dataClient.GetItemAvailableAssetsAsync(new GetItemAvailableAssetsOptions(collectionId, itemId));

            IReadOnlyList<string> assets = response.Value;
            Console.WriteLine($"Available assets for item '{itemId}':");
            foreach (string asset in assets)
            {
                Console.WriteLine($"  - {asset}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemBounds()
        {
            #region Snippet:Sample06_GetBounds
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get bounding box for an item
            Response<StacItemBounds> response = await dataClient.GetItemBoundsAsync(new GetItemTilesetsOptions(collectionId, itemId));

            StacItemBounds boundsResult = response.Value;
            var bounds = boundsResult.Bounds;
            Console.WriteLine($"Bounds [minx, miny, maxx, maxy]: [{bounds[0]}, {bounds[1]}, {bounds[2]}, {bounds[3]}]");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemPreview()
        {
            #region Snippet:Sample06_GetPreview
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get a preview image
            Response response = await dataClient.GetItemPreviewAsync(new GetItemPreviewOptions(collectionId, itemId)
            {
                Format = TilerImageFormat.Png,
                Width = 512,
                Height = 512,
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });

            byte[] imageBytes = response.Content.ToArray();
            Console.WriteLine($"Preview image: {imageBytes.Length} bytes");

            // Save to file
            System.IO.File.WriteAllBytes("preview.png", imageBytes);
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemInfo()
        {
            #region Snippet:Sample06_GetInfo
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get item metadata as GeoJSON
            Response<TilerInfoGeoJsonFeature> response = await dataClient.GetItemInfoGeoJsonAsync(new GetItemInfoOptions(collectionId, itemId)
            {
                Assets = { "image" }
            });

            TilerInfoGeoJsonFeature info = response.Value;
            Console.WriteLine("Item info retrieved successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemStatistics()
        {
            #region Snippet:Sample06_GetStatistics
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get statistics for an item's assets
            Response<TilerStacItemStatistics> response = await dataClient.GetItemStatisticsAsync(new GetItemStatisticsOptions(collectionId, itemId)
            {
                Assets = { "image" }
            });

            TilerStacItemStatistics statistics = response.Value;
            Console.WriteLine("Statistics retrieved successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemAssetStatistics()
        {
            #region Snippet:Sample06_GetAssetStatistics
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get detailed statistics for each asset
            Response<AssetStatisticsResult> response = await dataClient.GetItemAssetStatisticsAsync(new GetItemAssetStatisticsOptions(collectionId, itemId)
            {
                Assets = { "image" }
            });

            IReadOnlyDictionary<string, BinaryData> assetStatistics = response.Value.AdditionalProperties;
            Console.WriteLine($"Statistics for {assetStatistics.Count} assets");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemWmtsCapabilitiesByTms()
        {
            #region Snippet:Sample06_GetWmtsCapabilities
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get WMTS capabilities XML
            Response response = await dataClient.GetItemWmtsCapabilitiesByTmsAsync(new GetItemWmtsCapabilitiesByTmsOptions(collectionId, itemId, "WebMercatorQuad")
            {
                TileFormat = TilerImageFormat.Png,
                TileScale = 1,
                MinZoom = 7,
                MaxZoom = 14,
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });

            string xmlString = System.Text.Encoding.UTF8.GetString(response.Content.ToArray());
            Console.WriteLine($"WMTS Capabilities: {xmlString.Substring(0, 200)}...");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CropByGeoJson()
        {
            #region Snippet:Sample06_CropGeoJson
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Define crop area as GeoJSON polygon
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
            var feature = new GeoJsonFeature(geometry, FeatureKind.Feature);
            feature.Properties.Add("description", BinaryData.FromString("\"Crop area\""));

            // Crop image by geometry
            Response response = await dataClient.CropFeatureByFormatAsync(
                feature,
                new CropFeatureByFormatOptions(collectionId, itemId, "png")
                {
                    Assets = { "image" },
                    AssetBandIndices = { "image|1,2,3" }
                });

            byte[] croppedImage = response.Content.ToArray();
            Console.WriteLine($"Cropped image: {croppedImage.Length} bytes");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CropWithDimensions()
        {
            #region Snippet:Sample06_CropWithDimensions
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Define crop area
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
            var feature = new GeoJsonFeature(geometry, FeatureKind.Feature);
            feature.Properties.Add("description", BinaryData.FromString("\"Crop area\""));

            // Crop with specific dimensions
            Response response = await dataClient.CropFeatureWidthByHeightAsync(
                feature,
                new CropFeatureWidthByHeightOptions(collectionId, itemId, 256, 256, "png")
                {
                    Assets = { "image" },
                    AssetBandIndices = { "image|1,2,3" }
                });

            byte[] croppedImage = response.Content.ToArray();
            Console.WriteLine($"Cropped 256x256 image: {croppedImage.Length} bytes");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetStatisticsForArea()
        {
            #region Snippet:Sample06_GetGeoJsonStatistics
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Define area for statistics
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
            var feature = new GeoJsonFeature(geometry, FeatureKind.Feature);
            feature.Properties.Add("description", BinaryData.FromString("\"Statistics area\""));

            // Get statistics for the area
            Response<StacItemStatisticsGeoJson> response = await dataClient.GetItemFeatureStatisticsAsync(
                feature,
                new GetItemFeatureStatisticsOptions(collectionId, itemId)
                {
                    Assets = { "image" }
                });

            StacItemStatisticsGeoJson statistics = response.Value;
            Console.WriteLine("Statistics for area retrieved successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetPartByBounds()
        {
            #region Snippet:Sample06_GetPart
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get part of image by bounding box
            Response response = await dataClient.GetItemBboxCropAsync(new GetItemBboxCropOptions(collectionId, itemId, -84.3930f, 33.6798f, -84.3670f, 33.7058f, "png")
            {
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });

            byte[] partImage = response.Content.ToArray();
            Console.WriteLine($"Part image: {partImage.Length} bytes");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemBboxCropWithDimensions()
        {
            #region Snippet:Sample06_GetPartWithDimensions
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get part with specific dimensions
            Response response = await dataClient.GetItemBboxCropWithDimensionsAsync(new GetItemBboxCropWithDimensionsOptions(collectionId, itemId, -84.3930f, 33.6798f, -84.3670f, 33.7058f, 256, 256, "png")
            {
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });

            byte[] partImage = response.Content.ToArray();
            Console.WriteLine($"Part image (256x256): {partImage.Length} bytes");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetDataAtPoint()
        {
            #region Snippet:Sample06_GetPoint
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get data at a specific point
            Response<TilerCoreModelsResponsesPoint> response = await dataClient.GetItemPointAsync(new GetItemPointOptions(collectionId, itemId, -84.3860f, 33.6760f)
            {
                Assets = { "image" }
            });

            TilerCoreModelsResponsesPoint pointData = response.Value;
            Console.WriteLine("Point data retrieved successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetTileJsonMetadata()
        {
            #region Snippet:Sample06_GetTileJson
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get TileJSON metadata
            Response<TileJsonMetadata> response = await dataClient.GetItemTileJsonByTmsAsync(new GetItemTileJsonByTmsOptions(collectionId, itemId, "WebMercatorQuad")
            {
                TileFormat = TilerImageFormat.Png,
                TileScale = 1,
                MinZoom = 7,
                MaxZoom = 14,
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });

            TileJsonMetadata tileJson = response.Value;
            Console.WriteLine($"TileJSON version: {tileJson.TileJson}");
            Console.WriteLine($"Tile URL pattern: {tileJson.Tiles[0]}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetTileByScaleAndFormat()
        {
            #region Snippet:Sample06_GetTile
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Get a specific tile
            Response response = await dataClient.GetTileByScaleAndFormatAsync(new GetTileByScaleAndFormatOptions(collectionId, itemId, "WebMercatorQuad", 14, 4349, 6564, 1, "png")
            {
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });

            byte[] tileImage = response.Content.ToArray();
            Console.WriteLine($"Tile image: {tileImage.Length} bytes");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CompleteTilerWorkflow()
        {
            #region Snippet:Sample06_CompleteTilerWorkflow
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            // Step 1: Get available assets
            Response<IReadOnlyList<string>> assetsResponse = await dataClient.GetItemAvailableAssetsAsync(new GetItemAvailableAssetsOptions(collectionId, itemId));
            Console.WriteLine($"Step 1: Found {assetsResponse.Value.Count} assets");

            // Step 2: Get item bounds
            Response<StacItemBounds> boundsResponse = await dataClient.GetItemBoundsAsync(new GetItemTilesetsOptions(collectionId, itemId));
            var bounds = boundsResponse.Value.Bounds;
            Console.WriteLine($"Step 2: Bounds: [{bounds[0]}, {bounds[1]}, {bounds[2]}, {bounds[3]}]");

            // Step 3: Get a preview image
            Response previewResponse = await dataClient.GetItemPreviewAsync(new GetItemPreviewOptions(collectionId, itemId)
            {
                Format = TilerImageFormat.Png,
                Width = 512,
                Height = 512,
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });
            Console.WriteLine($"Step 3: Preview image: {previewResponse.Content.ToArray().Length} bytes");

            // Step 4: Get TileJSON for mapping applications
            Response<TileJsonMetadata> tileJsonResponse = await dataClient.GetItemTileJsonByTmsAsync(new GetItemTileJsonByTmsOptions(collectionId, itemId, "WebMercatorQuad")
            {
                TileFormat = TilerImageFormat.Png,
                TileScale = 1,
                MinZoom = 7,
                MaxZoom = 14,
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });
            Console.WriteLine($"Step 4: TileJSON URL pattern: {tileJsonResponse.Value.Tiles[0]}");

            // Step 5: Get a specific tile
            Response tileResponse = await dataClient.GetTileByScaleAndFormatAsync(new GetTileByScaleAndFormatOptions(collectionId, itemId, "WebMercatorQuad", 14, 4349, 6564, 1, "png")
            {
                Assets = { "image" },
                AssetBandIndices = { "image|1,2,3" }
            });
            Console.WriteLine($"Step 5: Tile image: {tileResponse.Content.ToArray().Length} bytes");
            #endregion
        }
    }
}
