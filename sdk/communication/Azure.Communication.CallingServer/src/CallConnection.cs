// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Models;
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

        /// <summary> Terminates the conversation for all participants in the call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Hangup)}");
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

        /// <summary> Terminates the conversation for all participants in the call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Hangup)}");
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
                return await RestClient.PlayAudioAsync(
                    callConnectionId: CallConnectionId,
                    audioFileUri: audioFileUri.AbsoluteUri,
                    loop: options?.Loop ?? false,
                    audioFileId: options?.AudioFileId ?? Guid.NewGuid().ToString(),
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
                return RestClient.PlayAudio(
                    callConnectionId: CallConnectionId,
                    audioFileUri: audioFileUri.AbsoluteUri,
                    loop: options?.Loop ?? false,
                    audioFileId: options?.AudioFileId ?? Guid.NewGuid().ToString(),
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
                return await RestClient.AddParticipantAsync(
                    callConnectionId: CallConnectionId,
                    participant: CommunicationIdentifierSerializer.Serialize(participant),
                    alternateCallerId: alternateCallerId == null ? null : new PhoneNumberIdentifierModel(alternateCallerId),
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
                return RestClient.AddParticipant(
                    callConnectionId: CallConnectionId,
                    participant: CommunicationIdentifierSerializer.Serialize(participant),
                    alternateCallerId: alternateCallerId == null ? null : new PhoneNumberIdentifierModel(alternateCallerId),
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

        /// <summary> Transfer the call to a participant. </summary>
        /// <param name="targetParticipant"> The target participant. </param>
        /// <param name="alternateCallerId">The phone number to use when transferring to a pstn participant.</param>
        /// <param name="userToUserInformation">The user to user information payload. </param>
        /// <param name="operationContext"> The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<TransferCallResult>> TransferToParticipantAsync(CommunicationIdentifier targetParticipant, string alternateCallerId = default, string userToUserInformation = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferToParticipantAsync)}");
            scope.Start();
            try
            {
                return await RestClient.TransferToParticipantAsync(
                    callConnectionId: CallConnectionId,
                    targetParticipant: CommunicationIdentifierSerializer.Serialize(targetParticipant),
                    alternateCallerId: alternateCallerId == null ? null : new PhoneNumberIdentifierModel(alternateCallerId),
                    userToUserInformation: userToUserInformation,
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

        /// <summary> Transfer the call to a participant. </summary>
        /// <param name="targetParticipant"> The target participant. </param>
        /// <param name="alternateCallerId">The phone number to use when transferring to a pstn participant.</param>
        /// <param name="userToUserInformation">The user to user information payload. </param>
        /// <param name="operationContext"> The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<TransferCallResult> TransferToParticipant(CommunicationIdentifier targetParticipant, string alternateCallerId = default, string userToUserInformation = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferToParticipant)}");
            scope.Start();
            try
            {
                return RestClient.TransferToParticipant(
                    callConnectionId: CallConnectionId,
                    targetParticipant: CommunicationIdentifierSerializer.Serialize(targetParticipant),
                    alternateCallerId: alternateCallerId == null ? null : new PhoneNumberIdentifierModel(alternateCallerId),
                    userToUserInformation: userToUserInformation,
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

        /// <summary> Transfer the current call to another call. </summary>
        /// <param name="targetCallConnectionId"> The target call connection id to transfer to. </param>
        /// <param name="userToUserInformation">The user to user information payload. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<TransferCallResult>> TransferToCallAsync(string targetCallConnectionId, string userToUserInformation = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferToCallAsync)}");
            scope.Start();
            try
            {
                return await RestClient.TransferToCallAsync(
                    callConnectionId: CallConnectionId,
                    targetCallConnectionId: targetCallConnectionId,
                    userToUserInformation: userToUserInformation,
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

        /// <summary> Transfer the current call to another call. </summary>
        /// <param name="targetCallConnectionId"> The target call connection id to transfer to. </param>
        /// <param name="userToUserInformation">The user to user information payload. </param>
        /// <param name="operationContext"> The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<TransferCallResult> TransferToCall(string targetCallConnectionId, string userToUserInformation = default, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferToCall)}");
            scope.Start();
            try
            {
                return RestClient.TransferToCall(
                    callConnectionId: CallConnectionId,
                    targetCallConnectionId: targetCallConnectionId,
                    userToUserInformation: userToUserInformation,
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
        public virtual async Task<Response<CallParticipant>> GetParticipantAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipantAsync)}");
            scope.Start();
            try
            {
                Response<CallParticipantInternal> callParticipantsInternal = await RestClient.GetParticipantAsync(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);

                return Response.FromValue(new CallParticipant(callParticipantsInternal.Value), callParticipantsInternal.GetRawResponse());
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
        public virtual Response<CallParticipant> GetParticipant(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                Response<CallParticipantInternal> callParticipantsInternal = RestClient.GetParticipant(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        cancellationToken: cancellationToken);

                return Response.FromValue(new CallParticipant(callParticipantsInternal.Value), callParticipantsInternal.GetRawResponse());
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
                return await RestClient.ParticipantPlayAudioAsync(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        audioFileUri: audioFileUri.AbsoluteUri,
                                        loop: options?.Loop ?? false,
                                        audioFileId: options?.AudioFileId,
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayAudioToParticipant)}");
            scope.Start();
            try
            {
                return RestClient.ParticipantPlayAudio(
                                        callConnectionId: CallConnectionId,
                                        identifier: CommunicationIdentifierSerializer.Serialize(participant),
                                        audioFileUri: audioFileUri.AbsoluteUri,
                                        loop: options?.Loop ?? false,
                                        audioFileId: options?.AudioFileId,
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

        /// <summary> Create an audio routing group with the targets. </summary>
        /// <param name="audioRoutingGroupId"> The audio routing group id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<AudioRoutingGroupResult>> GetAudioRoutingGroupsAsync(string audioRoutingGroupId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CreateAudioRoutingGroupAsync)}");
            scope.Start();
            try
            {
                Response<AudioRoutingGroupResultInternal> audioRoutingGroupResultInternal = await RestClient.GetAudioRoutingGroupsAsync(
                                        callConnectionId: CallConnectionId,
                                        audioRoutingGroupId: audioRoutingGroupId,
                                        cancellationToken: cancellationToken
                                        ).ConfigureAwait(false);

                return Response.FromValue(new AudioRoutingGroupResult(audioRoutingGroupResultInternal.Value), audioRoutingGroupResultInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create an audio routing group with the targets. </summary>
        /// <param name="audioRoutingGroupId"> The audio routing group id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<AudioRoutingGroupResult> GetAudioRoutingGroups(string audioRoutingGroupId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CreateAudioRoutingGroup)}");
            scope.Start();
            try
            {
                Response<AudioRoutingGroupResultInternal> audioRoutingGroupResultInternal = RestClient.GetAudioRoutingGroups(
                    callConnectionId: CallConnectionId,
                    audioRoutingGroupId: audioRoutingGroupId,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(new AudioRoutingGroupResult(audioRoutingGroupResultInternal.Value), audioRoutingGroupResultInternal.GetRawResponse());
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
