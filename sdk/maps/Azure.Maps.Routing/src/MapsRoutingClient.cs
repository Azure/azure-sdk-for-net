// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Core.Pipeline;
using Azure.Maps.Common;
using Azure.Maps.Routing.Models;

namespace Azure.Maps.Routing
{
    /// <summary> The Route service client. </summary>
    public partial class MapsRoutingClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The RestClient is used to access Route REST client. </summary>
        internal RouteRestClient RestClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of MapsRoutingClient. </summary>
        protected MapsRoutingClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            RestClient = null;
        }

        /// <summary> Initializes a new instance of MapsRoutingClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Route Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MapsRoutingClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsRoutingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new RouteRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRoutingClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Route Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRoutingClient(AzureKeyCredential credential, MapsRoutingClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsRoutingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new RouteRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRoutingClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Route Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.
        /// It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API.
        /// To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="clientId"/> is null. </exception>
        public MapsRoutingClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsRoutingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new RouteRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRoutingClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Route Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.
        /// It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API.
        /// To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance.
        /// </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="clientId"/> is null. </exception>
        public MapsRoutingClient(TokenCredential credential, string clientId, MapsRoutingClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            options ??= new MapsRoutingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new RouteRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRoutingClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        public MapsRoutingClient(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsRoutingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            RestClient = new RouteRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRoutingClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRoutingClient(AzureSasCredential credential, MapsRoutingClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsRoutingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            RestClient = new RouteRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary>
        /// The Matrix Routing service allows calculation of a matrix of route summaries for a set of routes defined by origin and destination locations by using an asynchronous (async) or synchronous (sync) request.
        /// For every given origin, the service calculates the cost of routing from that origin to every given destination. The set of origins and the set of destinations can be thought of as the column and row headers of a table and each cell in the table contains the costs of routing from the origin to the destination for that cell. As an example, let's say a food delivery company has 20 drivers and they need to find the closest driver to pick up the delivery from the restaurant. To solve this use case, they can call Matrix Route API.
        /// For each route, the travel times and distances are returned. You can use the computed costs to determine which detailed routes to calculate using the Route Directions API.
        /// The maximum size of a matrix for sync request is <c>100</c> (the number of origins multiplied by the number of destinations).
        /// </summary>
        /// <param name="routeMatrixQuery"> The route matrix to query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="routeMatrixQuery"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<RouteMatrixResult>> GetImmediateRouteMatrixAsync(RouteMatrixQuery routeMatrixQuery, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetImmediateRouteMatrix");
            scope.Start();
            try
            {
                var options = new RouteMatrixOptions(routeMatrixQuery);
                return await RestClient.RequestRouteMatrixSyncAsync(
                    JsonFormat.Json,
                    options.Query,
                    true, // WaitForResult only supports for async request. Set to `true` for sync request.
                    options?.TravelTimeType,
                    options?.SectionFilter,
                    options?.ArriveAt,
                    options?.DepartAt,
                    options?.VehicleAxleWeightInKilograms,
                    options?.VehicleLengthInMeters,
                    options?.VehicleHeightInMeters,
                    options?.VehicleWidthInMeters,
                    options?.VehicleMaxSpeedInKilometersPerHour,
                    options?.VehicleWeightInKilograms,
                    options?.Windingness,
                    options?.InclineLevel,
                    options?.TravelMode,
                    options?.Avoid,
                    options?.UseTrafficData,
                    options?.RouteType,
                    options?.VehicleLoadType,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Matrix Routing service allows calculation of a matrix of route summaries for a set of routes defined by origin and destination locations by using an asynchronous (async) or synchronous (sync) request.
        /// For every given origin, the service calculates the cost of routing from that origin to every given destination. The set of origins and the set of destinations can be thought of as the column and row headers of
        /// a table and each cell in the table contains the costs of routing from the origin to the destination for that cell. As an example, let's say a food delivery company has 20 drivers and they need to find the closest driver to pick up the delivery from the restaurant. To solve this use case, they can call Matrix Route API.
        /// For each route, the travel times and distances are returned. You can use the computed costs to determine which detailed routes to calculate using the Route Directions API.
        /// The maximum size of a matrix for sync request is <c>100</c> (the number of origins multiplied by the number of destinations).
        /// </summary>
        /// <param name="options"> The route direction options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<RouteMatrixResult>> GetImmediateRouteMatrixAsync(RouteMatrixOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetImmediateRouteMatrix");
            scope.Start();
            try
            {
                return await RestClient.RequestRouteMatrixSyncAsync(
                    JsonFormat.Json,
                    options.Query,
                    true, // WaitForResult only supports for async request. Set to `true` for sync request.
                    options?.TravelTimeType,
                    options?.SectionFilter,
                    options?.ArriveAt,
                    options?.DepartAt,
                    options?.VehicleAxleWeightInKilograms,
                    options?.VehicleLengthInMeters,
                    options?.VehicleHeightInMeters,
                    options?.VehicleWidthInMeters,
                    options?.VehicleMaxSpeedInKilometersPerHour,
                    options?.VehicleWeightInKilograms,
                    options?.Windingness,
                    options?.InclineLevel,
                    options?.TravelMode,
                    options?.Avoid,
                    options?.UseTrafficData,
                    options?.RouteType,
                    options?.VehicleLoadType,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Matrix Routing service allows calculation of a matrix of route summaries for a set of routes defined by origin and destination locations by using an asynchronous (async) or synchronous (sync) request. For every given origin, the service calculates the cost of routing from that origin to every given destination. The set of origins and the set of destinations can be thought of as the column and row headers of a table and each cell in the table contains the costs of routing from the origin to the destination for that cell. As an example, let's say a food delivery company has 20 drivers and they need to find the closest driver to pick up the delivery from the restaurant. To solve this use case, they can call Matrix Route API.
        /// For each route, the travel times and distances are returned. You can use the computed costs to determine which detailed routes to calculate using the Route Directions API.
        /// The maximum size of a matrix for sync request is <c>100</c> (the number of origins multiplied by the number of destinations).
        /// </summary>
        /// <param name="routeMatrixQuery"> The route matrix to query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="routeMatrixQuery"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<RouteMatrixResult> GetImmediateRouteMatrix(RouteMatrixQuery routeMatrixQuery, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetImmediateRouteMatrix");
            scope.Start();
            try
            {
                var options = new RouteMatrixOptions(routeMatrixQuery);
                return RestClient.RequestRouteMatrixSync(
                    JsonFormat.Json,
                    options.Query,
                    true, // WaitForResult only supports for async request. Set to `true` for sync request.
                    options?.TravelTimeType,
                    options?.SectionFilter,
                    options?.ArriveAt,
                    options?.DepartAt,
                    options?.VehicleAxleWeightInKilograms,
                    options?.VehicleLengthInMeters,
                    options?.VehicleHeightInMeters,
                    options?.VehicleWidthInMeters,
                    options?.VehicleMaxSpeedInKilometersPerHour,
                    options?.VehicleWeightInKilograms,
                    options?.Windingness,
                    options?.InclineLevel,
                    options?.TravelMode,
                    options?.Avoid,
                    options?.UseTrafficData,
                    options?.RouteType,
                    options?.VehicleLoadType,
                    cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Matrix Routing service allows calculation of a matrix of route summaries for a set of routes defined by origin and destination locations by using an asynchronous (async) or synchronous (sync) request. For every given origin, the service calculates the cost of routing from that origin to every given destination. The set of origins and the set of destinations can be thought of as the column and row headers of a table and each cell in the table contains the costs of routing from the origin to the destination for that cell. As an example, let's say a food delivery company has 20 drivers and they need to find the closest driver to pick up the delivery from the restaurant. To solve this use case, they can call Matrix Route API.
        /// For each route, the travel times and distances are returned. You can use the computed costs to determine which detailed routes to calculate using the Route Directions API.
        /// The maximum size of a matrix for sync request is <c>100</c> (the number of origins multiplied by the number of destinations).
        /// </summary>
        /// <param name="options"> The route direction options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<RouteMatrixResult> GetImmediateRouteMatrix(RouteMatrixOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetImmediateRouteMatrix");
            scope.Start();
            try
            {
                return RestClient.RequestRouteMatrixSync(
                    JsonFormat.Json,
                    options.Query,
                    true, // WaitForResult only supports for async request. Set to `true` for sync request.
                    options?.TravelTimeType,
                    options?.SectionFilter,
                    options?.ArriveAt,
                    options?.DepartAt,
                    options?.VehicleAxleWeightInKilograms,
                    options?.VehicleLengthInMeters,
                    options?.VehicleHeightInMeters,
                    options?.VehicleWidthInMeters,
                    options?.VehicleMaxSpeedInKilometersPerHour,
                    options?.VehicleWeightInKilograms,
                    options?.Windingness,
                    options?.InclineLevel,
                    options?.TravelMode,
                    options?.Avoid,
                    options?.UseTrafficData,
                    options?.RouteType,
                    options?.VehicleLoadType,
                    cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a route between an origin and a destination, passing through waypoints if they are specified. The route will take into account factors such as current traffic and the typical road speeds on the requested day of the week and time of day.
        /// Information returned includes the distance, estimated travel time, and a representation of the route geometry. Additional routing information such as optimized waypoint order or turn by turn instructions is also available, depending on the options selected.
        /// Routing service provides a set of parameters for a detailed description of vehicle-specific Consumption Model. Please check <see href="https://docs.microsoft.com/azure/azure-maps/consumption-model">Consumption Model</see> for detailed explanation of the concepts and parameters involved.
        /// </summary>
        /// <param name="query"> The route direction query, including a list of route points and route direction options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<RouteDirections>> GetDirectionsAsync(RouteDirectionQuery query, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(query, nameof(query));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetDirections");
            scope.Start();
            try
            {
                var stringRoutePoints = MapsRoutingClient.GeoPointsToString(query.RoutePoints);
                var options = query.RouteDirectionOptions;
                Report? report = null;
                if (options?.ShouldReportEffectiveSettings == true)
                {
                    report = Report.EffectiveSettings;
                }

                if (options?.RouteDirectionParameters == null)
                {
                    return await RestClient.GetRouteDirectionsAsync(
                        ResponseFormat.Json,
                        stringRoutePoints,
                        options?.MaxAlternatives,
                        options?.AlternativeType,
                        options?.MinDeviationDistance,
                        options?.ArriveAt,
                        options?.DepartAt,
                        options?.MinDeviationTime,
                        options?.InstructionsType,
                        options?.Language.ToString(),
                        options?.ComputeBestWaypointOrder,
                        options?.RouteRepresentationForBestOrder,
                        options?.TravelTimeType,
                        options?.VehicleHeading,
                        report,
                        options?.SectionFilter,
                        options?.VehicleAxleWeightInKilograms,
                        options?.VehicleWidthInMeters,
                        options?.VehicleHeightInMeters,
                        options?.VehicleLengthInMeters,
                        options?.VehicleMaxSpeedInKilometersPerHour,
                        options?.VehicleWeightInKilograms,
                        options?.IsCommercialVehicle,
                        options?.Windingness,
                        options?.InclineLevel,
                        options?.TravelMode,
                        options?.Avoid,
                        options?.UseTrafficData,
                        options?.RouteType,
                        options?.VehicleLoadType,
                        options?.VehicleEngineType,
                        options?.ConstantSpeedConsumptionInLitersPerHundredKilometer,
                        options?.CurrentFuelInLiters,
                        options?.AuxiliaryPowerInLitersPerHour,
                        options?.FuelEnergyDensityInMegajoulesPerLiter,
                        options?.AccelerationEfficiency,
                        options?.DecelerationEfficiency,
                        options?.UphillEfficiency,
                        options?.DownhillEfficiency,
                        options?.ConstantSpeedConsumptionInKilowattHoursPerHundredKilometer,
                        options?.CurrentChargeInKilowattHours,
                        options?.MaxChargeInKilowattHours,
                        options?.AuxiliaryPowerInKilowatts,
                        cancellationToken
                    ).ConfigureAwait(false);
                }
                else
                {
                    return await RestClient.GetRouteDirectionsWithAdditionalParametersAsync(
                        ResponseFormat.Json,
                        stringRoutePoints,
                        options.RouteDirectionParameters,
                        options?.MaxAlternatives,
                        options?.AlternativeType,
                        options?.MinDeviationDistance,
                        options?.MinDeviationTime,
                        options?.InstructionsType,
                        options?.Language.ToString(),
                        options?.ComputeBestWaypointOrder,
                        options?.RouteRepresentationForBestOrder,
                        options?.TravelTimeType,
                        options?.VehicleHeading,
                        report,
                        options?.SectionFilter,
                        options?.ArriveAt,
                        options?.DepartAt,
                        options?.VehicleAxleWeightInKilograms,
                        options?.VehicleLengthInMeters,
                        options?.VehicleHeightInMeters,
                        options?.VehicleWidthInMeters,
                        options?.VehicleMaxSpeedInKilometersPerHour,
                        options?.VehicleWeightInKilograms,
                        options?.IsCommercialVehicle,
                        options?.Windingness,
                        options?.InclineLevel,
                        options?.TravelMode,
                        options?.Avoid,
                        options?.UseTrafficData,
                        options?.RouteType,
                        options?.VehicleLoadType,
                        options?.VehicleEngineType,
                        options?.ConstantSpeedConsumptionInLitersPerHundredKilometer,
                        options?.CurrentFuelInLiters,
                        options?.AuxiliaryPowerInLitersPerHour,
                        options?.FuelEnergyDensityInMegajoulesPerLiter,
                        options?.AccelerationEfficiency,
                        options?.DecelerationEfficiency,
                        options?.UphillEfficiency,
                        options?.DownhillEfficiency,
                        options?.ConstantSpeedConsumptionInKilowattHoursPerHundredKilometer,
                        options?.CurrentChargeInKilowattHours,
                        options?.MaxChargeInKilowattHours,
                        options?.AuxiliaryPowerInKilowatts,
                        cancellationToken
                    ).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a route between an origin and a destination, passing through waypoints if they are specified. The route will take into account factors such as current traffic and the typical road speeds on the requested day of the week and time of day.
        /// Information returned includes the distance, estimated travel time, and a representation of the route geometry. Additional routing information such as optimized waypoint order or turn by turn instructions is also available, depending on the options selected.
        /// Routing service provides a set of parameters for a detailed description of vehicle-specific Consumption Model. Please check <see href="https://docs.microsoft.com/azure/azure-maps/consumption-model">Consumption Model</see> for detailed explanation of the concepts and parameters involved.
        /// </summary>
        /// <param name="query"> The route direction query, including a list of route points and route direction options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<RouteDirections> GetDirections(RouteDirectionQuery query, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(query, nameof(query));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetDirections");
            scope.Start();
            try
            {
                var stringRoutePoints = MapsRoutingClient.GeoPointsToString(query.RoutePoints);
                var options = query.RouteDirectionOptions;
                Report? report = null;
                if (options?.ShouldReportEffectiveSettings == true)
                {
                    report = Report.EffectiveSettings;
                }

                if (options?.RouteDirectionParameters == null)
                {
                    return RestClient.GetRouteDirections(
                        ResponseFormat.Json,
                        stringRoutePoints,
                        options?.MaxAlternatives,
                        options?.AlternativeType,
                        options?.MinDeviationDistance,
                        options?.ArriveAt,
                        options?.DepartAt,
                        options?.MinDeviationTime,
                        options?.InstructionsType,
                        options?.Language.ToString(),
                        options?.ComputeBestWaypointOrder,
                        options?.RouteRepresentationForBestOrder,
                        options?.TravelTimeType,
                        options?.VehicleHeading,
                        report,
                        options?.SectionFilter,
                        options?.VehicleAxleWeightInKilograms,
                        options?.VehicleWidthInMeters,
                        options?.VehicleHeightInMeters,
                        options?.VehicleLengthInMeters,
                        options?.VehicleMaxSpeedInKilometersPerHour,
                        options?.VehicleWeightInKilograms,
                        options?.IsCommercialVehicle,
                        options?.Windingness,
                        options?.InclineLevel,
                        options?.TravelMode,
                        options?.Avoid,
                        options?.UseTrafficData,
                        options?.RouteType,
                        options?.VehicleLoadType,
                        options?.VehicleEngineType,
                        options?.ConstantSpeedConsumptionInLitersPerHundredKilometer,
                        options?.CurrentFuelInLiters,
                        options?.AuxiliaryPowerInLitersPerHour,
                        options?.FuelEnergyDensityInMegajoulesPerLiter,
                        options?.AccelerationEfficiency,
                        options?.DecelerationEfficiency,
                        options?.UphillEfficiency,
                        options?.DownhillEfficiency,
                        options?.ConstantSpeedConsumptionInKilowattHoursPerHundredKilometer,
                        options?.CurrentChargeInKilowattHours,
                        options?.MaxChargeInKilowattHours,
                        options?.AuxiliaryPowerInKilowatts,
                        cancellationToken
                    );
                }
                else
                {
                    return RestClient.GetRouteDirectionsWithAdditionalParameters(
                        ResponseFormat.Json,
                        stringRoutePoints,
                        options.RouteDirectionParameters,
                        options?.MaxAlternatives,
                        options?.AlternativeType,
                        options?.MinDeviationDistance,
                        options?.MinDeviationTime,
                        options?.InstructionsType,
                        options?.Language.ToString(),
                        options?.ComputeBestWaypointOrder,
                        options?.RouteRepresentationForBestOrder,
                        options?.TravelTimeType,
                        options?.VehicleHeading,
                        report,
                        options?.SectionFilter,
                        options?.ArriveAt,
                        options?.DepartAt,
                        options?.VehicleAxleWeightInKilograms,
                        options?.VehicleLengthInMeters,
                        options?.VehicleHeightInMeters,
                        options?.VehicleWidthInMeters,
                        options?.VehicleMaxSpeedInKilometersPerHour,
                        options?.VehicleWeightInKilograms,
                        options?.IsCommercialVehicle,
                        options?.Windingness,
                        options?.InclineLevel,
                        options?.TravelMode,
                        options?.Avoid,
                        options?.UseTrafficData,
                        options?.RouteType,
                        options?.VehicleLoadType,
                        options?.VehicleEngineType,
                        options?.ConstantSpeedConsumptionInLitersPerHundredKilometer,
                        options?.CurrentFuelInLiters,
                        options?.AuxiliaryPowerInLitersPerHour,
                        options?.FuelEnergyDensityInMegajoulesPerLiter,
                        options?.AccelerationEfficiency,
                        options?.DecelerationEfficiency,
                        options?.UphillEfficiency,
                        options?.DownhillEfficiency,
                        options?.ConstantSpeedConsumptionInKilowattHoursPerHundredKilometer,
                        options?.CurrentChargeInKilowattHours,
                        options?.MaxChargeInKilowattHours,
                        options?.AuxiliaryPowerInKilowatts,
                        cancellationToken
                    );
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This service will calculate a set of locations that can be reached from the origin point based on fuel, energy,  time or distance budget that is specified. A polygon boundary (or Isochrone) is returned in a counterclockwise  orientation as well as the precise polygon center which was the result of the origin point.
        /// The returned polygon can be used for further processing such as  <see href="https://docs.microsoft.com/rest/api/maps/search/postsearchinsidegeometry">Search Inside Geometry</see> to  search for POIs within the provided Isochrone.
        /// </summary>
        /// <param name="options"> Route range options to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<RouteRangeResult>> GetRouteRangeAsync(RouteRangeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetRouteRange");
            scope.Start();
            try
            {
                return await RestClient.GetRouteRangeAsync(
                    ResponseFormat.Json,
                    options.Query,
                    options.FuelBudgetInLiters,
                    options.EnergyBudgetInKilowattHours,
                    options.TimeBudget?.TotalSeconds,
                    options.DistanceBudgetInMeters,
                    options.DepartAt,
                    options.RouteType,
                    options.UseTrafficData,
                    options.Avoid,
                    options.TravelMode,
                    options.InclineLevel,
                    options.Windingness,
                    options.VehicleAxleWeightInKilograms,
                    options.VehicleWidthInMeters,
                    options.VehicleHeightInMeters,
                    options.VehicleLengthInMeters,
                    options.VehicleMaxSpeedInKilometersPerHour,
                    options.VehicleWeightInKilograms,
                    options.IsCommercialVehicle,
                    options.VehicleLoadType,
                    options.VehicleEngineType,
                    options.ConstantSpeedConsumptionInLitersPerHundredKilometer,
                    options.CurrentFuelInLiters,
                    options.AuxiliaryPowerInLitersPerHour,
                    options.FuelEnergyDensityInMegajoulesPerLiter,
                    options.AccelerationEfficiency,
                    options.DecelerationEfficiency,
                    options.UphillEfficiency,
                    options.DownhillEfficiency,
                    options.ConstantSpeedConsumptionInKilowattHoursPerHundredKilometer,
                    options.CurrentChargeInKilowattHours,
                    options.MaxChargeInKilowattHours,
                    options.AuxiliaryPowerInKilowatts,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This service will calculate a set of locations that can be reached from the origin point based on fuel, energy,  time or distance budget that is specified. A polygon boundary (or Isochrone) is returned in a counterclockwise  orientation as well as the precise polygon center which was the result of the origin point.
        /// The returned polygon can be used for further processing such as <see href="https://docs.microsoft.com/rest/api/maps/search/postsearchinsidegeometry">Search Inside Geometry</see> to  search for POIs within the provided Isochrone.
        /// </summary>
        /// <param name="options"> Route range options to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<RouteRangeResult> GetRouteRange(RouteRangeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetRouteRange");
            scope.Start();
            try
            {
                return RestClient.GetRouteRange(
                    ResponseFormat.Json,
                    options.Query,
                    options.FuelBudgetInLiters,
                    options.EnergyBudgetInKilowattHours,
                    options.TimeBudget?.TotalSeconds,
                    options.DistanceBudgetInMeters,
                    options.DepartAt,
                    options.RouteType,
                    options.UseTrafficData,
                    options.Avoid,
                    options.TravelMode,
                    options.InclineLevel,
                    options.Windingness,
                    options.VehicleAxleWeightInKilograms,
                    options.VehicleWidthInMeters,
                    options.VehicleHeightInMeters,
                    options.VehicleLengthInMeters,
                    options.VehicleMaxSpeedInKilometersPerHour,
                    options.VehicleWeightInKilograms,
                    options.IsCommercialVehicle,
                    options.VehicleLoadType,
                    options.VehicleEngineType,
                    options.ConstantSpeedConsumptionInLitersPerHundredKilometer,
                    options.CurrentFuelInLiters,
                    options.AuxiliaryPowerInLitersPerHour,
                    options.FuelEnergyDensityInMegajoulesPerLiter,
                    options.AccelerationEfficiency,
                    options.DecelerationEfficiency,
                    options.UphillEfficiency,
                    options.DownhillEfficiency,
                    options.ConstantSpeedConsumptionInKilowattHoursPerHundredKilometer,
                    options.CurrentChargeInKilowattHours,
                    options.MaxChargeInKilowattHours,
                    options.AuxiliaryPowerInKilowatts,
                    cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Route Directions Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/route/getroutedirections">Route Directions API</see> using just a single API call.
        /// You can call Route Directions Batch API to run either asynchronously (async) or synchronously (sync). The sync API up to <c>100</c> queries.
        /// </summary>
        /// <param name="queries"> The list of route directions queries/requests to process. The list can contain 100 queries for sync version and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual async Task<Response<RouteDirectionsBatchResult>> GetDirectionsImmediateBatchAsync(IEnumerable<RouteDirectionQuery> queries, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(queries, nameof(queries));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetDirectionsImmediateBatch");
            scope.Start();
            try
            {
                var batchItems = MapsRoutingClient.RouteDirectionsQueriesToBatchItems(queries);
                return await RestClient.RequestRouteDirectionsBatchSyncAsync(JsonFormat.Json, batchItems, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Route Directions Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/route/getroutedirections">Route Directions API</see> using just a single API call.
        /// You can call Route Directions Batch API to run either asynchronously (async) or synchronously (sync). The sync API up to <c>100</c> queries.
        /// </summary>
        /// <param name="queries"> The list of route directions queries/requests to process. The list can contain 100 queries for sync version and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual Response<RouteDirectionsBatchResult> GetDirectionsImmediateBatch(IEnumerable<RouteDirectionQuery> queries, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(queries, nameof(queries));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetDirectionsImmediateBatch");
            scope.Start();
            try
            {
                var batchItems = MapsRoutingClient.RouteDirectionsQueriesToBatchItems(queries);
                return RestClient.RequestRouteDirectionsBatchSync(JsonFormat.Json, batchItems, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Matrix Routing service allows calculation of a matrix of route summaries for a set of routes defined by origin and destination locations by using an asynchronous (async) or synchronous (sync) request.
        /// For every given origin, the service calculates the cost of routing from that origin to every given destination. The set of origins and the set of destinations can be thought of as the column and row headers of a table and each cell in the table contains the costs of routing from the origin to the destination for that cell.
        /// For each route, the travel times and distances are returned. You can use the computed costs to determine which detailed routes to calculate using the Route Directions API.
        /// The maximum size of a matrix for async request is <c>700</c> (the number of origins multiplied by the number of destinations).
        /// </summary>
        /// <param name="waitUntil"> If the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="options"> The route direction options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<GetRouteMatrixOperation> GetRouteMatrixAsync(WaitUntil waitUntil, RouteMatrixOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetRouteMatrix");
            scope.Start();
            try
            {
                var response = await RestClient.RequestRouteMatrixAsync(
                    JsonFormat.Json,
                    options.Query,
                    false,
                    options?.TravelTimeType,
                    options?.SectionFilter,
                    options?.ArriveAt,
                    options?.DepartAt,
                    options?.VehicleAxleWeightInKilograms,
                    options?.VehicleLengthInMeters,
                    options?.VehicleHeightInMeters,
                    options?.VehicleWidthInMeters,
                    options?.VehicleMaxSpeedInKilometersPerHour,
                    options?.VehicleWeightInKilograms,
                    options?.Windingness,
                    options?.InclineLevel,
                    options?.TravelMode,
                    options?.Avoid,
                    options?.UseTrafficData,
                    options?.RouteType,
                    options?.VehicleLoadType,
                    cancellationToken
                ).ConfigureAwait(false);

                // Create operation for route direction
                var operation = new GetRouteMatrixOperation(this, new Uri(response.Headers.Location));
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
        /// The Matrix Routing service allows calculation of a matrix of route summaries for a set of routes defined by origin and destination locations by using an asynchronous (async) or synchronous (sync) request.
        /// For every given origin, the service calculates the cost of routing from that origin to every given destination. The set of origins and the set of destinations can be thought of as the column and row headers of a table and each cell in the table contains the costs of routing from the origin to the destination for that cell.
        /// For each route, the travel times and distances are returned. You can use the computed costs to determine which detailed routes to calculate using the Route Directions API.
        /// The maximum size of a matrix for async request is <c>700</c> (the number of origins multiplied by the number of destinations).
        /// </summary>
        /// <param name="waitUntil"> If the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="options"> The route direction options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual GetRouteMatrixOperation GetRouteMatrix(WaitUntil waitUntil, RouteMatrixOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetRouteMatrix");
            scope.Start();
            try
            {
                var response = RestClient.RequestRouteMatrix(
                    JsonFormat.Json,
                    options.Query,
                    false,
                    options?.TravelTimeType,
                    options?.SectionFilter,
                    options?.ArriveAt,
                    options?.DepartAt,
                    options?.VehicleAxleWeightInKilograms,
                    options?.VehicleLengthInMeters,
                    options?.VehicleHeightInMeters,
                    options?.VehicleWidthInMeters,
                    options?.VehicleMaxSpeedInKilometersPerHour,
                    options?.VehicleWeightInKilograms,
                    options?.Windingness,
                    options?.InclineLevel,
                    options?.TravelMode,
                    options?.Avoid,
                    options?.UseTrafficData,
                    options?.RouteType,
                    options?.VehicleLoadType,
                    cancellationToken
                );

                // Create operation for route direction
                var operation = new GetRouteMatrixOperation(this, new Uri(response.Headers.Location));
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
        /// The Route Directions Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/route/getroutedirections">Route Directions API</see> using just a single API call.
        /// TThis Route Directions Batch API will run asynchronously (async) and it allows caller to batch up to <c>700</c> queries.
        /// </summary>
        /// <param name="waitUntil"> If the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="queries"> The list of route directions queries/requests to process. The list can contain a max of 700 queries for async and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual async Task<GetDirectionsOperation> GetDirectionsBatchAsync(WaitUntil waitUntil, IEnumerable<RouteDirectionQuery> queries, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(queries, nameof(queries));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetDirectionsBatch");
            scope.Start();
            try
            {
                var batchItems = MapsRoutingClient.RouteDirectionsQueriesToBatchItems(queries);
                var response = await RestClient.RequestRouteDirectionsBatchAsync(
                    JsonFormat.Json, batchItems, cancellationToken).ConfigureAwait(false);

                // Create operation for route direction
                var operation = new GetDirectionsOperation(this, new Uri(response.Headers.Location));
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
        /// The Route Directions Batch API sends batches of queries to <see href="https://docs.microsoft.com/rest/api/maps/route/getroutedirections">Route Directions API</see> using just a single API call.
        /// TThis Route Directions Batch API will run asynchronously (async) and it allows caller to batch up to <c>700</c> queries.
        /// </summary>
        /// <param name="waitUntil"> Whether to return once method is invoked or wait for the server operation to fully complete before returning. Possible value: <c>WaitUntil.Completed</c> and <c>WaitUntil.Started</c> </param>
        /// <param name="queries"> The list of route directions queries/requests to process. The list can contain a max of 700 queries for async and must contain at least 1 query. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queries"/> is null. </exception>
        public virtual GetDirectionsOperation GetDirectionsBatch(WaitUntil waitUntil, IEnumerable<RouteDirectionQuery> queries, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(queries, nameof(queries));

            using var scope = _clientDiagnostics.CreateScope("MapsRoutingClient.GetDirectionsBatch");
            scope.Start();
            try
            {
                var batchItems = MapsRoutingClient.RouteDirectionsQueriesToBatchItems(queries);
                var response = RestClient.RequestRouteDirectionsBatch(
                    JsonFormat.Json, batchItems, cancellationToken);

                // Create operation for route direction
                var operation = new GetDirectionsOperation(this, new Uri(response.Headers.Location));
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
        /// Convert a list of queries in string format to BatchItems for route directions queries
        /// </summary>
        private static BatchRequest RouteDirectionsQueriesToBatchItems(IEnumerable<RouteDirectionQuery> queries)
        {
            BatchRequest batchItems = new BatchRequest();
            foreach (var query in queries)
            {
                var stringRoutePoints = MapsRoutingClient.GeoPointsToString(query.RoutePoints);
                var options = query.RouteDirectionOptions;
                var uri = new RawRequestUriBuilder();
                uri.AppendQuery("query", stringRoutePoints, false);
                if (options?.TravelTimeType != null)
                {
                    uri.AppendQuery("TravelTimeTypeFor", options.TravelTimeType.Value.ToString(), true);
                }
                if (options?.SectionFilter != null)
                {
                    foreach (var param in options.SectionFilter)
                    {
                        uri.AppendQuery("sectionType", param.ToString(), true);
                    }
                }
                if (options?.ArriveAt != null)
                {
                    uri.AppendQuery("arriveAt", options.ArriveAt.Value, "O", true);
                }
                if (options?.DepartAt != null)
                {
                    uri.AppendQuery("departAt", options.DepartAt.Value, "O", true);
                }
                if (options?.VehicleAxleWeightInKilograms != null)
                {
                    uri.AppendQuery("vehicleAxleWeight", options.VehicleAxleWeightInKilograms.Value, true);
                }
                if (options?.VehicleLengthInMeters != null)
                {
                    uri.AppendQuery("vehicleLength", options.VehicleLengthInMeters.Value, true);
                }
                if (options?.VehicleHeightInMeters != null)
                {
                    uri.AppendQuery("vehicleHeight", options.VehicleHeightInMeters.Value, true);
                }
                if (options?.VehicleWidthInMeters != null)
                {
                    uri.AppendQuery("vehicleWidth", options.VehicleWidthInMeters.Value, true);
                }
                if (options?.VehicleMaxSpeedInKilometersPerHour != null)
                {
                    uri.AppendQuery("vehicleMaxSpeed", options.VehicleMaxSpeedInKilometersPerHour.Value, true);
                }
                if (options?.VehicleWeightInKilograms != null)
                {
                    uri.AppendQuery("vehicleWeight", options.VehicleWeightInKilograms.Value, true);
                }
                if (options?.Windingness != null)
                {
                    uri.AppendQuery("windingness", options.Windingness.Value.ToString(), true);
                }
                if (options?.InclineLevel != null)
                {
                    uri.AppendQuery("hilliness", options.InclineLevel.Value.ToString(), true);
                }
                if (options?.TravelMode != null)
                {
                    uri.AppendQuery("travelMode", options.TravelMode.Value.ToString(), true);
                }
                if (options?.Avoid != null)
                {
                    foreach (var param in options.Avoid)
                    {
                        uri.AppendQuery("avoid", param.ToString(), true);
                    }
                }
                if (options?.UseTrafficData != null)
                {
                    uri.AppendQuery("traffic", options.UseTrafficData.Value, true);
                }
                if (options?.RouteType != null)
                {
                    uri.AppendQuery("routeType", options.RouteType.Value.ToString(), true);
                }
                if (options?.VehicleLoadType != null)
                {
                    uri.AppendQuery("vehicleLoadType", options.VehicleLoadType.Value.ToString(), true);
                }
                batchItems.BatchItems.Add(new BatchRequestItem(uri.Query));
            }
            return batchItems;
        }

        /// <summary>
        /// Convert GeoPosition to a route point string in `{Latitude1},{Longitude1}:{Latitude2},{Longitude2}:...` format
        /// </summary>
        private static string GeoPointsToString(IList<GeoPosition> routePoints)
        {
            var sb = new StringBuilder(string.Empty, routePoints.Count * 16);
            foreach (var point in routePoints)
            {
                if (sb.Length > 0)
                {
                    sb.Append(':');
                }
                sb.AppendFormat(CultureInfo.InvariantCulture, "{0},{1}", point.Latitude, point.Longitude);
            }
            return sb.ToString();
        }
    }
}
