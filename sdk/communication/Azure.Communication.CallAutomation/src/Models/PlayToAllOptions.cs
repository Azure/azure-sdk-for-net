﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// A PlaySource object representing the source to play.
        /// </summary>
        public IReadOnlyList<PlaySource> PlaySources { get; }

        /// <summary>
        /// The option to play the provided audio source in loop when set to true.
        /// </summary>
        public bool Loop { get; set; }

        /// <summary>
        /// The Operation Context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Creates a new PlayToAllOptions object.
        /// </summary>
        public PlayToAllOptions(PlaySource playSource)
        {
            List<PlaySource> playSources = new List<PlaySource>() { playSource };
            PlaySources = playSources;
        }

        /// <summary>
        /// Creates a new PlayToAllOptions object with list of play sources.
        /// </summary>
        public PlayToAllOptions(IEnumerable<PlaySource> playSources)
        {
            PlaySources = playSources.ToList();
        }
    }
}
