// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallingServer.Models.MediaStreaming
{
    internal class MediaStreamingMetadataInternal
    {
        /// <summary>
        /// Subscription Id.
        /// </summary>
        [JsonPropertyName("subscriptionId")]
        public string MediaSubscriptionId { get; set; }

        /// <summary>
        /// Format.
        /// </summary>
        [JsonPropertyName("format")]
        public MediaStreamingFormatInternal Format { get; set; }
    }
}
