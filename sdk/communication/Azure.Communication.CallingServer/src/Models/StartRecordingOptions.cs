// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Options for the Start Recording operation.
    /// </summary>
    public class StartRecordingOptions
    {
        /// <summary>
        /// Parameters for the Start Recording operation.
        /// </summary>
        /// <param name="callLocator"> . </param>
        public StartRecordingOptions(CallLocator callLocator)
        {
            CallLocator = callLocator ?? throw new ArgumentNullException(nameof(callLocator));
        }

        /// <summary>
        /// The callLocator.
        /// </summary>
        internal CallLocator CallLocator { get; }

        /// <summary>
        /// The callLocator.
        /// </summary>
        public Uri RecordingStateCallbackEndpoint { get; set; }

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

        /// <summary>
        /// Channel affinity for a participant.
        /// </summary>
        public IEnumerable<ChannelAffinity> ChannelAffinity { get; set; }
    }
}
