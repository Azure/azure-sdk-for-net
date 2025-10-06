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
        public async Task CanGetMapCopyrightAttribution()
        {
            var client = CreateClient();
            var copyrights = await client.GetMapCopyrightAttributionAsync(
                MapTileSetId.MicrosoftBase, new GeoBoundingBox(13.228, 52.4559, 13.5794, 52.629));

            Assert.IsNotNull(copyrights);
        }

        [RecordedTest]
        public async Task CanGetMapStaticImage()
        {
            var client = CreateClient();
            var options = new GetMapStaticImageOptions(new GeoPosition(10.176, 25.0524), 100, 100)
            {
                Language = RenderingLanguage.EnglishUsa,
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
            var options = new GetMapTileOptions(
                MapTileSetId.MicrosoftBaseHybrid,
                new MapTileIndex(88, 88, 10)
            );
            using var imageryStream = new MemoryStream();
            var tile = await client.GetMapTileAsync(options);

            Assert.IsNotNull(tile);
            tile.Value.CopyTo(imageryStream);
            Assert.IsTrue(imageryStream.Length > 0);
        }

        [RecordedTest]
        public async Task CanGetMapTileSet()
        {
            var client = CreateClient();
            var tileSet = await client.GetMapTileSetAsync(MapTileSetId.MicrosoftImagery);

            Assert.IsNotNull(tileSet);
            Assert.AreEqual("2.2.0", tileSet.Value.TileJsonVersion);
            Assert.AreEqual("1.0.0", tileSet.Value.TileSetVersion);
            Assert.AreEqual("microsoft.imagery", tileSet.Value.TileSetName);
            Assert.AreEqual(1, tileSet.Value.TileEndpoints.Count);
            Assert.AreEqual(1, tileSet.Value.MinZoomLevel);
            Assert.AreEqual(19, tileSet.Value.MaxZoomLevel);
        }

        public void GetMapTileException()
        {
            var client = CreateClient();

            #region Snippet:CatchRenderException
            try
            {
                var options = new GetMapTileOptions(
                    MapTileSetId.MicrosoftBaseHybrid,
                    new MapTileIndex(12, 12, 2)
                );

                Response<Stream> imageryTile = client.GetMapTile(options);
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
