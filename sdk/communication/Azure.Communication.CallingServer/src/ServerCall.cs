// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    }
}
