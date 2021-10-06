// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    internal class LevelOneGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected List<GeographyPoint> Points { get; set; }

        public override Geography GetGeography(string type)
        {
            if (type == GeoJsonConstants.LineStringTypeName)
            {
                return GeographyFactory.LineString().Create(Points);
            }

            else if (type == GeoJsonConstants.MultiPointTypeName)
            {
                return GeographyFactory.MultiPoint().Create(Points);
            }

            else
            {
                throw new JsonException($"Invalid GeoJson. type: {type} does not match coordinates provided");
            }
        }

        public override void Process(ref Utf8JsonReader reader)
        {
            Points = ReadPoints(ref reader);
        }
    }
}
