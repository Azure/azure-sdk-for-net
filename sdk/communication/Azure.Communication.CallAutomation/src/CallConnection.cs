﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
                    var repeatabilityHeaders = new RepeatabilityHeaders();
                    return await RestClient.TerminateCallAsync(
                        CallConnectionId,
                        repeatabilityHeaders.RepeatabilityRequestId,
                        repeatabilityHeaders.GetRepeatabilityFirstSentString(),
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
                    var repeatabilityHeaders = new RepeatabilityHeaders();
                    return RestClient.TerminateCall(
                        CallConnectionId,
                        repeatabilityHeaders.RepeatabilityRequestId,
                        repeatabilityHeaders.GetRepeatabilityFirstSentString(),
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
                var repeatabilityHeaders = new RepeatabilityHeaders();

                var response = await RestClient.TransferToParticipantAsync(
                    CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    ).ConfigureAwait(false);

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
                var repeatabilityHeaders = new RepeatabilityHeaders();

                var response = RestClient.TransferToParticipant(
                    CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken
                    );

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
            TransferToParticipantRequestInternal request = new TransferToParticipantRequestInternal(CommunicationIdentifierSerializer.Serialize(options.Target));

            request.CustomContext = new CustomContextInternal(
                options.SipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.SipHeaders,
                options.VoipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.VoipHeaders);

            if (options.OperationContext != null && options.OperationContext.Length > CallAutomationConstants.InputValidation.StringMaxLength)
            {
                throw new ArgumentException(CallAutomationErrorMessages.OperationContextExceedsMaxLength);
            }
            else
            {
                request.OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext;
            }

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
                var repeatabilityHeaders = new RepeatabilityHeaders();

                var response = await RestClient.AddParticipantAsync(
                    callConnectionId: CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken: cancellationToken
                    ).ConfigureAwait(false);

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
                var repeatabilityHeaders = new RepeatabilityHeaders();

                var response = RestClient.AddParticipant(
                    callConnectionId: CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken: cancellationToken
                    );

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

            AddParticipantRequestInternal request = new(CommunicationIdentifierSerializer.Serialize(options.ParticipantToAdd.Target))
            {
                SourceCallerIdNumber = options.ParticipantToAdd.SourceCallerIdNumber == null
                    ? null
                    : new PhoneNumberIdentifierModel(options.ParticipantToAdd.SourceCallerIdNumber.PhoneNumber),
                SourceDisplayName = options.ParticipantToAdd.SourceDisplayName,
                OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext
            };

            if (options.InvitationTimeoutInSeconds != null &&
                (options.InvitationTimeoutInSeconds < CallAutomationConstants.InputValidation.MinInvitationTimeoutInSeconds ||
                options.InvitationTimeoutInSeconds > CallAutomationConstants.InputValidation.MaxInvitationTimeoutInSeconds))
            {
                throw new ArgumentException(CallAutomationErrorMessages.InvalidInvitationTimeoutInSeconds);
            }
            else
            {
                request.InvitationTimeoutInSeconds = options.InvitationTimeoutInSeconds;
            }

            request.CustomContext = new CustomContextInternal(
                options.ParticipantToAdd.SipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.ParticipantToAdd.SipHeaders,
                options.ParticipantToAdd.VoipHeaders == null ? new ChangeTrackingDictionary<string, string>() : options.ParticipantToAdd.VoipHeaders);

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

                RemoveParticipantRequestInternal request = new(CommunicationIdentifierSerializer.Serialize(options.ParticipantToRemove));
                var repeatabilityHeaders = new RepeatabilityHeaders();
                if (options.OperationContext != null && options.OperationContext.Length > CallAutomationConstants.InputValidation.StringMaxLength)
                {
                    throw new ArgumentException(CallAutomationErrorMessages.OperationContextExceedsMaxLength);
                }
                else
                {
                    request.OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext;
                }

                var response = await RestClient.RemoveParticipantAsync(
                    CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken).ConfigureAwait(false);

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

                RemoveParticipantRequestInternal request = new(CommunicationIdentifierSerializer.Serialize(options.ParticipantToRemove));
                var repeatabilityHeaders = new RepeatabilityHeaders();

                if (options.OperationContext != null && options.OperationContext.Length > CallAutomationConstants.InputValidation.StringMaxLength)
                {
                    throw new ArgumentException(CallAutomationErrorMessages.OperationContextExceedsMaxLength);
                }
                else
                {
                    options.OperationContext = options.OperationContext == default ? Guid.NewGuid().ToString() : options.OperationContext;
                }

                var response = RestClient.RemoveParticipant(
                    CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken);

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
        /// <param name="operationContext">The Operation Context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="targetParticipant"/> is null. </exception>
        /// <returns>A Response containing MuteParticipantsResponse.</returns>
        public virtual Response<MuteParticipantsResponse> MuteParticipants(CommunicationIdentifier targetParticipant, string operationContext = default, CancellationToken cancellationToken = default)
        {
            var options = new MuteParticipantsOptions(new List<CommunicationIdentifier> { targetParticipant })
            {
                OperationContext = operationContext
            };

            return MuteParticipants(options, cancellationToken);
        }

        /// <summary>
        /// Mute participants from the call.
        /// Only Acs Users are currently supported.
        /// </summary>
        /// <param name="options">Options for the MuteParticipant operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns>A Response containing MuteParticipantsResponse. </returns>
        public virtual Response<MuteParticipantsResponse> MuteParticipants(MuteParticipantsOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(MuteParticipants)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                MuteParticipantsRequestInternal request = new MuteParticipantsRequestInternal(
                    options.TargetParticipants.Select(participant => CommunicationIdentifierSerializer.Serialize(participant)));
                var repeatabilityHeaders = new RepeatabilityHeaders();

                if (options.OperationContext != null && options.OperationContext.Length > CallAutomationConstants.InputValidation.StringMaxLength)
                {
                    throw new ArgumentException(CallAutomationErrorMessages.OperationContextExceedsMaxLength);
                }
                else
                {
                    request.OperationContext = options.OperationContext;
                }

                return RestClient.Mute(
                    CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Unmute participant from the call.
        /// Only Acs Users are currently supported.
        /// </summary>
        /// <param name="targetParticipant">Participant to unmute.</param>
        /// <param name="operationContext">The Operation Context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetParticipant"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual Response<UnmuteParticipantsResponse> UnmuteParticipants(CommunicationIdentifier targetParticipant, string operationContext = default, CancellationToken cancellationToken = default)
        {
            var options = new UnmuteParticipantsOptions(new List<CommunicationIdentifier> { targetParticipant })
            {
                OperationContext = operationContext,
            };
            return UnmuteParticipants(options, cancellationToken);
        }

        /// <summary>
        /// Unmute participants from the call.
        /// Only Acs Users are currently supported.
        /// </summary>
        /// <param name="options">Options for the UnmuteParticipant operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="options"/> OperationContext is too long. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public virtual Response<UnmuteParticipantsResponse> UnmuteParticipants(UnmuteParticipantsOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(UnmuteParticipants)}");
            scope.Start();
            try
            {
                UnmuteParticipantsRequestInternal request = new UnmuteParticipantsRequestInternal(
                    options.TargetParticipants.Select(participant => CommunicationIdentifierSerializer.Serialize(participant)).ToList());
                var repeatabilityHeaders = new RepeatabilityHeaders();
                if (options.OperationContext != null && options.OperationContext.Length > CallAutomationConstants.InputValidation.StringMaxLength)
                {
                    throw new ArgumentException(CallAutomationErrorMessages.OperationContextExceedsMaxLength);
                }
                else
                {
                    request.OperationContext = options.OperationContext;
                }

                return RestClient.Unmute(
                    CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken);
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
        /// <param name="operationContext">The Operation Context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetParticipant"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public async virtual Task<Response<MuteParticipantsResponse>> MuteParticipantsAsync(CommunicationIdentifier targetParticipant, string operationContext = default, CancellationToken cancellationToken = default)
        {
            var options = new MuteParticipantsOptions(new List<CommunicationIdentifier> { targetParticipant })
            {
                OperationContext = operationContext
            };
            return await MuteParticipantsAsync(options, cancellationToken).ConfigureAwait(false);
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
        public async virtual Task<Response<MuteParticipantsResponse>> MuteParticipantsAsync(MuteParticipantsOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(MuteParticipants)}");
            scope.Start();
            try
            {
                if (options == null)
                    throw new ArgumentNullException(nameof(options));

                MuteParticipantsRequestInternal request = new MuteParticipantsRequestInternal(
                    options.TargetParticipants.Select(participant => CommunicationIdentifierSerializer.Serialize(participant)));
                var repeatabilityHeaders = new RepeatabilityHeaders();

                if (options.OperationContext != null && options.OperationContext.Length > CallAutomationConstants.InputValidation.StringMaxLength)
                {
                    throw new ArgumentException(CallAutomationErrorMessages.OperationContextExceedsMaxLength);
                }
                else
                {
                    request.OperationContext = options.OperationContext;
                }

                return await RestClient.MuteAsync(
                    CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Unmute participants on the call.
        /// Only Acs Users are currently supported.
        /// </summary>
        /// <param name="targetParticipant">Participant to unmute.</param>
        /// <param name="operationContext">The Operation Context.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public async virtual Task<Response<UnmuteParticipantsResponse>> UnmuteParticipantsAsync(CommunicationIdentifier targetParticipant, string operationContext = default, CancellationToken cancellationToken = default)
        {
            var options = new UnmuteParticipantsOptions(new List<CommunicationIdentifier> { targetParticipant })
            {
                OperationContext = operationContext
            };

            return await UnmuteParticipantsAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Unmute participants from the call.
        /// Only Acs Users are currently supported.
        /// </summary>
        /// <param name="options">Options for the UnmuteParticipant operation.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="options"/> OperationContext is too long. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <returns></returns>
        public async virtual Task<Response<UnmuteParticipantsResponse>> UnmuteParticipantsAsync(UnmuteParticipantsOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(CallConnection)}.{nameof(UnmuteParticipants)}");
            scope.Start();
            try
            {
                UnmuteParticipantsRequestInternal request = new UnmuteParticipantsRequestInternal(
                    options.TargetParticipants.Select(participant => CommunicationIdentifierSerializer.Serialize(participant)).ToList());
                var repeatabilityHeaders = new RepeatabilityHeaders();
                if (options.OperationContext != null && options.OperationContext.Length > CallAutomationConstants.InputValidation.StringMaxLength)
                {
                    throw new ArgumentException(CallAutomationErrorMessages.OperationContextExceedsMaxLength);
                }
                else
                {
                    request.OperationContext = options.OperationContext;
                }

                return await RestClient.UnmuteAsync(
                    CallConnectionId,
                    request,
                    repeatabilityHeaders.RepeatabilityRequestId,
                    repeatabilityHeaders.GetRepeatabilityFirstSentString(),
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
