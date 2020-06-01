// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class LexicalTokenizer
    {
        /// <summary> Initializes a new instance of LexicalTokenizer. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        private protected LexicalTokenizer(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
