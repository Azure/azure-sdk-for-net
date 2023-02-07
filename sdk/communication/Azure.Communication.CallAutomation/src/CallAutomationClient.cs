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
        internal EventProcessor EventProcessor { get; }
        internal CommunicationUserIdentifier Source { get; }

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
            : this(new Uri(connectionString.GetRequired("endpoint")), options.BuildHttpPipeline(connectionString), options)
        { }

        private CallAutomationClient(string endpoint, TokenCredential tokenCredential, CallAutomationClientOptions options)
            : this(new Uri(endpoint), options.BuildHttpPipeline(tokenCredential), options)
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
            EventProcessor = new EventProcessor(options.EventProcessorOptions);
            Source = options.Source;
        }

        private CallAutomationClient(Uri endpoint, CallAutomationClientOptions options, ConnectionString connectionString)
        : this(
        endpoint: endpoint,
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
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
        /// <returns></returns>
        public virtual async Task<Response<AnswerCallResult>> AnswerCallAsync(AnswerCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                if (options == null) throw new ArgumentNullException(nameof(options));

                AnswerCallRequestInternal request = CreateAnswerCallRequest(options);
                var repeatabilityHeaders = new RepeatabilityHeaders();

                var answerResponse = await AzureCommunicationServicesRestClient.AnswerCallAsync(request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken)
                    .ConfigureAwait(false);

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
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
        /// <returns></returns>
        public virtual Response<AnswerCallResult> AnswerCall(AnswerCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(AnswerCall)}");
            scope.Start();
            try
            {
                if (options == null) throw new ArgumentNullException(nameof(options));

                AnswerCallRequestInternal request = CreateAnswerCallRequest(options);
                var repeatabilityHeaders = new RepeatabilityHeaders();

                var answerResponse = AzureCommunicationServicesRestClient.AnswerCall(request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken);

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

        private static AnswerCallRequestInternal CreateAnswerCallRequest(AnswerCallOptions options)
        {
            // validate callbackUri
            if (!IsValidHttpsUri(options.CallbackUri))
            {
                throw new ArgumentException(CallAutomationErrorMessages.InvalidHttpsUriMessage);
            }

            AnswerCallRequestInternal request = new AnswerCallRequestInternal(options.IncomingCallContext, options.CallbackUri.AbsoluteUri);
            // Add custom cognitive service domain name
            if (options.AzureCognitiveServicesEndpointUrl != null)
            {
                if (!IsValidHttpsUri(options.AzureCognitiveServicesEndpointUrl))
                {
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidCognitiveServiceHttpsUriMessage);
                }
                request.AzureCognitiveServicesEndpointUrl = options.AzureCognitiveServicesEndpointUrl.AbsoluteUri;
            }
            request.MediaStreamingConfiguration = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);

            return request;
        }

        /// Redirect an incoming call to the target identity.
        /// <param name="incomingCallContext"> The incoming call context </param>
        /// <param name="target"> The target identity. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="incomingCallContext"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is null.</exception>
        public virtual async Task<Response> RedirectCallAsync(string incomingCallContext, CommunicationIdentifier target, CancellationToken cancellationToken = default)
        {
            RedirectCallOptions options = new RedirectCallOptions(incomingCallContext, target);

            return await RedirectCallAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// Redirect an incoming call to the target identity.
        /// <param name="options">Options for the Redirect operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
        public virtual async Task<Response> RedirectCallAsync(RedirectCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RedirectCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                RedirectCallRequestInternal request = new RedirectCallRequestInternal(options.IncomingCallContext, CommunicationIdentifierSerializer.Serialize(options.Target));
                var repeatabilityHeaders = new RepeatabilityHeaders();

                return await AzureCommunicationServicesRestClient.RedirectCallAsync(
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken
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
            RedirectCallOptions options = new RedirectCallOptions(incomingCallContext, target);

            return RedirectCall(options, cancellationToken);
        }

        /// Redirect an incoming call to the target identity.
        /// <param name="options">Options for the Redirect operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
        public virtual Response RedirectCall(RedirectCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(RedirectCall)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                RedirectCallRequestInternal request = new RedirectCallRequestInternal(options.IncomingCallContext, CommunicationIdentifierSerializer.Serialize(options.Target));
                var repeatabilityHeaders = new RepeatabilityHeaders();

                return AzureCommunicationServicesRestClient.RedirectCall(
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken);
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
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
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
                var repeatabilityHeaders = new RepeatabilityHeaders();

                return await AzureCommunicationServicesRestClient.RejectCallAsync(
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken
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
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
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
                var repeatabilityHeaders = new RepeatabilityHeaders();

                return AzureCommunicationServicesRestClient.RejectCall(
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    );
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
        /// <returns></returns>
        public virtual async Task<Response<CreateCallResult>> CreateCallAsync(CallInvite callInvite, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                if (callInvite == null)
                {
                    throw new ArgumentNullException(nameof(callInvite));
                }

                if (callbackUri == null)
                {
                    throw new ArgumentNullException(nameof(callbackUri));
                }

                var createCallOptions = new CreateCallOptions(callInvite, callbackUri);

                CreateCallRequestInternal request = CreateCallRequest(createCallOptions);
                createCallOptions.RepeatabilityHeaders?.GenerateIfRepeatabilityHeadersNotProvided();

                var createCallResponse = await AzureCommunicationServicesRestClient.CreateCallAsync(
                    request,
                    createCallOptions.RepeatabilityHeaders?.RepeatabilityRequestId,
                    createCallOptions.RepeatabilityHeaders?.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    ).ConfigureAwait(false);

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
        /// <param name="options">Options for the CreateCall request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> CallbackUri is not formatted correctly. </exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
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
                var repeatabilityHeaders = new RepeatabilityHeaders();

                var createCallResponse = await AzureCommunicationServicesRestClient.CreateCallAsync(
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    ).ConfigureAwait(false);

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
        /// <returns></returns>
        public virtual Response<CreateCallResult> CreateCall(CallInvite callInvite, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                if (callInvite == null)
                {
                    throw new ArgumentNullException(nameof(callInvite));
                }

                if (callbackUri == null)
                {
                    throw new ArgumentNullException(nameof(callbackUri));
                }

                var createCallOptions = new CreateCallOptions(callInvite, callbackUri);

                CreateCallRequestInternal request = CreateCallRequest(createCallOptions);
                createCallOptions.RepeatabilityHeaders?.GenerateIfRepeatabilityHeadersNotProvided();

                var createCallResponse = AzureCommunicationServicesRestClient.CreateCall(
                    request,
                    createCallOptions.RepeatabilityHeaders?.RepeatabilityRequestId,
                    createCallOptions.RepeatabilityHeaders?.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    );

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
        /// <param name="options">Options for the CreateCall request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> CallbackUri is not formatted correctly. </exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
        /// <returns></returns>

        public virtual Response<CreateCallResult> CreateCall(CreateCallOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(CreateCall)}");
            scope.Start();
            try
            {
                if (options == null) throw new ArgumentNullException(nameof(options));

                CreateCallRequestInternal request = CreateCallRequest(options);
                var repeatabilityHeaders = new RepeatabilityHeaders();

                var createCallResponse = AzureCommunicationServicesRestClient.CreateCall(
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    );

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
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
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
                options.RepeatabilityHeaders?.GenerateIfRepeatabilityHeadersNotProvided();

                var createCallResponse = await AzureCommunicationServicesRestClient.CreateCallAsync(
                    request,
                    options.RepeatabilityHeaders?.RepeatabilityRequestId,
                    options.RepeatabilityHeaders?.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    ).ConfigureAwait(false);

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
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
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
                options.RepeatabilityHeaders?.GenerateIfRepeatabilityHeadersNotProvided();

                var createCallResponse = AzureCommunicationServicesRestClient.CreateCall(
                    request,
                    options.RepeatabilityHeaders?.RepeatabilityRequestId,
                    options.RepeatabilityHeaders?.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    );

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

        private CreateCallRequestInternal CreateCallRequest(CreateCallOptions options)
        {
            CallSourceInternal sourceDto = new(CommunicationIdentifierSerializer.Serialize(Source))
            {
                CallerId = options?.CallInvite?.SourceCallerIdNumber == null
                    ? null
                    : new PhoneNumberIdentifierModel(options?.CallInvite?.SourceCallerIdNumber?.PhoneNumber),
                DisplayName = options.CallInvite.SourceDisplayName,
            };

            CreateCallRequestInternal request = new(
                new List<CommunicationIdentifierModel>() { { CommunicationIdentifierSerializer.Serialize(options.CallInvite.Target) } },
                sourceDto,
                options.CallbackUri.AbsoluteUri);
            // Add custom cognitive service domain name
            if (options.AzureCognitiveServicesEndpointUrl != null)
            {
                if (!IsValidHttpsUri(options.AzureCognitiveServicesEndpointUrl))
                {
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidCognitiveServiceHttpsUriMessage);
                }
                request.AzureCognitiveServicesEndpointUrl = options.AzureCognitiveServicesEndpointUrl.AbsoluteUri;
            }
            request.OperationContext = options.OperationContext;
            request.MediaStreamingConfiguration = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);

            return request;
        }

        private CreateCallRequestInternal CreateCallRequest(CreateGroupCallOptions options)
        {
            CallSourceInternal sourceDto = new(CommunicationIdentifierSerializer.Serialize(Source))
            {
                CallerId = options?.SourceCallerIdNumber == null ? null : new PhoneNumberIdentifierModel(options?.SourceCallerIdNumber?.PhoneNumber),
                DisplayName = options.SourceDisplayName,
            };

            CreateCallRequestInternal request = new(
                options.Targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                sourceDto,
                options.CallbackUri.AbsoluteUri);
            // Add custom cognitive service domain name
            if (options.AzureCognitiveServicesEndpointUrl != null)
            {
                if (!IsValidHttpsUri(options.AzureCognitiveServicesEndpointUrl))
                {
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidCognitiveServiceHttpsUriMessage);
                }
                request.AzureCognitiveServicesEndpointUrl = options.AzureCognitiveServicesEndpointUrl.AbsoluteUri;
            }
            request.OperationContext = options.OperationContext;
            request.MediaStreamingConfiguration = CreateMediaStreamingOptionsInternal(options.MediaStreamingOptions);

            return request;
        }

        /// <summary>
        /// Validates an Https Uri.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static bool IsValidHttpsUri(Uri uri) {
            if (uri == null)
                return false;
            var uriString = uri.AbsoluteUri;
            return Uri.IsWellFormedUriString(uriString, UriKind.Absolute) && new Uri(uriString).Scheme == Uri.UriSchemeHttps;
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
                return new CallConnection(callConnectionId, CallConnectionRestClient, CallMediaRestClient, _clientDiagnostics, EventProcessor);
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

        /// <summary>Get CallAtumation's EventProcessor for handling Call Automation's event more easily.</summary>
        public virtual EventProcessor GetEventProcessor()
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

        /// <summary>
        /// Get source identity used by Call Automation client.
        /// </summary>
        /// <returns></returns>
        public virtual CommunicationUserIdentifier GetSourceIdentity()
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(GetSourceIdentity)}");
            scope.Start();
            try
            {
                return Source;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
