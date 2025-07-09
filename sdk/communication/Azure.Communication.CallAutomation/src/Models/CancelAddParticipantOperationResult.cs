// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>AddParticipantsResult Result.</summary>
    public class CancelAddParticipantOperationResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal CancelAddParticipantOperationResult(CancelAddParticipantResponseInternal internalObj)
        {
            OperationContext = internalObj.OperationContext;
            InvitationId = internalObj.InvitationId;
        }

        internal CancelAddParticipantOperationResult(string invitationId, string operationcontext)
        {
            InvitationId = invitationId;
            OperationContext = operationcontext;
        }

        /// <summary>The operation context provided by client.</summary>
        public string OperationContext { get; }

        /// <summary>
        /// Invitation ID used to cancel the add participant action.
        /// </summary>
        public string InvitationId { get; }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="CancelAddParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="CancelAddParticipantEventResult"/> which contains either <see cref="CancelAddParticipantSucceeded"/> event or <see cref="CancelAddParticipantFailed"/> event.</returns>
        public CancelAddParticipantEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(CancelAddParticipantSucceeded)
                || filter.GetType() == typeof(CancelAddParticipantFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="CancelAddParticipantEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="CancelAddParticipantEventResult"/> which contains either <see cref="CancelAddParticipantSucceeded"/> event or <see cref="CancelAddParticipantFailed"/> event.</returns>
        public async Task<CancelAddParticipantEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(CancelAddParticipantSucceeded)
                || filter.GetType() == typeof(CancelAddParticipantFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static CancelAddParticipantEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            switch (returnedEvent)
            {
                case CancelAddParticipantSucceeded:
                    {
                        var successEvent = returnedEvent as CancelAddParticipantSucceeded;

                        return new CancelAddParticipantEventResult(
                            true,
                            successEvent,
                            null);
                    }

                case CancelAddParticipantFailed:
                    {
                        var failedEvent = returnedEvent as CancelAddParticipantFailed;

                        return new CancelAddParticipantEventResult(
                            false,
                            null,
                            failedEvent);
                    }

                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }
        }
    }
}
