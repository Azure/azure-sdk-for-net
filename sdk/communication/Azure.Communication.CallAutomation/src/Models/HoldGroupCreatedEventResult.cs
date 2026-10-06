// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The result from creating a hold group.
    /// </summary>
    public class HoldGroupCreatedEventResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal HoldGroupCreatedEventResult()
        {
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="HoldGroupEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="HoldGroupEventResult"/> which contains either <see cref="HoldGroupCreated"/> event or <see cref="HoldGroupFailed"/> event.</returns>
        public HoldGroupEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(HoldGroupCreated)
                || filter.GetType() == typeof(HoldGroupAudioStarted)
                || filter.GetType() == typeof(HoldGroupAudioFailed)
                || filter.GetType() == typeof(HoldGroupFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="HoldGroupEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="HoldGroupEventResult"/> which contains either <see cref="HoldGroupCreated"/> event or <see cref="HoldGroupFailed"/> event.</returns>
        public async Task<HoldGroupEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(HoldGroupCreated)
                || filter.GetType() == typeof(HoldGroupAudioStarted)
                || filter.GetType() == typeof(HoldGroupAudioFailed)
                || filter.GetType() == typeof(HoldGroupFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static HoldGroupEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            HoldGroupEventResult result = default;
            switch (returnedEvent)
            {
                case HoldGroupCreated:
                    result = new HoldGroupEventResult(true, (HoldGroupCreated)returnedEvent, null, null, null);
                    break;
                case HoldGroupAudioStarted:
                    result = new HoldGroupEventResult(true, null, (HoldGroupAudioStarted)returnedEvent, null, null);
                    break;
                case HoldGroupAudioFailed:
                    result = new HoldGroupEventResult(false, null, null, (HoldGroupAudioFailed)returnedEvent, null);
                    break;
                case HoldGroupFailed:
                    result = new HoldGroupEventResult(false, null, null, null, (HoldGroupFailed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
