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
        /// <summary> Initializes a new instance of ParticipantsUpdatedEventInternal. </summary>
        public ParticipantsUpdatedEvent()
        {
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

            return new ParticipantsUpdatedEvent
            {
                CallLegId = participantsUpdatedEventInternal.CallLegId,
                Participants = participantsUpdatedEventInternal.Participants?.Select(x => new CommunicationParticipant { Identifier = CommunicationIdentifierSerializer.Deserialize(x.Identifier), IsMuted = x.IsMuted, ParticipantId = x.ParticipantId })
            };
        }

        /// <summary> The call leg.id. </summary>
        public string CallLegId { get; set; }

        /// <summary> The list of participants. </summary>
        public IEnumerable<CommunicationParticipant> Participants { get; set; }
    }
}
