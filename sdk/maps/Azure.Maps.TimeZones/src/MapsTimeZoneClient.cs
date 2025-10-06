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

namespace Azure.Maps.TimeZones
{
    /// <summary> The Render service client. </summary>
    public partial class MapsTimeZoneClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The restClient is used to access Render REST client. </summary>
        internal TimezoneRestClient restClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of MapsTimeZoneClient. </summary>
        protected MapsTimeZoneClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            restClient = null;
        }

        /// <summary> Initializes a new instance of MapsTimeZoneClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        public MapsTimeZoneClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsTimeZoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimeZoneClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsTimeZoneClient(AzureKeyCredential credential, MapsTimeZoneClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options?.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsTimeZoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimeZoneClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        public MapsTimeZoneClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsTimeZoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimeZoneClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsTimeZoneClient(TokenCredential credential, string clientId, MapsTimeZoneClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options?.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsTimeZoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimeZoneClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        /// <param name="options"> The options for configuring the client. If options is <c>null</c>, default option settings will be applied. </param>
        public MapsTimeZoneClient(AzureSasCredential credential, MapsTimeZoneClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options?.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsTimeZoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimeZoneClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal MapsTimeZoneClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string clientId = null, MapsTimeZoneClientOptions.ServiceVersion apiVersion = MapsTimeZoneClientOptions.LatestVersion)
        {
            var options = new MapsTimeZoneClientOptions(apiVersion);
            restClient = new TimezoneRestClient(clientDiagnostics, pipeline, endpoint, clientId, options.Version);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary>
        /// This API returns current, historical, and future time zone information for the specified IANA time zone ID.
        /// </summary>
        /// <param name="timeZoneId"> The IANA time zone ID. </param>
        /// <param name="options"> Contains parameters for get timezone by id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timeZoneId"/> is null. </exception>
        public virtual async Task<Response<TimeZoneResult>> GetTimeZoneByIdAsync(string timeZoneId, GetTimeZoneOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetTimeZoneById");
            scope.Start();
            try
            {
                return await restClient.GetTimezoneByIDAsync(JsonFormat.Json, timeZoneId, options.AcceptLanguage, options?.AdditionalTimeZoneReturnInformation, options?.TimeStamp, options?.DaylightSavingsTimeTransitionFrom, options?.DaylightSavingsTimeTransitionInYears, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This API returns current, historical, and future time zone information for the specified IANA time zone ID.
        /// </summary>
        /// <param name="timeZoneId"> The IANA time zone ID. </param>
        /// <param name="options"> Contains parameters for get timezone by id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timeZoneId"/> is null. </exception>
        public virtual Response<TimeZoneResult> GetTimeZoneById(string timeZoneId, GetTimeZoneOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetTimeZoneById");
            scope.Start();
            try
            {
                return restClient.GetTimezoneByID(JsonFormat.Json, timeZoneId, options.AcceptLanguage, options?.AdditionalTimeZoneReturnInformation, options?.TimeStamp, options?.DaylightSavingsTimeTransitionFrom, options?.DaylightSavingsTimeTransitionInYears, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the current, historical, and future time zone information for the specified latitude-longitude pair..
        /// </summary>
        /// <param name="coordinates"> Coordinates of the point for which time zone information is requested. This parameter is a list of coordinates, containing a pair of coordinate(lat, long). When this endpoint is called directly, coordinates are passed in as a single string containing coordinates, separated by commas. </param>
        /// <param name="options"> Contains parameters for get timezone by id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public virtual async Task<Response<TimeZoneResult>> GetTimeZoneByCoordinatesAsync(GeoPosition coordinates, GetTimeZoneOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetTimeZoneByCoordinates");
            scope.Start();
            try
            {
                var coord = new[]
               {
                     Convert.ToDouble(coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                     Convert.ToDouble(coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                 };
                return await restClient.GetTimezoneByCoordinatesAsync(
                    JsonFormat.Json,
                    coord,
                    options.AcceptLanguage,
                    options?.AdditionalTimeZoneReturnInformation,
                    options?.TimeStamp,
                    options?.DaylightSavingsTimeTransitionFrom,
                    options?.DaylightSavingsTimeTransitionInYears,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the current, historical, and future time zone information for the specified latitude-longitude pair..
        /// </summary>
        /// <param name="coordinates"> Coordinates of the point for which time zone information is requested. This parameter is a list of coordinates, containing a pair of coordinate(lat, long). When this endpoint is called directly, coordinates are passed in as a single string containing coordinates, separated by commas. </param>
        /// <param name="options"> Contains parameters for get timezone by id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public virtual Response<TimeZoneResult> GetTimeZoneByCoordinates(GeoPosition coordinates, GetTimeZoneOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetTimeZoneByCoordinates");
            scope.Start();
            try
            {
                var coord = new[]
                {
                     Convert.ToDouble(coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                     Convert.ToDouble(coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                 };
                return restClient.GetTimezoneByCoordinates(
                    JsonFormat.Json,
                    coord,
                    options.AcceptLanguage,
                    options?.AdditionalTimeZoneReturnInformation,
                    options?.TimeStamp,
                    options?.DaylightSavingsTimeTransitionFrom,
                    options?.DaylightSavingsTimeTransitionInYears,
                    cancellationToken
                );
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the list of Windows Time Zone IDs.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<WindowsTimeZoneData>> GetWindowsTimeZoneIdsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetWindowsTimeZoneIds");
            scope.Start();
            try
            {
                Response<IReadOnlyList<WindowsTimeZone>> response = await restClient.GetWindowsTimezoneIdsAsync(JsonFormat.Json, cancellationToken).ConfigureAwait(false);
                var value = new WindowsTimeZoneData(response.Value);
                return Response.FromValue(value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the list of Windows time zone IDs.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<WindowsTimeZoneData> GetWindowsTimeZoneIds(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetWindowsTimeZoneIds");
            scope.Start();
            try
            {
                Response<IReadOnlyList<WindowsTimeZone>> response = restClient.GetWindowsTimezoneIds(JsonFormat.Json, cancellationToken);
                var value = new WindowsTimeZoneData(response.Value);
                return Response.FromValue(value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the list of IANA time zone IDs.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// The <c>Get IANA Time Zones</c> API is an HTTP <c>GET</c> request that returns a full list of Internet Assigned Numbers Authority (IANA) time zone IDs. Updates to the IANA service are reflected in the system within one day.
        /// </remarks>
        public virtual async Task<Response<IanaIdData>> GetTimeZoneIanaIdsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetTimeZoneIanaIds");
            scope.Start();
            try
            {
                Response<IReadOnlyList<IanaId>> response = await restClient.GetIanaTimezoneIdsAsync(JsonFormat.Json, cancellationToken).ConfigureAwait(false);
                var value = new IanaIdData(response.Value);
                return Response.FromValue(value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the list of IANA time zone IDs.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// The <c>Get IANA Time Zones</c> API is an HTTP <c>GET</c> request that returns a full list of Internet Assigned Numbers Authority (IANA) time zone IDs. Updates to the IANA service are reflected in the system within one day.
        /// </remarks>
        public virtual Response<IanaIdData> GetTimeZoneIanaIds(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetTimeZoneIanaIds");
            scope.Start();
            try
            {
                Response<IReadOnlyList<IanaId>> response = restClient.GetIanaTimezoneIds(JsonFormat.Json, cancellationToken);
                var value = new IanaIdData(response.Value);
                return Response.FromValue(value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the current IANA version number.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// The `Get Time Zone IANA Version` API is an HTTP `GET` request that returns the current Internet Assigned Numbers Authority (IANA) version number as Metadata.
        /// </remarks>
        public virtual async Task<Response<TimeZoneIanaVersionResult>> GetIanaVersionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetIanaVersion");
            scope.Start();
            try
            {
                return await restClient.GetIanaVersionAsync(JsonFormat.Json, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the current IANA version number.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks>
        /// The `Get Time Zone IANA Version` API is an HTTP `GET` request that returns the current Internet Assigned Numbers Authority (IANA) version number as Metadata.
        /// </remarks>
        public virtual Response<TimeZoneIanaVersionResult> GetIanaVersion(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.GetIanaVersion");
            scope.Start();
            try
            {
                return restClient.GetIanaVersion(JsonFormat.Json, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the IANA ID.
        /// </summary>
        /// <param name="windowsTimeZoneId"> The Windows time zone ID. </param>
        /// <param name="windowsTerritoryCode"> Windows Time Zone territory code. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="windowsTimeZoneId"/> is null. </exception>
        /// <remarks>
        /// The `Get Windows to IANA Time Zone` API is an HTTP `GET` request that returns a corresponding Internet Assigned Numbers Authority (IANA) ID, given a valid Windows Time Zone ID. Multiple IANA IDs may be returned for a single Windows ID. It is possible to narrow these results by adding an optional territory parameter.
        /// </remarks>
        public virtual async Task<Response<IanaIdData>> ConvertWindowsTimeZoneToIanaAsync(string windowsTimeZoneId, string windowsTerritoryCode = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.ConvertWindowsTimeZoneToIana");
            scope.Start();
            try
            {
                Response<IReadOnlyList<IanaId>> response = await restClient.ConvertWindowsTimezoneToIanaAsync(JsonFormat.Json, windowsTimeZoneId, windowsTerritoryCode, cancellationToken).ConfigureAwait(false);
                var value = new IanaIdData(response.Value);
                return Response.FromValue(value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the IANA ID.
        /// </summary>
        /// <param name="windowsTimeZoneId"> The Windows time zone ID. </param>
        /// <param name="windowsTerritoryCode"> Windows Time Zone territory code. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="windowsTimeZoneId"/> is null. </exception>
        /// <remarks>
        /// The <c>Get Windows to IANA Time Zone</c> API is an HTTP <c>GET</c> request that returns a corresponding Internet Assigned Numbers Authority (IANA) ID, given a valid Windows Time Zone ID. Multiple IANA IDs may be returned for a single Windows ID. It is possible to narrow these results by adding an optional territory parameter.
        /// </remarks>
        public virtual Response<IanaIdData> ConvertWindowsTimeZoneToIana(string windowsTimeZoneId, string windowsTerritoryCode = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimeZoneClient.ConvertWindowsTimeZoneToIana");
            scope.Start();
            try
            {
                Response<IReadOnlyList<IanaId>> response = restClient.ConvertWindowsTimezoneToIana(JsonFormat.Json, windowsTimeZoneId, windowsTerritoryCode, cancellationToken);
                var value = new IanaIdData(response.Value);
                return Response.FromValue(value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
