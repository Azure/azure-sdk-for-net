// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Streaming metadata
    /// </summary>
    public class MediaStreamingMetadata : MediaStreamingPackageBase
    {
        /// <summary>
        /// Subscription Id.
        /// </summary>
        public string MediaSubscriptionId { get; }

        /// <summary>
        /// Format.
        /// </summary>
        public MediaStreamingFormat Format { get; }

        internal MediaStreamingMetadata(string mediaSubscriptionId, MediaStreamingFormat format)
        {
            MediaSubscriptionId = mediaSubscriptionId;
            Format = format;
        }
    }
}
