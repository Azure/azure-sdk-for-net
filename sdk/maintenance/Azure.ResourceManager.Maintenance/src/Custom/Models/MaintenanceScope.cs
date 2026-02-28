// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance.Models
{
    // Rename enum members to maintain backward compatibility
    public readonly partial struct MaintenanceScope
    {
        /// <summary> This maintenance scope controls installation of SQL server platform updates. </summary>
        [CodeGenMember("SQLDB")]
        public static MaintenanceScope SqlDB { get; } = new MaintenanceScope(SQLDBValue);

        /// <summary> This maintenance scope controls installation of SQL managed instance platform update. </summary>
        [CodeGenMember("SQLManagedInstance")]
        public static MaintenanceScope SqlManagedInstance { get; } = new MaintenanceScope(SQLManagedInstanceValue);
    }
}
