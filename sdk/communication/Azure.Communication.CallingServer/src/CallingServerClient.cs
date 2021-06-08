// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services Calling Server client.
    /// </summary>
    public class CallingServerClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallConnectionRestClient CallConnectionRestClient { get; }
        internal ServerCallRestClient ServerCallRestClient { get; }

        #region public constructors - all arguments need null check

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(string connectionString, CallingServerClientOptions options = default)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  options ?? new CallingServerClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(Uri endpoint, AzureKeyCredential keyCredential, CallingServerClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new CallingServerClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(Uri endpoint, TokenCredential tokenCredential, CallingServerClientOptions options = default)
            : this(
                  Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                  Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                  options ?? new CallingServerClientOptions())
        { }

        #endregion

        #region private constructors

        private CallingServerClient(ConnectionString connectionString, CallingServerClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private CallingServerClient(string endpoint, TokenCredential tokenCredential, CallingServerClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private CallingServerClient(string endpoint, AzureKeyCredential keyCredential, CallingServerClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private CallingServerClient(string endpoint, HttpPipeline httpPipeline, CallingServerClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            CallConnectionRestClient = new CallConnectionRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            ServerCallRestClient = new ServerCallRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="CallingServerClient"/> for mocking.</summary>
        protected CallingServerClient()
        {
            _clientDiagnostics = null;
            CallConnectionRestClient = null;
            ServerCallRestClient = null;
        }

        /// Create an outgoing call from source to target identities.
        /// <param name="source"> The source identity </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="options"> The call options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual async Task<Response<CallConnection>> CreateCallConnectionAsync(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCallConnection)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                Argument.AssertNotNull(options, nameof(options));

                var alternateCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);

                var createCallResponse = await CallConnectionRestClient.CreateCallAsync(
                    targets: targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    callbackUri: options.CallbackUri?.AbsoluteUri,
                    requestedMediaTypes: options.RequestedMediaTypes,
                    requestedCallEvents: options.RequestedCallEvents,
                    alternateCallerId: alternateCallerId,
                    subject: options.Subject,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnection(createCallResponse.Value.CallConnectionId, CallConnectionRestClient, _clientDiagnostics),
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Create an outgoing call from source to target identities.
        /// <param name="source"> The source identity </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="options"> The call options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual Response<CallConnection> CreateCallConnection(CommunicationIdentifier source, IEnumerable<CommunicationIdentifier> targets, CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCallConnection)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                Argument.AssertNotNull(options, nameof(options));

                var alternateCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);

                var createCallResponse = CallConnectionRestClient.CreateCall(
                    targets: targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    callbackUri: options.CallbackUri?.AbsoluteUri,
                    requestedMediaTypes: options.RequestedMediaTypes,
                    requestedCallEvents: options.RequestedCallEvents,
                    alternateCallerId: alternateCallerId,
                    subject: options.Subject,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(
                    new CallConnection(createCallResponse.Value.CallConnectionId, CallConnectionRestClient, _clientDiagnostics),
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Join the call using server call id.
        /// <param name="serverCallId"> The server call id. </param>
        /// <param name="source"> The source identity. </param>
        /// <param name="callOptions"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="serverCallId"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callOptions"/> is null.</exception>
        public virtual async Task<Response<CallConnection>> JoinCallConnectionAsync(string serverCallId, CommunicationIdentifier source, JoinCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(JoinCallConnection)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                var joinCallResponse = await ServerCallRestClient.JoinCallAsync(
                    serverCallId: serverCallId,
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    callbackUri: callOptions.CallbackUri?.AbsoluteUri,
                    requestedMediaTypes: callOptions.RequestedMediaTypes,
                    requestedCallEvents: callOptions.RequestedCallEvents,
                    subject: null,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnection(joinCallResponse.Value.CallConnectionId, CallConnectionRestClient, _clientDiagnostics),
                    joinCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Join the call using server call id.
        /// <param name="serverCallId"> The server call id. </param>
        /// <param name="source"> The source identity. </param>
        /// <param name="callOptions"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="serverCallId"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callOptions"/> is null.</exception>
        public virtual Response<CallConnection> JoinCallConnection(string serverCallId, CommunicationIdentifier source, JoinCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(JoinCallConnection)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                var joinCallResponse = ServerCallRestClient.JoinCall(
                    serverCallId: serverCallId,
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    callbackUri: callOptions.CallbackUri?.AbsoluteUri,
                    requestedMediaTypes: callOptions.RequestedMediaTypes,
                    requestedCallEvents: callOptions.RequestedCallEvents,
                    subject: null,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(
                    new CallConnection(joinCallResponse.Value.CallConnectionId, CallConnectionRestClient, _clientDiagnostics),
                    joinCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of CallConnection. <see cref="CallConnection"/>.</summary>
        /// <param name="callConnectionId"> The thread id for the ChatThreadClient instance. </param>
        public virtual CallConnection GetCallConnection(string callConnectionId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CallingServerClient)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(callConnectionId, nameof(callConnectionId));

                return new CallConnection(callConnectionId, CallConnectionRestClient, _clientDiagnostics);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Initializes a server call.
        /// </summary>
        /// <param name="serverCallId">The server call id. </param>
        /// <returns></returns>
        public virtual ServerCall InitializeServerCall(string serverCallId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(InitializeServerCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(serverCallId, nameof(serverCallId));

                return new ServerCall(serverCallId, ServerCallRestClient, _clientDiagnostics);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
