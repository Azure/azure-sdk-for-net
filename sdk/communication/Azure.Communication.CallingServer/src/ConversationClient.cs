// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services Conversation Client.
    /// </summary>
    public class ConversationClient
    {
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly HttpPipeline _pipeline;
        internal readonly string _resourceEndpoint;
        private readonly ContentDownloader _contentDownloader;

        internal ConversationRestClient RestClient { get; }

        #region public constructors - all arguments need null check

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public ConversationClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new CallClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(string connectionString, CallClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new CallClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(Uri endpoint, AzureKeyCredential keyCredential, CallClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new CallClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(Uri endpoint, TokenCredential tokenCredential, CallClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new CallClientOptions())
        { }

        #endregion

        #region private constructors

        private ConversationClient(ConnectionString connectionString, CallClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private ConversationClient(string endpoint, TokenCredential tokenCredential, CallClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private ConversationClient(string endpoint, AzureKeyCredential keyCredential, CallClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private ConversationClient(string endpoint, HttpPipeline httpPipeline, CallClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = httpPipeline;
            _resourceEndpoint = endpoint;
            _contentDownloader = new(this);
            RestClient = new ConversationRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="ConversationClient"/> for mocking.</summary>
        protected ConversationClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            _resourceEndpoint = null;
            _contentDownloader = new(this);
            RestClient = null;
        }

        /// Join the call using conversation id.
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="source"> The source identity. </param>
        /// <param name="callOptions"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="conversationId"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callOptions"/> is null.</exception>
        public virtual async Task<Response<JoinCallResponse>> JoinCallAsync(string conversationId, CommunicationIdentifier source, JoinCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(JoinCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                return await RestClient.JoinCallAsync(
                    conversationId: conversationId,
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    callbackUri: callOptions.CallbackUri?.AbsoluteUri,
                    requestedModalities: callOptions.RequestedModalities,
                    requestedCallEvents: callOptions.RequestedCallEvents,
                    subject: null,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// Join the call using conversation id.
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="source"> The source identity. </param>
        /// <param name="callOptions"> The call Options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="conversationId"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="callOptions"/> is null.</exception>
        public virtual Response<JoinCallResponse> JoinCall(string conversationId, CommunicationIdentifier source, JoinCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(JoinCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(source, nameof(source));
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                return RestClient.JoinCall(
                    conversationId: conversationId,
                    source: CommunicationIdentifierSerializer.Serialize(source),
                    callbackUri: callOptions.CallbackUri?.AbsoluteUri,
                    requestedModalities: callOptions.RequestedModalities,
                    requestedCallEvents: callOptions.RequestedCallEvents,
                    subject: null,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Play audio in the call. </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="audioFileUri"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(string conversationId, Uri audioFileUri, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
            => await PlayAudioAsync(
                conversationId: conversationId,
                options: new PlayAudioOptions
                {
                    AudioFileUri = audioFileUri,
                    AudioFileId = audioFileId,
                    CallbackUri = callbackUri,
                    OperationContext = operationContext
                },
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);

        /// <summary> Play audio in the call. </summary>
        /// <param name="conversationId"> The call leg id. </param>
        /// <param name="options"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(string conversationId, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(options, nameof(options));

                // Currently looping media is not supported for out-call scenarios, thus setting it to false.
                return await RestClient.PlayAudioAsync(
                    conversationId: conversationId,
                    audioFileUri: options.AudioFileUri?.AbsoluteUri,
                    loop: false,
                    audioFileId: options.AudioFileId,
                    callbackUri: options.CallbackUri?.AbsoluteUri,
                    operationContext: options.OperationContext,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Play audio in the call. </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<PlayAudioResponse> PlayAudio(string conversationId, Uri audioFileUri, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
            => PlayAudio(
                conversationId: conversationId,
                options: new PlayAudioOptions
                {
                    AudioFileUri = audioFileUri,
                    AudioFileId = audioFileId,
                    CallbackUri = callbackUri,
                    OperationContext = operationContext
                },
                cancellationToken: cancellationToken
                );

        /// <summary> Play audio in the call. </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="options"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<PlayAudioResponse> PlayAudio(string conversationId, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(options, nameof(options));

                // Currently looping media is not supported for out-call scenarios, thus setting it to false.
                return RestClient.PlayAudio(
                    conversationId: conversationId,
                    audioFileUri: options.AudioFileUri?.AbsoluteUri,
                    loop: false,
                    audioFileId: options.AudioFileId,
                    callbackUri: options.CallbackUri?.AbsoluteUri,
                    operationContext: options.OperationContext,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Add participant to the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="callbackUri">The callback uri to receive the notification.</param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response AddParticipant(string conversationId, CommunicationIdentifier participant, Uri callbackUri, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var participantsInternal = new List<CommunicationIdentifierModel> { CommunicationIdentifierSerializer.Serialize(participant) };
                var alternateCallerIdInternal = string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId);
                return RestClient.InviteParticipants(
                    conversationId: conversationId,
                    participants: participantsInternal,
                    alternateCallerId: alternateCallerIdInternal,
                    callbackUri: callbackUri?.AbsoluteUri,
                    operationContext: operationContext,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Add participant to the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="callbackUri"></param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> AddParticipantAsync(string conversationId, CommunicationIdentifier participant, Uri callbackUri, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var participantsInternal = new List<CommunicationIdentifierModel> { CommunicationIdentifierSerializer.Serialize(participant) };
                var alternateCallerIdInternal = string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId);
                return await RestClient.InviteParticipantsAsync(
                    conversationId: conversationId,
                    participants: participantsInternal,
                    alternateCallerId: alternateCallerIdInternal,
                    callbackUri: callbackUri?.AbsoluteUri,
                    operationContext: operationContext,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Remove participant from the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="participantId">The participant id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response RemoveParticipant(string conversationId, string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                return RestClient.RemoveParticipant(
                    conversationId: conversationId,
                    participantId: participantId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Remove participant from the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="participantId">The participant id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> RemoveParticipantAsync(string conversationId, string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                return await RestClient.RemoveParticipantAsync(
                    conversationId: conversationId,
                    participantId: participantId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Start recording of the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingStateCallbackUri">The uri to send state change callbacks.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<StartCallRecordingResponse>> StartRecordingAsync(string conversationId, Uri recordingStateCallbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StartRecording)}");
            scope.Start();
            try
            {
                return await RestClient.StartRecordingAsync(
                    conversationId: conversationId,
                    recordingStateCallbackUri: recordingStateCallbackUri.AbsoluteUri,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Start recording of the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingStateCallbackUri">The uri to send state change callbacks.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response<StartCallRecordingResponse> StartRecording(string conversationId, Uri recordingStateCallbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StartRecording)}");
            scope.Start();
            try
            {
                return RestClient.StartRecording(
                    conversationId: conversationId,
                    recordingStateCallbackUri: recordingStateCallbackUri.AbsoluteUri,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get the current recording state by recording id.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<GetCallRecordingStateResponse>> GetRecordingStateAsync(string conversationId, string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(GetRecordingState)}");
            scope.Start();
            try
            {
                return await RestClient.RecordingStateAsync(
                    conversationId: conversationId,
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get the current recording state by recording id.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response<GetCallRecordingStateResponse> GetRecordingState(string conversationId, string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(GetRecordingState)}");
            scope.Start();
            try
            {
                return RestClient.RecordingState(
                    conversationId: conversationId,
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stop recording of the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingId">The recording id to stop.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> StopRecordingAsync(string conversationId, string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StopRecording)}");
            scope.Start();
            try
            {
                return await RestClient.StopRecordingAsync(
                    conversationId: conversationId,
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Stop recording of the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingId">The recording id to stop.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response StopRecording(string conversationId, string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StopRecording)}");
            scope.Start();
            try
            {
                return RestClient.StopRecording(
                    conversationId: conversationId,
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Pause recording of the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> PauseRecordingAsync(string conversationId, string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PauseRecording)}");
            scope.Start();
            try
            {
                return await RestClient.PauseRecordingAsync(
                    conversationId: conversationId,
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Pause recording of the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response PauseRecording(string conversationId, string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PauseRecording)}");
            scope.Start();
            try
            {
                return RestClient.PauseRecording(
                    conversationId: conversationId,
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resume recording of the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> ResumeRecordingAsync(string conversationId, string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(ResumeRecording)}");
            scope.Start();
            try
            {
                return await RestClient.ResumeRecordingAsync(
                    conversationId: conversationId,
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// resume recording of the call.
        /// </summary>
        /// <param name="conversationId"> The conversation id that can be a group id or a encoded conversation url retrieve from client. </param>
        /// <param name="recordingId">The recording id to resume.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response ResumeRecording(string conversationId, string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(ResumeRecording)}");
            scope.Start();
            try
            {
                return RestClient.ResumeRecording(
                    conversationId: conversationId,
                    recordingId: recordingId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// The <see cref="DownloadStreamingAsync(Uri, HttpRange, CancellationToken)"/>
        /// operation downloads the recording's content.
        ///
        /// </summary>
        /// <param name="sourceEndpoint">
        /// Recording's content's url location.
        /// </param>
        /// <param name="range">
        /// If provided, only download the bytes of the content in the specified range.
        /// If not provided, download the entire content.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Stream}"/> containing the
        /// downloaded content.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response<Stream>> DownloadStreamingAsync(
            Uri sourceEndpoint,
            HttpRange range = default,
            CancellationToken cancellationToken = default) =>
            await _contentDownloader.DownloadStreamingInternal(
                sourceEndpoint,
                range,
                async: true,
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadStreaming(Uri, HttpRange, CancellationToken)"/>
        /// operation downloads the recording's content.
        ///
        /// </summary>
        /// <param name="sourceEndpoint">
        /// Recording's content's url location.
        /// </param>
        /// <param name="range">
        /// If provided, only download the bytes of the content in the specified range.
        /// If not provided, download the entire content.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response{Stream}"/> containing the
        /// downloaded content.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response<Stream> DownloadStreaming(
            Uri sourceEndpoint,
            HttpRange range = default,
            CancellationToken cancellationToken = default) =>
            _contentDownloader.DownloadStreamingInternal(
                sourceEndpoint,
                range,
                async: false,
                cancellationToken)
            .EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadTo(Uri, Stream, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationStream">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(Uri sourceEndpoint, Stream destinationStream,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default) =>
            _contentDownloader.StagedDownloadAsync(sourceEndpoint, destinationStream, transferOptions, async: false, cancellationToken: cancellationToken).EnsureCompleted();

        /// <summary>
        /// The <see cref="DownloadToAsync(Uri, Stream, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationStream"/>.
        /// </summary>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationStream">
        /// A <see cref="Stream"/> to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(Uri sourceEndpoint, Stream destinationStream, ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default) =>
            await _contentDownloader.StagedDownloadAsync(sourceEndpoint, destinationStream, transferOptions, async: true, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// The <see cref="DownloadTo(Uri, string, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual Response DownloadTo(Uri sourceEndpoint, string destinationPath,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(destinationPath);
            return _contentDownloader.StagedDownloadAsync(sourceEndpoint, destination, transferOptions,
                async: false, cancellationToken: cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// The <see cref="DownloadToAsync(Uri, string, ContentTransferOptions, CancellationToken)"/>
        /// operation downloads the specified content using parallel requests,
        /// and writes the content to <paramref name="destinationPath"/>.
        /// </summary>
        /// <param name="sourceEndpoint">
        /// A <see cref="Uri"/> with the Recording's content's url location.
        /// </param>
        /// <param name="destinationPath">
        /// A file path to write the downloaded content to.
        /// </param>
        /// <param name="transferOptions">
        /// Optional <see cref="ContentTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate
        /// notifications that the operation should be cancelled.
        /// </param>
        /// <returns>
        /// A <see cref="Response"/> describing the operation.
        /// </returns>
        /// <remarks>
        /// A <see cref="RequestFailedException"/> will be thrown if
        /// a failure occurs.
        /// </remarks>
        public virtual async Task<Response> DownloadToAsync(Uri sourceEndpoint, string destinationPath,
            ContentTransferOptions transferOptions = default, CancellationToken cancellationToken = default)
        {
            using Stream destination = File.Create(destinationPath);
            return await _contentDownloader.StagedDownloadAsync(sourceEndpoint, destination, transferOptions,
                async: true, cancellationToken: cancellationToken).ConfigureAwait(false);
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
