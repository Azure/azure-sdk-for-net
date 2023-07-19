// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the analyze sentiment operation on a single document,
    /// containing the predicted sentiment for each sentence as well as for
    /// the full document.
    /// </summary>
    public class AnalyzeSentimentResult : TextAnalyticsResult
    {
        private readonly DocumentSentiment _documentSentiment;

        internal AnalyzeSentimentResult(
            string id,
            TextDocumentStatistics statistics,
            DocumentSentiment documentSentiment)
            : base(id, statistics)
        {
            _documentSentiment = documentSentiment;
        }

        internal AnalyzeSentimentResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the predicted sentiment for the full document.
        /// </summary>
        public DocumentSentiment DocumentSentiment
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _documentSentiment;
            }
        }
    }
}
