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
using Azure.Core;
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
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
            string clientId = "<Your Map ClientId>";
#else
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
#endif
            MapsRenderClient client = new MapsRenderClient(credential, clientId);
            #endregion
        }

        public void RenderClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateRenderClientViaSubscriptionKey
            // Create a MapsRenderClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsRenderClient client = new MapsRenderClient(credential);
            #endregion
        }

        [Test]
        public void RenderingImageryTiles()
        {
            #region Snippet:RenderImageryTiles
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
            string clientId = "<Your Map ClientId>";
#else
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
#endif
            MapsRenderClient client = new MapsRenderClient(credential, clientId);

            #region Snippet:GetTileXY
            int zoom = 10, tileSize = 300;

            // Get tile X, Y index by coordinate, zoom and tile size information
            MapTileIndex tileIndex = MapsRenderClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);
            #endregion

            #region Snippet:RenderImagery
            // Get imagery tile
            Response<Stream> imageryTile = client.GetMapImageryTile(new MapTileIndex(tileIndex.X, tileIndex.Y, zoom));

            // Prepare a file stream to save the imagery
            using (FileStream fileStream = File.Create(".\\BerlinImagery.png"))
            {
                imageryTile.Value.CopyTo(fileStream);
            }
            #endregion
            #endregion
        }

        [Test]
        public void RenderingStaticImages()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRenderClient client = new MapsRenderClient(credential, clientId);

            #region Snippet:RenderStaticImages
            // Prepare static image options
            GetMapStaticImageOptions staticImageOptions = new GetMapStaticImageOptions(new GeoBoundingBox(13.228,52.4559,13.5794,52.629))
            {
                MapImageLayer = MapImageLayer.Basic,
                MapImageStyle = MapImageStyle.Dark,
                ZoomLevel = 10,
                RenderLanguage = "en",
            };

            // Get static image
            Response<Stream> image = client.GetMapStaticImage(staticImageOptions);

            // Prepare a file stream to save the imagery
            using (FileStream fileStream = File.Create(".\\BerlinStaticImage.png"))
            {
                image.Value.CopyTo(fileStream);
            }
            #endregion

            Assert.IsNotNull(image);
        }

        [Test]
        public void RenderingStaticImagesWithPinsAndPaths()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRenderClient client = new MapsRenderClient(credential, clientId);
            Assert.IsNotNull(client);

            #region Snippet:RenderStaticImagesWithPinsAndPaths
            // Prepare pushpin styles
            ImagePushpinStyle pushpinSet1 = new ImagePushpinStyle(
                new List<PushpinPosition>()
                {
                    new PushpinPosition(13.35, 52.577, "Label start"),
                    new PushpinPosition(13.2988, 52.6, "Label end"),
                }
            )
            {
                PushpinScaleRatio = 0.9,
                PushpinColor = Color.Red,
                LabelColor = Color.Blue,
                LabelScaleRatio = 18
            };
            ImagePushpinStyle pushpinSet2 = new ImagePushpinStyle(
                new List<PushpinPosition>() {new PushpinPosition(13.495, 52.497, "Label 3")}
            )
            {
                PushpinScaleRatio = 1.2,
                PushpinColor = Color.Beige,
                LabelColor = Color.White,
                LabelScaleRatio = 18
            };

            // Prepare path styles
            ImagePathStyle path1 = new ImagePathStyle(
                new List<GeoPosition>() {
                    new GeoPosition(13.35, 52.577),
                    new GeoPosition(13.2988, 52.6)
                }
            )
            {
                LineColor = Color.Beige,
                LineWidthInPixels = 5
            };

            // Prepare static image options
            GetMapStaticImageOptions staticImageOptions = new GetMapStaticImageOptions(new GeoBoundingBox(13.228, 52.4559, 13.5794, 52.629))
            {
                MapImageLayer = MapImageLayer.Basic,
                MapImageStyle = MapImageStyle.Dark,
                ZoomLevel = 10,
                RenderLanguage = "en",
                ImagePushpinStyles = new List<ImagePushpinStyle>() { pushpinSet1, pushpinSet2 },
                ImagePathStyles = new List<ImagePathStyle>() { path1 },
            };

            // Get static image
            Response<Stream> image = client.GetMapStaticImage(staticImageOptions);

            // Prepare a file stream to save the imagery
            using (FileStream fileStream = File.Create(".\\BerlinStaticImageWithPinsAndPaths.png"))
            {
                image.Value.CopyTo(fileStream);
            }
            #endregion

            Assert.IsNotNull(staticImageOptions);
            Assert.IsNotNull(image);
        }

        [Test]
        public void RenderingMapTiles()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRenderClient client = new MapsRenderClient(credential, clientId);

            #region Snippet:RenderMapTiles
            int zoom = 10, tileSize = 300;

            // Get tile X, Y index by coordinate, zoom and tile size information
            MapTileIndex tileIndex = MapsRenderClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);

            // Fetch map tiles
            GetMapTileOptions GetMapTileOptions = new GetMapTileOptions()
            {
                MapTileFormat = MapTileFormat.Png,
                MapTileLayer = MapTileLayer.Hybrid,
                MapTileStyle = MapTileStyle.Main,
                MapTileIndex = new MapTileIndex(tileIndex.X, tileIndex.Y, zoom),
            };
            Response<Stream> mapTile = client.GetMapTile(GetMapTileOptions);

            // Prepare a file stream to save the imagery
            using (FileStream fileStream = File.Create(".\\BerlinMapTile.png"))
            {
                mapTile.Value.CopyTo(fileStream);
            }
            #endregion

            Assert.IsNotNull(mapTile);
        }
    }
}
