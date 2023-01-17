// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The result from Canceling all media operation. </summary>
    public class CancelAllMediaOperationsResult : ResultWithWaitForEventBase
    {
        internal CancelAllMediaOperationsResult()
        {
        }

        /// <summary>
        /// Wait for CancelAllMediaOperationsEventResult using EventProcessor.
        /// </summary>
        /// <returns></returns>
        public async Task<CancelAllMediaOperationsEventResult> WaitForEvent()
        {
            if (_evHandler is null)
            {
                throw new ArgumentNullException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEvent(filter
                => filter.CallConnectionId == _callConnectionId
                && filter.OperationContext == _operationContext
                && (filter.GetType() == typeof(PlayCanceled)
                || filter.GetType() == typeof(RecognizeCanceled))).ConfigureAwait(false);

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
