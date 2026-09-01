// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.Sql;

public partial class SqlServerDatabaseReplicationLink
{
    /// <summary>
    /// This property is obsolete and will be removed in a future version.
    /// Please use <see cref="Name"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<string> LinkId
    {
        get => Name;
        set => Name = value;
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
