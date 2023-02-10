// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of BatchRequestItem. </summary>{
    internal partial class BatchRequestItem<T>
    {
        /// <summary> Initializes a new instance of BatchRequestItem. </summary>
        internal BatchRequestItem(T query)
        {
            Query = query;
        }

        /// <summary> The list of queries to process. </summary>
        internal T Query { get; }
    }
}
