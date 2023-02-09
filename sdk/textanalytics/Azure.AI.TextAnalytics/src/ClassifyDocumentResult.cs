// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of performing dynamic classification or custom text classification on a given
    /// document.
    /// </summary>
    public class ClassifyDocumentResult : TextAnalyticsResult
    {
        private readonly ClassificationCategoryCollection _classifications;

        /// <summary>
        /// Initializes a successful <see cref="ClassifyDocumentResult"/>.
        /// </summary>
        internal ClassifyDocumentResult(
            string id,
            TextDocumentStatistics statistics,
            ClassificationCategoryCollection classifications,
            DetectedLanguage? detectedLanguage,
            IReadOnlyCollection<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _classifications = classifications;
            DetectedLanguage = detectedLanguage;
            Warnings = warnings;
        }

        /// <summary>
        /// Initializes a <see cref="ClassifyDocumentResult"/> with an error.
        /// </summary>
        internal ClassifyDocumentResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// The language of the input document as detected by the service when requested to perform automatic language
        /// detection, which is possible by specifying "auto" as the language of the input document.
        /// </summary>
        public DetectedLanguage? DetectedLanguage { get; }

        /// <summary>
        /// The warnings that resulted from processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// The collection of categories that were used to classify the document.
        /// </summary>
        public ClassificationCategoryCollection ClassificationCategories
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException(
                        $"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _classifications;
            }
        }
    }
}
