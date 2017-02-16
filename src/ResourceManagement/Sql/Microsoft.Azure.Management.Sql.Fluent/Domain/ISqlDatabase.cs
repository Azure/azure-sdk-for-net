// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using SqlDatabase.Update;
    using Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Database.
    /// </summary>
    public interface ISqlDatabase  :
        IIndependentChildResource<ISqlManager>,
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        IUpdatable<SqlDatabase.Update.IUpdate>,
        IHasInner<Models.DatabaseInner>
    {
        /// <return>All the replication links associated with the database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> ListReplicationLinks();

        /// <summary>
        /// Gets the elasticPoolName value.
        /// </summary>
        string ElasticPoolName { get; }

        /// <return>Returns the list of usages (DatabaseMetrics) of the database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> ListUsages();

        /// <summary>
        /// Gets name of the SQL Server to which this database belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets an Azure SQL Database Transparent Data Encryption for the database.
        /// </summary>
        /// <return>An Azure SQL Database Transparent Data Encryption for the database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption GetTransparentDataEncryption();

        /// <summary>
        /// Gets the edition of the Azure SQL Database.
        /// </summary>
        string Edition { get; }

        /// <return>SqlWarehouse instance for more operations.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse AsWarehouse();

        /// <return>Returns the list of all restore points on the database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> ListRestorePoints();

        /// <summary>
        /// Gets the creation date of the Azure SQL Database.
        /// </summary>
        System.DateTime CreationDate { get; }

        /// <summary>
        /// Deletes the existing SQL database.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets the current Service Level Objective Id of the Azure SQL Database, this is the Id of the
        /// Service Level Objective that is currently active.
        /// </summary>
        System.Guid CurrentServiceObjectiveId { get; }

        /// <return>The upgradeHint value.</return>
        Microsoft.Azure.Management.Sql.Fluent.IUpgradeHint GetUpgradeHint();

        /// <summary>
        /// Gets the Service Level Objective of the Azure SQL Database.
        /// </summary>
        string ServiceLevelObjective { get; }

        /// <summary>
        /// Gets the max size of the Azure SQL Database expressed in bytes.
        /// </summary>
        long MaxSizeBytes { get; }

        /// <summary>
        /// Gets the defaultSecondaryLocation value.
        /// </summary>
        string DefaultSecondaryLocation { get; }

        /// <summary>
        /// Gets the collation of the Azure SQL Database.
        /// </summary>
        string Collation { get; }

        /// <summary>
        /// Gets the Id of the Azure SQL Database.
        /// </summary>
        string DatabaseId { get; }

        /// <summary>
        /// Gets true if this Database is SqlWarehouse.
        /// </summary>
        bool IsDataWarehouse { get; }

        /// <summary>
        /// Gets the recovery period start date of the Azure SQL Database. This
        /// records the start date and time when recovery is available for this
        /// Azure SQL Database.
        /// </summary>
        System.DateTime EarliestRestoreDate { get; }

        /// <summary>
        /// Gets the name of the configured Service Level Objective of the Azure
        /// SQL Database, this is the Service Level Objective that is being
        /// applied to the Azure SQL Database.
        /// </summary>
        string RequestedServiceObjectiveName { get; }

        /// <summary>
        /// Gets the configured Service Level Objective Id of the Azure SQL
        /// Database, this is the Service Level Objective that is being applied to
        /// the Azure SQL Database.
        /// </summary>
        System.Guid RequestedServiceObjectiveId { get; }

        /// <summary>
        /// Gets the status of the Azure SQL Database.
        /// </summary>
        string Status { get; }

        /// <return>Information about service tier advisors for specified database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> ListServiceTierAdvisors();
    }
}