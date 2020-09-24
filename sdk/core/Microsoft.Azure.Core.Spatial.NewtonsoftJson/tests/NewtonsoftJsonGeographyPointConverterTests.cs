// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Azure.Core.Serialization;
using Microsoft.Spatial;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.Core.Spatial.NewtonsoftJson.Tests
{
    public class NewtonsoftJsonGeographyPointConverterTests
    {
        [Test]
        public void CanConvert()
        {
            NewtonsoftJsonGeographyPointConverter converter = new NewtonsoftJsonGeographyPointConverter();
            Assert.IsTrue(converter.CanConvert(typeof(GeographyPoint)));
        }

        [Test]
        public void ReadJson()
        {
            JsonSerializer serializer = JsonSerializer.CreateDefault();
            serializer.Converters.Add(new NewtonsoftJsonGeographyPointConverter());

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
            serializer.Converters.Add(new NewtonsoftJsonGeographyPointConverter());

            using StringWriter writer = new StringWriter();
            serializer.Serialize(writer, point);

            Assert.AreEqual(@"{""type"":""Point"",""coordinates"":[-121.726906,46.879967]}", writer.ToString());
        }
    }
}
