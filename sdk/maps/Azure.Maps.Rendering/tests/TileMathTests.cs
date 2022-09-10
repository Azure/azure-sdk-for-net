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
            var tileIndex = MapsRenderClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);
            Assert.AreEqual(550, tileIndex.X);
            Assert.AreEqual(335, tileIndex.Y);
            Assert.AreEqual(zoom, tileIndex.Z);
        }

        [Test]
        public void TileXYToBoundingBoxTest()
        {
            int tileX = 200, tileY = 137, tileSize = 512, zoom = 11;

            var boundingBox = MapsRenderClient.TileXYToBoundingBox(new MapTileIndex(tileX, tileY, zoom), tileSize);
            Assert.AreEqual(-149.39471879571406, boundingBox.West);
            Assert.AreEqual(82.850409048238333, boundingBox.South);
            Assert.AreEqual(-149.24169238969262, boundingBox.East);
            Assert.AreEqual(82.869429549418456, boundingBox.North);
        }
    }
}
