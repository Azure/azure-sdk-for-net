// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Drawing;
#region Snippet:SaveToFile
using System.IO;
#endregion
#region Snippet:RenderImportNamespace
using Azure.Maps.Rendering;
#endregion
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Rendering.Tests
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
            var tileIndex = MapsRenderClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);
            #endregion

            #region Snippet:RenderImagery
            // Get imagery tile
            var imageryTile = client.GetMapImageryTile(new MapTileIndex(tileIndex.X, tileIndex.Y, zoom));
            Assert.IsNotNull(imageryTile);

            // Prepare a file stream to save the imagery
            using (var fileStream = File.Create(".\\BerlinImagery.png"))
            {
                imageryTile.Value.CopyTo(fileStream);
                Assert.IsTrue(fileStream.Length > 0);
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
            // Prepare static image options
            var staticImageOptions = new GetMapStaticImageOptions(new GeoBoundingBox(13.228,52.4559,13.5794,52.629))
            {
                ImageLayer = MapImageLayer.Basic,
                ImageStyle = MapImageStyle.Dark,
                ZoomLevel = 10,
                RenderLanguage = "en",
            };

            // Get static image
            var image = client.GetMapStaticImage(staticImageOptions);

            // Prepare a file stream to save the imagery
            using (var fileStream = File.Create(".\\BerlinStaticImage.png"))
            {
                image.Value.CopyTo(fileStream);
                Assert.IsTrue(fileStream.Length > 0);
            }
            #endregion

            Assert.IsNotNull(image);
        }

        [Test]
        public void RenderingStaticImagesWithPinsAndPaths()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRenderClient(credential, clientId);
            Assert.IsNotNull(client);

            #region Snippet:RenderStaticImagesWithPinsAndPaths
            // Prepare pushpin styles
            var pushpinSet1 = new ImagePushpinStyle(
                new List<PushpinPosition>() {
                    new PushpinPosition(13.35, 52.577, "Label start"),
                    new PushpinPosition(13.2988, 52.6, "Label end"),
            })
            {
                PinScale = 0.9,
                PinColor = Color.Red,
                LabelColor = Color.Blue,
                LabelScale = 18
            };
            var pushpinSet2 = new ImagePushpinStyle(
                new List<PushpinPosition>() {new PushpinPosition(13.495, 52.497, "Label 3")}
            )
            {
                PinScale = 1.2,
                PinColor = Color.Beige,
                LabelColor = Color.White,
                LabelScale = 18
            };

            // Prepare path styles
            var path1 = new ImagePathStyle(
                new List<GeoPosition>() {
                    new GeoPosition(13.35, 52.577),
                    new GeoPosition(13.2988, 52.6)
            })
            {
                LineColor = Color.Beige,
                LineWidthInPixels = 5
            };

            // Prepare static image options
            var staticImageOptions = new GetMapStaticImageOptions(new GeoBoundingBox(13.228, 52.4559, 13.5794, 52.629))
            {
                ImageLayer = MapImageLayer.Basic,
                ImageStyle = MapImageStyle.Dark,
                ZoomLevel = 10,
                RenderLanguage = "en",
                ImagePushpinStyles = new List<ImagePushpinStyle>() { pushpinSet1, pushpinSet2 },
                ImagePathStyles = new List<ImagePathStyle>() { path1 },
            };

            // Get static image
            var image = client.GetMapStaticImage(staticImageOptions);

            // Prepare a file stream to save the imagery
            using (var fileStream = File.Create(".\\BerlinStaticImageWithPinsAndPaths.png"))
            {
                image.Value.CopyTo(fileStream);
                Assert.IsTrue(fileStream.Length > 0);
            }
            #endregion

            Assert.IsNotNull(staticImageOptions);
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
            var tileIndex = MapsRenderClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);

            // Fetch map tiles
            var GetMapTileOptions = new GetMapTileOptions()
            {
                MapTileFormat = MapTileFormat.Png,
                MapTileLayer = MapTileLayer.Hybrid,
                MapTileStyle = MapTileStyle.Main,
                MapTileIndex = new MapTileIndex(tileIndex.X, tileIndex.Y, zoom),
            };
            var mapTile = client.GetMapTile(GetMapTileOptions);

            // Prepare a file stream to save the imagery
            using (var fileStream = File.Create(".\\BerlinMapTile.png"))
            {
                mapTile.Value.CopyTo(fileStream);
                Assert.IsTrue(fileStream.Length > 0);
            }
            #endregion

            Assert.IsNotNull(mapTile);
        }
    }
}
