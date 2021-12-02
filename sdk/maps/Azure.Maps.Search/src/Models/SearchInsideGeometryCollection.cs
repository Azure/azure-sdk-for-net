// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("SearchInsideGeometryCollection")]
    public partial class SearchInsideGeometryCollection
    {
        /// <summary> Initializes a new instance of SearchInsideGeometryCollection. </summary>
        /// <param name="geometries"> Contains a list of valid `GeoJSON` polygon geometry objects. </param>
        public SearchInsideGeometryCollection(IEnumerable<GeoJsonPolygon> geometries): this(geometries.Select(geometry => new SearchInsidePolygon(geometry))) {}

        /// <summary> Deserialize json geometry collection </summary>
        #pragma warning disable AZC0014 // Allow using JsonElement
        public static SearchInsideGeometryCollection FromJsonElement(JsonElement element)
        {
        #pragma warning restore AZC0014
            IList<GeoJsonPolygon> geometries = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("geometries"))
                {
                    List<GeoJsonPolygon> array = new List<GeoJsonPolygon>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(GeoJsonPolygon.DeserializeGeoJsonPolygon(item));
                    }
                    geometries = array;
                    continue;
                }
            }
            return new SearchInsideGeometryCollection(geometries);
        }
    }
}
