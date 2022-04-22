// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using Newtonsoft.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Advances a JsonReader identified to contain a Point.
    /// </summary>
    /// <remarks>
    /// A GeographyPoint is an array of typically two numbers i.e. the coordinates. When Process is called,
    /// depending on the positioning of the GeoJson properties, the GeoJson 'type' property may not have been
    /// read, so the reader processes the GeoJson coordinates property and creates a single GeographyPoint.
    /// Once both the type and coordinates properties have been read, GetGeography will be called, and the reader
    /// will either return the parsed GeographyPoint or throw an exception if the type argument is not Point.
    /// </remarks>
    internal class LevelZeroGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected GeographyPoint GeographyPoint { get; set; }

        public override Geography GetGeography(string type)
        {
            if (type == GeoJsonConstants.PointTypeName)
            {
                return GeographyPoint;
            }

            throw new JsonSerializationException($"Invalid GeoJson: type '{type}' does not match coordinates provided.");
        }

        public override void Process(JsonReader reader)
        {
            GeographyPoint = reader.ReadPoint();
        }
    }
}
