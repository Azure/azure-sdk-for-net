// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("TransferCallResponse")]
    public partial class TransferCallToParticipantResult : ResultWithWaitForEventBase
    {
        /// <summary>
        /// Wait for <see cref="TransferCallToParticipantEventResult"/> using <see cref="EventProcessor"/>.
        /// </summary>
        /// <returns>Returns <see cref="TransferCallToParticipantEventResult"/> which contains either <see cref="CallTransferAccepted"/> event or <see cref="CallTransferFailed"/> event.</returns>
        public async Task<TransferCallToParticipantEventResult> WaitForEvent(TimeSpan eventTimeout = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForSingleEvent(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(CallTransferAccepted)
                || filter.GetType() == typeof(CallTransferFailed)),
                eventTimeout).ConfigureAwait(false);

            TransferCallToParticipantEventResult result = default;
            switch (returnedEvent)
            {
                case CallTransferAccepted:
                    result = new TransferCallToParticipantEventResult(true, (CallTransferAccepted)returnedEvent, null);
                    break;
                case CallTransferFailed:
                    result = new TransferCallToParticipantEventResult(false, null, (CallTransferFailed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
