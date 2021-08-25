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
        /// The server call id.
        /// </summary>
        internal virtual string ServerCallId { get; set; }

        /// <summary>Initializes a new instance of <see cref="ServerCall"/>.</summary>
        internal ServerCall(string serverCallId, ServerCallsRestClient serverCallRestClient, ClientDiagnostics clientDiagnostics)
        {
            ServerCallId = serverCallId;
            RestClient = serverCallRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="ServerCall"/> for mocking.</summary>
        protected ServerCall()
        {
            ServerCallId = null;
            _clientDiagnostics = null;
            RestClient = null;
        }

        /// <summary> Play audio in the call. </summary>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<PlayAudioResult>> PlayAudioAsync(Uri audioFileUri, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                // Currently looping media is not supported for out-call scenarios, thus setting it to false.
                return await RestClient.PlayAudioAsync(
                    serverCallId: ServerCallId,
                    audioFileUri: audioFileUri?.AbsoluteUri,
                    loop: false,
                    audioFileId: audioFileId,
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

        /// <summary> Play audio in the call. </summary>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<PlayAudioResult> PlayAudio(Uri audioFileUri, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                // Currently looping media is not supported for out-call scenarios, thus setting it to false.
                return RestClient.PlayAudio(
                    serverCallId: ServerCallId,
                    audioFileUri: audioFileUri?.AbsoluteUri,
                    loop: false,
                    audioFileId: audioFileId,
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

                return RestClient.AddParticipant(
                    serverCallId: ServerCallId,
                    participant: CommunicationIdentifierSerializer.Serialize(participant),
                    alternateCallerId: string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId),
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

                return await RestClient.AddParticipantAsync(
                    serverCallId: ServerCallId,
                    participant: CommunicationIdentifierSerializer.Serialize(participant),
                    alternateCallerId: string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId),
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
        /// <param name="participantId">The participant id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response RemoveParticipant(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                return RestClient.RemoveParticipant(
                    serverCallId: ServerCallId,
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
        /// <param name="participantId">The participant id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> RemoveParticipantAsync(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                return await RestClient.RemoveParticipantAsync(
                    serverCallId: ServerCallId,
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
        /// <param name="recordingStateCallbackUri">The uri to send state change callbacks.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<StartCallRecordingResult>> StartRecordingAsync(Uri recordingStateCallbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartRecording)}");
            scope.Start();
            try
            {
                return await RestClient.StartRecordingAsync(
                    serverCallId: ServerCallId,
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
        /// <param name="recordingStateCallbackUri">The uri to send state change callbacks.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response<StartCallRecordingResult> StartRecording(Uri recordingStateCallbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartRecording)}");
            scope.Start();
            try
            {
                return RestClient.StartRecording(
                    serverCallId: ServerCallId,
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
        /// <param name="recordingId">The recording id to get the state of.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response<CallRecordingProperties>> GetRecordingStateAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetRecordingState)}");
            scope.Start();
            try
            {
                return await RestClient.GetRecordingPropertiesAsync(
                    serverCallId: ServerCallId,
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
                    serverCallId: ServerCallId,
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
                    serverCallId: ServerCallId,
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
                    serverCallId: ServerCallId,
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
                    serverCallId: ServerCallId,
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
                    serverCallId: ServerCallId,
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
                    serverCallId: ServerCallId,
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
                    serverCallId: ServerCallId,
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
                                        serverCallId: ServerCallId,
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
                                        serverCallId: ServerCallId,
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
        /// <param name="participantId">The participant id. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual async Task<Response<CallParticipant>> GetParticipantAsync(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetParticipantAsync)}");
            scope.Start();
            try
            {
                Response<CallParticipantInternal> callParticipantInternal = await RestClient.GetParticipantAsync(
                                        participantId: participantId,
                                        serverCallId: ServerCallId,
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);

                return Response.FromValue(new CallParticipant(callParticipantInternal.Value), callParticipantInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participant of the call using participant id. </summary>
        /// <param name="participantId">The participant id. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual Response<CallParticipant> GetParticipant(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                Response<CallParticipantInternal> callParticipantInternal = RestClient.GetParticipant(
                                        participantId: participantId,
                                        serverCallId: ServerCallId,
                                        cancellationToken: cancellationToken);

                return Response.FromValue(new CallParticipant(callParticipantInternal.Value), callParticipantInternal.GetRawResponse());
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
        public virtual async Task<Response<IEnumerable<CallParticipant>>> GetParticipantByIdAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipantByIdAsync)}");
            scope.Start();
            try
            {
                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = await RestClient.GetParticipantByIdAsync(
                                        serverCallId: ServerCallId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
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
        public virtual Response<IEnumerable<CallParticipant>> GetParticipantById(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipantById)}");
            scope.Start();
            try
            {
                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = RestClient.GetParticipantById(
                                        serverCallId: ServerCallId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        cancellationToken: cancellationToken);

                return Response.FromValue(callParticipantsInternal.Value.Select(c => new CallParticipant(c)), callParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove a participant from the call using <see cref="CommunicationIdentifier"/>.</summary>
        /// <param name="participant"> The identity of participant to be removed from the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> RemoveParticipantByIdAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(RemoveParticipantByIdAsync)}");
            scope.Start();
            try
            {
                return await RestClient.RemoveParticipantByIdAsync(
                    serverCallId: ServerCallId,
                    identifier: CommunicationIdentifierSerializer.Serialize(participant),
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove a participant from the call using <see cref="CommunicationIdentifier"/>.</summary>
        /// <param name="participant"> The identity of participant to be removed from the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response RemoveParticipantById(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(RemoveParticipantById)}");
            scope.Start();
            try
            {
                return RestClient.RemoveParticipantById(
                    serverCallId: ServerCallId,
                    identifier: CommunicationIdentifierSerializer.Serialize(participant),
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Hold the participant and play default music. </summary>
        /// <param name="participantId">The participant id.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<StartHoldMusicResult>> StartHoldMusicAsync(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartHoldMusicAsync)}");
            scope.Start();
            try
            {
                return await RestClient.StartHoldMusicAsync(
                    serverCallId: ServerCallId,
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

        /// <summary> Hold the participant and play default music. </summary>
        /// <param name="participantId">The participant id.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<StartHoldMusicResult> StartHoldMusic(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartHoldMusic)}");
            scope.Start();
            try
            {
                return RestClient.StartHoldMusic(
                    serverCallId: ServerCallId,
                    participantId: participantId,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Hold the participant and play the custom audio. </summary>
        /// <param name="participantId">The participant id.</param>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<StartHoldMusicResult>> StartHoldMusicAsync(string participantId, Uri audioFileUri, string audioFileId, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartHoldMusicAsync)}");
            scope.Start();
            try
            {
                return await RestClient.StartHoldMusicAsync(
                    serverCallId: ServerCallId,
                    participantId: participantId,
                    audioFileUri: audioFileUri.AbsoluteUri,
                    audioFileId: audioFileId,
                    callbackUri: callbackUri.AbsoluteUri,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Hold the participant and play the custom audio. </summary>
        /// <param name="participantId">The participant id.</param>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<StartHoldMusicResult> StartHoldMusic(string participantId, Uri audioFileUri, string audioFileId, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartHoldMusic)}");
            scope.Start();
            try
            {
                return RestClient.StartHoldMusic(
                    serverCallId: ServerCallId,
                    participantId: participantId,
                    audioFileUri: audioFileUri.AbsoluteUri,
                    audioFileId: audioFileId,
                    callbackUri: callbackUri.AbsoluteUri,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove participant from the hold and stop playing audio. </summary>
        /// <param name="participantId"> The participant id. </param>
        /// <param name="operationId">The id of the start hold music operation. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<StopHoldMusicResult>> StopHoldMusicAsync(string participantId, string operationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StopHoldMusicAsync)}");
            scope.Start();
            try
            {
                return await RestClient.StopHoldMusicAsync(
                    serverCallId: ServerCallId,
                    participantId: participantId,
                    startHoldMusicOperationId: operationId,
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
        /// <param name="participantId"> The participant id. </param>
        /// <param name="operationId">The id of the start hold music operation. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<StopHoldMusicResult> StopHoldMusic(string participantId, string operationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StopHoldMusic)}");
            scope.Start();
            try
            {
                return RestClient.StopHoldMusic(
                    serverCallId: ServerCallId,
                    participantId: participantId,
                    startHoldMusicOperationId: operationId,
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
        /// <param name="participantId">The participant id.</param>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<PlayAudioResult>> PlayAudioToParticipantAsync(string participantId, Uri audioFileUri, string audioFileId, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudioToParticipantAsync)}");
            scope.Start();
            try
            {
                return await RestClient.ParticipantPlayAudioAsync(
                    serverCallId: ServerCallId,
                    participantId: participantId,
                    loop: false,
                    audioFileUri: audioFileUri.AbsoluteUri,
                    audioFileId: audioFileId,
                    callbackUri: callbackUri.AbsoluteUri,
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
        /// <param name="participantId">The participant id.</param>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<PlayAudioResult> PlayAudioToParticipant(string participantId, Uri audioFileUri, string audioFileId, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudioToParticipant)}");
            scope.Start();
            try
            {
                return RestClient.ParticipantPlayAudio(
                    serverCallId: ServerCallId,
                    participantId: participantId,
                    loop: false,
                    audioFileUri: audioFileUri.AbsoluteUri,
                    audioFileId: audioFileId,
                    callbackUri: callbackUri.AbsoluteUri,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
