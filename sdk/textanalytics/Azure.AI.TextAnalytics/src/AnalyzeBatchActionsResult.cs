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
            ExtractKeyPhrasesActionResults = Transforms.ConvertToExtractKeyPhrasesActionResults(jobState, map);
            RecognizeEntitiesActionResults = Transforms.ConvertToRecognizeEntitiesActionsResults(jobState, map);
            RecognizePiiEntitiesActionResults = Transforms.ConvertToRecognizePiiEntitiesActionsResults(jobState, map);
        }

        /// <summary>
        /// Collection for ExtractKeyPhrasesActionsResults
        /// </summary>
        public ExtractKeyPhrasesActionResults ExtractKeyPhrasesActionResults { get; }

        /// <summary>
        /// RecognizeEntitiesActionsResults
        /// </summary>
        public RecognizeEntitiesActionResults RecognizeEntitiesActionResults { get; }

        /// <summary>
        /// RecognizePiiEntitiesActionsResults
        /// </summary>
        public RecognizePiiEntitiesActionResults RecognizePiiEntitiesActionResults { get; }

        /// <summary>
        /// Statistics
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }
    }
}
