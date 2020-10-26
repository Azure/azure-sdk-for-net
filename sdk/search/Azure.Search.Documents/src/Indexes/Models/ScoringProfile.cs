// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class ScoringProfile
    {
        /// <summary> The collection of functions that influence the scoring of documents. </summary>
        public IList<ScoringFunction> Functions { get; }
    }
}
