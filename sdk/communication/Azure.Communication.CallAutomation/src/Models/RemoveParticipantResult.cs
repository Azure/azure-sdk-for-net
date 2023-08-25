// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>RemoveParticipantResult Result.</summary>
    public class RemoveParticipantResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal RemoveParticipantResult(string operationContext)
        {
            OperationContext = operationContext;
        }

        internal RemoveParticipantResult(RemoveParticipantResponseInternal internalObj)
        {
            OperationContext = internalObj.OperationContext;
        }

        /// <summary>The operation context provided by client.</summary>
        public string OperationContext { get; }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="RemoveParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="RemoveParticipantEventResult"/> which contains either <see cref="RemoveParticipantSucceeded"/> event or <see cref="RemoveParticipantFailed"/> event.</returns>
        public RemoveParticipantEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(RemoveParticipantSucceeded)
                || filter.GetType() == typeof(RemoveParticipantFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="RemoveParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="RemoveParticipantEventResult"/> which contains either <see cref="RemoveParticipantSucceeded"/> event or <see cref="RemoveParticipantFailed"/> event.</returns>
        public async Task<RemoveParticipantEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(RemoveParticipantSucceeded)
                || filter.GetType() == typeof(RemoveParticipantFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static RemoveParticipantEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            RemoveParticipantEventResult result = default;
            switch (returnedEvent)
            {
                case RemoveParticipantSucceeded:
                    result = new RemoveParticipantEventResult(true, (RemoveParticipantSucceeded)returnedEvent, null, ((RemoveParticipantSucceeded)returnedEvent).Participant);
                    break;
                case RemoveParticipantFailed:
                    result = new RemoveParticipantEventResult(false, null, (RemoveParticipantFailed)returnedEvent,((RemoveParticipantFailed)returnedEvent).Participant);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
