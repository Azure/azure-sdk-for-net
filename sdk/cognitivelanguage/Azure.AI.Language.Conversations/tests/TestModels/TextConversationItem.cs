// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The text modality of an input conversation. </summary>
    public partial class TextConversationItem : ConversationItemBase
    {
        /// <summary> Initializes a new instance of TextConversationItem. </summary>
        /// <param name="id"> The ID of a conversation item. </param>
        /// <param name="participantId"> The participant ID of a conversation item. </param>
        /// <param name="text"> The text input. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="participantId"/> or <paramref name="text"/> is null. </exception>
        public TextConversationItem(string id, string participantId, string text) : base(id, participantId)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(participantId, nameof(participantId));
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
        }

        /// <summary> The text input. </summary>
        public string Text { get; }
    }
}
