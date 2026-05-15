// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.DataMigration.Models
{
    /// <summary> Backward-compatible constructor overload for ValidateMigrationInputSqlServerSqlMITaskInput. </summary>
    public partial class ValidateMigrationInputSqlServerSqlMITaskInput
    {
        /// <summary> Backward-compatible constructor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValidateMigrationInputSqlServerSqlMITaskInput(DataMigrationSqlConnectionInfo sourceConnectionInfo, DataMigrationSqlConnectionInfo targetConnectionInfo, IEnumerable<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, DataMigrationBlobShare backupBlobShare)
            : this(sourceConnectionInfo, targetConnectionInfo, selectedDatabases?.ToList(), default, default, backupBlobShare, default, default)
        {
        }
    }
}
