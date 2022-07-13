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
    /// The Azure Communication Services Call Connection Client.
    /// </summary>
    public class CallConnectionClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallConnectionsRestClient RestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallConnectionClient(string callConnectionId, CallConnectionsRestClient callConnectionRestClient, ClientDiagnostics clientDiagnostics)
        {
            CallConnectionId = callConnectionId;
            RestClient = callConnectionRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="CallConnectionClient"/> for mocking.</summary>
        protected CallConnectionClient()
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(Hangup)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(Hangup)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(TerminateCall)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(TerminateCall)}");
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
        public virtual async Task<Response<TransferCallResponse>> TransferCallToParticipantAsync(CommunicationIdentifier targetParticipant, TransferCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                TransferToParticipantRequestInternal request = new TransferToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(targetParticipant));

                if (options != null)
                {
                    request.TransfereeCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                    request.UserToUserInformation = options.UserToUserInformation;
                    request.OperationContext = options.OperationContext;
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
        public virtual Response<TransferCallResponse> TransferCallToParticipant(CommunicationIdentifier targetParticipant, TransferCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                TransferToParticipantRequestInternal request = new TransferToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(targetParticipant));

                if (options != null)
                {
                    request.TransfereeCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                    request.UserToUserInformation = options.UserToUserInformation;
                    request.OperationContext = options.OperationContext;
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

        /// <summary> Add a participant to the call. </summary>
        /// <param name="participantsToAdd"> The list of identity of participants to be added to the call. </param>
        /// <param name="options">The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToAdd"/> is null. </exception>
        public virtual async Task<Response<AddParticipantsResponse>> AddParticipantAsync(IEnumerable<CommunicationIdentifier> participantsToAdd, AddParticipantsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                AddParticipantsRequestInternal request = new AddParticipantsRequestInternal(participantsToAdd.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                if (options != null)
                {
                    request.SourceCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                    request.OperationContext = options.OperationContext;
                    request.InvitationTimeoutInSeconds = options.InvitationTimeoutInSeconds;
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
        public virtual Response<AddParticipantsResponse> AddParticipant(IEnumerable<CommunicationIdentifier> participantsToAdd, AddParticipantsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                AddParticipantsRequestInternal request = new AddParticipantsRequestInternal(participantsToAdd.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                if (options != null)
                {
                    request.SourceCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                    request.OperationContext = options.OperationContext;
                    request.InvitationTimeoutInSeconds = options.InvitationTimeoutInSeconds;
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

        /// <summary> Get participant from a call. </summary>
        /// <param name="participant">The participant.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual async Task<Response<CallParticipant>> GetParticipantAsync(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var response = await RestClient.GetParticipantAsync(
                    callConnectionId: CallConnectionId,
                    CommunicationIdentifierSerializer.Serialize(participant),
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(new CallParticipant(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participant from a call. </summary>
        /// <param name="participant">The participant.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual Response<CallParticipant> GetParticipant(CommunicationIdentifier participant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var response = RestClient.GetParticipant(
                    callConnectionId: CallConnectionId,
                    CommunicationIdentifierSerializer.Serialize(participant),
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(new CallParticipant(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participants from a call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="IEnumerable{CallParticipant}"/>.</returns>
        public virtual async Task<Response<IReadOnlyList<CallParticipant>>> GetParticipantsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(GetParticipantsAsync)}");
            scope.Start();
            try
            {
                var response = await RestClient.GetParticipantsAsync(
                    callConnectionId: CallConnectionId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                IReadOnlyList<CallParticipant> result = response.Value.Select(t => new CallParticipant(t)).ToList();

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participants from a call. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="IEnumerable{CallParticipant}"/>.</returns>
        public virtual Response<IReadOnlyList<CallParticipant>> GetParticipants(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                var response = RestClient.GetParticipants(
                    callConnectionId: CallConnectionId,
                    cancellationToken: cancellationToken
                    );

                IReadOnlyList<CallParticipant> result = response.Value.Select(t => new CallParticipant(t)).ToList();

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove participants from the call. </summary>
        /// <param name="participantsToRemove"> The list of identity of participants to be removed from the call. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToRemove"/> is null. </exception>
        public virtual async Task<Response<RemoveParticipantsResponse>> RemoveParticipantsAsync(IEnumerable<CommunicationIdentifier> participantsToRemove, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                RemoveParticipantsRequestInternal request = new RemoveParticipantsRequestInternal(participantsToRemove.Select(t => CommunicationIdentifierSerializer.Serialize(t)));
                request.OperationContext = operationContext;

                return await RestClient.RemoveParticipantsAsync(
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

        /// <summary> Remove participants from the call. </summary>
        /// <param name="participantsToRemove"> The list of identity of participants to be removed from the call. </param>
        /// <param name="operationContext">The operation context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToRemove"/> is null. </exception>
        public virtual Response<RemoveParticipantsResponse> RemoveParticipants(IEnumerable<CommunicationIdentifier> participantsToRemove, string operationContext = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnectionClient)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                RemoveParticipantsRequestInternal request = new RemoveParticipantsRequestInternal(participantsToRemove.Select(t => CommunicationIdentifierSerializer.Serialize(t)));
                request.OperationContext = operationContext;

                return RestClient.RemoveParticipants(
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
