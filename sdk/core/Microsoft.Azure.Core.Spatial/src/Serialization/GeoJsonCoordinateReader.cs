// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Advances a Utf8JsonReader positioned at coordinates property to identify GeoJson type.
    /// </summary>
    /// <remarks>
    /// The GeoJson standard essentially has four "schemas" for containing geography coordinates.
    /// <list type="bullet" >
    /// <item>
    /// <description>Level zero defines a Point an array of doubles for latitude, longitude, etc.</description>
    /// </item>
    /// <item>
    /// <description>
    /// Level one, defines a LineString or MultiPoint, both which are an array of points.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Level two, defines a Polygon or MultiLineString, an array of an array of points.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Level three, defines a MultiPolygon, an array of an array of an array of points.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    internal abstract class GeoJsonCoordinateReader
    {
        public abstract void Process(ref Utf8JsonReader reader);

        /// <summary>
        /// Accepts the GeoJson coordinates property, and iterates the top level array to determine
        /// which of the four schemas the coordinates match.
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the GeoJson coordinates property.</param>
        /// <returns>A reader which will parse out correct parser based on the schema detected.</returns>
        /// <exception cref="JsonException"></exception>
        public static GeoJsonCoordinateReader Create(ref Utf8JsonReader reader)
        {
            GeoJsonCoordinateReader result;

            reader.Expect(JsonTokenType.StartArray);

            int detectedLevel = 0;

            // How many nested StartArray tokens we find identifies which of the four schemas we're dealing with
            for (; reader.Read() && reader.TokenType == JsonTokenType.StartArray; detectedLevel++)
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
        /// The Geography a derived class read from a Utf8JsonReader. Some schema levels support more
        /// than one Geography type, e.g. level 1 supports LineString and MultiPoint, which are both an
        /// array of points. The type argument informs which of the two types to create and return.
        /// </summary>
        /// <param name="type">The type read from the GeoJson type property.</param>
        /// <returns>The Geography parsed by a level 0,1,2,3 reader.</returns>
        public abstract Geography GetGeography(string type);
    }
}
