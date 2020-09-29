// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Converts between <see cref="GeographyPoint" /> objects and Geo-JSON points.
    /// </summary>
    public class NewtonsoftJsonGeographyPointConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType) =>
            typeof(GeographyPoint).IsAssignableFrom(objectType);

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            reader.ReadGeoJsonPoint();

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            writer.WriteGeoJsonPoint((GeographyPoint)value);
    }
}
