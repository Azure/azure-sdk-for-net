// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds hidden PolicySchema alias for renamed Policy property.
// Could use @@clientName in spec but would lose the improved name.

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class BlobInventoryPolicyData
    {
        /// <summary> Backward-compatible alias for Policy. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.policy")]
        public BlobInventoryPolicySchema PolicySchema
        {
            get => Policy;
            set => Policy = value;
        }
    }
}
