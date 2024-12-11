// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for creating Interrupt Audio And Announce.
    /// </summary>
    public class InterruptAudioAndAnnounceOptions
    {
        /// <summary>
        /// PlaySource objects representing the sources to play.
        /// </summary>
        public IReadOnlyList<PlaySource> PlaySources { get; }

        /// <summary>
        /// A list of target identifiers to play the file to.
        /// </summary>
        public IReadOnlyList<CommunicationIdentifier> PlayTo { get; }

        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Creates a new InterruptAudioAndAnnounceOptions object.
        /// </summary>
        public InterruptAudioAndAnnounceOptions(IEnumerable<PlaySource> playSource, CommunicationIdentifier playTo)
        {
            PlaySources = playSource.ToList();
            PlayTo = new List<CommunicationIdentifier> { playTo };
        }
    }
}
