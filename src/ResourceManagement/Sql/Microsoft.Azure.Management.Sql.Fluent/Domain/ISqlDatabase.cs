// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;
    using SqlDatabase.Update;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Database.
    /// </summary>
    public interface ISqlDatabase  :
        IIndependentChildResource,
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase>,
        IUpdatable<SqlDatabase.Update.IUpdate>,
        IWrapper<Models.DatabaseInner>
    {
        /// <return>All the replication links associated with the database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> ListReplicationLinks();

        /// <return>The elasticPoolName value.</return>
        string ElasticPoolName { get; }

        /// <return>Returns the list of usages (DatabaseMetrics) of the database.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> ListUsages();

        /// <return>Name of the SQL Server to which this database belongs.</return>
        string SqlServerName { get; }

        /// <summary>
        /// Gets an Azure SQL Database Transparent Data Encryption for the database.
        /// </summary>
        /// <return>An Azure SQL Database Transparent Data Encryption for the database.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption GetTransparentDataEncryption();

        /// <return>The edition of the Azure SQL Database.</return>
        string Edition { get; }

        /// <return>SqlWarehouse instance for more operations.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse CastToWarehouse();

        /// <return>Returns the list of all restore points on the database.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> ListRestorePoints();

        /// <return>The creation date of the Azure SQL Database.</return>
        System.DateTime CreationDate { get; }

        /// <summary>
        /// Deletes the existing SQL database.
        /// </summary>
        void Delete();

        /// <return>
        /// The current Service Level Objective Id of the Azure SQL Database, this is the Id of the
        /// Service Level Objective that is currently active.
        /// </return>
        System.Guid CurrentServiceObjectiveId { get; }

        /// <return>The upgradeHint value.</return>
        Microsoft.Azure.Management.Sql.Fluent.IUpgradeHint GetUpgradeHint();

        /// <return>The Service Level Objective of the Azure SQL Database.</return>
        string ServiceLevelObjective { get; }

        /// <return>The max size of the Azure SQL Database expressed in bytes.</return>
        long MaxSizeBytes { get; }

        /// <return>The defaultSecondaryLocation value.</return>
        string DefaultSecondaryLocation { get; }

        /// <return>The collation of the Azure SQL Database.</return>
        string Collation { get; }

        /// <return>The Id of the Azure SQL Database.</return>
        string DatabaseId { get; }

        /// <return>True if this Database is SqlWarehouse.</return>
        bool IsDataWarehouse { get; }

        /// <return>
        /// The recovery period start date of the Azure SQL Database. This
        /// records the start date and time when recovery is available for this
        /// Azure SQL Database.
        /// </return>
        System.DateTime EarliestRestoreDate { get; }

        /// <return>
        /// The name of the configured Service Level Objective of the Azure
        /// SQL Database, this is the Service Level Objective that is being
        /// applied to the Azure SQL Database.
        /// </return>
        string RequestedServiceObjectiveName { get; }

        /// <return>
        /// The configured Service Level Objective Id of the Azure SQL
        /// Database, this is the Service Level Objective that is being applied to
        /// the Azure SQL Database.
        /// </return>
        System.Guid RequestedServiceObjectiveId { get; }

        /// <return>The status of the Azure SQL Database.</return>
        string Status { get; }

        /// <return>Information about service tier advisors for specified database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> ListServiceTierAdvisors();
    }
}