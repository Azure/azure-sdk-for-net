// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class StopwordsTokenFilter
    {
        /// <summary> The list of stopwords. This property and the stopwords list property cannot both be set. </summary>
        public IList<string> Stopwords { get; }
    }
}
