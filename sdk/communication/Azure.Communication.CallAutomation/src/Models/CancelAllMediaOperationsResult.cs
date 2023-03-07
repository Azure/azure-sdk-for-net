// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from Canceling all media operation.</summary>
    public class CancelAllMediaOperationsResult : ResultWithWaitForEventBase
    {
        internal CancelAllMediaOperationsResult()
        {
        }

        /// <summary>
        /// Wait for <see cref="CancelAllMediaOperationsEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <returns>Returns <see cref="CancelAllMediaOperationsEventResult"/> which contains either <see cref="PlayCanceled"/> or <see cref="RecognizeCanceled"/> event.</returns>
        public async Task<CancelAllMediaOperationsEventResult> WaitForEvent(TimeSpan eventTimeout = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForSingleEvent(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(PlayCanceled)
                || filter.GetType() == typeof(RecognizeCanceled)),
                eventTimeout).ConfigureAwait(false);

            CancelAllMediaOperationsEventResult result = default;
            switch (returnedEvent)
            {
                case PlayCanceled:
                    result = new CancelAllMediaOperationsEventResult(true, (PlayCanceled)returnedEvent, null);
                    break;
                case RecognizeCanceled:
                    result = new CancelAllMediaOperationsEventResult(true, null, (RecognizeCanceled)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
