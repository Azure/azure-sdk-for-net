// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Communication.Rooms.Models;

namespace Azure.Communication.Rooms
{
    /// <summary> A participant of the room. </summary>
    public partial class RoomParticipant
    {
        /// <summary> Initializes a new instance of RoomParticipant. </summary>
        /// <param name="communicationIdentifier"> Identifies a participant in Azure Communication services. A participant is, for example, a phone number or an Azure communication user. This model must be interpreted as a union: Apart from rawId, at most one further property may be set. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationIdentifier"/> is null. </exception>
        public RoomParticipant(CommunicationIdentifier communicationIdentifier)
        {
            Argument.CheckNotNull(communicationIdentifier, nameof(communicationIdentifier));
            CommunicationIdentifier = communicationIdentifier;
        }

        /// <summary> Initializes a new instance of RoomParticipant. </summary>
        /// <param name="communicationIdentifier"> Identifies a participant in Azure Communication services. A participant is, for example, a phone number or an Azure communication user. This model must be interpreted as a union: Apart from rawId, at most one further property may be set. </param>
        /// <param name="role"> Role Name. </param>
        public RoomParticipant(CommunicationIdentifier communicationIdentifier, RoleType role)
        {
            CommunicationIdentifier = communicationIdentifier;
            Role = role;
        }

        internal RoomParticipant(RoomParticipantInternal roomParticipantInternal)
        {
            CommunicationIdentifier = CommunicationIdentifierSerializer.Deserialize(roomParticipantInternal.CommunicationIdentifier);
            Role = roomParticipantInternal.Role;
        }

        /// <summary> Identifies a participant in Azure Communication services. A participant is, for example, a phone number or an Azure communication user. This model must be interpreted as a union: Apart from rawId, at most one further property may be set. </summary>
        public CommunicationIdentifier CommunicationIdentifier { get;}
        /// <summary> Role Name. </summary>
        public RoleType? Role { get; set; }

        internal RoomParticipantInternal ToRoomParticipantInternal()
        {
            return new RoomParticipantInternal(CommunicationIdentifierSerializer.Serialize(CommunicationIdentifier), Role);
        }
    }
}
