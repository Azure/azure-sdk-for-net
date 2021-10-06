// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    internal class LevelTwoGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected List<List<GeographyPoint>> Points { get; set; }

        public override Geography GetGeography(string type)
        {
            if (type == GeoJsonConstants.PolygonTypeName)
            {
                return GeographyFactory.Polygon().Create(Points);
            }

            else if (type == GeoJsonConstants.MultiLineStringTypeName)
            {
                return GeographyFactory.MultiLineString().Create(Points);
            }

            else
            {
                throw new JsonException($"Invalid GeoJson. type: {type} does not match coordinates provided");
            }
        }

        public override void Process(ref Utf8JsonReader reader)
        {
            Points = new List<List<GeographyPoint>>();

            while (true)
            {
                List<GeographyPoint> points = ReadPoints(ref reader);

                Points.Add(points);

                reader.SkipComments();

                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                reader.SkipComments();

                reader.SkipComments();
            }
        }
    }
}
