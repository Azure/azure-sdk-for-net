// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
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
        public virtual async Task<Response<CallConnectionProperties>> GetCallConnectionPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(GetCallConnectionProperties)}");
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
        public virtual Response<CallConnectionProperties> GetCallConnectionProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallAutomationClient)}.{nameof(GetCallConnectionProperties)}");
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
        /// <param name="repeatabilityRequestId"> Only used if terminating a call. If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-Id and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-Id is an opaque string representing a client-generated unique identifier for the request. It is a version 4 (random) UUID. </param>
        /// <param name="repeatabilityFirstSent"> Only used if terminating a call. If Repeatability-Request-ID header is specified, then Repeatability-First-Sent header must also be specified. The value should be the date and time at which the request was first created, expressed using the IMF-fixdate form of HTTP-date. Example: Sun, 06 Nov 1994 08:49:37 GMT.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentException"><paramref name="repeatabilityRequestId"/> <paramref name="repeatabilityFirstSent"/> Repeatability headers are set incorrectly.</exception>
        public virtual async Task<Response> HangUpAsync(bool forEveryone, Guid? repeatabilityRequestId = null, string repeatabilityFirstSent = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(HangUp)}");
            scope.Start();
            try
            {
                if (forEveryone)
                {
                    var repeatabilityHeaders = new RepeatabilityHeaders
                    {
                        RepeatabilityRequestId = repeatabilityRequestId,
                        RepeatabilityFirstSent = repeatabilityFirstSent
                    };
                    if (!repeatabilityHeaders.IsValidRepeatabilityHeaders())
                        throw new ArgumentException(CallAutomationErrorMessages.InvalidRepeatabilityHeadersMessage);

                    return await RestClient.TerminateCallAsync(
                        CallConnectionId,
                        repeatabilityRequestId,
                        repeatabilityFirstSent,
                        cancellationToken
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
        /// <param name="repeatabilityRequestId"> Only used if terminating a call. If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-Id and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-Id is an opaque string representing a client-generated unique identifier for the request. It is a version 4 (random) UUID. </param>
        /// <param name="repeatabilityFirstSent"> Only used if terminating a call. If Repeatability-Request-ID header is specified, then Repeatability-First-Sent header must also be specified. The value should be the date and time at which the request was first created, expressed using the IMF-fixdate form of HTTP-date. Example: Sun, 06 Nov 1994 08:49:37 GMT.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentException"><paramref name="repeatabilityRequestId"/> <paramref name="repeatabilityFirstSent"/> Repeatability headers are set incorrectly.</exception>
        public virtual Response HangUp(bool forEveryone, Guid? repeatabilityRequestId = null, string repeatabilityFirstSent = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(HangUp)}");
            scope.Start();
            try
            {
                if (forEveryone)
                {
                    var repeatabilityHeaders = new RepeatabilityHeaders
                    {
                        RepeatabilityRequestId = repeatabilityRequestId,
                        RepeatabilityFirstSent = repeatabilityFirstSent
                    };
                    if (!repeatabilityHeaders.IsValidRepeatabilityHeaders())
                        throw new ArgumentException(CallAutomationErrorMessages.InvalidRepeatabilityHeadersMessage);

                    return RestClient.TerminateCall(
                        CallConnectionId,
                        repeatabilityRequestId,
                        repeatabilityFirstSent,
                        cancellationToken
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
        /// <param name="options"> Options for the Transfer Call To Participant operation. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
        public virtual async Task<Response<TransferCallToParticipantResult>> TransferCallToParticipantAsync(TransferToParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));
                if (!options.IsValidRepeatabilityHeaders())
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidRepeatabilityHeadersMessage);

                TransferToParticipantRequestInternal request = CreateTransferToParticipantRequest(options);;

                return await RestClient.TransferToParticipantAsync(
                    CallConnectionId,
                    request,
                    options.RepeatabilityRequestId,
                    options.RepeatabilityFirstSent,
                    cancellationToken
                    ).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Transfer the call. </summary>
        /// <param name="options"> Options for the Transfer Call To Participant operation. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
        public virtual Response<TransferCallToParticipantResult> TransferCallToParticipant(TransferToParticipantOptions options,CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));
                if (!options.IsValidRepeatabilityHeaders())
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidRepeatabilityHeadersMessage);

                TransferToParticipantRequestInternal request = CreateTransferToParticipantRequest(options);

                return RestClient.TransferToParticipant(
                    CallConnectionId,
                    request,
                    options.RepeatabilityRequestId,
                    options.RepeatabilityFirstSent,
                    cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static TransferToParticipantRequestInternal CreateTransferToParticipantRequest(TransferToParticipantOptions options)
        {
            TransferToParticipantRequestInternal request = new TransferToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(options.TargetParticipant));

            request.TransfereeCallerId = options.SourceCallerId == null ? null : new PhoneNumberIdentifierModel(options.SourceCallerId.PhoneNumber);
            request.UserToUserInformation = options.UserToUserInformation;
            request.OperationContext = options.OperationContext;

            return request;
        }

        /// <summary> Add participants to the call. </summary>
        /// <param name="options"> Options for the Add Participants operation.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> Repeatability headers are set incorrectly.</exception>
        public virtual async Task<Response<AddParticipantsResult>> AddParticipantsAsync(AddParticipantsOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));
                if (!options.IsValidRepeatabilityHeaders())
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidRepeatabilityHeadersMessage);

                AddParticipantsRequestInternal request = CreateAddParticipantRequest(options);

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
        /// <param name="options"> Options for the Add Participants operation.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<AddParticipantsResult> AddParticipants(AddParticipantsOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipants)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));
                if (!options.IsValidRepeatabilityHeaders())
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidRepeatabilityHeadersMessage);

                AddParticipantsRequestInternal request = CreateAddParticipantRequest(options);

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

        private static AddParticipantsRequestInternal CreateAddParticipantRequest(AddParticipantsOptions options)
        {
            AddParticipantsRequestInternal request = new AddParticipantsRequestInternal(options.ParticipantsToAdd.Select(t => CommunicationIdentifierSerializer.Serialize(t)).ToList());

            request.SourceCallerId = options.SourceCallerId == null ? null : new PhoneNumberIdentifierModel(options.SourceCallerId.PhoneNumber);
            request.OperationContext = options.OperationContext;
            request.InvitationTimeoutInSeconds = options.InvitationTimeoutInSeconds;

            return request;
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
        /// <param name="operationContext"> The Operation Context. </param>
        /// <param name="repeatabilityRequestId"> If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-Id and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-Id is an opaque string representing a client-generated unique identifier for the request. It is a version 4 (random) UUID. </param>
        /// <param name="repeatabilityFirstSent"> If Repeatability-Request-ID header is specified, then Repeatability-First-Sent header must also be specified. The value should be the date and time at which the request was first created, expressed using the IMF-fixdate form of HTTP-date. Example: Sun, 06 Nov 1994 08:49:37 GMT.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToRemove"/> is null. </exception>
        /// <exception cref="ArgumentException"><paramref name="repeatabilityRequestId"/> <paramref name="repeatabilityFirstSent"/> Repeatability headers are set incorrectly.</exception>
        public virtual async Task<Response<RemoveParticipantsResult>> RemoveParticipantsAsync(IEnumerable<CommunicationIdentifier> participantsToRemove, string operationContext = default, Guid? repeatabilityRequestId = null, string repeatabilityFirstSent = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                var repeatabilityHeaders = new RepeatabilityHeaders
                {
                    RepeatabilityRequestId = repeatabilityRequestId,
                    RepeatabilityFirstSent = repeatabilityFirstSent
                };
                if (!repeatabilityHeaders.IsValidRepeatabilityHeaders())
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidRepeatabilityHeadersMessage);

                RemoveParticipantsRequestInternal request = new RemoveParticipantsRequestInternal(participantsToRemove.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                request.OperationContext = operationContext;

                return await RestClient.RemoveParticipantsAsync(
                    CallConnectionId,
                    request,
                    repeatabilityRequestId,
                    repeatabilityFirstSent,
                    cancellationToken
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
        /// <param name="operationContext"> The Operation Context. </param>
        /// <param name="repeatabilityRequestId"> If specified, the client directs that the request is repeatable; that is, that the client can make the request multiple times with the same Repeatability-Request-Id and get back an appropriate response without the server executing the request multiple times. The value of the Repeatability-Request-Id is an opaque string representing a client-generated unique identifier for the request. It is a version 4 (random) UUID. </param>
        /// <param name="repeatabilityFirstSent"> If Repeatability-Request-ID header is specified, then Repeatability-First-Sent header must also be specified. The value should be the date and time at which the request was first created, expressed using the IMF-fixdate form of HTTP-date. Example: Sun, 06 Nov 1994 08:49:37 GMT.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantsToRemove"/> is null. </exception>
        /// <exception cref="ArgumentException"><paramref name="repeatabilityRequestId"/> <paramref name="repeatabilityFirstSent"/> Repeatability headers are set incorrectly.</exception>
        public virtual Response<RemoveParticipantsResult> RemoveParticipants(IEnumerable<CommunicationIdentifier> participantsToRemove, string operationContext = default, Guid? repeatabilityRequestId = null, string repeatabilityFirstSent = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipants)}");
            scope.Start();
            try
            {
                var repeatabilityHeaders = new RepeatabilityHeaders
                {
                    RepeatabilityRequestId = repeatabilityRequestId,
                    RepeatabilityFirstSent = repeatabilityFirstSent
                };
                if (!repeatabilityHeaders.IsValidRepeatabilityHeaders())
                    throw new ArgumentException(CallAutomationErrorMessages.InvalidRepeatabilityHeadersMessage);

                RemoveParticipantsRequestInternal request = new RemoveParticipantsRequestInternal(participantsToRemove.Select(t => CommunicationIdentifierSerializer.Serialize(t)));

                request.OperationContext = operationContext;

               return RestClient.RemoveParticipants(
                    CallConnectionId,
                    request,
                    repeatabilityRequestId,
                    repeatabilityFirstSent,
                    cancellationToken
                    );
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Initializes a new instance of CallContent. <see cref="CallMedia"/>.</summary>
        public virtual CallMedia GetCallMedia()
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetCallMedia)}");
            scope.Start();
            try
            {
                return new CallMedia(CallConnectionId, ContentRestClient, _clientDiagnostics);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
