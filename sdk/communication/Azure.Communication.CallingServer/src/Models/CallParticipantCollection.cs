// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallingServer
{
    /// <summary> A collection of participants in a call. </summary>
    public class CallParticipantCollection
    {
        /// <summary> Initializes a new instance of CallParticipantCollection. </summary>
        /// <param name="participants"> Collection of call participants. </param>
        internal CallParticipantCollection(IReadOnlyList<CallParticipant> participants)
        {
            if (participants == null)
            {
                throw new ArgumentNullException(nameof(participants));
            }
            Value = participants;
        }

        /// <summary> Initializes a new instance of CallParticipantCollection. </summary>
        /// <param name="callParticipantsInternal"> Collection of call participants. </param>
        internal CallParticipantCollection(IEnumerable<AcsCallParticipantDtoInternal> callParticipantsInternal)
        {
            if (callParticipantsInternal == null)
            {
                throw new ArgumentNullException(nameof(callParticipantsInternal));
            }

            Value = callParticipantsInternal.Select(x => new CallParticipant(
                CommunicationIdentifierSerializer.Deserialize(x.Identifier),
                x.IsMuted ?? default)).ToList();
        }

        /// <summary> Collection of internal call participants. </summary>
        public IReadOnlyList<CallParticipant> Value { get; }
    }
}
