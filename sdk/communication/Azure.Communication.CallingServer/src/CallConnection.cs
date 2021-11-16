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
    /// The Azure Communication Services Calling Server client.
    /// </summary>
    public class CallConnection
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallConnectionsRestClient RestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallConnection(string callConnectionId, CallConnectionsRestClient callConnectionRestClient, ClientDiagnostics clientDiagnostics)
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

        /// <summary> Disconnect the current caller in a group-call or end a p2p-call.</summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> HangupAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Hangup)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Hangup)}");
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
        public virtual async Task<Response> CancelAllMediaOperationsAsync(string operationContext = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return await RestClient.CancelAllMediaOperationsAsync(
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

        /// <summary> Cancel all media operations in the call. </summary>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response CancelAllMediaOperations(string operationContext = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return RestClient.CancelAllMediaOperations(
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

        /// <summary> Play audio in the call. </summary>
        /// <param name="audioFileUri">The media resource uri of the play audio request. Currently only Wave file (.wav) format audio prompts are supported. The audio content in the wave file must be mono (single-channel), 16-bit samples with a 16,000 (16KHz) sampling rate.</param>
        /// <param name="options"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<PlayAudioResult>> PlayAudioAsync(Uri audioFileUri, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                return await RestClient.PlayAudioAsync(
                    callConnectionId: CallConnectionId,
                    audioFileUri: audioFileUri.AbsoluteUri,
                    loop: options?.Loop ?? false,
                    audioFileId: options?.AudioFileId ?? Guid.NewGuid().ToString(),
                    callbackUri: options?.CallbackUri?.AbsoluteUri,
                    operationContext: options?.OperationContext ?? Guid.NewGuid().ToString(),
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
        /// <param name="options"> Play audio request. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<PlayAudioResult> PlayAudio(Uri audioFileUri, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                return RestClient.PlayAudio(
                    callConnectionId: CallConnectionId,
                    audioFileUri: audioFileUri.AbsoluteUri,
                    loop: options?.Loop ?? false,
                    audioFileId: options?.AudioFileId ?? Guid.NewGuid().ToString(),
                    callbackUri: options?.CallbackUri?.AbsoluteUri,
                    operationContext: options?.OperationContext ?? Guid.NewGuid().ToString(),
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
        public virtual async Task<Response<AddParticipantResult>> AddParticipantAsync(CommunicationIdentifier participant, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return await RestClient.AddParticipantAsync(
                    callConnectionId: CallConnectionId,
                    participant: CommunicationIdentifierSerializer.Serialize(participant),
                    alternateCallerId: alternateCallerId == null ? null : new PhoneNumberIdentifierModel(alternateCallerId),
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
        public virtual Response<AddParticipantResult> AddParticipant(CommunicationIdentifier participant, string alternateCallerId = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return RestClient.AddParticipant(
                    callConnectionId: CallConnectionId,
                    participant: CommunicationIdentifierSerializer.Serialize(participant),
                    alternateCallerId: alternateCallerId == null ? null : new PhoneNumberIdentifierModel(alternateCallerId),
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
        /// <param name="participant"> The identity of participant to be removed from the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> RemoveParticipantAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return await RestClient.RemoveParticipantAsync(
                    callConnectionId: CallConnectionId,
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

        /// <summary> Remove a participant from the call. </summary>
        /// <param name="participant"> The identity of participant to be removed from the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response RemoveParticipant(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return RestClient.RemoveParticipant(
                    callConnectionId: CallConnectionId,
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

        /// <summary> Transfer the call. </summary>
        /// <param name="targetParticipant"> The target participant. </param>
        /// <param name="targetCallConnectionId"> The target call connection id to transfer to. </param>
        /// <param name="userToUserInformation">The user to user information payload. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<TransferCallResult>> TransferCallAsync(CommunicationIdentifier targetParticipant, string targetCallConnectionId, string userToUserInformation, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(targetParticipant, nameof(targetParticipant));

                return await RestClient.TransferAsync(
                    callConnectionId: CallConnectionId,
                    targetParticipant: CommunicationIdentifierSerializer.Serialize(targetParticipant),
                    targetCallConnectionId: targetCallConnectionId,
                    userToUserInformation: userToUserInformation,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Transfer the call. </summary>
        /// <param name="targetParticipant"> The target participant. </param>
        /// <param name="targetCallConnectionId"> The target call connection id to transfer to. </param>
        /// <param name="userToUserInformation">The user to user information payload. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<TransferCallResult> TransferCall(CommunicationIdentifier targetParticipant, string targetCallConnectionId, string userToUserInformation, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCall)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(targetParticipant, nameof(targetParticipant));

                return RestClient.Transfer(
                    callConnectionId: CallConnectionId,
                    targetParticipant: CommunicationIdentifierSerializer.Serialize(targetParticipant),
                    targetCallConnectionId: targetCallConnectionId,
                    userToUserInformation: userToUserInformation,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get call connection properties. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallConnectionProperties"/>.</returns>
        public virtual async Task<Response<CallConnectionProperties>> GetCallAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Response<CallConnectionPropertiesInternal> callConnectionPropertiesInternal = await RestClient.GetCallAsync(
                                        callConnectionId: CallConnectionId,
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);

                return Response.FromValue(new CallConnectionProperties(callConnectionPropertiesInternal.Value), callConnectionPropertiesInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get call connection properties. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallConnectionProperties"/>.</returns>
        public virtual Response<CallConnectionProperties> GetCall(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                Response<CallConnectionPropertiesInternal> callConnectionPropertiesInternal = RestClient.GetCall(
                        callConnectionId: CallConnectionId,
                        cancellationToken: cancellationToken
                        );

                return Response.FromValue(new CallConnectionProperties(callConnectionPropertiesInternal.Value), callConnectionPropertiesInternal.GetRawResponse());
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipantsAsync)}");
            scope.Start();
            try
            {
                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = await RestClient.GetParticipantsAsync(
                                        callConnectionId: CallConnectionId,
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = RestClient.GetParticipants(
                                        callConnectionId: CallConnectionId,
                                        cancellationToken: cancellationToken);

                return Response.FromValue(callParticipantsInternal.Value.Select(x => new CallParticipant(x)), callParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participant from the call using <see cref="CommunicationIdentifier"/>. </summary>
        /// <param name="participant"> The identity of participant. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual async Task<Response<IEnumerable<CallParticipant>>> GetParticipantAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipantAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = await RestClient.GetParticipantAsync(
                                        callConnectionId: CallConnectionId,
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
        /// <param name="participant"> The identity of participant. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual Response<IEnumerable<CallParticipant>> GetParticipant(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                Response<IReadOnlyList<CallParticipantInternal>> callParticipantsInternal = RestClient.GetParticipant(
                                        callConnectionId: CallConnectionId,
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

        /// <summary> Keep call connection alive. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> KeepAliveAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(KeepAliveAsync)}");
            scope.Start();
            try
            {
                return await RestClient.KeepAliveAsync(
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

        /// <summary> Keep call connection alive. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response KeepAlive(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(KeepAlive)}");
            scope.Start();
            try
            {
                return RestClient.KeepAlive(
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

        /// <summary> Play audio to a participant. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="audioFileUri">The media resource uri of the play audio request. Currently only Wave file (.wav) format audio prompts are supported. The audio content in the wave file must be mono (single-channel), 16-bit samples with a 16,000 (16KHz) sampling rate.</param>
        /// <param name="options"> Options for playing audio. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<PlayAudioResult>> PlayAudioToParticipantAsync(CommunicationIdentifier participant, Uri audioFileUri, PlayAudioOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayAudioToParticipantAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                return await RestClient.ParticipantPlayAudioAsync(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        audioFileUri: audioFileUri.AbsoluteUri,
                                        loop: options?.Loop ?? false,
                                        audioFileId: options?.AudioFileId,
                                        callbackUri: options?.CallbackUri?.AbsoluteUri,
                                        operationContext: options?.OperationContext,
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
            Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayAudioToParticipant)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(audioFileUri, nameof(audioFileUri));

                return RestClient.ParticipantPlayAudio(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        audioFileUri: audioFileUri.AbsoluteUri,
                                        loop: options?.Loop ?? false,
                                        audioFileId: options?.AudioFileId,
                                        callbackUri: options?.CallbackUri?.AbsoluteUri,
                                        operationContext: options?.OperationContext,
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelParticipantMediaOperationAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(mediaOperationId, nameof(mediaOperationId));

                return await RestClient.CancelParticipantMediaOperationAsync(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        mediaOperationId: mediaOperationId,
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelParticipantMediaOperation)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));
                Argument.AssertNotNull(mediaOperationId, nameof(mediaOperationId));

                return RestClient.CancelParticipantMediaOperation(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        mediaOperationId: mediaOperationId,
                                        cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Mute Participant Operation. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> MuteParticipantAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelParticipantMediaOperationAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return await RestClient.MuteParticipantAsync(
                                        callConnectionId: CallConnectionId,
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

        /// <summary> Mute Participant Operation. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response MuteParticipant(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelParticipantMediaOperation)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return RestClient.MuteParticipant(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Unmute Participant Operation. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UnmuteParticipantAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelParticipantMediaOperationAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return await RestClient.UnmuteParticipantAsync(
                                        callConnectionId: CallConnectionId,
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

        /// <summary> Unmute Participant Operation. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UnmuteParticipant(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelParticipantMediaOperation)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return RestClient.UnmuteParticipant(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Hold Participant Meeting Audio. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> HoldParticipantMeetingAudioAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(HoldParticipantMeetingAudioAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return await RestClient.HoldParticipantMeetingAudioAsync(
                                        callConnectionId: CallConnectionId,
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

        /// <summary> Hold Participant Meeting Audio. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response HoldParticipantMeetingAudio(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(HoldParticipantMeetingAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return RestClient.HoldParticipantMeetingAudio(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Resume Participant Meeting Audio. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> ResumeParticipantMeetingAudioAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(ResumeParticipantMeetingAudioAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return await RestClient.ResumeParticipantMeetingAudioAsync(
                                        callConnectionId: CallConnectionId,
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

        /// <summary> Resume Participant Meeting Audio. </summary>
        /// <param name="participant"> The identifier of the participant. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response ResumeParticipantMeetingAudio(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(ResumeParticipantMeetingAudio)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(participant, nameof(participant));

                return RestClient.ResumeParticipantMeetingAudio(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create an audio routing group with the targets. </summary>
        /// <param name="audioRoutingMode"> The audio routing group mode. </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CreateAudioRoutingGroupResult>> CreateAudioRoutingGroupAsync(AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CreateAudioRoutingGroupAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                var count = targets.Count();
                if (audioRoutingMode == AudioRoutingMode.OneToOne)
                {
                    if (count != 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(targets), "count should be one when using AudioRoutingMode.OneToOne");
                    }
                }

                return await RestClient.CreateAudioRoutingGroupAsync(
                                        callConnectionId: CallConnectionId,
                                        audioRoutingMode: audioRoutingMode,
                                        targets: targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create an audio routing group with the targets. </summary>
        /// <param name="audioRoutingMode"> The audio routing group mode. </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CreateAudioRoutingGroupResult> CreateAudioRoutingGroup(AudioRoutingMode audioRoutingMode, IEnumerable<CommunicationIdentifier> targets, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CreateAudioRoutingGroup)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));
                var count = targets.Count();
                if (audioRoutingMode == AudioRoutingMode.OneToOne)
                {
                    if (count != 1)
                    {
                        throw new ArgumentOutOfRangeException(nameof(targets), "count should be one when using AudioRoutingMode.OneToOne");
                    }
                }

                return RestClient.CreateAudioRoutingGroup(
                                        callConnectionId: CallConnectionId,
                                        audioRoutingMode: audioRoutingMode,
                                        targets: targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                                        cancellationToken: cancellationToken
                                        );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Update the targets in an existing audio routing group. </summary>
        /// <param name="audioRoutingGroupId"> The identifier of the Audio Routing Group. </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateAudioRoutingGroupAsync(string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(UpdateAudioRoutingGroupAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(audioRoutingGroupId, nameof(audioRoutingGroupId));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));

                return await RestClient.UpdateAudioRoutingGroupAsync(
                                        callConnectionId: CallConnectionId,
                                        audioRoutingGroupId: audioRoutingGroupId,
                                        targets: targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Update the targets in an existing audio routing group. </summary>
        /// <param name="audioRoutingGroupId"> The identifier of the Audio Routing Group. </param>
        /// <param name="targets"> The target identities. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateAudioRoutingGroup(string audioRoutingGroupId, IEnumerable<CommunicationIdentifier> targets, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(UpdateAudioRoutingGroup)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(audioRoutingGroupId, nameof(audioRoutingGroupId));
                Argument.AssertNotNullOrEmpty(targets, nameof(targets));

                return RestClient.UpdateAudioRoutingGroup(
                                        callConnectionId: CallConnectionId,
                                        audioRoutingGroupId: audioRoutingGroupId,
                                        targets: targets.Select(t => CommunicationIdentifierSerializer.Serialize(t)),
                                        cancellationToken: cancellationToken
                                        );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Delete an existing audio routing group. </summary>
        /// <param name="audioRoutingGroupId"> The identifier of the Audio Routing Group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteAudioRoutingGroupAsync(string audioRoutingGroupId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(DeleteAudioRoutingGroupAsync)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(audioRoutingGroupId, nameof(audioRoutingGroupId));

                return await RestClient.DeleteAudioRoutingGroupAsync(
                                        callConnectionId: CallConnectionId,
                                        audioRoutingGroupId: audioRoutingGroupId,
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Delete an existing audio routing group. </summary>
        /// <param name="audioRoutingGroupId"> The identifier of the Audio Routing Group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteAudioRoutingGroup(string audioRoutingGroupId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(DeleteAudioRoutingGroup)}");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(audioRoutingGroupId, nameof(audioRoutingGroupId));

                return RestClient.DeleteAudioRoutingGroup(
                                        callConnectionId: CallConnectionId,
                                        audioRoutingGroupId: audioRoutingGroupId,
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
