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
        /// <summary> Initializes a new instance of AddParticipantsFailed event. </summary>
        internal AddParticipantsFailed()
        {
            Participants = new ChangeTrackingList<CommunicationIdentifier>();
        }

        /// <summary> Initializes a new instance of AddParticipantsFailed event. </summary>
        /// <param name="internalEvent">Internal Representation of the AddParticipantsFailed event. </param>
        internal AddParticipantsFailed(AddParticipantsFailedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            Participants = internalEvent.Participants.Select(t => CommunicationIdentifierSerializer.Deserialize(t)).ToList();
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }
        /// <summary> Operation context. </summary>
        public override string OperationContext { get; internal set; }
        /// <summary> Gets the result info. </summary>
        public override ResultInformation ResultInformation { get; internal set; }
        /// <summary> Participants failed to be added. </summary>
        public IReadOnlyList<CommunicationIdentifier> Participants { get; }

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
