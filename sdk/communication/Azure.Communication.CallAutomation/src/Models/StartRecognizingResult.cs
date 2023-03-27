// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using System.Threading;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from start recognizing result.</summary>
    public class StartRecognizingResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal StartRecognizingResult()
        {
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="StartRecognizingEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="StartRecognizingEventResult"/> which contains either <see cref="RecognizeCompleted"/> event or <see cref="RecognizeFailed"/> event.</returns>
        public StartRecognizingEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(RecognizeCompleted)
                || filter.GetType() == typeof(RecognizeFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="StartRecognizingEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="StartRecognizingEventResult"/> which contains either <see cref="RecognizeCompleted"/> event or <see cref="RecognizeFailed"/> event.</returns>
        public async Task<StartRecognizingEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(RecognizeCompleted)
                || filter.GetType() == typeof(RecognizeFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static StartRecognizingEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
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
