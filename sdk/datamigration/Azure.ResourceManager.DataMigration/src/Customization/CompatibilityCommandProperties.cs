// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402, CS1591

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    // Suppress the generated internal parameterless constructors on discriminated abstract base types
    // and replace them with protected constructors to preserve GA 1.0.0 ApiCompat compatibility.
    // The TypeSpec generator emits internal ctors by design, but the previous AutoRest-based GA SDK
    // shipped these as protected, so we must maintain that access level.
    [CodeGenSuppress("ConnectToSourceSqlServerTaskOutput")]
    public abstract partial class ConnectToSourceSqlServerTaskOutput
    {
        protected ConnectToSourceSqlServerTaskOutput()
        {
        }
    }

    [CodeGenSuppress("DatabaseMigrationBaseProperties")]
    public abstract partial class DatabaseMigrationBaseProperties
    {
        protected DatabaseMigrationBaseProperties()
        {
        }
    }

    [CodeGenSuppress("DataMigrationCommandProperties")]
    public abstract partial class DataMigrationCommandProperties
    {
        protected DataMigrationCommandProperties()
        {
        }
    }

    [CodeGenSuppress("DataMigrationProjectTaskProperties")]
    public abstract partial class DataMigrationProjectTaskProperties
    {
        protected DataMigrationProjectTaskProperties()
        {
        }
    }

    [CodeGenSuppress("MigrateMySqlAzureDBForMySqlOfflineTaskOutput")]
    public abstract partial class MigrateMySqlAzureDBForMySqlOfflineTaskOutput
    {
        protected MigrateMySqlAzureDBForMySqlOfflineTaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigrateMySqlAzureDBForMySqlSyncTaskOutput")]
    public abstract partial class MigrateMySqlAzureDBForMySqlSyncTaskOutput
    {
        protected MigrateMySqlAzureDBForMySqlSyncTaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigrateOracleAzureDBPostgreSqlSyncTaskOutput")]
    public abstract partial class MigrateOracleAzureDBPostgreSqlSyncTaskOutput
    {
        protected MigrateOracleAzureDBPostgreSqlSyncTaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput")]
    public abstract partial class MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput
    {
        protected MigratePostgreSqlAzureDBForPostgreSqlSyncTaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigrateSchemaSqlServerSqlDBTaskOutput")]
    public abstract partial class MigrateSchemaSqlServerSqlDBTaskOutput
    {
        protected MigrateSchemaSqlServerSqlDBTaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigrateSqlServerSqlDBSyncTaskOutput")]
    public abstract partial class MigrateSqlServerSqlDBSyncTaskOutput
    {
        protected MigrateSqlServerSqlDBSyncTaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigrateSqlServerSqlDBTaskOutput")]
    public abstract partial class MigrateSqlServerSqlDBTaskOutput
    {
        protected MigrateSqlServerSqlDBTaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigrateSqlServerSqlMISyncTaskOutput")]
    public abstract partial class MigrateSqlServerSqlMISyncTaskOutput
    {
        protected MigrateSqlServerSqlMISyncTaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigrateSqlServerSqlMITaskOutput")]
    public abstract partial class MigrateSqlServerSqlMITaskOutput
    {
        protected MigrateSqlServerSqlMITaskOutput()
        {
        }
    }

    [CodeGenSuppress("MigrateSsisTaskOutput")]
    public abstract partial class MigrateSsisTaskOutput
    {
        protected MigrateSsisTaskOutput()
        {
        }
    }

    [CodeGenSuppress("ServerConnectionInfo")]
    public abstract partial class ServerConnectionInfo
    {
        protected ServerConnectionInfo()
        {
        }
    }

    // Backward-compatible convenience property that existed in the GA 1.0.0 API surface.
    // The generated code exposes Output.Errors, but the old SDK flattened it as OutputErrors.
    public partial class MigrateMISyncCompleteCommandProperties
    {
        public IReadOnlyList<DataMigrationReportableException> OutputErrors => Output is null ? default : (IReadOnlyList<DataMigrationReportableException>)Output.Errors;
    }
}
