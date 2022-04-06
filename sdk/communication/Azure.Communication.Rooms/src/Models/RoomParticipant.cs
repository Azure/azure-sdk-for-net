// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Rooms.Models
{
    /// <summary>
    /// An Azure Communication Services Room Participant.
    /// </summary>
    public partial class RoomParticipant
    {
        /// <summary>
        /// An Azure Communication Services Room.
        /// </summary>
        /// <param name="identifier">I</param>
        /// <param name="roleName"></param>
        public RoomParticipant(string identifier, string roleName)
        {
            Identifier = identifier;
            RoleName = roleName;
        }

        /// <summary> The identifer of participant in Acs User Identifer format. </summary>
        public string Identifier { get; set; }
        /// <summary> The prebuilt role name. </summary>
        public string RoleName { get; set; }

        internal RoomParticipantInternal ToRoomParticipantInternal()
        {
            if (String.IsNullOrEmpty(RoleName))
            {
                return null;
            }
            return new RoomParticipantInternal(RoleName);
        }
    }
}
