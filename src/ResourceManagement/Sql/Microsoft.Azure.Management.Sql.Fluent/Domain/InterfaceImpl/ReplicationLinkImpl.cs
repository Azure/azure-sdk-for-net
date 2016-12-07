// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;


    internal partial class ReplicationLinkImpl 
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Sql.Fluent.IReplicationLink Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Sql.Fluent.IReplicationLink;
        }

        /// <return>The replication state for the replication link.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.ReplicationState
        {
            get
            {
                return this.ReplicationState() as string;
            }
        }

        /// <return>The Azure Region of the partner Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PartnerLocation
        {
            get
            {
                return this.PartnerLocation() as string;
            }
        }

        /// <return>The role of the partner SQL Database in the replication link.</return>
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

        /// <return>Start time for the replication link (ISO8601 format).</return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.StartTime
        {
            get
            {
                return this.StartTime();
            }
        }

        /// <return>The name of the partner Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PartnerDatabase
        {
            get
            {
                return this.PartnerDatabase() as string;
            }
        }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.SqlServerName
        {
            get
            {
                return this.SqlServerName() as string;
            }
        }

        /// <summary>
        /// Deletes the replication link.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.Delete()
        {
 
            this.Delete();
        }

        /// <return>The percentage of the seeding completed for the replication link.</return>
        int Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PercentComplete
        {
            get
            {
                return this.PercentComplete();
            }
        }

        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.DatabaseName
        {
            get
            {
                return this.DatabaseName() as string;
            }
        }

        /// <return>The name of the Azure SQL Server hosting the partner Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.PartnerServer
        {
            get
            {
                return this.PartnerServer() as string;
            }
        }

        /// <return>The role of the SQL Database in the replication link.</return>
        Models.ReplicationRole Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.Role
        {
            get
            {
                return this.Role();
            }
        }

        /// <summary>
        /// Forces fail over the Azure SQL Database Replication Link which may result in data loss.
        /// </summary>
        void Microsoft.Azure.Management.Sql.Fluent.IReplicationLink.ForceFailoverAllowDataLoss()
        {
 
            this.ForceFailoverAllowDataLoss();
        }

        /// <return>The resource ID string.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id() as string;
            }
        }

        /// <return>The name of the resource group.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName() as string;
            }
        }
    }
}