// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.DataMigration.Models
{
    public abstract partial class MigrateSqlServerSqlMITaskOutput
    {
        /// <summary> Backward-compatible protected constructor for ApiCompat. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected MigrateSqlServerSqlMITaskOutput() : this(default(string)) { }
    }
}
