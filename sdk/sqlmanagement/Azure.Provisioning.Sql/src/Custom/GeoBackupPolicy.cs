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

    // Preserve API versions shipped by the reflection-based generator that are not emitted
    // by the TypeSpec-based generator when targeting only the current stable API version.
    public static partial class ResourceVersions
    {
        /// <summary> API version "2014-01-01". </summary>
        public static readonly string V2014_01_01 = "2014-01-01";
        /// <summary> API version "2014-04-01". </summary>
        public static readonly string V2014_04_01 = "2014-04-01";
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";
        /// <summary> API version "2023-08-01". </summary>
        public static readonly string V2023_08_01 = "2023-08-01";
    }
}
