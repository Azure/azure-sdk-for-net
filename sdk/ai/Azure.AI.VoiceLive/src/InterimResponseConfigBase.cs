// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Base class for interim response configurations that provide user feedback
    /// during latency or tool execution delays in voice interactions.
    /// </summary>
    public abstract class InterimResponseConfigBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InterimResponseConfigBase"/>.
        /// </summary>
        protected InterimResponseConfigBase()
        {
            Triggers = new List<InterimResponseTrigger>();
        }

        /// <summary>
        /// Gets the collection of triggers that activate interim responses.
        /// </summary>
        public IList<InterimResponseTrigger> Triggers { get; }

        /// <summary>
        /// Gets or sets the latency threshold in milliseconds that triggers interim responses.
        /// When set, interim responses will be triggered if the response latency exceeds this value.
        /// </summary>
        public int? LatencyThresholdMs { get; set; }
    }
}