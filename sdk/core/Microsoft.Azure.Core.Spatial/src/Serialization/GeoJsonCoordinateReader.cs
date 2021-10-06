// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    internal abstract class GeoJsonCoordinateReader
    {
        public abstract void Process(ref Utf8JsonReader reader);

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

        public abstract Geography GetGeography(string type);
    }
}
