// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The context of the summary with conversation item id. </summary>
    public partial class ItemizedSummaryContext : SummaryContext
    {
        /// <summary> Initializes a new instance of ItemizedSummaryContext. </summary>
        /// <param name="offset"> Start position for the context. Use of different &apos;stringIndexType&apos; values can affect the offset returned. </param>
        /// <param name="length"> The length of the context. Use of different &apos;stringIndexType&apos; values can affect the length returned. </param>
        /// <param name="conversationItemId"> Reference to the id of ConversationItem. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversationItemId"/> is null. </exception>
        public ItemizedSummaryContext(int offset, int length, string conversationItemId) : base(offset, length)
        {
            Argument.AssertNotNull(conversationItemId, nameof(conversationItemId));

            ConversationItemId = conversationItemId;
        }

        /// <summary> Reference to the id of ConversationItem. </summary>
        public string ConversationItemId { get; set; }
    }
}
