// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Base class for Out Streaming Data
    /// </summary>
    public class OutStreamingData
    {
        /// <summary>
        /// Create the new instance of outstreamingdata with kind
        /// </summary>
        /// <param name="kind"></param>
        public OutStreamingData(MediaKind kind)
        {
            this.Kind = kind;
        }

        /// <summary>
        /// Out streaming data kind ex. StopAudio, AudioData
        /// </summary>
        public MediaKind Kind { get; }

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
