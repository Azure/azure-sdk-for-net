// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallingServer
{
    /// <summary> AddParticipantsResult Result </summary>
    public class AddParticipantsResult
    {
        internal AddParticipantsResult(IReadOnlyList<CallParticipant> participants, string operationContext)
        {
            Participants = participants;
            OperationContext = operationContext;
        }

        internal AddParticipantsResult(AddParticipantsResponseInternal internalObj)
        {
            Participants = internalObj.Participants.Select(t => new CallParticipant(t)).ToList();
            OperationContext = internalObj.OperationContext;
        }

        /// <summary> Gets the participants. </summary>
        public IReadOnlyList<CallParticipant> Participants { get; }
        /// <summary> The operation context provided by client. </summary>
        public string OperationContext { get; }
    }
}
