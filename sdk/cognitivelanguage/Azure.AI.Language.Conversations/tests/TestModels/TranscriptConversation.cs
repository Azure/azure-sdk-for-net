// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The TranscriptConversation. </summary>
    public partial class TranscriptConversation : Conversation
    {
        /// <summary> Initializes a new instance of TranscriptConversation. </summary>
        /// <param name="id"> Unique identifier for the conversation. </param>
        /// <param name="language"> The language of the conversation item in BCP-47 format. </param>
        /// <param name="conversationItems"> Ordered list of transcript conversation items in the conversation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="language"/> or <paramref name="conversationItems"/> is null. </exception>
        public TranscriptConversation(string id, string language, IEnumerable<TranscriptConversationItem> conversationItems) : base(id, language)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(language, nameof(language));
            Argument.AssertNotNull(conversationItems, nameof(conversationItems));

            ConversationItems = conversationItems.ToList();
            Modality = InputModality.Transcript;
        }

        /// <summary> Ordered list of transcript conversation items in the conversation. </summary>
        public IList<TranscriptConversationItem> ConversationItems { get; }
    }
}
