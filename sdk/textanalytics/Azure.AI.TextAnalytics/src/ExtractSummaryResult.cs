// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the extractive text summarization operation on a document,
    /// containing a collection of the <see cref="SummarySentence"/> objects
    /// identified in that document.
    /// </summary>
    public class ExtractSummaryResult : TextAnalyticsResult
    {
        private readonly SummarySentenceCollection _sentences;

        internal ExtractSummaryResult(string id, TextDocumentStatistics statistics, SummarySentenceCollection sentences)
            : base(id, statistics)
        {
            _sentences = sentences;
        }

        internal ExtractSummaryResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the collection of summary sentences extracted from the document.
        /// </summary>
        public SummarySentenceCollection Sentences
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _sentences;
            }
        }
    }
}
