// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The results of executing multiple actions on a set of documents.
    /// </summary>
    public class AnalyzeActionsResult
    {
        internal AnalyzeActionsResult(
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResults,
            IReadOnlyCollection<RecognizeEntitiesActionResult> recognizeEntitiesActionResults,
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults,
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> recognizeLinkedEntitiesActionResults,
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionResults,
            IReadOnlyCollection<ExtractSummaryActionResult> extractSummaryActionResults)
        {
            ExtractKeyPhrasesResults = extractKeyPhrasesActionResults;
            RecognizeEntitiesResults = recognizeEntitiesActionResults;
            RecognizePiiEntitiesResults = recognizePiiEntitiesActionResults;
            RecognizeLinkedEntitiesResults = recognizeLinkedEntitiesActionResults;
            AnalyzeSentimentResults = analyzeSentimentActionResults;
            ExtractSummaryResults = extractSummaryActionResults;
        }

        /// <summary>
        /// Determines the collection of <see cref="ExtractKeyPhrasesActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<ExtractKeyPhrasesActionResult> ExtractKeyPhrasesResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="RecognizeEntitiesActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<RecognizeEntitiesActionResult> RecognizeEntitiesResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="RecognizePiiEntitiesActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<RecognizePiiEntitiesActionResult> RecognizePiiEntitiesResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="RecognizeLinkedEntitiesActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> RecognizeLinkedEntitiesResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="AnalyzeSentimentActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<AnalyzeSentimentActionResult> AnalyzeSentimentResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="ExtractSummaryActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<ExtractSummaryActionResult> ExtractSummaryResults { get; }
    }
}
