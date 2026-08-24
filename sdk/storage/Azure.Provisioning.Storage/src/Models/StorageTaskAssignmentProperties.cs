// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.Storage;

public partial class StorageTaskAssignmentProperties
{
    private BicepValue<StorageTaskAssignmentProvisioningState>? _storageTaskAssignmentProvisioningState;

    // TypeSpec no longer exposes the shared provisioning-state property on this model.
    // Keep the shipped property on its original output path for compatibility.
    /// <summary>
    /// Represents the provisioning state of the storage task assignment.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<StorageProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
    }
    private BicepValue<StorageProvisioningState>? _provisioningState;

    // TypeSpec collapses the two historical provisioning-state views to one wire field.
    // Preserve the resource-specific property alongside the shared compatibility property.
    /// <summary>
    /// Represents the resource-specific provisioning state of the storage task assignment.
    /// </summary>
    public BicepValue<StorageTaskAssignmentProvisioningState> StorageTaskAssignmentProvisioningState
    {
        get { Initialize(); return _storageTaskAssignmentProvisioningState!; }
    }

    partial void DefineAdditionalProperties()
    {
        _provisioningState = DefineProperty<StorageProvisioningState>("ProvisioningState", ["provisioningState"], isOutput: true);
        _storageTaskAssignmentProvisioningState = DefineProperty<StorageTaskAssignmentProvisioningState>(nameof(StorageTaskAssignmentProvisioningState), ["provisioningState"], isOutput: true);
    }
}
