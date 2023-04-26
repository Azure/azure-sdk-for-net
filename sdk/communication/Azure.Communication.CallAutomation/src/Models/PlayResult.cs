// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using System.Threading;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from playing audio.</summary>
    public class PlayResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal PlayResult()
        {
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="PlayEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="PlayEventResult"/> which contains either <see cref="PlayCompletedEventData"/> event or <see cref="PlayFailedEventData"/> event.</returns>
        public PlayEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(PlayCompletedEventData)
                || filter.GetType() == typeof(PlayFailedEventData)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="PlayEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="PlayEventResult"/> which contains either <see cref="PlayCompletedEventData"/> event or <see cref="PlayFailedEventData"/> event.</returns>
        public async Task<PlayEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(PlayCompletedEventData)
                || filter.GetType() == typeof(PlayFailedEventData)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static PlayEventResult SetReturnedEvent(CallAutomationEventData returnedEvent)
        {
            PlayEventResult result = default;
            switch (returnedEvent)
            {
                case PlayCompletedEventData:
                    result = new PlayEventResult(true, (PlayCompletedEventData)returnedEvent, null);
                    break;
                case PlayFailedEventData:
                    result = new PlayEventResult(false, null, (PlayFailedEventData)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
