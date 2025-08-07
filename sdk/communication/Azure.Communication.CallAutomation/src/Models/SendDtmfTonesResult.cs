// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;
using System.Threading;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from send dtmf request.</summary>
    public partial class SendDtmfTonesResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal SendDtmfTonesResult()
        {
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>
        /// This is blocking call. Wait for <see cref="SendDtmfTonesEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="SendDtmfTonesEventResult"/> which contains either <see cref="SendDtmfTonesCompleted"/> event or <see cref="SendDtmfTonesFailed"/> event.</returns>
        public SendDtmfTonesEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(SendDtmfTonesCompleted)
                || filter.GetType() == typeof(SendDtmfTonesFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="SendDtmfTonesEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="SendDtmfTonesEventResult"/> which contains either <see cref="SendDtmfTonesCompleted"/> event or <see cref="SendDtmfTonesCompleted"/> event.</returns>
        public async Task<SendDtmfTonesEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(SendDtmfTonesCompleted)
                || filter.GetType() == typeof(SendDtmfTonesFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static SendDtmfTonesEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            SendDtmfTonesEventResult result = default;
            switch (returnedEvent)
            {
                case SendDtmfTonesCompleted:
                    result = new SendDtmfTonesEventResult(true, (SendDtmfTonesCompleted)returnedEvent, null);
                    break;
                case SendDtmfTonesFailed:
                    result = new SendDtmfTonesEventResult(false, null, (SendDtmfTonesFailed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
