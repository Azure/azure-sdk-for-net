// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Spatial
{
    public class SpatialProxyFactoryTests
    {
        [TestCase(null, false)]
        [TestCase(typeof(object), false)]
        [TestCase(typeof(int), false)]
        [TestCase(typeof(GeoPoint), true)]
        [TestCase(typeof(GeoPointCollection), false)]
        [TestCase(typeof(GeoPosition), false)]
        [TestCase(typeof(GeoLinearRing), false)]
        [TestCase(typeof(GeoPolygon), true)]
        [TestCase(typeof(GeoPolygonCollection), false)]
        [TestCase(typeof(GeoLineString), true)]
        [TestCase(typeof(GeoLineStringCollection), false)]
        public void CanCreate(Type type, bool expected) =>
            Assert.AreEqual(expected, SpatialProxyFactory.CanCreate(type));

        [Test]
        public void CreateNull()
        {
            Assert.IsFalse(SpatialProxyFactory.TryCreate(null, out GeoObjectProxy proxy));
            Assert.IsNull(proxy);
        }

        [Test]
        public void CreateGeographyPoint()
        {
            GeoPoint point = new(1.0, 2.0);
            GeoPointProxy proxy = new(point);

            Assert.AreSame(point, proxy.Value);
            Assert.AreEqual(1.0, proxy.Coordinates.Longitude);
            Assert.AreEqual(2.0, proxy.Coordinates.Latitude);
        }

        [Test]
        public void CreateGeographyPolygon()
        {
            GeoPolygon polygon = new(new GeoPosition[]
            {
                new GeoPosition(0.0, 0.0),
                new GeoPosition(1.0, 0.0),
                new GeoPosition(1.0, 1.0),
                new GeoPosition(0.0, 1.0),
                new GeoPosition(0.0, 0.0),
            });

            GeoPolygonProxy proxy = new(polygon);

            Assert.AreSame(polygon, proxy.Value);
            Assert.AreEqual(1, proxy.Rings.Count);

            GeoLinearRing ring0 = polygon.Rings[0];
            GeoLinearRingProxy proxyRing0 = proxy.Rings[0];
            Assert.AreSame(ring0, proxyRing0.Value);
            Assert.AreEqual(5, ring0.Coordinates.Count);
            Assert.AreEqual(ring0.Coordinates.Count, proxyRing0.Coordinates.Count);

            for (int i = 0; i < ring0.Coordinates.Count; i++)
            {
                Assert.AreEqual(ring0.Coordinates[i].Latitude, proxyRing0.Coordinates[i].Latitude);
                Assert.AreEqual(ring0.Coordinates[i].Longitude, proxyRing0.Coordinates[i].Longitude);
            }
        }

        [Test]
        public void CreateGeographyLineString()
        {
            GeoLineString line = new(new GeoPosition[]
            {
                new GeoPosition(0.0, 0.0),
                new GeoPosition(1.0, 0.0),
                new GeoPosition(1.0, 1.0),
                new GeoPosition(0.0, 1.0),
                new GeoPosition(0.0, 0.0),
            });

            GeoLineStringProxy proxy = new(line);

            Assert.AreSame(line, proxy.Value);
            Assert.AreEqual(5, line.Coordinates.Count);
            Assert.AreEqual(line.Coordinates.Count, proxy.Coordinates.Count);

            for (int i = 0; i < line.Coordinates.Count; i++)
            {
                Assert.AreEqual(line.Coordinates[i].Latitude, proxy.Coordinates[i].Latitude);
                Assert.AreEqual(line.Coordinates[i].Longitude, proxy.Coordinates[i].Longitude);
            }
        }

        [TestCaseSource(nameof(CreateFailsData))]
        public void CreateFails(object value)
        {
            Assert.IsFalse(SpatialProxyFactory.TryCreate(value, out GeoObjectProxy proxy));
            Assert.IsNull(proxy);
        }

        [TestCase(null, false)]
        [TestCase(typeof(object), false)]
        [TestCase(typeof(int), false)]
        [TestCase(typeof(GeoPoint), true)]
        [TestCase(typeof(GeoLinearRing), false)]
        [TestCase(typeof(GeoLineString), false)]
        [TestCase(typeof(GeoPolygon), false)]
        [TestCase(typeof(GeoPosition), false)]
        public void IsSupportedPoint(Type type, bool expected) =>
            Assert.AreEqual(expected, SpatialProxyFactory.IsSupportedPoint(type));

        private static IEnumerable CreateFailsData => new[]
        {
            new TestCaseData(new object()),
            new TestCaseData(1),
            new TestCaseData(new GeoPosition(1.0, 2.0)),
        };
    }
}
