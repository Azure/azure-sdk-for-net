// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Supported parameters for a Conversational sentiment analysis task. </summary>
    public partial class ConversationalSentimentTaskParameters : PreBuiltTaskParameters
    {
        /// <summary> Initializes a new instance of ConversationalSentimentTaskParameters. </summary>
        public ConversationalSentimentTaskParameters()
        {
        }

        /// <summary> Initializes a new instance of ConversationalSentimentTaskParameters. </summary>
        /// <param name="loggingOptOut"></param>
        /// <param name="modelVersion"></param>
        /// <param name="predictionSource"> For transcript conversations, this parameter provides information regarding which content type should be used for sentiment analysis. The details of the sentiment analysis - like the offset, length and the text itself - will correspond to the text type selected here. </param>
        internal ConversationalSentimentTaskParameters(bool? loggingOptOut, string modelVersion, TranscriptContentType? predictionSource) : base(loggingOptOut, modelVersion)
        {
            PredictionSource = predictionSource;
        }

        /// <summary> For transcript conversations, this parameter provides information regarding which content type should be used for sentiment analysis. The details of the sentiment analysis - like the offset, length and the text itself - will correspond to the text type selected here. </summary>
        public TranscriptContentType? PredictionSource { get; set; }
    }
}
