// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the classify custom categories operation on a document,
    /// containing the collection of <see cref="DocumentClassification"/> objects
    /// predicted for that document.
    /// </summary>
    public class ClassifyCustomCategoriesResult : TextAnalyticsResult
    {
        private readonly DocumentClassificationCollection _documentClassifications;
        internal ClassifyCustomCategoriesResult(string id, TextDocumentStatistics statistics, DocumentClassificationCollection documentClassifications, IReadOnlyCollection<TextAnalyticsWarning> warnings)
            : base(id, statistics)
        {
            _documentClassifications = documentClassifications;
            Warnings = warnings;
        }

        internal ClassifyCustomCategoriesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Gets the collection of <see cref="DocumentClassification"/> objects predicted for the corresponding document.
        /// </summary>
        public DocumentClassificationCollection DocumentClassifications
        {
            get
            {
                if (HasError)
                {
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
                }
                return _documentClassifications;
            }
        }
    }
}
