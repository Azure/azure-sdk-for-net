// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class SpatialGeoArrayTest
    {
        [Test]
        public void PointCoordinatesWork()
        {
            var point = new GeoPoint(1, 2);

            Assert.AreEqual(2, point.Coordinates.Count);
            Assert.AreEqual(1, point.Coordinates[0]);
            Assert.AreEqual(2, point.Coordinates[1]);
        }

        [Test]
        public void PointCoordinatesWork3()
        {
            var point = new GeoPoint(1, 2, 3);

            Assert.AreEqual(3, point.Coordinates.Count);

            Assert.AreEqual(1, point.Coordinates[0]);
            Assert.AreEqual(2, point.Coordinates[1]);
            Assert.AreEqual(3, point.Coordinates[2]);
        }

        [Test]
        public void PointCollectionCoordinatesWork()
        {
            var pointCollection = new GeoPointCollection(
                new[]
                {
                    new GeoPoint(1,2),
                    new GeoPoint(3,4)
                });

            Assert.AreEqual(2, pointCollection.Coordinates.Count);
            Assert.AreEqual(2, pointCollection.Coordinates.Count());

            Assert.AreEqual(1, pointCollection.Coordinates[0][0]);
            Assert.AreEqual(2, pointCollection.Coordinates[0][1]);

            Assert.AreEqual(3, pointCollection.Coordinates[1][0]);
            Assert.AreEqual(4, pointCollection.Coordinates[1][1]);
        }

        [Test]
        public void LineCoordinatesWork()
        {
            var line = new GeoLineString(new GeoPosition[]
            {
                new GeoPosition(1, 2),
                new GeoPosition(3, 4),
                new GeoPosition(5, 6),
            });

            Assert.AreEqual(3, line.Coordinates.Count);
            Assert.AreEqual(3, line.Coordinates.Count());

            Assert.AreEqual(1, line.Coordinates[0][0]);
            Assert.AreEqual(2, line.Coordinates[0][1]);

            Assert.AreEqual(3, line.Coordinates[1][0]);
            Assert.AreEqual(4, line.Coordinates[1][1]);

            Assert.AreEqual(5, line.Coordinates[2][0]);
            Assert.AreEqual(6, line.Coordinates[2][1]);
        }

        [Test]
        public void LineCollectionCoordinatesWork()
        {
            var lineCollection = new GeoLineStringCollection(new[]
            {
                new GeoLineString(new[] {
                    new GeoPosition(1, 2),
                    new GeoPosition(3, 4)
                }),
                new GeoLineString(new[] {
                    new GeoPosition(5, 6),
                    new GeoPosition(7, 8)
                }),
            });

            Assert.AreEqual(2, lineCollection.Coordinates.Count);
            Assert.AreEqual(2, lineCollection.Coordinates.Count());

            Assert.AreEqual(1, lineCollection.Coordinates[0][0][0]);
            Assert.AreEqual(2, lineCollection.Coordinates[0][0][1]);

            Assert.AreEqual(3, lineCollection.Coordinates[0][1][0]);
            Assert.AreEqual(4, lineCollection.Coordinates[0][1][1]);

            Assert.AreEqual(5, lineCollection.Coordinates[1][0][0]);
            Assert.AreEqual(6, lineCollection.Coordinates[1][0][1]);

            Assert.AreEqual(7, lineCollection.Coordinates[1][1][0]);
            Assert.AreEqual(8, lineCollection.Coordinates[1][1][1]);
        }

        [Test]
        public void PolygonCoordinatesWork()
        {
            var polygon = new GeoPolygon(new[]
            {
                new GeoLinearRing(new[] {
                    new GeoPosition(1, 2),
                    new GeoPosition(3, 4),
                    new GeoPosition(3, 4),
                    new GeoPosition(1, 2),
                }),
                new GeoLinearRing(new[] {
                    new GeoPosition(5, 6),
                    new GeoPosition(7, 8),
                    new GeoPosition(7, 8),
                    new GeoPosition(5, 6),
                }),
            });

            Assert.AreEqual(2, polygon.Coordinates.Count);
            Assert.AreEqual(2, polygon.Coordinates.Count());

            Assert.AreEqual(1, polygon.Coordinates[0][0][0]);
            Assert.AreEqual(2, polygon.Coordinates[0][0][1]);

            Assert.AreEqual(3, polygon.Coordinates[0][1][0]);
            Assert.AreEqual(4, polygon.Coordinates[0][1][1]);

            Assert.AreEqual(3, polygon.Coordinates[0][2][0]);
            Assert.AreEqual(4, polygon.Coordinates[0][2][1]);

            Assert.AreEqual(1, polygon.Coordinates[0][3][0]);
            Assert.AreEqual(2, polygon.Coordinates[0][3][1]);

            Assert.AreEqual(5, polygon.Coordinates[1][0][0]);
            Assert.AreEqual(6, polygon.Coordinates[1][0][1]);

            Assert.AreEqual(7, polygon.Coordinates[1][1][0]);
            Assert.AreEqual(8, polygon.Coordinates[1][1][1]);

            Assert.AreEqual(7, polygon.Coordinates[1][2][0]);
            Assert.AreEqual(8, polygon.Coordinates[1][2][1]);

            Assert.AreEqual(5, polygon.Coordinates[1][3][0]);
            Assert.AreEqual(6, polygon.Coordinates[1][3][1]);
        }

        [Test]
        public void PolygonCollectionCoordinatesWork()
        {
            var polygonCollection = new GeoPolygonCollection(new[]{
                new GeoPolygon(new[]
                {
                    new GeoLinearRing(new[] {
                        new GeoPosition(1, 2),
                        new GeoPosition(3, 4),
                        new GeoPosition(3, 4),
                        new GeoPosition(1, 2)
                    }),
                    new GeoLinearRing(new[] {
                        new GeoPosition(5, 6),
                        new GeoPosition(7, 8),
                        new GeoPosition(7, 8),
                        new GeoPosition(5, 6)
                    }),
                }),

                new GeoPolygon(new[]
                {
                    new GeoLinearRing(new[] {
                        new GeoPosition(9, 10),
                        new GeoPosition(11, 12),
                        new GeoPosition(11, 12),
                        new GeoPosition(9, 10)
                    }),
                    new GeoLinearRing(new[] {
                        new GeoPosition(13, 14),
                        new GeoPosition(15, 16),
                        new GeoPosition(15, 16),
                        new GeoPosition(13, 14)
                    }),
                }),
            });

            Assert.AreEqual(2, polygonCollection.Coordinates.Count);
            Assert.AreEqual(2, polygonCollection.Coordinates.Count());

            var c = polygonCollection.Coordinates[0];
            Assert.AreEqual(1, polygonCollection.Coordinates[0][0][0][0]);
            Assert.AreEqual(2, polygonCollection.Coordinates[0][0][0][1]);

            Assert.AreEqual(3, polygonCollection.Coordinates[0][0][1][0]);
            Assert.AreEqual(4, polygonCollection.Coordinates[0][0][1][1]);

            Assert.AreEqual(3, polygonCollection.Coordinates[0][0][2][0]);
            Assert.AreEqual(4, polygonCollection.Coordinates[0][0][2][1]);

            Assert.AreEqual(1, polygonCollection.Coordinates[0][0][3][0]);
            Assert.AreEqual(2, polygonCollection.Coordinates[0][0][3][1]);

            Assert.AreEqual(5, polygonCollection.Coordinates[0][1][0][0]);
            Assert.AreEqual(6, polygonCollection.Coordinates[0][1][0][1]);

            Assert.AreEqual(7, polygonCollection.Coordinates[0][1][1][0]);
            Assert.AreEqual(8, polygonCollection.Coordinates[0][1][1][1]);

            Assert.AreEqual(7, polygonCollection.Coordinates[0][1][2][0]);
            Assert.AreEqual(8, polygonCollection.Coordinates[0][1][2][1]);

            Assert.AreEqual(5, polygonCollection.Coordinates[0][1][3][0]);
            Assert.AreEqual(6, polygonCollection.Coordinates[0][1][3][1]);

            Assert.AreEqual(9, polygonCollection.Coordinates[1][0][0][0]);
            Assert.AreEqual(10, polygonCollection.Coordinates[1][0][0][1]);

            Assert.AreEqual(11, polygonCollection.Coordinates[1][0][1][0]);
            Assert.AreEqual(12, polygonCollection.Coordinates[1][0][1][1]);

            Assert.AreEqual(11, polygonCollection.Coordinates[1][0][2][0]);
            Assert.AreEqual(12, polygonCollection.Coordinates[1][0][2][1]);

            Assert.AreEqual(9, polygonCollection.Coordinates[1][0][3][0]);
            Assert.AreEqual(10, polygonCollection.Coordinates[1][0][3][1]);

            Assert.AreEqual(13, polygonCollection.Coordinates[1][1][0][0]);
            Assert.AreEqual(14, polygonCollection.Coordinates[1][1][0][1]);

            Assert.AreEqual(15, polygonCollection.Coordinates[1][1][1][0]);
            Assert.AreEqual(16, polygonCollection.Coordinates[1][1][1][1]);

            Assert.AreEqual(15, polygonCollection.Coordinates[1][1][2][0]);
            Assert.AreEqual(16, polygonCollection.Coordinates[1][1][2][1]);

            Assert.AreEqual(13, polygonCollection.Coordinates[1][1][3][0]);
            Assert.AreEqual(14, polygonCollection.Coordinates[1][1][3][1]);
        }
    }
}