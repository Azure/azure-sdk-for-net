// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The MultiLanguageConversationAnalysisInput. </summary>
    public partial class MultiLanguageConversationAnalysisInput
    {
        /// <summary> Initializes a new instance of MultiLanguageConversationAnalysisInput. </summary>
        /// <param name="conversations">
        /// Please note <see cref="Conversation"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="TextConversation"/> and <see cref="TranscriptConversation"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="conversations"/> is null. </exception>
        public MultiLanguageConversationAnalysisInput(IEnumerable<Conversation> conversations)
        {
            Argument.AssertNotNull(conversations, nameof(conversations));

            Conversations = conversations.ToList();
        }

        /// <summary>
        /// Gets the conversations
        /// Please note <see cref="Conversation"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="TextConversation"/> and <see cref="TranscriptConversation"/>.
        /// </summary>
        public IList<Conversation> Conversations { get; }
    }
}
