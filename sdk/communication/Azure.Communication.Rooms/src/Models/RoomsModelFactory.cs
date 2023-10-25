// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Rooms
{
    /// <summary> Model factory for read-only models. </summary>
    [CodeGenModel("CommunicationRoomsModelFactory")]
    public static partial class RoomsModelFactory
    {
        /// <summary> Initializes a new instance of CommunicationRoom. </summary>
        /// <param name="id"> Unique identifier of a room. This id is server generated. </param>
        /// <param name="createdAt"> The timestamp when the room was created at the server. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="validFrom"> The timestamp from when the room is open for joining. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <param name="validUntil"> The timestamp from when the room can no longer be joined. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <returns> A new <see cref="Rooms.CommunicationRoom"/> instance for mocking. </returns>
        public static CommunicationRoom CommunicationRoom(string id = null, DateTimeOffset createdAt = default, DateTimeOffset validFrom = default, DateTimeOffset validUntil = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return RoomsModelFactory.CommunicationRoom(id, createdAt, validFrom, validUntil, false);
        }

        /// <summary> Initializes a new instance of RoomParticipant. </summary>
        /// <param name="rawId"> Raw ID representation of the communication identifier. Please refer to the following document for additional information on Raw ID. &lt;br&gt; https://learn.microsoft.com/azure/communication-services/concepts/identifiers?pivots=programming-language-rest#raw-id-representation. </param>
        /// <param name="role"> The role of a room participant. The default value is Attendee. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="rawId"/> is null. </exception>
        /// <returns> A new <see cref="RoomParticipant"/> instance for mocking. </returns>
        public static RoomParticipant RoomParticipant(string rawId, ParticipantRole role)
        {
            if (rawId == null)
            {
                throw new ArgumentNullException(nameof(rawId));
            }
            return new RoomParticipant(rawId, role);
        }
    }
}
