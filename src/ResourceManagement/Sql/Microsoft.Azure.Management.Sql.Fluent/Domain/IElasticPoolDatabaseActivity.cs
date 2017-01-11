// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL ElasticPool's Database Activity.
    /// </summary>
    public interface IElasticPoolDatabaseActivity  :
        IWrapper<Models.ElasticPoolDatabaseActivityInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <summary>
        /// Gets the database name.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets the name of the current Elastic Pool the database is in if available.
        /// </summary>
        string CurrentElasticPoolName { get; }

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
        /// Gets the name of the current service objective if available.
        /// </summary>
        string CurrentServiceObjective { get; }

        /// <summary>
        /// Gets the name for the Elastic Pool the database is moving into if available.
        /// </summary>
        string RequestedElasticPoolName { get; }

        /// <summary>
        /// Gets the name of the requested service objective if available.
        /// </summary>
        string RequestedServiceObjective { get; }

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