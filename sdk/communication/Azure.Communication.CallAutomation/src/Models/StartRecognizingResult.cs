// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The result from start recognizing result. </summary>
    public class StartRecognizingResult : ResultWithWaitForEventBase
    {
        internal StartRecognizingResult()
        {
        }

        /// <summary>
        /// Wait for StartRecognizingEventResult using EventProcessor.
        /// </summary>
        /// <returns></returns>
        public async Task<StartRecognizingEventResult> WaitForEvent(TimeSpan eventTimeout = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEvent(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(RecognizeCompleted)
                || filter.GetType() == typeof(RecognizeFailed)),
                eventTimeout).ConfigureAwait(false);

            StartRecognizingEventResult result = default;
            switch (returnedEvent)
            {
                case RecognizeCompleted:
                    result = new StartRecognizingEventResult(true, (RecognizeCompleted)returnedEvent, null);
                    break;
                case RecognizeFailed:
                    result = new StartRecognizingEventResult(false, null, (RecognizeFailed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
