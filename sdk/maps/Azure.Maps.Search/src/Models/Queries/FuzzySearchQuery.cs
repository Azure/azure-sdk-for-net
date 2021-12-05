// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of FuzzySearchBatchQuery. </summary>{
    public partial class FuzzySearchQuery: IQueryRepresentable
    {
        private string query;
        private LatLon coordinates;
        private FuzzySearchOptions options;
        private IEnumerable<string> countryFilter;

        /// <summary> Initializes a new instance of FuzzySearchBatchQuery. </summary>
        public FuzzySearchQuery(string query, LatLon coordinates, IEnumerable<string> countryFilter, FuzzySearchOptions options = null)
        {
            this.query = query;
            this.coordinates = coordinates;
            this.countryFilter = countryFilter;
            this.options = options;
        }

        /// <summary> Initializes a new instance of FuzzySearchBatchQuery. </summary>
        public FuzzySearchQuery(string query, LatLon coordinates, FuzzySearchOptions options = null): this(query, coordinates, null, options) {}

        /// <summary> Initializes a new instance of FuzzySearchBatchQuery. </summary>
        public FuzzySearchQuery(string query, IEnumerable<string> countryFilter, FuzzySearchOptions options = null): this(query, null, countryFilter, options) {}

        /// <summary> The query string will be passed verbatim to the search API for processing. </summary>
        public string Query(SearchClient client)
        {
            return "?" + client.RestClient.CreateFuzzySearchRequest(query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CategoryFilter, countryFilter, coordinates?.Lat, coordinates?.Lon, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.TopLeft.ToString() : null, options?.BoundingBox != null ? options.BoundingBox.BottomRight.ToString() : null, options?.Language, options?.ExtendedPostalCodesFor, options?.MinFuzzyLevel, options?.MaxFuzzyLevel, options?.IndexFilter, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, options?.EntityType, options?.LocalizedMapView, options?.OperatingHours).Request.Uri.Query;
        }
    }
}
