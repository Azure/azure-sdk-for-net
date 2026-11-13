// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.Sql;

public partial class SqlServerDatabaseRestorePoint
{
    // Restore points are read-only, but this constructor preserves the API shipped in the
    // previous stable version.
    /// <summary> Creates a new SqlServerDatabaseRestorePoint. </summary>
    /// <param name="bicepIdentifier"> The bicep identifier name. </param>
    /// <param name="resourceVersion"> The resource API version. </param>
    public SqlServerDatabaseRestorePoint(string bicepIdentifier, string resourceVersion = null)
        : base(bicepIdentifier, "Microsoft.Sql/servers/databases/restorePoints", resourceVersion ?? "2025-01-01")
    {
    }

    // Preserve API versions shipped by the reflection-based generator that are not emitted
    // by the TypeSpec-based generator when targeting only the current stable API version.
    public static partial class ResourceVersions
    {
        /// <summary> API version "2014-01-01". </summary>
        public static readonly string V2014_01_01 = "2014-01-01";
        /// <summary> API version "2014-04-01". </summary>
        public static readonly string V2014_04_01 = "2014-04-01";
        /// <summary> API version "2015-01-01". </summary>
        public static readonly string V2015_01_01 = "2015-01-01";
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";
        /// <summary> API version "2023-08-01". </summary>
        public static readonly string V2023_08_01 = "2023-08-01";
    }
}
