// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary>
    /// Represents the input text document to be queried.
    /// </summary>
    public partial class TextDocument
    {
        /// <summary>
        /// Initializes a new instance of TextDocument.
        /// </summary>
        /// <param name="id">Unique identifier for the text document.</param>
        /// <param name="text">Text contents of the document.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="text"/> is null.</exception>
        public TextDocument(string id, string text)
        {
            Id = Argument.CheckNotNull(id, nameof(id));
            Text = Argument.CheckNotNull(text, nameof(text));
        }

        /// <summary>
        /// Gets the unique identifier for the text document.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the text contents of the document.
        /// </summary>
        public string Text { get; }
    }
}
