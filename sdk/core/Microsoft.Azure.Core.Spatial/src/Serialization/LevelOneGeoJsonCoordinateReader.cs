// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Advances a Utf8JsonReader identified to contain either a LineString or MultiPoint.
    /// </summary>
    /// <remarks>
    /// Both LineString and MultiPoint are an array of points. When Process is called, depending on
    /// the positioning of the GeoJson properties, the GeoJson 'type' property may not have been read,
    /// so the reader processes the GeoJson coordinates property and creates a list of GeographyPoints.
    /// Once both the type and coordinates properties have been read, GetGeography will be called, and
    /// the reader will either create a LineString or MultiPoint, or raise an exception if the type
    /// argument is not LineString or MultiPoint.
    /// </remarks>
    internal class LevelOneGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected List<GeographyPoint> Points { get; set; }

        /// <summary>
        /// Converts the Points array into either a LineString or MultiPoint
        /// </summary>
        /// <param name="type">The GeoJson type read from the 'type' property</param>
        /// <returns>The Geography created from the Points array</returns>
        /// <exception cref="JsonException">Invalid GeoJson, e.g. 'type' property specifies Polygon
        /// where as the coordinates property contains a LineString</exception>
        public override Geography GetGeography(string type)
        {
            if (type == GeoJsonConstants.LineStringTypeName)
            {
                return GeographyFactory.LineString().Create(Points);
            }

            else if (type == GeoJsonConstants.MultiPointTypeName)
            {
                return GeographyFactory.MultiPoint().Create(Points);
            }

            else
            {
                throw new JsonException($"Invalid GeoJson: type '{type}' does not match coordinates provided.");
            }
        }

        /// <summary>
        /// Extracts an array of points from a Utf8JsonReader
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in an array</param>
        public override void Process(ref Utf8JsonReader reader)
        {
            Points = reader.ReadLineStringOrMultiPoint();
        }
    }
}
