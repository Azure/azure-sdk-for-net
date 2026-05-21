// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.DataMigration.Models
{
    public partial class MigrateSqlServerSqlMITaskInput
    {
        /// <summary> Backward-compatible constructor with backupBlobShare parameter. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MigrateSqlServerSqlMITaskInput(
            DataMigrationSqlConnectionInfo sourceConnectionInfo,
            DataMigrationSqlConnectionInfo targetConnectionInfo,
            IEnumerable<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases,
            DataMigrationBlobShare backupBlobShare)
            : this(sourceConnectionInfo, targetConnectionInfo, null, selectedDatabases?.ToList(), null, new ChangeTrackingList<string>(), new ChangeTrackingList<string>(), null, backupBlobShare, null, null, null)
        {
            Argument.AssertNotNull(sourceConnectionInfo, nameof(sourceConnectionInfo));
            Argument.AssertNotNull(targetConnectionInfo, nameof(targetConnectionInfo));
            Argument.AssertNotNull(selectedDatabases, nameof(selectedDatabases));
        }

        /// <summary> Backward-compatible 3-param public constructor. </summary>
        public MigrateSqlServerSqlMITaskInput(
            DataMigrationSqlConnectionInfo sourceConnectionInfo,
            DataMigrationSqlConnectionInfo targetConnectionInfo,
            IEnumerable<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases)
            : this(sourceConnectionInfo, targetConnectionInfo, null, selectedDatabases?.ToList(), null, new ChangeTrackingList<string>(), new ChangeTrackingList<string>(), null, null, null, null, null)
        {
            Argument.AssertNotNull(sourceConnectionInfo, nameof(sourceConnectionInfo));
            Argument.AssertNotNull(targetConnectionInfo, nameof(targetConnectionInfo));
            Argument.AssertNotNull(selectedDatabases, nameof(selectedDatabases));
        }
    }
}
