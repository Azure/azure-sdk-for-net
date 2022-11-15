// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The ConversationSentimentItemResult. </summary>
    public partial class ConversationSentimentItemResult
    {
        /// <summary> Initializes a new instance of ConversationSentimentItemResult. </summary>
        /// <param name="id"> The identifier for the conversation item. </param>
        /// <param name="participantId"> The identifier for the speaker. </param>
        /// <param name="sentiment"> Predicted sentiment. </param>
        /// <param name="confidenceScores"> Represents the confidence scores between 0 and 1 across all sentiment classes: positive, neutral, negative. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="participantId"/> or <paramref name="confidenceScores"/> is null. </exception>
        public ConversationSentimentItemResult(string id, string participantId, TextSentiment sentiment, SentimentConfidenceScores confidenceScores)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(participantId, nameof(participantId));
            Argument.AssertNotNull(confidenceScores, nameof(confidenceScores));

            Id = id;
            ParticipantId = participantId;
            Sentiment = sentiment;
            ConfidenceScores = confidenceScores;
        }

        /// <summary> The identifier for the conversation item. </summary>
        public string Id { get; set; }
        /// <summary> The identifier for the speaker. </summary>
        public string ParticipantId { get; set; }
        /// <summary> Predicted sentiment. </summary>
        public TextSentiment Sentiment { get; set; }
        /// <summary> Represents the confidence scores between 0 and 1 across all sentiment classes: positive, neutral, negative. </summary>
        public SentimentConfidenceScores ConfidenceScores { get; set; }
    }
}
