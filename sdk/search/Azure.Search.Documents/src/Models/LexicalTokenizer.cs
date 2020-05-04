// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    [CodeGenModel("Tokenizer")]
    public partial class LexicalTokenizer
    {
        /// <summary> Initializes a new instance of LexicalTokenizer. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        private protected LexicalTokenizer(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
