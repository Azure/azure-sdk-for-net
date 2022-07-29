// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Optional parameters for the Start Recording operation.
    /// </summary>
    public class StartRecordingOptions
    {
        /// <summary>
        /// The recording channel.
        /// </summary>
        public RecordingChannel RecordingChannel { get; set; }

        /// <summary>
        /// The recording content.
        /// </summary>
        public RecordingContent RecordingContent { get; set; }

        /// <summary>
        /// The recording format.
        /// </summary>
        public RecordingFormat RecordingFormat { get; set; }
    }
}
