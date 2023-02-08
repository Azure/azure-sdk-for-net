// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            IReadOnlyCollection<RecognizeCustomEntitiesActionResult> recognizeCustomEntitiesActionResults,
            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionResults,
            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionResults,
            IReadOnlyCollection<AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntitiesActionResults,
            IReadOnlyCollection<ExtractSummaryActionResult> extractSummaryActionResults,
            IReadOnlyCollection<AbstractSummaryActionResult> abstractSummaryActionResults
            )
        {
            ExtractKeyPhrasesResults = extractKeyPhrasesActionResults;
            RecognizeEntitiesResults = recognizeEntitiesActionResults;
            RecognizePiiEntitiesResults = recognizePiiEntitiesActionResults;
            RecognizeLinkedEntitiesResults = recognizeLinkedEntitiesActionResults;
            AnalyzeSentimentResults = analyzeSentimentActionResults;
            RecognizeCustomEntitiesResults = recognizeCustomEntitiesActionResults;
            SingleLabelClassifyResults = singleLabelClassifyActionResults;
            MultiLabelClassifyResults = multiLabelClassifyActionResults;
            AnalyzeHealthcareEntitiesResults = analyzeHealthcareEntitiesActionResults;
            ExtractSummaryResults = extractSummaryActionResults;
            AbstractSummaryResults = abstractSummaryActionResults;
        }

        internal AnalyzeActionsResult(
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> extractKeyPhrasesActionResults,
            IReadOnlyCollection<RecognizeEntitiesActionResult> recognizeEntitiesActionResults,
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults,
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> recognizeLinkedEntitiesActionResults,
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionResults
            )
        {
            ExtractKeyPhrasesResults = extractKeyPhrasesActionResults;
            RecognizeEntitiesResults = recognizeEntitiesActionResults;
            RecognizePiiEntitiesResults = recognizePiiEntitiesActionResults;
            RecognizeLinkedEntitiesResults = recognizeLinkedEntitiesActionResults;
            AnalyzeSentimentResults = analyzeSentimentActionResults;
            SingleLabelClassifyResults = Array.Empty<SingleLabelClassifyActionResult>();
            MultiLabelClassifyResults = Array.Empty<MultiLabelClassifyActionResult>();
            RecognizeCustomEntitiesResults = Array.Empty<RecognizeCustomEntitiesActionResult>();
            AnalyzeHealthcareEntitiesResults = Array.Empty<AnalyzeHealthcareEntitiesActionResult>();
            ExtractSummaryResults = Array.Empty<ExtractSummaryActionResult>();
            AbstractSummaryResults = Array.Empty<AbstractSummaryActionResult>();
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
        /// Determines the collection of <see cref="RecognizeCustomEntitiesActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<RecognizeCustomEntitiesActionResult> RecognizeCustomEntitiesResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="SingleLabelClassifyActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<SingleLabelClassifyActionResult> SingleLabelClassifyResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="MultiLabelClassifyActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<MultiLabelClassifyActionResult> MultiLabelClassifyResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="AnalyzeHealthcareEntitiesResult"/>.
        /// </summary>
        public IReadOnlyCollection<AnalyzeHealthcareEntitiesActionResult> AnalyzeHealthcareEntitiesResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="ExtractSummaryActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<ExtractSummaryActionResult> ExtractSummaryResults { get; }

        /// <summary>
        /// Determines the collection of <see cref="AbstractSummaryActionResult"/>.
        /// </summary>
        public IReadOnlyCollection<AbstractSummaryActionResult> AbstractSummaryResults { get; }
    }
}
