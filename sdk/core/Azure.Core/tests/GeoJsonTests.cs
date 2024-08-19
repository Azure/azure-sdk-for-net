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
            Assert.AreEqual("[1, 2, 3, 4]", new GeoBoundingBox(1, 2, 3, 4).ToString());
            Assert.AreEqual("[1, 2, 5, 3, 4, 6]", new GeoBoundingBox(1, 2, 3, 4, 5, 6).ToString());
        }

        [Test]
        public void GeoObjectToStringReturnsSerializedRepresentation()
        {
            var point = new GeoPoint(1, 2);
            Assert.AreEqual("{\"type\":\"Point\",\"coordinates\":[1,2]}", point.ToString());
        }

        [Test]
        public void GeoObjectParseParsesJson()
        {
            var point = GeoPoint.Parse("{\"type\":\"Point\",\"coordinates\":[1,2]}");
            Assert.IsInstanceOf<GeoPoint>(point);
            Assert.AreEqual(((GeoPoint)point).Coordinates, new GeoPosition(1, 2));
        }
    }
}