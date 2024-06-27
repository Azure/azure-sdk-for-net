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
using Azure.Maps.Timezone.Models.Options;

namespace Azure.Maps.Timezone
{
    /// <summary> The Render service client. </summary>
    public partial class MapsTimezoneClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The restClient is used to access Render REST client. </summary>
        internal TimezoneRestClient restClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        protected MapsTimezoneClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            restClient = null;
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        public MapsTimezoneClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsTimezoneClient(AzureKeyCredential credential, MapsTimezoneClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        public MapsTimezoneClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsTimezoneClient(TokenCredential credential, string clientId, MapsTimezoneClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        public MapsTimezoneClient(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsTimezoneClient(AzureSasCredential credential, MapsTimezoneClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            restClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal MapsTimezoneClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string clientId = null, MapsTimezoneClientOptions.ServiceVersion apiVersion = MapsTimezoneClientOptions.LatestVersion)
        {
            var options = new MapsTimezoneClientOptions(apiVersion);
            restClient = new TimezoneRestClient(clientDiagnostics, pipeline, endpoint, clientId, options.Version);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary>
        /// This API returns current, historical, and future time zone information for the specified IANA time zone ID.
        /// </summary>
        /// <param name="timezoneId"> The IANA time zone ID. </param>
        /// <param name="options"> Contains parameters for get timezone by id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timezoneId"/> is null. </exception>
        public virtual async Task<Response<TimezoneResult>> GetTimezoneByIDAsync(string timezoneId, TimezoneBaseOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetTimezoneByID");
            scope.Start();
            try
            {
                return await restClient.GetTimezoneByIDAsync(JsonFormat.Json, timezoneId, options.AcceptLanguage, options?.Options, options?.TimeStamp, options?.DaylightSavingsTimeFrom, options?.DaylightSavingsTimeLastingYears, cancellationToken).ConfigureAwait(false);
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
        /// <param name="timezoneId"> The IANA time zone ID. </param>
        /// <param name="options"> Contains parameters for get timezone by id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timezoneId"/> is null. </exception>
        public virtual Response<TimezoneResult> GetTimezoneByID(string timezoneId, TimezoneBaseOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetTimezoneByID");
            scope.Start();
            try
            {
                return restClient.GetTimezoneByID(JsonFormat.Json, timezoneId, options.AcceptLanguage, options?.Options, options?.TimeStamp, options?.DaylightSavingsTimeFrom, options?.DaylightSavingsTimeLastingYears, cancellationToken);
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
        public virtual async Task<Response<TimezoneResult>> GetTimezoneByCoordinatesAsync(GeoPosition coordinates, TimezoneBaseOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetTimezoneByCoordinates");
            scope.Start();
            try
            {
                var coord = new[]
               {
                     Convert.ToDouble(coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                     Convert.ToDouble(coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                 };
                return await restClient.GetTimezoneByCoordinatesAsync(JsonFormat.Json, coord, options.AcceptLanguage, options?.Options, options?.TimeStamp, options?.DaylightSavingsTimeFrom, options?.DaylightSavingsTimeLastingYears, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<TimezoneResult> GetTimezoneByCoordinates(GeoPosition coordinates, TimezoneBaseOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetTimezoneByCoordinates");
            scope.Start();
            try
            {
                var coord = new[]
                {
                     Convert.ToDouble(coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                     Convert.ToDouble(coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                 };
                return restClient.GetTimezoneByCoordinates(JsonFormat.Json, coord, options.AcceptLanguage, options?.Options, options?.TimeStamp, options?.DaylightSavingsTimeFrom, options?.DaylightSavingsTimeLastingYears, cancellationToken);
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
        public virtual async Task<Response<IReadOnlyList<TimezoneWindows>>> GetWindowsTimezoneIdsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetWindowsTimezoneIds");
            scope.Start();
            try
            {
                return await restClient.GetWindowsTimezoneIdsAsync(JsonFormat.Json, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<IReadOnlyList<TimezoneWindows>> GetWindowsTimezoneIds(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetWindowsTimezoneIds");
            scope.Start();
            try
            {
                return restClient.GetWindowsTimezoneIds(JsonFormat.Json, cancellationToken);
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
        /// The `Get IANA Time Zones` API is an HTTP `GET` request that returns a full list of Internet Assigned Numbers Authority (IANA) time zone IDs. Updates to the IANA service are reflected in the system within one day.
        /// </remarks>
        public virtual async Task<Response<IReadOnlyList<IanaId>>> GetIanaTimezoneIdsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetIanaTimezoneIds");
            scope.Start();
            try
            {
                return await restClient.GetIanaTimezoneIdsAsync(JsonFormat.Json, cancellationToken).ConfigureAwait(false);
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
        /// The `Get IANA Time Zones` API is an HTTP `GET` request that returns a full list of Internet Assigned Numbers Authority (IANA) time zone IDs. Updates to the IANA service are reflected in the system within one day.
        /// </remarks>
        public virtual Response<IReadOnlyList<IanaId>> GetIanaTimezoneIds(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetIanaTimezoneIds");
            scope.Start();
            try
            {
                return restClient.GetIanaTimezoneIds(JsonFormat.Json, cancellationToken);
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
        public virtual async Task<Response<TimezoneIanaVersionResult>> GetIanaVersionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetIanaVersion");
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
        public virtual Response<TimezoneIanaVersionResult> GetIanaVersion(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetIanaVersion");
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
        /// <param name="windowsTimezoneId"> The Windows time zone ID. </param>
        /// <param name="windowsTerritoryCode"> Windows Time Zone territory code. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="windowsTimezoneId"/> is null. </exception>
        /// <remarks>
        /// The `Get Windows to IANA Time Zone` API is an HTTP `GET` request that returns a corresponding Internet Assigned Numbers Authority (IANA) ID, given a valid Windows Time Zone ID. Multiple IANA IDs may be returned for a single Windows ID. It is possible to narrow these results by adding an optional territory parameter.
        /// </remarks>
        public virtual async Task<Response<IReadOnlyList<IanaId>>> ConvertWindowsTimezoneToIanaAsync(string windowsTimezoneId, string windowsTerritoryCode = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.ConvertWindowsTimezoneToIana");
            scope.Start();
            try
            {
                return await restClient.ConvertWindowsTimezoneToIanaAsync(JsonFormat.Json, windowsTimezoneId, windowsTerritoryCode, cancellationToken).ConfigureAwait(false);
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
        /// <param name="windowsTimezoneId"> The Windows time zone ID. </param>
        /// <param name="windowsTerritoryCode"> Windows Time Zone territory code. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="windowsTimezoneId"/> is null. </exception>
        /// <remarks>
        /// The `Get Windows to IANA Time Zone` API is an HTTP `GET` request that returns a corresponding Internet Assigned Numbers Authority (IANA) ID, given a valid Windows Time Zone ID. Multiple IANA IDs may be returned for a single Windows ID. It is possible to narrow these results by adding an optional territory parameter.
        /// </remarks>
        public virtual Response<IReadOnlyList<IanaId>> ConvertWindowsTimezoneToIana(string windowsTimezoneId, string windowsTerritoryCode = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.ConvertWindowsTimezoneToIana");
            scope.Start();
            try
            {
                return restClient.ConvertWindowsTimezoneToIana(JsonFormat.Json, windowsTimezoneId, windowsTerritoryCode, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
