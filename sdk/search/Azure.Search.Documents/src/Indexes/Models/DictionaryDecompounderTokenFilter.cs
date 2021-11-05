// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class DictionaryDecompounderTokenFilter
    {
        /// <summary> The list of words to match against. </summary>
        public IList<string> WordList { get; }
    }
}
