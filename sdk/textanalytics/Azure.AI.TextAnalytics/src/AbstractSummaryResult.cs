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
    public partial class AbstractSummaryResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<AbstractiveSummary> _summaries;

        /// <summary>
        /// Initializes a successful <see cref="AbstractSummaryResult"/>.
        /// </summary>
        internal AbstractSummaryResult(
            string id,
            TextDocumentStatistics statistics,
            IList<AbstractiveSummary> summaries,
            DetectedLanguage? detectedLanguage,
            IList<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _summaries = (summaries is not null)
                ? new ReadOnlyCollection<AbstractiveSummary>(summaries)
                : new List<AbstractiveSummary>();

            DetectedLanguage = detectedLanguage;

            Warnings = (warnings is not null)
                ? new ReadOnlyCollection<TextAnalyticsWarning>(warnings)
                : new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// Initializes an <see cref="AbstractSummaryResult"/> with an error.
        /// </summary>
        internal AbstractSummaryResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The warnings that resulted from processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; } = new List<TextAnalyticsWarning>();

        /// <summary>
        /// The language of the input document as detected by the service when requested to perform automatic language
        /// detection, which is possible by specifying "auto" as the language of the input document.
        /// </summary>
        public DetectedLanguage? DetectedLanguage { get; }

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
