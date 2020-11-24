// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using Microsoft.Spatial;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Spatial
{
    public class SpatialProxyFactoryTests
    {
        [TestCase(null, false)]
        [TestCase(typeof(object), false)]
        [TestCase(typeof(int), false)]
        [TestCase(typeof(GeographyPoint), true)]
        [TestCase(typeof(GeometryPoint), false)]
        [TestCase(typeof(GeographyPosition), false)]
        [TestCase(typeof(GeometryPosition), false)]
        [TestCase(typeof(GeographyPolygon), true)]
        [TestCase(typeof(GeometryPolygon), false)]
        [TestCase(typeof(GeographyLineString), true)]
        [TestCase(typeof(GeometryLineString), false)]
        public void CanCreate(Type type, bool expected) =>
            Assert.AreEqual(expected, SpatialProxyFactory.CanCreate(type));

        [Test]
        public void CreateNull()
        {
            Assert.IsFalse(SpatialProxyFactory.TryCreate(null, out GeographyProxy proxy));
            Assert.IsNull(proxy);
        }

        [Test]
        public void CreateGeographyPoint()
        {
            GeographyPoint point = GeographyFactory.Point(1.0, 2.0);
            GeographyPointProxy proxy = new GeographyPointProxy(point);

            Assert.AreSame(point, proxy.Value);
            Assert.AreEqual(1.0, proxy.Latitude);
            Assert.AreEqual(2.0, proxy.Longitude);
        }

        [Test]
        public void CreateGeographyPolygon()
        {
            GeographyPolygon polygon = GeographyFactory
                .Polygon()
                .Ring(0.0, 0.0)
                .LineTo(1.0, 0.0)
                .LineTo(1.0, 1.0)
                .LineTo(0.0, 1.0)
                .LineTo(0.0, 0.0);
            GeographyPolygonProxy proxy = new GeographyPolygonProxy(polygon);

            Assert.AreSame(polygon, proxy.Value);
            Assert.AreEqual(1, proxy.Rings.Count);

            GeographyLineString line0 = polygon.Rings[0];
            GeographyLineStringProxy proxyLine0 = proxy.Rings[0];
            Assert.AreSame(line0, proxyLine0.Value);
            Assert.AreEqual(5, line0.Points.Count);
            Assert.AreEqual(line0.Points.Count, proxyLine0.Points.Count);

            for (int i = 0; i < line0.Points.Count; i++)
            {
                Assert.AreEqual(line0.Points[i].Latitude, proxyLine0.Points[i].Latitude);
                Assert.AreEqual(line0.Points[i].Longitude, proxyLine0.Points[i].Longitude);
            }
        }

        [Test]
        public void CreateGeographyLineString()
        {
            GeographyLineString line = GeographyFactory
                .LineString(0.0, 0.0)
                .LineTo(1.0, 0.0)
                .LineTo(1.0, 1.0)
                .LineTo(0.0, 1.0)
                .LineTo(0.0, 0.0);
            GeographyLineStringProxy proxy = new GeographyLineStringProxy(line);

            Assert.AreSame(line, proxy.Value);
            Assert.AreEqual(5, line.Points.Count);
            Assert.AreEqual(line.Points.Count, proxy.Points.Count);

            for (int i = 0; i < line.Points.Count; i++)
            {
                Assert.AreEqual(line.Points[i].Latitude, proxy.Points[i].Latitude);
                Assert.AreEqual(line.Points[i].Longitude, proxy.Points[i].Longitude);
            }
        }

        [TestCaseSource(nameof(CreateFailsData))]
        public void CreateFails(object value)
        {
            Assert.IsFalse(SpatialProxyFactory.TryCreate(value, out GeographyProxy proxy));
            Assert.IsNull(proxy);
        }

        [TestCase(null, false)]
        [TestCase(typeof(object), false)]
        [TestCase(typeof(int), false)]
        [TestCase(typeof(GeographyPoint), true)]
        [TestCase(typeof(GeometryPoint), false)]
        [TestCase(typeof(GeographyPosition), false)]
        [TestCase(typeof(GeometryPosition), false)]
        [TestCase(typeof(GeographyPolygon), false)]
        [TestCase(typeof(GeometryPolygon), false)]
        [TestCase(typeof(GeographyLineString), false)]
        [TestCase(typeof(GeometryLineString), false)]
        public void IsSupportedPoint(Type type, bool expected) =>
            Assert.AreEqual(expected, SpatialProxyFactory.IsSupportedPoint(type));

        private static IEnumerable CreateFailsData => new[]
        {
            new TestCaseData(new object()),
            new TestCaseData(1),
            new TestCaseData(GeometryFactory.Point(1.0, 2.0)),
            new TestCaseData(new GeometryPosition(1.0, 2.0)),
            new TestCaseData(GeographyFactory
                .Polygon()
                .Ring(0.0, 0.0)
                .LineTo(1.0, 0.0)
                .LineTo(1.0, 1.0)
                .LineTo(0.0, 1.0)
                .LineTo(0.0, 0.0)),
            new TestCaseData(GeographyFactory
                .LineString(0.0, 0.0)
                .LineTo(1.0, 0.0)
                .LineTo(1.0, 1.0)
                .LineTo(0.0, 1.0)
                .LineTo(0.0, 0.0)),
        };
    }
}
