// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.Storage;

public partial class StorageTaskAssignmentProperties
{
    /// <summary>
    /// Represents the provisioning state of the storage task assignment.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<StorageProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
    }
    private BicepValue<StorageProvisioningState>? _provisioningState;
}
