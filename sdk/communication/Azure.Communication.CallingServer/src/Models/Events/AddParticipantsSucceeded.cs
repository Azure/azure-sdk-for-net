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
    public class AddParticipantsSucceeded: CallingServerEventBase
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
            OperationContext = internalEvent.OperationContext;
            ResultInfo = internalEvent.ResultInfo;
            Participants = internalEvent.Participants.Select(t => CommunicationIdentifierSerializer.Deserialize(t)).ToList();
            EventType = internalEvent.EventType;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Operation context. </summary>
        public string OperationContext { get; }
        /// <summary> Gets the result info. </summary>
        public ResultInformation ResultInfo { get; }
        /// <summary> Participants added. </summary>
        public IReadOnlyList<CommunicationIdentifier> Participants { get; }
        /// <summary> Call connection ID. </summary>
        public string CallConnectionId { get; }
        /// <summary> Server call ID. </summary>
        public string ServerCallId { get; }
        /// <summary> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </summary>
        public string CorrelationId { get; }
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
