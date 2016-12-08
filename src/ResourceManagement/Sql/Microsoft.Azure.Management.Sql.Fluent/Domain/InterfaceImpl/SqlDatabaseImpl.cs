// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core.IndependentChild.Definition;
    using System;
    using SqlDatabase.Definition;
    using System.Threading;
    using SqlDatabase.Update;
    using System.Collections.Generic;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    internal partial class SqlDatabaseImpl 
    {
        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabaseId">Id of the source database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreateMode SqlDatabase.Definition.IWithSourceDatabaseId.WithSourceDatabase(string sourceDatabaseId)
        {
            return this.WithSourceDatabase(sourceDatabaseId) as SqlDatabase.Definition.IWithCreateMode;
        }

        /// <summary>
        /// Sets the resource if of source database for the SQL Database.
        /// Collation, Edition, and MaxSizeBytes must remain the same while the link is
        /// active. Values specified for these parameters will be ignored.
        /// </summary>
        /// <param name="sourceDatabase">Instance of the source database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreateMode SqlDatabase.Definition.IWithSourceDatabaseId.WithSourceDatabase(ISqlDatabase sourceDatabase)
        {
            return this.WithSourceDatabase(sourceDatabase) as SqlDatabase.Definition.IWithCreateMode;
        }

        /// <summary>
        /// Sets the max size in bytes for SQL Database.
        /// </summary>
        /// <param name="maxSizeBytes">
        /// Max size of the Azure SQL Database expressed in bytes. Note: Only
        /// the following sizes are supported (in addition to limitations being
        /// placed on each edition): { 100 MB | 500 MB |1 GB | 5 GB | 10 GB | 20
        /// GB | 30 GB … 150 GB | 200 GB … 500 GB }.
        /// </param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreate SqlDatabase.Definition.IWithMaxSizeBytes.WithMaxSizeBytes(long maxSizeBytes)
        {
            return this.WithMaxSizeBytes(maxSizeBytes) as SqlDatabase.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the max size in bytes for SQL Database.
        /// </summary>
        /// <param name="maxSizeBytes">
        /// Max size of the Azure SQL Database expressed in bytes. Note: Only
        /// the following sizes are supported (in addition to limitations being
        /// placed on each edition): { 100 MB | 500 MB |1 GB | 5 GB | 10 GB | 20
        /// GB | 30 GB … 150 GB | 200 GB … 500 GB }.
        /// </param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithMaxSizeBytes.WithMaxSizeBytes(long maxSizeBytes)
        {
            return this.WithMaxSizeBytes(maxSizeBytes) as SqlDatabase.Update.IUpdate;
        }

        /// <summary>
        /// Sets the service level objective for the SQL Database.
        /// </summary>
        /// <param name="serviceLevelObjective">Service level objected for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreate SqlDatabase.Definition.IWithServiceObjective.WithServiceObjective(string serviceLevelObjective)
        {
            return this.WithServiceObjective(serviceLevelObjective) as SqlDatabase.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the service level objective for the SQL Database.
        /// </summary>
        /// <param name="serviceLevelObjective">Service level objected for the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithServiceObjective.WithServiceObjective(string serviceLevelObjective)
        {
            return this.WithServiceObjective(serviceLevelObjective) as SqlDatabase.Update.IUpdate;
        }

        /// <summary>
        /// Sets the edition for the SQL Database.
        /// </summary>
        /// <param name="edition">Edition to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreate SqlDatabase.Definition.IWithEdition.WithEdition(string edition)
        {
            return this.WithEdition(edition) as SqlDatabase.Definition.IWithCreate;
        }

        /// <summary>
        /// Sets the edition for the SQL Database.
        /// </summary>
        /// <param name="edition">Edition to be set for database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithEdition.WithEdition(string edition)
        {
            return this.WithEdition(edition) as SqlDatabase.Update.IUpdate;
        }

        /// <summary>
        /// Sets the create mode for the SQL Database.
        /// </summary>
        /// <param name="createMode">Create mode for the database, should not be default in this flow.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreateWithLessOptions SqlDatabase.Definition.IWithCreateMode.WithMode(string createMode)
        {
            return this.WithMode(createMode) as SqlDatabase.Definition.IWithCreateWithLessOptions;
        }

        /// <summary>
        /// Specifies database to be created without elastic pool.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithExistingDatabase SqlDatabase.Definition.IWithElasticPoolName.WithoutElasticPool()
        {
            return this.WithoutElasticPool() as SqlDatabase.Definition.IWithExistingDatabase;
        }

        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithExistingDatabase SqlDatabase.Definition.IWithElasticPoolName.WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool)
        {
            return this.WithNewElasticPool(sqlElasticPool) as SqlDatabase.Definition.IWithExistingDatabase;
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithExistingDatabase SqlDatabase.Definition.IWithElasticPoolName.WithExistingElasticPool(string elasticPoolName)
        {
            return this.WithExistingElasticPool(elasticPoolName) as SqlDatabase.Definition.IWithExistingDatabase;
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithExistingDatabase SqlDatabase.Definition.IWithElasticPoolName.WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            return this.WithExistingElasticPool(sqlElasticPool) as SqlDatabase.Definition.IWithExistingDatabase;
        }

        /// <summary>
        /// Removes database from it's elastic pool.
        /// </summary>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IWithEdition SqlDatabase.Update.IWithElasticPoolName.WithoutElasticPool()
        {
            return this.WithoutElasticPool() as SqlDatabase.Update.IWithEdition;
        }

        /// <summary>
        /// Sets the new elastic pool for the SQLDatabase, this will create a new elastic pool while creating database.
        /// </summary>
        /// <param name="sqlElasticPool">Creatable definition for new elastic pool to be created for the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithElasticPoolName.WithNewElasticPool(ICreatable<Microsoft.Azure.Management.Sql.Fluent.ISqlElasticPool> sqlElasticPool)
        {
            return this.WithNewElasticPool(sqlElasticPool) as SqlDatabase.Update.IUpdate;
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="elasticPoolName">For the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithElasticPoolName.WithExistingElasticPool(string elasticPoolName)
        {
            return this.WithExistingElasticPool(elasticPoolName) as SqlDatabase.Update.IUpdate;
        }

        /// <summary>
        /// Sets the existing elastic pool for the SQLDatabase.
        /// </summary>
        /// <param name="sqlElasticPool">For the SQL Database.</param>
        /// <return>The next stage of the update.</return>
        SqlDatabase.Update.IUpdate SqlDatabase.Update.IWithElasticPoolName.WithExistingElasticPool(ISqlElasticPool sqlElasticPool)
        {
            return this.WithExistingElasticPool(sqlElasticPool) as SqlDatabase.Update.IUpdate;
        }

        /// <return>
        /// The current Service Level Objective Id of the Azure SQL Database, this is the Id of the
        /// Service Level Objective that is currently active.
        /// </return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.CurrentServiceObjectiveId
        {
            get
            {
                return this.CurrentServiceObjectiveId();
            }
        }

        /// <return>The max size of the Azure SQL Database expressed in bytes.</return>
        long Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.MaxSizeBytes
        {
            get
            {
                return this.MaxSizeBytes();
            }
        }

        /// <return>The Id of the Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.DatabaseId
        {
            get
            {
                return this.DatabaseId() as string;
            }
        }

        /// <return>The Service Level Objective of the Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ServiceLevelObjective
        {
            get
            {
                return this.ServiceLevelObjective() as string;
            }
        }

        /// <return>The upgradeHint value.</return>
        Microsoft.Azure.Management.Sql.Fluent.IUpgradeHint Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.GetUpgradeHint()
        {
            return this.GetUpgradeHint() as Microsoft.Azure.Management.Sql.Fluent.IUpgradeHint;
        }

        /// <return>SqlWarehouse instance for more operations.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.CastToWarehouse()
        {
            return this.CastToWarehouse() as Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse;
        }

        /// <return>Name of the SQL Server to which this database belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.SqlServerName
        {
            get
            {
                return this.SqlServerName() as string;
            }
        }

        /// <return>
        /// The configured Service Level Objective Id of the Azure SQL
        /// Database, this is the Service Level Objective that is being applied to
        /// the Azure SQL Database.
        /// </return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.RequestedServiceObjectiveId
        {
            get
            {
                return this.RequestedServiceObjectiveId();
            }
        }

        /// <return>The edition of the Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Edition
        {
            get
            {
                return this.Edition() as string;
            }
        }

        /// <return>The collation of the Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Collation
        {
            get
            {
                return this.Collation() as string;
            }
        }

        /// <return>All the replication links associated with the database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListReplicationLinks()
        {
            return this.ListReplicationLinks() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>;
        }

        /// <return>The defaultSecondaryLocation value.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.DefaultSecondaryLocation
        {
            get
            {
                return this.DefaultSecondaryLocation() as string;
            }
        }

        /// <return>
        /// The recovery period start date of the Azure SQL Database. This
        /// records the start date and time when recovery is available for this
        /// Azure SQL Database.
        /// </return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.EarliestRestoreDate
        {
            get
            {
                return this.EarliestRestoreDate();
            }
        }

        /// <return>The elasticPoolName value.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ElasticPoolName
        {
            get
            {
                return this.ElasticPoolName() as string;
            }
        }

        /// <return>Returns the list of usages (DatabaseMetrics) of the database.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListUsages()
        {
            return this.ListUsages() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric>;
        }

        /// <return>The status of the Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Status
        {
            get
            {
                return this.Status() as string;
            }
        }

        /// <summary>
        /// Gets an Azure SQL Database Transparent Data Encryption for the database.
        /// </summary>
        /// <return>An Azure SQL Database Transparent Data Encryption for the database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.GetTransparentDataEncryption()
        {
            return this.GetTransparentDataEncryption() as Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption;
        }

        /// <summary>
        /// Deletes the existing SQL database.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Delete()
        {
 
            this.Delete();
        }

        /// <return>The creation date of the Azure SQL Database.</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <return>
        /// The name of the configured Service Level Objective of the Azure
        /// SQL Database, this is the Service Level Objective that is being
        /// applied to the Azure SQL Database.
        /// </return>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.RequestedServiceObjectiveName
        {
            get
            {
                return this.RequestedServiceObjectiveName() as string;
            }
        }

        /// <return>Information about service tier advisors for specified database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListServiceTierAdvisors()
        {
            return this.ListServiceTierAdvisors() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>;
        }

        /// <return>Returns the list of all restore points on the database.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListRestorePoints()
        {
            return this.ListRestorePoints() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint>;
        }

        /// <return>True if this Database is SqlWarehouse.</return>
        bool Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.IsDataWarehouse
        {
            get
            {
                return this.IsDataWarehouse();
            }
        }

        /// <summary>
        /// Sets the creation flow to ask relevant question when source database is not specified.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreate SqlDatabase.Definition.IWithExistingDatabase.WithoutSourceDatabaseId()
        {
            return this.WithoutSourceDatabaseId() as SqlDatabase.Definition.IWithCreate;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase;
        }

        /// <summary>
        /// Sets the collation for the SQL Database.
        /// </summary>
        /// <param name="collation">Collation to be set for database.</param>
        /// <return>The next stage of the definition.</return>
        SqlDatabase.Definition.IWithCreate SqlDatabase.Definition.IWithCollation.WithCollation(string collation)
        {
            return this.WithCollation(collation) as SqlDatabase.Definition.IWithCreate;
        }
    }
}