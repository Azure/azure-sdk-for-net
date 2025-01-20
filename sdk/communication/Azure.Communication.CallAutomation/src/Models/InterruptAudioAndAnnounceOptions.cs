// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options to be used in the Play operation.
    /// </summary>
    public class InterruptAudioAndAnnounceOptions
    {
        /// <summary>
        /// PlaySource objects representing the sources to play.
        /// </summary>
        public IReadOnlyList<PlaySource> Announcement { get; }

        /// <summary>
        /// A list of target identifiers to play the file to.
        /// </summary>
        public CommunicationIdentifier PlayTo { get; }

        /// <summary>
        /// The Operation Context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Creates a new PlayOptions object.
        /// </summary>
        public InterruptAudioAndAnnounceOptions(IEnumerable<PlaySource> announcement, CommunicationIdentifier playTo)
        {
            Announcement = announcement.ToList();
            PlayTo = playTo;
        }

        /// <summary>
        /// Creates a new PlayOptions object.
        /// </summary>
        public InterruptAudioAndAnnounceOptions(PlaySource announcement, CommunicationIdentifier playTo)
        {
            Announcement = new List<PlaySource> { announcement };
            PlayTo = playTo;
        }
    }
}
