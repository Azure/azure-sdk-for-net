// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:SaveToFile
using System.IO;
#endregion
#region Snippet:ImportTileMath
using Azure.Maps;
#endregion
#region Snippet:RenderImportNamespace
using Azure.Maps.Render;
#endregion
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Render.Tests
{
    public class RenderClientSamples : SamplesBase<RenderClientTestEnvironment>
    {
        public void RenderClientViaAAD()
        {
            #region Snippet:InstantiateRenderClientViaAAD
            // Create a MapsRenderClient that will authenticate through Active Directory
            var credential = new DefaultAzureCredential();
            var clientId = "<My Map Account Client Id>";
            MapsRenderClient client = new MapsRenderClient(credential, clientId);
            #endregion
        }

        public void RenderClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateRenderClientViaSubscriptionKey
            // Create a MapsRenderClient that will authenticate through Subscription Key (Shared key)
            var credential = new AzureKeyCredential("<My Subscription Key>");
            MapsRenderClient client = new MapsRenderClient(credential);
            #endregion
        }

        [Test]
        public void RenderingImageryTiles()
        {
            #region Snippet:RenderImageryTiles
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRenderClient(credential, clientId);

            #region Snippet:GetTileXY
            int zoom = 10, tileSize = 300;

            // Get tile X, Y index by coordinate, zoom and tile size information
            TileMath.PositionToTileXY(
                new GeoPosition(13.3854, 52.517), zoom, tileSize,
                out var tileX, out var tileY
            );
            #endregion

            #region Snippet:RenderImagery
            // Get imagery tile
            var imageryTile = client.GetMapImageryTile(new TileIndex(tileX, tileY, zoom));
            Assert.IsNotNull(imageryTile);

            // Prepare a file stream to save the imagery
            using (var fileStream = File.Create(".\\BerlinImagery.png"))
            {
                imageryTile.Value.CopyTo(fileStream);
                Assert.IsNotNull(fileStream.Length > 0);
            }
            #endregion
            #endregion
        }

        [Test]
        public void RenderingStaticImages()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRenderClient(credential, clientId);

            #region Snippet:RenderStaticImages
            // Get static image
            var staticImageOptions = new RenderStaticImageOptions()
            {
                TileLayer = MapImageLayer.Basic,
                TileStyle = MapImageStyle.Dark,
                BoundingBox = new GeoBoundingBox(13.228,52.4559,13.5794,52.629),
                ZoomLevel = 10,
                RenderLanguage = "en",
            };
            var image = client.GetMapStaticImage(staticImageOptions);

            // Prepare a file stream to save the imagery
            using (var fileStream = File.Create(".\\BerlinStaticImage.png"))
            {
                image.Value.CopyTo(fileStream);
                Assert.IsNotNull(fileStream.Length > 0);
            }
            #endregion

            Assert.IsNotNull(image);
        }

        [Test]
        public void RenderingMapTiles()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRenderClient(credential, clientId);

            #region Snippet:RenderMapTiles
            int zoom = 10, tileSize = 300;

            // Get tile X, Y index by coordinate, zoom and tile size information
            TileMath.PositionToTileXY(
                new GeoPosition(13.3854, 52.517), zoom, tileSize,
                out var tileX, out var tileY
            );

            // Fetch map tiles
            var renderTileOptions = new RenderTileOptions()
            {
                TileFormat = TileFormat.Png,
                TileLayer = MapTileLayer.Hybrid,
                TileStyle = MapTileStyle.Main,
                TileIndex = new TileIndex(tileX, tileY, zoom),
            };
            var mapTile = client.GetMapTile(renderTileOptions);

            // Prepare a file stream to save the imagery
            using (var fileStream = File.Create(".\\BerlinMapTile.png"))
            {
                mapTile.Value.CopyTo(fileStream);
                Assert.IsNotNull(fileStream.Length > 0);
            }
            #endregion

            Assert.IsNotNull(mapTile);
        }
    }
}
