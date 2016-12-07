// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Replication link.
    /// </summary>
    public interface IReplicationLink  :
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>,
        IWrapper<Models.ReplicationLinkInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <return>The replication state for the replication link.</return>
        string ReplicationState { get; }

        /// <return>The role of the SQL Database in the replication link.</return>
        Models.ReplicationRole Role { get; }

        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string DatabaseName { get; }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string SqlServerName { get; }

        /// <return>The name of the Azure SQL Server hosting the partner Azure SQL Database.</return>
        string PartnerServer { get; }

        /// <return>The role of the partner SQL Database in the replication link.</return>
        Models.ReplicationRole PartnerRole { get; }

        /// <return>The percentage of the seeding completed for the replication link.</return>
        int PercentComplete { get; }

        /// <summary>
        /// Deletes the replication link.
        /// </summary>
        void Delete();

        /// <summary>
        /// Forces fail over the Azure SQL Database Replication Link which may result in data loss.
        /// </summary>
        void ForceFailoverAllowDataLoss();

        /// <summary>
        /// Fails over the Azure SQL Database Replication Link.
        /// </summary>
        void Failover();

        /// <return>The name of the partner Azure SQL Database.</return>
        string PartnerDatabase { get; }

        /// <return>Start time for the replication link (ISO8601 format).</return>
        System.DateTime StartTime { get; }

        /// <return>The Azure Region of the partner Azure SQL Database.</return>
        string PartnerLocation { get; }
    }
}