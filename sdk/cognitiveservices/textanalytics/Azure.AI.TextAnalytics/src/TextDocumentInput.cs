﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class TextDocumentInput
    {
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        public TextDocumentInput(string id, string text)
        {
            Id = id;
            Text = text;
        }

        /// <summary>
        /// Gets unique, non-empty document identifier.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Language of the document.
        /// Gets or sets this is the 2 letter ISO 639-1 representation of a
        /// language. For example, use "en" for English; "es" for Spanish etc.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// </summary>
        public string Text { get; }
    }
}