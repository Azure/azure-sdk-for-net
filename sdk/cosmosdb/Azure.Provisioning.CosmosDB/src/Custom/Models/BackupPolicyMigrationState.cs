// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.CosmosDB;

public partial class BackupPolicyMigrationState
{
    // CUSTOMIZATION: The updated generator names this property StartsOn, while the released API
    // exposed StartOn. Preserve the released property as a temporary compatibility alias.
    /// <summary> Gets or sets the time when the backup policy migration started. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Use StartsOn instead.")]
    public BicepValue<DateTimeOffset> StartOn
    {
        get => StartsOn;
        set => StartsOn = value;
    }
}
