// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("GeoJsonLineString")]
    public partial class GeoJsonLineString
    {
        /// <summary> Deserialize json geometry </summary>
        #pragma warning disable AZC0014 // Allow using JsonElement
        public static GeoJsonLineString FromJsonElement(JsonElement element)
        {
        #pragma warning restore AZC0014
            return GeoJsonLineString.DeserializeGeoJsonLineString(element);
        }
    }
}
