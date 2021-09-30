// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering
{
    [CodeGenModel("TextRecord")]
    public partial class TextRecord
    {
        /// <summary>
        /// Initializes a new instance of TextRecord.
        /// </summary>
        /// <param name="id">Unique identifier for the text record.</param>
        /// <param name="text">Text contents of the record.</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> or <paramref name="text"/> is null.</exception>
        public TextRecord(string id, string text)
        {
            Id = Argument.CheckNotNull(id, nameof(id));
            Text = Argument.CheckNotNull(text, nameof(text));
        }

        /// <summary>
        /// Gets the unique identifier for the text record.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the text contents of the record.
        /// </summary>
        public string Text { get; }
    }
}
