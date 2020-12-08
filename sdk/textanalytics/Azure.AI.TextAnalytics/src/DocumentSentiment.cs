// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Overall predicted sentiment and confidence scores for the document.
    /// It also includes per-sentence sentiment prediction.
    /// <para>For more information regarding text sentiment, see
    /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/how-tos/text-analytics-how-to-sentiment-analysis"/>.</para>
    /// </summary>
    public class DocumentSentiment
    {
        internal DocumentSentiment(TextSentiment sentiment, double positiveScore, double neutralScore, double negativeScore, List<SentenceSentiment> sentenceSentiments, IList<TextAnalyticsWarning> warnings)
        {
            Sentiment = sentiment;
            ConfidenceScores = new SentimentConfidenceScores(positiveScore, neutralScore, negativeScore);
            Sentences = new ReadOnlyCollection<SentenceSentiment>(sentenceSentiments);
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        internal DocumentSentiment(DocumentSentimentInternal documentSentiment)
        {
            Sentiment = documentSentiment.Sentiment;
            ConfidenceScores = documentSentiment.ConfidenceScores;
            Sentences = ConvertToSentences(documentSentiment.Sentences);
            Warnings = Transforms.ConvertToWarnings(documentSentiment.Warnings);
        }

        /// <summary>
        /// Gets the predicted sentiment for the analyzed document.
        /// </summary>
        public TextSentiment Sentiment { get; }

        /// <summary>
        /// Gets the sentiment confidence score (Softmax score) between 0 and 1,
        /// for each sentiment. Higher values signify higher confidence.
        /// </summary>
        public SentimentConfidenceScores ConfidenceScores { get; }

        /// <summary>
        /// Gets the predicted sentiment and other analysis like Opinion mining
        /// for each sentence in the corresponding document.
        /// </summary>
        public IReadOnlyCollection<SentenceSentiment> Sentences { get; }

        /// <summary>
        /// Gets the warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        private static List<SentenceSentiment> ConvertToSentences(IReadOnlyList<SentenceSentimentInternal> internalSentences)
        {
            var sentences = new List<SentenceSentiment>();
            foreach (var sentence in internalSentences)
            {
                sentences.Add(new SentenceSentiment(sentence, internalSentences));
            }
            return sentences;
        }
    }
}
