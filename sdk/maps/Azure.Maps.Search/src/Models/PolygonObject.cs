// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.GeoJson;
using System.Text.Json;

namespace Azure.Maps.Search.Models
{
    /// <summary> The classification for the POI being returned. </summary>
    [CodeGenModel("Polygon")]
    public partial class PolygonObject
    {
        /// <summary> ID of the returned entity. </summary>
        [CodeGenMember("ProviderID")]
        public string ProviderId { get; }
        /// <summary> Geometry data in GeoJSON format. Please refer to [RFC 7946](https://tools.ietf.org/html/rfc7946) for details. Present only if &quot;error&quot; is not present. </summary>
        [CodeGenMember("GeometryData")]
        public GeoObject GeometryData { get; }

        internal static PolygonObject DeserializePolygonObject(JsonElement element)
        {
            Optional<string> providerID = default;
            Optional<GeoObject> geometryData = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("providerID"))
                {
                    providerID = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("geometryData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    // The fastest path is .NET 6+ with no custom serializer
                    #if NET6_0_OR_GREATER
                    geometryData = JsonSerializer.Deserialize<GeoObject>(property.Value);
                    #else
                    // Copy the document so we can parse the data again
                    ArrayBufferWriter<byte> buffer = new();
                    Utf8JsonWriter writer = new(buffer);
                    property.Value.WriteTo(writer);
                    writer.Flush();
                    geometryData = JsonSerializer.Deserialize<GeoObject>(buffer.WrittenSpan);
                    #endif
                    continue;
                }
            }
            return new PolygonObject(providerID.Value, geometryData.Value);
        }
    }
}
