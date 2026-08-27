// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageTaskAssignmentProperties
{
    private BicepValue<StorageTaskAssignmentProvisioningState> _storageTaskAssignmentProvisioningState;
#pragma warning disable CS0618 // Compatibility property intentionally uses the obsolete shipped enum.
    private BicepValue<StorageProvisioningState> _legacyProvisioningState;
#pragma warning restore CS0618

    /// <summary>
    /// Represents the provisioning state of the storage task assignment.
    /// </summary>
    [CodeGenMember("ProvisioningState")]
    public BicepValue<StorageTaskAssignmentProvisioningState> StorageTaskAssignmentProvisioningState
    {
        get { Initialize(); return _storageTaskAssignmentProvisioningState; }
    }

    /// <summary>
    /// Represents the provisioning state of the storage task assignment.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsoleted and will be removed in a future version. Please use StorageTaskAssignmentProvisioningState instead.")]
#pragma warning disable CS0618 // Compatibility property intentionally uses the obsolete shipped enum.
    public BicepValue<StorageProvisioningState> ProvisioningState
#pragma warning restore CS0618
    {
        get { Initialize(); return _legacyProvisioningState; }
    }

    partial void DefineAdditionalProperties()
    {
        // Both output aliases share the response path because they preserve the shipped new and old views of the same wire property.
        _storageTaskAssignmentProvisioningState = DefineProperty<StorageTaskAssignmentProvisioningState>(nameof(StorageTaskAssignmentProvisioningState), ["provisioningState"], isOutput: true);
#pragma warning disable CS0618 // Compatibility property registration intentionally uses the obsolete shipped enum.
        _legacyProvisioningState = DefineProperty<StorageProvisioningState>(nameof(ProvisioningState), ["provisioningState"], isOutput: true);
#pragma warning restore CS0618
    }
}
