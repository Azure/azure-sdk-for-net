// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Converts between <c>Microsoft.Spatial</c> objects and Geo-JSON.
    /// </summary>
    public class NewtonsoftJsonMicrosoftSpatialGeoJsonConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType) =>
            // BUGBUG #15506: Check for all Geography derivatives.
            typeof(GeographyPoint).IsAssignableFrom(objectType);

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
            reader.ReadGeoJsonPoint();

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            writer.WriteGeoJsonPoint((GeographyPoint)value);
    }
}
