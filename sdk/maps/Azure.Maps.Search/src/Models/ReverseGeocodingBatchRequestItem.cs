// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    public partial class ReverseGeocodingBatchRequestItem
    {
        /// <summary> The coordinates of the location that you want to reverse geocode. Example: [lon,lat]. </summary>
        public IList<double> Coordinates { get; set; }
        /// <summary>
        /// Specify entity types that you want in the response. Only the types you specify will be returned. If the point cannot be mapped to the entity types you specify, no location information is returned in the response.
        /// Default value is all possible entities.
        /// A comma separated list of entity types selected from the following options.
        ///
        /// - Address
        /// - Neighborhood
        /// - PopulatedPlace
        /// - Postcode1
        /// - AdminDivision1
        /// - AdminDivision2
        /// - CountryRegion
        ///
        /// These entity types are ordered from the most specific entity to the least specific entity. When entities of more than one entity type are found, only the most specific entity is returned. For example, if you specify Address and AdminDistrict1 as entity types and entities were found for both types, only the Address entity information is returned in the response.
        /// </summary>
        public IList<ResultTypeEnum> ResultTypes { get; set; }
    }
}
