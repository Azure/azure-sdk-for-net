// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class KeepTokenFilter
    {
        /// <summary> The list of words to keep. </summary>
        public IList<string> KeepWords { get; }
    }
}
