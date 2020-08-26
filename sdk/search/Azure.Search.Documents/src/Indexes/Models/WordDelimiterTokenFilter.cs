// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class WordDelimiterTokenFilter
    {
        /// <summary> A list of tokens to protect from being delimited. </summary>
        public IList<string> ProtectedWords { get; }
    }
}
