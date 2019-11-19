// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public interface ITextAnalysisResult
    {
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
