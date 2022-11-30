// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The response returned by a Conversation project. </summary>
    public partial class ConversationResult
    {
        /// <summary> Initializes a new instance of ConversationResult. </summary>
        /// <param name="query"> The same query given in request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> is null. </exception>
        internal ConversationResult(string query)
        {
            Argument.AssertNotNull(query, nameof(query));

            Query = query;
        }

        /// <summary> Initializes a new instance of ConversationResult. </summary>
        /// <param name="query"> The same query given in request. </param>
        /// <param name="detectedLanguage"> The detected language from the query in BCP 47 language representation.. </param>
        /// <param name="prediction"> The predicted result for the query. </param>
        internal ConversationResult(string query, string detectedLanguage, ConversationPrediction prediction)
        {
            Query = query;
            DetectedLanguage = detectedLanguage;
            Prediction = prediction;
        }

        /// <summary> The same query given in request. </summary>
        public string Query { get; }
        /// <summary> The detected language from the query in BCP 47 language representation.. </summary>
        public string DetectedLanguage { get; }
        /// <summary> The predicted result for the query. </summary>
        public ConversationPrediction Prediction { get; }
    }
}
