// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL ElasticPool's Activity.
    /// </summary>
    public interface IElasticPoolActivity  :
        IWrapper<Models.ElasticPoolActivityInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <summary>
        /// Gets the name of the Elastic Pool.
        /// </summary>
        string ElasticPoolName { get; }

        /// <summary>
        /// Gets the requested min DTU per database if available.
        /// </summary>
        int RequestedDatabaseDtuMin { get; }

        /// <summary>
        /// Gets the error message if available.
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Gets the error severity if available.
        /// </summary>
        int ErrorSeverity { get; }

        /// <summary>
        /// Gets the error code if available.
        /// </summary>
        int ErrorCode { get; }

        /// <summary>
        /// Gets the name of the Azure SQL Server the Elastic Pool is in.
        /// </summary>
        string ServerName { get; }

        /// <summary>
        /// Gets the percentage complete if available.
        /// </summary>
        int PercentComplete { get; }

        /// <summary>
        /// Gets the requested DTU for the pool if available.
        /// </summary>
        int RequestedDtu { get; }

        /// <summary>
        /// Gets the requested name for the Elastic Pool if available.
        /// </summary>
        string RequestedElasticPoolName { get; }

        /// <summary>
        /// Gets the requested storage limit for the pool in GB if available.
        /// </summary>
        long RequestedStorageLimitInGB { get; }

        /// <summary>
        /// Gets the requested max DTU per database if available.
        /// </summary>
        int RequestedDatabaseDtuMax { get; }

        /// <summary>
        /// Gets the unique operation ID.
        /// </summary>
        string OperationId { get; }

        /// <summary>
        /// Gets the time the operation started (ISO8601 format).
        /// </summary>
        System.DateTime StartTime { get; }

        /// <summary>
        /// Gets the time the operation finished (ISO8601 format).
        /// </summary>
        System.DateTime EndTime { get; }

        /// <summary>
        /// Gets the current state of the operation.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Gets the operation name.
        /// </summary>
        string Operation { get; }
    }
}