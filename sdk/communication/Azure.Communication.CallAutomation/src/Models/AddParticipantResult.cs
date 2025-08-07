// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>AddParticipantsResult Result.</summary>
    public class AddParticipantResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal AddParticipantResult(CallParticipant participant, string operationContext, string invitationId)
        {
            Participant = participant;
            OperationContext = operationContext;
            InvitationId = invitationId;
        }

        internal AddParticipantResult(AddParticipantResponseInternal internalObj)
        {
            Participant = new CallParticipant(internalObj.Participant);
            OperationContext = internalObj.OperationContext;
            InvitationId = internalObj.InvitationId;
        }

        /// <summary>Gets the participant.</summary>
        public CallParticipant Participant { get; }
        /// <summary>The operation context provided by client.</summary>
        public string OperationContext { get; }
        /// <summary>
        /// The invitation ID used to add the participant.
        /// </summary>
        public string InvitationId { get; }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="AddParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="AddParticipantEventResult"/> which contains either <see cref="AddParticipantSucceeded"/> event or <see cref="AddParticipantFailed"/> event.</returns>
        public AddParticipantEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(AddParticipantSucceeded)
                || filter.GetType() == typeof(AddParticipantFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="AddParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="AddParticipantEventResult"/> which contains either <see cref="AddParticipantSucceeded"/> event or <see cref="AddParticipantFailed"/> event.</returns>
        public async Task<AddParticipantEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(AddParticipantSucceeded)
                || filter.GetType() == typeof(AddParticipantFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static AddParticipantEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            AddParticipantEventResult result = default;
            switch (returnedEvent)
            {
                case AddParticipantSucceeded:
                    result = new AddParticipantEventResult(true, (AddParticipantSucceeded)returnedEvent, null, ((AddParticipantSucceeded)returnedEvent).Participant);
                    break;
                case AddParticipantFailed:
                    result = new AddParticipantEventResult(false, null, (AddParticipantFailed)returnedEvent,((AddParticipantFailed)returnedEvent).Participant);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
