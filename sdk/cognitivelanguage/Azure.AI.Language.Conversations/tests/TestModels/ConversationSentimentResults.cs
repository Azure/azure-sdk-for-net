// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The result from sentiment analysis operation for each conversation. </summary>
    public partial class ConversationSentimentResults : PreBuiltResult
    {
        /// <summary> Initializes a new instance of ConversationSentimentResults. </summary>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <param name="conversations"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="errors"/>, <paramref name="modelVersion"/> or <paramref name="conversations"/> is null. </exception>
        public ConversationSentimentResults(IEnumerable<InputError> errors, string modelVersion, IEnumerable<ConversationSentimentResultsConversationsItem> conversations) : base(errors, modelVersion)
        {
            Argument.AssertNotNull(errors, nameof(errors));
            Argument.AssertNotNull(modelVersion, nameof(modelVersion));
            Argument.AssertNotNull(conversations, nameof(conversations));

            Conversations = conversations.ToList();
        }

        /// <summary> Initializes a new instance of ConversationSentimentResults. </summary>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <param name="conversations"></param>
        internal ConversationSentimentResults(IList<InputError> errors, RequestStatistics statistics, string modelVersion, IList<ConversationSentimentResultsConversationsItem> conversations) : base(errors, statistics, modelVersion)
        {
            Conversations = conversations;
        }

        /// <summary> Gets the conversations. </summary>
        public IList<ConversationSentimentResultsConversationsItem> Conversations { get; }
    }
}
