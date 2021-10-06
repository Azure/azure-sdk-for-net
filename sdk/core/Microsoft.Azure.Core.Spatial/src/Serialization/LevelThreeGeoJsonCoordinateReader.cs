// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A MultiPolygon is an array of Polygons. When Process is called, depending on the positioning
    /// of the GeoJson properties, the GeoJson 'type' property may not have been read, so the reader
    /// processes the GeoJson coordinates property and creates a list of GeographyPolygon. Once both
    /// the type and coordinates properties have been read, GetGeography will be called, and the reader
    /// will either create a MultiPolygon, or throw an exception if the type argument is not MultiPolygon.
    /// </summary>
    internal class LevelThreeGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected List<GeographyPolygon> Polygons { get; set; }

        /// <summary>
        /// Converts the Polygons array into a MultiPolygon
        /// </summary>
        /// <param name="type">The GeoJson type read from the 'type' property</param>
        /// <returns>The MultiPolygon created from the Polygons array</returns>
        /// <exception cref="JsonException">Invalid GeoJson, e.g. 'type' property specifies Polygon
        /// where as the coordinates property contains a MultiPolygon</exception>
        public override Geography GetGeography(string type)
        {
            if (type == GeoJsonConstants.MultiPolygonTypeName)
            {
                return GeographyFactory.MultiPolygon().Create(Polygons);
            }

            else
            {
                throw new JsonException($"Invalid GeoJson. type: {type} does not match coordinates provided");
            }
        }

        /// <summary>
        /// Extract an array of Polygons from the Utf8JsonReader
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in the MultiPolygon</param>
        public override void Process(ref Utf8JsonReader reader)
        {
            Polygons = new List<GeographyPolygon>();

            while (true)
            {
                GeographyPolygon polygon = ReadPolygon(ref reader);

                Polygons.Add(polygon);

                reader.SkipComments();

                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                reader.SkipComments();

                reader.SkipComments();

                reader.SkipComments();
            }
        }

        /// <summary>
        /// Extracts a single Polygon from the Utf8JsonReader
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in the Polygon</param>
        /// <returns>The GeographyPolygon extracted from the reader</returns>
        private static GeographyPolygon ReadPolygon(ref Utf8JsonReader reader)
        {
            List<List<GeographyPoint>> geographyPoints = new List<List<GeographyPoint>>();

            reader.Expect(JsonTokenType.Number);

            while (true)
            {
                List<GeographyPoint> points = ReadPoints(ref reader);

                geographyPoints.Add(points);

                reader.SkipComments();

                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                reader.SkipComments();

                reader.SkipComments();
            }

            GeographyPolygon result = GeographyFactory.Polygon().Create(geographyPoints);

            return result;
        }
    }
}
