// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from playing audio.</summary>
    public class HoldResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal HoldResult()
        {
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="HoldEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="HoldEventResult"/> which contains <see cref="HoldFailed"/> event.</returns>
        public HoldEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && filter.GetType() == typeof(HoldFailed),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="HoldEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="HoldEventResult"/> which contains <see cref="HoldFailed"/> event.</returns>
        public async Task<HoldEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && filter.GetType() == typeof(HoldFailed),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static HoldEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            HoldEventResult result = default;
            switch (returnedEvent)
            {
                case HoldFailed:
                    result = new HoldEventResult(false, (HoldFailed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
