// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.SqlDatabase.Update;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Database.
    /// </summary>
    public interface ISqlDatabase  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IIndependentChildResource<Microsoft.Azure.Management.Sql.Fluent.ISqlManager,Models.DatabaseInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<SqlDatabase.Update.IUpdate>
    {
        /// <summary>
        /// Gets the elasticPoolName value.
        /// </summary>
        string ElasticPoolName { get; }

        /// <summary>
        /// Gets the edition of the Azure SQL Database.
        /// </summary>
        string Edition { get; }

        /// <return>Returns the list of all restore points on the database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> ListRestorePoints();

        /// <return>Returns the list of usages (DatabaseMetrics) of the database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> ListUsages();

        /// <summary>
        /// Gets the recovery period start date of the Azure SQL Database. This
        /// records the start date and time when recovery is available for this
        /// Azure SQL Database.
        /// </summary>
        System.DateTime EarliestRestoreDate { get; }

        /// <summary>
        /// Gets the max size of the Azure SQL Database expressed in bytes.
        /// </summary>
        long MaxSizeBytes { get; }

        /// <summary>
        /// Gets the status of the Azure SQL Database.
        /// </summary>
        string Status { get; }

        /// <summary>
        /// Gets true if this Database is SqlWarehouse.
        /// </summary>
        bool IsDataWarehouse { get; }

        /// <summary>
        /// Gets an Azure SQL Database Transparent Data Encryption for the database.
        /// </summary>
        /// <return>An Azure SQL Database Transparent Data Encryption for the database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption GetTransparentDataEncryption();

        /// <return>Information about service tier advisors for specified database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> ListServiceTierAdvisors();

        /// <return>All the replication links associated with the database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> ListReplicationLinks();

        /// <return>The upgradeHint value.</return>
        Microsoft.Azure.Management.Sql.Fluent.IUpgradeHintInterface GetUpgradeHint();

        /// <summary>
        /// Gets the collation of the Azure SQL Database.
        /// </summary>
        string Collation { get; }

        /// <summary>
        /// Gets the defaultSecondaryLocation value.
        /// </summary>
        string DefaultSecondaryLocation { get; }

        /// <summary>
        /// Gets the creation date of the Azure SQL Database.
        /// </summary>
        System.DateTime CreationDate { get; }

        /// <summary>
        /// Gets the Id of the Azure SQL Database.
        /// </summary>
        string DatabaseId { get; }

        /// <summary>
        /// Gets the name of the configured Service Level Objective of the Azure
        /// SQL Database, this is the Service Level Objective that is being
        /// applied to the Azure SQL Database.
        /// </summary>
        string RequestedServiceObjectiveName { get; }

        /// <return>SqlWarehouse instance for more operations.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse AsWarehouse();

        /// <summary>
        /// Gets the Service Level Objective of the Azure SQL Database.
        /// </summary>
        string ServiceLevelObjective { get; }

        /// <summary>
        /// Deletes the existing SQL database.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the current Service Level Objective Id of the Azure SQL Database, this is the Id of the
        /// Service Level Objective that is currently active.
        /// </summary>
        System.Guid CurrentServiceObjectiveId { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this database belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the configured Service Level Objective Id of the Azure SQL
        /// Database, this is the Service Level Objective that is being applied to
        /// the Azure SQL Database.
        /// </summary>
        System.Guid RequestedServiceObjectiveId { get; }
    }
}