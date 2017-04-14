// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Rest;
    using System;

    internal partial class ReplicationLinkImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the replication state for the replication link.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.ReplicationState
        {
            get
            {
                return this.ReplicationState();
            }
        }

        /// <summary>
        /// Forces fail over the Azure SQL Database Replication Link which may result in data loss.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.ForceFailoverAllowDataLossAsync(CancellationToken cancellationToken)
        {
 
            await this.ForceFailoverAllowDataLossAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the Azure Region of the partner Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PartnerLocation
        {
            get
            {
                return this.PartnerLocation();
            }
        }

        /// <summary>
        /// Gets the role of the partner SQL Database in the replication link.
        /// </summary>
        Models.ReplicationRole Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PartnerRole
        {
            get
            {
                return this.PartnerRole();
            }
        }

        /// <summary>
        /// Fails over the Azure SQL Database Replication Link.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.Failover()
        {
 
            this.Failover();
        }

        /// <summary>
        /// Gets start time for the replication link (ISO8601 format).
        /// </summary>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <summary>
        /// Gets the name of the partner Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PartnerDatabase
        {
            get
            {
                return this.PartnerDatabase();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Deletes the replication link.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.Delete()
        {
 
            this.Delete();
        }

        /// <summary>
        /// Gets the percentage of the seeding completed for the replication link.
        /// </summary>
        int Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PercentComplete
        {
            get
            {
                return this.PercentComplete();
            }
        }

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.DatabaseName
        {
            get
            {
                return this.DatabaseName();
            }
        }

        /// <summary>
        /// Gets the name of the Azure SQL Server hosting the partner Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PartnerServer
        {
            get
            {
                return this.PartnerServer();
            }
        }

        /// <summary>
        /// Forces fail over the Azure SQL Database Replication Link which may result in data loss.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.ForceFailoverAllowDataLoss()
        {
 
            this.ForceFailoverAllowDataLoss();
        }

        /// <summary>
        /// Fails over the Azure SQL Database Replication Link.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.FailoverAsync(CancellationToken cancellationToken)
        {
 
            await this.FailoverAsync(cancellationToken);
        }

        /// <summary>
        /// Gets the role of the SQL Database in the replication link.
        /// </summary>
        Models.ReplicationRole Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.Role
        {
            get
            {
                return this.Role();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }
    }
}