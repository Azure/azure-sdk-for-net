// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class CjkBigramTokenFilter
    {
        /// <summary> The scripts to ignore. </summary>
        public IList<CjkBigramTokenFilterScripts> IgnoreScripts { get; }
    }
}
