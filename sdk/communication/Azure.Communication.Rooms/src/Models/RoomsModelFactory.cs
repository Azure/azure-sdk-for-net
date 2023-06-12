// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Communication.Rooms;
using Azure.Core;

namespace Azure.Communication.Rooms
{
    /// <summary> Model factory for read-only models. </summary>
    [CodeGenModel("RoomsModelFactory")]
    public static partial class RoomsModelFactory
    {
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
