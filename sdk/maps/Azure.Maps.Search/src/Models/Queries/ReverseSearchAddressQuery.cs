// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of ReverseSearchAddressQuery. </summary>
    public class ReverseSearchAddressQuery: IQueryRepresentable
    {
        private LatLon coordinates;
        private ReverseSearchOptions options;

        /// <summary> Initializes a new instance of ReverseSearchAddressQuery. </summary>
        public ReverseSearchAddressQuery(LatLon coordinates, ReverseSearchOptions options = null)
        {
            this.coordinates = coordinates;
            this.options = options;
        }

        /// <summary> The query string will be passed verbatim to the search API for processing. </summary>
        public string Query(SearchClient client)
        {
            return "?" + client.RestClient.CreateReverseSearchAddressRequest((double[]) coordinates, ResponseFormat.Json, options?.Language, options?.IncludeSpeedLimit, options?.Heading, options?.RadiusInMeters, options?.Number, options?.IncludeRoadUse, options?.RoadUse, options?.AllowFreeformNewline, options?.IncludeMatchType, options?.EntityType, options?.LocalizedMapView).Request.Uri;
        }
    }
}
