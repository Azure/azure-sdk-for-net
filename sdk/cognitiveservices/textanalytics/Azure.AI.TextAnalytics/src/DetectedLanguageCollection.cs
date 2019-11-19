// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DetectedLanguageCollection : Collection<DetectedLanguage>, ITextAnalysisResult
    {
        internal DetectedLanguageCollection(string id, TextDocumentStatistics statistics)
        {
            Id = id;
            Statistics = statistics;
        }

        internal DetectedLanguageCollection(string id, string errorMessage)
        {
            Id = id;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// </summary>
        /// <param name="languages"></param>
        public static implicit operator DetectedLanguage(DetectedLanguageCollection languages) => languages.OrderBy(l => l.Score).First();

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
