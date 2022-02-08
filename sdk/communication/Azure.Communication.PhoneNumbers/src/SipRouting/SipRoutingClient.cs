// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    /// <summary>
    /// The Azure Communication Services calling configuration client.
    /// </summary>
    public class SipRoutingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SipRoutingRestClient _restClient;

        #region public constructors - all arguments need null check

        /// <summary>
        /// Initializes a calling configuration client with an Azure resource connection string and client options.
        /// </summary>
        public SipRoutingClient(string connectionString)
            : this(
                ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                new SipRoutingClientOptions())
        { }

        /// <summary>
        /// Initializes a calling configuration client with an Azure resource connection string and client options.
        /// </summary>
        public SipRoutingClient(string connectionString, SipRoutingClientOptions options)
            : this(
                ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new SipRoutingClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="SipRoutingClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public SipRoutingClient(Uri endpoint, AzureKeyCredential keyCredential, SipRoutingClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(keyCredential, nameof(keyCredential)),
                options ?? new SipRoutingClientOptions())
        { }

        /// <summary>
        /// Initializes a calling configuration client with a token credential.
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        /// </summary>
        public SipRoutingClient(Uri endpoint, TokenCredential tokenCredential, SipRoutingClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new SipRoutingClientOptions())
        { }

        #endregion

        #region private constructors

        private SipRoutingClient(ConnectionString connectionString, SipRoutingClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private SipRoutingClient(string endpoint, AzureKeyCredential keyCredential, SipRoutingClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private SipRoutingClient(string endpoint, TokenCredential tokenCredential, SipRoutingClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private SipRoutingClient(string endpoint, HttpPipeline httpPipeline, SipRoutingClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            _restClient = new SipRoutingRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="SipRoutingClient"/> for mocking.</summary>
        protected SipRoutingClient()
        {
            _clientDiagnostics = null!;
            _restClient = null!;
        }

        /// <summary>
        /// Returns current calling configuration for resource <see cref="SipConfiguration"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns></returns>
        public virtual async Task<Response<SipConfiguration>> GetSipConfigurationAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetSipConfiguration)}");
            scope.Start();
            try
            {
                return await _restClient.GetSipConfigurationAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Returns current calling configuration for resource <see cref="SipConfiguration"/>.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns></returns>
        public virtual Response<SipConfiguration> GetSipConfiguration(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetSipConfiguration)}");
            scope.Start();
            try
            {
                return _restClient.GetSipConfiguration(cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with SIP trunk gateways list and routing settings.
        /// </summary>
        /// <param name="config">Updated configuration.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipConfiguration> UpdateSipConfiguration(
            SipConfiguration config,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(UpdateSipConfiguration)}");
            scope.Start();
            try
            {
                return _restClient.PatchSipConfiguration(config, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with SIP trunk gateways list and routing settings.
        /// </summary>
        /// <param name="config">Updated configuration.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipConfiguration>> UpdateSipConfigurationAsync(
            SipConfiguration config,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(UpdateSipConfiguration)}");
            scope.Start();
            try
            {
                return await _restClient.PatchSipConfigurationAsync(config, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with SIP trunk gateways list. Other configuration settings are not affected.
        /// </summary>
        /// <param name="trunk">SIP trunk gateway.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipTrunk> SetTrunk(
            SipTrunk trunk,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new Dictionary<string, SipTrunk> { { trunk.Fqdn, trunk } });

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetTrunk)}");
            scope.Start();
            try
            {
                var response = _restClient.PatchSipConfiguration(config, cancellationToken);
                return Response.FromValue(response.Value.Trunks.First(x => x.Key.Equals(trunk.Fqdn)).Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with SIP trunk gateways list. Other configuration settings are not affected.
        /// </summary>
        /// <param name="trunk">SIP trunk gateway.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipTrunk>> SetTrunkAsync(
            SipTrunk trunk,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new Dictionary<string, SipTrunk> { { trunk.Fqdn, trunk } });

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetTrunk)}");
            scope.Start();
            try
            {
                var response = await _restClient.PatchSipConfigurationAsync(config, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Trunks.First(x => x.Key.Equals(trunk.Fqdn)).Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with online routing settings. Other configuration settings are not affected.
        /// </summary>
        /// <param name="route">Online routing setting.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipTrunkRoute> SetRoute(
            SipTrunkRoute route,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetRoute)}");
            scope.Start();
            try
            {
                var currentConfig = GetSipConfiguration(cancellationToken);
                var currentRoutes = currentConfig.Value.Routes.ToList();

                var index = currentRoutes.FindIndex(x => x.Name.Equals(route.Name));

                if (index >= 0)
                {
                    currentRoutes[index] = route;
                }
                else
                {
                    currentRoutes.Add(route);
                }

                var config = new SipConfiguration(currentRoutes);

                var response = _restClient.PatchSipConfiguration(config, cancellationToken);
                return Response.FromValue(response.Value.Routes.First(x => x.Name.Equals(route.Name)), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with online routing settings. Other configuration settings are not affected.
        /// </summary>
        /// <param name="route">Online routing setting.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipTrunkRoute>> SetRouteAsync(
            SipTrunkRoute route,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetRoute)}");
            scope.Start();
            try
            {
                var currentConfig = await GetSipConfigurationAsync(cancellationToken).ConfigureAwait(false);
                var currentRoutes = currentConfig.Value.Routes.ToList();

                var index = currentRoutes.FindIndex(x => x.Name.Equals(route.Name));

                if (index >= 0)
                {
                    currentRoutes[index] = route;
                }
                else
                {
                    currentRoutes.Add(route);
                }

                var config = new SipConfiguration(currentRoutes);

                var response = await _restClient.PatchSipConfigurationAsync(config, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Routes.First(x => x.Name.Equals(route.Name)), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="trunkFqdn">Trunk FQDN to be deleted.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipTrunk> DeleteTrunk(
            string trunkFqdn,
            CancellationToken cancellationToken = default)
        {
            var removeConfig = new SipConfiguration(new Dictionary<string, SipTrunk> { { trunkFqdn, null } });

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(DeleteTrunk)}");
            scope.Start();
            try
            {
                var currentConfig = GetSipConfiguration(cancellationToken);
                var trunkToRemove = currentConfig.Value.Trunks.FirstOrDefault(x => x.Key.Equals(trunkFqdn)).Value;
                var response = _restClient.PatchSipConfiguration(removeConfig, cancellationToken);
                return Response.FromValue(trunkToRemove, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="trunkFqdn">trunk FQDN to be deleted.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<string>> DeleteTrunkAsync(
            string trunkFqdn,
            CancellationToken cancellationToken = default)
        {
            var removeConfig = new SipConfiguration(new Dictionary<string, SipTrunk> { { trunkFqdn, null } });

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(DeleteTrunk)}");
            scope.Start();
            try
            {
                var currentConfig = await GetSipConfigurationAsync(cancellationToken).ConfigureAwait(false);
                var trunkToRemove = currentConfig.Value.Trunks.FirstOrDefault(x => x.Key.Equals(trunkFqdn)).Value;
                var response = await _restClient.PatchSipConfigurationAsync(removeConfig, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(trunkFqdn, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="routeName">Name of the route to be deleted.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipTrunkRoute> DeleteRoute(
            string routeName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(DeleteRoute)}");
            scope.Start();
            try
            {
                var currentConfiguration = GetSipConfiguration(cancellationToken);
                var routeToRemove = currentConfiguration.Value.Routes.FirstOrDefault(x => x.Name.Equals(routeName));
                var modifiedConfig = new SipConfiguration(currentConfiguration.Value.Routes.Where(x => !x.Name.Equals(routeName)).ToList());
                var response = _restClient.PatchSipConfiguration(modifiedConfig, cancellationToken);
                return Response.FromValue(routeToRemove, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="routeName">Name of the route to be deleted.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipTrunkRoute>> DeleteRouteAsync(
            string routeName,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(DeleteRoute)}");
            scope.Start();
            try
            {
                var currentConfiguration = await GetSipConfigurationAsync(cancellationToken).ConfigureAwait(false);
                var routeToRemove = currentConfiguration.Value.Routes.FirstOrDefault(x => x.Name.Equals(routeName));
                var modifiedConfig = new SipConfiguration(currentConfiguration.Value.Routes.Where(x => !x.Name.Equals(routeName)).ToList());
                var response = await _restClient.PatchSipConfigurationAsync(modifiedConfig, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(routeToRemove, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipTrunk"/>.
        /// </summary>
        /// <returns>List of configured trunks.</returns>
        public virtual Response<IReadOnlyList<SipTrunk>> GetTrunks(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetTrunks)}");
            scope.Start();
            try
            {
                var response = _restClient.GetSipConfiguration(cancellationToken);
                return Response.FromValue((IReadOnlyList<SipTrunk>)response.Value.Trunks.Values.ToList().AsReadOnly(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipTrunk"/>.
        /// </summary>
        /// <returns>List of configured trunks.</returns>
        public virtual async Task<Response<IReadOnlyList<SipTrunk>>> GetTrunksAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetTrunks)}");
            scope.Start();
            try
            {
                var response = await _restClient.GetSipConfigurationAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue((IReadOnlyList<SipTrunk>)response.Value.Trunks.Values.ToList().AsReadOnly(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipTrunkRoute"/>.
        /// </summary>
        /// <returns>List of configured routes.</returns>
        public virtual Response<IReadOnlyList<SipTrunkRoute>> GetRoutes(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetRoutes)}");
            scope.Start();
            try
            {
                var response = _restClient.GetSipConfiguration(cancellationToken);
                return Response.FromValue(response.Value.Routes, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipTrunkRoute"/>.
        /// </summary>
        /// <returns>List of configured routes.</returns>
        public virtual async Task<Response<IReadOnlyList<SipTrunkRoute>>> GetRoutesAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetRoutes)}");
            scope.Start();
            try
            {
                var response = await _restClient.GetSipConfigurationAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Routes, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static T AssertNotNull<T>(T argument, string argumentName)
            where T : class
        {
            Argument.AssertNotNull(argument, argumentName);
            return argument;
        }

        private static string AssertNotNullOrEmpty(string argument, string argumentName)
        {
            Argument.AssertNotNullOrEmpty(argument, argumentName);
            return argument;
        }
    }
}
