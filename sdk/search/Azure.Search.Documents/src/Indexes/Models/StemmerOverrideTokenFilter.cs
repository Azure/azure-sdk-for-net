// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class StemmerOverrideTokenFilter
    {
        /// <summary> A list of stemming rules in the following format: &quot;word =&gt; stem&quot;, for example: &quot;ran =&gt; run&quot;. </summary>
        public IList<string> Rules { get; }
    }
}
