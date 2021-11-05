// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class NGramTokenizer
    {
        /// <summary> Character classes to keep in the tokens. </summary>
        public IList<TokenCharacterKind> TokenChars { get; }
    }
}
