// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.GeoJson;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class GeoJsonTests
    {
        [Test]
        public void BoundingBoxToStringReturnsStringRepresentation()
        {
            Assert.That(new GeoBoundingBox(1, 2, 3, 4).ToString(), Is.EqualTo("[1, 2, 3, 4]"));
            Assert.That(new GeoBoundingBox(1, 2, 3, 4, 5, 6).ToString(), Is.EqualTo("[1, 2, 5, 3, 4, 6]"));
        }

        [Test]
        public void GeoObjectToStringReturnsSerializedRepresentation()
        {
            var point = new GeoPoint(1, 2);
            Assert.That(point.ToString(), Is.EqualTo("{\"type\":\"Point\",\"coordinates\":[1,2]}"));
        }

        [Test]
        public void GeoObjectParseParsesJson()
        {
            var point = GeoPoint.Parse("{\"type\":\"Point\",\"coordinates\":[1,2]}");
            Assert.That(point, Is.InstanceOf<GeoPoint>());
            Assert.That(new GeoPosition(1, 2), Is.EqualTo(((GeoPoint)point).Coordinates));
        }
    }
}
