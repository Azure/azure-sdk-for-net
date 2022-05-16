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
        internal CallConnectionRestClient RestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallLegId { get; internal set; }

        internal CallConnection(string callLegId, CallConnectionRestClient callConnectionRestClient, ClientDiagnostics clientDiagnostics)
        {
            this.CallLegId = callLegId;
            this.RestClient = callConnectionRestClient;
            this._clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="CallingServerClient"/> for mocking.</summary>
        protected CallConnection()
        {
            _clientDiagnostics = null;
            RestClient = null;
            CallLegId = null;
        }

        /// <summary> Get call details. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallConnectionProperties"/>.</returns>
        public virtual async Task<Response<CallConnectionProperties>> GetCallAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetCall)}");
            scope.Start();
            try
            {
                Response<CallConnectionPropertiesInternal> callConnectionPropertiesInternal = await RestClient.GetCallAsync(
                                        callLegId: CallLegId,
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

        /// <summary> Get call details. </summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallConnectionProperties"/>.</returns>
        public virtual Response<CallConnectionProperties> GetCall(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetCall)}");
            scope.Start();
            try
            {
                Response<CallConnectionPropertiesInternal> callConnectionPropertiesInternal = RestClient.GetCall(
                        callLegId: CallLegId,
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

        /// <summary> Disconnect the current caller in a group-call or end a p2p-call.</summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> HangupAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Hangup)}");
            scope.Start();
            try
            {
                return await RestClient.HangUpCallAsync(
                    callLegId: CallLegId,
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
                return RestClient.HangUpCall(
                    callLegId: CallLegId,
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
        /// <param name="reason"> The reason of the terminate. </param>
        /// <param name="callbackUri"> The callback uri. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> TerminateCallAsync(string reason, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TerminateCall)}");
            scope.Start();
            try
            {
                TerminateCallRequest request = new TerminateCallRequest();
                request.Reason = reason;
                request.CallbackUri = callbackUri?.AbsoluteUri;

                return await RestClient.TerminateCallAsync(
                    callLegId: CallLegId,
                    terminateCallRequest: request,
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
        /// <param name="reason"> The reason of the terminate. </param>
        /// <param name="callbackUri"> The callback uri. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response TerminateCall(string reason, Uri callbackUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TerminateCall)}");
            scope.Start();
            try
            {
                TerminateCallRequest request = new TerminateCallRequest();
                request.Reason = reason;
                request.CallbackUri = callbackUri?.AbsoluteUri;

                return RestClient.TerminateCall(
                    callLegId: CallLegId,
                    terminateCallRequest: request,
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
        /// <param name="targetCallLegId"> The target call leg id to transfer to. </param>
        /// <param name="options">The transfer options. </param>
        /// <param name="callbackUri"> The callback uri. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> TransferCallAsync(CommunicationIdentifier targetParticipant, string targetCallLegId, Uri callbackUri, TransferCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCall)}");
            scope.Start();
            try
            {
                TransferCallRequestInternal request = new TransferCallRequestInternal();
                request.TargetParticipant = CommunicationIdentifierSerializer.Serialize(targetParticipant);
                request.TargetCallLegId = targetCallLegId;
                request.CallbackUri = callbackUri?.AbsoluteUri;
                request.UserToUserInformation = options.UserToUserInformation;
                request.AlternateCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);

                return await RestClient.TransferCallAsync(
                    callLegId: CallLegId,
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
        /// <param name="targetCallLegId"> The target call leg id to transfer to. </param>
        /// <param name="options">The transfer options. </param>
        /// <param name="callbackUri"> The callback uri. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response TransferCall(CommunicationIdentifier targetParticipant, string targetCallLegId, Uri callbackUri, TransferCallOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCall)}");
            scope.Start();
            try
            {
                TransferCallRequestInternal request = new TransferCallRequestInternal();
                request.TargetParticipant = CommunicationIdentifierSerializer.Serialize(targetParticipant);
                request.TargetCallLegId = targetCallLegId;
                request.CallbackUri = callbackUri?.AbsoluteUri;
                request.UserToUserInformation = options.UserToUserInformation;
                request.AlternateCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);

                return RestClient.TransferCall(
                    callLegId: CallLegId,
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

        /// <summary> Get participant from the call using <see cref="CommunicationIdentifier"/>. </summary>
        /// <param name="participantId"> The identity of participant. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual async Task<Response<CallParticipant>> GetParticipantAsync(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var callParticipantsInternal = await RestClient.GetParticipantAsync(
                                        callLegId: CallLegId,
                                        participantId: participantId,
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
        /// <param name="participantId"> The identity of participant. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual Response<CallParticipant> GetParticipant(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var callParticipantsInternal = RestClient.GetParticipant(
                                        callLegId: CallLegId,
                                        participantId: participantId,
                                        cancellationToken: cancellationToken
                                        );

                return Response.FromValue(new CallParticipant(callParticipantsInternal.Value), callParticipantsInternal.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Add a participant to the call. </summary>
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="callbackUri">The callback Uri.</param>
        /// <param name="options">The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participant"/> is null. </exception>
        public virtual async Task<Response> AddParticipantAsync(CommunicationIdentifier participant, Uri callbackUri, AddParticipantOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                AddParticipantRequestInternal request = new AddParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(participant));
                request.AlternateCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                request.OperationContext = options.OperationContext;
                request.CallbackUri = callbackUri?.AbsoluteUri;

                return await RestClient.AddParticipantAsync(
                    callLegId: CallLegId,
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
        /// <param name="participant"> The identity of participant to be added to the call. </param>
        /// <param name="callbackUri">The callback Uri.</param>
        /// <param name="options">The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participant"/> is null. </exception>
        public virtual Response AddParticipant(CommunicationIdentifier participant, Uri callbackUri, AddParticipantOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                AddParticipantRequestInternal request = new AddParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(participant));
                request.AlternateCallerId = options.AlternateCallerId == null ? null : new PhoneNumberIdentifierModel(options.AlternateCallerId.PhoneNumber);
                request.OperationContext = options.OperationContext;
                request.CallbackUri = callbackUri?.AbsoluteUri;

                return RestClient.AddParticipant(
                    callLegId: CallLegId,
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

        /// <summary> Get participants of the call. </summary>
        /// <param name="continuationToken"> The continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="IEnumerable{CallParticipant}"/>.</returns>
        public virtual AsyncPageable<CallParticipant> GetParticipantsAsync(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<CallParticipant>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipants)}");
                scope.Start();
                try
                {
                    Response<CallParticipantCollectionInternal> response = await RestClient
                        .ListParticipantAsync(CallLegId, maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);

                    return Page.FromValues(response.Value.Value.Select(x => new CallParticipant(x)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<CallParticipant>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipants)}");
                scope.Start();
                try
                {
                    Response<CallParticipantCollectionInternal> response = await RestClient
                        .ListParticipantNextPageAsync(nextLink, CallLegId, maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new CallParticipant(x)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get participants of the call. </summary>
        /// <param name="continuationToken"> The continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="IEnumerable{CallParticipant}"/>.</returns>
        public virtual Pageable<CallParticipant> GetParticipants(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Page<CallParticipant> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipants)}");
                scope.Start();
                try
                {
                    var response =  RestClient
                        .ListParticipant(CallLegId, maxPageSize, continuationToken, cancellationToken);

                    return Page.FromValues(response.Value.Value.Select(x => new CallParticipant(x)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<CallParticipant> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipants)}");
                scope.Start();
                try
                {
                    var response = RestClient
                        .ListParticipantNextPage(nextLink, CallLegId, maxPageSize, continuationToken, cancellationToken);

                    return Page.FromValues(response.Value.Value.Select(x => new CallParticipant(x)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Remove a participant from the call. </summary>
        /// <param name="participantId"> The identity of participant to be removed from the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> RemoveParticipantAsync(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                return await RestClient.RemoveParticipantAsync(
                    callLegId: CallLegId,
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

        /// <summary> Remove a participant from the call. </summary>
        /// <param name="participantId"> The identity of participant to be removed from the call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response RemoveParticipant(string participantId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                return RestClient.RemoveParticipant(
                    callLegId: CallLegId,
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
    }
}
