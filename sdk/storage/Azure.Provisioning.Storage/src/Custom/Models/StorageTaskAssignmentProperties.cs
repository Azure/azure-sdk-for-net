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
#pragma warning disable CS0618 // Compatibility property intentionally uses the obsolete shipped enum.
    public BicepValue<StorageProvisioningState> ProvisioningState
#pragma warning restore CS0618
    {
        get { Initialize(); return _provisioningState!; }
    }
#pragma warning disable CS0618 // Compatibility field intentionally uses the obsolete shipped enum.
    private BicepValue<StorageProvisioningState>? _provisioningState;
#pragma warning restore CS0618

    // Preserve the shipped ProvisioningState property on its original output-only wire path.
    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618 // Compatibility property registration intentionally uses the obsolete shipped enum.
        _provisioningState = DefineProperty<StorageProvisioningState>("ProvisioningState", ["provisioningState"], isOutput: true);
#pragma warning restore CS0618
    }
}
