// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    internal class LevelThreeGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected List<GeographyPolygon> Polygons { get; set; }

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
