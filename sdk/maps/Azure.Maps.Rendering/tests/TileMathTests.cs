// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Maps.Rendering.Tests
{
    public class TileMathTests
    {
        [Test]
        public void PositionToTileXYTest()
        {
            int zoom = 10, tileSize = 512;

            // Get tile X, Y index by coordinate, zoom and tile size information
            var tileIndex = MapsRenderingClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);
            Assert.Multiple(() =>
            {
                Assert.That(tileIndex.X, Is.EqualTo(550));
                Assert.That(tileIndex.Y, Is.EqualTo(335));
                Assert.That(tileIndex.Z, Is.EqualTo(zoom));
            });
        }

        [Test]
        public void TileXYToBoundingBoxTest()
        {
            int tileX = 200, tileY = 137, tileSize = 512, zoom = 11;

            var boundingBox = MapsRenderingClient.TileXYToBoundingBox(new MapTileIndex(tileX, tileY, zoom), tileSize);
            Assert.Multiple(() =>
            {
                Assert.That(boundingBox.West, Is.EqualTo(-144.84375));
                Assert.That(boundingBox.South, Is.EqualTo(82.448764055958122));
                Assert.That(boundingBox.East, Is.EqualTo(-144.66796875));
                Assert.That(boundingBox.North, Is.EqualTo(82.471828856584551));
            });
        }
    }
}
