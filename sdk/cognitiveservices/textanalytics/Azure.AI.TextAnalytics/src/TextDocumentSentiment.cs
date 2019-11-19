// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class TextDocumentSentiment: ITextAnalysisResult
    {
        internal TextDocumentSentiment(string id, TextDocumentStatistics statistics)
        {
            Id = id;
            Statistics = statistics;
        }

        internal TextDocumentSentiment(string id, string errorMessage)
        {
            Id = id;
            ErrorMessage = errorMessage;
        }

        // TODO: set DocumentSentiment.Length
        /// <summary>
        /// </summary>
        public TextSentiment DocumentSentiment { get; }

        /// <summary>
        /// </summary>
        public Collection<TextSentiment> SentenceSentiments { get; }

        /// <summary>
        /// </summary>
        /// <param name="sentiments"></param>
        public static implicit operator TextSentiment(TextDocumentSentiment sentiments) => sentiments.DocumentSentiment;

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
