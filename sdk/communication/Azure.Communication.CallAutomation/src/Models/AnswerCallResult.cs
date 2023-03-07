// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from creating a call.</summary>
    public class AnswerCallResult : ResultWithWaitForEventBase
    {
        internal AnswerCallResult(CallConnection callConnection,
            CallConnectionProperties callConnectionProperties)
        {
            CallConnection = callConnection;
            CallConnectionProperties = callConnectionProperties;
        }

        /// <summary>CallConnection instance.</summary>
        public CallConnection CallConnection { get; }

        /// <summary> Properties of the call. </summary>
        public CallConnectionProperties CallConnectionProperties { get; }

        /// <summary>
        /// Wait for <see cref="AnswerCallEventResult"/> using <see cref="CallAutomationEventProcessor"/>.
        /// </summary>
        /// <returns>Returns <see cref="AnswerCallEventResult"/> which contains <see cref="CallConnected"/> event.</returns>
        public async Task<AnswerCallEventResult> WaitForEvent(TimeSpan eventTimeout = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForSingleEvent(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && filter.GetType() == typeof(CallConnected),
                eventTimeout).ConfigureAwait(false);

            return new AnswerCallEventResult(true, (CallConnected)returnedEvent);
        }
    }
}
