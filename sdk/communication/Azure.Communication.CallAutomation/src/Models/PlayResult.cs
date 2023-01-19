// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>The result from playing audio.</summary>
    public class PlayResult : ResultWithWaitForEventBase
    {
        internal PlayResult()
        {
        }

        /// <summary>
        /// Wait for <see cref="PlayEventResult"/> using <see cref="EventProcessor"/>.
        /// </summary>
        /// <returns>Returns <see cref="PlayEventResult"/> which contains either <see cref="PlayCompleted"/> event or <see cref="PlayFailed"/> event.</returns>
        public async Task<PlayEventResult> WaitForEvent(TimeSpan eventTimeout = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForSingleEvent(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(PlayCompleted)
                || filter.GetType() == typeof(PlayFailed)),
                eventTimeout).ConfigureAwait(false);

            PlayEventResult result = default;
            switch (returnedEvent)
            {
                case PlayCompleted:
                    result = new PlayEventResult(true, (PlayCompleted)returnedEvent, null);
                    break;
                case PlayFailed:
                    result = new PlayEventResult(false, null, (PlayFailed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
