// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class KeywordMarkerTokenFilter
    {
        /// <summary> A list of words to mark as keywords. </summary>
        public IList<string> Keywords { get; }
    }
}
