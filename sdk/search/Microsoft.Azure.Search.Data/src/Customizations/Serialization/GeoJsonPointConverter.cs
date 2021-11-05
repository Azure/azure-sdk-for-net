// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Reflection;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Converts between <see cref="Microsoft.Spatial.GeographyPoint" /> objects and Geo-JSON points.
    /// </summary>
    internal class GeoJsonPointConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            typeof(GeographyPoint).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            reader.ReadGeoJsonPoint();

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            writer.WriteGeoJsonPoint((GeographyPoint)value);
    }
}
