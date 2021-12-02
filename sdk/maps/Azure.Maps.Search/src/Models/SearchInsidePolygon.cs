// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("SearchInsidePolygon")]
    public partial class SearchInsidePolygon
    {
        /// <summary> Initializes a new instance of SearchInsidePolygon. </summary>
        /// <param name="polygon"> `GeoJson Polygon` geometry type. </param>
        public SearchInsidePolygon(GeoJsonPolygon polygon): this(polygon.Coordinates) {}
    }
}
