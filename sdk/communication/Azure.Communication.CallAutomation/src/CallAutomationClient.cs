// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Azure Communication Services Call Automation client.
    /// </summary>
    public class CallAutomationClient
    {
        internal readonly string _resourceEndpoint;
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly HttpPipeline _pipeline;

        internal CallConnectionRestClient CallConnectionRestClient { get; }
        internal AzureCommunicationServicesRestClient AzureCommunicationServicesRestClient { get; }
        internal CallMediaRestClient CallMediaRestClient { get; }
        internal CallRecordingRestClient CallRecordingRestClient { get; }
        internal CallDialogRestClient CallDialogRestClient { get; }
        internal CallAutomationEventProcessor EventProcessor { get; }

        /// <summary>
        /// CommunicationUserIdentifier that makes the outbound call.
        /// This can be provided by providing CallAutomationClientOption during construction of CallAutomationClient.
        /// If left blank, service will create one each request.
        /// </summary>
        public CommunicationUserIdentifier Source { get; }

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

        /// <summary> Initializes a new instance of <see cref="CallAutomationClient"/>.</summary>
        /// <param name="pmaEndpoint">Endpoint for PMA</param>
        /// <param name="acsEndpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public CallAutomationClient(Uri pmaEndpoint, Uri acsEndpoint, TokenCredential credential, CallAutomationClientOptions options = default)
        : this(
              pmaEndpoint,
              acsEndpoint,
              options ?? new CallAutomationClientOptions(),
              credential
              )
        { }
        #endregion

        #region private constructors
        private CallAutomationClient(ConnectionString connectionString, CallAutomationClientOptions options)
            : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        { }

        private CallAutomationClient(string endpoint, TokenCredential tokenCredential, CallAutomationClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(tokenCredential), options)
        { }

        private CallAutomationClient(Uri endpoint, CallAutomationClientOptions options, ConnectionString connectionString)
        : this(
        endpoint: endpoint,
        httpPipeline: options.CustomBuildHttpPipeline(connectionString),
        options: options)
        { }

        private CallAutomationClient(Uri endpoint, HttpPipeline httpPipeline, CallAutomationClientOptions options)
        {
            _pipeline = httpPipeline;
            _resourceEndpoint = endpoint.AbsoluteUri;
            _clientDiagnostics = new ClientDiagnostics(options);
            AzureCommunicationServicesRestClient = new AzureCommunicationServicesRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            CallConnectionRestClient = new CallConnectionRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            CallMediaRestClient = new CallMediaRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            CallRecordingRestClient = new CallRecordingRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            CallDialogRestClient = new CallDialogRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
            EventProcessor = new CallAutomationEventProcessor();
            Source = options.Source;
        }

        private CallAutomationClient(
            Uri pmaEndpoint,
            Uri acsEndpoint,
            CallAutomationClientOptions options,
            TokenCredential tokenCredential)
            : this(pmaEndpoint, options.CustomBuildHttpPipeline(acsEndpoint, tokenCredential), options)
        { }
        #endregion

        /// <summary>Initializes a new instance of <see cref="CallAutomationClient"/> for mocking.</summary>
        protected CallAutomationClient()
        {
            _pipeline = null;
            _resourceEndpoint = null;
            _clientDiagnostics = null;
            CallConnectionRestClient = null;
            AzureCommunicationServicesRestClient = null;
            CallMediaRestClient = null;
        }

        /// Answer an incoming call.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="callbackUri"> The callback Uri to receive status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentException"><paramref name="callbackUri"/> callbackUri is not formatted correctly. </exception>
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
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> CallbackUri is not formatted correctly. </exception>
        /// <returns></returns>
        public virtual async Task<Response<AnswerCallResult>> AnswerCallAsync(AnswerCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                AnswerCallRequestInternal request = CreateAnswerCallRequest(options);

                var answerResponse = await AzureCommunicationServicesRestClient.AnswerCallAsync(request, cancellationToken).ConfigureAwait(false);

                var result = new AnswerCallResult(GetCallConnection(answerResponse.Value.CallConnectionId), new CallConnectionProperties(answerResponse.Value));
                result.SetEventProcessor(EventProcessor, answerResponse.Value.CallConnectionId, null);

                return Response.FromValue(result,
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
        /// <exception cref="ArgumentException"><paramref name="callbackUri"/> callbackUri is not formatted correctly. </exception>
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
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> CallbackUri is not formatted correctly. </exception>
        /// <returns></returns>
        public virtual Response<AnswerCallResult> AnswerCall(AnswerCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                AnswerCallRequestInternal request = CreateAnswerCallRequest(options);

                var answerResponse = AzureCommunicationServicesRestClient.AnswerCall(request, cancellationToken);

                var result = new AnswerCallResult(GetCallConnection(answerResponse.Value.CallConnectionId), new CallConnectionProperties(answerResponse.Value));
                result.SetEventProcessor(EventProcessor, answerResponse.Value.CallConnectionId, null);

                return Response.FromValue(result,
                    answerResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private AnswerCallRequestInternal CreateAnswerCallRequest(AnswerCallOptions options)
        {
            AnswerCallRequestInternal request = new AnswerCallRequestInternal(options.IncomingCallContext, options.CallbackUri.AbsoluteUri);

            // Add CallIntelligenceOptions such as custom cognitive service domain name
            string cognitiveServicesEndpoint = options.CallIntelligenceOptions?.CognitiveServicesEndpoint?.AbsoluteUri;
            if (cognitiveServicesEndpoint != null)
            {
                request.CallIntelligenceOptions = new()
                {
                    CognitiveServicesEndpoint = cognitiveServicesEndpoint
                };
            }

            request.MediaStreamingOptions = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);
            request.TranscriptionOptions = CreateTranscriptionOptionsInternal(options.TranscriptionOptions);
            request.AnsweredBy = Source == null ? null : new CommunicationUserIdentifierModel(Source.Id);
            request.OperationContext = options.OperationContext;
            request.CustomCallingContext = new CustomCallingContextInternal(
                options.CustomCallingContext?.SipHeaders ?? new ChangeTrackingDictionary<string, string>(),
                options.CustomCallingContext?.VoipHeaders ?? new ChangeTrackingDictionary<string, string>());

            return request;
        }

        /// Redirect an incoming call to the target identity.
        /// <param name="incomingCallContext"> The incoming call context. </param>
        /// <param name="callInvite"> The target where the call is redirected to. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callInvite"/> is null.</exception>
        public virtual async Task<Response> RedirectCallAsync(string incomingCallContext, CallInvite callInvite, CancellationToken cancellationToken = default)
        {
            RedirectCallOptions options = new RedirectCallOptions(incomingCallContext, callInvite);

            return await RedirectCallAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// Redirect an incoming call to the target identity.
        /// <param name="options">Options for the Redirect operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual async Task<Response> RedirectCallAsync(RedirectCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RedirectCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                RedirectCallRequestInternal request = new RedirectCallRequestInternal(options.IncomingCallContext, CommunicationIdentifierSerializer.Serialize(options.CallInvite.Target));

                request.CustomCallingContext = new CustomCallingContextInternal(
                   options.CallInvite.CustomCallingContext.SipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.CallInvite.CustomCallingContext.SipHeaders,
                   options.CallInvite.CustomCallingContext.VoipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.CallInvite.CustomCallingContext.VoipHeaders);

                return await AzureCommunicationServicesRestClient.RedirectCallAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Redirect an incoming call to the target identities.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="callInvite"> The target where the call is redirected to.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callInvite"/> is null.</exception>
        public virtual Response RedirectCall(string incomingCallContext, CallInvite callInvite, CancellationToken cancellationToken = default)
        {
            RedirectCallOptions options = new RedirectCallOptions(incomingCallContext, callInvite);

            return RedirectCall(options, cancellationToken);
        }

        /// Redirect an incoming call to the target identity.
        /// <param name="options">Options for the Redirect operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual Response RedirectCall(RedirectCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RedirectCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                RedirectCallRequestInternal request = new RedirectCallRequestInternal(options.IncomingCallContext, CommunicationIdentifierSerializer.Serialize(options.CallInvite.Target));

                request.CustomCallingContext = new CustomCallingContextInternal(
                                   options.CallInvite.CustomCallingContext.SipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.CallInvite.CustomCallingContext.SipHeaders,
                                   options.CallInvite.CustomCallingContext.VoipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.CallInvite.CustomCallingContext.VoipHeaders);

                return AzureCommunicationServicesRestClient.RedirectCall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Reject an incoming call.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual async Task<Response> RejectCallAsync(string incomingCallContext, CancellationToken cancellationToken = default)
        {
            RejectCallOptions options = new RejectCallOptions(incomingCallContext);

            return await RejectCallAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// Reject an incoming call.
        /// <param name="options">Options for the Reject operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual async Task<Response> RejectCallAsync(RejectCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RejectCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                RejectCallRequestInternal request = new RejectCallRequestInternal(options.IncomingCallContext);
                request.CallRejectReason = options.CallRejectReason.ToString();

                return await AzureCommunicationServicesRestClient.RejectCallAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Reject an incoming call.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        public virtual Response RejectCall(string incomingCallContext, CancellationToken cancellationToken = default)
        {
            RejectCallOptions options = new RejectCallOptions(incomingCallContext);

            return RejectCall(options, cancellationToken);
        }

        /// Reject an incoming call.
        /// <param name="options">Options for the Reject operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual Response RejectCall(RejectCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RejectCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                RejectCallRequestInternal request = new RejectCallRequestInternal(options.IncomingCallContext);
                request.CallRejectReason = options.CallRejectReason.ToString();

                return AzureCommunicationServicesRestClient.RejectCall(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Create an outgoing call to target invitee.
        /// </summary>
        /// <param name="callInvite"></param>
        /// <param name="callbackUri"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"><paramref name="callInvite"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="callbackUri"/> CallbackUri is not formatted correctly or empty. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual async Task<Response<CreateCallResult>> CreateCallAsync(CallInvite callInvite, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            CreateCallOptions options = new CreateCallOptions(callInvite, callbackUri);

            return await CreateCallAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create an outgoing call to target invitee.
        /// </summary>
        /// <param name="options">Options for the CreateCall request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> CallbackUri is not formatted correctly. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
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

                var createCallResponse = await AzureCommunicationServicesRestClient.CreateCallAsync(request, cancellationToken).ConfigureAwait(false);

                var result = new CreateCallResult(
                    GetCallConnection(createCallResponse.Value.CallConnectionId),
                    new CallConnectionProperties(createCallResponse.Value));
                result.SetEventProcessor(EventProcessor, createCallResponse.Value.CallConnectionId, request.OperationContext);

                return Response.FromValue(result,
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Create an outgoing call to target invitee.
        /// </summary>
        /// <param name="callInvite"></param>
        /// <param name="callbackUri"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"><paramref name="callInvite"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="callbackUri"/> CallbackUri is not formatted correctly or empty. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual Response<CreateCallResult> CreateCall(CallInvite callInvite, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            CreateCallOptions options = new CreateCallOptions(callInvite, callbackUri);

            return CreateCall(options, cancellationToken);
        }

        /// <summary>
        /// Create an outgoing call to target invitee.
        /// </summary>
        /// <param name="options">Options for the CreateCall request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> CallbackUri is not formatted correctly. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>

        public virtual Response<CreateCallResult> CreateCall(CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                CreateCallRequestInternal request = CreateCallRequest(options);

                var createCallResponse = AzureCommunicationServicesRestClient.CreateCall(request, cancellationToken);

                var result = new CreateCallResult(
                    GetCallConnection(createCallResponse.Value.CallConnectionId),
                    new CallConnectionProperties(createCallResponse.Value));
                result.SetEventProcessor(EventProcessor, createCallResponse.Value.CallConnectionId, request.OperationContext);

                return Response.FromValue(result,
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Create an outgoing group call to target identities.
        /// </summary>
        /// <param name="options">Options for the CreateCall request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> CallbackUri is not formatted correctly. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual async Task<Response<CreateCallResult>> CreateGroupCallAsync(CreateGroupCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                if (options == null)
                {
                    throw new ArgumentNullException(nameof(options));
                }

                CreateCallRequestInternal request = CreateCallRequest(options);

                var createCallResponse = await AzureCommunicationServicesRestClient.CreateCallAsync(request, cancellationToken).ConfigureAwait(false);

                var result = new CreateCallResult(
                    GetCallConnection(createCallResponse.Value.CallConnectionId),
                    new CallConnectionProperties(createCallResponse.Value));
                result.SetEventProcessor(EventProcessor, createCallResponse.Value.CallConnectionId, request.OperationContext);

                return Response.FromValue(result,
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Create an outgoing group call to target identities.
        /// </summary>
        /// <param name="options">Options for the CreateCall request.</param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> CallbackUri is not formatted correctly. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual Response<CreateCallResult> CreateGroupCall(CreateGroupCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                if (options == null)
                {
                    throw new ArgumentNullException(nameof(options));
                }

                CreateCallRequestInternal request = CreateCallRequest(options);

                var createCallResponse = AzureCommunicationServicesRestClient.CreateCall(request, cancellationToken);

                var result = new CreateCallResult(
                    GetCallConnection(createCallResponse.Value.CallConnectionId),
                    new CallConnectionProperties(createCallResponse.Value));
                result.SetEventProcessor(EventProcessor, createCallResponse.Value.CallConnectionId, request.OperationContext);

                return Response.FromValue(result,
                    createCallResponse.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Create a connect request.
        /// </summary>
        /// <param name="callLocator"></param>
        /// <param name="callbackUri"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"><paramref name="callLocator"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="callbackUri"/> callbackUrl is not formatted correctly or empty. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual async Task<Response<ConnectCallResult>> ConnectCallAsync(CallLocator callLocator, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            ConnectCallOptions options = new ConnectCallOptions(callLocator, callbackUri);

            return await ConnectCallAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a connect request.
        /// </summary>
        /// <param name="connectCallOptions">ConnectOptions for connect request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectCallOptions"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectCallOptions"/> CallbackUrl is not formatted correctly. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual async Task<Response<ConnectCallResult>> ConnectCallAsync(ConnectCallOptions connectCallOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(ConnectCall)}");
            scope.Start();
            try
            {
                if (connectCallOptions == null)
                    throw new ArgumentNullException(nameof(connectCallOptions));

                ConnectRequestInternal connectRequest = ConnectRequest(connectCallOptions);
                Response<CallConnectionPropertiesInternal> response = await AzureCommunicationServicesRestClient.ConnectAsync(connectRequest).ConfigureAwait(false);

                var callConnection = GetCallConnection(response.Value.CallConnectionId);
                ConnectCallResult connectResult = new ConnectCallResult(new CallConnectionProperties(response.Value), callConnection);
                connectResult.SetEventProcessor(EventProcessor, response.Value.CallConnectionId);

                return Response.FromValue(connectResult, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Create a connect request.
        /// </summary>
        /// <param name="callLocator"></param>
        /// <param name="callbackUri"></param>
        /// <param name="cancellationToken"></param>
        /// <exception cref="ArgumentNullException"><paramref name="callLocator"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="callbackUri"/> callbackUrl is not formatted correctly or empty. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual Response<ConnectCallResult> ConnectCall(CallLocator callLocator, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            ConnectCallOptions options = new ConnectCallOptions(callLocator, callbackUri);

            return ConnectCall(options, cancellationToken);
        }

        /// <summary>
        /// Create a connect request.
        /// </summary>
        /// <param name="connectCallOptions">ConnectOptions for connect request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connectCallOptions"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="connectCallOptions"/> CallbackUrl is not formatted correctly. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual Response<ConnectCallResult> ConnectCall(ConnectCallOptions connectCallOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(ConnectCall)}");
            scope.Start();
            try
            {
                if (connectCallOptions == null)
                    throw new ArgumentNullException(nameof(connectCallOptions));

                ConnectRequestInternal connectRequest = ConnectRequest(connectCallOptions);
                Response<CallConnectionPropertiesInternal> response = AzureCommunicationServicesRestClient.Connect(connectRequest);

                var callConnection = GetCallConnection(response.Value.CallConnectionId);
                ConnectCallResult connectResult = new ConnectCallResult(new CallConnectionProperties(response.Value), callConnection);
                connectResult.SetEventProcessor(EventProcessor, response.Value.CallConnectionId);

                return Response.FromValue(connectResult, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
        private CreateCallRequestInternal CreateCallRequest(CreateCallOptions options)
        {
            CreateCallRequestInternal request = new(
                targets: new List<CommunicationIdentifierModel>() { { CommunicationIdentifierSerializer.Serialize(options.CallInvite.Target) } },
                callbackUri: options.CallbackUri.AbsoluteUri)
            {
                SourceCallerIdNumber = options?.CallInvite?.SourceCallerIdNumber == null
                    ? null
                    : new PhoneNumberIdentifierModel(options?.CallInvite?.SourceCallerIdNumber?.PhoneNumber),
                SourceDisplayName = options?.CallInvite?.SourceDisplayName,
                Source = Source == null ? null : new CommunicationUserIdentifierModel(Source.Id),
                TeamsAppSource = options.TeamsAppSource == null ? null : new MicrosoftTeamsAppIdentifierModel(options.TeamsAppSource.AppId),
            };

            request.CustomCallingContext = new CustomCallingContextInternal(
               options.CallInvite.CustomCallingContext.SipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.CallInvite.CustomCallingContext.SipHeaders,
               options.CallInvite.CustomCallingContext.VoipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.CallInvite.CustomCallingContext.VoipHeaders);

            // Add CallIntelligenceOptions such as custom cognitive service domain name
            string cognitiveServicesEndpoint = options.CallIntelligenceOptions?.CognitiveServicesEndpoint?.AbsoluteUri;
            if (cognitiveServicesEndpoint != null)
            {
                request.CallIntelligenceOptions = new()
                {
                    CognitiveServicesEndpoint = cognitiveServicesEndpoint
                };
            }

            request.OperationContext = options.OperationContext;
            request.MediaStreamingOptions = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);
            request.TranscriptionOptions = CreateTranscriptionOptionsInternal(options.TranscriptionOptions);

            return request;
        }

        private CreateCallRequestInternal CreateCallRequest(CreateGroupCallOptions options)
        {
            CreateCallRequestInternal request = new(
                targets: options.Targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                callbackUri: options.CallbackUri.AbsoluteUri)
            {
                SourceCallerIdNumber = options?.SourceCallerIdNumber == null
                    ? null
                    : new PhoneNumberIdentifierModel(options?.SourceCallerIdNumber?.PhoneNumber),
                SourceDisplayName = options?.SourceDisplayName,
                Source = Source == null ? null : new CommunicationUserIdentifierModel(Source.Id),
                TeamsAppSource = options.TeamsAppSource == null ? null : new MicrosoftTeamsAppIdentifierModel(options.TeamsAppSource.AppId)
            };

            request.CustomCallingContext = new CustomCallingContextInternal(
               options.CustomCallingContext.SipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.CustomCallingContext.SipHeaders,
               options.CustomCallingContext.VoipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.CustomCallingContext.VoipHeaders);

            // Add CallIntelligenceOptions such as custom cognitive service domain name
            string cognitiveServicesEndpoint = options.CallIntelligenceOptions?.CognitiveServicesEndpoint?.AbsoluteUri;
            if (cognitiveServicesEndpoint != null)
            {
                request.CallIntelligenceOptions = new()
                {
                    CognitiveServicesEndpoint = cognitiveServicesEndpoint
                };
            }

            request.OperationContext = options.OperationContext;
            request.MediaStreamingOptions = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);
            request.TranscriptionOptions = CreateTranscriptionOptionsInternal(options.TranscriptionOptions);

            return request;
        }

        private ConnectRequestInternal ConnectRequest(ConnectCallOptions options)
        {
            CallLocatorInternal callLocatorInternal = CallLocatorSerializer.Serialize(options.CallLocator);
            ConnectRequestInternal connectRequest = new ConnectRequestInternal(callLocatorInternal, options.CallbackUri?.AbsoluteUri);
            connectRequest.OperationContext = options.OperationContext;
            connectRequest.MediaStreamingOptions = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);
            connectRequest.TranscriptionOptions = CreateTranscriptionOptionsInternal(options.TranscriptionOptions);

            if (options.CallIntelligenceOptions != null && options.CallIntelligenceOptions.CognitiveServicesEndpoint != null)
            {
                CallIntelligenceOptionsInternal callIntelligenceOptionsInternal = new CallIntelligenceOptionsInternal
                {
                    CognitiveServicesEndpoint = options.CallIntelligenceOptions?.CognitiveServicesEndpoint?.AbsoluteUri
                };
                connectRequest.CallIntelligenceOptions = callIntelligenceOptionsInternal;
            }

            return connectRequest;
        }

        /// <summary>
        /// Validates an Https Uri.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static bool IsValidHttpsUri(Uri uri)
        {
            if (uri == null)
                return false;
            var uriString = uri.AbsoluteUri;
            return Uri.IsWellFormedUriString(uriString, UriKind.Absolute) && new Uri(uriString).Scheme == Uri.UriSchemeHttps;
        }

        private static MediaStreamingOptionsInternal CreateMediaStreamingOptionsInternal(MediaStreamingOptions configuration)
        {
            return configuration == default
                ? default
                : new MediaStreamingOptionsInternal(configuration.TransportUri.AbsoluteUri, configuration.MediaStreamingTransport,
                configuration.MediaStreamingContent, configuration.MediaStreamingAudioChannel, configuration.StartMediaStreaming,
                configuration.EnableBidirectional, configuration.AudioFormat);
        }
        private static TranscriptionOptionsInternal CreateTranscriptionOptionsInternal(TranscriptionOptions configuration)
        {
            return configuration == default
                ? default
                : new TranscriptionOptionsInternal(configuration.TransportUrl.AbsoluteUri, configuration.TranscriptionTransport, configuration.Locale,
                configuration.StartTranscription.GetValueOrDefault())
                {
                    EnableIntermediateResults = configuration.EnableIntermediateResults,
                    SpeechRecognitionModelEndpointId = configuration.SpeechRecognitionModelEndpointId
                };
        }

        /// <summary> Initializes a new instance of CallConnection. <see cref="CallConnection"/>.</summary>
        /// <param name="callConnectionId"> The call connection id for the GetCallConnection instance. </param>
        public virtual CallConnection GetCallConnection(string callConnectionId)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(GetCallConnection)}");
            scope.Start();
            try
            {
                return new CallConnection(callConnectionId, CallConnectionRestClient, CallMediaRestClient, CallDialogRestClient, _clientDiagnostics, EventProcessor);
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
                return new CallRecording(_resourceEndpoint, CallRecordingRestClient, _clientDiagnostics, _pipeline);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>Get Call Automation's EventProcessor for handling Call Automation's event more easily.</summary>
        public virtual CallAutomationEventProcessor GetEventProcessor()
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(GetEventProcessor)}");
            scope.Start();
            try
            {
                return EventProcessor;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
