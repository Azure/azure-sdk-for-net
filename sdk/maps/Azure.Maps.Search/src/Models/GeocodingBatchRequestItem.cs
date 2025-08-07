// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search.Models
{
    [CodeGenSerialization(nameof(BoundingBox), SerializationValueHook = nameof(SerializeBoundingBoxValue))]
    [CodeGenSuppress("GeocodingBatchRequestItem", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(IList<double>), typeof(string), typeof(IList<double>), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSerialization(nameof(_BoundingBox), "boundingBox")]
    public partial class GeocodingBatchRequestItem
    {
        /// <summary>
        /// A rectangular area on the earth defined as a bounding box object. The sides of the rectangles are defined by longitude and latitude values. For more information, see Location and Area Types. When you specify this parameter, the geographical area is taken into account when computing the results of a location query.
        ///
        /// Example: [lon1, lat1, lon2, lat2]
        /// </summary>
        [CodeGenMember("BoundingBox")]
        internal IList<double> _BoundingBox { get; set; }

        /// <summary>
        /// A rectangular area on the earth defined as a bounding box object. The sides of the rectangles are defined by longitude and latitude values. For more information, see Location and Area Types. When you specify this parameter, the geographical area is taken into account when computing the results of a location query.
        ///
        /// Example: <c>GeoBoundingBox(west, south, east, north)</c>
        /// </summary>
        public GeoBoundingBox BoundingBox { get; set; }

        [CodeGenMember("Coordinates")]
        internal IList<double> _Coordinates { get; }
        /// <summary> A point on the earth specified as a longitude and latitude. When you specify this parameter, the user’s location is taken into account and the results returned may be more relevant to the user. Example: <c>GeoPosition(longitude, latitude)</c>. </summary>
        public GeoPosition Coordinates { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeBoundingBoxValue(Utf8JsonWriter writer)
        {
            if (BoundingBox != null)
            {
                writer.WriteStartArray();
                writer.WriteNumberValue(BoundingBox.North);
                writer.WriteNumberValue(BoundingBox.West);
                writer.WriteNumberValue(BoundingBox.South);
                writer.WriteNumberValue(BoundingBox.East);
                writer.WriteEndArray();
            }
        }
    }
}
