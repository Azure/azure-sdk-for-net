// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Rest;
    using System.Collections.Generic;
    using System;

    internal partial class SqlWarehouseImpl 
    {
        /// <summary>
        /// Resume an Azure SQL Data Warehouse database.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse.ResumeDataWarehouse()
        {
 
            this.ResumeDataWarehouse();
        }

        /// <summary>
        /// Resume an Azure SQL Data Warehouse database asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouseBeta.ResumeDataWarehouseAsync(CancellationToken cancellationToken)
        {
 
            await this.ResumeDataWarehouseAsync(cancellationToken);
        }

        /// <summary>
        /// Pause an Azure SQL Data Warehouse database.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse.PauseDataWarehouse()
        {
 
            this.PauseDataWarehouse();
        }

        /// <summary>
        /// Pause an Azure SQL Data Warehouse database asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouseBeta.PauseDataWarehouseAsync(CancellationToken cancellationToken)
        {
 
            await this.PauseDataWarehouseAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name;
            }
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName;
            }
        }

        /// <summary>
        /// Gets the tags for the resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type;
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id;
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName;
            }
        }

        /// <summary>
        /// Gets the manager client of this resource type.
        /// </summary>
        Microsoft.Azure.Management.Sql.Fluent.ISqlManager Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Sql.Fluent.ISqlManager>.Manager
        {
            get
            {
                return this.Manager as Microsoft.Azure.Management.Sql.Fluent.ISqlManager;
            }
        }

        /// <summary>
        /// Gets the current Service Level Objective Id of the Azure SQL Database, this is the Id of the
        /// Service Level Objective that is currently active.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.CurrentServiceObjectiveId
        {
            get
            {
                return this.CurrentServiceObjectiveId();
            }
        }

        /// <summary>
        /// Gets the max size of the Azure SQL Database expressed in bytes.
        /// </summary>
        long Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.MaxSizeBytes
        {
            get
            {
                return this.MaxSizeBytes();
            }
        }

        /// <summary>
        /// Gets the Id of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.DatabaseId
        {
            get
            {
                return this.DatabaseId();
            }
        }

        /// <summary>
        /// Gets the Service Level Objective of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ServiceLevelObjective
        {
            get
            {
                return this.ServiceLevelObjective();
            }
        }

        /// <return>The upgradeHint value.</return>
        Microsoft.Azure.Management.Sql.Fluent.IUpgradeHintInterface Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.GetUpgradeHint()
        {
            return this.GetUpgradeHint() as Microsoft.Azure.Management.Sql.Fluent.IUpgradeHintInterface;
        }

        /// <summary>
        /// Gets name of the SQL Server to which this database belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets the configured Service Level Objective Id of the Azure SQL
        /// Database, this is the Service Level Objective that is being applied to
        /// the Azure SQL Database.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.RequestedServiceObjectiveId
        {
            get
            {
                return this.RequestedServiceObjectiveId();
            }
        }

        /// <summary>
        /// Gets the edition of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Edition
        {
            get
            {
                return this.Edition();
            }
        }

        /// <return>SqlWarehouse instance for more operations.</return>
        Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.AsWarehouse()
        {
            return this.AsWarehouse() as Microsoft.Azure.Management.Sql.Fluent.ISqlWarehouse;
        }

        /// <summary>
        /// Gets the collation of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Collation
        {
            get
            {
                return this.Collation();
            }
        }

        /// <return>All the replication links associated with the database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListReplicationLinks()
        {
            return this.ListReplicationLinks() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>;
        }

        /// <summary>
        /// Gets the defaultSecondaryLocation value.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.DefaultSecondaryLocation
        {
            get
            {
                return this.DefaultSecondaryLocation();
            }
        }

        /// <summary>
        /// Gets the recovery period start date of the Azure SQL Database. This
        /// records the start date and time when recovery is available for this
        /// Azure SQL Database.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.EarliestRestoreDate
        {
            get
            {
                return this.EarliestRestoreDate();
            }
        }

        /// <summary>
        /// Gets the elasticPoolName value.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ElasticPoolName
        {
            get
            {
                return this.ElasticPoolName();
            }
        }

        /// <return>Returns the list of usages (DatabaseMetrics) of the database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListUsages()
        {
            return this.ListUsages() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IDatabaseMetric>;
        }

        /// <summary>
        /// Gets the status of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.Status
        {
            get
            {
                return this.Status();
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

        /// <summary>
        /// Gets the creation date of the Azure SQL Database.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <summary>
        /// Gets the name of the configured Service Level Objective of the Azure
        /// SQL Database, this is the Service Level Objective that is being
        /// applied to the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.RequestedServiceObjectiveName
        {
            get
            {
                return this.RequestedServiceObjectiveName();
            }
        }

        /// <return>Information about service tier advisors for specified database.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListServiceTierAdvisors()
        {
            return this.ListServiceTierAdvisors() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Sql.Fluent.IServiceTierAdvisor>;
        }

        /// <return>Returns the list of all restore points on the database.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint> Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.ListRestorePoints()
        {
            return this.ListRestorePoints() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.IRestorePoint>;
        }

        /// <summary>
        /// Gets true if this Database is SqlWarehouse.
        /// </summary>
        bool Microsoft.Azure.Management.Sql.Fluent.ISqlDatabase.IsDataWarehouse
        {
            get
            {
                return this.IsDataWarehouse();
            }
        }
    }
}