// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Mark Streaming Audio.
    /// </summary>
    public class MarkAudio : StreamingData
    {
        /// <summary>
        /// Sequence for the mark.
        /// </summary>
        public string Sequence { get; set; }
    }
}
