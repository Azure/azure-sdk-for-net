// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Rooms
{
    /// <summary> A participant of the room. </summary>
    [CodeGenModel("RoomParticipantInternal")]
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
        public RoomParticipant(CommunicationIdentifier communicationIdentifier, ParticipantRole role)
        {
            CommunicationIdentifier = communicationIdentifier;
            Role = role;
        }

        /// <summary> Identifies a participant in Azure Communication services. A participant is, for example, a phone number or an Azure communication user. This model must be interpreted as a union: Apart from rawId, at most one further property may be set. </summary>
        public CommunicationIdentifier CommunicationIdentifier { get;}

        /// <summary> Role Name. </summary>
        public ParticipantRole? Role { get; set; }

        /// <summary> Raw ID representation of the communication identifier. Please refer to the following document for additional information on Raw ID. &lt;br&gt; https://learn.microsoft.com/azure/communication-services/concepts/identifiers?pivots=programming-language-rest#raw-id-representation. </summary>
        internal string RawId { get; }
    }
}
