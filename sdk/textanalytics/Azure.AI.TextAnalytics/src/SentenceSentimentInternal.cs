// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("SentenceSentiment")]
    internal partial struct SentenceSentimentInternal
    {
        /// <summary> The sentence text. </summary>
        public string Text { get; }
        /// <summary> The predicted Sentiment for the sentence. </summary>
        public string Sentiment { get; }
        /// <summary> The sentiment confidence score between 0 and 1 for the sentence for all classes. </summary>
        public SentimentConfidenceScores ConfidenceScores { get; }
        /// <summary> The sentence offset from the start of the document. </summary>
        public int Offset { get; }
        /// <summary> The length of the sentence. </summary>
        public int Length { get; }
        /// <summary> The array of aspect object for the sentence. </summary>
        public IReadOnlyList<SentenceAspect> Aspects { get; }
        /// <summary> The array of opinion object for the sentence. </summary>
        public IReadOnlyList<SentenceOpinion> Opinions { get; }
    }
}
