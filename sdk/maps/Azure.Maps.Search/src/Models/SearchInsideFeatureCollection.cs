// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("SearchInsideFeatureCollection")]
    public partial class SearchInsideFeatureCollection
    {
        /// <summary> Deserialize json geometry collection </summary>
        #pragma warning disable AZC0014 // Allow using JsonElement
        public static SearchInsideFeatureCollection FromJsonElement(JsonElement element)
        {
        #pragma warning restore AZC0014
            IList<GeoJsonFeature> features = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("features"))
                {
                    List<GeoJsonFeature> array = new List<GeoJsonFeature>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(GeoJsonFeature.DeserializeGeoJsonFeature(item));
                    }
                    features = array;
                    continue;
                }
            }
            return new SearchInsideFeatureCollection(features);
        }
    }
}
