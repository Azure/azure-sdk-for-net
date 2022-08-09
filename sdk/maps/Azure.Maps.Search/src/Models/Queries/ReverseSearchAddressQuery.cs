// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System;
using System.Globalization;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of ReverseSearchAddressQuery. </summary>
    public class ReverseSearchAddressQuery: IQueryRepresentable
    {
        private ReverseSearchOptions options;

        /// <summary> Initializes a new instance of ReverseSearchAddressQuery. </summary>
        public ReverseSearchAddressQuery(ReverseSearchOptions options = null)
        {
            this.options = options;
        }

        /// <summary> The query string will be passed verbatim to the search API for processing. </summary>
        public string Query(MapsSearchClient client)
        {
            return "?" + client.RestClient.CreateReverseSearchAddressRequest(new double[] {Convert.ToDouble(options?.coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat), Convert.ToDouble(options?.coordinates?.Longitude, CultureInfo.GetCultureInfo("en-US").NumberFormat)}, ResponseFormat.Json, options?.Language, options?.IncludeSpeedLimit, options?.Heading, options?.RadiusInMeters, options?.Number, options?.IncludeRoadUse, options?.RoadUse, options?.AllowFreeformNewline, options?.IncludeMatchType, options?.EntityType, options?.LocalizedMapView).Request.Uri;
        }
    }
}
