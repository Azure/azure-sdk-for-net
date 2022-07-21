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
    public class AddParticipantsFailedEvent : CallingServerEventBase
    {
        /// <summary> Initializes a new instance of AddParticipantsFailedEvent. </summary>
        internal AddParticipantsFailedEvent()
        {
            Participants = new ChangeTrackingList<CommunicationIdentifier>();
        }

        /// <summary> Initializes a new instance of AddParticipantsFailedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the AddParticipantsFailedEvent. </param>
        internal AddParticipantsFailedEvent(AddParticipantsFailedEventInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInfo = internalEvent.ResultInfo;
            Participants = internalEvent.Participants.Select(t => CommunicationIdentifierSerializer.Deserialize(t)).ToList();
            Type = internalEvent.Type;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Operation context. </summary>
        public string OperationContext { get; }
        /// <summary> Gets the result info. </summary>
        public ResultInformation ResultInfo { get; }
        /// <summary> Participants failed to be added. </summary>
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
        /// Deserialize <see cref="AddParticipantsFailedEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AddParticipantsFailedEvent"/> object.</returns>
        public static AddParticipantsFailedEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = AddParticipantsFailedEventInternal.DeserializeAddParticipantsFailedEventInternal(element);
            return new AddParticipantsFailedEvent(internalEvent);
        }
    }
}
