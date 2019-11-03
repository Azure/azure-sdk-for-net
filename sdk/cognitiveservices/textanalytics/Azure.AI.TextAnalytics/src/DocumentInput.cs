// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DocumentInput
    {
        /// <summary>
        /// Gets or sets unique, non-empty document identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Country Hint or known Language of the document
        /// Gets or sets this is the 2 letter ISO 639-1 representation of a
        /// language. For example, use "en" for English; "es" for Spanish etc.
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// </summary>
        public string Text { get; set; }
    }
}