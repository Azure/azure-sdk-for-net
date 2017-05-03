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
    /// Members of IReplicationLink that are in Beta.
    /// </summary>
    public interface IReplicationLinkBeta  : IBeta
    {
        /// <summary>
        /// Forces fail over the Azure SQL Database Replication Link which may result in data loss.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ForceFailoverAllowDataLossAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Fails over the Azure SQL Database Replication Link.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task FailoverAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}