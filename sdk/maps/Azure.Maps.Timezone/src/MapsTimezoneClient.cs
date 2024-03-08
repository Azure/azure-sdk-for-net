// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Maps.Common;
using Azure.Maps.Timezone;
using Azure.Maps.Timezone.Models;

namespace Azure.Maps.Timezone
{
    /// <summary> The Timezone service client. </summary>
    public partial class MapsTimezoneClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The restClient is used to access Timezone REST client. </summary>
        internal TimezoneRestClient RestClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of MapsTimezoneClient. </summary>
        protected MapsTimezoneClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            RestClient = null;
        }

        /// <summary> Initializes a new instance of MapsTimezoneClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Timezone Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MapsTimezoneClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimezoneClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Timezone Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsTimezoneClient(AzureKeyCredential credential, MapsTimezoneClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimezoneClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Timezone Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="clientId"/> is null. </exception>
        public MapsTimezoneClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimezoneClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Timezone Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="clientId"/> is null. </exception>
        public MapsTimezoneClient(TokenCredential credential, string clientId, MapsTimezoneClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            options ??= new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimezoneClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        public MapsTimezoneClient(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsTimezoneClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            RestClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsTimezoneClient. </summary>
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
            RestClient = new TimezoneRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary>
        /// __Time Zone by Id__
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns current, historical, and future time zone information for the specified IANA time zone ID.
        /// </summary>
        /// <param name="timezoneId"> The IANA time zone ID. </param>
        /// <param name="acceptLanguage"> Specifies the language code in which the timezone names should be returned. If no language code is provided, the response will be in "EN". Please refer to [Supported Languages](https://docs.microsoft.com/azure/azure-maps/supported-languages) for details. </param>
        /// <param name="options"> Alternatively, use alias "o". Options available for types of information returned in the result. </param>
        /// <param name="timeStamp"> Alternatively, use alias "stamp", or "s". Reference time, if omitted, the API will use the machine time serving the request. </param>
        /// <param name="daylightSavingsTimeFrom"> Alternatively, use alias "tf". The start date from which daylight savings time (DST) transitions are requested, only applies when "options" = all or "options" = transitions. </param>
        /// <param name="daylightSavingsTimeLastingYears"> Alternatively, use alias "ty". The number of years from "transitionsFrom" for which DST transitions are requested, only applies when "options" = all or "options" = transitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timezoneId"/> is null. </exception>
        public virtual async Task<Response<TimezoneResult>> GetTimezoneByIDAsync(string timezoneId, string acceptLanguage = null, TimezoneOptions? options = null, DateTimeOffset? timeStamp = null, DateTimeOffset? daylightSavingsTimeFrom = null, int? daylightSavingsTimeLastingYears = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetTimezoneByID");
            scope.Start();
            try
            {
                return await RestClient.GetTimezoneByIDAsync(
                    JsonFormat.Json,
                    timezoneId,
                    acceptLanguage,
                    options,
                    timeStamp,
                    daylightSavingsTimeFrom,
                    daylightSavingsTimeLastingYears,
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
        /// __Time Zone by Id__
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns current, historical, and future time zone information for the specified IANA time zone ID.
        /// </summary>
        /// <param name="timezoneId"> The IANA time zone ID. </param>
        /// <param name="acceptLanguage"> Specifies the language code in which the timezone names should be returned. If no language code is provided, the response will be in "EN". Please refer to [Supported Languages](https://docs.microsoft.com/azure/azure-maps/supported-languages) for details. </param>
        /// <param name="options"> Alternatively, use alias "o". Options available for types of information returned in the result. </param>
        /// <param name="timeStamp"> Alternatively, use alias "stamp", or "s". Reference time, if omitted, the API will use the machine time serving the request. </param>
        /// <param name="daylightSavingsTimeFrom"> Alternatively, use alias "tf". The start date from which daylight savings time (DST) transitions are requested, only applies when "options" = all or "options" = transitions. </param>
        /// <param name="daylightSavingsTimeLastingYears"> Alternatively, use alias "ty". The number of years from "transitionsFrom" for which DST transitions are requested, only applies when "options" = all or "options" = transitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="timezoneId"/> is null. </exception>
        public virtual Response<TimezoneResult> GetTimezoneByID(string timezoneId, string acceptLanguage = null, TimezoneOptions? options = null, DateTimeOffset? timeStamp = null, DateTimeOffset? daylightSavingsTimeFrom = null, int? daylightSavingsTimeLastingYears = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetTimezoneByID");
            scope.Start();
            try
            {
                return RestClient.GetTimezoneByID(
                    JsonFormat.Json,
                    timezoneId,
                    acceptLanguage,
                    options,
                    timeStamp,
                    daylightSavingsTimeFrom,
                    daylightSavingsTimeLastingYears,
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
        /// __Time Zone by Coordinates__
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns current, historical, and future time zone information for a specified latitude-longitude pair. In addition, the API provides sunset and sunrise times for a given location.
        /// </summary>
        /// <param name="coordinates"> Coordinates of the point for which time zone information is requested. This parameter is a list of coordinates, containing a pair of coordinate(lat, long). When this endpoint is called directly, coordinates are passed in as a single string containing coordinates, separated by commas. </param>
        /// <param name="acceptLanguage"> Specifies the language code in which the timezone names should be returned. If no language code is provided, the response will be in "EN". Please refer to [Supported Languages](https://docs.microsoft.com/azure/azure-maps/supported-languages) for details. </param>
        /// <param name="options"> Alternatively, use alias "o". Options available for types of information returned in the result. </param>
        /// <param name="timeStamp"> Alternatively, use alias "stamp", or "s". Reference time, if omitted, the API will use the machine time serving the request. </param>
        /// <param name="daylightSavingsTimeFrom"> Alternatively, use alias "tf". The start date from which daylight savings time (DST) transitions are requested, only applies when "options" = all or "options" = transitions. </param>
        /// <param name="daylightSavingsTimeLastingYears"> Alternatively, use alias "ty". The number of years from "transitionsFrom" for which DST transitions are requested, only applies when "options" = all or "options" = transitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public virtual async Task<Response<TimezoneResult>> GetTimezoneByCoordinatesAsync(IEnumerable<double> coordinates, string acceptLanguage = null, TimezoneOptions? options = null, DateTimeOffset? timeStamp = null, DateTimeOffset? daylightSavingsTimeFrom = null, int? daylightSavingsTimeLastingYears = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetTimezoneByCoordinates");
            scope.Start();
            try
            {
                return await RestClient.GetTimezoneByCoordinatesAsync(
                    JsonFormat.Json,
                    coordinates,
                    acceptLanguage,
                    options,
                    timeStamp,
                    daylightSavingsTimeFrom,
                    daylightSavingsTimeLastingYears,
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
        /// __Time Zone by Coordinates__
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns current, historical, and future time zone information for a specified latitude-longitude pair. In addition, the API provides sunset and sunrise times for a given location.
        /// </summary>
        /// <param name="coordinates"> Coordinates of the point for which time zone information is requested. This parameter is a list of coordinates, containing a pair of coordinate(lat, long). When this endpoint is called directly, coordinates are passed in as a single string containing coordinates, separated by commas. </param>
        /// <param name="acceptLanguage"> Specifies the language code in which the timezone names should be returned. If no language code is provided, the response will be in "EN". Please refer to [Supported Languages](https://docs.microsoft.com/azure/azure-maps/supported-languages) for details. </param>
        /// <param name="options"> Alternatively, use alias "o". Options available for types of information returned in the result. </param>
        /// <param name="timeStamp"> Alternatively, use alias "stamp", or "s". Reference time, if omitted, the API will use the machine time serving the request. </param>
        /// <param name="daylightSavingsTimeFrom"> Alternatively, use alias "tf". The start date from which daylight savings time (DST) transitions are requested, only applies when "options" = all or "options" = transitions. </param>
        /// <param name="daylightSavingsTimeLastingYears"> Alternatively, use alias "ty". The number of years from "transitionsFrom" for which DST transitions are requested, only applies when "options" = all or "options" = transitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="coordinates"/> is null. </exception>
        public virtual Response<TimezoneResult> GetTimezoneByCoordinates(IEnumerable<double> coordinates, string acceptLanguage = null, TimezoneOptions? options = null, DateTimeOffset? timeStamp = null, DateTimeOffset? daylightSavingsTimeFrom = null, int? daylightSavingsTimeLastingYears = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetTimezoneByCoordinates");
            scope.Start();
            try
            {
                return RestClient.GetTimezoneByCoordinates(
                    JsonFormat.Json,
                    coordinates,
                    acceptLanguage,
                    options,
                    timeStamp,
                    daylightSavingsTimeFrom,
                    daylightSavingsTimeLastingYears,
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
        /// __Windows Time Zones__
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns a full list of Windows Time Zone IDs.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<TimezoneWindows>>> GetWindowsTimezoneIdsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetWindowsTimezoneIds");
            scope.Start();
            try
            {
                return await RestClient.GetWindowsTimezoneIdsAsync(
                    JsonFormat.Json,
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
        /// __Windows Time Zones__
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns a full list of Windows Time Zone IDs.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<TimezoneWindows>> GetWindowsTimezoneIds(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetWindowsTimezoneIds");
            scope.Start();
            try
            {
                return RestClient.GetWindowsTimezoneIds(
                    JsonFormat.Json,
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
        /// __IANA Time Zones__
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns a full list of IANA time zone IDs. Updates to the IANA service will be reflected in the system within one day.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<IanaId>>> GetIanaTimezoneIdsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetIanaTimezoneIds");
            scope.Start();
            try
            {
                return await RestClient.GetIanaTimezoneIdsAsync(
                    JsonFormat.Json,
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
        /// __IANA Time Zones__
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns a full list of IANA time zone IDs. Updates to the IANA service will be reflected in the system within one day.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<IanaId>> GetIanaTimezoneIds(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetWindowsTimezoneIds");
            scope.Start();
            try
            {
                return RestClient.GetIanaTimezoneIds(
                    JsonFormat.Json,
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
        /// __Time Zone IANA Version__
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns the current IANA version number as Metadata.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TimezoneIanaVersionResult>> GetIanaVersionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetIanaVersion");
            scope.Start();
            try
            {
                return await RestClient.GetIanaVersionAsync(
                    JsonFormat.Json,
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
        /// __Time Zone IANA Version__
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns the current IANA version number as Metadata.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TimezoneIanaVersionResult> GetIanaVersion(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.GetIanaVersion");
            scope.Start();
            try
            {
                return RestClient.GetIanaVersion(
                    JsonFormat.Json,
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
        /// __Windows to IANA Time Zone__
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns a corresponding IANA ID, given a valid Windows Time Zone ID. Multiple IANA IDs may be returned for a single Windows ID. It is possible to narrow these results by adding an optional territory parameter.
        /// </summary>
        /// <param name="windowsTimezoneId"> The Windows time zone ID. </param>
        /// <param name="windowsTerritoryCode"> Windows Time Zone territory code. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="windowsTimezoneId"/> is null. </exception>
        public virtual async Task<Response<IReadOnlyList<IanaId>>> ConvertWindowsTimezoneToIanaAsync(string windowsTimezoneId, string windowsTerritoryCode = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.ConvertWindowsTimezoneToIana");
            scope.Start();
            try
            {
                return await RestClient.ConvertWindowsTimezoneToIanaAsync(
                    JsonFormat.Json,
                    windowsTimezoneId,
                    windowsTerritoryCode,
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
        /// __Windows to IANA Time Zone__
        ///
        ///
        /// **Applies to:** see [pricing tiers](https://aka.ms/AzureMapsPricingTier).
        ///
        ///
        /// This API returns a corresponding IANA ID, given a valid Windows Time Zone ID. Multiple IANA IDs may be returned for a single Windows ID. It is possible to narrow these results by adding an optional territory parameter.
        /// </summary>
        /// <param name="windowsTimezoneId"> The Windows time zone ID. </param>
        /// <param name="windowsTerritoryCode"> Windows Time Zone territory code. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="windowsTimezoneId"/> is null. </exception>
        public virtual Response<IReadOnlyList<IanaId>> ConvertWindowsTimezoneToIana(string windowsTimezoneId, string windowsTerritoryCode = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsTimezoneClient.ConvertWindowsTimezoneToIana");
            scope.Start();
            try
            {
                return RestClient.ConvertWindowsTimezoneToIana(
                    JsonFormat.Json,
                    windowsTimezoneId,
                    windowsTerritoryCode,
                    cancellationToken
                );
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
