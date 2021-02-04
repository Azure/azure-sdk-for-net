// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="JobMetadata"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    public class AnalyzeBatchActionsResult
    {
        /// <summary>
        /// AnalyzeBatchActionsResult
        /// </summary>
        internal AnalyzeBatchActionsResult(AnalyzeJobState jobState, IDictionary<string, int> map)
        {
            ExtractKeyPhrasesActionsResults = Transforms.ConvertToExtractKeyPhrasesActionResults(jobState, map);
            RecognizeEntitiesActionsResults = Transforms.ConvertToRecognizeEntitiesActionsResults(jobState, map);
            RecognizePiiEntitiesActionsResults = Transforms.ConvertToRecognizePiiEntitiesActionsResults(jobState, map);
        }

        /// <summary>
        /// Collection for ExtractKeyPhrasesActionsResults
        /// </summary>
        public IReadOnlyCollection<ExtractKeyPhrasesActionResult> ExtractKeyPhrasesActionsResults { get; }

        /// <summary>
        /// RecognizeEntitiesActionsResults
        /// </summary>
        public IReadOnlyCollection<RecognizeEntitiesActionResult> RecognizeEntitiesActionsResults { get; }

        /// <summary>
        /// RecognizePiiEntitiesActionsResults
        /// </summary>
        public IReadOnlyCollection<RecognizePiiEntitiesActionResult> RecognizePiiEntitiesActionsResults { get; }

        /// <summary>
        /// Statistics
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }
    }
}
