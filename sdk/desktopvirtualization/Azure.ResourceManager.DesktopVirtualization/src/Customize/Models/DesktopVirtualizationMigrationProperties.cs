// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    /// <summary> Properties for arm migration. </summary>
    [Obsolete("This struct is obsolete and will be removed in a future release", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DesktopVirtualizationMigrationProperties
    {
        /// <summary> Initializes a new instance of DesktopVirtualizationMigrationProperties. </summary>
        public DesktopVirtualizationMigrationProperties()
        {
        }

        /// <summary> Initializes a new instance of DesktopVirtualizationMigrationProperties. </summary>
        /// <param name="operation"> The type of operation for migration. </param>
        /// <param name="migrationPath"> The path to the legacy object to migrate. </param>
        internal DesktopVirtualizationMigrationProperties(MigrationOperation? operation, string migrationPath)
        {
            Operation = operation;
            MigrationPath = migrationPath;
        }

        /// <summary> The type of operation for migration. </summary>
        public MigrationOperation? Operation { get; set; }
        /// <summary> The path to the legacy object to migrate. </summary>
        public string MigrationPath { get; set; }
    }
}
