// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests.Samples
{
    /// <summary>
    /// Samples demonstrating how to work with the Mosaics Tiler API for creating dynamic mosaics
    /// and map tiles from STAC searches.
    /// </summary>
    public partial class Sample05_MosaicsTiler : PlanetaryComputerTestBase
    {
        public Sample05_MosaicsTiler(bool isAsync) : base(isAsync) { }
        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task RegisterMosaicsSearch()
        {
            #region Snippet:Sample05_RegisterSearch
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            // Define a CQL2-JSON filter for temporal range
            var filter = new Dictionary<string, BinaryData>
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
                            "naip"
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
                    }
                })
            };

            // Register the search and get a search ID
            Response<TilerMosaicSearchRegistrationResult> response = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json
            );

            string searchId = response.Value.SearchId;
            Console.WriteLine($"Registered search ID: {searchId}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetSearchInfo()
        {
            #region Snippet:Sample05_GetSearchInfo
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string searchId = "abc123"; // From previous registration

            // Get information about the registered search
            Response<TilerStacSearchRegistration> response = await dataClient.GetSearchInfoAsync(searchId);
            TilerStacSearchRegistration searchInfo = response.Value;

            Console.WriteLine("Search registration retrieved successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetSearchTileJson()
        {
            #region Snippet:Sample05_GetTileJson
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string searchId = "abc123"; // From previous registration
            string collectionId = "naip";

            // Get TileJSON metadata for the mosaic
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

            TileJsonMetadata tileJson = response.Value;
            Console.WriteLine($"TileJSON version: {tileJson.TileJson}");
            Console.WriteLine($"Tile URL pattern: {tileJson.Tiles[0]}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetSearchTile()
        {
            #region Snippet:Sample05_GetTile
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string searchId = "abc123"; // From previous registration
            string collectionId = "naip";

            // Get a specific tile image (z=13, x=2174, y=3282)
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

            byte[] imageBytes = response.Value.ToArray();
            Console.WriteLine($"Downloaded tile: {imageBytes.Length} bytes");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetSearchWmtsCapabilities()
        {
            #region Snippet:Sample05_GetWmtsCapabilities
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string searchId = "abc123"; // From previous registration

            // Get WMTS capabilities XML
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

            string xmlString = Encoding.UTF8.GetString(response.Value.ToArray());
            Console.WriteLine($"WMTS Capabilities XML: {xmlString.Substring(0, 200)}...");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetSearchPointWithAssets()
        {
            #region Snippet:Sample05_GetAssetsForPoint
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string searchId = "abc123"; // From previous registration

            // Get assets that cover a specific point
            float longitude = -84.432f;
            float latitude = 33.640f;

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

            IReadOnlyList<StacItemPointAsset> assets = response.Value;
            Console.WriteLine($"Found {assets.Count} assets at point ({longitude}, {latitude})");
            foreach (StacItemPointAsset asset in assets)
            {
                Console.WriteLine($"  - {asset.Id}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetSearchAssetsForTile()
        {
            #region Snippet:Sample05_GetAssetsForTile
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string searchId = "abc123"; // From previous registration
            string collectionId = "naip";

            // Get assets that intersect with a specific tile
            Response<IReadOnlyList<TilerAssetGeoJson>> response = await dataClient.GetSearchAssetsForTileAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 13,
                x: 2174,
                y: 3282,
                collectionId: collectionId
            );

            IReadOnlyList<TilerAssetGeoJson> assets = response.Value;
            Console.WriteLine($"Found {assets.Count} assets for tile z=13, x=2174, y=3282");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CompleteTilingWorkflow()
        {
            #region Snippet:Sample05_CompleteTilingWorkflow
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";

            // Step 1: Register a search with filters
            var filter = new Dictionary<string, BinaryData>
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
                    }
                })
            };

            var sortBy = new[]
            {
                new StacSortExtension("datetime", StacSearchSortingDirection.Desc)
            };

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await dataClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Json,
                sortBy: sortBy
            );

            string searchId = registerResponse.Value.SearchId;
            Console.WriteLine($"Step 1: Registered search ID: {searchId}");

            // Step 2: Get TileJSON metadata
            Response<TileJsonMetadata> tileJsonResponse = await dataClient.GetSearchTileJsonAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                assets: new[] { "image" },
                assetBandIndices: new[] { "image|1,2,3" },
                tileScale: 1,
                minZoom: 9,
                tileFormat: TilerImageFormat.Png,
                collectionId: collectionId
            );

            Console.WriteLine($"Step 2: TileJSON URL pattern: {tileJsonResponse.Value.Tiles[0]}");

            // Step 3: Get a specific tile
            Response<BinaryData> tileResponse = await dataClient.GetSearchTileAsync(
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

            Console.WriteLine($"Step 3: Downloaded tile: {tileResponse.Value.ToArray().Length} bytes");

            // Step 4: Get assets for a specific point
            Response<IReadOnlyList<StacItemPointAsset>> assetsResponse = await dataClient.GetSearchPointWithAssetsAsync(
                searchId: searchId,
                longitude: -84.432f,
                latitude: 33.640f,
                coordinateReferenceSystem: "EPSG:4326",
                itemsLimit: 100
            );

            Console.WriteLine($"Step 4: Found {assetsResponse.Value.Count} assets at point");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetSearchTileByScaleAndFormat()
        {
            #region Snippet:Sample05_GetSearchTileByScaleAndFormat
#if SNIPPET
            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");
            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());
#else
            var client = GetTestClient();
#endif
            DataClient dataClient = client.GetDataClient();
            string searchId = "existing-search-id";
            string collectionId = "naip";

            // Get a tile with explicit scale and format in the URL path
            Response<BinaryData> response = await dataClient.GetSearchTileByScaleAndFormatAsync(
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

            byte[] imageBytes = response.Value.ToArray();
            Console.WriteLine($"Downloaded tile (by scale and format): {imageBytes.Length} bytes");
            #endregion
        }
    }
}
