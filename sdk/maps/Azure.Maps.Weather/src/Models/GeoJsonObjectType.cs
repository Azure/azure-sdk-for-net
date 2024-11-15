// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Maps.Weather.Models
{
    /// <summary> Specifies the `GeoJSON` type. Must be one of the nine valid GeoJSON object types - Point, MultiPoint, LineString, MultiLineString, Polygon, MultiPolygon, GeometryCollection, Feature and FeatureCollection. </summary>
    internal enum GeoJsonObjectType
    {
        /// <summary> `GeoJSON Point` geometry. </summary>
        GeoJsonPoint,
        /// <summary> `GeoJSON MultiPoint` geometry. </summary>
        GeoJsonMultiPoint,
        /// <summary> `GeoJSON LineString` geometry. </summary>
        GeoJsonLineString,
        /// <summary> `GeoJSON MultiLineString` geometry. </summary>
        GeoJsonMultiLineString,
        /// <summary> `GeoJSON Polygon` geometry. </summary>
        GeoJsonPolygon,
        /// <summary> `GeoJSON MultiPolygon` geometry. </summary>
        GeoJsonMultiPolygon,
        /// <summary> `GeoJSON GeometryCollection` geometry. </summary>
        GeoJsonGeometryCollection,
        /// <summary> `GeoJSON Feature` object. </summary>
        GeoJsonFeature,
        /// <summary> `GeoJSON FeatureCollection` object. </summary>
        GeoJsonFeatureCollection
    }
}
