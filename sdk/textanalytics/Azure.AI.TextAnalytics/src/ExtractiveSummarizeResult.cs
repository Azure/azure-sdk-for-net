// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of performing extractive summarization on a given document.
    /// </summary>
    public partial class ExtractiveSummarizeResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<ExtractiveSummarySentence> _sentences;

        /// <summary>
        /// Initializes a successful <see cref="ExtractiveSummarizeResult"/>.
        /// </summary>
        internal ExtractiveSummarizeResult(
            string id,
            TextDocumentStatistics statistics,
            IList<ExtractiveSummarySentence> sentences,
            IList<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _sentences = (sentences is not null)
                ? new ReadOnlyCollection<ExtractiveSummarySentence>(sentences)
                : new List<ExtractiveSummarySentence>();

            Warnings = (warnings is not null)
                ? new ReadOnlyCollection<TextAnalyticsWarning>(warnings)
                : new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// Initializes an <see cref="ExtractiveSummarizeResult"/> with an error.
        /// </summary>
        internal ExtractiveSummarizeResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The warnings that resulted from processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; } = new List<TextAnalyticsWarning>();

        /// <summary>
        /// The collection of summary sentences extracted from the input document.
        /// </summary>
        public IReadOnlyCollection<ExtractiveSummarySentence> Sentences
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException(
                        $"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _sentences;
            }
        }
    }
}
