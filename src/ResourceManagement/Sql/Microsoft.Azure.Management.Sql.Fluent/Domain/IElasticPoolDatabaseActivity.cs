// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
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
        /// <return>The database name.</return>
        string DatabaseName { get; }

        /// <return>The name of the current Elastic Pool the database is in if available.</return>
        string CurrentElasticPoolName { get; }

        /// <return>The error message if available.</return>
        string ErrorMessage { get; }

        /// <return>The error severity if available.</return>
        int ErrorSeverity { get; }

        /// <return>The error code if available.</return>
        int ErrorCode { get; }

        /// <return>The name of the Azure SQL Server the Elastic Pool is in.</return>
        string ServerName { get; }

        /// <return>The percentage complete if available.</return>
        int PercentComplete { get; }

        /// <return>The name of the current service objective if available.</return>
        string CurrentServiceObjective { get; }

        /// <return>The name for the Elastic Pool the database is moving into if available.</return>
        string RequestedElasticPoolName { get; }

        /// <return>The name of the requested service objective if available.</return>
        string RequestedServiceObjective { get; }

        /// <return>The unique operation ID.</return>
        string OperationId { get; }

        /// <return>The time the operation started (ISO8601 format).</return>
        System.DateTime StartTime { get; }

        /// <return>The time the operation finished (ISO8601 format).</return>
        System.DateTime EndTime { get; }

        /// <return>The current state of the operation.</return>
        string State { get; }

        /// <return>The operation name.</return>
        string Operation { get; }
    }
}