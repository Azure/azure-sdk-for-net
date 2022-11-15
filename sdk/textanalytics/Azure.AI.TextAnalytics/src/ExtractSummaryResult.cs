// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the extractive text summarization operation on a given
    /// document, containing a collection of the <see cref="SummarySentence"/>
    /// objects extracted from that document.
    /// </summary>
    public partial class ExtractSummaryResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<SummarySentence> _sentences;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSummaryResult"/> class.
        /// </summary>
        internal ExtractSummaryResult(
            string id,
            TextDocumentStatistics statistics,
            IList<SummarySentence> sentences,
            IList<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _sentences = (sentences is not null)
                ? new ReadOnlyCollection<SummarySentence>(sentences)
                : new List<SummarySentence>();

            Warnings = (warnings is not null)
                ? new ReadOnlyCollection<TextAnalyticsWarning>(warnings)
                : new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSummaryResult"/>.
        /// </summary>
        /// <param name="id">Analyze operation id.</param>
        /// <param name="error">Operation error object.</param>
        internal ExtractSummaryResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; } = new List<TextAnalyticsWarning>();

        /// <summary>
        /// The collection of summary sentences extracted from the document.
        /// </summary>
        public IReadOnlyCollection<SummarySentence> Sentences
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
