// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.DataMigration.Models
{
    // Backward-compat justification: restore GA-era constructor overloads that accepted backupBlobShare and 3-param signatures.
    public partial class ValidateMigrationInputSqlServerSqlMITaskInput
    {
        // Backward-compatible constructor with backupBlobShare parameter.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValidateMigrationInputSqlServerSqlMITaskInput(
            DataMigrationSqlConnectionInfo sourceConnectionInfo,
            DataMigrationSqlConnectionInfo targetConnectionInfo,
            IEnumerable<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases,
            DataMigrationBlobShare backupBlobShare)
            : this(sourceConnectionInfo, targetConnectionInfo, selectedDatabases?.ToList(), new ChangeTrackingList<string>(), null, backupBlobShare, null, null)
        {
            Argument.AssertNotNull(sourceConnectionInfo, nameof(sourceConnectionInfo));
            Argument.AssertNotNull(targetConnectionInfo, nameof(targetConnectionInfo));
            Argument.AssertNotNull(selectedDatabases, nameof(selectedDatabases));
        }

        // Backward-compatible 3-param public constructor.
        public ValidateMigrationInputSqlServerSqlMITaskInput(
            DataMigrationSqlConnectionInfo sourceConnectionInfo,
            DataMigrationSqlConnectionInfo targetConnectionInfo,
            IEnumerable<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases)
            : this(sourceConnectionInfo, targetConnectionInfo, selectedDatabases?.ToList(), new ChangeTrackingList<string>(), null, null, null, null)
        {
            Argument.AssertNotNull(sourceConnectionInfo, nameof(sourceConnectionInfo));
            Argument.AssertNotNull(targetConnectionInfo, nameof(targetConnectionInfo));
            Argument.AssertNotNull(selectedDatabases, nameof(selectedDatabases));
        }
    }
}
