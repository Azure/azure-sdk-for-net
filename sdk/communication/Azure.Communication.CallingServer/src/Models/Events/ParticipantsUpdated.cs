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
    public class ParticipantsUpdated : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of ParticipantsUpdatedEvent. </summary>
        internal ParticipantsUpdated()
        {
            Participants = new ChangeTrackingList<CommunicationIdentifier>();
        }

        /// <summary> Initializes a new instance of ParticipantsUpdatedEvent. </summary>
        /// <param name="internalEvent"> Internal Representation of the ParticipantsUpdatedEvent. </param>
        internal ParticipantsUpdated(ParticipantsUpdatedInternal internalEvent)
        {
            EventSource = internalEvent.EventSource;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participants = internalEvent.Participants.Select(t => CommunicationIdentifierSerializer.Deserialize(t)).ToList();
            Version = internalEvent.Version;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            PublicEventType = internalEvent.PublicEventType;
        }

        /// <summary> EventSource. </summary>
        public string EventSource { get; }
        /// <summary> Operation context. </summary>
        public string OperationContext { get; }
        /// <summary> Gets the result info. </summary>
        public ResultInformation ResultInformation { get; }
        /// <summary> Participants failed to be added. </summary>

        /// <summary> List of current participants in the call. </summary>
        public IReadOnlyList<CommunicationIdentifier> Participants { get; }
        /// <summary> Used to determine the version of the event. </summary>
        public string Version { get; }
        /// <summary> The public event namespace used as the &quot;type&quot; property in the CloudEvent. </summary>
        public string PublicEventType { get; }

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
