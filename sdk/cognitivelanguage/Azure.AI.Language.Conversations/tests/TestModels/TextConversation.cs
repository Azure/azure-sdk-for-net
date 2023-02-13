// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The TextConversation. </summary>
    public partial class TextConversation : Conversation
    {
        /// <summary> Initializes a new instance of TextConversation. </summary>
        /// <param name="id"> Unique identifier for the conversation. </param>
        /// <param name="language"> The language of the conversation item in BCP-47 format. </param>
        /// <param name="conversationItems"> Ordered list of text conversation items in the conversation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="language"/> or <paramref name="conversationItems"/> is null. </exception>
        public TextConversation(string id, string language, IEnumerable<TextConversationItem> conversationItems) : base(id, language)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(conversationItems, nameof(conversationItems));

            ConversationItems = conversationItems.ToList();
            Modality = InputModality.Text;
        }

        /// <summary> Ordered list of text conversation items in the conversation. </summary>
        public IList<TextConversationItem> ConversationItems { get; }
    }
}
