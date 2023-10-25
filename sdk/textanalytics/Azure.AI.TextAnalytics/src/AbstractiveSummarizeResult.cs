// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of performing abstractive summarization on a given document.
    /// </summary>
    public partial class AbstractiveSummarizeResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<AbstractiveSummary> _summaries;

        /// <summary>
        /// Initializes a successful <see cref="AbstractiveSummarizeResult"/>.
        /// </summary>
        internal AbstractiveSummarizeResult(
            string id,
            TextDocumentStatistics statistics,
            IList<AbstractiveSummary> summaries,
            IList<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _summaries = (summaries is not null)
                ? new ReadOnlyCollection<AbstractiveSummary>(summaries)
                : new List<AbstractiveSummary>();

            Warnings = (warnings is not null)
                ? new ReadOnlyCollection<TextAnalyticsWarning>(warnings)
                : new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// Initializes an <see cref="AbstractiveSummarizeResult"/> with an error.
        /// </summary>
        internal AbstractiveSummarizeResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The warnings that resulted from processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; } = new List<TextAnalyticsWarning>();

        /// <summary>
        /// The collection of resulting summaries corresponding to the input document.
        /// </summary>
        public IReadOnlyCollection<AbstractiveSummary> Summaries
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
