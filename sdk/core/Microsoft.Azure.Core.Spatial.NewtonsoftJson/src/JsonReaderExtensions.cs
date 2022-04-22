// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A collection of extension methods for JsonReader.
    /// </summary>
    internal static class JsonReaderExtensions
    {
        /// <summary>
        /// Extracts the data associated with a MultiPolygon.
        /// </summary>
        /// <param name="reader">A JsonReader positioned at the first number in a linestring.</param>
        /// <returns>A nested list which can be used to create a MultiPolygon.</returns>
        public static List<List<List<GeographyPoint>>> ReadMultiPolygon(
            this JsonReader reader)
        {
            List<List<List<GeographyPoint>>> result = new List<List<List<GeographyPoint>>>();

            while (true)
            {
                List<List<GeographyPoint>> listOfList = reader.ReadPolygonOrMultiLineString();

                result.Add(listOfList);

                // Advance the reader, and determine if we've read the last Polygon in the MultiPolygon

                reader.Read();

                if (reader.TokenType == JsonToken.EndArray)
                {
                    break;
                }

                // There is another Polygon, advance the reader to the first number in the first ring's first linestring
                reader.Expect(JsonToken.StartArray);

                // The reader is positioned at the first ring
                reader.Read();
                reader.Expect(JsonToken.StartArray);

                // The reader is positioned at the first linestring
                reader.Read();
                reader.Expect(JsonToken.StartArray);

                // The reader is positioned at the first point
                reader.Read();
                // Ultimately ReadPoint() will call Expect(JsonTokenType.Number) so no need to duplicate here
            }

            return result;
        }

        /// <summary>
        /// Extracts the data associated with either a Polygon or a MultiLineString.
        /// </summary>
        /// <param name="reader">A JsonReader positioned at the first number in a linestring.</param>
        /// <returns>A nested list which can be used to create either a Polygon or MultiLineString.</returns>
        public static List<List<GeographyPoint>> ReadPolygonOrMultiLineString(
            this JsonReader reader)
        {
            List<List<GeographyPoint>> result = new List<List<GeographyPoint>>();

            while (true)
            {
                List<GeographyPoint> points = reader.ReadLineStringOrMultiPoint();

                result.Add(points);

                // Advance the reader, and determine if we've read the last Ring in the Polygon

                reader.Read();

                if (reader.TokenType == JsonToken.EndArray)
                {
                    break;
                }

                // There is another Ring, advance the reader to the first number in the first linestring
                reader.Expect(JsonToken.StartArray);

                // The reader is positioned at the first linestring
                reader.Read();
                reader.Expect(JsonToken.StartArray);

                // The reader is positioned at the first point
                reader.Read();
                // Ultimately ReadPoint() will call Expect(JsonTokenType.Number) so no need to duplicate here
            }

            return result;
        }

        /// <summary>
        /// Extracts a list of points from a JsonReader.
        /// </summary>
        /// <param name="reader">A JsonReader positioned at the first number in an array of points.</param>
        /// <returns>The list of points extracted</returns>
        public static List<GeographyPoint> ReadLineStringOrMultiPoint(this JsonReader reader)
        {
            List<GeographyPoint> result = new List<GeographyPoint>();

            while (true)
            {
                GeographyPoint geographyPoint = reader.ReadPoint();

                result.Add(geographyPoint);

                // Advance the reader, and determine if we've read the last point

                reader.Read();

                if (reader.TokenType == JsonToken.EndArray)
                {
                    break;
                }

                // There is another point
                reader.Expect(JsonToken.StartArray);

                // The reader is positioned at the next point
                reader.Read();
                // ReadPoint() will call Expect(JsonTokenType.Number) so no need to duplicate here
            }

            return result;
        }

        /// <summary>
        /// Extract a single point from a JsonReader
        /// </summary>
        /// <param name="reader">A JsonReader positioned at the first number in an array which defines a point</param>
        /// <returns>The point extracted</returns>
        /// <exception cref="JsonSerializationException"></exception>
        public static GeographyPoint ReadPoint(this JsonReader reader)
        {
            reader.ExpectNumber();

            double longitude = reader.ReadDouble();

            reader.Read();

            reader.ExpectNumber();

            double latitude = reader.ReadDouble();

            //TODO perhaps read M and / or Z??? Gotta check the spec

            do
            {
                reader.Read();
            } while (reader.TokenType != JsonToken.EndArray);

            return GeographyPoint.Create(latitude, longitude);
        }
    }
}
