// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using Microsoft.Rest;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Replication link.
    /// </summary>
    public interface IReplicationLink  :
        IReplicationLinkBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IReplicationLink>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ReplicationLinkInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId
    {
        /// <summary>
        /// Gets the name of the Azure SQL Server hosting the partner Azure SQL Database.
        /// </summary>
        string PartnerServer { get; }

        /// <summary>
        /// Gets the percentage of the seeding completed for the replication link.
        /// </summary>
        int PercentComplete { get; }

        /// <summary>
        /// Gets the replication state for the replication link.
        /// </summary>
        string ReplicationState { get; }

        /// <summary>
        /// Fails over the Azure SQL Database Replication Link.
        /// </summary>
        void Failover();

        /// <summary>
        /// Forces fail over the Azure SQL Database Replication Link which may result in data loss.
        /// </summary>
        void ForceFailoverAllowDataLoss();

        /// <summary>
        /// Gets the Azure Region of the partner Azure SQL Database.
        /// </summary>
        string PartnerLocation { get; }

        /// <summary>
        /// Gets start time for the replication link (ISO8601 format).
        /// </summary>
        System.DateTime StartTime { get; }

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets the role of the partner SQL Database in the replication link.
        /// </summary>
        Models.ReplicationRole PartnerRole { get; }

        /// <summary>
        /// Deletes the replication link.
        /// </summary>
        void Delete();

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the role of the SQL Database in the replication link.
        /// </summary>
        Models.ReplicationRole Role { get; }

        /// <summary>
        /// Gets the name of the partner Azure SQL Database.
        /// </summary>
        string PartnerDatabase { get; }
    }
}