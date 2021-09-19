// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the classify custom category operation on a document,
    /// containing the <see cref="DocumentClassification"/> object predicted
    /// for this document.
    /// </summary>
    public class ClassifyCustomCategoryResult : TextAnalyticsResult
    {
        private readonly DocumentClassification _documentClassification;
        internal ClassifyCustomCategoryResult(string id, TextDocumentStatistics statistics, SummarySentenceCollection sentences)
            : base(id, statistics)
        {
            _sentences = sentences;
        }

        internal ClassifyCustomCategoryResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the collection of summary sentences extracted from the document.
        /// </summary>
        public DocumentClassification DocumentClassification
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _documentClassification;
            }
        }
    }
}
