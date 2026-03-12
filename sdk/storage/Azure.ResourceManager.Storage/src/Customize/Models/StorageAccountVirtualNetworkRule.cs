// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountVirtualNetworkRule
    {
        /// <summary> Backward-compatible constructor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageAccountVirtualNetworkRule(ResourceIdentifier virtualNetworkResourceId) : this(virtualNetworkResourceId, default, default, default)
        {
        }
    }
}
