// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Rooms
{
    /// <summary> A participant invited to the room. </summary>
    public class InvitedRoomParticipant
    {
        /// <summary> Initializes a new instance of InvitedRoomParticipant. </summary>
        /// <param name="communicationIdentifier"> Identifies a participant in Azure Communication services. A participant is, for example, a phone number or an Azure communication user. This model must be interpreted as a union: Apart from rawId, at most one further property may be set. </param>
        public InvitedRoomParticipant(CommunicationIdentifier communicationIdentifier)
        {
            CommunicationIdentifier = communicationIdentifier;
        }
        /// <summary> Identifies a participant in Azure Communication services. A participant is, for example, a phone number or an Azure communication user. This model must be interpreted as a union: Apart from rawId, at most one further property may be set. </summary>
        public CommunicationIdentifier CommunicationIdentifier { get; }

        /// <summary> Role Name. </summary>
        public ParticipantRole? Role { get; set; }
    }
}
