// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A collection of extension methods for Utf8JsonReader.
    /// </summary>
    internal static class Utf8JsonReaderExtensions
    {
        /// <summary>
        /// Extracts the data associated with a MultiPolygon.
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in a linestring.</param>
        /// <returns>A nested list which can be used to create a MultiPolygon.</returns>
        public static List<List<List<GeographyPoint>>> ReadListOfListofList(
            this ref Utf8JsonReader reader)
        {
            List<List<List<GeographyPoint>>> result = new List<List<List<GeographyPoint>>>();

            while (true)
            {
                List<List<GeographyPoint>> listOfList = reader.ReadListOfList();

                result.Add(listOfList);

                // Advance the reader, and determine if we've read the last Polygon in the MultiPolygon

                reader.SkipComments();

                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                // There is another PolyGon, advance the reader to the first number in the first ring's first linestring
                reader.Expect(JsonTokenType.StartArray);

                // The reader is positioned at the first ring
                reader.SkipComments();
                reader.Expect(JsonTokenType.StartArray);

                // The reader is positioned at the first linestring
                reader.SkipComments();
                reader.Expect(JsonTokenType.StartArray);

                // The reader is positioned at the first point
                reader.SkipComments();
                // Ultimately ReadPoint() will call Expect(JsonTokenType.Number) so no need to duplicate here
            }

            return result;
        }

        /// <summary>
        /// Extracts the data associated with either a Polygon or a MultiLineString.
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in a linestring.</param>
        /// <returns>A nested list which can be used to create either a Polygon or MultiLineString.</returns>
        public static List<List<GeographyPoint>> ReadListOfList(
            this ref Utf8JsonReader reader)
        {
            List<List<GeographyPoint>> result = new List<List<GeographyPoint>>();

            while (true)
            {
                List<GeographyPoint> points = ReadPoints(ref reader);

                result.Add(points);

                // Advance the reader, and determine if we've read the last Ring in the Polygon

                reader.SkipComments();

                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                // There is another Ring, advance the reader to the first number in the first linestring
                reader.Expect(JsonTokenType.StartArray);

                // The reader is positioned at the first linestring
                reader.SkipComments();
                reader.Expect(JsonTokenType.StartArray);

                // The reader is positioned at the first point
                reader.SkipComments();
                // Ultimately ReadPoint() will call Expect(JsonTokenType.Number) so no need to duplicate here
            }

            return result;
        }

        /// <summary>
        /// Extracts a list of points from a Utf8JsonReader.
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in an array of points.</param>
        /// <returns>The list of points extracted</returns>
        public static List<GeographyPoint> ReadPoints(this ref Utf8JsonReader reader)
        {
            List<GeographyPoint> result = new List<GeographyPoint>();

            while (true)
            {
                GeographyPoint geographyPoint = ReadPoint(ref reader);

                result.Add(geographyPoint);

                // Advance the reader, and determine if we've read the last point

                reader.SkipComments();

                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                // There is another point
                reader.Expect(JsonTokenType.StartArray);

                // The reader is positioned at the next point
                reader.SkipComments();
                // ReadPoint() will call Expect(JsonTokenType.Number) so no need to duplicate here
            }

            return result;
        }

        /// <summary>
        /// Extract a single point from a Utf8JsonReader
        /// </summary>
        /// <param name="reader">A Utf8JsonReader positioned at the first number in an array which defines a point</param>
        /// <returns>The point extracted</returns>
        public static GeographyPoint ReadPoint(this ref Utf8JsonReader reader)
        {
            reader.Expect(JsonTokenType.Number);

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
    }
}
