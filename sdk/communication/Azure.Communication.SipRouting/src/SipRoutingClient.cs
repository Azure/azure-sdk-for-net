﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Communication.SipRouting.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.SipRouting
{
    /// <summary>
    /// The Azure Communication Services calling configuration client.
    /// </summary>
    public class SipRoutingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly AzureCommunicationSIPRoutingServiceRestClient _restClient;

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
        public SipRoutingClient(Uri endpoint, AzureKeyCredential keyCredential, SipRoutingClientOptions? options = default)
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
        public SipRoutingClient(Uri endpoint, TokenCredential tokenCredential, SipRoutingClientOptions? options = default)
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
            _restClient = new AzureCommunicationSIPRoutingServiceRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
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
        /// Update <see cref="SipConfigurationPatch"/> for resource with SIP trunk gateways list and routing settings.
        /// </summary>
        /// <param name="trunks">List of SIP trunk gateways.</param>
        /// <param name="routes"></param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipConfiguration> UpdateSipTrunkConfiguration(
            IDictionary<string,TrunkPatch> trunks,
            IList<TrunkRoute> routes,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfigurationPatch(trunks, routes);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(UpdateSipTrunkConfiguration)}");
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
        /// Update <see cref="SipConfigurationPatch"/> for resource with SIP trunk gateways list and routing settings.
        /// </summary>
        /// <param name="trunks">List of SIP trunk gateways.</param>
        /// <param name="routes"></param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipConfiguration>> UpdateSipTrunkConfigurationAsync(
            IDictionary<string,TrunkPatch> trunks,
            IList<TrunkRoute> routes,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfigurationPatch(trunks, routes);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(UpdateSipTrunkConfiguration)}");
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
        /// <param name="trunks">List of SIP trunk gateways.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipConfiguration> UpdateTrunks(
            IDictionary<string,TrunkPatch> trunks,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfigurationPatch(trunks);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(UpdateTrunks)}");
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
        /// Update <see cref="SipConfiguration"/> for resource with SIP trunk gateways list. Other configuration settings are not affected.
        /// </summary>
        /// <param name="trunks">List of SIP trunk gateways.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipConfiguration>> UpdateTrunksAsync(
            IDictionary<string,TrunkPatch> trunks,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfigurationPatch(trunks);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(UpdateTrunks)}");
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
        /// Update <see cref="SipConfiguration"/> for resource with online routing settings. Other configuration settings are not affected.
        /// </summary>
        /// <param name="routes">List of online routing settings.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual Response<SipConfiguration> UpdateRoutingSettings(
            IList<TrunkRoute> routes,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfigurationPatch(routes);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(UpdateRoutingSettings)}");
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
        /// Update <see cref="SipConfiguration"/> for resource with online routing settings. Other configuration settings are not affected.
        /// </summary>
        /// <param name="routes">List of online routing settings.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>Updated configuration value.</returns>
        public virtual async Task<Response<SipConfiguration>> UpdateRoutingSettingsAsync(
            IList<TrunkRoute> routes,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfigurationPatch(routes);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(UpdateRoutingSettings)}");
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
