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
    /// The Azure Communication Services Call Connection.
    /// </summary>
    public class CallConnection
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallConnectionRestClient RestClient { get; }

        /// <summary>
        /// The call connection id. This is the call leg id associated with the current call.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallConnection(string callConnectionId, CallConnectionRestClient callConnectionRestClient, ClientDiagnostics clientDiagnostics)
        {
            this.CallConnectionId = callConnectionId;
            this.RestClient = callConnectionRestClient;
            this._clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="CallingServerClient"/> for mocking.</summary>
        protected CallConnection()
        {
            _clientDiagnostics = null;
            RestClient = null;
            CallConnectionId = null;
        }

        /// <summary> Deletes the call. </summary>
        /// <param name="cancellationToken"> The cancellation token . </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteCallAsync(
                    callConnectionId: CallConnectionId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes the call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return RestClient.DeleteCall(
                    callConnectionId: CallConnectionId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Disconnect the current caller in a group-call or end a p2p-call.</summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> HangupAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(Hangup)}");
            scope.Start();
            try
            {
                return await RestClient.HangupCallAsync(
                    callConnectionId: CallConnectionId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Disconnect the current caller in a group-call or end a p2p-call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response Hangup(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(Hangup)}");
            scope.Start();
            try
            {
                return RestClient.HangupCall(
                    callConnectionId: CallConnectionId,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancel all media operations in the call. </summary>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CancelAllMediaOperationsResponse>> CancelAllMediaOperationsAsync(string operationContext = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CancelAllMediaOperationsAsync)}");
            scope.Start();
            try
            {
                return await RestClient.CancelAllMediaOperationsAsync(
                    callConnectionId: CallConnectionId,
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

        /// <summary> Cancel all media operations in the call. </summary>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CancelAllMediaOperationsResponse> CancelAllMediaOperations(string operationContext = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return RestClient.CancelAllMediaOperations(
                    callConnectionId: CallConnectionId,
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

        /// <summary> Play audio in the call. </summary>
        /// <param name="audioFileUri"> The uri of the audio file. </param>
        /// <param name="loop">The flag to indicate if audio file need to be played in a loop or not.</param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="audioFileUri"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResponse>> PlayAudioAsync(Uri audioFileUri, bool? loop, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
            => await PlayAudioAsync(
                options: new PlayAudioOptions
                {
                    AudioFileUri = audioFileUri,
                    Loop = loop,
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(options, nameof(options));

                return await RestClient.PlayAudioAsync(
                    callConnectionId: CallConnectionId,
                    audioFileUri: options.AudioFileUri?.AbsoluteUri,
                    loop: options.Loop,
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
        /// <param name="loop">The flag to indicate if audio file need to be played in a loop or not.</param>
        /// <param name="audioFileId">Tne id for the media in the AudioFileUri, using which we cache the media resource. </param>
        /// <param name="callbackUri">The callback Uri to receive PlayAudio status notifications. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="audioFileUri"/> is null. </exception>
        public virtual Response<PlayAudioResponse> PlayAudio(Uri audioFileUri, bool? loop, string audioFileId, Uri callbackUri, string operationContext = null, CancellationToken cancellationToken = default)
            => PlayAudio(
                options: new PlayAudioOptions
                {
                    AudioFileUri = audioFileUri,
                    Loop = loop,
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(options, nameof(options));

                return RestClient.PlayAudio(
                    callConnectionId: CallConnectionId,
                    audioFileUri: options.AudioFileUri?.AbsoluteUri,
                    loop: options.Loop,
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

        /// <summary> Add a participant to the call. </summary>

        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participant"/> is null. </exception>
        public virtual async Task<Response> AddParticipantAsync(CommunicationIdentifier participant, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AddParticipantAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNullOrEmpty(alternateCallerId, nameof(alternateCallerId));

                return await RestClient.InviteParticipantsAsync(
                    callConnectionId: CallConnectionId,
                    participants: new List<CommunicationIdentifierModel>() { CommunicationIdentifierSerializer.Serialize(participant) },
                    alternateCallerId: new PhoneNumberIdentifierModel(alternateCallerId),
                    operationContext: operationContext,
                    callbackUri: null,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Add a participant to the call. </summary>
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="alternateCallerId">The phone number to use when adding a pstn participant.</param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participant"/> is null. </exception>
        public virtual Response AddParticipant(CommunicationIdentifier participant, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNullOrEmpty(alternateCallerId, nameof(alternateCallerId));

                return RestClient.InviteParticipants(
                    callConnectionId: CallConnectionId,
                    participants: new List<CommunicationIdentifierModel>() { CommunicationIdentifierSerializer.Serialize(participant) },
                    alternateCallerId: new PhoneNumberIdentifierModel(alternateCallerId),
                    operationContext: operationContext,
                    callbackUri: null,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove a participant from the call. </summary>
        /// <param name="participantId"> The participant id. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantId"/> is null. </exception>
        public virtual async Task<Response> RemoveParticipantAsync(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                return await RestClient.RemoveParticipantAsync(
                    callConnectionId: CallConnectionId,
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

        /// <summary> Remove a participants from the call. </summary>
        /// <param name="participantId"> The participant id. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantId"/> is null. </exception>
        public virtual Response RemoveParticipant(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                return RestClient.RemoveParticipant(
                    callConnectionId: CallConnectionId,
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

        /// <summary> Get call connection details. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CallConnectionDetails>> GetDetailsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetDetails)}");
            scope.Start();
            try
            {
                var callConnectionDetailsInternal = await RestClient.GetCallAsync(
                     callConnectionId: CallConnectionId,
                     cancellationToken: cancellationToken
                     ).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnectionDetails(callConnectionDetailsInternal.Value),
                    callConnectionDetailsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get call connection details. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CallConnectionDetails> GetDetails(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetDetails)}");
            scope.Start();
            try
            {
                var callConnectionDetailsInternal = RestClient.GetCall(
                     callConnectionId: CallConnectionId,
                     cancellationToken: cancellationToken
                     );

                return Response.FromValue(
                    new CallConnectionDetails(callConnectionDetailsInternal.Value),
                    callConnectionDetailsInternal.GetRawResponse());
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
                     callConnectionId: CallConnectionId,
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
                     callConnectionId: CallConnectionId,
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
                     callConnectionId: CallConnectionId,
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
                     callConnectionId: CallConnectionId,
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
