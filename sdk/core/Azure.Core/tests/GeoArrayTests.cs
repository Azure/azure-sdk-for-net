// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class GeoArrayTests
    {
        [Test]
        public void PointCoordinatesWork()
        {
            var point = new GeoPoint(1, 2);

            Assert.That(point.Coordinates.Count, Is.EqualTo(2));
            Assert.That(point.Coordinates[0], Is.EqualTo(1));
            Assert.That(point.Coordinates[1], Is.EqualTo(2));
        }

        [Test]
        public void PointCoordinatesWork3()
        {
            var point = new GeoPoint(1, 2, 3);

            Assert.That(point.Coordinates.Count, Is.EqualTo(3));

            Assert.That(point.Coordinates[0], Is.EqualTo(1));
            Assert.That(point.Coordinates[1], Is.EqualTo(2));
            Assert.That(point.Coordinates[2], Is.EqualTo(3));
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

            Assert.That(pointCollection.Coordinates.Count, Is.EqualTo(2));
            Assert.That(pointCollection.Coordinates.Count(), Is.EqualTo(2));

            Assert.That(pointCollection.Coordinates[0][0], Is.EqualTo(1));
            Assert.That(pointCollection.Coordinates[0][1], Is.EqualTo(2));

            Assert.That(pointCollection.Coordinates[1][0], Is.EqualTo(3));
            Assert.That(pointCollection.Coordinates[1][1], Is.EqualTo(4));
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

            Assert.That(line.Coordinates.Count, Is.EqualTo(3));
            Assert.That(line.Coordinates.Count(), Is.EqualTo(3));

            Assert.That(line.Coordinates[0][0], Is.EqualTo(1));
            Assert.That(line.Coordinates[0][1], Is.EqualTo(2));

            Assert.That(line.Coordinates[1][0], Is.EqualTo(3));
            Assert.That(line.Coordinates[1][1], Is.EqualTo(4));

            Assert.That(line.Coordinates[2][0], Is.EqualTo(5));
            Assert.That(line.Coordinates[2][1], Is.EqualTo(6));
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

            Assert.That(lineCollection.Coordinates.Count, Is.EqualTo(2));
            Assert.That(lineCollection.Coordinates.Count(), Is.EqualTo(2));

            Assert.That(lineCollection.Coordinates[0][0][0], Is.EqualTo(1));
            Assert.That(lineCollection.Coordinates[0][0][1], Is.EqualTo(2));

            Assert.That(lineCollection.Coordinates[0][1][0], Is.EqualTo(3));
            Assert.That(lineCollection.Coordinates[0][1][1], Is.EqualTo(4));

            Assert.That(lineCollection.Coordinates[1][0][0], Is.EqualTo(5));
            Assert.That(lineCollection.Coordinates[1][0][1], Is.EqualTo(6));

            Assert.That(lineCollection.Coordinates[1][1][0], Is.EqualTo(7));
            Assert.That(lineCollection.Coordinates[1][1][1], Is.EqualTo(8));
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

            Assert.That(polygon.Coordinates.Count, Is.EqualTo(2));
            Assert.That(polygon.Coordinates.Count(), Is.EqualTo(2));

            Assert.That(polygon.Coordinates[0][0][0], Is.EqualTo(1));
            Assert.That(polygon.Coordinates[0][0][1], Is.EqualTo(2));

            Assert.That(polygon.Coordinates[0][1][0], Is.EqualTo(3));
            Assert.That(polygon.Coordinates[0][1][1], Is.EqualTo(4));

            Assert.That(polygon.Coordinates[0][2][0], Is.EqualTo(3));
            Assert.That(polygon.Coordinates[0][2][1], Is.EqualTo(4));

            Assert.That(polygon.Coordinates[0][3][0], Is.EqualTo(1));
            Assert.That(polygon.Coordinates[0][3][1], Is.EqualTo(2));

            Assert.That(polygon.Coordinates[1][0][0], Is.EqualTo(5));
            Assert.That(polygon.Coordinates[1][0][1], Is.EqualTo(6));

            Assert.That(polygon.Coordinates[1][1][0], Is.EqualTo(7));
            Assert.That(polygon.Coordinates[1][1][1], Is.EqualTo(8));

            Assert.That(polygon.Coordinates[1][2][0], Is.EqualTo(7));
            Assert.That(polygon.Coordinates[1][2][1], Is.EqualTo(8));

            Assert.That(polygon.Coordinates[1][3][0], Is.EqualTo(5));
            Assert.That(polygon.Coordinates[1][3][1], Is.EqualTo(6));
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

            Assert.That(polygonCollection.Coordinates.Count, Is.EqualTo(2));
            Assert.That(polygonCollection.Coordinates.Count(), Is.EqualTo(2));

            var c = polygonCollection.Coordinates[0];
            Assert.That(polygonCollection.Coordinates[0][0][0][0], Is.EqualTo(1));
            Assert.That(polygonCollection.Coordinates[0][0][0][1], Is.EqualTo(2));

            Assert.That(polygonCollection.Coordinates[0][0][1][0], Is.EqualTo(3));
            Assert.That(polygonCollection.Coordinates[0][0][1][1], Is.EqualTo(4));

            Assert.That(polygonCollection.Coordinates[0][0][2][0], Is.EqualTo(3));
            Assert.That(polygonCollection.Coordinates[0][0][2][1], Is.EqualTo(4));

            Assert.That(polygonCollection.Coordinates[0][0][3][0], Is.EqualTo(1));
            Assert.That(polygonCollection.Coordinates[0][0][3][1], Is.EqualTo(2));

            Assert.That(polygonCollection.Coordinates[0][1][0][0], Is.EqualTo(5));
            Assert.That(polygonCollection.Coordinates[0][1][0][1], Is.EqualTo(6));

            Assert.That(polygonCollection.Coordinates[0][1][1][0], Is.EqualTo(7));
            Assert.That(polygonCollection.Coordinates[0][1][1][1], Is.EqualTo(8));

            Assert.That(polygonCollection.Coordinates[0][1][2][0], Is.EqualTo(7));
            Assert.That(polygonCollection.Coordinates[0][1][2][1], Is.EqualTo(8));

            Assert.That(polygonCollection.Coordinates[0][1][3][0], Is.EqualTo(5));
            Assert.That(polygonCollection.Coordinates[0][1][3][1], Is.EqualTo(6));

            Assert.That(polygonCollection.Coordinates[1][0][0][0], Is.EqualTo(9));
            Assert.That(polygonCollection.Coordinates[1][0][0][1], Is.EqualTo(10));

            Assert.That(polygonCollection.Coordinates[1][0][1][0], Is.EqualTo(11));
            Assert.That(polygonCollection.Coordinates[1][0][1][1], Is.EqualTo(12));

            Assert.That(polygonCollection.Coordinates[1][0][2][0], Is.EqualTo(11));
            Assert.That(polygonCollection.Coordinates[1][0][2][1], Is.EqualTo(12));

            Assert.That(polygonCollection.Coordinates[1][0][3][0], Is.EqualTo(9));
            Assert.That(polygonCollection.Coordinates[1][0][3][1], Is.EqualTo(10));

            Assert.That(polygonCollection.Coordinates[1][1][0][0], Is.EqualTo(13));
            Assert.That(polygonCollection.Coordinates[1][1][0][1], Is.EqualTo(14));

            Assert.That(polygonCollection.Coordinates[1][1][1][0], Is.EqualTo(15));
            Assert.That(polygonCollection.Coordinates[1][1][1][1], Is.EqualTo(16));

            Assert.That(polygonCollection.Coordinates[1][1][2][0], Is.EqualTo(15));
            Assert.That(polygonCollection.Coordinates[1][1][2][1], Is.EqualTo(16));

            Assert.That(polygonCollection.Coordinates[1][1][3][0], Is.EqualTo(13));
            Assert.That(polygonCollection.Coordinates[1][1][3][1], Is.EqualTo(14));
        }
    }
}
