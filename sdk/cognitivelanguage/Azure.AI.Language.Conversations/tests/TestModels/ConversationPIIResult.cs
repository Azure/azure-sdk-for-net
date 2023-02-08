// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The result from PII detection and redaction operation for each conversation. </summary>
    public partial class ConversationPIIResult
    {
        /// <summary> Initializes a new instance of ConversationPIIResult. </summary>
        /// <param name="conversationItems"> Enumeration of PII detection and redaction operation results for all the conversation items in a conversation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversationItems"/> is null. </exception>
        public ConversationPIIResult(IEnumerable<ConversationPIIItemResult> conversationItems)
        {
            Argument.AssertNotNull(conversationItems, nameof(conversationItems));

            ConversationItems = conversationItems.ToList();
        }

        /// <summary> Initializes a new instance of ConversationPIIResult. </summary>
        /// <param name="conversationItems"> Enumeration of PII detection and redaction operation results for all the conversation items in a conversation. </param>
        internal ConversationPIIResult(IList<ConversationPIIItemResult> conversationItems)
        {
            ConversationItems = conversationItems;
        }

        /// <summary> Enumeration of PII detection and redaction operation results for all the conversation items in a conversation. </summary>
        public IList<ConversationPIIItemResult> ConversationItems { get; }
    }
}
