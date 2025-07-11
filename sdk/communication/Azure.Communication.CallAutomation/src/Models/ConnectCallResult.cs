// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from connect request.</summary>
    public class ConnectCallResult
    {
        private CallAutomationEventProcessor _evHandler;
        private string _callConnectionId;

        internal ConnectCallResult(CallConnectionProperties callConnectionProperties, CallConnection callConnection)
        {
            CallConnectionProperties = callConnectionProperties;
            CallConnection = callConnection;
        }

        internal void SetEventProcessor(CallAutomationEventProcessor evHandler, string callConnectionId)
        {
            _evHandler = evHandler;
            _callConnectionId = callConnectionId;
        }

        /// <summary>CallConnection instance.</summary>
        public CallConnection CallConnection { get; }

        /// <summary> Properties of the call. </summary>
        public CallConnectionProperties CallConnectionProperties { get; }

        /// <summary>
        /// This is blocking call. Wait for <see cref="ConnectCallEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="ConnectCallEventResult"/> which contains <see cref="ConnectFailed"/> event.</returns>
        public ConnectCallEventResult WaitForEventProcessor(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = _evHandler.WaitForEventProcessor(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.GetType() == typeof(CallConnected) || filter.GetType() == typeof(ConnectFailed)),
                cancellationToken);

            return SetReturnedEvent(returnedEvent);
        }

        /// <summary>
        /// Wait for <see cref="ConnectCallEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation Token can be used to set timeout or cancel this WaitForEventProcessor.</param>
        /// <returns>Returns <see cref="ConnectCallEventResult"/> which contains <see cref="ConnectFailed"/> event.</returns>
        public async Task<ConnectCallEventResult> WaitForEventProcessorAsync(CancellationToken cancellationToken = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForEventProcessorAsync(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.GetType() == typeof(CallConnected) || filter.GetType() == typeof(ConnectFailed)),
                cancellationToken).ConfigureAwait(false);

            return SetReturnedEvent(returnedEvent);
        }

        private static ConnectCallEventResult SetReturnedEvent(CallAutomationEventBase returnedEvent)
        {
            ConnectCallEventResult result = default;
            switch (returnedEvent)
            {
                case ConnectFailed:
                    result = new ConnectCallEventResult(false, (ConnectFailed)returnedEvent, null);
                    break;
                case CallConnected:
                    result = new ConnectCallEventResult(true, null, (CallConnected)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
