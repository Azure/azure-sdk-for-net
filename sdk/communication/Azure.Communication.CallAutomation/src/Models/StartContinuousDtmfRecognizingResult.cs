// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using System.Threading;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from start continuous dtmf recognition request.</summary>
    public class StartContinuousDtmfRecognizingResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal StartContinuousDtmfRecognizingResult()
        {
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="StartContinuousDtmfRecognizingEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="StartContinuousDtmfRecognizingEventResult"/> which contains either <see cref="ContinuousDtmfRecognitionToneReceived"/> event or <see cref="ContinuousDtmfRecognitionToneFailed"/> event.</returns>
        public StartContinuousDtmfRecognizingEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(ContinuousDtmfRecognitionToneReceived)
                || filter.GetType() == typeof(ContinuousDtmfRecognitionToneFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="StartContinuousDtmfRecognizingEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="StartContinuousDtmfRecognizingEventResult"/> which contains either <see cref="ContinuousDtmfRecognitionToneReceived"/> event or <see cref="ContinuousDtmfRecognitionToneFailed"/> event.</returns>
        public async Task<StartContinuousDtmfRecognizingEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(ContinuousDtmfRecognitionToneReceived)
                || filter.GetType() == typeof(ContinuousDtmfRecognitionToneFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static StartContinuousDtmfRecognizingEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            StartContinuousDtmfRecognizingEventResult result = default;
            switch (returnedEvent)
            {
                case ContinuousDtmfRecognitionToneReceived:
                    result = new StartContinuousDtmfRecognizingEventResult(true, (ContinuousDtmfRecognitionToneReceived)returnedEvent, null);
                    break;
                case ContinuousDtmfRecognitionToneFailed:
                    result = new StartContinuousDtmfRecognizingEventResult(false, null, (ContinuousDtmfRecognitionToneFailed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
