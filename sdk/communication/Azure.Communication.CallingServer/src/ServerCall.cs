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

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Azure Communication Services Conversation Client.
    /// </summary>
    public class ServerCall
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal ServerCallRestClient RestClient { get; }

        /// <summary>
        /// The server call id.
        /// </summary>
        internal virtual string ServerCallId { get; set; }

        /// <summary>Initializes a new instance of <see cref="ServerCall"/>.</summary>
        internal ServerCall(string serverCallId, ServerCallRestClient serverCallRestClient, ClientDiagnostics clientDiagnostics)
        {
            ServerCallId = serverCallId;
            RestClient = serverCallRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="ServerCall"/> for mocking.</summary>
        protected ServerCall()
        {
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
        /// <exception cref="ArgumentNullException"> <paramref name="audioFileUri"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(Uri audioFileUri, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
            => await PlayAudioAsync(
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
        /// <param name="options"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(options, nameof(options));

                // Currently looping media is not supported for out-call scenarios, thus setting it to false.
                return await RestClient.PlayAudioAsync(
                    serverCallId: ServerCallId,
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
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<PlayAudioResponse> PlayAudio(Uri audioFileUri, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
            => PlayAudio(
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
        /// <param name="options"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<PlayAudioResponse> PlayAudio(PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(options, nameof(options));

                // Currently looping media is not supported for out-call scenarios, thus setting it to false.
                return RestClient.PlayAudio(
                    serverCallId: ServerCallId,
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
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="callbackUri">The callback uri to receive the notification.</param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual Response AddParticipant(CommunicationIdentifier participant, Uri callbackUri, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var participantsInternal = new List<CommunicationIdentifierModel> { CommunicationIdentifierSerializer.Serialize(participant) };
                var alternateCallerIdInternal = string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId);
                return RestClient.InviteParticipants(
                    serverCallId: ServerCallId,
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
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="callbackUri"></param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task<Response> AddParticipantAsync(CommunicationIdentifier participant, Uri callbackUri, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(AddParticipantAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                var participantsInternal = new List<CommunicationIdentifierModel> { CommunicationIdentifierSerializer.Serialize(participant) };
                var alternateCallerIdInternal = string.IsNullOrEmpty(alternateCallerId) ? null : new PhoneNumberIdentifierModel(alternateCallerId);
                return await RestClient.InviteParticipantsAsync(
                    serverCallId: ServerCallId,
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(RemoveParticipantAsync)}");
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
        public virtual async Task<Response<StartCallRecordingResponse>> StartRecordingAsync(Uri recordingStateCallbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StartRecordingAsync)}");
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
        public virtual Response<StartCallRecordingResponse> StartRecording(Uri recordingStateCallbackUri, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response<GetCallRecordingStateResponse>> GetRecordingStateAsync(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetRecordingStateAsync)}");
            scope.Start();
            try
            {
                return await RestClient.RecordingStateAsync(
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
        public virtual Response<GetCallRecordingStateResponse> GetRecordingState(string recordingId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(GetRecordingState)}");
            scope.Start();
            try
            {
                return RestClient.RecordingState(
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(StopRecordingAsync)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(PauseRecordingAsync)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ServerCall)}.{nameof(ResumeRecordingAsync)}");
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

        /// <summary> Get a list of all the participants in the call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<IEnumerable<CommunicationParticipant>>> GetParticipantsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetParticipantsAsync)}");
            scope.Start();
            try
            {
                var communicationParticipantsInternal = await RestClient.GetParticipantsAsync(
                     serverCallId: ServerCallId,
                     cancellationToken: cancellationToken
                     ).ConfigureAwait(false);

                return Response.FromValue(communicationParticipantsInternal.Value.Select(c => CommunicationParticipantSerializer.Deserialize(c)), communicationParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get a list of all the participants in the call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<IEnumerable<CommunicationParticipant>> GetParticipants(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                var communicationParticipantsInternal = RestClient.GetParticipants(
                     serverCallId: ServerCallId,
                     cancellationToken: cancellationToken
                     );

                return Response.FromValue(communicationParticipantsInternal.Value.Select(c => CommunicationParticipantSerializer.Deserialize(c)), communicationParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get a participant from the call using participant id. </summary>
        /// <param name="participantId">The participant id. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CommunicationParticipant>> GetParticipantAsync(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetParticipantAsync)}");
            scope.Start();
            try
            {
                var communicationParticipantInternal = await RestClient.GetParticipantAsync(
                     serverCallId: ServerCallId,
                     participantId: participantId,
                     cancellationToken: cancellationToken
                     ).ConfigureAwait(false);

                return Response.FromValue(
                    CommunicationParticipantSerializer.Deserialize(communicationParticipantInternal.Value),
                    communicationParticipantInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get a participant from the call using participant id. </summary>
        /// <param name="participantId">The participant id. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CommunicationParticipant> GetParticipant(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var communicationParticipantInternal = RestClient.GetParticipant(
                     serverCallId: ServerCallId,
                     participantId: participantId,
                     cancellationToken: cancellationToken);

                return Response.FromValue(
                    CommunicationParticipantSerializer.Deserialize(communicationParticipantInternal.Value),
                    communicationParticipantInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
