// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Maps.Common;
using Azure.Maps.Search.Models;

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
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version);
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
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version);
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
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version, null, clientId);
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
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version, null, clientId);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        public MapsSearchClient(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsSearchClient(AzureSasCredential credential, MapsSearchClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version);
        }
        /// <summary>
        /// **Geocoding**
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        /// In many cases, the complete search service might be too much, for instance if you are only interested in traditional geocoding. Search can also be accessed for address look up exclusively. The geocoding is performed by hitting the geocoding endpoint with just the address or partial address in question. The geocoding search index will be queried for everything above the street level data. No Point of Interest (POIs) will be returned. Note that the geocoder is very tolerant of typos and incomplete addresses. It will also handle everything from exact street addresses or street or intersections as well as higher level geographies such as city centers, counties, states etc.
        /// </summary>
        /// <param name="top"> Maximum number of responses that will be returned. Default: 5, minimum: 1 and maximum: 20. </param>
        /// <param name="query"> A string that contains information about a location, such as an address or landmark name. </param>
        /// <param name="addressLine">
        /// The official street line of an address relative to the area, as specified by the locality, or postalCode, properties. Typical use of this element would be to provide a street address or any official address.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="countryRegion">
        /// Signal for the geocoding result to an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) that is specified e.g. FR./
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="bbox">
        /// A rectangular area on the earth defined as a bounding box object. The sides of the rectangles are defined by longitude and latitude values. When you specify this parameter, the geographical area is taken into account when computing the results of a location query.
        ///
        /// Example: lon1,lat1,lon2,lat2
        /// </param>
        /// <param name="view">
        /// A string that represents an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). This will alter Geopolitical disputed borders and labels to align with the specified user region. By default, the View parameter is set to “Auto” even if you haven’t defined it in the request.
        ///
        /// Please refer to [Supported Views](https://aka.ms/AzureMapsLocalizationViews) for details and to see the available Views.
        /// </param>
        /// <param name="coordinates"> A point on the earth specified as a longitude and latitude. When you specify this parameter, the user’s location is taken into account and the results returned may be more relevant to the user. Example: &amp;coordinates=lon,lat. </param>
        /// <param name="adminDistrict">
        /// The country subdivision portion of an address, such as WA.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="adminDistrict2">
        /// The county for the structured address, such as King.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="adminDistrict3">
        /// The named area for the structured address.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="locality">
        /// The locality portion of an address, such as Seattle.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="postalCode">
        /// The postal code portion of an address.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<GeocodingResponse>> GetGeocodingAsync(string query = null, string addressLine = null, string countryRegion = null, IEnumerable<double> bbox = null, string view = null, IEnumerable<double> coordinates = null, string adminDistrict = null, string adminDistrict2 = null, string adminDistrict3 = null, string locality = null, string postalCode = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetGeocoding");
            scope.Start();
            try
            {
                return await RestClient.GetGeocodingAsync(top, query, addressLine, countryRegion, bbox, view, coordinates, adminDistrict, adminDistrict2, adminDistrict3, locality, postalCode, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// **Geocoding**
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        /// In many cases, the complete search service might be too much, for instance if you are only interested in traditional geocoding. Search can also be accessed for address look up exclusively. The geocoding is performed by hitting the geocoding endpoint with just the address or partial address in question. The geocoding search index will be queried for everything above the street level data. No Point of Interest (POIs) will be returned. Note that the geocoder is very tolerant of typos and incomplete addresses. It will also handle everything from exact street addresses or street or intersections as well as higher level geographies such as city centers, counties, states etc.
        /// </summary>
        /// <param name="top"> Maximum number of responses that will be returned. Default: 5, minimum: 1 and maximum: 20. </param>
        /// <param name="query"> A string that contains information about a location, such as an address or landmark name. </param>
        /// <param name="addressLine">
        /// The official street line of an address relative to the area, as specified by the locality, or postalCode, properties. Typical use of this element would be to provide a street address or any official address.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="countryRegion">
        /// Signal for the geocoding result to an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) that is specified e.g. FR./
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="bbox">
        /// A rectangular area on the earth defined as a bounding box object. The sides of the rectangles are defined by longitude and latitude values. When you specify this parameter, the geographical area is taken into account when computing the results of a location query.
        ///
        /// Example: lon1,lat1,lon2,lat2
        /// </param>
        /// <param name="view">
        /// A string that represents an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). This will alter Geopolitical disputed borders and labels to align with the specified user region. By default, the View parameter is set to “Auto” even if you haven’t defined it in the request.
        ///
        /// Please refer to [Supported Views](https://aka.ms/AzureMapsLocalizationViews) for details and to see the available Views.
        /// </param>
        /// <param name="coordinates"> A point on the earth specified as a longitude and latitude. When you specify this parameter, the user’s location is taken into account and the results returned may be more relevant to the user. Example: &amp;coordinates=lon,lat. </param>
        /// <param name="adminDistrict">
        /// The country subdivision portion of an address, such as WA.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="adminDistrict2">
        /// The county for the structured address, such as King.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="adminDistrict3">
        /// The named area for the structured address.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="locality">
        /// The locality portion of an address, such as Seattle.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="postalCode">
        /// The postal code portion of an address.
        ///
        /// **If query is given, should not use this parameter.**
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<GeocodingResponse> GetGeocoding(string query = null, string addressLine = null, string countryRegion = null, IEnumerable<double> bbox = null, string view = null, IEnumerable<double> coordinates = null, string adminDistrict = null, string adminDistrict2 = null, string adminDistrict3 = null, string locality = null, string postalCode = null, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetGeocoding");
            scope.Start();
            try
            {
                return RestClient.GetGeocoding(top, query, addressLine, countryRegion, bbox, view, coordinates, adminDistrict, adminDistrict2, adminDistrict3, locality, postalCode, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="geocodingBatchRequestBody"> The list of address geocoding queries/requests to process. The list can contain a max of 100 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geocodingBatchRequestBody"/> is null. </exception>
        public virtual async Task<Response<GeocodingBatchResponse>> GetGeocodingBatchAsync(GeocodingBatchRequestBody geocodingBatchRequestBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetGeocodingBatch");
            scope.Start();
            try
            {
                return await RestClient.GetGeocodingBatchAsync(geocodingBatchRequestBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="geocodingBatchRequestBody"> The list of address geocoding queries/requests to process. The list can contain a max of 100 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geocodingBatchRequestBody"/> is null. </exception>
        public virtual Response<GeocodingBatchResponse> GetGeocodingBatch(GeocodingBatchRequestBody geocodingBatchRequestBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetGeocodingBatch");
            scope.Start();
            try
            {
                return RestClient.GetGeocodingBatch(geocodingBatchRequestBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// **Get Polygon**
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        /// Supplies polygon data of a geographical area outline such as a city or a country region.
        /// </summary>
        /// <param name="coordinates"> A point on the earth specified as a longitude and latitude. Example: &amp;coordinates=lon,lat. </param>
        /// <param name="view">
        /// A string that represents an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). This will alter Geopolitical disputed borders and labels to align with the specified user region. By default, the View parameter is set to “Auto” even if you haven’t defined it in the request.
        ///
        /// Please refer to [Supported Views](https://aka.ms/AzureMapsLocalizationViews) for details and to see the available Views.
        /// </param>
        /// <param name="resultType"> The geopolitical concept to return a boundary for. </param>
        /// <param name="resolution"> Resolution determines the amount of points to send back. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Boundary>> GetPolygonAsync(IEnumerable<double> coordinates, string view = null, BoundaryResultTypeEnum? resultType = null, ResolutionEnum? resolution = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetPolygon");
            scope.Start();
            try
            {
                return await RestClient.GetPolygonAsync(coordinates, view, resultType, resolution, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// **Get Polygon**
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        /// Supplies polygon data of a geographical area outline such as a city or a country region.
        /// </summary>
        /// <param name="coordinates"> A point on the earth specified as a longitude and latitude. Example: &amp;coordinates=lon,lat. </param>
        /// <param name="view">
        /// A string that represents an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). This will alter Geopolitical disputed borders and labels to align with the specified user region. By default, the View parameter is set to “Auto” even if you haven’t defined it in the request.
        ///
        /// Please refer to [Supported Views](https://aka.ms/AzureMapsLocalizationViews) for details and to see the available Views.
        /// </param>
        /// <param name="resultType"> The geopolitical concept to return a boundary for. </param>
        /// <param name="resolution"> Resolution determines the amount of points to send back. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Boundary> GetPolygon(IEnumerable<double> coordinates, string view = null, BoundaryResultTypeEnum? resultType = null, ResolutionEnum? resolution = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetPolygon");
            scope.Start();
            try
            {
                return RestClient.GetPolygon(coordinates, view, resultType, resolution, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// **Reverse Geocoding**
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        /// Translate a coordinate (example: 37.786505, -122.3862) into a human understandable street address. Most often this is needed in tracking applications where you receive a GPS feed from the device or asset and wish to know what address where the coordinate is located. This endpoint will return address information for a given coordinate.
        /// </summary>
        /// <param name="coordinates"> The coordinates of the location that you want to reverse geocode. Example: &amp;coordinates=lon,lat. </param>
        /// <param name="resultTypes">
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
        /// </param>
        /// <param name="view">
        /// A string that represents an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). This will alter Geopolitical disputed borders and labels to align with the specified user region. By default, the View parameter is set to “Auto” even if you haven’t defined it in the request.
        ///
        /// Please refer to [Supported Views](https://aka.ms/AzureMapsLocalizationViews) for details and to see the available Views.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public virtual async Task<Response<GeocodingResponse>> GetReverseGeocodingAsync(IEnumerable<double> coordinates, IEnumerable<ReverseGeocodingResultTypeEnum> resultTypes = null, string view = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetReverseGeocoding");
            scope.Start();
            try
            {
                return await RestClient.GetReverseGeocodingAsync(coordinates, resultTypes, view, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// **Reverse Geocoding**
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        /// Translate a coordinate (example: 37.786505, -122.3862) into a human understandable street address. Most often this is needed in tracking applications where you receive a GPS feed from the device or asset and wish to know what address where the coordinate is located. This endpoint will return address information for a given coordinate.
        /// </summary>
        /// <param name="coordinates"> The coordinates of the location that you want to reverse geocode. Example: &amp;coordinates=lon,lat. </param>
        /// <param name="resultTypes">
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
        /// </param>
        /// <param name="view">
        /// A string that represents an [ISO 3166-1 Alpha-2 region/country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). This will alter Geopolitical disputed borders and labels to align with the specified user region. By default, the View parameter is set to “Auto” even if you haven’t defined it in the request.
        ///
        /// Please refer to [Supported Views](https://aka.ms/AzureMapsLocalizationViews) for details and to see the available Views.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public virtual Response<GeocodingResponse> GetReverseGeocoding(IEnumerable<double> coordinates, IEnumerable<ReverseGeocodingResultTypeEnum> resultTypes = null, string view = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetReverseGeocoding");
            scope.Start();
            try
            {
                return RestClient.GetReverseGeocoding(coordinates, resultTypes, view, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// **Reverse Geocoding Batch API**
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        ///
        /// The Reverse Geocoding Batch API sends batches of queries to [Reverse Geocoding API](/rest/api/maps/search/get-reverse-geocoding) using just a single API call. The API allows caller to batch up to **100** queries.
        ///
        /// ### Submit Synchronous Batch Request
        /// The Synchronous API is recommended for lightweight batch requests. When the service receives a request, it will respond as soon as the batch items are calculated and there will be no possibility to retrieve the results later. The Synchronous API will return a timeout error (a 408 response) if the request takes longer than 60 seconds. The number of batch items is limited to **100** for this API.
        /// ```
        /// POST https://atlas.microsoft.com/reverseGeocode:batch?api-version=2023-06-01
        /// ```
        /// ### POST Body for Batch Request
        /// To send the _reverse geocoding_ queries you will use a `POST` request where the request body will contain the `batchItems` array in `json` format and the `Content-Type` header will be set to `application/json`. Here's a sample request body containing 2 _reverse geocoding_ queries:
        ///
        ///
        /// ```
        /// {
        ///   "batchItems": [
        ///     {
        ///       "coordinates": [-122.128275, 47.639429],
        ///       "resultTypes": ["Address", "PopulatedPlace"]
        ///     },
        ///     {
        ///       "coordinates": [-122.341979399674, 47.6095253501216]
        ///     }
        ///   ]
        /// }
        /// ```
        ///
        /// A _reverse geocoding_ batchItem object can accept any of the supported _reverse geocoding_ [URI parameters](/rest/api/maps/search/get-reverse-geocoding#uri-parameters).
        ///
        ///
        /// The batch should contain at least **1** query.
        ///
        ///
        /// ### Batch Response Model
        /// The batch response contains a `summary` component that indicates the `totalRequests` that were part of the original batch request and `successfulRequests` i.e. queries which were executed successfully. The batch response also includes a `batchItems` array which contains a response for each and every query in the batch request. The `batchItems` will contain the results in the exact same order the original queries were sent in the batch request. Each item is of one of the following types:
        ///
        ///   - [`GeocodingResponse`](/rest/api/maps/search/get-reverse-geocoding#geocodingresponse) - If the query completed successfully.
        ///
        ///   - `Error` - If the query failed. The response will contain a `code` and a `message` in this case.
        ///
        ///
        ///
        /// </summary>
        /// <param name="reverseGeocodingBatchRequestBody"> The list of reverse geocoding queries/requests to process. The list can contain a max of 100 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="reverseGeocodingBatchRequestBody"/> is null. </exception>
        public virtual async Task<Response<GeocodingBatchResponse>> GetReverseGeocodingBatchAsync(ReverseGeocodingBatchRequestBody reverseGeocodingBatchRequestBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetReverseGeocodingBatch");
            scope.Start();
            try
            {
                return await RestClient.GetReverseGeocodingBatchAsync(reverseGeocodingBatchRequestBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// **Reverse Geocoding Batch API**
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        ///
        /// The Reverse Geocoding Batch API sends batches of queries to [Reverse Geocoding API](/rest/api/maps/search/get-reverse-geocoding) using just a single API call. The API allows caller to batch up to **100** queries.
        ///
        /// ### Submit Synchronous Batch Request
        /// The Synchronous API is recommended for lightweight batch requests. When the service receives a request, it will respond as soon as the batch items are calculated and there will be no possibility to retrieve the results later. The Synchronous API will return a timeout error (a 408 response) if the request takes longer than 60 seconds. The number of batch items is limited to **100** for this API.
        /// ```
        /// POST https://atlas.microsoft.com/reverseGeocode:batch?api-version=2023-06-01
        /// ```
        /// ### POST Body for Batch Request
        /// To send the _reverse geocoding_ queries you will use a `POST` request where the request body will contain the `batchItems` array in `json` format and the `Content-Type` header will be set to `application/json`. Here's a sample request body containing 2 _reverse geocoding_ queries:
        ///
        ///
        /// ```
        /// {
        ///   "batchItems": [
        ///     {
        ///       "coordinates": [-122.128275, 47.639429],
        ///       "resultTypes": ["Address", "PopulatedPlace"]
        ///     },
        ///     {
        ///       "coordinates": [-122.341979399674, 47.6095253501216]
        ///     }
        ///   ]
        /// }
        /// ```
        ///
        /// A _reverse geocoding_ batchItem object can accept any of the supported _reverse geocoding_ [URI parameters](/rest/api/maps/search/get-reverse-geocoding#uri-parameters).
        ///
        ///
        /// The batch should contain at least **1** query.
        ///
        ///
        /// ### Batch Response Model
        /// The batch response contains a `summary` component that indicates the `totalRequests` that were part of the original batch request and `successfulRequests` i.e. queries which were executed successfully. The batch response also includes a `batchItems` array which contains a response for each and every query in the batch request. The `batchItems` will contain the results in the exact same order the original queries were sent in the batch request. Each item is of one of the following types:
        ///
        ///   - [`GeocodingResponse`](/rest/api/maps/search/get-reverse-geocoding#geocodingresponse) - If the query completed successfully.
        ///
        ///   - `Error` - If the query failed. The response will contain a `code` and a `message` in this case.
        ///
        ///
        ///
        /// </summary>
        /// <param name="reverseGeocodingBatchRequestBody"> The list of reverse geocoding queries/requests to process. The list can contain a max of 100 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="reverseGeocodingBatchRequestBody"/> is null. </exception>
        public virtual Response<GeocodingBatchResponse> GetReverseGeocodingBatch(ReverseGeocodingBatchRequestBody reverseGeocodingBatchRequestBody, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetReverseGeocodingBatch");
            scope.Start();
            try
            {
                return RestClient.GetReverseGeocodingBatch(reverseGeocodingBatchRequestBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
