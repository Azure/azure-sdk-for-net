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
    public class PlayOptions
    {
        /// <summary>
        /// PlaySource objects representing the sources to play.
        /// </summary>
        public IReadOnlyList<PlaySource> PlaySources { get; }

        /// <summary>
        /// A list of target identifiers to play the file to.
        /// </summary>
        public IReadOnlyList<CommunicationIdentifier> PlayTo { get; }

        /// <summary>
        /// The option to play the provided audio source in loop when set to true.
        /// </summary>
        public bool Loop { get; set; }

        /// <summary>
        /// The Operation Context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The callback URI that overrides the default callback URI set by CreateCall/AnswerCall for this operation.
        /// This setup is per-action. If this is not set, the default callback URI set by CreateCall/AnswerCall will be used.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }

        /// <summary>
        /// If set play can barge into other existing queued-up/currently-processing requests.
        /// </summary>
        internal bool InterruptCallMediaOperation { get; set; }

        /// <summary>
        /// Creates a new PlayOptions object.
        /// </summary>
        public PlayOptions(IEnumerable<PlaySource> playSources, IEnumerable<CommunicationIdentifier> playTo)
        {
            PlaySources = playSources.ToList();
            PlayTo = playTo.ToList();
        }

        /// <summary>
        /// Creates a new PlayOptions object.
        /// </summary>
        public PlayOptions(PlaySource playSource, IEnumerable<CommunicationIdentifier> playTo)
        {
            PlaySources = new List<PlaySource> { playSource };
            PlayTo = playTo.ToList();
        }
    }
}
