// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using Newtonsoft.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Advances a JsonReader positioned at coordinates property to identify GeoJson type.
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
        /// <summary>
        /// Advances the JsonReader and extracts the points which compose a Geography.
        /// </summary>
        /// <param name="reader"></param>
        public abstract void Process(JsonReader reader);

        /// <summary>
        /// Accepts the GeoJson coordinates property, and iterates the top level array to determine
        /// which of the four schemas the coordinates match.
        /// </summary>
        /// <param name="reader">A JsonReader positioned at the GeoJson coordinates property.</param>
        /// <returns>A reader which will parse out correct parser based on the schema detected.</returns>
        /// <exception cref="JsonSerializationException"></exception>
        public static GeoJsonCoordinateReader Create(JsonReader reader)
        {
            GeoJsonCoordinateReader result;

            reader.Expect(JsonToken.StartArray);

            int detectedLevel = 0;

            // How many nested StartArray tokens we find identifies which of the four schemas we're dealing with
            for (; reader.Read() && reader.TokenType == JsonToken.StartArray; detectedLevel++)
            {
                if (detectedLevel == 4)
                {
                    throw new JsonSerializationException($"Deserialization failed: GeoJson property '{GeoJsonConstants.CoordinatesPropertyName}' does not contain recognizable GeoJson.");
                }
            }

            reader.ExpectNumber();

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

            result.Process(reader);

            return result;
        }

        /// <summary>
        /// Returns a Geography created with the set of points extracted during the call to Process.
        /// </summary>
        /// <remarks>
        /// GetGeography will be called only after both the type and coordinates GeoJson properties have
        /// been read. As both LineString and MultiPoint share the same schema, a reader cannot know which
        /// type to create from the points alone. The same is true for Polygon and MultiLineString.
        /// </remarks>
        /// <param name="type">The type read from the GeoJson type property.</param>
        /// <returns>The Geography created by a level zero, one, two, or three reader.</returns>
        public abstract Geography GetGeography(string type);
    }
}
