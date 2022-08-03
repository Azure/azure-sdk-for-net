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
        internal readonly string _resourceEndpoint;
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly HttpPipeline _pipeline;

        internal CallConnectionsRestClient CallConnectionsRestClient { get; }
        internal ServerCallingRestClient ServerCallingRestClient { get; }
        internal ContentRestClient ContentRestClient { get; }
        internal ServerCallsRestClient ServerCallsRestClient { get; }

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
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(Uri endpoint, TokenCredential credential, CallingServerClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
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

        private CallingServerClient(string endpoint, HttpPipeline httpPipeline, CallingServerClientOptions options)
        {
            _pipeline = httpPipeline;
            _resourceEndpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            ServerCallingRestClient = new ServerCallingRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            CallConnectionsRestClient = new CallConnectionsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            ContentRestClient = new ContentRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            ServerCallsRestClient = new ServerCallsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        private CallingServerClient(Uri endpoint, CallingServerClientOptions options, ConnectionString connectionString)
        : this(
        endpoint: endpoint.AbsoluteUri,
        httpPipeline: options.CustomBuildHttpPipeline(connectionString),
        options: options)
        { }
        #endregion

        /// <summary>Initializes a new instance of <see cref="CallingServerClient"/> for mocking.</summary>
        protected CallingServerClient()
        {
            _pipeline = null;
            _resourceEndpoint = null;
            _clientDiagnostics = null;
            CallConnectionsRestClient = null;
            ServerCallingRestClient = null;
            ContentRestClient = null;
        }

        /// Answer an incoming call.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="callbackEndpoint"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual async Task<Response<AnswerCallResult>> AnswerCallAsync(string incomingCallContext, Uri callbackEndpoint, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                AnswerCallRequestInternal request = new AnswerCallRequestInternal(incomingCallContext);
                request.CallbackUri = callbackEndpoint?.AbsoluteUri;

                var answerResponse = await ServerCallingRestClient.AnswerCallAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

                return Response.FromValue(new AnswerCallResult(GetCallConnection(answerResponse.Value.CallConnectionId), new CallConnectionProperties(answerResponse.Value)),
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
        /// <param name="callbackEndpoint"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual Response<AnswerCallResult> AnswerCall(string incomingCallContext, Uri callbackEndpoint, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                AnswerCallRequestInternal request = new AnswerCallRequestInternal(incomingCallContext);
                request.CallbackUri = callbackEndpoint?.AbsoluteUri;

                var answerResponse = ServerCallingRestClient.AnswerCall(request,
                    cancellationToken: cancellationToken);

                return Response.FromValue(new AnswerCallResult(GetCallConnection(answerResponse.Value.CallConnectionId), new CallConnectionProperties(answerResponse.Value)),
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
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null.</exception>
        public virtual async Task<Response> RedirectCallAsync(string incomingCallContext, CommunicationIdentifier target, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RedirectCall)}");
            scope.Start();
            try
            {
                RedirectCallRequestInternal request = new RedirectCallRequestInternal(incomingCallContext, CommunicationIdentifierSerializer.Serialize(target));

                return await ServerCallingRestClient.RedirectCallAsync(
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
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null.</exception>
        public virtual Response RedirectCall(string incomingCallContext, CommunicationIdentifier target, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RedirectCall)}");
            scope.Start();
            try
            {
                RedirectCallRequestInternal request = new RedirectCallRequestInternal(incomingCallContext, CommunicationIdentifierSerializer.Serialize(target));

                return ServerCallingRestClient.RedirectCall(
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
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual async Task<Response> RejectCallAsync(string incomingCallContext, CallRejectReason callRejectReason, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RejectCall)}");
            scope.Start();
            try
            {
                RejectCallRequestInternal request = new RejectCallRequestInternal(incomingCallContext);
                request.CallRejectReason = callRejectReason.ToString();

                return await ServerCallingRestClient.RejectCallAsync(request,
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
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual Response RejectCall(string incomingCallContext, CallRejectReason callRejectReason, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RejectCall)}");
            scope.Start();
            try
            {
                RejectCallRequestInternal request = new RejectCallRequestInternal(incomingCallContext);
                request.CallRejectReason = callRejectReason.ToString();

                return ServerCallingRestClient.RejectCall(request,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Create an outgoing call from source to target identities.
        /// <param name="source"> The source identity. </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="callbackEndpoint"> The callback Uri to receive status notifications. </param>
        /// <param name="subject"> Optional subject of the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        public virtual async Task<Response<CreateCallResult>> CreateCallAsync(CallSource source, IEnumerable<CommunicationIdentifier> targets, Uri callbackEndpoint, string subject = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                CallSourceDto sourceDto = new CallSourceDto(CommunicationIdentifierSerializer.Serialize(source.Identifier));
                 sourceDto.CallerId = source.CallerId == null ? null : new PhoneNumberIdentifierModel(source.CallerId.PhoneNumber);

                CreateCallRequestInternal request = new CreateCallRequestInternal(targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)), sourceDto, callbackEndpoint?.AbsoluteUri);
                request.Subject = subject;

                var createCallResponse = await ServerCallingRestClient.CreateCallAsync(
                    body: request,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(new CreateCallResult(GetCallConnection(createCallResponse.Value.CallConnectionId), new CallConnectionProperties(createCallResponse.Value)),
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
        /// <param name="targets"> The target identities. </param>
        /// <param name="callbackEndpoint"> The callback Uri to receive status notifications. </param>
        /// <param name="subject"> Optional subject of the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        public virtual Response<CreateCallResult> CreateCall(CallSource source, IEnumerable<CommunicationIdentifier> targets, Uri callbackEndpoint, string subject = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                CallSourceDto sourceDto = new CallSourceDto(CommunicationIdentifierSerializer.Serialize(source.Identifier));
                sourceDto.CallerId = source.CallerId == null ? null : new PhoneNumberIdentifierModel(source.CallerId.PhoneNumber);

                CreateCallRequestInternal request = new CreateCallRequestInternal(targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)), sourceDto, callbackEndpoint?.AbsoluteUri);
                request.Subject = subject;

                var createCallResponse = ServerCallingRestClient.CreateCall(
                    body: request,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(new CreateCallResult(GetCallConnection(createCallResponse.Value.CallConnectionId), new CallConnectionProperties(createCallResponse.Value)),
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of CallConnection. <see cref="CallConnection"/>.</summary>
        /// <param name="callConnectionId"> The call connection id for the GetCallConnection instance. </param>
        public virtual CallConnection GetCallConnection(string callConnectionId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetCallConnection)}");
            scope.Start();
            try
            {
                return new CallConnection(callConnectionId, CallConnectionsRestClient, ContentRestClient,_clientDiagnostics);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of GetCallRecording. <see cref="CallRecording"/>.</summary>
        public virtual CallRecording GetCallRecording()
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetCallRecording)}");
            scope.Start();
            try
            {
                return new CallRecording(_resourceEndpoint, ServerCallsRestClient, ContentRestClient, _clientDiagnostics, _pipeline);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
