// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Text.Json;

namespace Azure.Core.Serialization
{
    internal class LevelZeroGeoJsonCoordinateReader : GeoJsonCoordinateReader
    {
        protected GeographyPoint GeographyPoint { get; set; }

        public override Geography GetGeography(string type)
        {
            if (type == GeoJsonConstants.PointTypeName)
            {
                return GeographyPoint;
            }

            throw new JsonException($"Invalid GeoJson. type: {type} does not match coordinates provided");
        }

        public override void Process(ref Utf8JsonReader reader)
        {
            GeographyPoint = ReadPoint(ref reader);
        }
    }
}
