// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;
using System.Collections.Generic;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The Azure Communication Services Conversation Client.
    /// </summary>
    public class ConversationClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ConversationRestClient RestClient { get; }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(Uri endpoint, AzureKeyCredential keyCredential, CallClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)),
                options ?? new CallClientOptions(),
                AssertNotNull(keyCredential, nameof(keyCredential)))
        { }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(string connectionString, CallClientOptions options = default)
            : this(
                  options ?? new CallClientOptions(),
                  ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))))
        { }

        /// <summary> Initializes a new instance of <see cref="ConversationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ConversationClient(Uri endpoint, TokenCredential tokenCredential, CallClientOptions options = default)
            : this(
                  endpoint,
                  options ?? new CallClientOptions(),
                  tokenCredential)
        { }

        /// <summary>Initializes a new instance of <see cref="ConversationClient"/> for mocking.</summary>
        protected ConversationClient()
        {
            _clientDiagnostics = null!;
            RestClient = null!;
        }

        private ConversationClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpointUrl)
        {
            RestClient = new ConversationRestClient(clientDiagnostics, pipeline, endpointUrl);
            _clientDiagnostics = clientDiagnostics;
        }

        private ConversationClient(CallClientOptions options, ConnectionString connectionString)
            : this(
                  clientDiagnostics: new ClientDiagnostics(options),
                  pipeline: options.BuildHttpPipeline(connectionString),
                  endpointUrl: connectionString.GetRequired("endpoint"))
        { }

        private ConversationClient(Uri endpoint, CallClientOptions options, TokenCredential tokenCredential)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(tokenCredential, nameof(tokenCredential));

            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new ConversationRestClient(
                _clientDiagnostics,
                options.BuildHttpPipeline(tokenCredential),
                endpoint.AbsoluteUri);
        }

        private ConversationClient(Uri endpoint, CallClientOptions options, AzureKeyCredential credential)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new ConversationRestClient(
                _clientDiagnostics,
                options.BuildHttpPipeline(credential),
                endpoint.AbsoluteUri);
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
        public virtual async Task<Response<JoinCallResponse>> JoinCallAsync(string conversationId, CommunicationIdentifier source, CreateCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(JoinCallAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                JoinCallRequestInternal request = new JoinCallRequestInternal(
                    CommunicationIdentifierSerializer.Serialize(source),
                    callOptions.CallbackUri.AbsoluteUri,
                    callOptions.RequestedModalities,
                    callOptions.RequestedCallEvents);

                return await RestClient.JoinCallAsync(
                    conversationId,
                    CommunicationIdentifierSerializer.Serialize(source),
                    callOptions.CallbackUri.AbsoluteUri,
                    callOptions.RequestedModalities,
                    callOptions.RequestedCallEvents,
                    null,
                    cancellationToken
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
        public virtual Response<JoinCallResponse> JoinCall(string conversationId, CommunicationIdentifier source, CreateCallOptions callOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallClient)}.{nameof(JoinCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(callOptions, nameof(callOptions));

                JoinCallRequestInternal request = new JoinCallRequestInternal(
                    CommunicationIdentifierSerializer.Serialize(source),
                    callOptions.CallbackUri.AbsoluteUri,
                    callOptions.RequestedModalities,
                    callOptions.RequestedCallEvents);

                return RestClient.JoinCall(
                    conversationId,
                    CommunicationIdentifierSerializer.Serialize(source),
                    callOptions.CallbackUri.AbsoluteUri,
                    callOptions.RequestedModalities,
                    callOptions.RequestedCallEvents,
                    null,
                    cancellationToken
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
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(string conversationId, Uri audioFileUri, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PlayAudioAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                // Currently looping media is not supported for out-call scenarios, thus setting it to false.
                return await RestClient.PlayAudioAsync(conversationId, audioFileUri.AbsoluteUri, false, operationContext, null, null, cancellationToken).ConfigureAwait(false);
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
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<PlayAudioResponse> PlayAudio(string conversationId, Uri audioFileUri, string operationContext, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                // Currently looping media is not supported for out-call scenarios, thus setting it to false.
                return RestClient.PlayAudio(conversationId, audioFileUri.AbsoluteUri, false, operationContext, null, null, cancellationToken);
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
        /// <param name="operationContext">The operation context.</param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response AddParticipant(string conversationId, CommunicationIdentifier participant, Uri callbackUri, string operationContext = null, string alternateCallerId = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var participantsInternal = new List<CommunicationIdentifierModel> { CommunicationIdentifierSerializer.Serialize(participant) };
                var alternateCallerIdInternal = string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId);
                return RestClient.InviteParticipants(conversationId, participantsInternal, alternateCallerIdInternal, operationContext, callbackUri?.AbsoluteUri, cancellationToken);
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
        /// <param name="operationContext">The operation context.</param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> AddParticipantAsync(string conversationId, CommunicationIdentifier participant, Uri callbackUri, string operationContext = null, string alternateCallerId = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(AddParticipantAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var participantsInternal = new List<CommunicationIdentifierModel> { CommunicationIdentifierSerializer.Serialize(participant) };
                var alternateCallerIdInternal = string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId);
                return await RestClient.InviteParticipantsAsync(conversationId, participantsInternal, alternateCallerIdInternal, operationContext, callbackUri?.AbsoluteUri, cancellationToken).ConfigureAwait(false);
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
                return RestClient.RemoveParticipant(conversationId, participantId, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(RemoveParticipantAsync)}");
            scope.Start();
            try
            {
                return await RestClient.RemoveParticipantAsync(conversationId, participantId, cancellationToken).ConfigureAwait(false);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StartRecordingAsync)}");
            scope.Start();
            try
            {
                return await RestClient.StartRecordingAsync(conversationId, recordingStateCallbackUri.AbsoluteUri, cancellationToken).ConfigureAwait(false);
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
                return RestClient.StartRecording(conversationId, recordingStateCallbackUri.AbsoluteUri, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(GetRecordingStateAsync)}");
            scope.Start();
            try
            {
                return await RestClient.RecordingStateAsync(conversationId, recordingId, cancellationToken).ConfigureAwait(false);
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
                return RestClient.RecordingState(conversationId, recordingId, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(StopRecordingAsync)}");
            scope.Start();
            try
            {
                return await RestClient.StopRecordingAsync(conversationId, recordingId, cancellationToken).ConfigureAwait(false);
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
                return RestClient.StopRecording(conversationId, recordingId, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(PauseRecordingAsync)}");
            scope.Start();
            try
            {
                return await RestClient.PauseRecordingAsync(conversationId, recordingId, cancellationToken).ConfigureAwait(false);
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
                return RestClient.PauseRecording(conversationId, recordingId, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ConversationClient)}.{nameof(ResumeRecordingAsync)}");
            scope.Start();
            try
            {
                return await RestClient.ResumeRecordingAsync(conversationId, recordingId, cancellationToken).ConfigureAwait(false);
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
                return RestClient.ResumeRecording(conversationId, recordingId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
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
