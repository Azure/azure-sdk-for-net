// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The participants updated event.
    /// </summary>
    public class ParticipantsUpdatedEvent : CallingServerEventBase
    {
        /// <summary> Initializes a new instance of ParticipantsUpdatedEvent. </summary>
        /// <param name="callConnectionId"> The call connection id. </param>
        /// <param name="participants"> The list of participants. </param>
        internal ParticipantsUpdatedEvent(string callConnectionId, IEnumerable<CallParticipant> participants)
        {
            CallConnectionId = callConnectionId;
            Participants = participants;
        }

        /// <summary>
        /// Deserialize <see cref="ParticipantsUpdatedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ParticipantsUpdatedEvent"/> object.</returns>
        public static ParticipantsUpdatedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var participantsUpdatedEventInternal = ParticipantsUpdatedEventInternal.DeserializeParticipantsUpdatedEventInternal(element);
            var callParticipants = participantsUpdatedEventInternal.Participants?.Select(x => new CallParticipant(identifier: CommunicationIdentifierSerializer.Deserialize(x.Identifier), isMuted: x.IsMuted, participantId: x.ParticipantId));

            return new ParticipantsUpdatedEvent(participantsUpdatedEventInternal.CallConnectionId, callParticipants);
        }

        /// <summary> The call connection id. </summary>
        public string CallConnectionId { get; }

        /// <summary> The list of participants. </summary>
        public IEnumerable<CallParticipant> Participants { get; }
    }
}
