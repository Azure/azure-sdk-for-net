// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The input ConversationItem and its optional parameters. </summary>
    public partial class ConversationAnalysisOptions
    {
        /// <summary> Initializes a new instance of ConversationAnalysisOptions. </summary>
        /// <param name="conversationItem"> The abstract base for a user input formatted conversation (e.g., Text, Transcript). </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversationItem"/> is null. </exception>
        public ConversationAnalysisOptions(ConversationItemBase conversationItem)
        {
            Argument.AssertNotNull(conversationItem, nameof(conversationItem));

            ConversationItem = conversationItem;
        }

        /// <summary> The abstract base for a user input formatted conversation (e.g., Text, Transcript). </summary>
        public ConversationItemBase ConversationItem { get; }
    }
}
