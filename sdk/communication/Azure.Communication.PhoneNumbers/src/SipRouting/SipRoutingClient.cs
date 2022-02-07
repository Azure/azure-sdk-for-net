// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Communication.PhoneNumbers.SipRouting;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Collections.ObjectModel;

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
        public virtual Response<SipConfiguration> SetTrunk(
            SipTrunk trunk,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new Dictionary<string, SipTrunk> { { trunk.Name, trunk } });
            return UpdateSipConfiguration(config, cancellationToken);
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with online routing settings. Other configuration settings are not affected.
        /// </summary>
        /// <param name="route">Online routing setting.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipConfiguration> SetRoute(
            SipTrunkRoute route,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new List<SipTrunkRoute> { route});
            return UpdateSipConfiguration(config, cancellationToken);
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with SIP trunk gateways list. Other configuration settings are not affected.
        /// </summary>
        /// <param name="trunk">SIP trunk gateway.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipConfiguration>> SetTrunkAsync(
            SipTrunk trunk,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new Dictionary<string, SipTrunk> { { trunk.Name, trunk } });
            return await UpdateSipConfigurationAsync(config, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update <see cref="SipConfiguration"/> for resource with online routing settings. Other configuration settings are not affected.
        /// </summary>
        /// <param name="route">Online routing setting.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipConfiguration>> SetRouteAsync(
            SipTrunkRoute route,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new List<SipTrunkRoute>{ route });
            return await UpdateSipConfigurationAsync(config, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="fqdn">Trunk FQDN to be deleted.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipConfiguration> DeleteTrunk(
            string fqdn,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new Dictionary<string, SipTrunk> { { fqdn, null } });

            return UpdateSipConfiguration(config,cancellationToken);
        }

        /// <summary>
        /// Delete <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="fqdn">trunk FQDN to be deleted.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipConfiguration>> DeleteTrunkAsync(
            string fqdn,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new Dictionary<string, SipTrunk> { { fqdn, null } });

            return await UpdateSipConfigurationAsync(config, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get <see cref="SipTrunk"/>.
        /// </summary>
        /// <returns>List of configured trunks.</returns>
        public virtual Response<IEnumerable<SipTrunk>> GetTrunks(
            CancellationToken cancellationToken = default)
        {
            return GetSipConfiguration(cancellationToken);
        }

        /// <summary>
        /// Get <see cref="SipTrunk"/>.
        /// </summary>
        /// <returns>List of configured trunks.</returns>
        public virtual Response<IEnumerable<SipTrunk>> GetTrunksAsync(
            CancellationToken cancellationToken = default)
        {
            return GetSipConfigurationAsync(cancellationToken);
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
