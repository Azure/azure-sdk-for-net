// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.NetworkTraversal
{
    /// <summary>
    /// The Azure Communication Services Networking client.
    /// </summary>
    public class CommunicationRelayClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CommunicationNetworkTraversalRestClient RestClient { get; }

        #region public constructors - all argument need null check

        /// <summary> Initializes a new instance of <see cref="CommunicationRelayClient"/>.</summary>
        /// <param name="connectionString"> Connection string acquired from the Azure Communication Services resource. </param>
        public CommunicationRelayClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new CommunicationRelayClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationRelayClient"/>.</summary>
        /// <param name="connectionString"> Connection string acquired from the Azure Communication Services resource. </param>
        /// <param name="options"> Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationRelayClient(string connectionString, CommunicationRelayClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new CommunicationRelayClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationRelayClient"/>.</summary>
        /// <param name="endpoint"> The URI of the Azure Communication Services resource. </param>
        /// <param name="keyCredential"> The <see cref="AzureKeyCredential"/> used to authenticate requests. </param>
        /// <param name="options"> Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationRelayClient(Uri endpoint, AzureKeyCredential keyCredential, CommunicationRelayClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new CommunicationRelayClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CommunicationRelayClient"/>.</summary>
        /// <param name="endpoint"> The URI of the Azure Communication Services resource. </param>
        /// <param name="tokenCredential"> The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential. </param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CommunicationRelayClient(Uri endpoint, TokenCredential tokenCredential, CommunicationRelayClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new CommunicationRelayClientOptions())
        { }

        #endregion

        #region private constructors

        private CommunicationRelayClient(ConnectionString connectionString, CommunicationRelayClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private CommunicationRelayClient(string endpoint, AzureKeyCredential keyCredential, CommunicationRelayClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private CommunicationRelayClient(string endpoint, TokenCredential tokenCredential, CommunicationRelayClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private CommunicationRelayClient(string endpoint, HttpPipeline httpPipeline, CommunicationRelayClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new CommunicationNetworkTraversalRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="CommunicationRelayClient"/> for mocking.</summary>
        protected CommunicationRelayClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        /// <summary>Gets a Relay Configuration for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to issue a token.</param>
        /// <param name="routeType"> The specified <see cref="RouteType"/> for the relay request </param>
        /// <param name="ttl"> The specified Time-to-live for the relay credential in seconds </param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="RequestFailedException">The server returned an error.</exception>
        public virtual Response<CommunicationRelayConfiguration> GetRelayConfiguration(CommunicationUserIdentifier communicationUser = null, RouteType? routeType = null, int? ttl = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationRelayClient)}.{nameof(GetRelayConfiguration)}");
            scope.Start();
            try
            {
                return RestClient.IssueRelayConfiguration(communicationUser?.Id, routeType, ttl, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Asynchronously gets a Relay Configuration for a <see cref="CommunicationUserIdentifier"/>.</summary>
        /// <param name="communicationUser">The <see cref="CommunicationUserIdentifier"/> for whom to issue a token.</param>
        /// <param name="routeType"> The specified <see cref="RouteType"/> for the relay request </param>
        /// <param name="ttl"> The specified Time-to-live for the relay credential in seconds </param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public virtual async Task<Response<CommunicationRelayConfiguration>> GetRelayConfigurationAsync(CommunicationUserIdentifier communicationUser = null, RouteType? routeType = null, int? ttl = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CommunicationRelayClient)}.{nameof(GetRelayConfiguration)}");
            scope.Start();
            try
            {
                return await RestClient.IssueRelayConfigurationAsync(communicationUser?.Id, routeType, ttl, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
