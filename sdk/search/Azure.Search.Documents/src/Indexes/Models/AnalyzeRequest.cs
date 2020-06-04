// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class AnalyzeRequest
    {
        /// <summary> An optional list of token filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        [CodeGenMember(EmptyAsUndefined = true, Initialize = true)]
        public IList<TokenFilterName> TokenFilters { get; }

        /// <summary> An optional list of character filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        [CodeGenMember(EmptyAsUndefined = true, Initialize = true)]
        public IList<string> CharFilters { get; }
    }
}
