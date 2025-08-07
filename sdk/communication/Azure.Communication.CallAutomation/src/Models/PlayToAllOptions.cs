// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options to be used in the PlayToAll operation.
    /// </summary>
    public class PlayToAllOptions
    {
        /// <summary>
        /// PlaySource objects representing the sources to play.
        /// </summary>
        public IReadOnlyList<PlaySource> PlaySources { get; }

        /// <summary>
        /// The option to play the provided audio source in loop when set to true.
        /// </summary>
        public bool Loop { get; set; }

        /// <summary>
        /// If set play can barge into other existing queued-up/currently-processing requests.
        /// </summary>
        public bool InterruptCallMediaOperation { get; set; }

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
        /// Creates a new PlayToAllOptions object.
        /// </summary>
        public PlayToAllOptions(IEnumerable<PlaySource> playSources)
        {
            PlaySources = playSources.ToList();
        }

        /// <summary>
        /// Creates a new PlayToAllOptions object.
        /// </summary>
        public PlayToAllOptions(PlaySource playSource)
        {
            PlaySources = new List<PlaySource> { playSource };
        }
    }
}
