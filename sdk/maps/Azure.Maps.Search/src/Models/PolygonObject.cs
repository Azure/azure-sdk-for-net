// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Maps.Common;
using System.Collections.Generic;
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
            string providerID = default;
            GeoObject geometryData = default;
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
                    foreach (var geoProperty in property.Value.EnumerateObject())
                    {
                        if (geoProperty.NameEquals("type"))
                        {
                            string type = geoProperty.Value.GetString();
                            if (type == "FeatureCollection") {
                                geometryData = DeserializeFeatureCollection(property);
                            } else {
                                geometryData = DeserializeObject(property.Value);
                            }
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new PolygonObject(providerID, geometryData);
        }

        private static GeoObject DeserializeFeatureCollection(JsonProperty property) {
            GeoObject result = default;
            foreach (var geoProperty in property.Value.EnumerateObject()) {
                if (geoProperty.NameEquals("features")) {
                    List<GeoObject> array = new List<GeoObject>();
                    foreach (var item in geoProperty.Value.EnumerateArray())
                    {
                        foreach (var featureProperty in item.EnumerateObject()) {
                            if (featureProperty.NameEquals("geometry")) {
                                array.Add(DeserializeObject(featureProperty.Value));
                            }
                        }
                    }
                    result = new GeoCollection(array);
                    continue;
                }
            }
            return result;
        }

        private static GeoObject DeserializeObject(JsonElement value) {
            GeoObject geometryData = default;
            // The fastest path is .NET 6+ with no custom serializer
            #if NET6_0_OR_GREATER
            geometryData = JsonSerializer.Deserialize<GeoObject>(value);
            #else
            // Copy the document so we can parse the data again
            ArrayBufferWriter<byte> buffer = new();
            Utf8JsonWriter writer = new(buffer);
            value.WriteTo(writer);
            writer.Flush();
            geometryData = JsonSerializer.Deserialize<GeoObject>(buffer.WrittenSpan);
            #endif
            return geometryData;
        }
    }
}
