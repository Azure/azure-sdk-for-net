// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of performing abstractive summarization on a given document.
    /// </summary>
    public partial class AbstractSummaryResult : TextAnalyticsResult
    {
        private readonly SummaryCollection _summaries;

        /// <summary>
        /// Initializes a successful <see cref="AbstractSummaryResult"/>.
        /// </summary>
        internal AbstractSummaryResult(string id, TextDocumentStatistics statistics, SummaryCollection summaries)
            : base(id, statistics)
        {
            _summaries = summaries;
        }

        /// <summary>
        /// Initializes an <see cref="AbstractSummaryResult"/> with an error.
        /// </summary>
        internal AbstractSummaryResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The collection of resulting summaries for the given document.
        /// </summary>
        public SummaryCollection Summaries
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException(
                        $"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _summaries;
            }
        }
    }
}
