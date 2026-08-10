// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

namespace Azure.ResourceManager.DataMigration.Models
{
    // Backward-compat justification: restore the GA-era protected constructor suppressed by the new generator for ApiCompat.
    public abstract partial class MigrateSqlServerSqlDBSyncTaskOutput
    {
        // Backward-compatible protected constructor for ApiCompat.
        protected MigrateSqlServerSqlDBSyncTaskOutput() : this(default(string)) { }
    }
}
