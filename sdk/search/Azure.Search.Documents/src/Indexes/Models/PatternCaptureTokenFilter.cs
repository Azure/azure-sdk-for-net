// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class PatternCaptureTokenFilter
    {
        /// <summary> A list of patterns to match against each token. </summary>
        public IList<string> Patterns { get; }
    }
}
