// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Weather.Models
{
    /// <summary> A valid `GeoJSON` geometry object. The type must be one of the seven valid GeoJSON geometry types - Point, MultiPoint, LineString, MultiLineString, Polygon, MultiPolygon and GeometryCollection. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1">RFC 7946</see> for details. </summary>
    internal partial class GeoJsonGeometry : GeoJsonObject
    {
        /// <summary> Initializes a new instance of GeoJsonGeometry. </summary>
        public GeoJsonGeometry()
        {
            Type = GeoJsonObjectType.GeoJsonGeometryCollection;
        }
    }
}
