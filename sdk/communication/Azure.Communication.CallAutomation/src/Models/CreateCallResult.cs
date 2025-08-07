// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from creating a call.</summary>
    public class CreateCallResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;
        private string _operationContext;

        internal CreateCallResult(CallConnection callConnection, CallConnectionProperties callConnectionProperties)
        {
            CallConnection = callConnection;
            CallConnectionProperties = callConnectionProperties;
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId, string operationContext)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
            _operationContext = operationContext;
        }

        /// <summary>CallConnection instance.</summary>
        public CallConnection CallConnection { get; }

        /// <summary>Properties of the call.</summary>
        public CallConnectionProperties CallConnectionProperties { get; }

        /// <summary>
        /// This is blocking call. Wait for <see cref="CreateCallEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="CreateCallEventResult"/> which contains <see cref="CallConnected"/> event.</returns>
        public CreateCallEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(CallConnected) || filter.GetType() == typeof(CreateCallFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="CreateCallEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="CreateCallEventResult"/> which contains <see cref="CallConnected"/> event.</returns>
        public async Task<CreateCallEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(CallConnected) || filter.GetType() == typeof(CreateCallFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static CreateCallEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            switch (returnedEvent)
            {
                case CallConnected:
                    return new CreateCallEventResult(true, (CallConnected)returnedEvent, null);
                case CreateCallFailed:
                    return new CreateCallEventResult(false, null, (CreateCallFailed)returnedEvent);
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }
        }
    }
}
