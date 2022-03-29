// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the Single Category Classification operation on a document,
    /// containing the <see cref="ClassificationCategory"/> object predicted
    /// for that document.
    /// </summary>
    public class SingleCategoryClassifyResult : TextAnalyticsResult
    {
        private readonly ClassificationCategory _classification;
        internal SingleCategoryClassifyResult(string id, TextDocumentStatistics statistics, ClassificationCategory classificationCategory , IReadOnlyCollection<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _classification = classificationCategory;
            Warnings = warnings;
        }

        internal SingleCategoryClassifyResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Gets the <see cref="ClassificationCategory"/> object predicted for the corresponding document.
        /// </summary>
        public ClassificationCategory Classification
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _classification;
            }
        }
    }
}
