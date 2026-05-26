// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.DataMigration.Models
{
    // Backward-compat justification: restore the GA-era protected constructor suppressed by the new generator for ApiCompat.
    public abstract partial class MigrateSqlServerSqlMITaskOutput
    {
        // Backward-compatible protected constructor for ApiCompat.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected MigrateSqlServerSqlMITaskOutput() : this(default(string)) { }
    }
}
