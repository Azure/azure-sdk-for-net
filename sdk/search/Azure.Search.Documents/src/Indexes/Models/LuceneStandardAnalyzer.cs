// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class LuceneStandardAnalyzer
    {
        /// <summary> A list of stopwords. </summary>
        public IList<string> Stopwords { get; }
    }
}
