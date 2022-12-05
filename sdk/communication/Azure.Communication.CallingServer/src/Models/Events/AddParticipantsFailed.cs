// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The add participant failed event.
    /// </summary>
    public class AddParticipantsFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of AddParticipantsFailedEvent. </summary>
        internal AddParticipantsFailed()
        {
            Participants = new ChangeTrackingList<CommunicationIdentifier>();
        }

        /// <summary> Initializes a new instance of AddParticipantsFailedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the AddParticipantsFailedEvent. </param>
        internal AddParticipantsFailed(AddParticipantsFailedInternal internalEvent)
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
        public IReadOnlyList<CommunicationIdentifier> Participants { get; }
        /// <summary> Used to determine the version of the event. </summary>
        public string Version { get; }
        /// <summary> The public event namespace used as the &quot;type&quot; property in the CloudEvent. </summary>
        public string PublicEventType { get; }

        /// <summary>
        /// Deserialize <see cref="AddParticipantsFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantsFailed"/> object.</returns>
        public static AddParticipantsFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantsFailedInternal.DeserializeAddParticipantsFailedInternal(element);
            return new AddParticipantsFailed(internalEvent);
        }
    }
}
