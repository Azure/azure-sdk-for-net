// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Rooms.Models
{
    /// <summary>
    /// An Azure Communication Services Room.
    /// </summary>
    public class CommunicationRoom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationRoom"/> class.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdDateTime"></param>
        /// <param name="validFrom"></param>
        /// <param name="validUntil"></param>
        /// <param name="participants"></param>
        internal CommunicationRoom(string id, DateTimeOffset createdDateTime, DateTimeOffset validFrom, DateTimeOffset validUntil,
             IReadOnlyDictionary<string, object> participants)
        {
            Id = id;
            CreatedDateTime = createdDateTime;
            ValidFrom = validFrom;
            ValidUntil = validUntil;
            Participants = participants;
        }

        internal CommunicationRoom(CreateRoomResponse createRoomResponse)
        {
            Id = createRoomResponse.Room.Id;
            CreatedDateTime = createRoomResponse.Room.CreatedDateTime;
            ValidFrom = createRoomResponse.Room.ValidFrom;
            ValidUntil = createRoomResponse.Room.ValidUntil;
            Participants = createRoomResponse.Room.Participants;
        }

        internal CommunicationRoom(UpdateRoomResponse updateRoomResponse)
        {
            Id = updateRoomResponse.Room.Id;
            CreatedDateTime = updateRoomResponse.Room.CreatedDateTime;
            ValidFrom = updateRoomResponse.Room.ValidFrom;
            ValidUntil = updateRoomResponse.Room.ValidUntil;
            Participants = updateRoomResponse.Room.Participants;
       }

        internal CommunicationRoom(RoomModel roomModel)
        {
            Id = roomModel.Id;
            CreatedDateTime = roomModel.CreatedDateTime;
            ValidFrom = roomModel.ValidFrom;
            ValidUntil = roomModel.ValidUntil;
            Participants = roomModel.Participants;
        }

        /// <summary> Unique identifier of a room. This id is server generated. </summary>
        public string Id { get; }
        /// <summary> The timestamp when the room was created at the server. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? CreatedDateTime { get; }
        /// <summary> The timestamp from when the room is open for joining. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ValidFrom { get; }
        /// <summary> The timestamp from when the room can no longer be joined. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ValidUntil { get; }
        /// <summary> Collection of identities invited to the room. </summary>
        public IReadOnlyDictionary<string, object> Participants { get; }
    }
}
