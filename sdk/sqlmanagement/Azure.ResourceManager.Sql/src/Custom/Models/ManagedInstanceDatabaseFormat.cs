// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public readonly partial struct ManagedInstanceDatabaseFormat
    {
        /// <summary> SQLServer2022. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static ManagedInstanceDatabaseFormat SqlServer2022 => SQLServer2022;

        /// <summary> SQLServer2025. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public static ManagedInstanceDatabaseFormat SqlServer2025 => SQLServer2025;
    }
}
