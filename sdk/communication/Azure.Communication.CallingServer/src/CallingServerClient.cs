// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;
using Azure.Communication.CallingServer;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services Calling Server client.
    /// </summary>
    public class CallingServerClient
    {
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly HttpPipeline _pipeline;
        internal readonly string _resourceEndpoint;

        internal ServerCallsRestClient ServerCallRestClient { get; }

        #region public constructors
        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public CallingServerClient(string connectionString)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  new CallingServerClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(string connectionString, CallingServerClientOptions options)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  Argument.CheckNotNull(options, nameof(options)))
        { }

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        public CallingServerClient(Uri endpoint, TokenCredential credential)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                new CallingServerClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="endpoint">Endpoint</param>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(Uri endpoint, string connectionString, CallingServerClientOptions options = default)
        : this(
        endpoint,
        options ?? new CallingServerClientOptions(),
        ConnectionString.Parse(connectionString))
        { }

        private CallingServerClient(Uri endpoint, CallingServerClientOptions options, ConnectionString connectionString)
        : this(
        endpoint: endpoint.AbsoluteUri,
        httpPipeline: options.BuildHttpPipeline(connectionString),
        options: options)
        { }

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(Uri endpoint, TokenCredential credential, CallingServerClientOptions options)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                Argument.CheckNotNull(options, nameof(options)))
        { }
        #endregion

        #region private constructors

        private CallingServerClient(ConnectionString connectionString, CallingServerClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private CallingServerClient(string endpoint, TokenCredential tokenCredential, CallingServerClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private CallingServerClient(string endpoint, HttpPipeline httpPipeline, CallingServerClientOptions options)
        {
            _pipeline = httpPipeline;
            _resourceEndpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            ServerCallRestClient = new ServerCallsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="CallingServerClient"/> for mocking.</summary>
        protected CallingServerClient()
        {
            _pipeline = null;
            _resourceEndpoint = null;
            _clientDiagnostics = null;
            ServerCallRestClient = null;
        }

        /// Answer an incoming call.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual Response<AnswerCallResponse> AnswerCall(string incomingCallContext, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                var answerResponse = ServerCallRestClient.AnswerCall(
                    incomingCallContext: incomingCallContext,
                    callbackUri: callbackUri?.AbsoluteUri,
                    cancellationToken: cancellationToken);

                return answerResponse;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Answer an incoming call.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual async Task<Response<AnswerCallResponse>> AnswerCallAsync(string incomingCallContext, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AnswerCallAsync)}");
            scope.Start();
            try
            {
                var answerResponse = await ServerCallRestClient.AnswerCallAsync(
                    incomingCallContext: incomingCallContext,
                    callbackUri: callbackUri?.AbsoluteUri,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return answerResponse;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
