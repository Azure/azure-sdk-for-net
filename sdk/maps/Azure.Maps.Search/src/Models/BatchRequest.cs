// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Maps.Search.Models
{
    /// <summary> Initializes a new instance of BatchRequest. </summary>
    internal partial class BatchRequest<T>
    {
        /// <summary> Initializes a new instance of BatchRequest. </summary>
        internal BatchRequest(IList<BatchRequestItem<T>> batchItems)
        {
            BatchItems = batchItems;
        }

        /// <summary> The list of queries to process. </summary>
        internal IList<BatchRequestItem<T>> BatchItems { get; }
    }
}
