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
            Assert.That(SpatialProxyFactory.CanCreate(type), Is.EqualTo(expected));

        [Test]
        public void CreateNull()
        {
            Assert.That(SpatialProxyFactory.TryCreate(null, out GeographyProxy proxy), Is.False);
            Assert.IsNull(proxy);
        }

        [Test]
        public void CreateGeographyPoint()
        {
            GeographyPoint point = GeographyFactory.Point(1.0, 2.0);
            GeographyPointProxy proxy = new GeographyPointProxy(point);

            Assert.That(proxy.Value, Is.SameAs(point));
            Assert.That(proxy.Latitude, Is.EqualTo(1.0));
            Assert.That(proxy.Longitude, Is.EqualTo(2.0));
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

            Assert.That(proxy.Value, Is.SameAs(polygon));
            Assert.That(proxy.Rings.Count, Is.EqualTo(1));

            GeographyLineString line0 = polygon.Rings[0];
            GeographyLineStringProxy proxyLine0 = proxy.Rings[0];
            Assert.That(proxyLine0.Value, Is.SameAs(line0));
            Assert.That(line0.Points.Count, Is.EqualTo(5));
            Assert.That(proxyLine0.Points.Count, Is.EqualTo(line0.Points.Count));

            for (int i = 0; i < line0.Points.Count; i++)
            {
                Assert.That(proxyLine0.Points[i].Latitude, Is.EqualTo(line0.Points[i].Latitude));
                Assert.That(proxyLine0.Points[i].Longitude, Is.EqualTo(line0.Points[i].Longitude));
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

            Assert.That(proxy.Value, Is.SameAs(line));
            Assert.That(line.Points.Count, Is.EqualTo(5));
            Assert.That(proxy.Points.Count, Is.EqualTo(line.Points.Count));

            for (int i = 0; i < line.Points.Count; i++)
            {
                Assert.That(proxy.Points[i].Latitude, Is.EqualTo(line.Points[i].Latitude));
                Assert.That(proxy.Points[i].Longitude, Is.EqualTo(line.Points[i].Longitude));
            }
        }

        [TestCaseSource(nameof(CreateFailsData))]
        public void CreateFails(object value)
        {
            Assert.That(SpatialProxyFactory.TryCreate(value, out GeographyProxy proxy), Is.False);
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
            Assert.That(SpatialProxyFactory.IsSupportedPoint(type), Is.EqualTo(expected));

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
