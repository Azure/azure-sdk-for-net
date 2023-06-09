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
        /// <param name="communicationIdentifier"> The communication identifier.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationIdentifier"/> is null. </exception>
        public RoomParticipant(CommunicationIdentifier communicationIdentifier)
        {
            Argument.AssertNotNull(communicationIdentifier, nameof(communicationIdentifier));
            CommunicationIdentifier = communicationIdentifier;
        }

        /// <summary> Initializes a new instance of RoomParticipant. </summary>
        /// <param name="rawId"> Raw ID representation of the communication identifier. Please refer to the following document for additional information on Raw ID. &lt;br&gt; https://learn.microsoft.com/azure/communication-services/concepts/identifiers?pivots=programming-language-rest#raw-id-representation. </param>
        /// <param name="role"> The role of a room participant. The default value is Attendee. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="rawId"/> is null. </exception>
        internal RoomParticipant(string rawId, ParticipantRole role)
        {
            Argument.AssertNotNull(rawId, nameof(rawId));
            CommunicationIdentifier = CommunicationIdentifier.FromRawId(rawId);
            RawId = rawId;
            Role = role;
        }

        /// <summary> Identifies a participant in Azure Communication services. A participant is, for example, a phone number or an Azure communication user. This model must be interpreted as a union: Apart from rawId, at most one further property may be set. </summary>
        public CommunicationIdentifier CommunicationIdentifier { get;}

        /// <summary> Role Name. </summary>
        public ParticipantRole Role { get; set; } = ParticipantRole.Attendee;

        /// <summary> Raw ID representation of the communication identifier. Please refer to the following document for additional information on Raw ID. &lt;br&gt; https://learn.microsoft.com/azure/communication-services/concepts/identifiers?pivots=programming-language-rest#raw-id-representation. </summary>
        internal string RawId { get; }
    }
}
