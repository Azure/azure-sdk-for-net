// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402, SA1649, CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.DataMigration.Models;

namespace Azure.ResourceManager.DataMigration
{
    /// <summary>Backward-compatible constructors for GA resource data types.</summary>
    public partial class DataMigrationProjectData
    {
        // Backward-compatible constructor for the previous TrackedResourceData shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataMigrationProjectData(AzureLocation location)
            : this()
        {
            Location = location;
        }
    }

    /// <summary>Backward-compatible constructors for GA resource data types.</summary>
    public partial class DataMigrationServiceData
    {
        // Backward-compatible constructor for the previous TrackedResourceData shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataMigrationServiceData(AzureLocation location)
            : this()
        {
            Location = location;
        }
    }

    /// <summary>Backward-compatible constructors for GA resource data types.</summary>
    public partial class SqlMigrationServiceData
    {
        // Backward-compatible constructor for the previous TrackedResourceData shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SqlMigrationServiceData(AzureLocation location)
            : this()
        {
            Location = location;
        }
    }
}

namespace Azure.ResourceManager.DataMigration.Models
{
    /// <summary>Backward-compatible constructor overloads for GA task inputs.</summary>
    public partial class MigrateSqlServerSqlMITaskInput
    {
        // Backward-compatible constructor that preserved the blob share shape.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MigrateSqlServerSqlMITaskInput(DataMigrationSqlConnectionInfo sourceConnectionInfo, DataMigrationSqlConnectionInfo targetConnectionInfo, IEnumerable<MigrateSqlServerSqlMIDatabaseInput> selectedDatabases, DataMigrationBlobShare backupBlobShare)
            : this(sourceConnectionInfo, targetConnectionInfo, null, selectedDatabases is IList<MigrateSqlServerSqlMIDatabaseInput> databaseList ? databaseList : new List<MigrateSqlServerSqlMIDatabaseInput>(selectedDatabases), null, null, null, null, backupBlobShare, null, null, null)
        {
        }
    }
}
