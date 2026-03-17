// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class CommonGramTokenFilter
    {
        /// <summary> The set of common words. </summary>
        public IList<string> CommonWords { get; }
    }
}
