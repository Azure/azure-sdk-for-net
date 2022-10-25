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
            Assert.AreEqual(550, tileIndex.X);
            Assert.AreEqual(335, tileIndex.Y);
            Assert.AreEqual(zoom, tileIndex.Z);
        }

        [Test]
        public void TileXYToBoundingBoxTest()
        {
            int tileX = 200, tileY = 137, tileSize = 512, zoom = 11;

            var boundingBox = MapsRenderingClient.TileXYToBoundingBox(new MapTileIndex(tileX, tileY, zoom), tileSize);
            Assert.AreEqual(-144.84375, boundingBox.West);
            Assert.AreEqual(82.448764055958122, boundingBox.South);
            Assert.AreEqual(-144.66796875, boundingBox.East);
            Assert.AreEqual(82.471828856584551, boundingBox.North);
        }
    }
}
