// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Rooms
{
    /// <summary>
    /// The Azure Communication Services Rooms Create Options
    /// </summary>
    public class UpdateRoomOptions
    {
        /// <summary> The timestamp from when the room is open for joining. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ValidFrom { get; set; }

        /// <summary> The timestamp from when the room can no longer be joined. The timestamp is in RFC3339 format: `yyyy-MM-ddTHH:mm:ssZ`. </summary>
        public DateTimeOffset? ValidUntil { get; set; }

        /// <summary> Set this flag to true if, at the time of the call, dial out to a PSTN number is enabled in a particular room. By default, this flag is set to false. </summary>
        public bool? PstnDialOutEnabled { get; set; }
    }
}
