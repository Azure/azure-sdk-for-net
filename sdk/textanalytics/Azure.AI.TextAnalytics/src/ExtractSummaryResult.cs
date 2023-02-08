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
    public partial class ExtractSummaryResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<SummarySentence> _sentences;

        /// <summary>
        /// Initializes a successful <see cref="ExtractSummaryResult"/>.
        /// </summary>
        internal ExtractSummaryResult(
            string id,
            TextDocumentStatistics statistics,
            IList<SummarySentence> sentences,
            DetectedLanguage? detectedLanguage,
            IList<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _sentences = (sentences is not null)
                ? new ReadOnlyCollection<SummarySentence>(sentences)
                : new List<SummarySentence>();

            DetectedLanguage = detectedLanguage;

            Warnings = (warnings is not null)
                ? new ReadOnlyCollection<TextAnalyticsWarning>(warnings)
                : new List<TextAnalyticsWarning>();
        }

        /// <summary>
        /// Initializes an <see cref="ExtractSummaryResult"/> with an error.
        /// </summary>
        internal ExtractSummaryResult(string id, TextAnalyticsError error) : base(id, error) { }

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
        /// The collection of summary sentences extracted from the input document.
        /// </summary>
        public IReadOnlyCollection<SummarySentence> Sentences
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
