// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class NamedEntityCollection : Collection<NamedEntity>, ITextAnalysisResult
    {
        internal NamedEntityCollection(string id, TextDocumentStatistics statistics)
        {
            Id = id;
            Statistics = statistics;
        }

        internal NamedEntityCollection(string id, string errorMessage)
        {
            Id = id;
            ErrorMessage = errorMessage;
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
