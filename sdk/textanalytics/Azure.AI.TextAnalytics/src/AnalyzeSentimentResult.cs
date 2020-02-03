// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the analyze sentiment operation on a single document,
    /// containing the predicted sentiment for each sentence as well as for
    /// the full document.
    /// </summary>
    public class AnalyzeSentimentResult : TextAnalyticsResult
    {
        internal AnalyzeSentimentResult(string id, TextDocumentStatistics statistics, DocumentSentiment documentSentiment)
            : base(id, statistics)
        {
            DocumentSentiment = documentSentiment;
        }

        internal AnalyzeSentimentResult(string id, string errorMessage) : base(id, errorMessage) { }

        /// <summary>
        /// Gets the predicted sentiment for the full document.
        /// </summary>
        public DocumentSentiment DocumentSentiment { get; }
    }
}
