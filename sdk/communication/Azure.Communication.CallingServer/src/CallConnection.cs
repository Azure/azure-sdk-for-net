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
    /// The Azure Communication Services Call Connection Client.
    /// </summary>
    public class CallConnection
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal CallConnectionsRestClient RestClient { get; }
        internal ContentRestClient ContentRestClient { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallConnection(string callConnectionId, CallConnectionsRestClient callConnectionRestClient, ContentRestClient CallContentRestClient, ClientDiagnostics clientDiagnostics)
        {
            CallConnectionId = callConnectionId;
            RestClient = callConnectionRestClient;
            ContentRestClient = CallContentRestClient;
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="CallConnection"/> for mocking.</summary>
        protected CallConnection()
        {
            _clientDiagnostics = null;
            RestClient = null;
            ContentRestClient = null;
            CallConnectionId = null;
        }

        /// <summary> Get various properties of the call. <see cref="CallConnectionProperties"/>.</summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual async Task<Response<CallConnectionProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                var response = await RestClient.GetCallAsync(CallConnectionId, cancellationToken: cancellationToken).ConfigureAwait(false);

                return Response.FromValue(
                    new CallConnectionProperties(response.Value),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get various properties of a ongoing call. <see cref="CallConnectionProperties"/>.</summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public virtual Response<CallConnectionProperties> GetProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallingServerClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                var response = RestClient.GetCall(CallConnectionId, cancellationToken: cancellationToken);

                return Response.FromValue(
                    new CallConnectionProperties(response.Value),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Disconnect the current caller in a group-call or end a p2p-call.</summary>
        /// <param name="forEveryone"> If true, this will terminate the call and hang up on all participants in this call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> HangupAsync(bool forEveryone, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Hangup)}");
            scope.Start();
            try
            {
                if (forEveryone)
                {
                    return await RestClient.TerminateCallAsync(
                        callConnectionId: CallConnectionId,
                        cancellationToken: cancellationToken
                        ).ConfigureAwait(false);
                }
                else
                {
                    return await RestClient.HangupCallAsync(
                        callConnectionId: CallConnectionId,
                        cancellationToken: cancellationToken
                        ).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Disconnect the current caller in a group-call or end a p2p-call. </summary>
        /// <param name="forEveryone"> If true, this will terminate the call and hang up on all participants in this call. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response Hangup(bool forEveryone, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Hangup)}");
            scope.Start();
            try
            {
                if (forEveryone)
                {
                    return RestClient.TerminateCall(
                        callConnectionId: CallConnectionId,
                        cancellationToken: cancellationToken
                        );
                }
                else
                {
                    return RestClient.HangupCall(
                        callConnectionId: CallConnectionId,
                        cancellationToken: cancellationToken
                        );
                }
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
        public virtual async Task<Response<TransferCallToParticipantResult>> TransferCallToParticipantAsync(CommunicationIdentifier targetParticipant, TransferCallToParticipantOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                TransferToParticipantRequestInternal request = new TransferToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(targetParticipant));

                if (options != null)
                {
                    request.TransfereeCallerId = options.SourceCallerId == null ? null : new PhoneNumberIdentifierModel(options.SourceCallerId.PhoneNumber);
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
        public virtual Response<TransferCallToParticipantResult> TransferCallToParticipant(CommunicationIdentifier targetParticipant, TransferCallToParticipantOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                TransferToParticipantRequestInternal request = new TransferToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(targetParticipant));

                if (options != null)
                {
                    request.TransfereeCallerId = options.SourceCallerId == null ? null : new PhoneNumberIdentifierModel(options.SourceCallerId.PhoneNumber);
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

        /// <summary> Add participants to the call. </summary>
        /// <param name="participantsToAdd"> The list of identity of participants to be added to the call. </param>
        /// <param name="options">The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToAdd"/> is null. </exception>
        public virtual async Task<Response<AddParticipantsResult>> AddParticipantsAsync(IEnumerable<CommunicationIdentifier> participantsToAdd, AddParticipantsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                AddParticipantsRequestInternal request = new AddParticipantsRequestInternal(participantsToAdd.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                if (options != null)
                {
                    request.SourceCallerId = options.SourceCallerId == null ? null : new PhoneNumberIdentifierModel(options.SourceCallerId.PhoneNumber);
                    request.OperationContext = options.OperationContext;
                    request.InvitationTimeoutInSeconds = options.InvitationTimeoutInSeconds;
                }

                var response = await RestClient.AddParticipantAsync(
                    callConnectionId: CallConnectionId,
                    request,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                return Response.FromValue(new AddParticipantsResult(response), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Add participants to the call. </summary>
        /// <param name="participantsToAdd"> The list of identity of participants to be added to the call. </param>
        /// <param name="options">The options. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToAdd"/> is null. </exception>
        public virtual Response<AddParticipantsResult> AddParticipants(IEnumerable<CommunicationIdentifier> participantsToAdd, AddParticipantsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                AddParticipantsRequestInternal request = new AddParticipantsRequestInternal(participantsToAdd.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                if (options != null)
                {
                    request.SourceCallerId = options.SourceCallerId == null ? null : new PhoneNumberIdentifierModel(options.SourceCallerId.PhoneNumber);
                    request.OperationContext = options.OperationContext;
                    request.InvitationTimeoutInSeconds = options.InvitationTimeoutInSeconds;
                }

                var response = RestClient.AddParticipant(
                    callConnectionId: CallConnectionId,
                    request,
                    cancellationToken: cancellationToken
                    );

                return Response.FromValue(new AddParticipantsResult(response), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get participant from a call. </summary>
        /// <param name="participantMri">The participant's MRI.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual async Task<Response<CallParticipant>> GetParticipantAsync(string participantMri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var response = await RestClient.GetParticipantAsync(
                    callConnectionId: CallConnectionId,
                    participantMri,
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
        /// <param name="participantMri">The participant MRI.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual Response<CallParticipant> GetParticipant(string participantMri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var response = RestClient.GetParticipant(
                    callConnectionId: CallConnectionId,
                    participantMri,
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                var response = await RestClient.GetParticipantsAsync(
                    callConnectionId: CallConnectionId,
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

                IReadOnlyList<CallParticipant> result = response.Value.Values.Select(t => new CallParticipant(t)).ToList();

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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipants)}");
            scope.Start();
            try
            {
                var response = RestClient.GetParticipants(
                    callConnectionId: CallConnectionId,
                    cancellationToken: cancellationToken
                    );

                IReadOnlyList<CallParticipant> result = response.Value.Values.Select(t => new CallParticipant(t)).ToList();

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
        /// <param name="options"> Options for removing participants. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToRemove"/> is null. </exception>
        public virtual async Task<Response<RemoveParticipantsResult>> RemoveParticipantsAsync(IEnumerable<CommunicationIdentifier> participantsToRemove, RemoveParticipantsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                RemoveParticipantsRequestInternal request = new RemoveParticipantsRequestInternal(participantsToRemove.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                if (options != null)
                {
                    request.OperationContext = options.OperationContext;
                }

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
        /// <param name="options"> Options for removing participants. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToRemove"/> is null. </exception>
        public virtual Response<RemoveParticipantsResult> RemoveParticipants(IEnumerable<CommunicationIdentifier> participantsToRemove, RemoveParticipantsOptions options = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                RemoveParticipantsRequestInternal request = new RemoveParticipantsRequestInternal(participantsToRemove.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                if (options != null)
                {
                    request.OperationContext = options.OperationContext;
                }

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

        /// <summary>
        /// Plays a file async.
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns></returns>
        public virtual async Task<Response> PlayAsync(FileSource fileSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(fileSource, playTo);

                return await ContentRestClient.PlayAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Plays a file.
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="playTo"></param>
        /// <returns></returns>
        public virtual Response Play(FileSource fileSource, IEnumerable<CommunicationIdentifier> playTo, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(Play)}");
            scope.Start();
            try
            {
                PlayRequestInternal request = CreatePlayRequest(fileSource, playTo);

                return ContentRestClient.Play(CallConnectionId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static PlayRequestInternal CreatePlayRequest(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo)
        {
            if (playSource is FileSource fileSource)
            {
                PlaySourceInternal sourceInternal;
                sourceInternal = new PlaySourceInternal(PlaySourceTypeInternal.File);
                sourceInternal.FileSource = new FileSourceInternal(fileSource.FileUri.AbsoluteUri);
                sourceInternal.PlaySourceId = playSource.PlaySourceId;

                PlayRequestInternal request = new PlayRequestInternal(sourceInternal);
                request.PlayTo = playTo.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList();

                return request;
            }
            else
            {
                throw new NotSupportedException(playSource.GetType().Name);
            }
        }

        /// <summary>
        /// Play to all participants async.
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> PlayToAllAsync(FileSource fileSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return await PlayAsync(fileSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Play to all participants.
        /// </summary>
        /// <param name="fileSource"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response PlayToAll(FileSource fileSource, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(PlayToAll)}");
            scope.Start();
            try
            {
                return Play(fileSource, Enumerable.Empty<CommunicationIdentifier>(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancel any media operation to all participants.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> CancelAllMediaOperationsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return await ContentRestClient.CancelAllMediaOperationsAsync(CallConnectionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancel any media operation to all participants.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response CancelAllMediaOperations(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAllMediaOperations)}");
            scope.Start();
            try
            {
                return ContentRestClient.CancelAllMediaOperations(CallConnectionId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
