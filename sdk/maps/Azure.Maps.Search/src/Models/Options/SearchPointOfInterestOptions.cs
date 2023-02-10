// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search
{
    /// <summary> Options. </summary>
    public class SearchPointOfInterestOptions: SearchAddressBaseOptions
    {
        /// <summary>
        /// A list of category set IDs which could be used to restrict the result to specific Points of Interest categories. ID order does not matter. When multiple category identifiers are provided, only POIs that belong to (at least) one of the categories from the provided list will be returned. The list of supported categories can be discovered using  <see href="https://aka.ms/AzureMapsPOICategoryTree">POI Categories API</see>.
        /// </summary>
        public IEnumerable<int> CategoryFilter { get; set; }
        /// <summary>
        /// A list of brand names which could be used to restrict the result to specific brands. Item order does not matter. When multiple brands are provided, only results that belong to (at least) one of the provided list will be returned. Brands that contain a &quot;,&quot; in their name should be put into quotes.
        /// </summary>
        public IEnumerable<string> BrandFilter { get; set; }
        /// <summary>
        /// A list of connector types which could be used to restrict the result to Electric Vehicle Station supporting specific connector types. Item order does not matter. When multiple connector types are provided, only results that belong to (at least) one of the provided list will be returned.
        /// Please refer to <see cref="ElectricVehicleConnector" /> for all the available connector types
        /// </summary>
        public IEnumerable<ElectricVehicleConnector> ElectricVehicleConnectorFilter { get; set; }

        /// <summary>
        /// Indexes for which extended postal codes should be included in the results.
        /// Please refer to <see cref="PointOfInterestExtendedPostalCodes" /> for all the available extended postal codes
        /// </summary>
        public IEnumerable<PointOfInterestExtendedPostalCodes> ExtendedPostalCodesFor { get; set; }
    }
}
