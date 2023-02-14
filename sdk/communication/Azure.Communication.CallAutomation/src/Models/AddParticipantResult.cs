// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>AddParticipantsResult Result.</summary>
    public class AddParticipantResult : ResultWithWaitForEventBase
    {
        internal AddParticipantResult(CallParticipant participant, string operationContext)
        {
            Participant = participant;
            OperationContext = operationContext;
        }

        internal AddParticipantResult(AddParticipantsResponseInternal internalObj)
        {
            Participant = internalObj.Participants.Select(t => new CallParticipant(t)).FirstOrDefault();
            OperationContext = internalObj.OperationContext;
        }

        /// <summary>Gets the participant.</summary>
        public CallParticipant Participant { get; }
        /// <summary>The operation context provided by client.</summary>
        public string OperationContext { get; }

        /// <summary>
        /// Wait for <see cref="AddParticipantsEventResult"/> using <see cref="EventProcessor"/>.
        /// </summary>
        /// <returns>Returns <see cref="AddParticipantsEventResult"/> which contains either <see cref="AddParticipantsSucceeded"/> event or <see cref="AddParticipantsFailed"/> event.</returns>
        public async Task<AddParticipantsEventResult> WaitForEvent(TimeSpan eventTimeout = default)
        {
            if (_evHandler is null)
            {
                throw new NullReferenceException(nameof(_evHandler));
            }

            var returnedEvent = await _evHandler.WaitForSingleEvent(filter
                => filter.CallConnectionId == _callConnectionId
                && (filter.OperationContext == _operationContext || _operationContext is null)
                && (filter.GetType() == typeof(AddParticipantsSucceeded)
                || filter.GetType() == typeof(AddParticipantsFailed)),
                eventTimeout).ConfigureAwait(false);

            AddParticipantsEventResult result = default;
            switch (returnedEvent)
            {
                case AddParticipantsSucceeded:
                    result = new AddParticipantsEventResult(true, (AddParticipantsSucceeded)returnedEvent, null);
                    break;
                case AddParticipantsFailed:
                    result = new AddParticipantsEventResult(false, null, (AddParticipantsFailed)returnedEvent);
                    break;
                default:
                    throw new NotSupportedException(returnedEvent.GetType().Name);
            }

            return result;
        }
    }
}
