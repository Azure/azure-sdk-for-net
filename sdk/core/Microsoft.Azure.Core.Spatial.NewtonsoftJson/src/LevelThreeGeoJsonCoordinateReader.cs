// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Advances a JsonReader identified to contain a MultiPolygon.
    /// </summary>
    /// <remarks>
    ///  A MultiPolygon is an array of Polygons. When Process is called, depending on the positioning
    /// of the GeoJson properties, the GeoJson 'type' property may not have been read, so the reader
    /// processes the GeoJson coordinates property and creates a list of GeographyPolygon. Once both
    /// the type and coordinates properties have been read, GetGeography will be called, and the reader
    /// will either create a MultiPolygon, or throw an exception if the type argument is not MultiPolygon.
    /// </remarks>
    internal class LevelThreeGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected List<List<List<GeographyPoint>>> Points { get; set; }

        /// <summary>
        /// Converts the Polygons array into a MultiPolygon
        /// </summary>
        /// <param name="type">The GeoJson type read from the 'type' property</param>
        /// <returns>The MultiPolygon created from the Polygons array</returns>
        /// <exception cref="JsonSerializationException">Invalid GeoJson, e.g. 'type' property specifies Polygon
        /// where as the coordinates property contains a MultiPolygon</exception>
        public override Geography GetGeography(string type)
        {
            if (type == GeoJsonConstants.MultiPolygonTypeName)
            {
                return GeographyFactory.MultiPolygon().Create(Points);
            }

            else
            {
                throw new JsonSerializationException($"Invalid GeoJson: type '{type}' does not match coordinates provided.");
            }
        }

        /// <summary>
        /// Extract an array of Polygons from the JsonReader
        /// </summary>
        /// <param name="reader">A JsonReader positioned at the first number in the MultiPolygon</param>
        public override void Process(JsonReader reader)
        {
            Points = reader.ReadMultiPolygon();
        }
    }
}
