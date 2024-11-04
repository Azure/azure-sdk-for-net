// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Base class for Streaming Data
    /// </summary>
    public class OutStreamingData
    {
        /// <summary>
        /// Out streaming data kind ex. StopAudio, AudioData
        /// </summary>
        public MediaKind Kind { get; set; }

        /// <summary>
        /// Out streaming Audio Data
        /// </summary>
        public AudioData AudioData { get; set; }

        /// <summary>
        /// Out streaming Stop Audio Data
        /// </summary>s
        public StopAudio StopAudio { get; set; }
    }
}
