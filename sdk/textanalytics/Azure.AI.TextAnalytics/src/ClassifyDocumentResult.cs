// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A representation of the result of performing custom text classification on a given document.
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
            IReadOnlyCollection<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _classifications = classifications;
            Warnings = warnings;
        }

        /// <summary>
        /// Initializes a <see cref="ClassifyDocumentResult"/> with an error.
        /// </summary>
        internal ClassifyDocumentResult(string id, TextAnalyticsError error) : base(id, error) { }

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
