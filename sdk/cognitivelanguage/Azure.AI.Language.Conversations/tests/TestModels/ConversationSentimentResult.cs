// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The result from sentiment analysis operation for each conversation item. </summary>
    public partial class ConversationSentimentResult
    {
        /// <summary> Initializes a new instance of ConversationSentimentResult. </summary>
        /// <param name="conversationItems"> Enumeration of Sentiment operation results for all the conversation items in a conversation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversationItems"/> is null. </exception>
        public ConversationSentimentResult(IEnumerable<ConversationSentimentItemResult> conversationItems)
        {
            Argument.AssertNotNull(conversationItems, nameof(conversationItems));

            ConversationItems = conversationItems.ToList();
        }

        /// <summary> Initializes a new instance of ConversationSentimentResult. </summary>
        /// <param name="conversationItems"> Enumeration of Sentiment operation results for all the conversation items in a conversation. </param>
        internal ConversationSentimentResult(IList<ConversationSentimentItemResult> conversationItems)
        {
            ConversationItems = conversationItems;
        }

        /// <summary> Enumeration of Sentiment operation results for all the conversation items in a conversation. </summary>
        public IList<ConversationSentimentItemResult> ConversationItems { get; }
    }
}
