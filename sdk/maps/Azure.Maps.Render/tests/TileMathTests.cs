// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Render.Tests
{
    public class TileMathTests
    {
        [Test]
        public void PositionToTileXYTest()
        {
            int zoom = 10, tileSize = 512;

            // Get tile X, Y index by coordinate, zoom and tile size information
            TileMath.PositionToTileXY(
                new GeoPosition(13.3854, 52.517), zoom, tileSize,
                out var tileX, out var tileY
            );
            Assert.AreEqual(550, tileX);
            Assert.AreEqual(335, tileY);
        }

        [Test]
        public void TileXYToBoundingBoxTest()
        {
            int tileX = 200, tileY = 137, tileSize = 512;
            double zoom = 11.2;

            var boundingBox = TileMath.TileXYToBoundingBox(tileX, tileY, zoom, tileSize);
            Assert.AreEqual(-149.39471879571406, boundingBox.West);
            Assert.AreEqual(82.850409048238333, boundingBox.South);
            Assert.AreEqual(-149.24169238969262, boundingBox.East);
            Assert.AreEqual(82.869429549418456, boundingBox.North);
        }

        [Test]
        public void BestMapViewTest()
        {
            #region Snippet:BestMapViewUsage
            var boundingBox = new GeoBoundingBox(4.84228, 52.41064, 4.84923, 52.41762);
            double mapWidth = 300.0, mapHeight = 300.0;
            int padding = 10, tileSize = 512;

            TileMath.BestMapView(boundingBox, mapWidth, mapHeight, padding, tileSize,
                out var centerLat, out var centerLon, out var zoom);

            // Use center latitude, longitute and zoom level for follow up operations
            #endregion

            Assert.AreEqual(52.414130138092666, centerLat);
            Assert.AreEqual(4.8457550000000005, centerLon);
            Assert.AreEqual(14.789907420100443, zoom);
        }
    }
}
