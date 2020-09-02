// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class StopAnalyzer
    {
        /// <summary> A list of stopwords. </summary>
        public IList<string> Stopwords { get; }
    }
}
