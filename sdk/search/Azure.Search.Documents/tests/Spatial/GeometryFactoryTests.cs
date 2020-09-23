// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using Microsoft.Spatial;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Spatial
{
    public class GeometryFactoryTests
    {
        [TestCase(null, false)]
        [TestCase(typeof(object), false)]
        [TestCase(typeof(int), false)]
        [TestCase(typeof(GeographyPoint), false)]
        [TestCase(typeof(GeometryPoint), true)]
        public void CanCreate(Type type, bool expected) =>
            Assert.AreEqual(expected, GeometryFactory.CanCreate(type));


        [Test]
        public void CreateNull() =>
            Assert.IsNull(GeometryFactory.Create(null));

        [Test]
        public void CreateGeometryPoint()
        {
            GeometryPoint point = GeometryPoint.Create(1.0, 2.0, 3.0);
            GeometryPointAdapter adapter = new GeometryPointAdapter(point);

            Assert.AreSame(point, adapter.Value);
            Assert.AreEqual(1.0, adapter.X);
            Assert.AreEqual(2.0, adapter.Y);
            Assert.AreEqual(3.0, adapter.Z);
            Assert.IsNull(adapter.M);
        }

        [TestCaseSource(nameof(CreateThrowsData))]
        public void CreateThrows(object value) =>
            Assert.Throws<NotSupportedException>(() => GeometryFactory.Create(value));

        private static IEnumerable CreateThrowsData => new[]
        {
            new TestCaseData(new object()),
            new TestCaseData(1),
            new TestCaseData(GeographyPoint.Create(1.0, 2.0, 3.0)),
        };
    }
}
