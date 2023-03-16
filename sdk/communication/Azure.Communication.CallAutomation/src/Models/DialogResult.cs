// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>AddParticipantsResult Result.</summary>
    public class DialogResult : ResultWithWaitForEventBase
    {
        internal DialogResult()
        {
        }

        /// <summary>
        /// Wait for <see cref="DialogEventResult"/> using <see cref="EventProcessor"/>.
        /// </summary>
        /// <returns>Returns <see cref="DialogEventResult"/> which contains either <see cref="DialogCompleted"/> event, <see cref="DialogConsent"/> event, <see cref="DialogFailed"/> event, <see cref="DialogHangup"/> event, <see cref="DialogStarted"/> event, <see cref="DialogTransfer"/> event.</returns>
        public async Task<DialogEventResult> WaitForEvent(TimeSpan eventTimeout = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForSingleEvent(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(DialogCompleted)
                || filter.GetType() == typeof(DialogConsent)
                || filter.GetType() == typeof(DialogFailed)
                || filter.GetType() == typeof(DialogHangup)
                || filter.GetType() == typeof(DialogStarted)
                || filter.GetType() == typeof(DialogTransfer)),
                eventTimeout).ConfigureAwait(false);

            DialogEventResult result = default;
            switch (returnedEvent)
            {
                case DialogCompleted:
                    result = new DialogEventResult(true, (DialogCompleted)returnedEvent, null, null, null, null, null);
                    break;
                case DialogConsent:
                    result = new DialogEventResult(true, null, (DialogConsent)returnedEvent, null, null, null, null);
                    break;
                case DialogFailed:
                    result = new DialogEventResult(false, null, null, (DialogFailed)returnedEvent, null, null, null);
                    break;
                case DialogHangup:
                    result = new DialogEventResult(true, null, null, null, (DialogHangup)returnedEvent, null, null);
                    break;
                case DialogStarted:
                    result = new DialogEventResult(true, null, null, null, null, (DialogStarted)returnedEvent, null);
                    break;
                case DialogTransfer:
                    result = new DialogEventResult(true, null, null, null, null, null, (DialogTransfer)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
