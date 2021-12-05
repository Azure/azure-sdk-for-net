// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of SearchAddressQuery. </summary>
    public partial class SearchAddressQuery: IQueryRepresentable
    {
        private string query;
        private SearchAddressOptions options;

        /// <summary> Initializes a new instance of SearchAddressQuery. </summary>
        public SearchAddressQuery(string query, SearchAddressOptions options = null)
        {
            this.query = query;
            this.options = options;
        }

        /// <summary> The query string will be passed verbatim to the search API for processing. </summary>
        public string Query(SearchClient client)
        {
            return "?" + client.RestClient.CreateSearchAddressRequest(query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CountryFilter, options?.Coordinates?.Lat, options?.Coordinates?.Lon, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.TopLeft.ToString() : null, options?.BoundingBox != null ? options.BoundingBox.BottomRight.ToString() : null, options?.Language, options?.ExtendedPostalCodesFor, options?.EntityType, options?.LocalizedMapView).Request.Uri;
        }
    }
}
