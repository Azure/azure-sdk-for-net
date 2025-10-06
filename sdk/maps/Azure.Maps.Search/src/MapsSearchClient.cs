// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.GeoJson;
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
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MapsSearchClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string acceptLanguage = options.SearchLanguage == null ? null : options.SearchLanguage.ToString();
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version, acceptLanguage);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Search Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MapsSearchClient(AzureKeyCredential credential, MapsSearchClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string acceptLanguage = options.SearchLanguage == null ? null : options.SearchLanguage.ToString();
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version, acceptLanguage);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Search Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="clientId"/> is null. </exception>
        public MapsSearchClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = ["https://atlas.microsoft.com/.default"];
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version, null, clientId);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Search Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="clientId"/> is null. </exception>
        public MapsSearchClient(TokenCredential credential, string clientId, MapsSearchClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = ["https://atlas.microsoft.com/.default"];
            string acceptLanguage = options.SearchLanguage?.ToString();
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version, acceptLanguage, clientId);
        }

        /// <summary> Initializes a new instance of MapsSearchClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
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
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MapsSearchClient(AzureSasCredential credential, MapsSearchClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsSearchClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string acceptLanguage = options.SearchLanguage?.ToString();
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            RestClient = new SearchRestClient(_clientDiagnostics, _pipeline, endpoint, options.Version, acceptLanguage);
        }
        /// <summary>
        /// In many cases, the complete search service might be too much, for instance if you are only interested in traditional geocoding. Search can also be accessed for address look up exclusively. The geocoding is performed by hitting the geocoding endpoint with just the address or partial address in question. The geocoding search index will be queried for everything above the street level data. No Point of Interest (POIs) will be returned. Note that the geocoder is very tolerant of typos and incomplete addresses. It will also handle everything from exact street addresses or street or intersections as well as higher level geographies such as city centers, counties, states etc.
        /// </summary>
        /// <param name="query"> A string that contains information about a location, such as an address or landmark name. </param>
        /// <param name="options"> additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<GeocodingResponse>> GetGeocodingAsync(string query = null, GeocodingQuery options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetGeocoding");
            scope.Start();
            try
            {
                string localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = options?.LocalizedMapView.ToString();
                }

                IEnumerable<double> boundingBox = null;
                if (options?.BoundingBox != null)
                {
                    boundingBox = [options.BoundingBox.North, options.BoundingBox.West, options.BoundingBox.South, options.BoundingBox.East];
                }
                IEnumerable<double> coordinates = null;
                if (options?.Coordinates != null)
                {
                    coordinates = coordinates = new[]
                    {
                        Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                    };
                }

                return await RestClient.GetGeocodingAsync(options?.Top, query, options?.AddressLine, options?.CountryRegion, boundingBox, localizedMapView, coordinates, options?.AdminDistrict, options?.AdminDistrict2, options?.AdminDistrict3, options?.Locality, options?.PostalCode, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// In many cases, the complete search service might be too much, for instance if you are only interested in traditional geocoding. Search can also be accessed for address look up exclusively. The geocoding is performed by hitting the geocoding endpoint with just the address or partial address in question. The geocoding search index will be queried for everything above the street level data. No Point of Interest (POIs) will be returned. Note that the geocoder is very tolerant of typos and incomplete addresses. It will also handle everything from exact street addresses or street or intersections as well as higher level geographies such as city centers, counties, states etc.
        /// </summary>
        /// <param name="query"> A string that contains information about a location, such as an address or landmark name. </param>
        /// <param name="options"> additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<GeocodingResponse> GetGeocoding(string query = null, GeocodingQuery options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetGeocoding");
            scope.Start();
            try
            {
                string localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = options?.LocalizedMapView.ToString();
                }

                IEnumerable<double> boundingBox = null;
                if (options?.BoundingBox != null)
                {
                    boundingBox = [options.BoundingBox.North, options.BoundingBox.West, options.BoundingBox.South, options.BoundingBox.East];
                }
                IEnumerable<double> coordinates = null;
                if (options?.Coordinates != null)
                {
                    coordinates = coordinates =
                    [
                        Convert.ToDouble(options?.Coordinates?.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToDouble(options?.Coordinates?.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                    ];
                }

                return RestClient.GetGeocoding(options?.Top, query, options?.AddressLine, options?.CountryRegion, boundingBox, localizedMapView, coordinates, options?.AdminDistrict, options?.AdminDistrict2, options?.AdminDistrict3, options?.Locality, options?.PostalCode, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="queries"> The list of address geocoding queries/requests to process. The list can contain a max of 100 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is empty. </exception>
        public virtual async Task<Response<GeocodingBatchResponse>> GetGeocodingBatchAsync(IEnumerable<GeocodingQuery> queries, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetGeocodingBatch");
            scope.Start();
            try
            {
                GeocodingBatchRequestBody batchRequestBody = geocodingQueriesToGecodingBatchRequestBody(queries);

                return await RestClient.GetGeocodingBatchAsync(batchRequestBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="queries"> The list of address geocoding queries/requests to process. The list can contain a max of 100 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is empty. </exception>
        public virtual Response<GeocodingBatchResponse> GetGeocodingBatch(IEnumerable<GeocodingQuery> queries, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetGeocodingBatch");
            scope.Start();
            try
            {
                GeocodingBatchRequestBody batchRequestBody = geocodingQueriesToGecodingBatchRequestBody(queries);

                return RestClient.GetGeocodingBatch(batchRequestBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Supplies polygon data of a geographical area outline such as a city or a country region.
        /// </summary>
        /// <param name="options"> additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Boundary>> GetPolygonAsync(GetPolygonOptions options = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetPolygon");
            scope.Start();
            try
            {
                string localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = options?.LocalizedMapView.ToString();
                }

                IEnumerable<double> coordinates = null;
#pragma warning disable CS8073 // The result of the expression is always true in net8.0, but not this is not true in netstandard2.0
                if (options.Coordinates != null)
#pragma warning restore CS8073
                {
                    coordinates = coordinates = new[]
                    {
                        Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                        Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                    };
                }
                var boundaryInternal = await RestClient.GetPolygonAsync(coordinates, localizedMapView, options?.ResultType, options?.Resolution, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new Boundary(boundaryInternal.Value), boundaryInternal.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Supplies polygon data of a geographical area outline such as a city or a country region.
        /// </summary>
        /// <param name="options"> additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Boundary> GetPolygon(GetPolygonOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetPolygon");
            scope.Start();
            try
            {
                string localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = options?.LocalizedMapView.ToString();
                }

                IEnumerable<double> coordinates = null;
#pragma warning disable CS8073 // The result of the expression is always true in net8.0, but not this is not true in netstandard2.0
                if (options.Coordinates != null)
#pragma warning restore CS8073
                {
                    coordinates = [(double)options.Coordinates.Longitude, (double)options.Coordinates.Latitude];
                }
                var boundaryInternal = RestClient.GetPolygon(coordinates, localizedMapView, options?.ResultType, options?.Resolution, cancellationToken);
                return Response.FromValue(new Boundary(boundaryInternal.Value), boundaryInternal.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Translate a coordinate (example: 37.786505, -122.3862) into a human understandable street address. Most often this is needed in tracking applications where you receive a GPS feed from the device or asset and wish to know what address where the coordinate is located. This endpoint will return address information for a given coordinate.
        /// </summary>
        /// <param name="coordinates"> The coordinates of the location that you want to reverse geocode. Example: &amp;coordinates=lon,lat. </param>
        /// <param name="options"> additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public virtual async Task<Response<GeocodingResponse>> GetReverseGeocodingAsync(GeoPosition coordinates, ReverseGeocodingQuery options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetReverseGeocoding");
            scope.Start();
            try
            {
                string localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = options?.LocalizedMapView.ToString();
                }

                IEnumerable<double> coordinatesList = null;
#pragma warning disable CS8073 // The result of the expression is always true in net8.0, but not this is not true in netstandard2.0
                if (coordinates != null)
#pragma warning restore CS8073
                {
                    coordinatesList = [coordinates.Longitude, coordinates.Latitude];
                }

                return await RestClient.GetReverseGeocodingAsync(coordinatesList, options?.ResultTypes, localizedMapView, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Translate a coordinate (example: 37.786505, -122.3862) into a human understandable street address. Most often this is needed in tracking applications where you receive a GPS feed from the device or asset and wish to know what address where the coordinate is located. This endpoint will return address information for a given coordinate.
        /// </summary>
        /// <param name="coordinates"> The coordinates of the location that you want to reverse geocode. Here it is represented by GeoPosition. Example: &amp;coordinates=lon,lat. </param>
        /// <param name="options"> additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public virtual Response<GeocodingResponse> GetReverseGeocoding(GeoPosition coordinates, ReverseGeocodingQuery options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetReverseGeocoding");
            scope.Start();
            try
            {
                string localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = options?.LocalizedMapView.ToString();
                }

                IEnumerable<double> coordinatesList = null;
#pragma warning disable CS8073 // The result of the expression is always true in net8.0, but not this is not true in netstandard2.0
                if (coordinates != null)
#pragma warning restore CS8073
                {
                    coordinatesList = new[] { coordinates.Longitude, coordinates.Latitude };
                }
                return RestClient.GetReverseGeocoding(coordinatesList, options?.ResultTypes, localizedMapView, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        ///
        /// The Reverse Geocoding Batch API sends batches of queries to <see href="/rest/api/maps/search/get-reverse-geocoding">Reverse Geocoding API</see> using just a single API call. The API allows caller to batch up to <c>100</c> queries.
        ///
        ///
        /// A reverse geocoding batchItem object can accept any of the supported reverse geocoding <see href="/rest/api/maps/search/get-reverse-geocoding#uri-parameters">URI parameters</see>.
        ///
        ///
        /// The batch should contain at least <c>1</c> query.
        ///
        /// </summary>
        /// <param name="queries"> The list of reverse geocoding queries/requests to process. The list can contain a max of 100 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is empty. </exception>
        public virtual async Task<Response<GeocodingBatchResponse>> GetReverseGeocodingBatchAsync(IEnumerable<ReverseGeocodingQuery> queries, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetReverseGeocodingBatch");
            scope.Start();
            try
            {
                ReverseGeocodingBatchRequestBody requestBody = reverseGeocodingQueriesReversToGecodingBatchRequestBody(queries);

                return await RestClient.GetReverseGeocodingBatchAsync(requestBody, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Reverse Geocoding Batch API sends batches of queries to <see href="/rest/api/maps/search/get-reverse-geocoding">Reverse Geocoding API</see> using just a single API call. The API allows caller to batch up to <c>100</c> queries.
        ///
        /// A reverse geocoding batchItem object can accept any of the supported reverse geocoding  <see href="/rest/api/maps/search/get-reverse-geocoding#uri-parameters">URI parameters</see>.
        ///
        ///
        /// The batch should contain at least <c>1</c> query.
        ///
        /// </summary>
        /// <param name="queries"> The list of reverse geocoding queries/requests to process. The list can contain a max of 100 queries and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is empty. </exception>
        public virtual Response<GeocodingBatchResponse> GetReverseGeocodingBatch(IEnumerable<ReverseGeocodingQuery> queries, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("MapsSearchClient.GetReverseGeocodingBatch");
            scope.Start();
            try
            {
                ReverseGeocodingBatchRequestBody requestBody = reverseGeocodingQueriesReversToGecodingBatchRequestBody(queries);

                return RestClient.GetReverseGeocodingBatch(requestBody, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static ReverseGeocodingBatchRequestBody reverseGeocodingQueriesReversToGecodingBatchRequestBody(IEnumerable<ReverseGeocodingQuery> queries)
        {
            IList<ReverseGeocodingBatchRequestItem> items = new ChangeTrackingList<ReverseGeocodingBatchRequestItem>();

            if (queries == null)
            {
                return null;
            }

            foreach (ReverseGeocodingQuery query in queries)
            {
                ReverseGeocodingBatchRequestItem item = new ReverseGeocodingBatchRequestItem();
                item.OptionalId = query.OptionalId;
#pragma warning disable CS8073 // The result of the expression is always true in net8.0, but not this is not true in netstandard2.0
                if (query.Coordinates != null)
#pragma warning restore CS8073
                {
                    item.Coordinates = new GeoPosition(Convert.ToDouble(query.Coordinates.Longitude), Convert.ToDouble(query.Coordinates.Latitude));
                }
                item.ResultTypes = new List<ResultTypeEnum>();
                if (query.ResultTypes != null)
                {
                    foreach (ReverseGeocodingResultTypeEnum resultType in query.ResultTypes)
                    {
                        item.ResultTypes.Add(new ResultTypeEnum(resultType.ToString()));
                    }
                }
                if (query.LocalizedMapView != null)
                {
                    item.LocalizedMapView = new LocalizedMapView(query.LocalizedMapView.ToString());
                }

                items.Add(item);
            }

            return new ReverseGeocodingBatchRequestBody(items);
        }

        private static GeocodingBatchRequestBody geocodingQueriesToGecodingBatchRequestBody(IEnumerable<GeocodingQuery> queries)
        {
            IList<GeocodingBatchRequestItem> items = new ChangeTrackingList<GeocodingBatchRequestItem>();

            if (queries == null)
            {
                return null;
            }

            foreach (GeocodingQuery query in queries)
            {
                GeocodingBatchRequestItem item = new GeocodingBatchRequestItem();
                item.OptionalId = query.OptionalId;
                item.Top = query.Top;
                item.Query = query.Query;
                item.AddressLine = query.AddressLine;
                item.CountryRegion = query.CountryRegion;
                if (query.BoundingBox != null)
                {
                    item.BoundingBox = new GeoBoundingBox(query.BoundingBox.West, query.BoundingBox.South, query.BoundingBox.East, query.BoundingBox.North);
                }
                if (query.LocalizedMapView != null)
                {
                    item.View = query.LocalizedMapView.ToString();
                }
                if (query.Coordinates != null)
                {
                    item.Coordinates = new GeoPosition(Convert.ToDouble(query.Coordinates?.Longitude), Convert.ToDouble(query.Coordinates?.Latitude));
                }
                item.AdminDistrict = query.AdminDistrict;
                item.AdminDistrict2 = query.AdminDistrict2;
                item.AdminDistrict3 = query.AdminDistrict3;
                item.Locality = query.Locality;
                item.PostalCode = query.PostalCode;
                items.Add(item);
            }
            return new GeocodingBatchRequestBody(items);
        }
    }
}
