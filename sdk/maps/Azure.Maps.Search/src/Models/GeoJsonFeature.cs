// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("GeoJsonFeature")]
    public partial class GeoJsonFeature
    {
        internal static GeoJsonFeature DeserializeGeoJsonFeature(JsonElement element)
        {
            if (element.TryGetProperty("geometry", out JsonElement geo))
            {
                if (geo.TryGetProperty("type", out JsonElement discriminator))
                {
                    switch (discriminator.GetString())
                    {
                        case "Point": return GeoJsonCircleFeature.DeserializeGeoJsonCircleFeature(element);
                        case "Polygon": return GeoJsonPolygonFeature.DeserializeGeoJsonPolygonFeature(element);
                    }
                }
            }

            GeoJsonGeometry geometry = default;
            Optional<object> properties = default;
            Optional<string> id = default;
            Optional<string> featureType = default;
            string type = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("geometry"))
                {
                    geometry = GeoJsonGeometry.DeserializeGeoJsonGeometry(property.Value);
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    properties = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("featureType"))
                {
                    featureType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
            }
            return new GeoJsonFeature(type, geometry, properties.Value, id.Value, featureType.Value);
        }
    }
}
