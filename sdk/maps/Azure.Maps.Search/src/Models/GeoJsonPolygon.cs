// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("GeoJsonPolygon")]
    internal partial class GeoJsonPolygon
    {
        /// <summary> Deserialize json geometry </summary>
        #pragma warning disable AZC0014 // Allow using JsonElement
        public static GeoJsonPolygon FromJsonElement(JsonElement element)
        {
        #pragma warning restore AZC0014
            return GeoJsonPolygon.DeserializeGeoJsonPolygon(element);
        }
    }
}
