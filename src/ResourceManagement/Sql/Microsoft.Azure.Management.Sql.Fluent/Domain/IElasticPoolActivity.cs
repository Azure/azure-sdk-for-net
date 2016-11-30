// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL ElasticPool's Activity.
    /// </summary>
    public interface IElasticPoolActivity  :
        IWrapper<Models.ElasticPoolActivityInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <return>The name of the Elastic Pool.</return>
        string ElasticPoolName { get; }

        /// <return>The requested min DTU per database if available.</return>
        int RequestedDatabaseDtuMin { get; }

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

        /// <return>The requested DTU for the pool if available.</return>
        int RequestedDtu { get; }

        /// <return>The requested name for the Elastic Pool if available.</return>
        string RequestedElasticPoolName { get; }

        /// <return>The requested storage limit for the pool in GB if available.</return>
        long RequestedStorageLimitInGB { get; }

        /// <return>The requested max DTU per database if available.</return>
        int RequestedDatabaseDtuMax { get; }

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