// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The participants updated event.
    /// </summary>
    public class ParticipantsUpdatedEvent : CallingServerEventBase
    {
        /// <summary> Initializes a new instance of ParticipantsUpdatedEvent. </summary>
        internal ParticipantsUpdatedEvent()
        {
            Participants = new ChangeTrackingList<CommunicationIdentifier>();
        }

        /// <summary> Initializes a new instance of ParticipantsUpdatedEvent. </summary>
        /// <param name="internalEvent"> Internal Representation of the ParticipantsUpdatedEvent. </param>
        internal ParticipantsUpdatedEvent(ParticipantsUpdatedEventInternal internalEvent)
        {
            Participants = internalEvent.Participants.Select(t => CommunicationIdentifierSerializer.Deserialize(t)).ToList();
            Type = internalEvent.Type;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> List of current participants in the call. </summary>
        public IReadOnlyList<CommunicationIdentifier> Participants { get; }
        /// <summary> Gets the type. </summary>
        public AcsEventType? Type { get; }
        /// <summary> Call connection ID. </summary>
        public string CallConnectionId { get; }
        /// <summary> Server call ID. </summary>
        public string ServerCallId { get; }
        /// <summary> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </summary>
        public string CorrelationId { get; }
        /// <summary>
        /// Deserialize <see cref="ParticipantsUpdatedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ParticipantsUpdatedEvent"/> object.</returns>
        public static ParticipantsUpdatedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = ParticipantsUpdatedEventInternal.DeserializeParticipantsUpdatedEventInternal(element);
            return new ParticipantsUpdatedEvent(internalEvent);
        }
    }
}
