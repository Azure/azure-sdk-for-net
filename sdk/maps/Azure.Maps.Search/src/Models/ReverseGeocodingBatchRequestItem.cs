// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Maps.Common;

namespace Azure.Maps.Search.Models
{
    [CodeGenSerialization(nameof(Coordinates), SerializationValueHook = nameof(SerializeCoordinatesValue))]
    [CodeGenSuppress("ReverseGeocodingBatchRequestItem", typeof(string), typeof(IList<double>), typeof(IList<ResultTypeEnum>), typeof(string))]
    public partial class ReverseGeocodingBatchRequestItem
    {
        [CodeGenMember("Coordinates")]
        internal IList<double> _Coordinates { get; }
        /// <summary> The coordinates of the location that you want to reverse geocode. Example: <c>GeoPosition(longitude, latitude)</c>. </summary>
        public GeoPosition Coordinates { get; set; }

        /// <summary>
        /// Specify entity types that you want in the response. Only the types you specify will be returned. If the point cannot be mapped to the entity types you specify, no location information is returned in the response.
        /// Default value is all possible entities.
        /// A comma separated list of entity types selected from the following options.
        ///
        /// <list type="bullet">
        /// <item>Address</item>
        /// <item>Neighborhood</item>
        /// <item>PopulatedPlace</item>
        /// <item>Postcode1</item>
        /// <item>AdminDivision1</item>
        /// <item>AdminDivision2</item>
        /// <item>CountryRegion</item>
        /// </list>
        ///
        /// These entity types are ordered from the most specific entity to the least specific entity. When entities of more than one entity type are found, only the most specific entity is returned. For example, if you specify Address and AdminDistrict1 as entity types and entities were found for both types, only the Address entity information is returned in the response.
        /// </summary>
        public IList<ResultTypeEnum> ResultTypes { get; set; }

        [CodeGenMember("View")]
        internal string View { get; set; }

        /// <summary> A string that specifies an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). This will alter Geopolitical disputed borders and labels to align with the specified user region. </summary>
        public LocalizedMapView LocalizedMapView { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SerializeCoordinatesValue(Utf8JsonWriter writer)
        {
#pragma warning disable CS8073 // The result of the expression is always true in net8.0, but not this is not true in netstandard2.0
            if (Coordinates != null)
#pragma warning restore CS8073
            {
                writer.WriteStartArray();
                writer.WriteNumberValue(Coordinates.Longitude);
                writer.WriteNumberValue(Coordinates.Latitude);
                writer.WriteEndArray();
            }
        }
    }
}
