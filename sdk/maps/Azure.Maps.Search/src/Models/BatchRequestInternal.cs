// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using System.Linq;

namespace Azure.Maps.Search.Models
{
    /// <summary> This type represents the request body for the Batch service. </summary>
    [CodeGenModel("BatchRequest")]
    internal partial class BatchRequestInternal
    {
        internal BatchRequestInternal(IEnumerable<BatchRequestItemInternal> batchItems)
        {
            BatchItems = batchItems.ToList();
        }
    }
}
