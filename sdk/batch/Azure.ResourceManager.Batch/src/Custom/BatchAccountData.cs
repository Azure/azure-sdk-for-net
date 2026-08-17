// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Batch
{
    // The TypeSpec resource shape generates TrackedResourceData, but the shipped type derives from ResourceData.
    public partial class BatchAccountData : ResourceData
    {
        // Keep the GA property type while the generated model uses a mutable dictionary internally.
        /// <summary> Resource tags. </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }
    }
}
