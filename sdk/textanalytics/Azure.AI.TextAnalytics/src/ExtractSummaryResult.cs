// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the extractive text summarization operation on a given
    /// document, containing a collection of the <see cref="SummarySentence"/>
    /// objects extracted from that document.
    /// </summary>
    public partial class ExtractSummaryResult : TextAnalyticsResult
    {
        private readonly SummarySentenceCollection _sentences;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSummaryResult"/> class.
        /// </summary>
        internal ExtractSummaryResult(string id, TextDocumentStatistics statistics, SummarySentenceCollection sentences)
            : base(id, statistics)
        {
            _sentences = sentences;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSummaryResult"/>.
        /// </summary>
        /// <param name="id">Analyze operation id.</param>
        /// <param name="error">Operation error object.</param>
        internal ExtractSummaryResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The collection of summary sentences extracted from the document.
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
