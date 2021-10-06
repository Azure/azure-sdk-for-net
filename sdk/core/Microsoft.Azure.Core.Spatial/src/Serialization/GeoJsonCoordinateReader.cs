// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// The GeoJson standard essentially has four "schemas" for containing geography coordinates
    /// Level zero defines a Point within a single array of doubles for latitude, longitude, etc
    /// Level one, defines LineString and MultiPoint, both which are an array of points
    /// Level two, defines Polygon and MultiLineString, an array of an array of points
    /// Level three, defines MultiPolygon, an array of Polygons, so an array of an array of an array of points
    /// </summary>
    internal abstract class GeoJsonCoordinateReader
    {
        public abstract void Process(ref Utf8JsonReader reader);

        /// <summary>
        /// Accepts the GeoJson coordinates property, and iterates the top level array to determine
        /// which of the four schemas the coordinates match
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the GeoJson coordinates property</param>
        /// <returns>A reader which will parse out correct parser based on the schema detected.</returns>
        /// <exception cref="JsonException"></exception>
        public static GeoJsonCoordinateReader Create(ref Utf8JsonReader reader)
        {
            GeoJsonCoordinateReader result;

            reader.Expect(JsonTokenType.StartArray);

            int detectedLevel = 0;

            for (; reader.SkipComments() && reader.TokenType == JsonTokenType.StartArray; detectedLevel++)
            {
                if (detectedLevel == 4)
                {
                    throw new JsonException($"Deserialization failed. GeoJson property '{GeoJsonConstants.CoordinatesPropertyName}' does not contain recognizable GeoJson.");
                }
            }

            reader.Expect(JsonTokenType.Number);

            switch (detectedLevel)
            {
                case 0:
                    result = new LevelZeroGeoJsonCoordinateReader();
                    break;

                case 1:
                    result = new LevelOneGeoJsonCoordinateReader();
                    break;

                case 2:
                    result = new LevelTwoGeoJsonCoordinateReader();
                    break;

                default:
                    result = new LevelThreeGeoJsonCoordinateReader();
                    break;
            }

            result.Process(ref reader);

            return result;
        }

        /// <summary>
        /// Extracts a list of points read from a Utf8JsonReader
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in an array of points.</param>
        /// <returns>The list of points extracted</returns>
        protected static List<GeographyPoint> ReadPoints(ref Utf8JsonReader reader)
        {
            List<GeographyPoint> result = new List<GeographyPoint>();

            reader.Expect(JsonTokenType.Number);

            while (true)
            {
                GeographyPoint geographyPoint = ReadPoint(ref reader);

                result.Add(geographyPoint);

                reader.SkipComments();

                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                reader.SkipComments();

                reader.Expect(JsonTokenType.Number);
            }

            return result;
        }

        /// <summary>
        /// Extract a single point from a Utf8JsonReader
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in an array which defines a point</param>
        /// <returns>The point extracted</returns>
        protected static GeographyPoint ReadPoint(ref Utf8JsonReader reader)
        {
            double longitude = reader.GetDouble();

            reader.SkipComments();

            reader.Expect(JsonTokenType.Number);

            double latitude = reader.GetDouble();

            //TODO perhaps read M and / or Z??? Gotta check the spec

            do
            {
                reader.SkipComments();
            } while (reader.TokenType != JsonTokenType.EndArray);

            return GeographyPoint.Create(latitude, longitude);
        }

        /// <summary>
        /// The Geography a derived class read from a Utf8JsonReader. Some schema levels support more
        /// than one Geography type, e.g. level 1 supports LineString and MultiPoint, which are both an
        /// array of points. The type argument informs which of the two types to create and return
        /// </summary>
        /// <param name="type">The type read from the GeoJson type property</param>
        /// <returns>The Geography parsed by a level 0,1,2,3 reader</returns>
        public abstract Geography GetGeography(string type);
    }
}
