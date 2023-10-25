// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Rooms
{
    /// <summary> The ParticipantProperties. </summary>
    [CodeGenModel("ParticipantProperties")]
    internal partial class ParticipantProperties
    {
        /// <summary> Initializes a new instance of ParticipantProperties. </summary>
        internal ParticipantProperties()
        {
        }

        /// <summary> The role of a room participant. The default value is Attendee. </summary>
        internal ParticipantRole? Role { get; set; }
    }
}
