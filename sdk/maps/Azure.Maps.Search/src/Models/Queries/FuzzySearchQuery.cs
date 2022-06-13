// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of FuzzySearchBatchQuery. </summary>{
    public partial class FuzzySearchQuery: IQueryRepresentable
    {
        private string query;
        private FuzzySearchOptions options;

        /// <summary> Initializes a new instance of FuzzySearchBatchQuery. </summary>
        public FuzzySearchQuery(string query, FuzzySearchOptions options = null)
        {
            this.query = query;
            this.options = options;
        }

        /// <summary> The query string will be passed verbatim to the search API for processing. </summary>
        public string Query(SearchClient client)
        {
            return "?" + client.RestClient.CreateFuzzySearchRequest(query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CategoryFilter, options?.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.North + "," + options.BoundingBox.West : null, options?.BoundingBox != null ? options.BoundingBox.South + "," + options.BoundingBox.East : null, options?.Language, options?.ExtendedPostalCodesFor, options?.MinFuzzyLevel, options?.MaxFuzzyLevel, options?.IndexFilter, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, options?.EntityType, options?.LocalizedMapView, options?.OperatingHours).Request.Uri.Query;
        }
    }
}
