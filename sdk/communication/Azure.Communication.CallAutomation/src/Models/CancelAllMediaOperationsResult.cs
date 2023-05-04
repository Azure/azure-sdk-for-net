// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using System.Threading;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from Canceling all media operation.</summary>
    public class CancelAllMediaOperationsResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal CancelAllMediaOperationsResult()
        {
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="CancelAllMediaOperationsEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="CancelAllMediaOperationsEventResult"/> which contains either <see cref="PlayCanceledEventData"/> or <see cref="RecognizeCanceledEventData"/> event.</returns>
        public CancelAllMediaOperationsEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(PlayCanceledEventData)
                || filter.GetType() == typeof(RecognizeCanceledEventData)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="CancelAllMediaOperationsEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="CancelAllMediaOperationsEventResult"/> which contains either <see cref="PlayCanceledEventData"/> or <see cref="RecognizeCanceledEventData"/> event.</returns>
        public async Task<CancelAllMediaOperationsEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(PlayCanceledEventData)
                || filter.GetType() == typeof(RecognizeCanceledEventData)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static CancelAllMediaOperationsEventResult SetReturnedEvent(CallAutomationEventData returnedEvent)
        {
            CancelAllMediaOperationsEventResult result = default;
            switch (returnedEvent)
            {
                case PlayCanceledEventData:
                    result = new CancelAllMediaOperationsEventResult(true, (PlayCanceledEventData)returnedEvent, null);
                    break;
                case RecognizeCanceledEventData:
                    result = new CancelAllMediaOperationsEventResult(true, null, (RecognizeCanceledEventData)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
