// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search.Models
{
    /// <summary> Options. </summary>
    public class ReverseGeocodingQuery
    {
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
        /// These entity types are ordered from the most specific entity to the least specific entity. When entities of more than one entity type are found, only the most specific entity is returned. For example, if you specify Address and AdminDistrict1 as entity types and entities were found for both types, only the Address entity information is returned in the response.
        /// </summary>
        public IEnumerable<ReverseGeocodingResultTypeEnum> ResultTypes { get; set; }

        /// <summary>A string that represents an <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 Alpha-2 region/country code</see>. This will alter Geopolitical disputed borders and labels to align with the specified user region. By default, the View parameter is set to “Auto” even if you haven’t defined it in the request. Please refer to <see href="https://aka.ms/AzureMapsLocalizationViews">Supported Views</see> for details and to see the available Views. </summary>
        public LocalizedMapView? LocalizedMapView { get; set; }

        /// <summary> The coordinates of the location that you want to reverse geocode. Example: <c>GeoPosition(lon, lat)</c></summary>
        public GeoPosition Coordinates { get; set; }

        /// <summary> id of the request which would show in corresponding batchItem. </summary>
        public string OptionalId { get; set; }
    }
}
