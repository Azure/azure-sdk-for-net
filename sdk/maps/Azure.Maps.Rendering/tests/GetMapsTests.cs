// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Rendering.Tests
{
    public class GetMapsTests : RenderingClientLiveTestsBase
    {
        public GetMapsTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetMapImageryTile()
        {
            var client = CreateClient();
            var tile = await client.GetMapImageryTileAsync(new MapTileIndex(14, 14, 10));
            using var imageryStream = new MemoryStream();

            Assert.IsNotNull(tile);
            tile.Value.CopyTo(imageryStream);
            Assert.IsTrue(imageryStream.Length > 0);
        }

        [RecordedTest]
        public async Task CanGetMapStaticImage()
        {
            var client = CreateClient();
            var options = new GetMapStaticImageOptions(new GeoPosition(10.176, 25.0524), 100, 100)
            {
                MapImageLayer = MapImageLayer.Basic,
                MapImageStyle = MapImageStyle.Dark,
                RenderLanguage = "en",
            };
            using var imageStream = new MemoryStream();
            var image = await client.GetMapStaticImageAsync(options);

            Assert.IsNotNull(image);
            image.Value.CopyTo(imageStream);
            Assert.IsTrue(imageStream.Length > 0);
        }

        [Test]
        public void GetMapStaticImageWithEmptyOptions()
        {
            var client = CreateClient();
            var options = new GetMapStaticImageOptions(null);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetMapStaticImageAsync(options));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task CanGetMapTile()
        {
            var client = CreateClient();
            var options = new GetMapTileOptions()
            {
                MapTileFormat = MapTileFormat.Png,
                MapTileLayer = MapTileLayer.Hybrid,
                MapTileStyle = MapTileStyle.Main,
                MapTileIndex = new MapTileIndex(88, 88, 10),
            };
            using var imageryStream = new MemoryStream();
            var tile = await client.GetMapTileAsync(options);

            Assert.IsNotNull(tile);
            tile.Value.CopyTo(imageryStream);
            Assert.IsTrue(imageryStream.Length > 0);
        }

        [Test]
        public void GetMapTileWithEmptyOptions()
        {
            var client = CreateClient();
            var options = new GetMapTileOptions();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.GetMapTileAsync(options));
        }

        public void GetMapTileException()
        {
            var client = CreateClient();

            #region Snippet:CatchRenderException
            try
            {
                Response<Stream> imageryTile = client.GetMapImageryTile(new MapTileIndex(12, 12, 2));
                using var imageryStream = new MemoryStream();
                imageryTile.Value.CopyTo(imageryStream);
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }
    }
}
