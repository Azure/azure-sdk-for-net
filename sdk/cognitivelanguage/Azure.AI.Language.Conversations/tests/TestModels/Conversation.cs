// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// A complete ordered set of utterances (spoken or written), by one or more speakers to be used for analysis.
    /// Please note <see cref="Conversation"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="TextConversation"/> and <see cref="TranscriptConversation"/>.
    /// </summary>
    public partial class Conversation
    {
        /// <summary> Initializes a new instance of Conversation. </summary>
        /// <param name="id"> Unique identifier for the conversation. </param>
        /// <param name="language"> The language of the conversation item in BCP-47 format. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="language"/> is null. </exception>
        public Conversation(string id, string language)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(language, nameof(language));

            Id = id;
            Language = language;
        }

        /// <summary> Unique identifier for the conversation. </summary>
        public string Id { get; }
        /// <summary> The language of the conversation item in BCP-47 format. </summary>
        public string Language { get; }
        /// <summary> Enumeration of supported conversational modalities. </summary>
        internal InputModality Modality { get; set; }
        /// <summary> Enumeration of supported conversational domains. </summary>
        public ConversationDomain? Domain { get; set; }
    }
}
