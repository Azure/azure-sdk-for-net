// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The results of an analyze batch actions operation.
    /// </summary>
    public class AnalyzeBatchActionsResult
    {
        internal AnalyzeBatchActionsResult(IReadOnlyCollection<ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResult, IReadOnlyCollection<RecognizeEntitiesActionResult> recognizeEntitiesActionResults, IReadOnlyCollection<RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults, TextDocumentBatchStatistics statistics)
        {
            ExtractKeyPhrasesActionsResults = extractKeyPhrasesActionResult;
            RecognizeEntitiesActionsResults = recognizeEntitiesActionResults;
            RecognizePiiEntitiesActionsResults = recognizePiiEntitiesActionResults;
            Statistics = statistics;
        }

        internal AnalyzeBatchActionsResult(AnalyzeJobState jobState, IDictionary<string, int> map)
        {
            AnalyzeBatchActionsResult actionResults = Transforms.ConvertToAnalyzeBatchActionsResult(jobState, map);
            ExtractKeyPhrasesActionsResults = actionResults.ExtractKeyPhrasesActionsResults;
            RecognizeEntitiesActionsResults = actionResults.RecognizeEntitiesActionsResults;
            RecognizePiiEntitiesActionsResults = actionResults.RecognizePiiEntitiesActionsResults;
            Statistics = actionResults.Statistics;
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
        /// <summary> if showStats=true was specified in the request this field will contain information about the document payload. </summary>
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }
    }
}
