// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Search.Models
{
    /// <summary> This type represents the request body for the Batch service. </summary>
    [CodeGenModel("BatchRequestItem")]
    internal partial class BatchRequestItemInternal
    {
        internal BatchRequestItemInternal(string query)
        {
            Query = query;
        }
    }
}
