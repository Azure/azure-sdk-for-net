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
            Assert.That(imageStream.Length > 0, Is.True);
        }

        [Test]
        public void GetMapStaticImageWithEmptyOptions()
        {
            var client = CreateClient();
            var options = new GetMapStaticImageOptions(null);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetMapStaticImageAsync(options));
            Assert.That(ex.Status, Is.EqualTo(400));
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
            Assert.That(imageryStream.Length > 0, Is.True);
        }

        [RecordedTest]
        public async Task CanGetMapTileSet()
        {
            var client = CreateClient();
            var tileSet = await client.GetMapTileSetAsync(MapTileSetId.MicrosoftImagery);

            Assert.IsNotNull(tileSet);
            Assert.That(tileSet.Value.TileJsonVersion, Is.EqualTo("2.2.0"));
            Assert.That(tileSet.Value.TileSetVersion, Is.EqualTo("1.0.0"));
            Assert.That(tileSet.Value.TileSetName, Is.EqualTo("microsoft.imagery"));
            Assert.That(tileSet.Value.TileEndpoints.Count, Is.EqualTo(1));
            Assert.That(tileSet.Value.MinZoomLevel, Is.EqualTo(1));
            Assert.That(tileSet.Value.MaxZoomLevel, Is.EqualTo(19));
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
