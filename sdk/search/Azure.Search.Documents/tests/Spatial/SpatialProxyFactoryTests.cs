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
        [TestCase(typeof(GeographyPoint), false)]
        [TestCase(typeof(GeometryPoint), true)]
        [TestCase(typeof(GeographyPosition), false)]
        [TestCase(typeof(GeometryPosition), true)]
        [TestCase(typeof(GeographyPolygon), false)]
        [TestCase(typeof(GeometryPolygon), true)]
        [TestCase(typeof(GeographyLineString), false)]
        [TestCase(typeof(GeometryLineString), true)]
        public void CanCreate(Type type, bool expected) =>
            Assert.AreEqual(expected, SpatialProxyFactory.CanCreate(type));


        [Test]
        public void CreateNull() =>
            Assert.IsNull(SpatialProxyFactory.Create(null));

        [Test]
        public void CreateGeometryPoint()
        {
            GeometryPoint point = GeometryFactory.Point(1.0, 2.0);
            GeometryPointProxy proxy = new GeometryPointProxy(point);

            Assert.AreSame(point, proxy.Value);
            Assert.AreEqual(1.0, proxy.X);
            Assert.AreEqual(2.0, proxy.Y);
        }

        [Test]
        public void CreateGeometryPosition()
        {
            GeometryPosition position = new GeometryPosition(1.0, 2.0);
            GeometryPositionProxy proxy = new GeometryPositionProxy(position);

            Assert.AreSame(position, proxy.Value);
            Assert.AreEqual(1.0, proxy.X);
            Assert.AreEqual(2.0, proxy.Y);
        }

        [Test]
        public void CreateGeometryPolygon()
        {
            GeometryPolygon polygon = GeometryFactory
                .Polygon()
                .Ring(0.0, 0.0)
                .LineTo(1.0, 0.0)
                .LineTo(1.0, 1.0)
                .LineTo(0.0, 1.0)
                .LineTo(0.0, 0.0);
            GeometryPolygonProxy proxy = new GeometryPolygonProxy(polygon);

            Assert.AreSame(polygon, proxy.Value);
            Assert.AreEqual(1, proxy.Rings.Count);

            GeometryLineString line0 = polygon.Rings[0];
            GeometryLineStringProxy proxyLine0 = proxy.Rings[0];
            Assert.AreSame(line0, proxyLine0.Value);
            Assert.AreEqual(5, line0.Points.Count);
            Assert.AreEqual(line0.Points.Count, proxyLine0.Points.Count);

            for (int i = 0; i < line0.Points.Count; i++)
            {
                Assert.AreEqual(line0.Points[i].X, proxyLine0.Points[i].X);
                Assert.AreEqual(line0.Points[i].Y, proxyLine0.Points[i].Y);
            }
        }

        [Test]
        public void CreateGeometryLineString()
        {
            GeometryLineString line = GeometryFactory
                .LineString(0.0, 0.0)
                .LineTo(1.0, 0.0)
                .LineTo(1.0, 1.0)
                .LineTo(0.0, 1.0)
                .LineTo(0.0, 0.0);
            GeometryLineStringProxy proxy = new GeometryLineStringProxy(line);

            Assert.AreSame(line, proxy.Value);
            Assert.AreEqual(5, line.Points.Count);
            Assert.AreEqual(line.Points.Count, proxy.Points.Count);

            for (int i = 0; i < line.Points.Count; i++)
            {
                Assert.AreEqual(line.Points[i].X, proxy.Points[i].X);
                Assert.AreEqual(line.Points[i].Y, proxy.Points[i].Y);
            }
        }

        [TestCaseSource(nameof(CreateThrowsData))]
        public void CreateThrows(object value) =>
            Assert.Throws<NotSupportedException>(() => SpatialProxyFactory.Create(value));

        private static IEnumerable CreateThrowsData => new[]
        {
            new TestCaseData(new object()),
            new TestCaseData(1),
            new TestCaseData(GeographyFactory.Point(1.0, 2.0)),
            new TestCaseData(new GeographyPosition(1.0, 2.0)),
            new TestCaseData(GeometryFactory
                .Polygon()
                .Ring(0.0, 0.0)
                .LineTo(1.0, 0.0)
                .LineTo(1.0, 1.0)
                .LineTo(0.0, 1.0)
                .LineTo(0.0, 0.0)),
            new TestCaseData(GeometryFactory
                .LineString(0.0, 0.0)
                .LineTo(1.0, 0.0)
                .LineTo(1.0, 1.0)
                .LineTo(0.0, 1.0)
                .LineTo(0.0, 0.0)),
        };
    }
}
