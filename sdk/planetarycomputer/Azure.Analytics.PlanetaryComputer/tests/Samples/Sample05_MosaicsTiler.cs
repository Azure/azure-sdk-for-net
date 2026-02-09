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
        public async Task GetMosaicsSearchInfo()
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
            Response<TilerStacSearchRegistration> response = await dataClient.GetMosaicsSearchInfoAsync(searchId);
            TilerStacSearchRegistration searchInfo = response.Value;

            Console.WriteLine("Search registration retrieved successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetMosaicsTileJson()
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

            TileJsonMetadata tileJson = response.Value;
            Console.WriteLine($"TileJSON version: {tileJson.TileJson}");
            Console.WriteLine($"Tile URL pattern: {tileJson.Tiles[0]}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetMosaicsTile()
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

            byte[] imageBytes = response.Value.ToArray();
            Console.WriteLine($"Downloaded tile: {imageBytes.Length} bytes");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetMosaicsWmtsCapabilities()
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

            string xmlString = Encoding.UTF8.GetString(response.Value.ToArray());
            Console.WriteLine($"WMTS Capabilities XML: {xmlString.Substring(0, 200)}...");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetMosaicsAssetsForPoint()
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
        public async Task GetMosaicsAssetsForTile()
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
            Response<IReadOnlyList<BinaryData>> response = await dataClient.GetMosaicsAssetsForTileAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                z: 13,
                x: 2174,
                y: 3282,
                collectionId: collectionId
            );

            IReadOnlyList<BinaryData> assets = response.Value;
            Console.WriteLine($"Found {assets.Count} assets for tile z=13, x=2174, y=3282");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CreateStaticImage()
        {
            #region Snippet:Sample05_CreateStaticImage
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";

            // Define the area of interest
            var coordinates = new List<IList<IList<float>>>
            {
                new List<IList<float>>
                {
                    new List<float> { -84.45f, 33.66f },
                    new List<float> { -84.40f, 33.66f },
                    new List<float> { -84.40f, 33.62f },
                    new List<float> { -84.45f, 33.62f },
                    new List<float> { -84.45f, 33.66f }
                }
            };
            var geometry = new PolygonGeometry(coordinates);

            // Define temporal filter
            var cqlFilter = new Dictionary<string, BinaryData>
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
                        ["op"] = "anyinteracts",
                        ["args"] = new object[]
                        {
                            new Dictionary<string, string> { ["property"] = "datetime" },
                            new Dictionary<string, object>
                            {
                                ["interval"] = new[] { "2023-01-01T00:00:00Z", "2023-12-31T00:00:00Z" }
                            }
                        }
                    }
                })
            };

            // Create image request
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

            // Create the static image
            Response<ImageResponse> response = await dataClient.CreateStaticImageAsync(
                collectionId: collectionId,
                body: imageRequest
            );

            Console.WriteLine($"Static image created: {response.Value.Url}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetStaticImage()
        {
            #region Snippet:Sample05_GetStaticImage
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            DataClient dataClient = client.GetDataClient();

            string collectionId = "naip";
            string imageId = "abc123.png"; // From CreateStaticImage response URL

            // Retrieve the static image
            Response<BinaryData> response = await dataClient.GetStaticImageAsync(
                collectionId: collectionId,
                id: imageId
            );

            byte[] imageBytes = response.Value.ToArray();
            Console.WriteLine($"Retrieved static image: {imageBytes.Length} bytes");

            // Save to file
            System.IO.File.WriteAllBytes("static_image.png", imageBytes);
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
            Response<TileJsonMetadata> tileJsonResponse = await dataClient.GetMosaicsTileJsonAsync(
                searchId: searchId,
                tileMatrixSetId: "WebMercatorQuad",
                assets: new[] { "image" },
                assetBandIndices: "image|1,2,3",
                tileScale: 1,
                minZoom: 9,
                tileFormat: TilerImageFormat.Png,
                collection: collectionId
            );

            Console.WriteLine($"Step 2: TileJSON URL pattern: {tileJsonResponse.Value.Tiles[0]}");

            // Step 3: Get a specific tile
            Response<BinaryData> tileResponse = await dataClient.GetMosaicsTileAsync(
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

            Console.WriteLine($"Step 3: Downloaded tile: {tileResponse.Value.ToArray().Length} bytes");

            // Step 4: Get assets for a specific point
            Response<IReadOnlyList<StacItemPointAsset>> assetsResponse = await dataClient.GetMosaicsAssetsForPointAsync(
                searchId: searchId,
                longitude: -84.432f,
                latitude: 33.640f,
                coordinateReferenceSystem: "EPSG:4326",
                itemsLimit: 100
            );

            Console.WriteLine($"Step 4: Found {assetsResponse.Value.Count} assets at point");
            #endregion
        }
    }
}
