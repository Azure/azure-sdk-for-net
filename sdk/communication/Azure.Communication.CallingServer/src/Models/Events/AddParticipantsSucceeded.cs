// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using System.Linq;
using System.Collections.Generic;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The add participants succeeded event.
    /// </summary>
    public class AddParticipantsSucceeded: CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of AddParticipantsSucceededEventInternal. </summary>
        internal AddParticipantsSucceeded()
        {
            Participants = new ChangeTrackingList<CommunicationIdentifier>();
        }

        /// <summary> Initializes a new instance of AddParticipantsSucceededEventInternal. </summary>
        /// <param name="internalEvent"> Internal Representation of the AddParticipantsSucceededEvent. </param>
        internal AddParticipantsSucceeded(AddParticipantsSucceededInternal internalEvent)
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
        /// <summary> Participants added. </summary>
        public IReadOnlyList<CommunicationIdentifier> Participants { get; }
        /// <summary> Used to determine the version of the event. </summary>
        public string Version { get; }
        /// <summary> The public event namespace used as the &quot;type&quot; property in the CloudEvent. </summary>
        public string PublicEventType { get; }

        /// <summary>
        /// Deserialize <see cref="AddParticipantsSucceeded"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantsSucceeded"/> object.</returns>
        public static AddParticipantsSucceeded Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantsSucceededInternal.DeserializeAddParticipantsSucceededInternal(element);
            return new AddParticipantsSucceeded(internalEvent);
        }
    }
}
