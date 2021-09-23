// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services Server Call Client.
    /// </summary>
    public class ServerCall
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ServerCallsRestClient RestClient { get; }

        /// <summary>
        /// The callLocator
        /// </summary>
        internal virtual CallLocatorModel CallLocator { get; set; }

        /// <summary>Initializes a new instance of <see cref="ServerCall"/>.</summary>
        internal ServerCall(CallLocatorModel callLocator, ServerCallsRestClient serverCallRestClient, ClientDiagnostics clientDiagnostics)
        {
            CallLocator = callLocator;
            RestClient = serverCallRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="ServerCall"/> for mocking.</summary>
        protected ServerCall()
        {
            CallLocator = null;
            _clientDiagnostics = null;
            RestClient = null;
        }

        /// <summary> Play audio in the call. </summary>
        /// <param name="audioFileUri">The media resource uri of the play audio request. Currently only Wave file (.wav) format audio prompts are supported. The audio content in the wave file must be mono (single-channel), 16-bit samples with a 16,000 (16KHz) sampling rate.</param>
        /// <param name="options"> Options for playing audio. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<PlayAudioResult>> PlayAudioAsync(Uri audioFileUri, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));
                var playAudioRequest = new PlayAudioRequest(loop: options?.Loop ?? false);

                playAudioRequest.AudioFileUri = audioFileUri.AbsoluteUri;
                playAudioRequest.AudioFileId = options?.AudioFileId;
                playAudioRequest.CallbackUri = options?.CallbackUri?.AbsoluteUri;
                playAudioRequest.OperationContext = options?.OperationContext;

                return await RestClient.PlayAudioAsync(
                    callLocator: CallLocator,
                    playAudioRequest: playAudioRequest,
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
        /// <param name="audioFileUri">The media resource uri of the play audio request. Currently only Wave file (.wav) format audio prompts are supported. The audio content in the wave file must be mono (single-channel), 16-bit samples with a 16,000 (16KHz) sampling rate.</param>
        /// <param name="options"> Options for playing audio. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<PlayAudioResult> PlayAudio(Uri audioFileUri, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                var playAudioRequest = new PlayAudioRequest(loop: options?.Loop ?? false);

                playAudioRequest.AudioFileUri = audioFileUri.AbsoluteUri;
                playAudioRequest.AudioFileId = options?.AudioFileId;
                playAudioRequest.CallbackUri = options?.CallbackUri?.AbsoluteUri;
                playAudioRequest.OperationContext = options?.OperationContext;

                return RestClient.PlayAudio(
                    callLocator: CallLocator,
                    playAudioRequest: playAudioRequest,
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
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="callbackUri">The callback uri to receive the notification.</param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response<AddParticipantResult> AddParticipant(CommunicationIdentifier participant, Uri callbackUri, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var addParticipantRequestInternal = new AddParticipantRequestInternal()
                {
                    Participant = CommunicationIdentifierSerializer.Serialize(participant),
                    CallbackUri = callbackUri?.AbsoluteUri,
                    AlternateCallerId = string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId),
                    OperationContext = operationContext
                };

                return RestClient.AddParticipant(
                    callLocator: CallLocator,
                    addParticipantRequest: addParticipantRequestInternal,
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
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="callbackUri"></param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<AddParticipantResult>> AddParticipantAsync(CommunicationIdentifier participant, Uri callbackUri, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var addParticipantRequestInternal = new AddParticipantRequestInternal()
                {
                    Participant = CommunicationIdentifierSerializer.Serialize(participant),
                    CallbackUri = callbackUri?.AbsoluteUri,
                    AlternateCallerId = string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId),
                    OperationContext = operationContext
                };

                return await RestClient.AddParticipantAsync(
                    callLocator: CallLocator,
                    addParticipantRequest: addParticipantRequestInternal,
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
        /// <param name="participant">The participant.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response RemoveParticipant(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var removeParticipantRequest = new RemoveParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(participant));

                return RestClient.RemoveParticipant(
                    callLocator: CallLocator,
                    removeParticipantRequest: removeParticipantRequest,
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
        /// <param name="participant">The participant.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> RemoveParticipantAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var removeParticipantRequest = new RemoveParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(participant));

                return await RestClient.RemoveParticipantAsync(
                    callLocator: CallLocator,
                    removeParticipantRequest: removeParticipantRequest,
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
        /// <param name="recordingStateCallbackUri">The uri to send state change callbacks.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<StartCallRecordingResult>> StartRecordingAsync(Uri recordingStateCallbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartRecording)}");
            scope.Start();
            try
            {
                var startCallRecordingRequest = new StartCallRecordingRequest()
                {
                    RecordingStateCallbackUri = recordingStateCallbackUri?.AbsoluteUri
                };

                return await RestClient.StartRecordingAsync(
                    callLocator: CallLocator,
                    startCallRecordingRequest: startCallRecordingRequest,
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
        /// <param name="recordingStateCallbackUri">The uri to send state change callbacks.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response<StartCallRecordingResult> StartRecording(Uri recordingStateCallbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartRecording)}");
            scope.Start();
            try
            {
                var startCallRecordingRequest = new StartCallRecordingRequest()
                {
                    RecordingStateCallbackUri = recordingStateCallbackUri?.AbsoluteUri
                };

                return RestClient.StartRecording(
                    callLocator: CallLocator,
                    startCallRecordingRequest: startCallRecordingRequest,
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
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<CallRecordingProperties>> GetRecordingStateAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetRecordingState)}");
            scope.Start();
            try
            {
                return await RestClient.GetRecordingPropertiesAsync(
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
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response<CallRecordingProperties> GetRecordingState(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetRecordingState)}");
            scope.Start();
            try
            {
                return RestClient.GetRecordingProperties(
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
        /// <param name="recordingId">The recording id to stop.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> StopRecordingAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StopRecording)}");
            scope.Start();
            try
            {
                return await RestClient.StopRecordingAsync(
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
        /// <param name="recordingId">The recording id to stop.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response StopRecording(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StopRecording)}");
            scope.Start();
            try
            {
                return RestClient.StopRecording(
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
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> PauseRecordingAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PauseRecording)}");
            scope.Start();
            try
            {
                return await RestClient.PauseRecordingAsync(
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
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response PauseRecording(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PauseRecording)}");
            scope.Start();
            try
            {
                return RestClient.PauseRecording(
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
        /// <param name="recordingId">The recording id to pause.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> ResumeRecordingAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(ResumeRecording)}");
            scope.Start();
            try
            {
                return await RestClient.ResumeRecordingAsync(
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
        /// <param name="recordingId">The recording id to resume.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response ResumeRecording(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(ResumeRecording)}");
            scope.Start();
            try
            {
                return RestClient.ResumeRecording(
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

        /// <summary> Get participants of the call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="IEnumerable{CallParticipant}"/>.</returns>
        public virtual async Task<Response<IEnumerable<CallParticipant>>> GetParticipantsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetParticipantsAsync)}");
            scope.Start();
            try
            {
                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = await RestClient.GetParticipantsAsync(
                                        callLocator: CallLocator,
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);

                return Response.FromValue(callParticipantsInternal.Value.Select(x => new CallParticipant(x)), callParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participants of the call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="IEnumerable{CallParticipant}"/>.</returns>
        public virtual Response<IEnumerable<CallParticipant>> GetParticipants(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = RestClient.GetParticipants(
                                        callLocator: CallLocator,
                                        cancellationToken: cancellationToken);

                return Response.FromValue(callParticipantsInternal.Value.Select(x => new CallParticipant(x)), callParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participant of the call using participant id. </summary>
        /// <param name="participant">The participant.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="IEnumerable{CallParticipant}"/>.</returns>
        public virtual async Task<Response<IEnumerable<CallParticipant>>> GetParticipantAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetParticipantAsync)}");
            scope.Start();
            try
            {
                var getParticipantRequestInternal = new GetParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(participant));

                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = await RestClient.GetParticipantAsync(
                                        callLocator: CallLocator,
                                        getParticipantRequest: getParticipantRequestInternal,
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);

                return Response.FromValue(callParticipantsInternal.Value.Select(c => new CallParticipant(c)), callParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participant from the call using <see cref="CommunicationIdentifier"/>. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="IEnumerable{CallParticipant}"/>.</returns>
        public virtual Response<IEnumerable<CallParticipant>> GetParticipant(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var getParticipantRequestInternal = new GetParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(participant));

                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = RestClient.GetParticipant(
                                        callLocator: CallLocator,
                                        getParticipantRequest: getParticipantRequestInternal,
                                        cancellationToken: cancellationToken);

                return Response.FromValue(callParticipantsInternal.Value.Select(c => new CallParticipant(c)), callParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Hold the participant and play default or custom audio. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="audioFileUri"> The uri of the audio file. If none is passed, default music will be played</param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. Needed only if audioFileUri is passed.</param>
        /// <param name="callbackUri">The callback Uri to receive StartHoldMusic status notifications.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<StartHoldMusicResult>> StartHoldMusicAsync(CommunicationIdentifier participant, Uri audioFileUri, string audioFileId, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartHoldMusicAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var startHoldMusicRequestInternal = new StartHoldMusicRequestInternal(CommunicationIdentifierSerializer.Serialize(participant));
                startHoldMusicRequestInternal.AudioFileUri= audioFileUri?.AbsoluteUri;
                startHoldMusicRequestInternal.AudioFileId = audioFileId;
                startHoldMusicRequestInternal.CallbackUri = callbackUri?.AbsoluteUri;

                return await RestClient.StartHoldMusicAsync(
                                        callLocator: CallLocator,
                                        startHoldMusicRequest: startHoldMusicRequestInternal,
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Hold the participant and play default or custom audio. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="audioFileUri"> The uri of the audio file. If none is passed, default music will be played</param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. Needed only if audioFileUri is passed.</param>
        /// <param name="callbackUri">The callback Uri to receive StartHoldMusic status notifications.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<StartHoldMusicResult> StartHoldMusic(CommunicationIdentifier participant, Uri audioFileUri, string audioFileId, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartHoldMusic)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var startHoldMusicRequestInternal = new StartHoldMusicRequestInternal(CommunicationIdentifierSerializer.Serialize(participant));
                startHoldMusicRequestInternal.AudioFileUri = audioFileUri?.AbsoluteUri;
                startHoldMusicRequestInternal.AudioFileId = audioFileId;
                startHoldMusicRequestInternal.CallbackUri = callbackUri?.AbsoluteUri;

                return RestClient.StartHoldMusic(
                                        callLocator: CallLocator,
                                        startHoldMusicRequest: startHoldMusicRequestInternal,
                                        cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove participant from the hold and stop playing audio. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="startHoldMusicOperationId">The id of the start hold music operation. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<StopHoldMusicResult>> StopHoldMusicAsync(CommunicationIdentifier participant, string startHoldMusicOperationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StopHoldMusicAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(participant, nameof(startHoldMusicOperationId));

                return await RestClient.StopHoldMusicAsync(
                                    callLocator: CallLocator,
                                    identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                    startHoldMusicOperationId: startHoldMusicOperationId,
                                    cancellationToken: cancellationToken
                                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove participant from the hold and stop playing audio. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="startHoldMusicOperationId">The id of the start hold music operation. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<StopHoldMusicResult> StopHoldMusic(CommunicationIdentifier participant, string startHoldMusicOperationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StopHoldMusic)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(participant, nameof(startHoldMusicOperationId));

                return RestClient.StopHoldMusic(
                                    callLocator: CallLocator,
                                    identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                    startHoldMusicOperationId: startHoldMusicOperationId,
                                    cancellationToken: cancellationToken
                                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Play audio to a participant. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="audioFileUri">The media resource uri of the play audio request. Currently only Wave file (.wav) format audio prompts are supported. The audio content in the wave file must be mono (single-channel), 16-bit samples with a 16,000 (16KHz) sampling rate.</param>
        /// <param name="options"> Options for playing audio. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<PlayAudioResult>> PlayAudioToParticipantAsync(CommunicationIdentifier participant, Uri audioFileUri, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudioToParticipantAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                var playAudioToParticipantRequestInternal = new PlayAudioToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(participant), options?.Loop ?? false);
                playAudioToParticipantRequestInternal.AudioFileId = options?.AudioFileId;
                playAudioToParticipantRequestInternal.CallbackUri = options?.CallbackUri?.AbsoluteUri;
                playAudioToParticipantRequestInternal.OperationContext = options?.OperationContext;

                return await RestClient.ParticipantPlayAudioAsync(
                                    callLocator: CallLocator,
                                    playAudioToParticipantRequest: playAudioToParticipantRequestInternal,
                                    cancellationToken: cancellationToken
                                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Play audio to a participant. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="audioFileUri">The media resource uri of the play audio request. Currently only Wave file (.wav) format audio prompts are supported. The audio content in the wave file must be mono (single-channel), 16-bit samples with a 16,000 (16KHz) sampling rate.</param>
        /// <param name="options"> Options for playing audio. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<PlayAudioResult> PlayAudioToParticipant(CommunicationIdentifier participant, Uri audioFileUri, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudioToParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                var playAudioToParticipantRequestInternal = new PlayAudioToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(participant), options?.Loop ?? false);
                playAudioToParticipantRequestInternal.AudioFileId = options?.AudioFileId;
                playAudioToParticipantRequestInternal.CallbackUri = options?.CallbackUri?.AbsoluteUri;
                playAudioToParticipantRequestInternal.OperationContext = options?.OperationContext;

                return RestClient.ParticipantPlayAudio(
                                    callLocator: CallLocator,
                                    playAudioToParticipantRequest: playAudioToParticipantRequestInternal,
                                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancel Participant Media Operation. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="mediaOperationId">The Id of the media operation to Cancel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> CancelParticipantMediaOperationAsync(CommunicationIdentifier participant, string mediaOperationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(CancelParticipantMediaOperationAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(mediaOperationId, nameof(mediaOperationId));

                var cancelParticipantMediaOperationRequestInternal = new CancelParticipantMediaOperationRequestInternal(CommunicationIdentifierSerializer.Serialize(participant), mediaOperationId);
                return await RestClient.CancelParticipantMediaOperationAsync(
                                    callLocator: CallLocator,
                                    cancelParticipantMediaOperationRequest: cancelParticipantMediaOperationRequestInternal,
                                    cancellationToken: cancellationToken
                                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancel Participant Media Operation. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="mediaOperationId">The Id of the media operation to Cancel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response CancelParticipantMediaOperation(CommunicationIdentifier participant, string mediaOperationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(CancelParticipantMediaOperation)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(mediaOperationId, nameof(mediaOperationId));

                var cancelParticipantMediaOperationRequestInternal = new CancelParticipantMediaOperationRequestInternal(CommunicationIdentifierSerializer.Serialize(participant), mediaOperationId);

                return RestClient.CancelParticipantMediaOperation(
                                    callLocator: CallLocator,
                                    cancelParticipantMediaOperationRequest: cancelParticipantMediaOperationRequestInternal,
                                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancel Media Operation. </summary>
        /// <param name="mediaOperationId">The Id of the media operation to Cancel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> CancelMediaOperationAsync(string mediaOperationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(CancelMediaOperationAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(mediaOperationId, nameof(mediaOperationId));

                var cancelMediaOperationRequest = new CancelMediaOperationRequest(mediaOperationId);

                return await RestClient.CancelMediaOperationAsync(
                                    callLocator: CallLocator,
                                    cancelMediaOperationRequest: cancelMediaOperationRequest,
                                    cancellationToken: cancellationToken
                                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancel Media Operation. </summary>
        /// <param name="mediaOperationId">The Id of the media operation to Cancel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response CancelMediaOperation(string mediaOperationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(CancelMediaOperation)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(mediaOperationId, nameof(mediaOperationId));

                var cancelMediaOperationRequest = new CancelMediaOperationRequest(mediaOperationId);

                return RestClient.CancelMediaOperation(
                                    callLocator: CallLocator,
                                    cancelMediaOperationRequest: cancelMediaOperationRequest,
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
