// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Maps.Search.Models;

namespace Azure.Maps.Search
{
    /// <summary> Options for Search Along Route API. </summary>
    public class SearchAlongRouteOptions: SearchGeometryBaseOptions
    {
        /// <summary>
        /// A list of connector types which could be used to restrict the result to Electric Vehicle Station supporting specific connector types. Item order does not matter. When multiple connector types are provided, only results that belong to (at least) one of the provided list will be returned.
        /// Please refer to <see cref="ElectricVehicleConnector" /> for all the available connector types
        /// </summary>
        public IEnumerable<ElectricVehicleConnector> ElectricVehicleConnectorFilter { get; set; }

        /// <summary>
        /// A list of brand names which could be used to restrict the result to specific brands. Item order does not matter. When multiple brands are provided, only results that belong to (at least) one of the provided list will be returned. Brands that contain a &quot;,&quot; in their name should be put into quotes.
        /// </summary>
        public IEnumerable<string> BrandFilter { get; set; }
    }
}
