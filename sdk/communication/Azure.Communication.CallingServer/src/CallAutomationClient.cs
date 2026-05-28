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
    /// The Azure Communication Services Call Automation client.
    /// </summary>
    public class CallAutomationClient
    {
        internal readonly string _resourceEndpoint;
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly HttpPipeline _pipeline;

        internal CallConnectionsRestClient CallConnectionsRestClient { get; }
        internal ServerCallingRestClient ServerCallingRestClient { get; }
        internal ContentRestClient ContentRestClient { get; }
        internal ServerCallsRestClient ServerCallsRestClient { get; }

        #region public constructors
        /// <summary> Initializes a new instance of <see cref="CallAutomationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public CallAutomationClient(string connectionString)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  new CallAutomationClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallAutomationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallAutomationClient(string connectionString, CallAutomationClientOptions options)
            : this(
                  ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                  Argument.CheckNotNull(options, nameof(options)))
        { }

        /// <summary> Initializes a new instance of <see cref="CallAutomationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallAutomationClient(Uri endpoint, TokenCredential credential, CallAutomationClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new CallAutomationClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="CallAutomationClient"/> with custom PMA endpoint.</summary>
        /// <param name="pmaEndpoint">Endpoint for PMA</param>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallAutomationClient(Uri pmaEndpoint, string connectionString, CallAutomationClientOptions options = default)
        : this(
        pmaEndpoint,
        options ?? new CallAutomationClientOptions(),
        ConnectionString.Parse(connectionString))
        { }
        #endregion

        #region private constructors
        private CallAutomationClient(ConnectionString connectionString, CallAutomationClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private CallAutomationClient(string endpoint, TokenCredential tokenCredential, CallAutomationClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private CallAutomationClient(string endpoint, HttpPipeline httpPipeline, CallAutomationClientOptions options)
        {
            _pipeline = httpPipeline;
            _resourceEndpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);
            ServerCallingRestClient = new ServerCallingRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            CallConnectionsRestClient = new CallConnectionsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            ContentRestClient = new ContentRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            ServerCallsRestClient = new ServerCallsRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        private CallAutomationClient(Uri endpoint, CallAutomationClientOptions options, ConnectionString connectionString)
        : this(
        endpoint: endpoint.AbsoluteUri,
        httpPipeline: options.CustomBuildHttpPipeline(connectionString),
        options: options)
        { }
        #endregion

        /// <summary>Initializes a new instance of <see cref="CallAutomationClient"/> for mocking.</summary>
        protected CallAutomationClient()
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
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual async Task<Response<AnswerCallResult>> AnswerCallAsync(string incomingCallContext, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext, callbackUri);

            return await AnswerCallAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Answer an incoming call.
        /// </summary>
        /// <param name="options">Options for the Answer Call operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<Response<AnswerCallResult>> AnswerCallAsync(AnswerCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                if (options == null) throw new ArgumentNullException(nameof(options));

                AnswerCallRequestInternal request = CreateAnswerCallRequest(options);

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
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual Response<AnswerCallResult> AnswerCall(string incomingCallContext, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            AnswerCallOptions options = new AnswerCallOptions(incomingCallContext, callbackUri);

            return AnswerCall(options, cancellationToken);
        }

        /// <summary>
        /// Answer an incoming call.
        /// </summary>
        /// <param name="options">Options for the AnswerCall operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns></returns>
        public virtual Response<AnswerCallResult> AnswerCall(AnswerCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                if (options == null) throw new ArgumentNullException(nameof(options));

                AnswerCallRequestInternal request = CreateAnswerCallRequest(options);

                var answerResponse = ServerCallingRestClient.AnswerCall(request, cancellationToken: cancellationToken);

                return Response.FromValue(new AnswerCallResult(GetCallConnection(answerResponse.Value.CallConnectionId), new CallConnectionProperties(answerResponse.Value)),
                    answerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static AnswerCallRequestInternal CreateAnswerCallRequest(AnswerCallOptions options)
        {
            AnswerCallRequestInternal request = new AnswerCallRequestInternal(options.IncomingCallContext, options.CallbackUri.AbsoluteUri);
            request.MediaStreamingConfiguration = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);

            return request;
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RedirectCall)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RedirectCall)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RejectCall)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RejectCall)}");
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
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="subject"> Optional subject of the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        public virtual async Task<Response<CreateCallResult>> CreateCallAsync(CallSource source, IEnumerable<CommunicationIdentifier> targets, Uri callbackUri, string subject = default, CancellationToken cancellationToken = default)
        {
            CreateCallOptions options = new CreateCallOptions(source, targets, callbackUri)
            {
                Subject = subject
            };
            return await CreateCallAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create an outgoing call from source to target identities.
        /// </summary>
        /// <param name="options">Options for the CreateCall request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<Response<CreateCallResult>> CreateCallAsync(CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                CreateCallRequestInternal request = CreateCallRequest(options);

                var createCallResponse = await ServerCallingRestClient.CreateCallAsync(
                    createCallRequestInternal: request,
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
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="subject"> Optional subject of the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        public virtual Response<CreateCallResult> CreateCall(CallSource source, IEnumerable<CommunicationIdentifier> targets, Uri callbackUri, string subject = default, CancellationToken cancellationToken = default)
        {
            CreateCallOptions options = new CreateCallOptions(source, targets, callbackUri)
            {
                Subject = subject
            };
            return CreateCall(options, cancellationToken);
        }

        /// <summary>
        /// Create an outgoing call from source to target identities.
        /// </summary>
        /// <param name="options">Options for the CreateCall request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>

        public virtual Response<CreateCallResult> CreateCall(CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                if (options == null) throw new ArgumentNullException(nameof(options));

                CallSourceInternal sourceDto = new CallSourceInternal(CommunicationIdentifierSerializer.Serialize(options.CallSource.Identifier));
                sourceDto.CallerId = options.CallSource.CallerId == null ? null : new PhoneNumberIdentifierModel(options.CallSource.CallerId.PhoneNumber);

                CreateCallRequestInternal request = CreateCallRequest(options);

                var createCallResponse = ServerCallingRestClient.CreateCall(
                    createCallRequestInternal: request,
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

        private static CreateCallRequestInternal CreateCallRequest(CreateCallOptions options)
        {
            CallSourceInternal sourceDto = new CallSourceInternal(CommunicationIdentifierSerializer.Serialize(options.CallSource.Identifier));
            sourceDto.CallerId = options.CallSource.CallerId == null ? null : new PhoneNumberIdentifierModel(options.CallSource.CallerId.PhoneNumber);

            CreateCallRequestInternal request = new CreateCallRequestInternal(
                options.Targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                sourceDto,
                options.CallbackUri.AbsoluteUri);
            request.Subject = options.Subject;
            request.MediaStreamingConfiguration = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);

            return request;
        }

        private static MediaStreamingOptionsInternal CreateMediaStreamingOptionsInternal(MediaStreamingOptions configuration)
        {
            return configuration == default
                ? default
                : new MediaStreamingOptionsInternal(configuration.TransportUri.AbsoluteUri, configuration.MediaStreamingTransport, configuration.MediaStreamingContent,
                configuration.MediaStreamingAudioChannel);
        }

        /// <summary> Initializes a new instance of CallConnection. <see cref="CallConnection"/>.</summary>
        /// <param name="callConnectionId"> The call connection id for the GetCallConnection instance. </param>
        public virtual CallConnection GetCallConnection(string callConnectionId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(GetCallConnection)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(GetCallRecording)}");
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
