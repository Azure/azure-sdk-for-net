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
        internal CallConnectionRestClient RestClient { get; }
        internal CallMediaRestClient CallMediaRestClient { get; }
        internal CallAutomationEventProcessor EventProcessor { get; }

        /// <summary>
        /// The call connection id.
        /// </summary>
        public virtual string CallConnectionId { get; internal set; }

        internal CallConnection(string callConnectionId, CallConnectionRestClient callConnectionRestClient, CallMediaRestClient callCallMediaRestClient, ClientDiagnostics clientDiagnostics, CallAutomationEventProcessor eventProcessor)
        {
            CallConnectionId = callConnectionId;
            RestClient = callConnectionRestClient;
            CallMediaRestClient = callCallMediaRestClient;
            _clientDiagnostics = clientDiagnostics;
            EventProcessor = eventProcessor;
        }

        /// <summary>Initializes a new instance of <see cref="CallConnection"/> for mocking.</summary>
        protected CallConnection()
        {
            _clientDiagnostics = null;
            RestClient = null;
            CallMediaRestClient = null;
            CallConnectionId = null;
        }

        /// <summary> Get various properties of the call. <see cref="CallConnectionProperties"/>.</summary>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
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
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
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
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> HangUpAsync(bool forEveryone, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(HangUp)}");
            scope.Start();
            try
            {
                if (forEveryone)
                {
                    return await RestClient.TerminateCallAsync(CallConnectionId, cancellationToken).ConfigureAwait(false);
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
        public virtual Response HangUp(bool forEveryone, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(HangUp)}");
            scope.Start();
            try
            {
                if (forEveryone)
                {
                    return RestClient.TerminateCall(CallConnectionId, cancellationToken);
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
        /// <param name="targetParticipant"> The target to transfer the call to. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targetParticipant"/> is null.</exception>
        public virtual async Task<Response<TransferCallToParticipantResult>> TransferCallToParticipantAsync(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            if (targetParticipant == null)
                throw new ArgumentNullException(nameof(targetParticipant));

            TransferToParticipantOptions options;

            if (targetParticipant is CommunicationUserIdentifier)
            {
                options = new TransferToParticipantOptions(targetParticipant as CommunicationUserIdentifier);
            }
            else if (targetParticipant is PhoneNumberIdentifier)
            {
                options = new TransferToParticipantOptions(targetParticipant as PhoneNumberIdentifier);
            }
            else if (targetParticipant is MicrosoftTeamsUserIdentifier)
            {
                options = new TransferToParticipantOptions(targetParticipant as MicrosoftTeamsUserIdentifier);
            }
            else
            {
                throw new ArgumentException("targetParticipant type is invalid.", nameof(targetParticipant));
            }

            return await TransferCallToParticipantAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Transfer this call to a participant. </summary>
        /// <param name="options"> Options for the Transfer Call To Participant operation. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentNullException"> SourceCallerId is null in <paramref name="options"/> when transferring the call to a PSTN target.</exception>
        public virtual async Task<Response<TransferCallToParticipantResult>> TransferCallToParticipantAsync(TransferToParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                TransferToParticipantRequestInternal request = CreateTransferToParticipantRequest(options);

                var response = await RestClient.TransferToParticipantAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = response.Value;
                result.SetEventProcessor(EventProcessor, CallConnectionId, result.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Transfer this call to a participant. </summary>
        /// <param name="targetParticipant"> The target to transfer the call to. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="targetParticipant"/> is null.</exception>
        public virtual Response<TransferCallToParticipantResult> TransferCallToParticipant(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            if (targetParticipant == null)
                throw new ArgumentNullException(nameof(targetParticipant));

            TransferToParticipantOptions options;

            if (targetParticipant is CommunicationUserIdentifier)
            {
                options = new TransferToParticipantOptions(targetParticipant as CommunicationUserIdentifier);
            }
            else if (targetParticipant is PhoneNumberIdentifier)
            {
                options = new TransferToParticipantOptions(targetParticipant as PhoneNumberIdentifier);
            }
            else if (targetParticipant is MicrosoftTeamsUserIdentifier)
            {
                options = new TransferToParticipantOptions(targetParticipant as MicrosoftTeamsUserIdentifier);
            }
            else
            {
                throw new ArgumentException("targetParticipant type is invalid.", nameof(targetParticipant));
            }

            return TransferCallToParticipant(options, cancellationToken);
        }

        /// <summary> Transfer the call. </summary>
        /// <param name="options"> Options for the Transfer Call To Participant operation. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="ArgumentNullException"> SourceCallerId is null in <paramref name="options"/> when transferring the call to a PSTN target.</exception>
        public virtual Response<TransferCallToParticipantResult> TransferCallToParticipant(TransferToParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(TransferCallToParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                TransferToParticipantRequestInternal request = CreateTransferToParticipantRequest(options);

                var response = RestClient.TransferToParticipant(CallConnectionId, request, cancellationToken);

                var result = response.Value;
                result.SetEventProcessor(EventProcessor, CallConnectionId, result.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static TransferToParticipantRequestInternal CreateTransferToParticipantRequest(TransferToParticipantOptions options)
        {
            TransferToParticipantRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.Target))
            {
                CustomCallingContext = new CustomCallingContextInternal(
                options.CustomCallingContext?.VoipHeaders ?? new ChangeTrackingDictionary<string, string>(),
                options.CustomCallingContext?.SipHeaders ?? new ChangeTrackingDictionary<string, string>()),
                OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext,
                Transferee = options.Transferee == default ? null : CommunicationIdentifierSerializer_2025_06_30.Serialize(options.Transferee),
                OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri,
                SourceCallerIdNumber = options.SourceCallerIdNumber == null ? null : new PhoneNumberIdentifierModel(options.SourceCallerIdNumber.PhoneNumber)
            };

            return request;
        }

        /// <summary>
        /// Add participant to the call.
        /// </summary>
        /// <param name="participantToAdd">Participant to add.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantToAdd"/> is null. </exception>
        /// <returns></returns>
        public virtual async Task<Response<AddParticipantResult>> AddParticipantAsync(CallInvite participantToAdd, CancellationToken cancellationToken = default)
        {
            return await AddParticipantAsync(new AddParticipantOptions(participantToAdd), cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Add participant to the call. </summary>
        /// <param name="options"> Options for the Add Participants operation.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<AddParticipantResult>> AddParticipantAsync(AddParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                AddParticipantRequestInternal request = CreateAddParticipantRequest(options);

                var response = await RestClient.AddParticipantAsync(callConnectionId: CallConnectionId, request, cancellationToken: cancellationToken).ConfigureAwait(false);

                var result = new AddParticipantResult(response);
                result.SetEventProcessor(EventProcessor, CallConnectionId, result.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
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
        /// <param name="participantToAdd">Participant to add.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantToAdd"/> is null. </exception>
        /// <returns></returns>
        public virtual Response<AddParticipantResult> AddParticipant(CallInvite participantToAdd, CancellationToken cancellationToken = default) =>
            AddParticipant(new AddParticipantOptions(participantToAdd), cancellationToken);

        /// <summary> Add participant to the call. </summary>
        /// <param name="options"> Options for the Add Participants operation.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<AddParticipantResult> AddParticipant(AddParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(AddParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                AddParticipantRequestInternal request = CreateAddParticipantRequest(options);

                var response = RestClient.AddParticipant(callConnectionId: CallConnectionId, request, cancellationToken: cancellationToken);

                var result = new AddParticipantResult(response);
                result.SetEventProcessor(EventProcessor, CallConnectionId, result.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static AddParticipantRequestInternal CreateAddParticipantRequest(AddParticipantOptions options)
        {
            // validate ParticipantToAdd is not null
            Argument.AssertNotNull(options.ParticipantToAdd, nameof(options.ParticipantToAdd));

            AddParticipantRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.ParticipantToAdd.Target))
            {
                CustomCallingContext = new CustomCallingContextInternal(
                    options.ParticipantToAdd.CustomCallingContext?.VoipHeaders ?? new ChangeTrackingDictionary<string, string>(),
                    options.ParticipantToAdd.CustomCallingContext?.SipHeaders ?? new ChangeTrackingDictionary<string, string>()),
                SourceCallerIdNumber = options.ParticipantToAdd.SourceCallerIdNumber == null
                    ? null
                    : new PhoneNumberIdentifierModel(options.ParticipantToAdd.SourceCallerIdNumber.PhoneNumber),
                SourceDisplayName = options.ParticipantToAdd.SourceDisplayName,
                OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext,
                InvitationTimeoutInSeconds = options.InvitationTimeoutInSeconds,
                OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri
            };

            return request;
        }

        /// <summary> Get participant from a call. </summary>
        /// <param name="participantIdentifier">The participant's identifier.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantIdentifier"/> is null. </exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual async Task<Response<CallParticipant>> GetParticipantAsync(CommunicationIdentifier participantIdentifier, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var response = await RestClient.GetParticipantAsync(
                    callConnectionId: CallConnectionId,
                    participantIdentifier.RawId,
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
        /// <param name="participantIdentifier">The participant identifier.</param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantIdentifier"/> is null. </exception>
        /// <returns>The <see cref="CallParticipant"/>.</returns>
        public virtual Response<CallParticipant> GetParticipant(CommunicationIdentifier participantIdentifier, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(GetParticipant)}");
            scope.Start();
            try
            {
                var response = RestClient.GetParticipant(
                    callConnectionId: CallConnectionId,
                    participantIdentifier.RawId,
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

                IReadOnlyList<CallParticipant> result = response.Value.Value.Select(t => new CallParticipant(t)).ToList();

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

                IReadOnlyList<CallParticipant> result = response.Value.Value.Select(t => new CallParticipant(t)).ToList();

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove participants from the call. </summary>
        /// <param name="participantToRemove"> The list of identity of participants to be removed from the call. </param>
        /// <param name="operationContext"> The Operation Context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantToRemove"/> is null. </exception>
        public virtual async Task<Response<RemoveParticipantResult>> RemoveParticipantAsync(CommunicationIdentifier participantToRemove, string operationContext = default, CancellationToken cancellationToken = default)
        {
            RemoveParticipantOptions options = new(participantToRemove)
            {
                OperationContext = operationContext == default ? Guid.NewGuid().ToString() : operationContext
            };

            return await RemoveParticipantAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Remove participants from the call. </summary>
        /// <param name="options">Options for the RemoveParticipants operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual async Task<Response<RemoveParticipantResult>> RemoveParticipantAsync(RemoveParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                // validate RequestInitiator is not null or empty
                Argument.AssertNotNull(options.ParticipantToRemove, nameof(options.ParticipantToRemove));

                RemoveParticipantRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.ParticipantToRemove));

                request.OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext;

                request.OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri;
                var response = await RestClient.RemoveParticipantAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);

                var result = new RemoveParticipantResult(response);
                result.SetEventProcessor(EventProcessor, CallConnectionId, result.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Remove participants from the call. </summary>
        /// <param name="participantToRemove"> The list of identity of participants to be removed from the call. </param>
        /// <param name="operationContext"> The Operation Context. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="participantToRemove"/> is null. </exception>
        public virtual Response<RemoveParticipantResult> RemoveParticipant(CommunicationIdentifier participantToRemove, string operationContext = default, CancellationToken cancellationToken = default)
        {
            RemoveParticipantOptions options = new(participantToRemove)
            {
                OperationContext = operationContext == default ? Guid.NewGuid().ToString() : operationContext
            };

            return RemoveParticipant(options, cancellationToken);
        }

        /// <summary> Remove participants from the call. </summary>
        /// <param name="options">Options for the RemoveParticipants operations.</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        public virtual Response<RemoveParticipantResult> RemoveParticipant(RemoveParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(RemoveParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                RemoveParticipantRequestInternal request = new(CommunicationIdentifierSerializer_2025_06_30.Serialize(options.ParticipantToRemove));

                options.OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext;

                request.OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri;
                var response = RestClient.RemoveParticipant(CallConnectionId, request, cancellationToken);

                var result = new RemoveParticipantResult(response);
                result.SetEventProcessor(EventProcessor, CallConnectionId, result.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
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
                return new CallMedia(CallConnectionId, CallMediaRestClient, _clientDiagnostics, EventProcessor);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Mute participant from the call.
        /// Only Acs Users are currently supported.
        /// </summary>
        /// <param name="targetParticipant">Participant to mute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="targetParticipant"/> is null. </exception>
        /// <returns>A Response containing MuteParticipantResult.</returns>
        public virtual Response<MuteParticipantResult> MuteParticipant(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(MuteParticipant)}");
            scope.Start();
            try
            {
                MuteParticipantsRequestInternal request = new(new List<CommunicationIdentifierModel>() { CommunicationIdentifierSerializer_2025_06_30.Serialize(targetParticipant) });

                var response = RestClient.Mute(
                    CallConnectionId,
                    request,
                    cancellationToken);

                return Response.FromValue(new MuteParticipantResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Mute participants from the call.
        /// Only Acs Users are currently supported.
        /// </summary>
        /// <param name="options">Options for the MuteParticipant operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns>A Response containing MuteParticipantResult. </returns>
        public virtual Response<MuteParticipantResult> MuteParticipant(MuteParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(MuteParticipant)}");
            scope.Start();
            try
            {
                MuteParticipantsRequestInternal request = new(new List<CommunicationIdentifierModel>() { CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant) });

                var response = RestClient.Mute(
                    CallConnectionId,
                    request,
                    cancellationToken);

                return Response.FromValue(new MuteParticipantResult(response.Value.OperationContext), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Mute participants on the call.
        /// Only Acs Users are currently supported.
        /// </summary>
        /// <param name="targetParticipant">Participants to mute.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetParticipant"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public async virtual Task<Response<MuteParticipantResult>> MuteParticipantAsync(CommunicationIdentifier targetParticipant, CancellationToken cancellationToken = default)
        {
            var options = new MuteParticipantOptions(targetParticipant);

            return await MuteParticipantAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Mute participants on the call.
        /// </summary>
        /// <param name="options">Options for the MuteParticipant operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="options"/> OperationContext is too long. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public async virtual Task<Response<MuteParticipantResult>> MuteParticipantAsync(MuteParticipantOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(MuteParticipant)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                MuteParticipantsRequestInternal request = new(new List<CommunicationIdentifierModel>() { CommunicationIdentifierSerializer_2025_06_30.Serialize(options.TargetParticipant) });

                request.OperationContext = options.OperationContext;

                return await RestClient.MuteAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancel add participant operation.
        /// </summary>
        /// <param name="invitationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<Response<CancelAddParticipantOperationResult>> CancelAddParticipantOperationAsync(string invitationId, CancellationToken cancellationToken = default)
        {
            return CancelAddParticipantOperationAsync(new CancelAddParticipantOperationOptions(invitationId), cancellationToken);
        }

        /// <summary>
        /// Cancel add participant operation.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async virtual Task<Response<CancelAddParticipantOperationResult>> CancelAddParticipantOperationAsync(CancelAddParticipantOperationOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAddParticipantOperation)}");
            scope.Start();

            try
            {
                if (options == null)
                {
                    throw new ArgumentNullException(nameof(options));
                }

                var request = new CancelAddParticipantRequestInternal(options.InvitationId)
                {
                    OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext,
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri,
                };
                var response = await RestClient.CancelAddParticipantAsync(CallConnectionId, request, cancellationToken).ConfigureAwait(false);
                var result = new CancelAddParticipantOperationResult(response);
                result.SetEventProcessor(EventProcessor, CallConnectionId, result.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancel add participant operation.
        /// </summary>
        /// <param name="invitationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<CancelAddParticipantOperationResult> CancelAddParticipantOperation(string invitationId, CancellationToken cancellationToken = default)
        {
            return CancelAddParticipantOperation(new CancelAddParticipantOperationOptions(invitationId), cancellationToken);
        }

        /// <summary>
        /// Cancel add participant operation.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<CancelAddParticipantOperationResult> CancelAddParticipantOperation(CancelAddParticipantOperationOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(CancelAddParticipantOperation)}");
            scope.Start();

            try
            {
                if (options == null)
                {
                    throw new ArgumentNullException(nameof(options));
                }

                var request = new CancelAddParticipantRequestInternal(options.InvitationId)
                {
                    OperationContext = options.OperationContext,
                    OperationCallbackUri = options.OperationCallbackUri?.AbsoluteUri,
                };
                var response = RestClient.CancelAddParticipant(CallConnectionId, request, cancellationToken);
                var result = new CancelAddParticipantOperationResult(response);
                result.SetEventProcessor(EventProcessor, CallConnectionId, result.OperationContext);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
