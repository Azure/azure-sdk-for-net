// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Routing.Models
{
    /// <summary> Batch request object. </summary>
    [CodeGenModel("BatchRequestItem")]
    internal partial class BatchRequestItem
    {
        /// <summary> Initializes a new instance of BatchRequestItem. </summary>
        public BatchRequestItem()
        {
        }

        /// <summary> Initializes a new instance of BatchRequestItem. </summary>
        public BatchRequestItem(string query)
        {
            Query = query;
        }
    }
}
