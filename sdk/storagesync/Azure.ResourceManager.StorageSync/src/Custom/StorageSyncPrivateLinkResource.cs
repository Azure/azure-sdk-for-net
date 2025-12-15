// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.StorageSync.Models
{
    /// <summary> A private link resource. </summary>
    public partial class StorageSyncPrivateLinkResource : ResourceData
    {
        /// <summary> Initializes a new instance of <see cref="StorageSyncPrivateLinkResource"/>. </summary>
        public StorageSyncPrivateLinkResource()
        {
            Properties = new StorageSyncPrivateLinkResourceProperties();
        }
    }
}
