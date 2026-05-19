// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.DataMigration.Models
{
    // Backward-compatible constructor overload for ValidateMigrationInputSqlServerSqlMITaskInput.
    public partial class ValidateMigrationInputSqlServerSqlMITaskInput
    {
        // Backward-compatible constructor.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValidateMigrationInputSqlServerSqlMITaskInput(DataMigrationSqlConnectionInfo sourceConnectionInfo, DataMigrationSqlConnectionInfo targetConnectionInfo, IEnumerable<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, DataMigrationBlobShare backupBlobShare)
            : this(sourceConnectionInfo, targetConnectionInfo, selectedDatabases?.ToList(), default, default, backupBlobShare, default, default)
        {
        }
    }
}
