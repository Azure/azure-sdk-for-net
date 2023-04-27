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

        internal AddParticipantResult(CallParticipant participant, string operationContext)
        {
            Participant = participant;
            OperationContext = operationContext;
        }

        internal AddParticipantResult(AddParticipantResponseInternal internalObj)
        {
            Participant = new CallParticipant(internalObj.Participant);
            OperationContext = internalObj.OperationContext;
        }

        /// <summary>Gets the participant.</summary>
        public CallParticipant Participant { get; }
        /// <summary>The operation context provided by client.</summary>
        public string OperationContext { get; }

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
        /// <returns>Returns <see cref="AddParticipantEventResult"/> which contains either <see cref="AddParticipantSucceededEventData"/> event or <see cref="AddParticipantFailedEventData"/> event.</returns>
        public AddParticipantEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(AddParticipantSucceededEventData)
                || filter.GetType() == typeof(AddParticipantFailedEventData)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="AddParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="AddParticipantEventResult"/> which contains either <see cref="AddParticipantSucceededEventData"/> event or <see cref="AddParticipantFailedEventData"/> event.</returns>
        public async Task<AddParticipantEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(AddParticipantSucceededEventData)
                || filter.GetType() == typeof(AddParticipantFailedEventData)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static AddParticipantEventResult SetReturnedEvent(CallAutomationEventData returnedEvent)
        {
            AddParticipantEventResult result = default;
            switch (returnedEvent)
            {
                case AddParticipantSucceededEventData:
                    result = new AddParticipantEventResult(true, (AddParticipantSucceededEventData)returnedEvent, null, ((AddParticipantSucceededEventData)returnedEvent).Participant);
                    break;
                case AddParticipantFailedEventData:
                    result = new AddParticipantEventResult(false, null, (AddParticipantFailedEventData)returnedEvent,((AddParticipantFailedEventData)returnedEvent).Participant);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
