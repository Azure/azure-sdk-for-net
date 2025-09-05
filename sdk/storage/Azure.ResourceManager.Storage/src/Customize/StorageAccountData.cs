// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing the StorageAccount data model.
    /// The storage account.
    /// </summary>
    public partial class StorageAccountData : TrackedResourceData
    {
        /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.provisioningState")]
        public StorageProvisioningState? ProvisioningState { get => StorageProvisioningStateExtensions.ToStorageProvisioningState(StorageAccountProvisioningState.ToString()); }
    }
}
