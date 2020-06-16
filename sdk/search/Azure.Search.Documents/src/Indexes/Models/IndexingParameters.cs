// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class IndexingParameters
    {
        /// <summary> A dictionary of indexer-specific configuration properties. Each name is the name of a specific property. Each value must be of a primitive type. </summary>
        [CodeGenMember(EmptyAsUndefined = true, Initialize = true)]
        public IDictionary<string, object> Configuration { get; }
    }
}
