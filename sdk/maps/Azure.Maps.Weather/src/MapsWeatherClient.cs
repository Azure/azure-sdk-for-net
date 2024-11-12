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
using Azure.Maps.Weather.Models;
using Azure.Maps.Weather.Models.Options;

namespace Azure.Maps.Weather
{
    // Data plane generated client.
    /// <summary> The Weather service client. </summary>
    public partial class MapsWeatherClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The restClient is used to access Weather REST client. </summary>
        internal WeatherRestClient restClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of MapsWeatherClient. </summary>
        protected MapsWeatherClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            restClient = null;
        }

        /// <summary> Initializes a new instance of MapsWeatherClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Weather Service. </param>
        public MapsWeatherClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsWeatherClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new WeatherRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsWeatherClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Weather Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsWeatherClient(AzureKeyCredential credential, MapsWeatherClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsWeatherClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new WeatherRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsWeatherClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Weather Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        public MapsWeatherClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsWeatherClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new WeatherRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsWeatherClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Weather Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsWeatherClient(TokenCredential credential, string clientId, MapsWeatherClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsWeatherClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new WeatherRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsWeatherClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        public MapsWeatherClient(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsWeatherClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            restClient = new WeatherRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsWeatherClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsWeatherClient(AzureSasCredential credential, MapsWeatherClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsWeatherClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            restClient = new WeatherRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }
        /// <summary>
        /// Use to get a detailed hourly weather forecast for up to 24 hours or a daily forecast for up to 10 days.
        /// </summary>
        /// <param name="options"> Get hourly forecast options to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<HourlyForecastResult>> GetHourlyWeatherForecastAsync(GetHourlyWeatherForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetHourlyWeatherForecast");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetHourlyForecastAsync(JsonFormat.Json, coord, options.Unit, options.DurationInHours, options.Language.ToString(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a detailed hourly weather forecast for up to 24 hours or a daily forecast for up to 10 days.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<HourlyForecastResult> GetHourlyWeatherForecast(GetHourlyWeatherForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetHourlyWeatherForecast");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetHourlyForecast(JsonFormat.Json, coord, options.Unit, options.DurationInHours, options.Language.ToString(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a minute-by-minute forecast for the next 120 minutes in intervals of 1, 5 and 15 minutes.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<MinuteForecastResult>> GetMinuteWeatherForecastAsync(GetMinuteWeatherForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetMinuteWeatherForecast");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetMinuteForecastAsync(JsonFormat.Json, coord, options.IntervalInMinutes, options.Language.ToString(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a minute-by-minute forecast for the next 120 minutes in intervals of 1, 5 and 15 minutes.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<MinuteForecastResult> GetMinuteWeatherForecast(GetMinuteWeatherForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetMinuteWeatherForecast");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetMinuteForecast(JsonFormat.Json, coord, options.IntervalInMinutes, options.Language.ToString(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a Quarter-Day Forecast for the next 1, 5, 10, or 15 days.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<QuarterDayForecastResult>> GetQuarterDayWeatherForecastAsync(GetQuarterDayWeatherForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetQuarterDayWeatherForecast");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetQuarterDayForecastAsync(JsonFormat.Json, coord, options.Unit, options.DurationInDays, options.Language.ToString(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a Quarter-Day Forecast for the next 1, 5, 10, or 15 days.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<QuarterDayForecastResult> GetQuarterDayWeatherForecast(GetQuarterDayWeatherForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetQuarterDayWeatherForecast");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetQuarterDayForecast(JsonFormat.Json, coord, options.Unit, options.DurationInDays, options.Language.ToString(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get current weather conditions.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<CurrentConditionsResult>> GetCurrentWeatherConditionsAsync(GetCurrentWeatherConditionsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetCurrentWeatherConditions");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetCurrentConditionsAsync(JsonFormat.Json, coord, options.Unit, options.IncludeDetails ? "true" : "false", options.DurationInHours, options.Language.ToString(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get current weather conditions.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<CurrentConditionsResult> GetCurrentWeatherConditions(GetCurrentWeatherConditionsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetCurrentWeatherConditions");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetCurrentConditions(JsonFormat.Json, coord, options.Unit, options.IncludeDetails ? "true" : "false", options.DurationInHours, options.Language.ToString(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a daily detailed weather forecast for the next 1, 5, 10, 15, 25, or 45 days.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<DailyForecastResult>> GetDailyWeatherForecastAsync(GetDailyWeatherForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyWeatherForecast");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetDailyForecastAsync(JsonFormat.Json, coord, options.Unit, options.DurationInDays, options.Language.ToString(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a daily detailed weather forecast for the next 1, 5, 10, 15, 25, or 45 days.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<DailyForecastResult> GetDailyWeatherForecast(GetDailyWeatherForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyWeatherForecast");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetDailyForecast(JsonFormat.Json, coord, options.Unit, options.DurationInDays, options.Language.ToString(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a locationally precise, up-to-the-minute forecast that includes weather hazard assessments and notifications along a route.
        /// </summary>
        /// <param name="query">
        /// Coordinates through which the route is calculated, separated by colon (:) and entered in chronological order. A minimum of two waypoints is required. A single API call may contain up to 60 waypoints.
        /// A waypoint indicates location, ETA, and optional heading: latitude,longitude,ETA,heading, where
        /// <list>
        ///   <item><c>Latitude</c> - Latitude coordinate in decimal degrees.</item>
        ///   <item><c>Longitude</c> - Longitude coordinate in decimal degrees.</item>
        ///   <item><c>ETA (estimated time of arrival)</c> - The number of minutes from the present time that it will take for the vehicle to reach the waypoint. Allowed range is from 0.0 to 120.0 minutes.</item>
        ///   <item><c>Heading</c> - An optional value indicating the vehicle heading as it passes the waypoint. Expressed in clockwise degrees relative to true north. This is issued to calculate sun glare as a driving hazard. Allowed range is from 0.0 to 360.0 degrees. If not provided, a heading will automatically be derived based on the position of neighboring waypoints.</item>
        ///</list>
        /// It is recommended to stay within, or close to, the distance that can be traveled within 120-mins or shortly after. This way a more accurate assessment can be provided for the trip and prevent isolated events not being captured between waypoints.  Information can and should be updated along the route (especially for trips greater than 2 hours) to continuously pull new waypoints moving forward, but also to ensure that forecast information for content such as precipitation type and intensity is accurate as storms develop and dissipate over time.
        /// </param>
        /// <param name="language">
        /// Language in which search results should be returned. Should be one of supported IETF language tags, case insensitive. When data in specified language is not available for a specific field, default language is used.
        ///
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<WeatherAlongRouteResult>> GetWeatherAlongRouteAsync(WeatherAlongRouteQuery query, WeatherLanguage language, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(query, nameof(query));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetWeatherAlongRoute");
            scope.Start();
            try
            {
                string queryString = "";
                foreach (WeatherAlongRouteWaypoint waypoint in query.Waypoints) {
                    if (waypoint.Heading == null) {
                        queryString += $"{waypoint.Coordinates.Latitude},{waypoint.Coordinates.Longitude},{waypoint.EtaInMinutes}:";
                    } else {
                        queryString += $"{waypoint.Coordinates.Latitude},{waypoint.Coordinates.Longitude},{waypoint.Heading},{waypoint.EtaInMinutes}:";
                    }
                }
                queryString = queryString.Substring(0, queryString.Length - 1);
                return await restClient.GetWeatherAlongRouteAsync(JsonFormat.Json, queryString, language.ToString(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a locationally precise, up-to-the-minute forecast that includes weather hazard assessments and notifications along a route.
        /// </summary>
        /// <param name="query">
        /// Coordinates through which the route is calculated, separated by colon (:) and entered in chronological order. A minimum of two waypoints is required. A single API call may contain up to 60 waypoints.
        /// A waypoint indicates location, ETA, and optional heading: latitude,longitude,ETA,heading, where
        /// <list>
        ///   <item><c>Latitude</c> - Latitude coordinate in decimal degrees.</item>
        ///   <item><c>Longitude</c> - Longitude coordinate in decimal degrees.</item>
        ///   <item><c>ETA (estimated time of arrival)</c> - The number of minutes from the present time that it will take for the vehicle to reach the waypoint. Allowed range is from 0.0 to 120.0 minutes.</item>
        ///   <item><c>Heading</c> - An optional value indicating the vehicle heading as it passes the waypoint. Expressed in clockwise degrees relative to true north. This is issued to calculate sun glare as a driving hazard. Allowed range is from 0.0 to 360.0 degrees. If not provided, a heading will automatically be derived based on the position of neighboring waypoints.</item>
        ///</list>
        /// It is recommended to stay within, or close to, the distance that can be traveled within 120-mins or shortly after. This way a more accurate assessment can be provided for the trip and prevent isolated events not being captured between waypoints.  Information can and should be updated along the route (especially for trips greater than 2 hours) to continuously pull new waypoints moving forward, but also to ensure that forecast information for content such as precipitation type and intensity is accurate as storms develop and dissipate over time.
        /// </param>
        /// <param name="language">
        /// Language in which search results should be returned. Should be one of supported IETF language tags, case insensitive. When data in specified language is not available for a specific field, default language is used.
        ///
        /// Please refer to <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported Languages</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<WeatherAlongRouteResult> GetWeatherAlongRoute(WeatherAlongRouteQuery query, WeatherLanguage language, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(query, nameof(query));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetWeatherAlongRoute");
            scope.Start();
            try
            {
                string queryString = "";
                foreach (WeatherAlongRouteWaypoint waypoint in query.Waypoints) {
                    if (waypoint.Heading == null) {
                        queryString += $"{waypoint.Coordinates.Latitude},{waypoint.Coordinates.Longitude},{waypoint.EtaInMinutes}:";
                    } else {
                        queryString += $"{waypoint.Coordinates.Latitude},{waypoint.Coordinates.Longitude},{waypoint.Heading},{waypoint.EtaInMinutes}:";
                    }
                }
                queryString = queryString.Substring(0, queryString.Length - 1);
                return restClient.GetWeatherAlongRoute(JsonFormat.Json, queryString, language.ToString(), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get information about severe weather conditions such as hurricanes, thunderstorms, flooding, lightning, heat waves or forest fires for a given location.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<SevereWeatherAlertsResult>> GetSevereWeatherAlertsAsync(GetSevereWeatherAlertsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetSevereWeatherAlerts");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetSevereWeatherAlertsAsync(JsonFormat.Json, coord, options.Language.ToString(), options.IncludeDetails ? "true" : "false", cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get information about severe weather conditions such as hurricanes, thunderstorms, flooding, lightning, heat waves or forest fires for a given location.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<SevereWeatherAlertsResult> GetSevereWeatherAlerts(GetSevereWeatherAlertsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetSevereWeatherAlerts");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetSevereWeatherAlerts(JsonFormat.Json, coord, options.Language.ToString(), options.IncludeDetails ? "true" : "false", cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use when you want to know if the weather conditions are optimal for a specific activity such as outdoor sporting activities, construction, or farming (results includes soil moisture information).
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<DailyIndicesResult>> GetDailyIndicesAsync(GetDailyIndicesOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyIndices");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetDailyIndicesAsync(JsonFormat.Json, coord, options.Language.ToString(), options.DurationInDays, options.IndexId, options.IndexGroupId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use when you want to know if the weather conditions are optimal for a specific activity such as outdoor sporting activities, construction, or farming (results includes soil moisture information).
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<DailyIndicesResult> GetDailyIndices(GetDailyIndicesOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyIndices");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetDailyIndices(JsonFormat.Json, coord, options.Language.ToString(), options.DurationInDays, options.IndexId, options.IndexGroupId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a list of the active tropical storms issued by national weather forecasting agencies.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<ActiveStormResult>> GetTropicalStormActiveAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetTropicalStormActive");
            scope.Start();
            try
            {
                return await restClient.GetTropicalStormActiveAsync(JsonFormat.Json, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a list of the active tropical storms issued by national weather forecasting agencies.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<ActiveStormResult> GetTropicalStormActive(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetTropicalStormActive");
            scope.Start();
            try
            {
                return restClient.GetTropicalStormActive(JsonFormat.Json, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a list of storms issued by national weather forecasting agencies.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<StormSearchResult>> GetTropicalStormSearchAsync(GetTropicalStormSearchOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetTropicalStormSearch");
            scope.Start();
            try
            {
                return await restClient.SearchTropicalStormAsync(JsonFormat.Json, options.Year, options.BasinId.ToString(), options.GovernmentStormId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a list of storms issued by national weather forecasting agencies.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<StormSearchResult> GetTropicalStormSearch(GetTropicalStormSearchOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetTropicalStormSearch");
            scope.Start();
            try
            {
                return restClient.SearchTropicalStorm(JsonFormat.Json, options.Year, options.BasinId.ToString(), options.GovernmentStormId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a list of tropical storms forecasted by national weather forecasting agencies.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<StormForecastResult>> GetTropicalStormForecastAsync(GetTropicalStormForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.BasinId, nameof(options.BasinId));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetTropicalStormForecast");
            scope.Start();
            try
            {
                return await restClient.GetTropicalStormForecastAsync(JsonFormat.Json, options.Year, options.BasinId.ToString(), options.GovernmentStormId, options.Unit, options.IncludeDetails, options.IncludeGeometricDetails, options.IncludeWindowGeometry, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get a list of tropical storms forecasted by national weather forecasting agencies.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<StormForecastResult> GetTropicalStormForecast(GetTropicalStormForecastOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.BasinId, nameof(options.BasinId));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetTropicalStormForecast");
            scope.Start();
            try
            {
                return restClient.GetTropicalStormForecast(JsonFormat.Json, options.Year, options.BasinId.ToString(), options.GovernmentStormId, options.Unit, options.IncludeDetails, options.IncludeGeometricDetails, options.IncludeWindowGeometry, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the location of tropical storms from individual national weather forecasting agencies.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<StormLocationsResult>> GetTropicalStormLocationsAsync(GetTropicalStormLocationsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.BasinId, nameof(options.BasinId));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetTropicalStormLocations");
            scope.Start();
            try
            {
                return await restClient.GetTropicalStormLocationsAsync(JsonFormat.Json, options.Year, options.BasinId.ToString(), options.GovernmentStormId, options.IncludeDetails, options.IncludeGeometricDetails, options.Unit, options.IncludeCurrentStorm, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get the location of tropical storms from individual national weather forecasting agencies.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<StormLocationsResult> GetTropicalStormLocations(GetTropicalStormLocationsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.BasinId, nameof(options.BasinId));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetTropicalStormLocations");
            scope.Start();
            try
            {
                return restClient.GetTropicalStormLocations(JsonFormat.Json, options.Year, options.BasinId.ToString(), options.GovernmentStormId, options.IncludeDetails, options.IncludeGeometricDetails, options.Unit, options.IncludeCurrentStorm, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get current air quality information that includes potential risks and suggested precautions.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<AirQualityResult>> GetCurrentAirQualityAsync(GetCurrentAirQualityOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetCurrentAirQuality");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetCurrentAirQualityAsync(JsonFormat.Json, coord, options.Language.ToString(), options.IncludePollutantDetails, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get current air quality information that includes potential risks and suggested precautions.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<AirQualityResult> GetCurrentAirQuality(GetCurrentAirQualityOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetCurrentAirQuality");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetCurrentAirQuality(JsonFormat.Json, coord, options.Language.ToString(), options.IncludePollutantDetails, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get daily air quality forecasts for the next one to seven days that include pollutant levels, potential risks and suggested precautions.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<DailyAirQualityForecastResult>> GetAirQualityDailyForecastsAsync(GetAirQualityDailyForecastsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetAirQualityDailyForecasts");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetAirQualityDailyForecastsAsync(JsonFormat.Json, coord, options.Language.ToString(), options.DurationInDays, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get daily air quality forecasts for the next one to seven days that include pollutant levels, potential risks and suggested precautions.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<DailyAirQualityForecastResult> GetAirQualityDailyForecasts(GetAirQualityDailyForecastsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetAirQualityDailyForecasts");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetAirQualityDailyForecasts(JsonFormat.Json, coord, options.Language.ToString(), options.DurationInDays, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get hourly air quality forecasts for the next one to 96 hours that include pollutant levels, potential risks and suggested precautions.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<AirQualityResult>> GetAirQualityHourlyForecastsAsync(GetAirQualityHourlyForecastsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetAirQualityHourlyForecasts");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetAirQualityHourlyForecastsAsync(JsonFormat.Json, coord, options.Language.ToString(), options.DurationInHours, options.IncludePollutantDetails, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get hourly air quality forecasts for the next one to 96 hours that include pollutant levels, potential risks and suggested precautions.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<AirQualityResult> GetAirQualityHourlyForecasts(GetAirQualityHourlyForecastsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetAirQualityHourlyForecasts");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetAirQualityHourlyForecasts(JsonFormat.Json, coord, options.Language.ToString(), options.DurationInHours, options.IncludePollutantDetails, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get climatology data such as past daily actual observed temperatures, precipitation, snowfall and snow depth.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<DailyHistoricalActualsResult>> GetDailyHistoricalActualsAsync(GetDailyHistoricalActualsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyHistoricalActuals");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetDailyHistoricalActualsAsync(JsonFormat.Json, coord, options.StartDate, options.EndDate, options.Unit, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get climatology data such as past daily actual observed temperatures, precipitation, snowfall and snow depth.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<DailyHistoricalActualsResult> GetDailyHistoricalActuals(GetDailyHistoricalActualsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyHistoricalActuals");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetDailyHistoricalActuals(JsonFormat.Json, coord, options.StartDate, options.EndDate, options.Unit, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get climatology data such as past daily record temperatures, precipitation and snowfall at a given location.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<DailyHistoricalRecordsResult>> GetDailyHistoricalRecordsAsync(GetDailyHistoricalRecordsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyHistoricalRecords");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetDailyHistoricalRecordsAsync(JsonFormat.Json, coord, options.StartDate, options.EndDate, options.Unit, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get climatology data such as past daily record temperatures, precipitation and snowfall at a given location.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<DailyHistoricalRecordsResult> GetDailyHistoricalRecords(GetDailyHistoricalRecordsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyHistoricalRecords");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetDailyHistoricalRecords(JsonFormat.Json, coord, options.StartDate, options.EndDate, options.Unit, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get climatology data such as past daily normal temperatures, precipitation and cooling/heating degree day information for a given location.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<DailyHistoricalNormalsResult>> GetDailyHistoricalNormalsAsync(GetDailyHistoricalNormalsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyHistoricalNormals");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return await restClient.GetDailyHistoricalNormalsAsync(JsonFormat.Json, coord, options.StartDate, options.EndDate, options.Unit, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Use to get climatology data such as past daily normal temperatures, precipitation and cooling/heating degree day information for a given location.
        /// </summary>
        /// <param name="options"> Additional options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<DailyHistoricalNormalsResult> GetDailyHistoricalNormals(GetDailyHistoricalNormalsOptions options, CancellationToken cancellationToken = default)
        {
            Common.Argument.AssertNotNull(options.Coordinates, nameof(options.Coordinates));

            using var scope = _clientDiagnostics.CreateScope("MapsWeatherClient.GetDailyHistoricalNormals");
            scope.Start();
            try
            {
                var coord = new[]
                {
                    Convert.ToDouble(options.Coordinates.Latitude, CultureInfo.InvariantCulture.NumberFormat),
                    Convert.ToDouble(options.Coordinates.Longitude, CultureInfo.InvariantCulture.NumberFormat)
                };
                return restClient.GetDailyHistoricalNormals(JsonFormat.Json, coord, options.StartDate, options.EndDate, options.Unit, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
