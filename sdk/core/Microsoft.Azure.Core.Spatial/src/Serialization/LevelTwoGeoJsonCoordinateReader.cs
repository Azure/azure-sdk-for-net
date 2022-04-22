// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Advances a Utf8JsonReader identified to contain either a Polygon or MultiLineString.
    /// </summary>
    /// <remarks>
    /// Both Polygon and MultiLineString are an array of an array of points. When Process is called,
    /// depending on the positioning of the GeoJson properties, the GeoJson 'type' property may not
    /// have been read, so the reader processes the GeoJson coordinates property and creates a list of
    /// a List of GeographyPoints. Once both the type and coordinates properties have been read,
    /// GetGeography will be called, and the reader will either create a Polygon or MultiLineString,
    /// or raise an exception if the type argument is not Polygon or MultiLineString.
    /// </remarks>
    internal class LevelTwoGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected List<List<GeographyPoint>> Points { get; set; }

        /// <summary>
        /// Converts the Points array of an array into either a Polygon or MultiLineString
        /// </summary>
        /// <param name="type">The GeoJson type read from the 'type' property</param>
        /// <returns>The Geography created from the Points array of an array</returns>
        /// <exception cref="JsonException">Invalid GeoJson, e.g. 'type' property specifies Polygon
        /// where as the coordinates property contains a LineString</exception>
        public override Geography GetGeography(string type)
        {
            if (type == GeoJsonConstants.PolygonTypeName)
            {
                return GeographyFactory.Polygon().Create(Points);
            }

            else if (type == GeoJsonConstants.MultiLineStringTypeName)
            {
                return GeographyFactory.MultiLineString().Create(Points);
            }

            else
            {
                throw new JsonException($"Invalid GeoJson: type '{type}' does not match coordinates provided.");
            }
        }

        /// <summary>
        /// Extracts an array of an array of points from a Utf8JsonReader
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in the first array</param>
        public override void Process(ref Utf8JsonReader reader)
        {
            Points = reader.ReadPolygonOrMultiLineString();
        }
    }
}
