// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> Channel affinity for a participant. </summary>
    public class ChannelAffinity
    {
        /// <summary> Initializes a new instance of ChannelAffinityInternal. </summary>
        /// <param name="participant">
        /// The identifier for the participant whose bitstream will be written to the channel.
        /// represented by the channel number.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="participant"/> is null. </exception>
        public ChannelAffinity(CommunicationIdentifier participant)
        {
            Argument.AssertNotNull(participant, nameof(participant));

            Participant = participant;
        }

        /// <summary>
        /// The identifier for the participant whose bitstream will be written to the channel.
        /// represented by the channel number.
        /// </summary>
        public CommunicationIdentifier Participant { get; }

        /// <summary> Channel number to which bitstream from a particular participant will be written. </summary>
        public int? Channel { get; set; }
    }
}
