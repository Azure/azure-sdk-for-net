// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub.Chat
{
    /// <summary> Options for querying messages in a conversation. </summary>
    public class MessageQueryOptions
    {
        /// <summary> Gets or sets the latest message ID (exclusive) for pagination. </summary>
        public string LatestMessageId { get; set; }

        /// <summary> Gets or sets the earliest message ID (exclusive) for pagination. </summary>
        public string EarliestMessageId { get; set; }

        /// <summary> Gets or sets the maximum number of result items per page. </summary>
        public int? MaxPageSize { get; set; }
    }
}