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

        internal CallConnection(string CallConnectionId, CallConnectionsRestClient callConnectionRestClient, ClientDiagnostics clientDiagnostics)
        {
            this.CallConnectionId = CallConnectionId;
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
        public virtual async Task<Response> TerminateCallAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TerminateCall)}");
            scope.Start();
            try
            {
                return await RestClient.TerminateCallAsync(
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
        public virtual Response TerminateCall(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TerminateCall)}");
            scope.Start();
            try
            {
                return RestClient.TerminateCall(
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

        /// <summary> Transfer this call to a participant. </summary>
        /// <param name="targetParticipant"> The identity of the target where call should be transferred to. </param>
        /// <param name="options">The transfer options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<TransferCallResponse> TransferCallToParticipantAsync(CommunicationIdentifier targetParticipant, TransferCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                TransferToParticipantRequestInternal request = new TransferToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(targetParticipant));

                if (options != null)
                {
                    request.TransfereeCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                    request.UserToUserInformation = options.UserToUserInformation;
                    request.OperationContext = options.OperationContext;
                    request.TransfereeParticipantId = options.TransfereeParticipantId;
                }

                return await RestClient.TransferToParticipantAsync(
                    callConnectionId: CallConnectionId,
                    request,
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
        /// <param name="options">The transfer options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual TransferCallResponse TransferCallToParticipant(CommunicationIdentifier targetParticipant, TransferCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                TransferToParticipantRequestInternal request = new TransferToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(targetParticipant));

                if (options != null)
                {
                    request.TransfereeCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                    request.UserToUserInformation = options.UserToUserInformation;
                    request.OperationContext = options.OperationContext;
                    request.TransfereeParticipantId = options.TransfereeParticipantId;
                }

                return RestClient.TransferToParticipant(
                    callConnectionId: CallConnectionId,
                    request,
                    cancellationToken: cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Transfer this call to another call. </summary>
        /// <param name="targetCallConnectionId"> The target where call's CallConnectionId. </param>
        /// <param name="options">The transfer options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<TransferCallResponse> TransferCallToCallAsync(string targetCallConnectionId, TransferCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                TransferToCallRequestInternal request = new TransferToCallRequestInternal(targetCallConnectionId);

                if (options != null)
                {
                    request.UserToUserInformation = options.UserToUserInformation;
                    request.OperationContext = options.OperationContext;
                    request.TransfereeParticipantId = options.TransfereeParticipantId;
                }

                return await RestClient.TransferToCallAsync(
                    callConnectionId: CallConnectionId,
                    request,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Transfer this call to another call. </summary>
        /// <param name="targetCallConnectionId"> The target where call's CallConnectionId. </param>
        /// <param name="options">The transfer options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual TransferCallResponse TransferCallToCall(string targetCallConnectionId, TransferCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                TransferToCallRequestInternal request = new TransferToCallRequestInternal(targetCallConnectionId);

                if (options != null)
                {
                    request.UserToUserInformation = options.UserToUserInformation;
                    request.OperationContext = options.OperationContext;
                    request.TransfereeParticipantId = options.TransfereeParticipantId;
                }

                return RestClient.TransferToCall(
                    callConnectionId: CallConnectionId,
                    request,
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
        /// <param name="participantsToAdd"> The list of identity of participants to be added to the call. </param>
        /// <param name="options">The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToAdd"/> is null. </exception>
        public virtual async Task<AddParticipantsResponse> AddParticipantsAsync(IEnumerable<CommunicationIdentifier> participantsToAdd, AddParticipantsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                AddParticipantsRequestInternal request = new AddParticipantsRequestInternal(participantsToAdd.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                if (options != null)
                {
                    request.SourceCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                    request.OperationContext = options.OperationContext;
                    request.InvitationTimeoutInSeconds = options.invitationTimeoutInSeconds;
                    request.ReplacementCallConnectionId = options.replacementCallConnectionId;
                }

                return await RestClient.AddParticipantAsync(
                    callConnectionId: CallConnectionId,
                    request,
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
        /// <param name="participantsToAdd"> The list of identity of participants to be added to the call. </param>
        /// <param name="options">The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToAdd"/> is null. </exception>
        public virtual AddParticipantsResponse AddParticipants(IEnumerable<CommunicationIdentifier> participantsToAdd, AddParticipantsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                AddParticipantsRequestInternal request = new AddParticipantsRequestInternal(participantsToAdd.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                if (options != null)
                {
                    request.SourceCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                    request.OperationContext = options.OperationContext;
                    request.InvitationTimeoutInSeconds = options.invitationTimeoutInSeconds;
                    request.ReplacementCallConnectionId = options.replacementCallConnectionId;
                }

                return RestClient.AddParticipant(
                    callConnectionId: CallConnectionId,
                    request,
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
