// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Channel affinity for a participant.
    /// </summary>
    public class ChannelAffinity
    {
        /// <summary> Channel number to which bitstream from a particular participant will be written. </summary>
        public int Channel { get; set; }

        /// <summary>
        /// The identifier for the participant whose bitstream will be written to the channel.
        /// represented by the channel number.
        /// </summary>
        public CommunicationIdentifier Participant { get; set; }
    }
}
