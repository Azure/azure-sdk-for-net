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
using Azure.Communication.CallingServer.Models;

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

        /// <summary> Initializes a new instance of <see cref="CallingServerClient"/> with custom PMA endpoint.</summary>
        /// <param name="pmaEndpoint">Endpoint for PMA</param>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallingServerClient(Uri pmaEndpoint, string connectionString, CallingServerClientOptions options = default)
        : this(
        pmaEndpoint,
        options ?? new CallingServerClientOptions(),
        ConnectionString.Parse(connectionString))
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
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual async Task<Response<CallConnectionProperties>> AnswerCallAsync(string incomingCallContext, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                AnswerCallRequestInternal request = new AnswerCallRequestInternal(incomingCallContext);
                request.CallbackUri = callbackUri?.AbsoluteUri;

                var answerResponse = await ServerCallingRestClient.AnswerCallAsync(request, cancellationToken: cancellationToken).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnectionProperties(answerResponse.Value),
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
        public virtual Response<CallConnectionProperties> AnswerCall(string incomingCallContext, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                AnswerCallRequestInternal request = new AnswerCallRequestInternal(incomingCallContext);
                request.CallbackUri = callbackUri?.AbsoluteUri;

                var answerResponse = ServerCallingRestClient.AnswerCall(request,
                    cancellationToken: cancellationToken);

                return Response.FromValue(
                    new CallConnectionProperties(answerResponse.Value),
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
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="options"> The call options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual async Task<Response<CallConnectionProperties>> CreateCallAsync(CallSource source, IEnumerable<CommunicationIdentifier> targets, Uri callbackUri, CreateCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                CallSourceDto sourceDto = new CallSourceDto(CommunicationIdentifierSerializer.Serialize(source.Identifier));

                if (options != null)
                {
                    sourceDto.CallerId = source.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(source.AlternateCallerId.PhoneNumber);
                }

                CreateCallRequestInternal request = new CreateCallRequestInternal(targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)), sourceDto, callbackUri?.AbsoluteUri);

                if (options != null)
                {
                    request.Subject = options.Subject;
                }

                var createCallResponse = await ServerCallingRestClient.CreateCallAsync(
                    body: request,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnectionProperties(createCallResponse.Value),
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
        /// <param name="options"> The call options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targets"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual Response<CallConnectionProperties> CreateCall(CallSource source, IEnumerable<CommunicationIdentifier> targets, Uri callbackUri, CreateCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                CallSourceDto sourceDto = new CallSourceDto(CommunicationIdentifierSerializer.Serialize(source.Identifier));

                if (options != null)
                {
                    sourceDto.CallerId = source.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(source.AlternateCallerId.PhoneNumber);
                }

                CreateCallRequestInternal request = new CreateCallRequestInternal(targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)), sourceDto, callbackUri?.AbsoluteUri);

                if (options != null)
                {
                    request.Subject = options.Subject;
                }

                var createCallResponse = ServerCallingRestClient.CreateCall(
                    body: request,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(
                    new CallConnectionProperties(createCallResponse.Value),
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get CallConnection. <see cref="CallConnectionClient"/>.</summary>
        /// <param name="callConnectionId"> The thread id for the ChatThreadClient instance. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual async Task<Response<CallConnectionProperties>> GetCallConnectionPropertiesAsync(string callConnectionId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetCallConnectionProperties)}");
            scope.Start();
            try
            {
                var response = await CallConnectionsRestClient.GetCallAsync(callConnectionId, cancellationToken: cancellationToken).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnectionProperties(response.Value),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get CallConnection. <see cref="CallConnectionClient"/>.</summary>
        /// <param name="callConnectionId"> The thread id for the ChatThreadClient instance. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<CallConnectionProperties> GetCallConnectionProperties(string callConnectionId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetCallConnectionProperties)}");
            scope.Start();
            try
            {
                var response = CallConnectionsRestClient.GetCall(callConnectionId, cancellationToken: cancellationToken);

                return Response.FromValue(
                    new CallConnectionProperties(response.Value),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of CallConnectionClient. <see cref="GetCallConnectionClient"/>.</summary>
        /// <param name="callConnectionId"> The thread id for the ChatThreadClient instance. </param>
        public virtual CallConnectionClient GetCallConnectionClient(string callConnectionId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetCallConnectionClient)}");
            scope.Start();
            try
            {
                return new CallConnectionClient(callConnectionId, CallConnectionsRestClient, _clientDiagnostics);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of CallConnectionClient. <see cref="CallRecordingClient"/>.</summary>
        public virtual CallRecordingClient GetCallRecordingClient()
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetCallRecordingClient)}");
            scope.Start();
            try
            {
                return new CallRecordingClient(_resourceEndpoint, ServerCallsRestClient, ContentRestClient, _clientDiagnostics, _pipeline);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of CallContentClient. <see cref="CallContentClient"/>.</summary>
        /// <param name="callConnectionId"> The thread id for the ChatThreadClient instance. </param>
        public virtual CallContentClient GetContentClient(string callConnectionId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetCallConnectionClient)}");
            scope.Start();
            try
            {
                return new CallContentClient(callConnectionId, ContentRestClient, _clientDiagnostics);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
