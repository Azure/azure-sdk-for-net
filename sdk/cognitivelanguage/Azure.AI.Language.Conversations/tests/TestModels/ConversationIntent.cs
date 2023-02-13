// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The intent classification result of a Conversation project. </summary>
    public partial class ConversationIntent
    {
        /// <summary> Initializes a new instance of ConversationIntent. </summary>
        /// <param name="category"> A predicted class. </param>
        /// <param name="confidence"> The confidence score of the class from 0.0 to 1.0. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="category"/> is null. </exception>
        internal ConversationIntent(string category, float confidence)
        {
            Argument.AssertNotNull(category, nameof(category));

            Category = category;
            Confidence = confidence;
        }

        /// <summary> A predicted class. </summary>
        public string Category { get; }
        /// <summary> The confidence score of the class from 0.0 to 1.0. </summary>
        public float Confidence { get; }
    }
}
