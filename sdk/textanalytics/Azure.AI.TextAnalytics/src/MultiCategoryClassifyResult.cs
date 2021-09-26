// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the Multi Category Classify operation on a document,
    /// containing the collection of <see cref="ClassificationCategory"/> objects
    /// predicted for that document.
    /// </summary>
    public class MultiCategoryClassifyResult : TextAnalyticsResult
    {
        private readonly ClassificationCategoryCollection _classificationCategories;
        internal MultiCategoryClassifyResult(string id, TextDocumentStatistics statistics, ClassificationCategoryCollection classificationCategories, IReadOnlyCollection<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _classificationCategories = classificationCategories;
            Warnings = warnings;
        }

        internal MultiCategoryClassifyResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Gets the collection of <see cref="ClassificationCategory"/> objects predicted for the corresponding document.
        /// </summary>
        public ClassificationCategoryCollection ClassificationCategories
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _classificationCategories;
            }
        }
    }
}
