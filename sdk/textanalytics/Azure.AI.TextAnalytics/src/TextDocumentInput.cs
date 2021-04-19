// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// An input representing an individual text document to
    /// be analyzed by the Text Analytics predictive model for a given operation.
    /// The document contains the document's id, the full text of the document,
    /// and the language that the document is written in.
    /// </summary>
    public class TextDocumentInput : TextAnalyticsInput
    {
        /// <summary>
        /// </summary>
        /// <param name="id">The id of the document represented by this instance.
        /// The id must be unique within the batch of documents analyzed in a
        /// given operation.</param>
        /// <param name="text">The text of the document.</param>
        public TextDocumentInput(string id, string text) : base(id, text) { }

        /// <summary>
        /// Gets or sets the language the input document is written in.  This
        /// value is the two letter ISO 639-1 representation of the language
        /// (for example, "en" for English or "es" for Spanish).
        /// </summary>
        public string Language { get; set; }
    }
}
