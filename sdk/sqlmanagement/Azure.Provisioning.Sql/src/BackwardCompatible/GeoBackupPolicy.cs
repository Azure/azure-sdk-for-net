// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.Sql;

public partial class GeoBackupPolicy
{
    /// <summary>
    /// The state of the geo backup policy.
    /// Please use <see cref="GeoBackupPolicyState"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<GeoBackupPolicyState> State
    {
        get => GeoBackupPolicyState;
        set => GeoBackupPolicyState = value;
    }
}
