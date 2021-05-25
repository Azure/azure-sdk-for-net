// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The results of executing multiple actions in a set of documents.
    /// </summary>
    public class AnalyzeActionsResult
    {
        internal AnalyzeActionsResult(
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResult,
            IReadOnlyCollection<RecognizeEntitiesActionResult> recognizeEntitiesActionResults,
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults,
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> recognizeLinkedEntitiesActionsResults,
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults,
            TextDocumentBatchStatistics statistics)
        {
            ExtractKeyPhrasesActionsResults = extractKeyPhrasesActionResult;
            RecognizeEntitiesActionsResults = recognizeEntitiesActionResults;
            RecognizePiiEntitiesActionsResults = recognizePiiEntitiesActionResults;
            RecognizeLinkedEntitiesActionsResults = recognizeLinkedEntitiesActionsResults;
            AnalyzeSentimentActionsResults = analyzeSentimentActionsResults;
            Statistics = statistics;
        }

        /// <summary>
        /// Determines the collection of ExtractKeyPhrasesActionResult.
        /// </summary>
        public IReadOnlyCollection<ExtractKeyPhrasesActionResult> ExtractKeyPhrasesActionsResults { get; }

        /// <summary>
        /// Determines the collection of RecognizeEntitiesActionResult.
        /// </summary>
        public IReadOnlyCollection<RecognizeEntitiesActionResult> RecognizeEntitiesActionsResults { get; }

        /// <summary>
        /// Determines the collection of RecognizePiiEntitiesActionResult.
        /// </summary>
        public IReadOnlyCollection<RecognizePiiEntitiesActionResult> RecognizePiiEntitiesActionsResults { get; }

        /// <summary>
        /// Determines the collection of RecognizeLinkedEntitiesActionsResult.
        /// </summary>
        public IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> RecognizeLinkedEntitiesActionsResults { get; }

        /// <summary>
        /// Determines the collection of AnalyzeSentimentActionsResults.
        /// </summary>
        public IReadOnlyCollection<AnalyzeSentimentActionResult> AnalyzeSentimentActionsResults { get; }

        /// <summary>
        /// Gets statistics about the operation executed and how it was processed
        /// by the service.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }
    }
}
