// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Maps.Search.Models;
using Azure.Core.GeoJson;

namespace Azure.Maps.Search
{
    /// <summary> The Search service client. </summary>
    public partial class MapsSearchClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The RestClient is used to access Route REST client. </summary>
        internal SearchRestClient RestClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        protected MapsSearchClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            RestClient = null;
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Search Service. </param>
        public MapsSearchClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Search Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsSearchClient(AzureKeyCredential credential, MapsSearchClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Search Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        public MapsSearchClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Search Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsSearchClient(TokenCredential credential, string clientId, MapsSearchClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary>
        /// The Get Polygon service allows you to request the geometry data such as a city or country  outline for a set of entities, previously retrieved from an Online Search request in GeoJSON format. The geometry ID is returned in the sourceGeometry object under &quot;geometry&quot; and &quot;id&quot; in either a Search Address or Search Fuzzy call.
        /// </summary>
        /// <param name="geometryIds"> Comma separated list of geometry UUIDs, previously retrieved from an Online Search request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PolygonResult>> GetPolygonsAsync(IEnumerable<string> geometryIds, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetPolygons");
            scope.Start();
            try
            {
                return await RestClient.ListPolygonsAsync(geometryIds, JsonFormat.Json, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Get Polygon service allows you to request the geometry data such as a city or country  outline for a set of entities, previously retrieved from an Online Search request in GeoJSON format. The geometry ID is returned in the sourceGeometry object under &quot;geometry&quot; and &quot;id&quot; in either a Search Address or Search Fuzzy call.
        /// </summary>
        /// <param name="geometryIds"> Comma separated list of geometry UUIDs, previously retrieved from an Online Search request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PolygonResult> GetPolygons(IEnumerable<string> geometryIds, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetPolygons");
            scope.Start();
            try
            {
                return RestClient.ListPolygons(geometryIds, JsonFormat.Json, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The basic default API is Free Form Search which handles the most fuzzy of inputs handling any combination of address or POI tokens. This search API is the canonical &apos;single line search&apos;. The Free Form Search API is a seamless combination of POI search and geocoding. The API can also be weighted with a contextual position (lat./lon. pair), or fully constrained by a a pair of coordinates and radius, or it can be executed more generally without any geo biasing anchor point.&lt;br&gt;&lt;br&gt;We strongly advise you to use the &apos;countrySet&apos; parameter to specify only the countries for which your application needs coverage, as the default behavior will be to search the entire world, potentially returning unnecessary results.&lt;br&gt;&lt;br&gt; E.g.: `countrySet`=US,FR &lt;br&gt;&lt;br&gt;Please see <see href="https://docs.microsoft.com/azure/location-based-services/geocoding-coverage">Search Coverage</see> for a complete list of all the supported countries.&lt;br&gt;&lt;br&gt;Most Search queries default to `maxFuzzyLevel`=2 to gain performance and also reduce unusual results. This new default can be overridden as needed per request by passing in the query param `maxFuzzyLevel`=3 or 4.
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> FuzzySearchAsync(String query, FuzzySearchOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.FuzzySearch");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.FuzzySearchAsync(query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CategoryFilter, options?.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.North + "," + options.BoundingBox.West : null, options?.BoundingBox != null ? options.BoundingBox.South + "," + options.BoundingBox.East : null, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.MinFuzzyLevel, options?.MaxFuzzyLevel, options?.IndexFilter, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, options?.EntityType, localizedMapView, options?.OperatingHours, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The basic default API is Free Form Search which handles the most fuzzy of inputs handling any combination of address or POI tokens. This search API is the canonical &apos;single line search&apos;. The Free Form Search API is a seamless combination of POI search and geocoding. The API can also be weighted with a contextual position (lat./lon. pair), or fully constrained by a a pair of coordinates and radius, or it can be executed more generally without any geo biasing anchor point.&lt;br&gt;&lt;br&gt;We strongly advise you to use the &apos;countrySet&apos; parameter to specify only the countries for which your application needs coverage, as the default behavior will be to search the entire world, potentially returning unnecessary results.&lt;br&gt;&lt;br&gt; E.g.: `countrySet`=US,FR &lt;br&gt;&lt;br&gt;Please see <see href="https://docs.microsoft.com/azure/location-based-services/geocoding-coverage">Search Coverage</see> for a complete list of all the supported countries.&lt;br&gt;&lt;br&gt;Most Search queries default to `maxFuzzyLevel`=2 to gain performance and also reduce unusual results. This new default can be overridden as needed per request by passing in the query param `maxFuzzyLevel`=3 or 4.
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> FuzzySearch(String query, FuzzySearchOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.FuzzySearch");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.FuzzySearch(query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CategoryFilter, options?.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.North + "," + options.BoundingBox.West : null, options?.BoundingBox != null ? options.BoundingBox.South + "," + options.BoundingBox.East : null, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.MinFuzzyLevel, options?.MaxFuzzyLevel, options?.IndexFilter, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, options?.EntityType, localizedMapView, options?.OperatingHours, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Points of Interest (POI) Search allows you to request POI results by name. Search supports additional query parameters such as language and filtering results by area of interest driven by country or bounding box.  Endpoint will return only POI results matching the query string. Response includes POI details such as address, a pair of coordinates location and category.
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="IsTypeAhead"> Boolean. If the typeahead flag is set, the query will be interpreted as a partial input and the search will enter predictive mode. </param>
        /// <param name="OperatingHours"> Hours of operation for a POI (Points of Interest). The availability of hours of operation will vary based on the data available. If not passed, then no opening hours information will be returned. </param>
        /// <param name="BoundingBox"> Bounding Box </param>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> SearchPointOfInterestAsync(string query, bool? IsTypeAhead = null, OperatingHoursRange? OperatingHours = null, GeoBoundingBox BoundingBox = null, SearchPointOfInterestOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchPointOfInterest");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.SearchPointOfInterestAsync(query, ResponseFormat.Json, IsTypeAhead, options?.Top, options?.Skip, options?.CategoryFilter, options?.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, BoundingBox != null ? BoundingBox.North + "," + BoundingBox.West : null, BoundingBox != null ? BoundingBox.South + "," + BoundingBox.East : null, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, localizedMapView, OperatingHours, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Points of Interest (POI) Search allows you to request POI results by name. Search supports additional query parameters such as language and filtering results by area of interest driven by country or bounding box.  Endpoint will return only POI results matching the query string. Response includes POI details such as address, a pair of coordinates location and category.
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="IsTypeAhead"> Boolean. If the typeahead flag is set, the query will be interpreted as a partial input and the search will enter predictive mode. </param>
        /// <param name="OperatingHours"> Hours of operation for a POI (Points of Interest). The availability of hours of operation will vary based on the data available. If not passed, then no opening hours information will be returned. </param>
        /// <param name="BoundingBox"> Bounding Box </param>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> SearchPointOfInterest(string query, bool? IsTypeAhead = null, OperatingHoursRange? OperatingHours = null, GeoBoundingBox BoundingBox = null, SearchPointOfInterestOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchPointOfInterest");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.SearchPointOfInterest(query, ResponseFormat.Json, IsTypeAhead, options?.Top, options?.Skip, options?.CategoryFilter, options?.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, BoundingBox != null ? BoundingBox.North + "," + BoundingBox.West : null, BoundingBox != null ? BoundingBox.South + "," + BoundingBox.East : null, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, localizedMapView, OperatingHours, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Nearby search API. If you have a use case for only retrieving POI results around a specific location, the nearby search method may be the right choice. This endpoint will only return POI results, and does not take in a search query parameter.
        /// </summary>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> SearchNearbyPointOfInterestAsync(SearchNearbyPointOfInterestOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchNearbyPointOfInterest");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.SearchNearbyPointOfInterestAsync(
                    Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat),
                    ResponseFormat.Json, options?.Top, options?.Skip, options?.CategoryFilter, options?.CountryFilter, options?.RadiusInMeters, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, localizedMapView, cancellationToken
                ).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Nearby search API. If you have a use case for only retrieving POI results around a specific location, the nearby search method may be the right choice. This endpoint will only return POI results, and does not take in a search query parameter.
        /// </summary>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> SearchNearbyPointOfInterest(SearchNearbyPointOfInterestOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchNearbyPointOfInterest");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.SearchNearbyPointOfInterest(
                    Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat),
                    ResponseFormat.Json, options?.Top, options?.Skip, options?.CategoryFilter, options?.CountryFilter, options?.RadiusInMeters, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, localizedMapView, cancellationToken
                );
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get POI by Category API. Points of Interest (POI) Category Search allows you to request POI results from given category. Search allows to query POIs from one category at a time. Endpoint will only return POI results which are categorized as specified.  Response includes POI details such as address, a pair of coordinates location and classification.
        /// </summary>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> SearchPointOfInterestCategoryAsync(SearchPointOfInterestCategoryOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchPointOfInterestCategory");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.SearchPointOfInterestCategoryAsync(options?.query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CategoryFilter, options.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.North + "," + options.BoundingBox.West : null, options?.BoundingBox != null ? options.BoundingBox.South + "," + options.BoundingBox.East : null, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, localizedMapView, options?.OperatingHours, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get POI by Category API. Points of Interest (POI) Category Search allows you to request POI results from given category. Search allows to query POIs from one category at a time. Endpoint will only return POI results which are categorized as specified.  Response includes POI details such as address, a pair of coordinates location and classification.
        /// </summary>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> SearchPointOfInterestCategory(SearchPointOfInterestCategoryOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchPointOfInterestCategory");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.SearchPointOfInterestCategory(options?.query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CategoryFilter, options?.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.North + "," + options.BoundingBox.West : null, options?.BoundingBox != null ? options.BoundingBox.South + "," + options.BoundingBox.East : null, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.BrandFilter, options?.ElectricVehicleConnectorFilter, localizedMapView, options?.OperatingHours, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get POI Category Tree API. POI Category API provides a full list of supported Points of Interest (POI) categories and subcategories together with their translations and synonyms. The returned content can be used to provide more meaningful results through other Search Service APIs, like <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchpoi">Get Search POI</see>.
        /// </summary>
        /// <param name="language">
        /// Language in which search results should be returned. Should be one of supported IETF language tags, except NGT and NGT-Latn. Language tag is case insensitive. When data in specified language is not available for a specific field, default language is used (English).
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PointOfInterestCategoryTreeResult>> GetPointOfInterestCategoryTreeAsync(SearchLanguage? language = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetPointOfInterestCategoryTree");
            scope.Start();
            try
            {
                return await RestClient.GetPointOfInterestCategoryTreeAsync(JsonFormat.Json, language.ToString(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get POI Category Tree API. POI Category API provides a full list of supported Points of Interest (POI) categories and subcategories together with their translations and synonyms. The returned content can be used to provide more meaningful results through other Search Service APIs, like <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchpoi">Get Search POI</see>.
        /// </summary>
        /// <param name="language">
        /// Language in which search results should be returned. Should be one of supported IETF language tags, except NGT and NGT-Latn. Language tag is case insensitive. When data in specified language is not available for a specific field, default language is used (English).
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PointOfInterestCategoryTreeResult> GetPointOfInterestCategoryTree(SearchLanguage? language = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetPointOfInterestCategoryTree");
            scope.Start();
            try
            {
                return RestClient.GetPointOfInterestCategoryTree(JsonFormat.Json, language.ToString(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Address geocoding. The geocoding is performed by hitting the geocode endpoint with just the address or partial address in question. The geocoding search index will be queried for everything above the street level data. No POIs will be returned. Note that the geocoder is very tolerant of typos and incomplete addresses. It will also handle everything from exact street addresses or street or intersections as well as higher level geographies such as city centers, counties, states etc.
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;, &quot;pizza&quot;). Must be properly URL encoded. </param>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> SearchAddressAsync(string query, SearchAddressOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchAddress");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.SearchAddressAsync(query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.North + "," + options.BoundingBox.West : null, options?.BoundingBox != null ? options.BoundingBox.South + "," + options.BoundingBox.East : null, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.EntityType, localizedMapView, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Address geocoding. The geocoding is performed by hitting the geocode endpoint with just the address or partial address in question. The geocoding search index will be queried for everything above the street level data. No POIs will be returned. Note that the geocoder is very tolerant of typos and incomplete addresses. It will also handle everything from exact street addresses or street or intersections as well as higher level geographies such as city centers, counties, states etc.
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;, &quot;pizza&quot;). Must be properly URL encoded. </param>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> SearchAddress(string query, SearchAddressOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchAddress");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.SearchAddress(query, ResponseFormat.Json, options?.IsTypeAhead, options?.Top, options?.Skip, options?.CountryFilter, options?.Coordinates?.Latitude, options?.Coordinates?.Longitude, options?.RadiusInMeters, options?.BoundingBox != null ? options.BoundingBox.North + "," + options.BoundingBox.West : null, options?.BoundingBox != null ? options.BoundingBox.South + "," + options.BoundingBox.East : null, options?.Language.ToString(), options?.ExtendedPostalCodesFor, options?.EntityType, localizedMapView, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reverse geocode to an address. There may be times when you need to translate a pair of coordinates (example: 37.786505, -122.3862) into a human understandable street address. Most often  this is needed in tracking applications where you  receive a GPS feed from the device or asset and  wish to know what address where the a pair of coordinates is  located. This endpoint will return address  information for a given coordinate.
        /// </summary>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ReverseSearchAddressResult>> ReverseSearchAddressAsync(ReverseSearchOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.ReverseSearchAddress");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.ReverseSearchAddressAsync(
                    new double[] {
                        Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                    },
                    ResponseFormat.Json, options?.Language.ToString(), options?.IncludeSpeedLimit, options?.Heading, options?.RadiusInMeters, options?.StreetNumber?.ToString(CultureInfo.InvariantCulture), options?.IncludeRoadUse, options?.RoadUse, options?.AllowFreeformNewline, options?.IncludeMatchType, options?.EntityType, localizedMapView, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reverse geocode to an address. There may be times when you need to translate a pair of coordinates (example: 37.786505, -122.3862) into a human understandable street address. Most often  this is needed in tracking applications where you  receive a GPS feed from the device or asset and  wish to know what address where the a pair of coordinates is  located. This endpoint will return address  information for a given coordinate.
        /// </summary>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ReverseSearchAddressResult> ReverseSearchAddress(ReverseSearchOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.ReverseSearchAddress");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.ReverseSearchAddress(
                    new double[] {
                        Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                    },
                    ResponseFormat.Json, options?.Language.ToString(), options?.IncludeSpeedLimit, options?.Heading, options?.RadiusInMeters, options?.StreetNumber?.ToString(CultureInfo.InvariantCulture), options?.IncludeRoadUse, options?.RoadUse, options?.AllowFreeformNewline, options?.IncludeMatchType, options?.EntityType, localizedMapView, cancellationToken
                );
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reverse geocode to a cross street. There may be times when you need to translate a  a pair of coordinates (example: 37.786505, -122.3862) into a human understandable cross street. Most often this  is needed in tracking applications where you  receive a GPS feed from the device or asset and wish to know what address where the a pair of coordinates is  located.
        /// This endpoint will return cross street information  for a given coordinate.
        /// </summary>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ReverseSearchCrossStreetAddressResult>> ReverseSearchCrossStreetAddressAsync(ReverseSearchCrossStreetOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.ReverseSearchCrossStreetAddress");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.ReverseSearchCrossStreetAddressAsync(
                    new double[] {
                        Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                    },
                    ResponseFormat.Json, options?.Top, options?.Heading, options?.RadiusInMeters, options?.Language.ToString(), localizedMapView, cancellationToken
                ).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Reverse geocode to a cross street. There may be times when you need to translate a  a pair of coordinates (example: 37.786505, -122.3862) into a human understandable cross street. Most often this  is needed in tracking applications where you  receive a GPS feed from the device or asset and wish to know what address where the a pair of coordinates is  located.
        /// This endpoint will return cross street information  for a given coordinate.
        /// </summary>
        /// <param name="options"> additional options  </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ReverseSearchCrossStreetAddressResult> ReverseSearchCrossStreetAddress(ReverseSearchCrossStreetOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.ReverseSearchCrossStreetAddress");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.ReverseSearchCrossStreetAddress(
                    new double[] {
                        Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                    },
                    ResponseFormat.Json, options?.Top, options?.Heading, options?.RadiusInMeters, options?.Language.ToString(), localizedMapView, cancellationToken
                );
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Structured address geocoding. The geocoding search index will be queried for everything above the street level data. No POIs will be returned. Note that the geocoder is very tolerant of typos and incomplete  addresses. It will also handle everything from exact  street addresses or street or intersections as well as higher level geographies such as city centers,  counties, states etc.
        /// </summary>
        /// <param name="address"> structured address </param>
        /// <param name="options"> additional options </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> SearchStructuredAddressAsync(StructuredAddress address, SearchStructuredAddressOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchStructuredAddress");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.SearchStructuredAddressAsync(address.CountryCode, ResponseFormat.Json, options?.Language.ToString(), options?.Top, options?.Skip, address.StreetNumber, address.StreetName, address.CrossStreet, address.Municipality, address.MunicipalitySubdivision, address.CountryTertiarySubdivision, address.CountrySecondarySubdivision, address.CountrySubdivision, address.PostalCode, options?.ExtendedPostalCodesFor, options?.EntityType, localizedMapView, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Structured address geocoding. The geocoding search index will be queried for everything above the street level data. No POIs will be returned. Note that the geocoder is very tolerant of typos and incomplete  addresses. It will also handle everything from exact  street addresses or street or intersections as well as higher level geographies such as city centers,  counties, states etc.
        /// </summary>
        /// <param name="address"> structured address </param>
        /// <param name="options"> additional options </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> SearchStructuredAddress(StructuredAddress address, SearchStructuredAddressOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchStructuredAddress");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.SearchStructuredAddress(address.CountryCode, ResponseFormat.Json, options?.Language.ToString(), options?.Top, options?.Skip, address.StreetNumber, address.StreetName, address.CrossStreet, address.Municipality, address.MunicipalitySubdivision, address.CountryTertiarySubdivision, address.CountrySecondarySubdivision, address.CountrySubdivision, address.PostalCode, options?.ExtendedPostalCodesFor, options?.EntityType, localizedMapView, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Search inside geometry. The Search Geometry endpoint allows you to perform a free form search inside a single geometry or many of them. The search results that fall inside the geometry/geometries will be returned.&lt;br&gt;&lt;br&gt;To send the geometry you will use a `POST` request where the request body will contain the `geometry` object represented as a `GeoJSON` type and the `Content-Type` header will be set to `application/json`. The geographical features to be searched can be modeled as Polygon and/or Circle geometries represented using any one of the following `GeoJSON` types:&lt;ul&gt;&lt;li&gt;**GeoJSON FeatureCollection** &lt;br&gt;The `geometry` can be represented as a `GeoJSON FeatureCollection` object. This is the recommended option if the geometry contains both Polygons and Circles. The `FeatureCollection` can contain a max of 50 `GeoJSON Feature` objects. Each `Feature` object should represent either a Polygon or a Circle with the following conditions:&lt;ul style=&quot;list-style-type:none&quot;&gt;&lt;li&gt;A `Feature` object for the Polygon geometry can have a max of 50 coordinates and it&apos;s properties must be empty.&lt;/li&gt;&lt;li&gt;A `Feature` object for the Circle geometry is composed of a _center_ represented using a `GeoJSON Point` type and a _radius_ value (in meters) which must be specified in the object&apos;s properties along with the _subType_ property whose value should be &apos;Circle&apos;.&lt;/li&gt;&lt;/ul&gt;&lt;br&gt; Please see the Examples section below for a sample `FeatureCollection` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;li&gt;**GeoJSON GeometryCollection**&lt;br&gt;The `geometry` can be represented as a `GeoJSON GeometryCollection` object. This is the recommended option if the geometry contains a list of Polygons only. The `GeometryCollection` can contain a max of 50 `GeoJSON Polygon` objects. Each `Polygon` object can have a max of 50 coordinates. Please see the Examples section below for a sample `GeometryCollection` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;li&gt;**GeoJSON Polygon**&lt;br&gt;The `geometry` can be represented as a `GeoJSON Polygon` object. This is the recommended option if the geometry contains a single Polygon. The `Polygon` object can have a max of 50 coordinates. Please see the Examples section below for a sample `Polygon` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;/ul&gt;.&lt;br&gt;&lt;br&gt;
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="geometry"> This represents the geometry for one or more geographical features (parks, state boundary etc.) to search in and should be a GeoJSON compliant type. Please refer to <see href="https://tools.ietf.org/html/rfc7946">RFC 7946</see> for details. </param>
        /// <param name="options"> additional options </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> SearchInsideGeometryAsync(String query, GeoObject geometry, SearchInsideGeometryOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchInsideGeometry");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.SearchInsideGeometryAsync(query, new SearchInsideGeometryRequest(geometry), ResponseFormat.Json, options?.Top, options?.Language.ToString(), options?.CategoryFilter, options?.ExtendedPostalCodesFor, options?.IndexFilter, localizedMapView, options?.OperatingHours, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Search inside geometry. The Search Geometry endpoint allows you to perform a free form search inside a single geometry or many of them. The search results that fall inside the geometry/geometries will be returned.&lt;br&gt;&lt;br&gt;To send the geometry you will use a `POST` request where the request body will contain the `geometry` object represented as a `GeoJSON` type and the `Content-Type` header will be set to `application/json`. The geographical features to be searched can be modeled as Polygon and/or Circle geometries represented using any one of the following `GeoJSON` types:&lt;ul&gt;&lt;li&gt;**GeoJSON FeatureCollection** &lt;br&gt;The `geometry` can be represented as a `GeoJSON FeatureCollection` object. This is the recommended option if the geometry contains both Polygons and Circles. The `FeatureCollection` can contain a max of 50 `GeoJSON Feature` objects. Each `Feature` object should represent either a Polygon or a Circle with the following conditions:&lt;ul style=&quot;list-style-type:none&quot;&gt;&lt;li&gt;A `Feature` object for the Polygon geometry can have a max of 50 coordinates and it&apos;s properties must be empty.&lt;/li&gt;&lt;li&gt;A `Feature` object for the Circle geometry is composed of a _center_ represented using a `GeoJSON Point` type and a _radius_ value (in meters) which must be specified in the object&apos;s properties along with the _subType_ property whose value should be &apos;Circle&apos;.&lt;/li&gt;&lt;/ul&gt;&lt;br&gt; Please see the Examples section below for a sample `FeatureCollection` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;li&gt;**GeoJSON GeometryCollection**&lt;br&gt;The `geometry` can be represented as a `GeoJSON GeometryCollection` object. This is the recommended option if the geometry contains a list of Polygons only. The `GeometryCollection` can contain a max of 50 `GeoJSON Polygon` objects. Each `Polygon` object can have a max of 50 coordinates. Please see the Examples section below for a sample `GeometryCollection` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;li&gt;**GeoJSON Polygon**&lt;br&gt;The `geometry` can be represented as a `GeoJSON Polygon` object. This is the recommended option if the geometry contains a single Polygon. The `Polygon` object can have a max of 50 coordinates. Please see the Examples section below for a sample `Polygon` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;/ul&gt;.&lt;br&gt;&lt;br&gt;
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="geometryCollection"> This represents the geometry for one or more geographical features (parks, state boundary etc.) to search in and should be a GeoJSON compliant type. Please refer to <see href="https://tools.ietf.org/html/rfc7946">RFC 7946</see> for details. </param>
        /// <param name="options"> additional options </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> SearchInsideGeometryAsync(String query, GeoCollection geometryCollection, SearchInsideGeometryOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchInsideGeometry");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.SearchInsideGeometryAsync(query, new SearchInsideGeometryRequest(geometryCollection), ResponseFormat.Json, options?.Top, options?.Language.ToString(), options?.CategoryFilter, options?.ExtendedPostalCodesFor, options?.IndexFilter, localizedMapView, options?.OperatingHours, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Search inside geometry. The Search Geometry endpoint allows you to perform a free form search inside a single geometry or many of them. The search results that fall inside the geometry/geometries will be returned.&lt;br&gt;&lt;br&gt;To send the geometry you will use a `POST` request where the request body will contain the `geometry` object represented as a `GeoJSON` type and the `Content-Type` header will be set to `application/json`. The geographical features to be searched can be modeled as Polygon and/or Circle geometries represented using any one of the following `GeoJSON` types:&lt;ul&gt;&lt;li&gt;**GeoJSON FeatureCollection** &lt;br&gt;The `geometry` can be represented as a `GeoJSON FeatureCollection` object. This is the recommended option if the geometry contains both Polygons and Circles. The `FeatureCollection` can contain a max of 50 `GeoJSON Feature` objects. Each `Feature` object should represent either a Polygon or a Circle with the following conditions:&lt;ul style=&quot;list-style-type:none&quot;&gt;&lt;li&gt;A `Feature` object for the Polygon geometry can have a max of 50 coordinates and it&apos;s properties must be empty.&lt;/li&gt;&lt;li&gt;A `Feature` object for the Circle geometry is composed of a _center_ represented using a `GeoJSON Point` type and a _radius_ value (in meters) which must be specified in the object&apos;s properties along with the _subType_ property whose value should be &apos;Circle&apos;.&lt;/li&gt;&lt;/ul&gt;&lt;br&gt; Please see the Examples section below for a sample `FeatureCollection` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;li&gt;**GeoJSON GeometryCollection**&lt;br&gt;The `geometry` can be represented as a `GeoJSON GeometryCollection` object. This is the recommended option if the geometry contains a list of Polygons only. The `GeometryCollection` can contain a max of 50 `GeoJSON Polygon` objects. Each `Polygon` object can have a max of 50 coordinates. Please see the Examples section below for a sample `GeometryCollection` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;li&gt;**GeoJSON Polygon**&lt;br&gt;The `geometry` can be represented as a `GeoJSON Polygon` object. This is the recommended option if the geometry contains a single Polygon. The `Polygon` object can have a max of 50 coordinates. Please see the Examples section below for a sample `Polygon` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;/ul&gt;.&lt;br&gt;&lt;br&gt;
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="geometry"> This represents the geometry for one or more geographical features (parks, state boundary etc.) to search in and should be a GeoJSON compliant type. Please refer to <see href="https://tools.ietf.org/html/rfc7946">RFC 7946</see> for details. </param>
        /// <param name="options"> additional options </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> SearchInsideGeometry(String query, GeoObject geometry, SearchInsideGeometryOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchInsideGeometry");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.SearchInsideGeometry(query, new SearchInsideGeometryRequest(geometry), ResponseFormat.Json, options?.Top, options?.Language.ToString(), options?.CategoryFilter, options?.ExtendedPostalCodesFor, options?.IndexFilter, localizedMapView, options?.OperatingHours, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Search inside geometry. The Search Geometry endpoint allows you to perform a free form search inside a single geometry or many of them. The search results that fall inside the geometry/geometries will be returned.&lt;br&gt;&lt;br&gt;To send the geometry you will use a `POST` request where the request body will contain the `geometry` object represented as a `GeoJSON` type and the `Content-Type` header will be set to `application/json`. The geographical features to be searched can be modeled as Polygon and/or Circle geometries represented using any one of the following `GeoJSON` types:&lt;ul&gt;&lt;li&gt;**GeoJSON FeatureCollection** &lt;br&gt;The `geometry` can be represented as a `GeoJSON FeatureCollection` object. This is the recommended option if the geometry contains both Polygons and Circles. The `FeatureCollection` can contain a max of 50 `GeoJSON Feature` objects. Each `Feature` object should represent either a Polygon or a Circle with the following conditions:&lt;ul style=&quot;list-style-type:none&quot;&gt;&lt;li&gt;A `Feature` object for the Polygon geometry can have a max of 50 coordinates and it&apos;s properties must be empty.&lt;/li&gt;&lt;li&gt;A `Feature` object for the Circle geometry is composed of a _center_ represented using a `GeoJSON Point` type and a _radius_ value (in meters) which must be specified in the object&apos;s properties along with the _subType_ property whose value should be &apos;Circle&apos;.&lt;/li&gt;&lt;/ul&gt;&lt;br&gt; Please see the Examples section below for a sample `FeatureCollection` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;li&gt;**GeoJSON GeometryCollection**&lt;br&gt;The `geometry` can be represented as a `GeoJSON GeometryCollection` object. This is the recommended option if the geometry contains a list of Polygons only. The `GeometryCollection` can contain a max of 50 `GeoJSON Polygon` objects. Each `Polygon` object can have a max of 50 coordinates. Please see the Examples section below for a sample `GeometryCollection` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;li&gt;**GeoJSON Polygon**&lt;br&gt;The `geometry` can be represented as a `GeoJSON Polygon` object. This is the recommended option if the geometry contains a single Polygon. The `Polygon` object can have a max of 50 coordinates. Please see the Examples section below for a sample `Polygon` representation.&lt;br&gt;&lt;br&gt;&lt;/li&gt;&lt;/ul&gt;.&lt;br&gt;&lt;br&gt;
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="geometryCollection"> This represents the geometry for one or more geographical features (parks, state boundary etc.) to search in and should be a GeoJSON compliant type. Please refer to <see href="https://tools.ietf.org/html/rfc7946">RFC 7946</see> for details. </param>
        /// <param name="options"> additional options </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> SearchInsideGeometry(String query, GeoCollection geometryCollection, SearchInsideGeometryOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchInsideGeometry");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.SearchInsideGeometry(query, new SearchInsideGeometryRequest(geometryCollection), ResponseFormat.Json, options?.Top, options?.Language.ToString(), options?.CategoryFilter, options?.ExtendedPostalCodesFor, options?.IndexFilter, localizedMapView, options?.OperatingHours, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Along Route endpoint allows you to perform a fuzzy search for POIs along a specified route. This search is constrained by specifying the `maxDetourTime` limiting measure.&lt;br&gt;&lt;br&gt;To send the route-points you will use a `POST` request where the request body will contain the `route` object represented as a `GeoJSON LineString` type and the `Content-Type` header will be set to `application/json`. Each route-point in `route` is represented as a `GeoJSON Position` type i.e. an array where the _longitude_ value is followed by the _latitude_ value and the _altitude_ value is ignored. The `route` should contain at least 2 route-points.&lt;br&gt;&lt;br&gt;It is possible that original route will be altered, some of it&apos;s points may be skipped. If the route that passes through the found point is faster than the original one, the `detourTime` value in the response is negative.
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="maxDetourTime"> Maximum detour time of the point of interest in seconds. Max value is 3600 seconds. </param>
        /// <param name="route"> This represents the route to search along and should be a valid `GeoJSON LineString` type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.4">RFC 7946</see> for details. </param>
        /// <param name="options"> additional options </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressResult>> SearchPointOfInterestAlongRouteAsync(String query, int maxDetourTime, GeoLineString route, SearchAlongRouteOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchPointOfInterestAlongRoute");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return await RestClient.SearchAlongRouteAsync(query, maxDetourTime, new SearchAlongRouteRequest(route), ResponseFormat.Json, options?.Top, options?.BrandFilter, options?.CategoryFilter, options?.ElectricVehicleConnectorFilter, localizedMapView, options?.OperatingHours, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Along Route endpoint allows you to perform a fuzzy search for POIs along a specified route. This search is constrained by specifying the `maxDetourTime` limiting measure.&lt;br&gt;&lt;br&gt;To send the route-points you will use a `POST` request where the request body will contain the `route` object represented as a `GeoJSON LineString` type and the `Content-Type` header will be set to `application/json`. Each route-point in `route` is represented as a `GeoJSON Position` type i.e. an array where the _longitude_ value is followed by the _latitude_ value and the _altitude_ value is ignored. The `route` should contain at least 2 route-points.&lt;br&gt;&lt;br&gt;It is possible that original route will be altered, some of it&apos;s points may be skipped. If the route that passes through the found point is faster than the original one, the `detourTime` value in the response is negative.
        /// </summary>
        /// <param name="query"> The POI name to search for (e.g., &quot;statue of liberty&quot;, &quot;starbucks&quot;), must be properly URL encoded. </param>
        /// <param name="maxDetourTime"> Maximum detour time of the point of interest in seconds. Max value is 3600 seconds. </param>
        /// <param name="route"> This represents the route to search along and should be a valid `GeoJSON LineString` type. Please refer to <see href="https://tools.ietf.org/html/rfc7946#section-3.1.4">RFC 7946</see> for details. </param>
        /// <param name="options"> additional options </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressResult> SearchPointOfInterestAlongRoute(string query, int maxDetourTime, GeoLineString route, SearchAlongRouteOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchPointOfInterestAlongRoute");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                return RestClient.SearchAlongRoute(query, maxDetourTime, new SearchAlongRouteRequest(route), ResponseFormat.Json, options?.Top, options?.BrandFilter, options?.CategoryFilter, options?.ElectricVehicleConnectorFilter, localizedMapView, options?.OperatingHours, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchfuzzy">Search Fuzzy API</see> using just a single API call. You can call Search Address Fuzzy Batch API to run either asynchronously (async) or synchronously (sync). The async API allows caller to batch up to **10,000** queries and sync API up to **100** queries.
        /// </summary>
        /// <param name="queries"> The list of search fuzzy queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressBatchResult>> GetImmediateFuzzyBatchSearchAsync(IEnumerable<FuzzySearchQuery> queries, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetImmediateFuzzyBatchSearch");
            scope.Start();
            try
            {
                var batchRequests = MapsSearchClient.fuzzySearchQueriesToBatchRequestInternal(queries);
                return await RestClient.FuzzySearchBatchSyncAsync(batchRequests, JsonFormat.Json, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchfuzzy">Search Fuzzy API</see> using just a single API call. You can call Search Address Fuzzy Batch API to run either asynchronously (async) or synchronously (sync). The async API allows caller to batch up to **10,000** queries and sync API up to **100** queries.
        /// </summary>
        /// <param name="queries"> The list of search fuzzy queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressBatchResult> GetImmediateFuzzyBatchSearch(IEnumerable<FuzzySearchQuery> queries, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetImmediateFuzzyBatchSearch");
            scope.Start();
            try
            {
                var batchRequests = MapsSearchClient.fuzzySearchQueriesToBatchRequestInternal(queries);
                return RestClient.FuzzySearchBatchSync(batchRequests, JsonFormat.Json, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchaddress">Search Address API</see> using just a single API call. This Search Address Batch API can handle up to **100** queries.
        /// To send more queries in a batch request, please refer to <see cref="MapsSearchClient.SearchAddressBatch(WaitUntil, IEnumerable&lt;SearchAddressQuery&gt;, CancellationToken)"/> long-running operation.
        /// </summary>
        /// <param name="queries"> The list of address geocoding queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SearchAddressBatchResult>> GetImmediateSearchAddressBatchAsync(IEnumerable<SearchAddressQuery> queries, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetImmediateSearchAddressBatch");
            scope.Start();
            try
            {
                var batchRequests = MapsSearchClient.searchAddressQueriesToBatchRequestInternal(queries);
                return await RestClient.SearchAddressBatchSyncAsync(batchRequests, JsonFormat.Json, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchaddress">Search Address API</see> using just a single API call. You can call Search Address Batch API to run either asynchronously (async) or synchronously (sync). The async API allows caller to batch up to **10,000** queries and sync API up to **100** queries.
        /// To send more queries in a batch request, please refer to <see cref="MapsSearchClient.SearchAddressBatch(WaitUntil, IEnumerable&lt;SearchAddressQuery&gt;, CancellationToken)"/> long-running operation.
        /// </summary>
        /// <param name="queries"> The list of address geocoding queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SearchAddressBatchResult> GetImmediateSearchAddressBatch(IEnumerable<SearchAddressQuery> queries, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetImmediateSearchAddressBatch");
            scope.Start();
            try
            {
                var batchRequests = MapsSearchClient.searchAddressQueriesToBatchRequestInternal(queries);
                return RestClient.SearchAddressBatchSync(batchRequests, JsonFormat.Json, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchaddressreverse">Search Address Reverse API</see> using just a single API call. This Search Address Reverse Batch API can handle up to **100** queries.
        /// To send more queries in a batch request, please refer to <see cref="MapsSearchClient.ReverseSearchAddressBatch(WaitUntil, IEnumerable&lt;ReverseSearchAddressQuery&gt;, CancellationToken)"/> long-running operation.
        /// </summary>
        /// <param name="queries"> The list of reverse geocoding queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ReverseSearchAddressBatchResult>> GetImmediateReverseSearchAddressBatchAsync(IEnumerable<ReverseSearchAddressQuery> queries, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetImmediateReverseSearchAddressBatch");
            scope.Start();
            try
            {
                var batchRequests = MapsSearchClient.reverseSearchAddressQueriesToBatchRequestInternal(queries);
                return await RestClient.ReverseSearchAddressBatchSyncAsync(batchRequests, JsonFormat.Json, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchaddressreverse">Search Address Reverse API</see> using just a single API call. This Search Address Reverse Batch API can handle up to **100** queries.
        /// To send more queries in a batch request, please refer to <see cref="MapsSearchClient.ReverseSearchAddressBatch(WaitUntil, IEnumerable&lt;ReverseSearchAddressQuery&gt;, CancellationToken)"/> long-running operation.
        /// </summary>
        /// <param name="queries"> The list of reverse geocoding queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ReverseSearchAddressBatchResult> GetImmediateReverseSearchAddressBatch(IEnumerable<ReverseSearchAddressQuery> queries, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetImmediateReverseSearchAddressBatch");
            scope.Start();
            try
            {
                var batchRequests = MapsSearchClient.reverseSearchAddressQueriesToBatchRequestInternal(queries);
                return RestClient.ReverseSearchAddressBatchSync(batchRequests, JsonFormat.Json, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchfuzzy">Search Fuzzy API</see> using just a single API call. You can call Search Address Fuzzy Batch API to run either asynchronously (async) or synchronously (sync). The async API allows caller to batch up to **10,000** queries and sync API up to **100** queries.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return immediately after starting the operation. </param>
        /// <param name="queries"> The list of search fuzzy queries/requests to process. The list can contain a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual async Task<FuzzySearchBatchOperation> FuzzyBatchSearchAsync(WaitUntil waitUntil, IEnumerable<FuzzySearchQuery> queries, CancellationToken cancellationToken = default)
        {
            if (queries == null)
            {
                throw new ArgumentNullException(nameof(queries));
            }

            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.FuzzyBatchSearch");
            scope.Start();
            try
            {
                var batchRequests = MapsSearchClient.fuzzySearchQueriesToBatchRequestInternal(queries);
                var originalResponse = await RestClient.FuzzySearchBatchAsync(batchRequests, JsonFormat.Json, cancellationToken).ConfigureAwait(false);
                var operation = new FuzzySearchBatchOperation(this, new Uri(originalResponse.Headers.Location));
                if (waitUntil == WaitUntil.Completed)
                {
                    // TODO: Remove Thread.Sleep after adding RetryAfterInSeconds parameter
                    Thread.Sleep(400);
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchfuzzy">Search Fuzzy API</see> using just a single API call. You can call Search Address Fuzzy Batch API to run either asynchronously (async) or synchronously (sync). The async API allows caller to batch up to **10,000** queries and sync API up to **100** queries.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return immediately after starting the operation. </param>
        /// <param name="queries"> The list of search fuzzy queries/requests to process. The list can contain a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual FuzzySearchBatchOperation FuzzyBatchSearch(WaitUntil waitUntil, IEnumerable<FuzzySearchQuery> queries, CancellationToken cancellationToken = default)
        {
            if (queries == null)
            {
                throw new ArgumentNullException(nameof(queries));
            }

            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.FuzzyBatchSearch");
            scope.Start();
            try
            {
                var batchRequest = fuzzySearchQueriesToBatchRequestInternal(queries);
                var originalResponse = RestClient.FuzzySearchBatch(batchRequest, JsonFormat.Json, cancellationToken);
                var operation = new FuzzySearchBatchOperation(this, new Uri(originalResponse.Headers.Location));
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchfuzzy">Search Fuzzy API</see> using just a single API call. You can call Search Address Batch API to run either asynchronously (async) or synchronously (sync). The async API allows caller to batch up to **10,000** queries and sync API up to **100** queries.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return immediately after starting the operation. </param>
        /// <param name="queries"> The list of address geocoding queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual async Task<SearchAddressBatchOperation> SearchAddressBatchAsync(WaitUntil waitUntil, IEnumerable<SearchAddressQuery> queries, CancellationToken cancellationToken = default)
        {
            if (queries == null)
            {
                throw new ArgumentNullException(nameof(queries));
            }

            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchAddressBatch");
            scope.Start();
            try
            {
                var batchRequest = MapsSearchClient.searchAddressQueriesToBatchRequestInternal(queries);
                var originalResponse = await RestClient.SearchAddressBatchAsync(batchRequest, JsonFormat.Json, cancellationToken).ConfigureAwait(false);
                var operation = new SearchAddressBatchOperation(this, new Uri(originalResponse.Headers.Location));
                if (waitUntil == WaitUntil.Completed)
                {
                    // TODO: Remove Thread.Sleep after adding RetryAfterInSeconds parameter
                    Thread.Sleep(400);
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchaddress">Search Address API</see> using just a single API call. You can call Search Address Batch API to run either asynchronously (async) or synchronously (sync). The async API allows caller to batch up to **10,000** queries and sync API up to **100** queries.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return immediately after starting the operation. </param>
        /// <param name="queries"> The list of address geocoding queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual SearchAddressBatchOperation SearchAddressBatch(WaitUntil waitUntil, IEnumerable<SearchAddressQuery> queries, CancellationToken cancellationToken = default)
        {
            if (queries == null)
            {
                throw new ArgumentNullException(nameof(queries));
            }

            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.SearchAddressBatch");
            scope.Start();
            try
            {
                var batchRequest = searchAddressQueriesToBatchRequestInternal(queries);
                var originalResponse = RestClient.SearchAddressBatch(batchRequest, JsonFormat.Json, cancellationToken);
                var operation = new SearchAddressBatchOperation(this, new Uri(originalResponse.Headers.Location));
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Reverse Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchaddressreverse">Search Address Reverse API</see> using just a single API call. This Search Address Reverse Batch API can handle up to **10000** queries.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return immediately after starting the operation. </param>
        /// <param name="queries"> The list of reverse geocoding queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual async Task<ReverseSearchAddressBatchOperation> ReverseSearchAddressBatchAsync(WaitUntil waitUntil, IEnumerable<ReverseSearchAddressQuery> queries, CancellationToken cancellationToken = default)
        {
            if (queries == null)
            {
                throw new ArgumentNullException(nameof(queries));
            }

            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.ReverseSearchAddressBatch");
            scope.Start();
            try
            {
                var batchQuery = MapsSearchClient.reverseSearchAddressQueriesToBatchRequestInternal(queries);
                var originalResponse = await RestClient.ReverseSearchAddressBatchAsync(batchQuery, JsonFormat.Json, cancellationToken).ConfigureAwait(false);
                var operation = new ReverseSearchAddressBatchOperation(this, new Uri(originalResponse.Headers.Location));
                if (waitUntil == WaitUntil.Completed)
                {
                    // TODO: Remove Thread.Sleep after adding RetryAfterInSeconds parameter
                    Thread.Sleep(400);
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Search Address Reverse Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/search/getsearchaddressreverse">Search Address Reverse API</see> using just a single API call. You can call Search Address Reverse Batch API to run either asynchronously (async) or synchronously (sync). The async API allows caller to batch up to **10,000** queries and sync API up to **100** queries.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return immediately after starting the operation. </param>
        /// <param name="queries"> The list of reverse geocoding queries/requests to process. The list can contain  a max of 10,000 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual ReverseSearchAddressBatchOperation ReverseSearchAddressBatch(WaitUntil waitUntil, IEnumerable<ReverseSearchAddressQuery> queries, CancellationToken cancellationToken = default)
        {
            if (queries == null)
            {
                throw new ArgumentNullException(nameof(queries));
            }

            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.ReverseSearchAddressBatch");
            scope.Start();
            try
            {
                var batchRequest = MapsSearchClient.reverseSearchAddressQueriesToBatchRequestInternal(queries);
                var originalResponse = RestClient.ReverseSearchAddressBatch(batchRequest, JsonFormat.Json, cancellationToken);
                var operation = new ReverseSearchAddressBatchOperation(this, new Uri(originalResponse.Headers.Location));
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Convert a list of queries in string format to BatchRequestInternal for fuzzy search queries
        /// </summary>
        private static BatchRequestInternal fuzzySearchQueriesToBatchRequestInternal(IEnumerable<FuzzySearchQuery> fuzzySearchQueries)
        {
            BatchRequestInternal batchItems = new BatchRequestInternal();

            foreach (var query in fuzzySearchQueries)
            {
                var options = query.FuzzySearchOptions;
                var uri = new RawRequestUriBuilder();

                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }

                uri.AppendQuery("query", query.Query, true);
                if (options?.IsTypeAhead != null)
                {
                    uri.AppendQuery("typeahead", options.IsTypeAhead.Value, true);
                }
                if (options?.Top != null)
                {
                    uri.AppendQuery("limit", options.Top.Value, true);
                }
                if (options?.Skip != null)
                {
                    uri.AppendQuery("ofs", options.Skip.Value, true);
                }
                if (options?.CategoryFilter != null)
                {
                    uri.AppendQueryDelimited("categorySet", options.CategoryFilter, ",", true);
                }
                if (options?.CountryFilter != null)
                {
                    uri.AppendQueryDelimited("countrySet", options.CountryFilter, ",", true);
                }
                if (options?.Coordinates != null)
                {
                    uri.AppendQuery("lat", options.Coordinates.Value.Latitude, true);
                    uri.AppendQuery("lon", options.Coordinates.Value.Longitude, true);
                }
                if (options?.RadiusInMeters != null)
                {
                    uri.AppendQuery("radius", options.RadiusInMeters.Value, true);
                }
                if (options?.BoundingBox != null)
                {
                    uri.AppendQuery("topLeft", options.BoundingBox.North + "," + options.BoundingBox.West, true);
                    uri.AppendQuery("btmRight", options.BoundingBox.South + "," + options.BoundingBox.East, true);
                }
                if (options?.Language.ToString() != null)
                {
                    uri.AppendQuery("language", options?.Language.ToString(), true);
                }
                if (options?.ExtendedPostalCodesFor != null)
                {
                    uri.AppendQueryDelimited("extendedPostalCodesFor", options?.ExtendedPostalCodesFor, ",", true);
                }
                if (options?.MinFuzzyLevel != null)
                {
                    uri.AppendQuery("minFuzzyLevel", options.MinFuzzyLevel.Value, true);
                }
                if (options?.MaxFuzzyLevel != null)
                {
                    uri.AppendQuery("maxFuzzyLevel", options.MaxFuzzyLevel.Value, true);
                }
                if (options?.IndexFilter != null)
                {
                    uri.AppendQueryDelimited("idxSet", options.IndexFilter, ",", true);
                }
                if (options?.BrandFilter != null)
                {
                    uri.AppendQueryDelimited("brandSet", options.BrandFilter, ",", true);
                }
                if (options?.ElectricVehicleConnectorFilter != null)
                {
                    uri.AppendQueryDelimited("connectorSet", options.ElectricVehicleConnectorFilter, ",", true);
                }
                if (options?.EntityType != null)
                {
                    uri.AppendQuery("entityType", options.EntityType.Value.ToString(), true);
                }
                if (localizedMapView != null)
                {
                    uri.AppendQuery("view", localizedMapView.Value.ToString(), true);
                }
                if (options?.OperatingHours != null)
                {
                    uri.AppendQuery("openingHours", options.OperatingHours.Value.ToString(), true);
                }
                batchItems.BatchItems.Add(new BatchRequestItemInternal(uri.Query));
            }
            return batchItems;
        }

        /// <summary>
        /// Convert a list of queries in string format to BatchRequestInternal for search address queries
        /// </summary>
        private static BatchRequestInternal searchAddressQueriesToBatchRequestInternal(IEnumerable<SearchAddressQuery> searchAddressQueries)
        {
            BatchRequestInternal batchItems = new BatchRequestInternal();
            foreach (var query in searchAddressQueries)
            {
                var options = query.SearchAddressOptions;
                var uri = new RawRequestUriBuilder();
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                uri.AppendQuery("query", query.Query, true);
                if (options?.IsTypeAhead != null)
                {
                    uri.AppendQuery("typeahead", options.IsTypeAhead.Value, true);
                }
                if (options?.Top != null)
                {
                    uri.AppendQuery("limit", options.Top.Value, true);
                }
                if (options?.Skip != null)
                {
                    uri.AppendQuery("ofs", options.Skip.Value, true);
                }
                if (options?.CountryFilter != null)
                {
                    uri.AppendQueryDelimited("countrySet", options.CountryFilter, ",", true);
                }
                if (options?.Coordinates != null)
                {
                    uri.AppendQuery("lat", options.Coordinates.Value.Latitude, true);
                    uri.AppendQuery("lon", options.Coordinates.Value.Longitude, true);
                }
                if (options?.RadiusInMeters != null)
                {
                    uri.AppendQuery("radius", options.RadiusInMeters.Value, true);
                }
                if (options?.BoundingBox != null)
                {
                    uri.AppendQuery("topLeft", options.BoundingBox.North + "," + options.BoundingBox.West, true);
                    uri.AppendQuery("btmRight", options.BoundingBox.South + "," + options.BoundingBox.East, true);
                }
                if (options?.Language.ToString() != null)
                {
                    uri.AppendQuery("language", options?.Language.ToString(), true);
                }
                if (options?.ExtendedPostalCodesFor != null)
                {
                    uri.AppendQueryDelimited("extendedPostalCodesFor", options?.ExtendedPostalCodesFor, ",", true);
                }
                if (options?.EntityType != null)
                {
                    uri.AppendQuery("entityType", options.EntityType.Value.ToString(), true);
                }
                if (localizedMapView != null)
                {
                    uri.AppendQuery("view", localizedMapView.Value.ToString(), true);
                }
                batchItems.BatchItems.Add(new BatchRequestItemInternal(uri.Query));
            }
            return batchItems;
        }

        /// <summary>
        /// Convert a list of queries in string format to BatchRequestInternal for reverse search address queries
        /// </summary>
        private static BatchRequestInternal reverseSearchAddressQueriesToBatchRequestInternal(IEnumerable<ReverseSearchAddressQuery> reverseSearchAddressQueries)
        {
            BatchRequestInternal batchItems = new BatchRequestInternal();

            foreach (var query in reverseSearchAddressQueries)
            {
                var options = query.ReverseSearchAddressOptions;
                var uri = new RawRequestUriBuilder();
                var queryCoordinate = new double[] {
                    Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };

                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }

                uri.AppendQueryDelimited("query", queryCoordinate, ",", true);
                if (options?.Language.ToString() != null)
                {
                    uri.AppendQuery("language", options?.Language.ToString(), true);
                }
                if (options?.IncludeSpeedLimit != null)
                {
                    uri.AppendQuery("returnSpeedLimit", options.IncludeSpeedLimit.Value, true);
                }
                if (options?.Heading != null)
                {
                    uri.AppendQuery("heading", options.Heading.Value, true);
                }
                if (options?.RadiusInMeters != null)
                {
                    uri.AppendQuery("radius", options.RadiusInMeters.Value, true);
                }
                if (options?.StreetNumber != null)
                {
                    uri.AppendQuery("number", options.StreetNumber.ToString(), true);
                }
                if (options?.IncludeRoadUse != null)
                {
                    uri.AppendQuery("returnRoadUse", options.IncludeRoadUse.Value, true);
                }
                if (options?.RoadUse != null)
                {
                    uri.AppendQueryDelimited("roadUse", options.RoadUse, ",", true);
                }
                if (options?.AllowFreeformNewline != null)
                {
                    uri.AppendQuery("allowFreeformNewline", options.AllowFreeformNewline.Value, true);
                }
                if (options?.IncludeMatchType != null)
                {
                    uri.AppendQuery("returnMatchType", options.IncludeMatchType.Value, true);
                }
                if (options?.EntityType != null)
                {
                    uri.AppendQuery("entityType", options.EntityType.Value.ToString(), true);
                }
                if (localizedMapView != null)
                {
                    uri.AppendQuery("view", localizedMapView.Value.ToString(), true);
                }
                batchItems.BatchItems.Add(new BatchRequestItemInternal(uri.Query));
            }
            return batchItems;
        }
    }
}
