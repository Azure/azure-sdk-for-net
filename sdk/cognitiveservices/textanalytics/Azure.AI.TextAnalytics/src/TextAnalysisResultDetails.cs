// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly struct TextAnalysisResultDetails
    {
        internal TextAnalysisResultDetails(string id, TextDocumentStatistics statistics)
        {
            Id = id;
            Statistics = statistics;
            ErrorMessage = default;
        }

        internal TextAnalysisResultDetails(string id, string errorMessage)
        {
            Id = id;
            ErrorMessage = errorMessage;
            Statistics = default;
        }

        /// <summary>
        /// Gets unique, non-empty document identifier.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets (Optional) if showStatistics=true was specified in the
        /// request this field will contain information about the document
        /// payload.
        /// </summary>
        public TextDocumentStatistics Statistics { get; }

        /// <summary>
        /// Errors and Warnings by document.
        /// </summary>
        public string ErrorMessage { get; }
    }
}
