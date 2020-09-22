// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;

namespace Microsoft.Spatial.NewtonsoftJson.Tests
{
    public class GeographyPointConverterTests
    {
        [Test]
        public void CanConvert()
        {
            GeographyPointConverter converter = new GeographyPointConverter();
            Assert.IsTrue(converter.CanConvert(typeof(GeographyPoint)));
        }

        [Test]
        public void ReadJson()
        {
            JsonSerializer serializer = JsonSerializer.CreateDefault();
            serializer.Converters.Add(new GeographyPointConverter());

            using StringReader reader = new StringReader(@"{""type"":""Point"",""coordinates"":[-121.726906,46.879967]}");
            using JsonReader jsonReader = new JsonTextReader(reader);
            GeographyPoint point = serializer.Deserialize<GeographyPoint>(jsonReader);

            Assert.AreEqual(point.Latitude, 46.879967);
            Assert.AreEqual(point.Longitude, -121.726906);
        }

        [Test]
        public void WriteJson()
        {
            GeographyPoint point = GeographyPoint.Create(46.879967, -121.726906);

            JsonSerializer serializer = JsonSerializer.CreateDefault();
            serializer.Converters.Add(new GeographyPointConverter());

            using StringWriter writer = new StringWriter();
            serializer.Serialize(writer, point);

            Assert.AreEqual(@"{""type"":""Point"",""coordinates"":[-121.726906,46.879967]}", writer.ToString());
        }
    }
}
