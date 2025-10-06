// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Properties of the storage task assignment. </summary>
    public partial class StorageTaskAssignmentProperties
    {
        /// <summary> Represents the provisioning state of the storage task assignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("provisioningState")]
        public StorageProvisioningState? ProvisioningState { get => StorageProvisioningStateExtensions.ToStorageProvisioningState(StorageTaskAssignmentProvisioningState.ToString()); }
    }
}
