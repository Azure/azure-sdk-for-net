// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
#region Snippet:RenderImportNamespace
using Azure.Maps.Render.Models;
#endregion
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
            var endpoint = new Uri("https://atlas.microsoft.com");
            var credential = new DefaultAzureCredential();
            var clientId = "<My Map Account Client Id>";
            MapsRenderClient client = new MapsRenderClient(credential, endpoint, clientId);
            #endregion
        }

        public void RenderClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateRenderClientViaSubscriptionKey
            // Create a MapsRenderClient that will authenticate through Subscription Key (Shared key)
            var endpoint = new Uri("https://atlas.microsoft.com");
            var credential = new AzureKeyCredential("<My Subscription Key>");
            MapsRenderClient client = new MapsRenderClient(credential, endpoint);
            #endregion
        }

        [Test]
        public void RenderingImageryTiles()
        {
            #region Snippet:RenderImageryTiles
            var endpoint = new Uri("https://atlas.microsoft.com");
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            #region Snippet:InstantiateRenderClient
            var client = new MapsRenderClient(credential, endpoint, clientId);
            #endregion

            #region Snippet:RenderImagery
            // Get imagery tile
            var imageryTile = client.GetMapImageryTile(new TileIndex(10, 12, 12));
            var imageryStream = new MemoryStream();
            imageryTile.Value.CopyTo(imageryStream);
            #endregion
            #endregion

            Assert.IsNotNull(imageryTile);
            Assert.IsTrue(imageryStream.Length > 0);
        }

        [Test]
        public void RenderingStaticImages()
        {
            var endpoint = new Uri("https://atlas.microsoft.com");
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRenderClient(credential, endpoint, clientId);

            #region Snippet:RenderStaticImages
            // Get static image
            var staticImageOptions = new RenderStaticImageOptions()
            {
                Layer = StaticMapLayer.Basic,
                Style = MapImageStyle.Dark,
                Center = new List<double>() { 0.0, 0.0 },
                Language = "en",
                Height = 100,
                Width = 100,
            };
            var image = client.GetMapStaticImage(staticImageOptions);
            var imageStream = new MemoryStream();
            image.Value.CopyTo(imageStream);
            #endregion

            Assert.IsNotNull(image);
            Assert.IsTrue(imageStream.Length > 0);
        }

        [Test]
        public void RenderingMapTiles()
        {
            var endpoint = new Uri("https://atlas.microsoft.com");
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRenderClient(credential, endpoint, clientId);

            #region Snippet:RenderMapTiles
            // Fetch map tiles
            var renderTileOptions = new RenderTileOptions()
            {
                Format = TileFormat.Png,
                Layer = MapTileLayer.Hybrid,
                Style = MapTileStyle.Main,
                TileIndex = new TileIndex(10, 88, 88),
            };
            var mapTile = client.GetMapTile(renderTileOptions);
            var tileStream = new MemoryStream();
            mapTile.Value.CopyTo(tileStream);
            #endregion

            Assert.IsNotNull(mapTile);
            Assert.IsTrue(tileStream.Length > 0);
        }
    }
}
