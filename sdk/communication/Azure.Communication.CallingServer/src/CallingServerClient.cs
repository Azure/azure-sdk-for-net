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

        internal CallConnectionRestClient CallConnectionRestClient { get; }
        internal ServerCallingRestClient ServerCallRestClient { get; }

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
            CallConnectionRestClient = new CallConnectionRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            ServerCallRestClient = new ServerCallingRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="CallingServerClient"/> for mocking.</summary>
        protected CallingServerClient()
        {
            _pipeline = null;
            _resourceEndpoint = null;
            _clientDiagnostics = null;
            CallConnectionRestClient = null;
            ServerCallRestClient = null;
        }

        /// Create an outgoing call from source to target identities.
        /// <param name="source"> The source identity. </param>
        /// <param name="target"> The target identity. </param>
        /// <param name="callbackUri"> The callback uri. </param>
        /// <param name="options"> The call options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual async Task<Response<CallConnection>> CreateCallAsync(CommunicationIdentifier source, CommunicationIdentifier target, Uri callbackUri, CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                CreateCallRequestInternal request = new CreateCallRequestInternal(CommunicationIdentifierSerializer.Serialize(target), CommunicationIdentifierSerializer.Serialize(source));
                request.CallbackUri = callbackUri?.AbsoluteUri;
                request.AlternateCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                request.Subject = options.Subject;

                var createCallResponse = await ServerCallRestClient.CreateCallAsync(request,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnection(createCallResponse.Value.CallLegId, CallConnectionRestClient, _clientDiagnostics),
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Create an outgoing call from source to target identities.
        /// <param name="source"> The source identity. </param>
        /// <param name="target"> The target identity. </param>
        /// <param name="callbackUri"> The callback uri. </param>
        /// <param name="options"> The call options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual Response<CallConnection> CreateCall(CommunicationIdentifier source, CommunicationIdentifier target, Uri callbackUri, CreateCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                CreateCallRequestInternal request = new CreateCallRequestInternal(CommunicationIdentifierSerializer.Serialize(target), CommunicationIdentifierSerializer.Serialize(source));
                request.CallbackUri = callbackUri?.AbsoluteUri;
                request.Subject = options.Subject;
                request.AlternateCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);

                var createCallResponse = ServerCallRestClient.CreateCall(request,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(
                    new CallConnection(createCallResponse.Value.CallLegId, CallConnectionRestClient, _clientDiagnostics),
                    createCallResponse.GetRawResponse());
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
        public virtual async Task<Response<CallConnection>> AnswerCallAsync(string incomingCallContext, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AnswerCallAsync)}");
            scope.Start();
            try
            {
                AnswerCallRequest request = new AnswerCallRequest(incomingCallContext);
                request.CallbackUri = callbackUri?.AbsoluteUri;

                var answerResponse = await ServerCallRestClient.AnswerCallAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnection(answerResponse.Value.CallLegId, CallConnectionRestClient, _clientDiagnostics),
                    answerResponse.GetRawResponse());
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
        public virtual Response<CallConnection> AnswerCall(string incomingCallContext, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                AnswerCallRequest request = new AnswerCallRequest(incomingCallContext);
                request.CallbackUri = callbackUri?.AbsoluteUri;

                var answerResponse = ServerCallRestClient.AnswerCall(request,
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    new CallConnection(answerResponse.Value.CallLegId, CallConnectionRestClient, _clientDiagnostics),
                    answerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Redirect an incoming call to the target identities.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="target"> The target identities. </param>
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null.</exception>
        public virtual async Task<Response> RedirectCallAsync(string incomingCallContext, CommunicationIdentifier target, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RedirectCallAsync)}");
            scope.Start();
            try
            {
                RedirectCallRequestInternal request = new RedirectCallRequestInternal(incomingCallContext, CommunicationIdentifierSerializer.Serialize(target));
                request.CallbackUri = callbackUri?.AbsoluteUri;

                return await ServerCallRestClient.RedirectCallAsync(
                    request,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Redirect an incoming call to the target identities.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="target"> The target identities. </param>
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null.</exception>
        public virtual Response RedirectCall(string incomingCallContext, CommunicationIdentifier target, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RedirectCall)}");
            scope.Start();
            try
            {
                RedirectCallRequestInternal request = new RedirectCallRequestInternal(incomingCallContext, CommunicationIdentifierSerializer.Serialize(target));
                request.CallbackUri = callbackUri?.AbsoluteUri;

                return ServerCallRestClient.RedirectCall(
                    request,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Reject an incoming call.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="callRejectReason"> The reason for rejecting call. </param>
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual async Task<Response> RejectCallAsync(string incomingCallContext, CallRejectReason callRejectReason, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RejectCallAsync)}");
            scope.Start();
            try
            {
                RejectCallRequest request = new RejectCallRequest(incomingCallContext);
                request.CallRejectReason = callRejectReason.ToString();
                request.CallbackUri = callbackUri?.AbsoluteUri;

                return await ServerCallRestClient.RejectCallAsync(request,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Reject an incoming call.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="callRejectReason"> The reason for rejecting call. </param>
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual Response RejectCall(string incomingCallContext, CallRejectReason callRejectReason, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RejectCall)}");
            scope.Start();
            try
            {
                RejectCallRequest request = new RejectCallRequest(incomingCallContext);
                request.CallRejectReason = callRejectReason.ToString();
                request.CallbackUri = callbackUri?.AbsoluteUri;

                return ServerCallRestClient.RejectCall(request,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
