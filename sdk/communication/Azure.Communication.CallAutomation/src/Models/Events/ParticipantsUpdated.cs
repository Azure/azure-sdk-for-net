// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The participants updated event.
    /// </summary>
    public class ParticipantsUpdated : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of ParticipantsUpdatedEvent. </summary>
        internal ParticipantsUpdated()
        {
            Participants = new ChangeTrackingList<CallParticipant>();
        }

        /// <summary> Initializes a new instance of ParticipantsUpdatedEvent. </summary>
        /// <param name="internalEvent"> Internal Representation of the ParticipantsUpdatedEvent. </param>
        internal ParticipantsUpdated(ParticipantsUpdatedInternal internalEvent)
        {
            Participants = internalEvent.Participants.Select(t => new CallParticipant(t)).ToList();
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            SequenceNumber = internalEvent.SequenceNumber;
            ResultInformation = internalEvent.ResultInformation;
        }

        /// <summary> List of current participants in the call. </summary>
        public IReadOnlyList<CallParticipant> Participants { get; }

        /// <summary> Sequence number to indicate order of ParticipantsUpdated events. </summary>
        public int? SequenceNumber { get; }

        /// <summary>
        /// Deserialize <see cref="ParticipantsUpdated"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ParticipantsUpdated"/> object.</returns>
        public static ParticipantsUpdated Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = ParticipantsUpdatedInternal.DeserializeParticipantsUpdatedInternal(element);
            return new ParticipantsUpdated(internalEvent);
        }
    }
}
